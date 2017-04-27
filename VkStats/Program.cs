using Newtonsoft.Json;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkStats
{  
    public class User
    {
        public Int64 Id { get; set; }
        [Index(IsUnique = true)]
        public Int64 VkId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsSub;
    }

    public class Group
    {
        public Int64 Id { get; set; }
        [Index(IsUnique = true)]
        public Int64 VkId { get; set; }
        public string Name { get; set; }
    }

    public class GroupUser
    {
        [Key]
        public Int64 GroupId { get; set; }

        [Key]
        public Int64 UserId { get; set; }
    }

    public class Post
    {
        public Int64 Id { get; set; }
        [Index(IsUnique = true)]
        public Int64 VkId { get; set; }
        public string Text { get; set; }
        public Int64 NComments { get; set; }
    }

    public class Comment
    {
        public Int64 Id { get; set; }
        [Index(IsUnique = true)]
        public Int64 VkId { get; set; }
        public Int64 PostId { get; set; }
        public Int64 Likes { get; set; }
        public string Text { get; set; }
        public Int64 UserId { get; set; }
    }

    public class Like
    {
        public Int64 Id { get; set; }
        public Int64 UserId { get; set; }
        public Int64 ObjectId { get; set; }
        // 1 - Post
        // 2 - Comment
        public Int64 Type { get; set; }
    
        public override bool Equals(object obj)
        {
            var like = obj as Like;
            if(like != null)
            {
                return like.UserId == UserId 
                    && like.Type == Type 
                    && like.ObjectId == ObjectId;
            }
            return base.Equals(obj);
        }
    }

    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupUser>()
                .HasKey(gu => new { gu.GroupId, gu.UserId });

            var initializer = new SqliteCreateDatabaseIfNotExists<MyContext>(modelBuilder);
            Database.SetInitializer(initializer);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
    }



    public class Downloader
    {

        private readonly VkNet.Model.Group Group;

        private readonly VkApi api;

        private readonly MyContext db;

        public Downloader()
        {
            var storedSecrets = System.IO.File.ReadLines("..\\..\\secrets.txt").ToArray();
            var login = storedSecrets[0];
            var pass = storedSecrets[1];
            var applicationId = ulong.Parse(storedSecrets[2]);
            var groupName = storedSecrets[3];

            db = new MyContext();


            api = new VkApi();
            api.Authorize(new ApiAuthParams
            {
                ApplicationId = applicationId,
                Login = login,
                Password = pass,
                Settings = Settings.All
            });

            Group = api.Groups.GetById(
                new List<string>(),
                groupName,
                GroupsFields.All)
            .First();

            Logger.Log($"Analyzer for {groupName} created");
        }

        //Assuming groups list do not change
        public void DownloadAllGroups()
        {
            Logger.Log($"Begin to load publics");
            var users = db.Users
                .Where(u => db.GroupUsers.Count(gu => gu.UserId == u.VkId) == 0)
                .ToArray();
            foreach (var u in users)
            {
                Logger.Log($"Loading 100 publics for user {u.Id}");
                VkCollection<VkNet.Model.Group> gs;
                try
                {
                    gs = api.Groups.Get(new GroupsGetParams
                    {
                        UserId = u.VkId,
                        Extended = true,
                        Fields = GroupsFields.Contacts,
                        Count = 100,
                        Filter = GroupsFilters.Publics
                    });

                    Logger.Log($"Loaded 100 publics for user {u.Id}");
                    foreach (var g in gs)
                    {
                        if (db.GroupUsers.Count(
                            gu => gu.UserId == u.VkId
                                && gu.GroupId == g.Id) == 0)
                        {
                            Logger.Log($"Saving connection between user {u.Id} and public {g.Id}");
                            db.GroupUsers.Add(new GroupUser
                            {
                                GroupId = g.Id,
                                UserId = u.VkId
                            });
                        }
                        else
                        {
                            Logger.Log($"Skipping connection between user {u.Id} and public {g.Id}");
                        }

                        if (db.Groups.Count(x => x.VkId == g.Id) == 0)
                        {
                            Logger.Log($"Saving public {g.Id}");
                            db.Groups.Add(new VkStats.Group
                            {
                                VkId = g.Id,
                                Name = g.Name
                            });                            
                        }
                        else
                        {
                            Logger.Log($"Skipping public {g.Id}");
                        }
                        db.SaveChanges();
                    }
                }
                catch(AccessDeniedException ae)
                {
                    Logger.Log($"User {u.Id} restricted acess");
                }               
                
            }
            Logger.Log($"Ended loading groups");

        }
            
        public void DownloadAllSubscribers()
        {            
            var nmembers = Group.MembersCount.Value;
            Logger.Log($"Begin to load {nmembers} subscribers");
            for (int i = 0; i < nmembers; i += 1000)
            {
                Logger.Log($"Loading subs from {i} to {i+1000} ");
                var usersPortion = api.Groups.GetMembers(
                    new GroupsGetMembersParams
                    {
                        Offset = i < nmembers ? i : nmembers % i,
                        GroupId = Group.ScreenName,
                        Fields = UsersFields.Contacts
                    });
                Logger.Log($"Loaded subs from {i} to {i + 1000} ");
                foreach (var u in usersPortion)
                {
                    if (u.IsDeactivated)
                    {
                        Logger.Log($"User {u.Id} deactivated, skipping");
                    }
                    else if (db.Users.Count(x => x.VkId == u.Id) > 0)
                    {
                        Logger.Log($"User {u.Id} already in DB, skipping");
                    }
                    else 
                    {
                        
                        var newUser = new User()
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            IsSub = true,
                            VkId = u.Id
                        };
                        db.Users.Add(newUser);
                        db.SaveChanges();
                        Logger.Log($"Added user {u.Id}");
                    }

                }
                
            }
            Logger.Log("Ended loading subscribers");
        }

        //TODO : fix i in logs
        public void DownloadAllPosts()
        {
            Logger.Log("Begin to load posts");
            var wall = api.Wall.Get(new WallGetParams()
            {
                Count = 100,
                Domain = Group.Name,
                OwnerId = (-1) * Group.Id
            });
            var wallposts = wall.WallPosts.ToList();
            Logger.Log($"Loaded {wallposts.Count} posts of {wall.TotalCount}");
            
            for (ulong i = 100; i < wall.TotalCount; i += 100)
            {
                var cur_offset = i < wall.TotalCount ? i : wall.TotalCount % i;
                var portionPosts = api.Wall.Get(new WallGetParams()
                {
                    Count = 100,
                    Offset = cur_offset,
                    Domain = Group.Name
                });
                wallposts.AddRange(portionPosts.WallPosts);
                Logger.Log($"Loaded {wallposts.Count} posts of {wall.TotalCount}");
            }

            foreach(var p in wallposts)
            {
                if(db.Posts.Count(px => px.VkId == p.Id.Value) == 0)
                {
                    db.Posts.Add(new Post
                    {
                        Text = p.Text,
                        VkId = p.Id.Value
                    });
                    db.SaveChanges();
                    Logger.Log($"Saved post {p.Id.Value} \" {Logger.FixString(p.Text, 1000)} \"");
                }
                else
                {
                    Logger.Log($"Skipped post {p.Id.Value} ");
                }
                

            }

        }

        public void DownloadAllComments(int skip = 0, int take = int.MaxValue)
        {
            Logger.Log("Begin to load comments");
            foreach(var savedPost in db.Posts.ToList().Skip(skip).Take(take))
            {
                Logger.Log($"Begin to load comments for post {savedPost.VkId}");
                var post = api.Wall.GetComments(
                    new WallGetCommentsParams
                {
                    Count = 100,
                    Offset = 0,
                    NeedLikes = true,
                    OwnerId = (-1) * Group.Id,
                    PostId = savedPost.VkId,
                });

                if ((ulong)savedPost.NComments == post.TotalCount)
                {
                    Logger.Log($"Skipping, no comments added to post {savedPost.VkId}"
                        + " (Or there are no comments at all)");
                    continue;
                }
                var comments = post.ToList();
                Logger.Log($"Loaded {comments.Count} comments of {post.TotalCount}");
                for (ulong i = 100; i < post.TotalCount; i += 100)
                {
                    var cur_offset = i < post.TotalCount ? i : post.TotalCount % i;

                    var commentsPortion = api.Wall.GetComments(
                        new WallGetCommentsParams
                    {
                        Count = 100,
                        Offset = (long)cur_offset,
                        NeedLikes = true,
                        OwnerId = (-1) * Group.Id,
                    });
                    comments.AddRange(commentsPortion.ToList());
                    Logger.Log($"Loaded {comments.Count} comments of {post.TotalCount}");
                }

                var ppost = db.Posts.First(p => p.VkId == savedPost.VkId);
                ppost.NComments = (long)post.TotalCount;
                db.SaveChanges();

                foreach (var c in comments)
                {
                    if (db.Comments.Count(cx => cx.VkId == c.Id) == 0 
                        && c.FromId > 0)
                    {
                        db.Comments.Add(new Comment
                        {
                            Text = c.Text,
                            Likes = c.Likes.Count,
                            PostId = savedPost.VkId,
                            UserId = c.FromId,
                            VkId = c.Id,
                        });
                        db.SaveChanges();
                        Logger.Log($"Saved comment {c.Id} " + 
                            $"from user {c.FromId} under {savedPost.VkId}");
                    }
                    else
                    {
                        Logger.Log($"Skipped comment {c.Id}");
                    }
                    
                }

                
            }
            Logger.Log("Ended loading comments");
        }

        //Assuming there are no comments with over 250 likes
        public void DownloadAllCommentLikes()
        {
            foreach(var c in db.Comments.Where(cx => cx.Likes > 0).ToArray())
            {
                var likes = api.Likes.GetList(new LikesGetListParams
                {
                    OwnerId = (-1) * Group.Id,
                    Type = LikeObjectType.Comment,
                    Count = 250,
                    ItemId = c.VkId
                })
                .Where(lx => lx > 0)
                .Select(id => new Like
                {
                    ObjectId = c.VkId,
                    Type = 2,
                    UserId = id
                })
                .Where(lx => db.Likes.Count(sl => sl == lx) == 0);

                foreach(var l in likes)
                {
                    db.Likes.Add(l);                    
                }
                
                db.SaveChanges();
                Logger.Log($"Added {likes.Count()} likes for comment {c.VkId}");

            }
            
        }

        //Assuming there are no posts with over 1000 likes
        public void DownloadAllPostLikes()
        {
            foreach (var p in db.Posts.ToArray())
            {
                var likes = api.Likes.GetList(new LikesGetListParams
                {
                    OwnerId = (-1) * Group.Id,
                    Type = LikeObjectType.Post,
                    Count = 1000,
                    ItemId = p.VkId
                })
                .Where(lx => lx > 0)
                .Select(id => new Like
                {
                    ObjectId = p.VkId,
                    Type = 1,
                    UserId = id
                })
                .Where(lx => db.Likes.Count(sl => sl == lx) == 0);

                foreach (var l in likes)
                {
                    db.Likes.Add(l);
                }

                db.SaveChanges();
                Logger.Log($"Added {likes.Count()} likes for post {p.VkId}");

            }

        }
    }

        

    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("BEGIN");
            
            
            var a = new Downloader();
            var db = new MyContext();
            //a.DownloadAllSubscribers();
            //a.DownloadAllGroups();
            //a.DownloadAllPosts();
            a.DownloadAllComments();
            a.DownloadAllCommentLikes();
            
            
            Console.WriteLine("END");
            Console.ReadKey();
        }
        
    }
}
