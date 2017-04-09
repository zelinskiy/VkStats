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
            this.SuspendLayout();
            // 
            // LogOutputTextBox
            // 
            this.LogOutputTextBox.Location = new System.Drawing.Point(188, 12);
            this.LogOutputTextBox.Multiline = true;
            this.LogOutputTextBox.Name = "LogOutputTextBox";
            this.LogOutputTextBox.ReadOnly = true;
            this.LogOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogOutputTextBox.Size = new System.Drawing.Size(444, 447);
            this.LogOutputTextBox.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.StartButton.Location = new System.Drawing.Point(12, 139);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 471);
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
            this.Controls.Add(this.LogOutputTextBox);
            this.Name = "MainForm";
            this.Text = "VkStats";
            this.Load += new System.EventHandler(this.MainForm_Load);
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
    }
}

