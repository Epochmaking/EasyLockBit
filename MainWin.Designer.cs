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
            this.toDelVolLabel = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.refleshButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.IsEnableHotKeys = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // normalLockButton
            // 
            this.normalLockButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.normalLockButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.normalLockButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.normalLockButton.Location = new System.Drawing.Point(35, 144);
            this.normalLockButton.Margin = new System.Windows.Forms.Padding(2);
            this.normalLockButton.Name = "normalLockButton";
            this.normalLockButton.Size = new System.Drawing.Size(113, 45);
            this.normalLockButton.TabIndex = 0;
            this.normalLockButton.Text = "普通锁定";
            this.normalLockButton.UseVisualStyleBackColor = true;
            this.normalLockButton.Click += new System.EventHandler(this.normalLockButton_Click);
            // 
            // forceLockButton
            // 
            this.forceLockButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forceLockButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.forceLockButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.forceLockButton.Location = new System.Drawing.Point(187, 144);
            this.forceLockButton.Margin = new System.Windows.Forms.Padding(2);
            this.forceLockButton.Name = "forceLockButton";
            this.forceLockButton.Size = new System.Drawing.Size(113, 45);
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
            this.driveChooser.Location = new System.Drawing.Point(120, 66);
            this.driveChooser.Margin = new System.Windows.Forms.Padding(2);
            this.driveChooser.Name = "driveChooser";
            this.driveChooser.Size = new System.Drawing.Size(87, 20);
            this.driveChooser.TabIndex = 3;
            this.driveChooser.SelectedIndexChanged += new System.EventHandler(this.driveChooser_SelectedIndexChanged);
            // 
            // toDelVolLabel
            // 
            this.toDelVolLabel.AutoSize = true;
            this.toDelVolLabel.BackColor = System.Drawing.Color.Transparent;
            this.toDelVolLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toDelVolLabel.Location = new System.Drawing.Point(44, 121);
            this.toDelVolLabel.Name = "toDelVolLabel";
            this.toDelVolLabel.Size = new System.Drawing.Size(99, 21);
            this.toDelVolLabel.TabIndex = 4;
            this.toDelVolLabel.Text = "同时删除盘符";
            this.toDelVolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toDelVolLabel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(138, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "(慎选，可在磁盘管理中恢复)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(49, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "选择分区：";
            // 
            // refleshButton
            // 
            this.refleshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refleshButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.refleshButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.refleshButton.Location = new System.Drawing.Point(222, 60);
            this.refleshButton.Margin = new System.Windows.Forms.Padding(2);
            this.refleshButton.Name = "refleshButton";
            this.refleshButton.Size = new System.Drawing.Size(78, 30);
            this.refleshButton.TabIndex = 7;
            this.refleshButton.Text = "刷新";
            this.refleshButton.UseVisualStyleBackColor = true;
            this.refleshButton.Click += new System.EventHandler(this.RefleshButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Bit_Locker.Properties.Resources.LOGO;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(133, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // IsEnableHotKeys
            // 
            this.IsEnableHotKeys.AutoSize = true;
            this.IsEnableHotKeys.BackColor = System.Drawing.Color.Transparent;
            this.IsEnableHotKeys.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsEnableHotKeys.Location = new System.Drawing.Point(44, 99);
            this.IsEnableHotKeys.Name = "IsEnableHotKeys";
            this.IsEnableHotKeys.Size = new System.Drawing.Size(193, 21);
            this.IsEnableHotKeys.TabIndex = 9;
            this.IsEnableHotKeys.Text = "启用强制锁定快捷键 (CTRL+B)";
            this.IsEnableHotKeys.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.IsEnableHotKeys.UseVisualStyleBackColor = false;
            this.IsEnableHotKeys.CheckedChanged += new System.EventHandler(this.IsEnableHotKeys_CheckedChanged);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(333, 198);
            this.Controls.Add(this.IsEnableHotKeys);
            this.Controls.Add(this.refleshButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toDelVolLabel);
            this.Controls.Add(this.driveChooser);
            this.Controls.Add(this.forceLockButton);
            this.Controls.Add(this.normalLockButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BitLocker快捷锁定工具";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
            this.Load += new System.EventHandler(this.MainWin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button normalLockButton;
        private System.Windows.Forms.Button forceLockButton;
        private System.Windows.Forms.ComboBox driveChooser;
        private System.Windows.Forms.CheckBox toDelVolLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button refleshButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox IsEnableHotKeys;
    }
}

