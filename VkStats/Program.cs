﻿using Newtonsoft.Json;
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
using VkStats.Models;

namespace VkStats
{

   
    public class User
    {
        public Int64 Id { get; set; }
        [Index(IsUnique = true)]
        public Int64 VkId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Group
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
    }

    public class GroupUser
    {
        [Key]
        public Int64 GroupId { get; set; }

        [Key]
        public Int64 UserId { get; set; }
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
    }

    static class Logger
    {
        static readonly DateTime beginAt = DateTime.Now;
        public static void Log(string message)
        {
            var t = DateTime.Now.ToString("HH:mm:ss");
            var delta = (DateTime.Now - beginAt);
            Console.WriteLine($"[LOG] [{t}] {message}");
        }

        /// <summary>
        /// Extends or crops string to fixed size
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="length">Desirable length</param>
        /// <returns></returns>
        public static string FixString(string input, int length)
        {
            if (input.Length >= length)
            {
                return string.Concat(input.Take(length));
            }
            return input + new string(' ', length - input.Length);
        }
    }

    public class Analyzer
    {
        private const string GroupName = "knnrk.media";

        private readonly VkNet.Model.Group Group;

        private readonly VkApi VkApi;

        public Analyzer()
        {
            var storedSecrets = System.IO.File.ReadLines("..\\..\\secrets.txt").ToArray();
            var login = storedSecrets[0];
            var pass = storedSecrets[1];
            var applicationId = ulong.Parse(storedSecrets[2]);
            

            VkApi = new VkApi();
            VkApi.Authorize(new ApiAuthParams
            {
                ApplicationId = applicationId,
                Login = login,
                Password = pass,
                Settings = Settings.All
            });

            Group = VkApi.Groups.GetById(
                new List<string>(),
                GroupName, 
                GroupsFields.All)
            .First();
        }

        /// <summary>
        /// Returns all active (non-dogs) subscribers
        /// </summary>
        /// <returns>List of ids</returns>
        private List<long> GetAllSubscribers()
        {
            Logger.Log("Begin to load subscribers");
            var res = new List<long>();
            var nmembers = Group.MembersCount.Value;
            for (int i = 0; i < nmembers; i += 1000)
            {
                res.AddRange(VkApi.Groups.GetMembers(new GroupsGetMembersParams
                {
                     Offset = i < nmembers ? i : nmembers % i,
                     GroupId = Group.ScreenName                     
                })
                .Select(m => m.Id));
            }
            Logger.Log("Ended loading subscribers");
            return res;            
        }


        //TODO:
        //Offsets
        //Group reposts
        private List<WallPostStats> GetWallPostsStats(ulong maxcount = 100)
        {
            Logger.Log("Started loading wallposts");
            var res = new List<WallPostStats>();

            var wall = VkApi.Wall.Get(new WallGetParams
            {
                Count = maxcount < 100 ? maxcount : 100,
                Domain = GroupName,
                Extended = false,
                Filter = WallFilter.All
            });

            foreach (var w in wall.WallPosts)
            {
                Logger.Log($"Loading wallpost {w.Id}");
                var wallStat = new WallPostStats(w.Id.Value);

                var reposts = VkApi.Wall.GetReposts((-1) * Group.Id, w.Id, 0, 1000);
                wallStat.Reposters.AddRange(reposts.Profiles.Select(p => p.Id));

                Logger.Log($"Loading comments for wallpost {w.Id}");
                var comments = VkApi.Wall.GetComments(new WallGetCommentsParams
                {
                    Count = 100,
                    Extended = false,
                    OwnerId = (-1) * Group.Id,
                    PostId = w.Id.Value,
                    NeedLikes = true
                });

                wallStat.Commenters.AddRange(comments.Select(c => c.FromId));
                foreach (var c in comments.Where(c => c.Likes.Count > 0))
                {
                    Logger.Log($"Loading {c.Likes.Count} likes for comment {c.Id} on wallpost {w.Id}");
                    wallStat.CommentLikers.AddRange(
                        VkApi.Likes.GetListEx(new LikesGetListParams
                        {
                            OwnerId = (-1) * Group.Id,
                            Extended = true,
                            ItemId = c.Id,
                            Type = LikeObjectType.Comment
                        }).Users.Select(u => u.Id));

                }
                res.Add(wallStat);
                //Thread.Sleep(3000);
            }
            Logger.Log("Ended loading wallposts");
            return res;
        }



