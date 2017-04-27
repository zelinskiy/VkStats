using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace VkStatsForm.Models
{
    public class Post
    {
        public Int64 Id { get; set; }
        [Index(IsUnique = true)]
        public Int64 VkId { get; set; }
        public string Text { get; set; }
        public Int64 NComments { get; set; }
        public Int64 NLikes { get; set; }
    }

}
