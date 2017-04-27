using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkStatsForm.Models
{
    public class GroupUser
    {
        [Key]
        public Int64 GroupId { get; set; }

        [Key]
        public Int64 UserId { get; set; }
    }

}
