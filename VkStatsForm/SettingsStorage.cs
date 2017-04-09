using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkStatsForm
{
    public static class SettingsStorage
    {
        private const string settingsPath = "secrets.txt";

        public static string Password = "";
        public static string Login = "";
        public static ulong AppId = 0;

        static SettingsStorage()
        {
            AppDomain.CurrentDomain.ProcessExit += SaveSettings;
            if (!File.Exists(settingsPath)) return;
            var storedSecrets = File.ReadLines(settingsPath).ToArray();
            Login = storedSecrets[0];
            Password = storedSecrets[1];
            AppId = ulong.Parse(storedSecrets[2]);
        }

        static void SaveSettings(object sender, EventArgs e)
        {
            File.WriteAllLines(
                settingsPath, 
                new string[] {
                    Login,
                    Password,
                    AppId.ToString()
                });

        }
    }
}
