using AxWMPLib;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace Minecraft_Bedrock_Launcher
{
    public partial class MainForm : Form
    {
        Bitmap vietnam_flag = Properties.Resources.vietnam_480px;
        Bitmap vietnam_government_flag = Properties.Resources.vietnam_government_480px;
        string original_path = @"C:\Windows\System32\Windows.ApplicationModel.Store.dll";
        string backup_path = @"C:\Windows\System32\Windows.ApplicationModel.Store.Preview.dll";

        string education_path = @"C:\Program Files (x86)\Microsoft Studios\Minecraft Education Edition\Minecraft.Windows.exe";
        string modified_dll_hash = "C1469DEA551C95D2C68EB42CEB37F020CB5B75D777E7083F24BF2E54AE2E4F55";

        public string bedrock_version;
        public string education_version;

        public bool permit = false;
        bool flag_animation = true;
        bool run_status = false;

        public MainForm()
        {
            InitializeComponent();

            //

            Close_Button.Enabled = false;
            Logo.Enabled = false;

            axWindowsMediaPlayer.Dock = DockStyle.Fill;
            axWindowsMediaPlayer.uiMode = "none";
            axWindowsMediaPlayer.URL = "https://cloud.kamvdta.xyz:2023/application/Intro_MBL.mp4";

            // Get Bedrock Version

            foreach (string subFolder in Directory.GetDirectories(@"C:\Program Files\WindowsApps"))
            {
                if (subFolder.Contains("Microsoft.MinecraftUWP"))
                {
                    bedrock_version = Path.GetFileName(subFolder).Replace("Microsoft.MinecraftUWP_", "").Replace("_x64__8wekyb3d8bbwe", "");
                    break;
                }
            }
            if (bedrock_version == null) Main_Button.Text = "Install Minecraft";

            // Get Education Version

            education_version = GetFileVersion(education_path);
        }

        private void axWindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == ((int)WMPLib.WMPPlayState.wmppsMediaEnded))
            {
                axWindowsMediaPlayer.Hide();
                Close_Button.Enabled = true;
                Logo.Enabled = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (run_status == true) Stop_Bypass();
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Country_Icon_Click(object sender, EventArgs e)
        {
            if (flag_animation == true) flag_animation = false;
            else flag_animation = true;
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            Show_AboutForm();
        }

        private void Flag_Tick(object sender, EventArgs e)
        {
            if (flag_animation)
            {
                if (Country_Icon.Image == vietnam_flag) Country_Icon.Image = vietnam_government_flag;
                else Country_Icon.Image = vietnam_flag;
            }
        }

        private void RefreshControl_Tick(object sender, EventArgs e)
        {
            if (permit == true)
            {
                if (Main_Button.Text == "Active") Main_Button.Text = "Start";
                else if (run_status && Process.GetProcessesByName("Minecraft.Windows").Length == 0) Stop_Bypass();
            }
        }

        private void Main_Button_Click(object sender, EventArgs e)
        {
            if (Main_Button.Text == "Start") Start_Bypass();
            else if (Main_Button.Text == "Stop") Stop_Bypass();
            else if (Main_Button.Text == "Active") Show_AboutForm();
            else if (Main_Button.Text == "Install Minecraft") Process.Start($"ms-windows-store://pdp/?PFN=Microsoft.MinecraftUWP_8wekyb3d8bbwe");
        }

        void Show_AboutForm()
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.ShowDialog();
        }

        public bool VerifyFileIntegrity(string filePath, string expectedHash)
        {
            if (File.Exists(filePath))
            {
                using (var sha256 = SHA256.Create())
                {
                    using (var stream = File.OpenRead(filePath))
                    {
                        var hash = sha256.ComputeHash(stream);
                        var hashString = BitConverter.ToString(hash).Replace("-", "");

                        return hashString.Equals(expectedHash, StringComparison.OrdinalIgnoreCase);
                    }
                }
            }
            else return false;
        }

        string GetFileVersion(string filePath)
        {
            if (File.Exists(filePath))
            {
                var versInfo = FileVersionInfo.GetVersionInfo(filePath);
                return $"V{versInfo.FileMajorPart}.{versInfo.FileMinorPart}.{versInfo.FileBuildPart}.{versInfo.FilePrivatePart}";
            }
            return null;
        }

        void StopProcess()
        {
            String[] list = new String[] { "Minecraft.Windows", "WinStore.App", "GameBar", "RuntimeBroker" };

            foreach (string process_name in list)
            {
                foreach (var process in Process.GetProcessesByName(process_name))
                {
                    process.Kill();
                }
            }
        }

        void Start_Bypass()
        {
            Main_Button.Text = "Stop";
            StopProcess();
            Thread.Sleep(1500);
            //
            if (!VerifyFileIntegrity(original_path, modified_dll_hash))
            {
                File.Move(original_path, backup_path);
            }
            File.WriteAllBytes(original_path, Properties.Resources.Windows_ApplicationModel_Store);
            //
            Process.Start("minecraft:\\");
            Thread.Sleep(1000);
            run_status = true;
        }

        void Stop_Bypass()
        {
            Main_Button.Text = "Start";
            StopProcess();
            Thread.Sleep(1500);
            //
            if (!VerifyFileIntegrity(backup_path, modified_dll_hash))
            {
                File.Move(backup_path, original_path);
            }
            if (VerifyFileIntegrity(original_path, modified_dll_hash))
            {
                File.Delete(original_path);
            }
            //
            run_status = false;
        }
    }
}