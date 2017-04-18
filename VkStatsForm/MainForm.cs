using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VkStatsForm
{
    public partial class MainForm : Form
    {

        private Analyzer analyzer;

        public MainForm()
        {
            InitializeComponent();
            Log($"Application started...");
            LoginTextBox.Text = SettingsStorage.Login;
            PasswordTextBox.Text = SettingsStorage.Password;
            AppIdTextBox.Text = SettingsStorage.AppId.ToString();
            GroupNameTextBox.Text = SettingsStorage.GroupName;


        }
        

        void Log(string msg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new object[] { msg });
                return;
            }
            var t = DateTime.Now.ToString("HH:mm:ss");
            LogOutputTextBox.AppendText($"\n[LOG] [{t}] {msg}\n");
        }

        void LogError(string msg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(LogError), new object[] { msg });
                return;
            }
            var t = DateTime.Now.ToString("HH:mm:ss");
            LogOutputTextBox.AppendText("\n-------------------------------------\n");
            LogOutputTextBox.AppendText($"\n[ERROR] [{t}] {msg}\n");
            LogOutputTextBox.AppendText("\n-------------------------------------\n");
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Log("Logging...");
            try
            {
                analyzer = new Analyzer(
                    SettingsStorage.Login,
                    SettingsStorage.Password,
                    SettingsStorage.AppId,
                    SettingsStorage.GroupName,
                    Log);
                Log("Logged in!");
                StartButton.BackColor = Color.LightGreen;
                ShowActiveSubsButton.Visible = true;
                ShowNonActiveSubsButton.Visible = true;
                ShowActiveNonSubsButton.Visible = true;
                GetPublicsButton.Visible = true;
            }
            catch(Exception ex)
            {
                LogError(ex.Message);
            }
            
        }

        private void ShowActiveSubsButton_Click(object sender, EventArgs e)
        {
            Task.Run(() => 
            {
                Log($"ActiveSubscribers:");
                foreach (var s in analyzer.ActiveSubscribers)
                {
                    Log($"User #{s.UserId} (L:{s.NLikes}, R:{s.NReposts}, C:{s.NComments})");
                }
                Log($"---------------");
                Log($"Top 10 publics:");
                Log($"---------------");

                
            });          
            
        }

        private void LoginTextBox_TextChanged(object sender, EventArgs e)
        {
            SettingsStorage.Login = LoginTextBox.Text;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            SettingsStorage.Password = PasswordTextBox.Text;
        }

        private void GroupNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SettingsStorage.GroupName = GroupNameTextBox.Text;
        }

        private void AppIdTextBox_TextChanged(object sender, EventArgs e)
        {
            var res = ulong.TryParse(AppIdTextBox.Text, out SettingsStorage.AppId);
            if (!res)
            {
                LogError($"Cannot parse AppId {AppIdTextBox.Text}");
            }
           
        }

        private void ShowNonActiveSubsButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Log($"NonActiveSubscribers:");
                foreach (var s in analyzer.NonActiveSubscribers)
                {
                    Log($"User #{s.UserId} (L:{s.NLikes}, R:{s.NReposts}, C:{s.NComments})");
                }
            });
        }

        private void ShowActiveNonSubsButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Log($"ActiveNonSubscribers:");
                foreach (var s in analyzer.ActiveNonSubscribers)
                {
                    Log($"User #{s.UserId} (L:{s.NLikes}, R:{s.NReposts}, C:{s.NComments})");
                }
            });
        }

        private void GetPublicsButton_Click(object sender, EventArgs e)
        {
            Log("Top publics:");
            var pubs = analyzer.GetPublics(25, 1000);

            foreach(var p in pubs.GroupBy(p => p.Id).OrderBy(g => g.Count()))
            {
                Log(p.First().Id + " occurs " + p.Count() + " times");
            }
        }
    }
}
