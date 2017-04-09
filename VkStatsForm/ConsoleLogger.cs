using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkStatsForm
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            var t = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine($"[LOG] [{t}] {message}");
        }        
       
    }
}
