using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkStatsForm.Models
{
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
            if (like != null)
            {
                return new Comparer().Equals(this, like);
            }
            return base.Equals(obj);
        }

        public class Comparer : IEqualityComparer<Like>
        {
            public bool Equals(Like x, Like y)
            {
                return x.UserId == y.UserId
                    && x.Type == y.Type
                    && x.ObjectId == y.ObjectId;
            }

            public int GetHashCode(Like l)
            {
                return (int)(l.ObjectId ^ l.UserId * l.Type);
            }
        }
    }

}
