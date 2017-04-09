using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkStatsForm
{
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
}
