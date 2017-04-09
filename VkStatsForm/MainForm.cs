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
                    Log);
                Log("Logged in!");
                StartButton.BackColor = Color.LightGreen;
                ShowActiveSubsButton.Visible = true;
                ShowNonActiveSubsButton.Visible = true;
                ShowActiveNonSubsButton.Visible = true;
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
    }
}
