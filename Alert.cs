using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bit_Locker
{
    public partial class Alert : Form
    {
        private MainWin MainWin;
        public Alert(MainWin MainWin)
        {
            InitializeComponent();
            this.label1.Text = "当普通锁定无效时才考虑强制锁定。\n" +
                                                "强制锁定会卸载目标分区，请先确保：\n" +
                                                "1.已保存该分区上的文件；\n" +
                                                "2.已关闭正在使用该分区的程序。\n" +
                                                "是否继续？";
            this.MainWin = MainWin;
            ContinueForceButton.Click += ContinueForceButton_Click;
        }

        private void ContinueForceButton_Click(object sender, EventArgs e)
        {
            MainWin.ContinueForceButton_Click(sender, e);
            Close();
        }
    }
}
