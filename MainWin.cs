using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace Bit_Locker
{
    public partial class MainWin : Form
    {
        public string[] driveList;
        List<string> bitlockerDrives = new List<string>();
        public string targetDrive;

        //复选框注册表，用于保持上次程序关闭前的复选框状态
        private const string RegistryKeyPath = @"SOFTWARE\EasyLockBit";
        private const string RegistryValueName = "ToDelVolCheckBoxState";

        public MainWin()
        {
            InitializeComponent();
            CheckForAdminRights();
            RefleshDrivers();
        }

        //检测是否以管理员身份运行
        private void CheckForAdminRights()
        {
            // 获取当前进程的Windows身份
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            // 创建一个WindowsPrincipal对象
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            // 检查当前用户是否属于管理员组
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                // 如果不是管理员，弹出消息框并退出程序
                MessageBox.Show("此程序需要以管理员身份运行。", "权限不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            // 在程序启动时读取CheckBox状态
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                if (key != null)
                {
                    object value = key.GetValue(RegistryValueName);
                    if (value != null) toDelVolLabel.Checked = Convert.ToBoolean(value);
                }
            }
        }

        private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 在程序关闭时保存CheckBox状态
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
            {
                key.SetValue(RegistryValueName, toDelVolLabel.Checked);
            }
        }

        private void RefleshDrivers()
        {
            targetDrive = string.Empty;
            driveList = Environment.GetLogicalDrives();
            Console.Write("DriveList: " + string.Join(" ", driveList));
            bitlockerDrives.Clear();
            bitlockerDrives.AddRange(from string drive in driveList// 检查当前驱动器是否启用了 BitLocker
                                     where IsDriveBitlocked(drive)
                                     select drive);
            driveChooser.Items.Clear();
            driveChooser.Items.AddRange(bitlockerDrives.ToArray());
            if (bitlockerDrives.Count > 0)
            {
                driveChooser.SelectedIndex = 0;
                targetDrive = bitlockerDrives[0].Replace("\\", "");
            }
        }

        private void driveChooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetDrive = driveList[driveChooser.SelectedIndex].Replace("\\", "");
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteVolumeMountPoint(string lpszVolumeMountPoint);

        private void normalLockButton_Click(object sender, EventArgs e)
        {
            //若未选择分区，提示用户
            if(targetDrive == string.Empty)
            {
                MessageBox.Show(this, text: "请选择分区！", caption: "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 创建批处理文件内容
            string batContent = $"%windir%\\Sysnative\\manage-bde.exe -lock {targetDrive} \r\n";

            string batFilePath = Path.Combine(Path.GetTempPath(), "lock_drive.bat");

            File.WriteAllText(batFilePath, batContent, Encoding.ASCII);

            try
            {
                if (RunProcess(batFilePath) == 0)
                {
                    //若勾选了删除盘符，则删除盘符
                    if (toDelVolLabel.Checked == true)
                    {
                        if (!DeleteVolumeMountPoint($@"{targetDrive}\"))
                        {
                            int errorCode = Marshal.GetLastWin32Error();
                            Console.WriteLine($"操作失败，错误代码: {errorCode}");
                        }
                    }

                    MessageBox.Show(this, text: "锁定成功", caption: "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefleshDrivers();
                }
                else
                {
                    MessageBox.Show(this, text: "锁定失败，请重试！", caption: "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"启动进程时出错：{ex.Message}");
            }
        }

        private void forceLockButton_Click(object sender, EventArgs e)
        {
            //若未选择分区，提示用户
            if (targetDrive == string.Empty)
            {
                MessageBox.Show(this, text: "请选择分区！", caption: "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new Alert(this).ShowDialog();
        }

        internal void ContinueForceButton_Click(object sender, EventArgs e)
        {
            // 创建批处理文件内容
            string batContent = $"%windir%\\Sysnative\\manage-bde.exe -lock {targetDrive} -ForceDismount\r\n";

            string batFilePath = Path.Combine(Path.GetTempPath(), "lock_drive.bat");

            File.WriteAllText(batFilePath, batContent, Encoding.ASCII);

            try
            {
                if (RunProcess(batFilePath) == 0)
                {
                    //若勾选了删除盘符，则删除盘符
                    if (toDelVolLabel.Checked == true)
                    {
                        if (!DeleteVolumeMountPoint($@"{targetDrive}\"))
                        {
                            int errorCode = Marshal.GetLastWin32Error();
                            Console.WriteLine($"操作失败，错误代码: {errorCode}");
                        }
                    }

                    MessageBox.Show(this, text: "锁定成功", caption: "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefleshDrivers();
                }
                else
                {
                    MessageBox.Show(this, text: "锁定失败，请重试！", caption: "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"启动进程时出错：{ex.Message}");
            }
        }

        private int RunProcess(string batFilePath)
        {
            // 检查文件路径是否为空
            if (string.IsNullOrEmpty(batFilePath)) throw new ArgumentException("batFilePath cannot be null or empty.");

            // 获取文件夹路径
            string folderPath = Path.GetDirectoryName(batFilePath);

            // 检查文件夹是否存在
            if (!Directory.Exists(folderPath)) throw new DirectoryNotFoundException($"The folder '{folderPath}' does not exist.");

            // 检查文件是否存在
            string batFileName = Path.Combine(folderPath, "lock_drive.bat");
            if (!File.Exists(batFileName)) throw new FileNotFoundException($"The file 'lock_drive.bat' does not exist in the folder '{folderPath}'.");

            // 创建一个ProcessStartInfo对象
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = batFileName,  // 直接设置为批处理文件路径
                UseShellExecute = false,  // 禁用Shell执行，以便可以获取退出代码
                Verb = "runas",          // 请求管理员权限
                WorkingDirectory = folderPath,
                CreateNoWindow = true,   // 隐藏窗口
                RedirectStandardOutput = true, // 重定向标准输出
                RedirectStandardError = true   // 重定向标准错误
            };

            try
            {
                // 启动进程
                using (Process process = Process.Start(startInfo))
                {
                    if (process == null) throw new InvalidOperationException("无法启动进程。");
                    process.WaitForExit();
                    return process.ExitCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
                return -1; // 返回一个错误代码，例如 -1
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

        private void RefleshButton_Click(object sender, EventArgs e)
        {
            RefleshDrivers();
        }
    }
}
