using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;



namespace VkStats
{
    class Program
    {
        static void Main(string[] args)
        {
            // There must be file secrets.txt with
            // LOGIN
            // PASS
            // APPID
            var storedSecrets = File.ReadLines("..\\..\\secrets.txt").ToArray();
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
            
            var members = vk.Groups.GetMembers(new GroupsGetMembersParams
            {
                GroupId = groupName,
                Count = 50,
                Fields = UsersFields.All
            });
            
            Console.WriteLine("Loaded {0} ids", members.Count);
            foreach(var m in members.Take(5))
            {
                Console.WriteLine("========================");
                Console.WriteLine("User {0} {1} top 20:", m.FirstName, m.LastName);
                Console.WriteLine("========================");
                var groups = vk.Groups.Get(new GroupsGetParams
                {
                    UserId = m.Id,
                    Count = 20,
                    Extended = true,
                    Filter = GroupsFilters.Publics,
                    Fields = GroupsFields.All
                });
                foreach (var g in groups)
                {
                    Console.WriteLine(g.Name);
                }
                
            }

            Console.WriteLine("END OF PROGRAM");
            Console.ReadKey();
        }
    }
}
