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

        private Downloader downloader;

        private CancellationTokenSource cts;

        public MainForm()
        {
            InitializeComponent();
            Log($"Application started...");
            LoginTextBox.Text = SettingsStorage.Login;
            PasswordTextBox.Text = SettingsStorage.Password;
            AppIdTextBox.Text = SettingsStorage.AppId.ToString();
            GroupNameTextBox.Text = SettingsStorage.GroupName;

            cts = new CancellationTokenSource();


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
                downloader = new Downloader(Log);
                Log("Logged in!");
                StartButton.BackColor = Color.LightGreen;
                showButtonsControlTab.Visible = true;
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }

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



        private void downloadPostsLikesButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                downloader.DownloadAllPostLikes(cts.Token);
            });
        }

        private void downloadCommentsLikesButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                downloader.DownloadAllCommentLikes(cts.Token);
            });
        }

        private void DownloadPostsButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                downloader.DownloadAllPosts(cts.Token);
            });
        }

        private void downloadSubscribersButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                downloader.DownloadAllSubscribers(cts.Token);
            });
        }

        private void downloadNonSubscribersButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                downloader.DownloadAllNonSubscribers(cts.Token);
            });
        }


        private void downloadCommentsButton_Click(object sender, EventArgs e)
        {
            var t = Task.Run(() =>
             {
                 downloader.DownloadAllComments(cts.Token);
             });
        }

        private void downloadGroupsButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                downloader.DownloadAllGroups(cts.Token);
            });
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            Log("Cancelled");
            Thread.Sleep(250);
            cts.Dispose();
            cts = new CancellationTokenSource();
        }

        private void showSubscribersButton_Click(object sender, EventArgs e)
        {
            using (var db = new Context())
            {
                rawOutputTextBox.Text = "SUBSCRIBERS: \n";
                foreach (var s in db.Users
                    .Where(u => u.IsSub == 1)
                    .OrderByDescending(u => db.Likes.Count(l => l.UserId == u.VkId))
                    .ToArray()
                    )
                {

                    rawOutputTextBox.AppendText($"\n{s.VkId} {s.FirstName} {s.LastName}\n");
                }
            }
        }

        private void showGroupsButton_Click(object sender, EventArgs e)
        {
            using (var db = new Context())
            {
                rawOutputTextBox.Text = "GROUPS: \n";
                foreach (var g in db.Groups
                    .ToArray()
                    .Select(g => new { g = g, c = db.GroupUsers.Count(gu => gu.GroupId == g.VkId) })
                    .OrderByDescending(o => o.c)
                    )
                {
                    rawOutputTextBox.AppendText($"\n[{g.g.VkId}]\t {g.g.Name} ({g.c})\n");
                }
            }
        }

        private void showCommentsButton_Click(object sender, EventArgs e)
        {
            using (var db = new Context())
            {
                rawOutputTextBox.Text = "COMMENTS :\n";
                foreach (var c in db.Comments
                    .ToArray()
                    .Select(c => new {
                        c = c,
                        l = db.Likes.Count(l => l.Type == 2 && l.ObjectId == c.VkId) })
                    .OrderByDescending(o => o.l)
                    )
                {
                    rawOutputTextBox.AppendText($"\n[{c.c.VkId}]\t ({c.l} likes)" +
                        $" Comment for {c.c.PostId} :\n{c.c.Text} \n");
                }
            }

        }

        private void showNonSubscribersButton_Click(object sender, EventArgs e)
        {
            using (var db = new Context())
            {
                rawOutputTextBox.Text = "NON-SUBSCRIBERS :\n";
                foreach (var s in db.Users
                    .Where(u => u.IsSub == 0)
                    .OrderByDescending(u => db.Likes.Count(l => l.UserId == u.VkId))
                    .ToArray()
                    )
                {

                    rawOutputTextBox.AppendText($"\n{s.VkId} {s.FirstName} {s.LastName}\n");
                }
            }
        }
    }
}
