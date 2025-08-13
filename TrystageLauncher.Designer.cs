using System;
using System.Windows.Forms;

namespace trystageClient
{
    partial class TrystageLauncher
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.quitButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.browseJava8 = new System.Windows.Forms.Button();
            this.txtJavaLocation = new System.Windows.Forms.TextBox();
            this.java8PathLabel = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.usrNameLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.quitButton);
            this.panel1.Controls.Add(this.startButton);
            this.panel1.Controls.Add(this.browseJava8);
            this.panel1.Controls.Add(this.txtJavaLocation);
            this.panel1.Controls.Add(this.java8PathLabel);
            this.panel1.Controls.Add(this.txtPlayerName);
            this.panel1.Controls.Add(this.usrNameLabel);
            this.panel1.Controls.Add(this.TitleLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 426);
            this.panel1.TabIndex = 0;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(198, 390);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 7;
            this.quitButton.Text = "退出";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.ExitProgram);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(13, 390);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "启动";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.OnStartButtonClick);
            // 
            // browseJava8
            // 
            this.browseJava8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.browseJava8.Location = new System.Drawing.Point(222, 149);
            this.browseJava8.Name = "browseJava8";
            this.browseJava8.Size = new System.Drawing.Size(51, 21);
            this.browseJava8.TabIndex = 5;
            this.browseJava8.Text = "浏览";
            this.browseJava8.UseVisualStyleBackColor = true;
            this.browseJava8.Click += new System.EventHandler(this.BrowseJava8);
            // 
            // txtJavaLocation
            // 
            this.txtJavaLocation.Location = new System.Drawing.Point(13, 149);
            this.txtJavaLocation.Name = "txtJavaLocation";
            this.txtJavaLocation.Size = new System.Drawing.Size(203, 21);
            this.txtJavaLocation.TabIndex = 4;
            // 
            // java8PathLabel
            // 
            this.java8PathLabel.AutoSize = true;
            this.java8PathLabel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.java8PathLabel.Location = new System.Drawing.Point(9, 126);
            this.java8PathLabel.Name = "java8PathLabel";
            this.java8PathLabel.Size = new System.Drawing.Size(78, 20);
            this.java8PathLabel.TabIndex = 3;
            this.java8PathLabel.Text = "Java 8路径";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(13, 87);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(260, 21);
            this.txtPlayerName.TabIndex = 2;
            // 
            // usrNameLabel
            // 
            this.usrNameLabel.AutoSize = true;
            this.usrNameLabel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.usrNameLabel.Location = new System.Drawing.Point(9, 64);
            this.usrNameLabel.Name = "usrNameLabel";
            this.usrNameLabel.Size = new System.Drawing.Size(51, 20);
            this.usrNameLabel.TabIndex = 1;
            this.usrNameLabel.Text = "用户名";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TitleLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleLabel.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.TitleLabel.Location = new System.Drawing.Point(8, 8);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(187, 26);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Trystage Launcher";
            // 
            // TrystageLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = global::trystageClient.Properties.Resources.vivid_blurred_colorful_background;
            this.ClientSize = new System.Drawing.Size(739, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TrystageLauncher";
            this.Text = "Trystage Launcher";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button browseJava8;
        private System.Windows.Forms.TextBox txtJavaLocation;
        private System.Windows.Forms.Label java8PathLabel;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label usrNameLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button quitButton;
    }
}

