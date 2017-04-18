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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.LogOutputTextBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.ShowActiveSubsButton = new System.Windows.Forms.Button();
            this.ShowNonActiveSubsButton = new System.Windows.Forms.Button();
            this.ShowActiveNonSubsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AppIdTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.LogTab = new System.Windows.Forms.TabPage();
            this.UsersTab = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.UsersDataGridView = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GroupNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GetPublicsButton = new System.Windows.Forms.Button();
            this.MainTab.SuspendLayout();
            this.LogTab.SuspendLayout();
            this.UsersTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
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
            this.LogOutputTextBox.Size = new System.Drawing.Size(446, 445);
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
            // ShowActiveSubsButton
            // 
            this.ShowActiveSubsButton.Location = new System.Drawing.Point(12, 354);
            this.ShowActiveSubsButton.Name = "ShowActiveSubsButton";
            this.ShowActiveSubsButton.Size = new System.Drawing.Size(170, 31);
            this.ShowActiveSubsButton.TabIndex = 2;
            this.ShowActiveSubsButton.Text = "Active subscribers";
            this.ShowActiveSubsButton.UseVisualStyleBackColor = true;
            this.ShowActiveSubsButton.Visible = false;
            this.ShowActiveSubsButton.Click += new System.EventHandler(this.ShowActiveSubsButton_Click);
            // 
            // ShowNonActiveSubsButton
            // 
            this.ShowNonActiveSubsButton.Location = new System.Drawing.Point(12, 391);
            this.ShowNonActiveSubsButton.Name = "ShowNonActiveSubsButton";
            this.ShowNonActiveSubsButton.Size = new System.Drawing.Size(170, 31);
            this.ShowNonActiveSubsButton.TabIndex = 3;
            this.ShowNonActiveSubsButton.Text = "Non-active subscribers";
            this.ShowNonActiveSubsButton.UseVisualStyleBackColor = true;
            this.ShowNonActiveSubsButton.Visible = false;
            this.ShowNonActiveSubsButton.Click += new System.EventHandler(this.ShowNonActiveSubsButton_Click);
            // 
            // ShowActiveNonSubsButton
            // 
            this.ShowActiveNonSubsButton.Location = new System.Drawing.Point(12, 428);
            this.ShowActiveNonSubsButton.Name = "ShowActiveNonSubsButton";
            this.ShowActiveNonSubsButton.Size = new System.Drawing.Size(170, 31);
            this.ShowActiveNonSubsButton.TabIndex = 4;
            this.ShowActiveNonSubsButton.Text = "Active non-subscribers";
            this.ShowActiveNonSubsButton.UseVisualStyleBackColor = true;
            this.ShowActiveNonSubsButton.Visible = false;
            this.ShowActiveNonSubsButton.Click += new System.EventHandler(this.ShowActiveNonSubsButton_Click);
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
            this.MainTab.Location = new System.Drawing.Point(188, 12);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(454, 471);
            this.MainTab.TabIndex = 11;
            // 
            // LogTab
            // 
            this.LogTab.Controls.Add(this.LogOutputTextBox);
            this.LogTab.Location = new System.Drawing.Point(4, 22);
            this.LogTab.Name = "LogTab";
            this.LogTab.Padding = new System.Windows.Forms.Padding(3);
            this.LogTab.Size = new System.Drawing.Size(446, 445);
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
            this.UsersTab.Size = new System.Drawing.Size(446, 445);
            this.UsersTab.TabIndex = 1;
            this.UsersTab.Text = "Users";
            this.UsersTab.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chart2);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(446, 445);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Stats";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // UsersDataGridView
            // 
            this.UsersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.UsersDataGridView.Name = "UsersDataGridView";
            this.UsersDataGridView.Size = new System.Drawing.Size(446, 445);
            this.UsersDataGridView.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart2.Legends.Add(legend6);
            this.chart2.Location = new System.Drawing.Point(306, 0);
            this.chart2.Name = "chart2";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(300, 300);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Public";
            // 
            // GetPublicsButton
            // 
            this.GetPublicsButton.Location = new System.Drawing.Point(12, 317);
            this.GetPublicsButton.Name = "GetPublicsButton";
            this.GetPublicsButton.Size = new System.Drawing.Size(170, 31);
            this.GetPublicsButton.TabIndex = 14;
            this.GetPublicsButton.Text = "10 Publics";
            this.GetPublicsButton.UseVisualStyleBackColor = true;
            this.GetPublicsButton.Visible = false;
            this.GetPublicsButton.Click += new System.EventHandler(this.GetPublicsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 495);
            this.Controls.Add(this.GetPublicsButton);
            this.Controls.Add(this.GroupNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MainTab);
            this.Controls.Add(this.AppIdTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowActiveNonSubsButton);
            this.Controls.Add(this.ShowNonActiveSubsButton);
            this.Controls.Add(this.ShowActiveSubsButton);
            this.Controls.Add(this.StartButton);
            this.Name = "MainForm";
            this.Text = "VkStats";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainTab.ResumeLayout(false);
            this.LogTab.ResumeLayout(false);
            this.LogTab.PerformLayout();
            this.UsersTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogOutputTextBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ShowActiveSubsButton;
        private System.Windows.Forms.Button ShowNonActiveSubsButton;
        private System.Windows.Forms.Button ShowActiveNonSubsButton;
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
        private System.Windows.Forms.TextBox GroupNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button GetPublicsButton;
    }
}