        private List<UserActivityStats> GetUserActivityStats()
        {
            Logger.Log($"Begining user activity analysis");
            var subs = GetAllSubscribers().Select(si => new UserActivityStats(si, true));
            
            var wstats = GetWallPostsStats();
            var nonsubs = wstats.SelectMany(s => s.Commenters)
                        .Union(wstats.SelectMany(s => s.Likers))
                        .Union(wstats.SelectMany(s => s.Reposters))
                        .Union(wstats.SelectMany(s => s.CommentLikers))                        
                        .Select(si => new UserActivityStats(si, false))
                        .Where(ns => !subs.Contains(ns));

            var res = subs.Concat(nonsubs).ToList();

            foreach (var ustat in res)
            {
                var id = ustat.UserId;
                ustat.NComments = wstats.SelectMany(s => s.Commenters).Count(c => c == id);
                ustat.NReposts = wstats.SelectMany(s => s.Reposters).Count(r => r == id);
                ustat.NLikes = wstats.SelectMany(s => s.Likers).Count(l => l == id);
                ustat.NLikes += wstats.SelectMany(s => s.CommentLikers).Count(l => l == id);
            }
            Logger.Log($"Ended user activity analysis");
            return res;
        }

        public List<UserActivityStats> ActiveSubscribers
        {
            get
            {
                return GetUserActivityStats()
                    .Where(s => s.IsSub && s.Total > 0)
                    .OrderByDescending(s => s.Total)
                    .ToList();
            }
        }

        public List<UserActivityStats> NonActiveSubscribers
        {
            get
            {
                return GetUserActivityStats()
                    .Where(s => s.IsSub && s.Total == 0)
                    .OrderByDescending(s => s.Total)
                    .ToList();
            }
        }

        public List<UserActivityStats> ActiveNonSubscribers
        {
            get
            {
                return GetUserActivityStats()
                    .Where(s => !s.IsSub)
                    .OrderByDescending(s => s.Total)
                    .ToList();
            }
        }
                

        private class WallPostStats
        {
            public readonly long Id;
            public List<long> Reposters = new List<long>();
            public List<long> Likers = new List<long>();
            public List<long> Commenters = new List<long>();
            public List<long> CommentLikers = new List<long>();

            public WallPostStats(long id)
            {
                Id = id;
            }
        }

    }

    public class UserActivityStats
    {
        public readonly long UserId;
        public int NReposts;
        public int NLikes;
        public int NComments;
        public bool IsSub;

        public int Total
        {
            get
            {
                return NLikes + NReposts + NComments;
            }
        }

        public UserActivityStats(long id, bool isSub)
        {
            UserId = id;
            IsSub = isSub;
        }

        public override bool Equals(object o)
        {
            var other = o as UserActivityStats;
            if (other != null) return UserId == other.UserId;
            else return base.Equals(o);
        }
    }

    class Program
    {      
        
        static void Main(string[] args)
        {
            Console.WriteLine("BEGIN");
            
            
            var a = new Analyzer();
            
            foreach (var u in a.ActiveSubscribers)
            {
                var name = Logger.FixString(u.UserId.ToString(), 20);
                Console.WriteLine($"{name}\t{u.NLikes}\t{u.NReposts}\t{u.NComments}");                
            }
            
            
            Console.WriteLine("END");
            Console.ReadKey();
        }
        
    }
}
