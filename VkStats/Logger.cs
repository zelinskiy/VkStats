

using System;
using System.Linq;

namespace VkStats
{
    static class Logger
    {
        static readonly DateTime beginAt = DateTime.Now;
        public static void Log(string message)
        {
            var t = DateTime.Now.ToString("HH:mm:ss");
            var delta = (DateTime.Now - beginAt);
            Console.WriteLine($"[LOG] [{t}] {message}");
        }

        /// <summary>
        /// Extends or crops string to fixed size
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="length">Desirable length</param>
        /// <returns></returns>
        public static string FixString(string input, int length)
        {
            if (input.Length >= length)
            {
                return string.Concat(input.Take(length));
            }
            return input + new string(' ', length - input.Length);
        }
    }
}