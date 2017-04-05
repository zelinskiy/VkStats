using Newtonsoft.Json;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;
using VkStats.Models;

namespace VkStats
{
    public class Person
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
    }

    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MyContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
        public DbSet<Person> Persons { get; set; }
    }

    class Program
    {      
        
        static void Main(string[] args)
        {
            Console.WriteLine("BEGIN");
            using (var db = new MyContext())
            {
                var person = new Person() { Name = "Martha" };
                db.Persons.Add(person);
                db.SaveChanges();
                foreach(var p in db.Persons.ToArray())
                {
                    Console.WriteLine(p.Name);
                }
            }
            
            Console.WriteLine("END");
            Console.ReadKey();
        }
        
    }
}
