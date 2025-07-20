using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bit_Locker
{
    public partial class MainWin : Form
    {
        public string[] driveList = Environment.GetLogicalDrives();
        List<string> bitlockerDrives = new List<string>();
        public string targetDrive;
        public MainWin()
        {
            InitializeComponent();
            Console.Write("DriveList: "+string.Join(" ", driveList));
            foreach (string drive in driveList)
            {
                
                // 检查当前驱动器是否启用了 BitLocker
                if (IsDriveBitlocked(drive))
                {
                    bitlockerDrives.Add(drive);
                }
            }
            this.driveChooser.Items.AddRange(bitlockerDrives.ToArray());
            
            if(bitlockerDrives.Count > 0)
            {
                this.driveChooser.SelectedIndex = 0;
                this.targetDrive = bitlockerDrives[0].Replace("\\", "");
            }
        }

        private void driveChooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.targetDrive = driveList[this.driveChooser.SelectedIndex].Replace("\\", "");
        }

        private void normalLockButton_Click(object sender, EventArgs e)
        {
            // 创建批处理文件内容
            string batContent = $"%windir%\\Sysnative\\manage-bde.exe -lock {targetDrive} \r\n" +
                                                     $"pause\n";

            string tempPath = Path.GetTempPath();
            string batFileName = "lock_drive.bat";
            string batFilePath = Path.Combine(tempPath, batFileName);

            File.WriteAllText(batFilePath, batContent, Encoding.ASCII);

            try
            {
                RunProcess(batFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"启动进程时出错：{ex.Message}");
            }
        }

        private void forceLockButton_Click(object sender, EventArgs e)
        {
            // 创建批处理文件内容
            string batContent = $"%windir%\\Sysnative\\manage-bde.exe -lock {targetDrive} -ForceDismount\r\n" +
                                                     $"pause\n";

            string tempPath = Path.GetTempPath();
            string batFileName = "lock_drive.bat";
            string batFilePath = Path.Combine(tempPath, batFileName);

            File.WriteAllText(batFilePath, batContent, Encoding.ASCII);

            try
            {
                RunProcess(batFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"启动进程时出错：{ex.Message}");
            }
        }

        private void RunProcess(string batFilePath)
        {
            // 检查文件路径是否为空
            if (string.IsNullOrEmpty(batFilePath)) throw new ArgumentException("batFilePath cannot be null or empty.");

            // 获取文件夹路径
            string folderPath = System.IO.Path.GetDirectoryName(batFilePath);

            // 检查文件夹是否存在
            if (!System.IO.Directory.Exists(folderPath)) throw new DirectoryNotFoundException($"The folder '{folderPath}' does not exist.");

            // 检查文件是否存在
            string batFileName = System.IO.Path.Combine(folderPath, "lock_drive.bat");
            if (!System.IO.File.Exists(batFileName)) throw new FileNotFoundException($"The file 'lock_drive.bat' does not exist in the folder '{folderPath}'.");

            // 创建一个ProcessStartInfo对象
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = batFileName,  // 直接设置为批处理文件路径
                UseShellExecute = true,  // 启用Shell执行
                Verb = "runas",          // 请求管理员权限
                WorkingDirectory = folderPath
            };

            try
            {
                // 启动进程
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                // 捕获异常并处理
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // 检查指定驱动器是否启用了 BitLocker
        private bool IsDriveBitlocked(string drive)
        {
            // 构建 WMI 查询
            string query = $"SELECT * FROM Win32_EncryptableVolume WHERE DriveLetter = '{drive.Substring(0, 2)}'";

            try
            {
                ConnectionOptions options = new ConnectionOptions
                {
                    Impersonation = ImpersonationLevel.Impersonate,
                    EnablePrivileges = true,
                    Authentication = AuthenticationLevel.Packet
                };

                ManagementScope scope = new ManagementScope(@"root\cimv2\Security\MicrosoftVolumeEncryption", options);
                scope.Connect();

                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, new ObjectQuery(query)))
                {
                    foreach (ManagementObject volume in searcher.Get())
                    {
                        if ((UInt32?)volume["ProtectionStatus"] == 1) return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"查询驱动器 {drive} 时发生错误：{ex.Message}");
            }

            return false;
        }
    }
}
