using System;

namespace Bit_Locker
{
    partial class MainWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.normalLockButton = new System.Windows.Forms.Button();
            this.forceLockButton = new System.Windows.Forms.Button();
            this.driveChooser = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // normalLockButton
            // 
            this.normalLockButton.Location = new System.Drawing.Point(95, 224);
            this.normalLockButton.Margin = new System.Windows.Forms.Padding(2);
            this.normalLockButton.Name = "normalLockButton";
            this.normalLockButton.Size = new System.Drawing.Size(143, 45);
            this.normalLockButton.TabIndex = 0;
            this.normalLockButton.Text = "普通锁定";
            this.normalLockButton.UseVisualStyleBackColor = true;
            this.normalLockButton.Click += new System.EventHandler(this.normalLockButton_Click);
            // 
            // forceLockButton
            // 
            this.forceLockButton.Location = new System.Drawing.Point(361, 224);
            this.forceLockButton.Margin = new System.Windows.Forms.Padding(2);
            this.forceLockButton.Name = "forceLockButton";
            this.forceLockButton.Size = new System.Drawing.Size(143, 45);
            this.forceLockButton.TabIndex = 1;
            this.forceLockButton.Text = "强制锁定";
            this.forceLockButton.UseVisualStyleBackColor = true;
            this.forceLockButton.Click += new System.EventHandler(this.forceLockButton_Click);
            // 
            // driveChooser
            // 
            this.driveChooser.BackColor = System.Drawing.SystemColors.Info;
            this.driveChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driveChooser.FormattingEnabled = true;
            this.driveChooser.ItemHeight = 12;
            this.driveChooser.Location = new System.Drawing.Point(262, 113);
            this.driveChooser.Margin = new System.Windows.Forms.Padding(2);
            this.driveChooser.Name = "driveChooser";
            this.driveChooser.Size = new System.Drawing.Size(76, 20);
            this.driveChooser.TabIndex = 3;
            this.driveChooser.SelectedIndexChanged += new System.EventHandler(this.driveChooser_SelectedIndexChanged);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.driveChooser);
            this.Controls.Add(this.forceLockButton);
            this.Controls.Add(this.normalLockButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWin";
            this.Text = "Bitlocker锁定器";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button normalLockButton;
        private System.Windows.Forms.Button forceLockButton;
        private System.Windows.Forms.ComboBox driveChooser;
    }
}

