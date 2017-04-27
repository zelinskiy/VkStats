using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace VkStatsForm.Models
{
    public class User
    {
        public Int64 Id { get; set; }
        [Index(IsUnique = true)]
        public Int64 VkId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        // 0 - no
        // 1- yes
        public Int64 IsSub { get; set; }
    }

}
