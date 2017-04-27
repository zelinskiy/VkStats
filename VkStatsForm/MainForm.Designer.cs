namespace VkStatsForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.LogOutputTextBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AppIdTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.LogTab = new System.Windows.Forms.TabPage();
            this.UsersTab = new System.Windows.Forms.TabPage();
            this.UsersDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rawOutputTab = new System.Windows.Forms.TabPage();
            this.rawOutputTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GroupNameTextBox = new System.Windows.Forms.TextBox();
            this.showButtonsControlTab = new System.Windows.Forms.TabControl();
            this.DownloadButtonsTab = new System.Windows.Forms.TabPage();
            this.downloadCommentsButton = new System.Windows.Forms.Button();
            this.downloadCommentsLikesButton = new System.Windows.Forms.Button();
            this.downloadPostsLikesButton = new System.Windows.Forms.Button();
            this.downloadNonSubscribersButton = new System.Windows.Forms.Button();
            this.downloadSubscribersButton = new System.Windows.Forms.Button();
            this.DownloadPostsButton = new System.Windows.Forms.Button();
            this.AnalyzeButtonsTab = new System.Windows.Forms.TabPage();
            this.cancelButton = new System.Windows.Forms.Button();
            this.showButtonsTab = new System.Windows.Forms.TabPage();
            this.showSubscribersButton = new System.Windows.Forms.Button();
            this.showGroupsButton = new System.Windows.Forms.Button();
            this.showCommentsButton = new System.Windows.Forms.Button();
            this.downloadGroupsButton = new System.Windows.Forms.Button();
            this.showNonSubscribersButton = new System.Windows.Forms.Button();
            this.MainTab.SuspendLayout();
            this.LogTab.SuspendLayout();
            this.UsersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.rawOutputTab.SuspendLayout();
            this.showButtonsControlTab.SuspendLayout();
            this.DownloadButtonsTab.SuspendLayout();
            this.showButtonsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogOutputTextBox
            // 
            this.LogOutputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogOutputTextBox.Location = new System.Drawing.Point(0, 0);
            this.LogOutputTextBox.Multiline = true;
            this.LogOutputTextBox.Name = "LogOutputTextBox";
            this.LogOutputTextBox.ReadOnly = true;
            this.LogOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogOutputTextBox.Size = new System.Drawing.Size(468, 428);
            this.LogOutputTextBox.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.StartButton.Location = new System.Drawing.Point(12, 181);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(170, 34);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Login";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Login";
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(12, 29);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(170, 20);
            this.LoginTextBox.TabIndex = 6;
            this.LoginTextBox.TextChanged += new System.EventHandler(this.LoginTextBox_TextChanged);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(12, 72);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(170, 20);
            this.PasswordTextBox.TabIndex = 8;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // AppIdTextBox
            // 
            this.AppIdTextBox.Location = new System.Drawing.Point(12, 113);
            this.AppIdTextBox.Name = "AppIdTextBox";
            this.AppIdTextBox.Size = new System.Drawing.Size(170, 20);
            this.AppIdTextBox.TabIndex = 10;
            this.AppIdTextBox.Text = "5292483";
            this.AppIdTextBox.TextChanged += new System.EventHandler(this.AppIdTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "ApplicationId";
            // 
            // MainTab
            // 
            this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTab.Controls.Add(this.LogTab);
            this.MainTab.Controls.Add(this.UsersTab);
            this.MainTab.Controls.Add(this.tabPage1);
            this.MainTab.Controls.Add(this.rawOutputTab);
            this.MainTab.Location = new System.Drawing.Point(188, 29);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(463, 454);
            this.MainTab.TabIndex = 11;
            // 
            // LogTab
            // 
            this.LogTab.Controls.Add(this.LogOutputTextBox);
            this.LogTab.Location = new System.Drawing.Point(4, 22);
            this.LogTab.Name = "LogTab";
            this.LogTab.Padding = new System.Windows.Forms.Padding(3);
            this.LogTab.Size = new System.Drawing.Size(455, 428);
            this.LogTab.TabIndex = 0;
            this.LogTab.Text = "Log";
            this.LogTab.UseVisualStyleBackColor = true;
            // 
            // UsersTab
            // 
            this.UsersTab.Controls.Add(this.UsersDataGridView);
            this.UsersTab.Location = new System.Drawing.Point(4, 22);
            this.UsersTab.Name = "UsersTab";
            this.UsersTab.Padding = new System.Windows.Forms.Padding(3);
            this.UsersTab.Size = new System.Drawing.Size(455, 428);
            this.UsersTab.TabIndex = 1;
            this.UsersTab.Text = "Users";
            this.UsersTab.UseVisualStyleBackColor = true;
            // 
            // UsersDataGridView
            // 
            this.UsersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.UsersDataGridView.Name = "UsersDataGridView";
            this.UsersDataGridView.Size = new System.Drawing.Size(455, 428);
            this.UsersDataGridView.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chart2);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(455, 428);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Stats";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(306, 0);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(300, 300);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // rawOutputTab
            // 
            this.rawOutputTab.Controls.Add(this.rawOutputTextBox);
            this.rawOutputTab.Location = new System.Drawing.Point(4, 22);
            this.rawOutputTab.Name = "rawOutputTab";
            this.rawOutputTab.Padding = new System.Windows.Forms.Padding(3);
            this.rawOutputTab.Size = new System.Drawing.Size(455, 428);
            this.rawOutputTab.TabIndex = 3;
            this.rawOutputTab.Text = "Raw Output";
            this.rawOutputTab.UseVisualStyleBackColor = true;
            // 
            // rawOutputTextBox
            // 
            this.rawOutputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawOutputTextBox.Location = new System.Drawing.Point(0, 0);
            this.rawOutputTextBox.Multiline = true;
            this.rawOutputTextBox.Name = "rawOutputTextBox";
            this.rawOutputTextBox.ReadOnly = true;
            this.rawOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rawOutputTextBox.Size = new System.Drawing.Size(455, 428);
            this.rawOutputTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Public";
            // 
            // GroupNameTextBox
            // 
            this.GroupNameTextBox.Location = new System.Drawing.Point(12, 155);
            this.GroupNameTextBox.Name = "GroupNameTextBox";
            this.GroupNameTextBox.Size = new System.Drawing.Size(170, 20);
            this.GroupNameTextBox.TabIndex = 13;
            this.GroupNameTextBox.Text = "knnrk.media";
            this.GroupNameTextBox.TextChanged += new System.EventHandler(this.GroupNameTextBox_TextChanged);
            // 
            // showButtonsControlTab
            // 
            this.showButtonsControlTab.Controls.Add(this.DownloadButtonsTab);
            this.showButtonsControlTab.Controls.Add(this.AnalyzeButtonsTab);
            this.showButtonsControlTab.Controls.Add(this.showButtonsTab);
            this.showButtonsControlTab.Location = new System.Drawing.Point(15, 236);
            this.showButtonsControlTab.Name = "showButtonsControlTab";
            this.showButtonsControlTab.SelectedIndex = 0;
            this.showButtonsControlTab.Size = new System.Drawing.Size(167, 243);
            this.showButtonsControlTab.TabIndex = 1;
            this.showButtonsControlTab.Visible = false;
            // 
            // DownloadButtonsTab
            // 
            this.DownloadButtonsTab.Controls.Add(this.downloadGroupsButton);
            this.DownloadButtonsTab.Controls.Add(this.downloadCommentsButton);
            this.DownloadButtonsTab.Controls.Add(this.downloadCommentsLikesButton);
            this.DownloadButtonsTab.Controls.Add(this.downloadPostsLikesButton);
            this.DownloadButtonsTab.Controls.Add(this.downloadNonSubscribersButton);
            this.DownloadButtonsTab.Controls.Add(this.downloadSubscribersButton);
            this.DownloadButtonsTab.Controls.Add(this.DownloadPostsButton);
            this.DownloadButtonsTab.Location = new System.Drawing.Point(4, 22);
            this.DownloadButtonsTab.Name = "DownloadButtonsTab";
            this.DownloadButtonsTab.Padding = new System.Windows.Forms.Padding(3);
            this.DownloadButtonsTab.Size = new System.Drawing.Size(159, 217);
            this.DownloadButtonsTab.TabIndex = 0;
            this.DownloadButtonsTab.Text = "Download";
            this.DownloadButtonsTab.UseVisualStyleBackColor = true;
            // 
            // downloadCommentsButton
            // 
            this.downloadCommentsButton.Location = new System.Drawing.Point(3, 93);
            this.downloadCommentsButton.Name = "downloadCommentsButton";
            this.downloadCommentsButton.Size = new System.Drawing.Size(150, 23);
            this.downloadCommentsButton.TabIndex = 7;
            this.downloadCommentsButton.Text = "Comments";
            this.downloadCommentsButton.UseVisualStyleBackColor = true;
            this.downloadCommentsButton.Click += new System.EventHandler(this.downloadCommentsButton_Click);
            // 
            // downloadCommentsLikesButton
            // 
            this.downloadCommentsLikesButton.Location = new System.Drawing.Point(3, 151);
            this.downloadCommentsLikesButton.Name = "downloadCommentsLikesButton";
            this.downloadCommentsLikesButton.Size = new System.Drawing.Size(150, 23);
            this.downloadCommentsLikesButton.TabIndex = 6;
            this.downloadCommentsLikesButton.Text = "Comments Likes";
            this.downloadCommentsLikesButton.UseVisualStyleBackColor = true;
            this.downloadCommentsLikesButton.Click += new System.EventHandler(this.downloadCommentsLikesButton_Click);
            // 
            // downloadPostsLikesButton
            // 
            this.downloadPostsLikesButton.Location = new System.Drawing.Point(3, 122);
            this.downloadPostsLikesButton.Name = "downloadPostsLikesButton";
            this.downloadPostsLikesButton.Size = new System.Drawing.Size(150, 23);
            this.downloadPostsLikesButton.TabIndex = 5;
            this.downloadPostsLikesButton.Text = "Posts Likes";
            this.downloadPostsLikesButton.UseVisualStyleBackColor = true;
            this.downloadPostsLikesButton.Click += new System.EventHandler(this.downloadPostsLikesButton_Click);
            // 
            // downloadNonSubscribersButton
            // 
            this.downloadNonSubscribersButton.Location = new System.Drawing.Point(3, 64);
            this.downloadNonSubscribersButton.Name = "downloadNonSubscribersButton";
            this.downloadNonSubscribersButton.Size = new System.Drawing.Size(150, 23);
            this.downloadNonSubscribersButton.TabIndex = 3;
            this.downloadNonSubscribersButton.Text = "Non-Subscribers";
            this.downloadNonSubscribersButton.UseVisualStyleBackColor = true;
            this.downloadNonSubscribersButton.Click += new System.EventHandler(this.downloadNonSubscribersButton_Click);
            // 
            // downloadSubscribersButton
            // 
            this.downloadSubscribersButton.Location = new System.Drawing.Point(3, 35);
            this.downloadSubscribersButton.Name = "downloadSubscribersButton";
            this.downloadSubscribersButton.Size = new System.Drawing.Size(150, 23);
            this.downloadSubscribersButton.TabIndex = 2;
            this.downloadSubscribersButton.Text = "Subscribers";
            this.downloadSubscribersButton.UseVisualStyleBackColor = true;
            this.downloadSubscribersButton.Click += new System.EventHandler(this.downloadSubscribersButton_Click);
            // 
            // DownloadPostsButton
            // 
            this.DownloadPostsButton.Location = new System.Drawing.Point(3, 6);
            this.DownloadPostsButton.Name = "DownloadPostsButton";
            this.DownloadPostsButton.Size = new System.Drawing.Size(150, 23);
            this.DownloadPostsButton.TabIndex = 1;
            this.DownloadPostsButton.Text = "Posts";
            this.DownloadPostsButton.UseVisualStyleBackColor = true;
            this.DownloadPostsButton.Click += new System.EventHandler(this.DownloadPostsButton_Click);
            // 
            // AnalyzeButtonsTab
            // 
            this.AnalyzeButtonsTab.AutoScroll = true;
            this.AnalyzeButtonsTab.Location = new System.Drawing.Point(4, 22);
            this.AnalyzeButtonsTab.Name = "AnalyzeButtonsTab";
            this.AnalyzeButtonsTab.Padding = new System.Windows.Forms.Padding(3);
            this.AnalyzeButtonsTab.Size = new System.Drawing.Size(159, 217);
            this.AnalyzeButtonsTab.TabIndex = 1;
            this.AnalyzeButtonsTab.Text = "Analyze";
            this.AnalyzeButtonsTab.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cancelButton.Location = new System.Drawing.Point(613, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(38, 37);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "C";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // showButtonsTab
            // 
            this.showButtonsTab.Controls.Add(this.showNonSubscribersButton);
            this.showButtonsTab.Controls.Add(this.showCommentsButton);
            this.showButtonsTab.Controls.Add(this.showGroupsButton);
            this.showButtonsTab.Controls.Add(this.showSubscribersButton);
            this.showButtonsTab.Location = new System.Drawing.Point(4, 22);
            this.showButtonsTab.Name = "showButtonsTab";
            this.showButtonsTab.Padding = new System.Windows.Forms.Padding(3);
            this.showButtonsTab.Size = new System.Drawing.Size(159, 217);
            this.showButtonsTab.TabIndex = 2;
            this.showButtonsTab.Text = "Show";
            this.showButtonsTab.UseVisualStyleBackColor = true;
            // 
            // showSubscribersButton
            // 
            this.showSubscribersButton.Location = new System.Drawing.Point(7, 7);
            this.showSubscribersButton.Name = "showSubscribersButton";
            this.showSubscribersButton.Size = new System.Drawing.Size(146, 23);
            this.showSubscribersButton.TabIndex = 0;
            this.showSubscribersButton.Text = "Subscribers";
            this.showSubscribersButton.UseVisualStyleBackColor = true;
            this.showSubscribersButton.Click += new System.EventHandler(this.showSubscribersButton_Click);
            // 
            // showGroupsButton
            // 
            this.showGroupsButton.Location = new System.Drawing.Point(7, 65);
            this.showGroupsButton.Name = "showGroupsButton";
            this.showGroupsButton.Size = new System.Drawing.Size(146, 23);
            this.showGroupsButton.TabIndex = 1;
            this.showGroupsButton.Text = "Groups";
            this.showGroupsButton.UseVisualStyleBackColor = true;
            this.showGroupsButton.Click += new System.EventHandler(this.showGroupsButton_Click);
            // 
            // showCommentsButton
            // 
            this.showCommentsButton.Location = new System.Drawing.Point(7, 94);
            this.showCommentsButton.Name = "showCommentsButton";
            this.showCommentsButton.Size = new System.Drawing.Size(146, 23);
            this.showCommentsButton.TabIndex = 2;
            this.showCommentsButton.Text = "Comments";
            this.showCommentsButton.UseVisualStyleBackColor = true;
            this.showCommentsButton.Click += new System.EventHandler(this.showCommentsButton_Click);
            // 
            // downloadGroupsButton
            // 
            this.downloadGroupsButton.Location = new System.Drawing.Point(3, 180);
            this.downloadGroupsButton.Name = "downloadGroupsButton";
            this.downloadGroupsButton.Size = new System.Drawing.Size(150, 23);
            this.downloadGroupsButton.TabIndex = 8;
            this.downloadGroupsButton.Text = "Groups";
            this.downloadGroupsButton.UseVisualStyleBackColor = true;
            this.downloadGroupsButton.Click += new System.EventHandler(this.downloadGroupsButton_Click);
            // 
            // showNonSubscribersButton
            // 
            this.showNonSubscribersButton.Location = new System.Drawing.Point(7, 36);
            this.showNonSubscribersButton.Name = "showNonSubscribersButton";
            this.showNonSubscribersButton.Size = new System.Drawing.Size(146, 23);
            this.showNonSubscribersButton.TabIndex = 3;
            this.showNonSubscribersButton.Text = "Non-Subscribers";
            this.showNonSubscribersButton.UseVisualStyleBackColor = true;
            this.showNonSubscribersButton.Click += new System.EventHandler(this.showNonSubscribersButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 495);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.showButtonsControlTab);
            this.Controls.Add(this.GroupNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MainTab);
            this.Controls.Add(this.AppIdTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartButton);
            this.Name = "MainForm";
            this.Text = "VkStats";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainTab.ResumeLayout(false);
            this.LogTab.ResumeLayout(false);
            this.LogTab.PerformLayout();
            this.UsersTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.rawOutputTab.ResumeLayout(false);
            this.rawOutputTab.PerformLayout();
            this.showButtonsControlTab.ResumeLayout(false);
            this.DownloadButtonsTab.ResumeLayout(false);
            this.showButtonsTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogOutputTextBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AppIdTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage LogTab;
        private System.Windows.Forms.TabPage UsersTab;
        private System.Windows.Forms.DataGridView UsersDataGridView;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox GroupNameTextBox;
        private System.Windows.Forms.TabControl showButtonsControlTab;
        private System.Windows.Forms.TabPage DownloadButtonsTab;
        private System.Windows.Forms.Button downloadNonSubscribersButton;
        private System.Windows.Forms.Button downloadSubscribersButton;
        private System.Windows.Forms.Button DownloadPostsButton;
        private System.Windows.Forms.TabPage AnalyzeButtonsTab;
        private System.Windows.Forms.Button downloadCommentsLikesButton;
        private System.Windows.Forms.Button downloadPostsLikesButton;
        private System.Windows.Forms.Button downloadCommentsButton;
        private System.Windows.Forms.TabPage rawOutputTab;
        private System.Windows.Forms.TextBox rawOutputTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TabPage showButtonsTab;
        private System.Windows.Forms.Button showCommentsButton;
        private System.Windows.Forms.Button showGroupsButton;
        private System.Windows.Forms.Button showSubscribersButton;
        private System.Windows.Forms.Button downloadGroupsButton;
        private System.Windows.Forms.Button showNonSubscribersButton;
    }
}

