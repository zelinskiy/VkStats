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
using System.Threading.Tasks;

using VkNet;
using VkNet.Enums.Filters;
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

    class Program
    {      
        
        static void Main(string[] args)
        {
            Console.WriteLine("BEGIN");
            

            var storedSecrets = System.IO.File.ReadLines("..\\..\\secrets.txt").ToArray();
            var login = storedSecrets[0];
            var pass = storedSecrets[1];
            var applicationId = ulong.Parse(storedSecrets[2]);

            const int groupId = 44898240;
            const string groupName = "kanonrk";

            var vk = new VkApi();
            vk.Authorize(new ApiAuthParams
            {
                ApplicationId = applicationId,
                Login = login,
                Password = pass,
                Settings = Settings.All
            });

            var group = vk.Groups.GetById(new List<string>(), groupName, GroupsFields.All).First();
            var nGroupMembers = group.MembersCount.Value;
            int offsetStep = 1000;
            var members = new List<VkNet.Model.User>();
            for (int i = 0; i < nGroupMembers; i += offsetStep)
            {
                Console.WriteLine("DOWNLOADING FROM {0} TO {1}", i, i + offsetStep);
                members.AddRange(vk.Groups.GetMembers(new GroupsGetMembersParams
                {
                    GroupId = groupName,
                    Count = offsetStep,
                    Offset = i < nGroupMembers ? i : nGroupMembers % i,
                    Fields = UsersFields.All
                }).Where(m => !m.IsDeactivated));

            }

            Console.WriteLine("DOWNLOADED " + members.Count);

            
            using (var db = new MyContext())
            {
                foreach (var m in members)
                {
                    var person = new User
                    {
                        VkId = m.Id,
                        FirstName = m.FirstName,
                        LastName = m.LastName
                    };                    
                    db.Users.Add(person);

                    var groups = vk.Groups
                        .Get(new GroupsGetParams { UserId = m.Id })
                        .Select(g => new GroupUser
                            {
                                UserId = m.Id,
                                GroupId = g.Id
                            });                    
                    db.GroupUsers.AddRange(groups);
                    db.SaveChanges();
                    Console.WriteLine("DOWNLOADED {0} GROUPS FOR USER {1} ", groups.Count(), m.Id);
                }                
            }

            Console.WriteLine("END");
            Console.ReadKey();
        }
        
    }
}
