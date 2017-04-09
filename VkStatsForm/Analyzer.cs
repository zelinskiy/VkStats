using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;

namespace VkStatsForm
{
    public class Analyzer
    {

        private const string GroupName = "knnrk.media";

        private readonly VkNet.Model.Group Group;

        private readonly VkApi VkApi;

        private readonly Action<string> Log;

        public Analyzer(
            string login, 
            string pass, 
            ulong applicationId, 
            Action<string> log)
        {
            Log = log;


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
            Log("Begin to load subscribers");
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
            Log("Ended loading subscribers");
            return res;
        }


        //TODO:
        //Offsets
        //Group reposts

        private List<WallPostStats> SavedWallPostsStats;
        private List<WallPostStats> GetWallPostsStats(ulong maxcount = 100)
        {
            if (SavedWallPostsStats != null)
            {
                Log("Loaded wallpost from memory");
                return SavedWallPostsStats;
            }
            Log($"Loading {maxcount} top wallposts");
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
                Log($"Loading wallpost {w.Id}");
                var wallStat = new WallPostStats(w.Id.Value);

                var reposts = VkApi.Wall.GetReposts((-1) * Group.Id, w.Id, 0, 1000);
                wallStat.Reposters.AddRange(reposts.Profiles.Select(p => p.Id));

                Log($"Loading comments for wallpost {w.Id}");
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
                    Log($"Loading {c.Likes.Count} likes for comment {c.Id} on wallpost {w.Id}");
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
            Log("Ended loading wallposts");
            SavedWallPostsStats = res;
            return res;
        }



        private List<UserActivityStats> GetUserActivityStats()
        {
            Log($"Begining user activity analysis");
            var subs = GetAllSubscribers().Select(si => new UserActivityStats(si, true));

            var wstats = GetWallPostsStats(10);
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
            Log($"Ended user activity analysis");
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

}
