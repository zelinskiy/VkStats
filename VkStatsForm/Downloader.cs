using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.RequestParams;
using VkNet.Utils;

using VkStatsForm.Models;

namespace VkStatsForm
{
    public class Downloader
    {
        private readonly Action<string> Log;
        private readonly VkNet.Model.Group Group;

        private readonly VkApi api;

        private readonly Context db;

        public Downloader(Action<string> log)
        {
            Log = log;


            var login = SettingsStorage.Login;
            var pass = SettingsStorage.Password;
            var applicationId = SettingsStorage.AppId;
            var groupName = SettingsStorage.GroupName;

            db = new Context();

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

            Log($"Downloader for {groupName} created");
        }

        //Assuming groups list do not change
        public void DownloadAllGroups(CancellationToken ct)
        {
            Log($"Begin to load publics");
            var users = db.Users
                .Where(u => db.GroupUsers.Count(gu => gu.UserId == u.VkId) == 0)
                .ToArray();
            foreach (var u in users)
            {
                Log($"Loading 100 publics for user {u.Id}");
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

                    Log($"Loaded 100 publics for user {u.Id}");
                    foreach (var g in gs)
                    {
                        if (ct.IsCancellationRequested) return;
                        if (db.GroupUsers.Count(
                            gu => gu.UserId == u.VkId
                                && gu.GroupId == g.Id) == 0)
                        {
                            Log($"Saving connection between user {u.Id} and public {g.Id}");
                            db.GroupUsers.Add(new GroupUser
                            {
                                GroupId = g.Id,
                                UserId = u.VkId
                            });
                        }
                        else
                        {
                            Log($"Skipping connection between user {u.Id} and public {g.Id}");
                        }

                        if (db.Groups.Count(x => x.VkId == g.Id) == 0)
                        {
                            Log($"Saving public {g.Id}");
                            db.Groups.Add(new Group
                            {
                                VkId = g.Id,
                                Name = g.Name
                            });
                        }
                        else
                        {
                            Log($"Skipping public {g.Id}");
                        }
                        db.SaveChanges();
                    }
                }
                catch (AccessDeniedException ae)
                {
                    Log($"User {u.Id} restricted acess");
                }

            }
            Log($"Ended loading groups");

        }

        public void DownloadAllSubscribers(CancellationToken ct)
        {
            var nmembers = Group.MembersCount.Value;
            Log($"Begin to load {nmembers} subscribers");
            for (int i = 0; i < nmembers; i += 1000)
            {
                Log($"Loading subs from {i} to {i + 1000} ");
                var usersPortion = api.Groups.GetMembers(
                    new GroupsGetMembersParams
                    {
                        Offset = i < nmembers ? i : nmembers % i,
                        GroupId = Group.ScreenName,
                        Fields = UsersFields.Contacts
                    });
                Log($"Loaded subs from {i} to {i + 1000} ");
                foreach (var u in usersPortion)
                {
                    if (ct.IsCancellationRequested) return;

                    if (u.IsDeactivated)
                    {
                        Log($"User {u.Id} deactivated, skipping");
                    }
                    else if (db.Users.Count(x => x.VkId == u.Id) > 0)
                    {
                        Log($"User {u.Id} already in DB, skipping");
                    }
                    else
                    {

                        var newUser = new User()
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            IsSub = 1,
                            VkId = u.Id
                        };
                        db.Users.Add(newUser);
                        db.SaveChanges();
                        Log($"Added user {u.Id}");
                    }

                }

            }
            Log("Ended loading subscribers");
        }

        //TODO : fix i in logs
        public void DownloadAllPosts(CancellationToken ct)
        {
            Log("Begin to load posts");
            var wall = api.Wall.Get(new WallGetParams()
            {
                Count = 100,
                Domain = Group.Name,
                OwnerId = (-1) * Group.Id
            });
            var wallposts = wall.WallPosts.ToList();
            Log($"Loaded {wallposts.Count} posts of {wall.TotalCount}");

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
                Log($"Loaded {wallposts.Count} posts of {wall.TotalCount}");
            }

            foreach (var p in wallposts)
            {
                if (ct.IsCancellationRequested) return;
                if (db.Posts.Count(px => px.VkId == p.Id.Value) == 0)
                {
                    db.Posts.Add(new Post
                    {
                        Text = p.Text,
                        VkId = p.Id.Value
                    });
                    db.SaveChanges();
                    Log($"Saved post {p.Id.Value}");
                }
                else
                {
                    Log($"Skipped post {p.Id.Value} ");
                }


            }

        }

        public void DownloadAllComments(CancellationToken ct, 
            int skip = 0, int take = int.MaxValue)
        {
            Log("Begin to load comments");
            foreach (var savedPost in db.Posts.ToList().Skip(skip).Take(take))
            {
                if (ct.IsCancellationRequested) return;

                Log($"Begin to load comments for post {savedPost.VkId}");
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
                    Log($"Skipping, no comments added to post {savedPost.VkId}"
                        + " (Or there are no comments at all)");
                    continue;
                }
                var comments = post.ToList();
                Log($"Loaded {comments.Count} comments of {post.TotalCount}");
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
                    Log($"Loaded {comments.Count} comments of {post.TotalCount}");
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
                        Log($"Saved comment {c.Id} " +
                            $"from user {c.FromId} under {savedPost.VkId}");
                    }
                    else
                    {
                        Log($"Skipped comment {c.Id}");
                    }

                }


            }
            Log("Ended loading comments");
        }

        private void DownloadLikes(CancellationToken ct, LikeObjectType t, uint? count,
            long type, IEnumerable<long> objectIds)
        {
            foreach (var o in objectIds)
            {
                if (ct.IsCancellationRequested) return;
                var likes = api.Likes.GetList(new LikesGetListParams
                {
                    OwnerId = (-1) * Group.Id,
                    Type = t,
                    Count = count,
                    ItemId = o
                })
                .Where(lx => lx > 0)
                .Select(id => new Like
                {
                    ObjectId = o,
                    Type = type,
                    UserId = id
                })
                .Except(db.Likes.ToArray(), new Like.Comparer());

                db.Likes.AddRange(likes);
                db.SaveChanges();
                Log($"Added {likes.Count()} likes");

            }
        }

        //Assuming there are no comments with over 250 likes
        public void DownloadAllCommentLikes(CancellationToken ct)
        {
            DownloadLikes(ct,
                LikeObjectType.Comment,
                250,
                2,
                db.Comments
                    .Where(c => c.Likes > 0)
                    .Select(c => c.VkId)
                    .ToArray());

        }

        //Assuming there are no posts with over 1000 likes
        public void DownloadAllPostLikes(CancellationToken ct)
        {
            DownloadLikes(ct, 
                LikeObjectType.Post,
                1000,
                1,
                db.Posts
                    .Select(p => p.VkId)
                    .ToArray());
        }


        public void DownloadAllNonSubscribers(CancellationToken ct)
        {
            var ids = db.Likes.Select(l => l.UserId)
                .Union(db.Comments.Select(c => c.UserId))
                .Where(i => db.Users.Count(u => u.VkId == i) == 0)
                .Where(i => i > 0)
                .ToList();
            Log($"Loading {ids.Count} users");
            
            var users = api.Users.Get(ids, ProfileFields.Contacts);
            if (ct.IsCancellationRequested) return;
            Log($"Loaded {users.Count()} users");
            db.Users.AddRange(users.Select(u => new User
            {
                VkId = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                IsSub = 0
            }));
            db.SaveChanges();
            Log($"Saved {users.Count} users");


        }


    }

}
