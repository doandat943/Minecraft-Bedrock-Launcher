using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Minecraft_Bedrock_Launcher
{
    public partial class frmMain : Form
    {
        Bitmap vietnam_flag = Properties.Resources.vietnam_480px;
        Bitmap vietnam_government_flag = Properties.Resources.vietnam_government_480px;

        string original_path = @"C:\Windows\System32\Windows.ApplicationModel.Store.dll";
        string backup_path = @"C:\Windows\System32\Windows.ApplicationModel.Store.Common.dll";
        string modified_dll_hash = "C1469DEA551C95D2C68EB42CEB37F020CB5B75D777E7083F24BF2E54AE2E4F55";
        string education_win32_path = @"C:\Program Files (x86)\Microsoft Studios\Minecraft Education Edition\Minecraft.Windows.exe";

        public string bedrock_version;
        public string education_win64_version;
        public string education_win32_version;

        public string education_win64_pointer;
        public string education_win32_pointer;

        public bool permit;

        string run_mode;
        bool run_status;
        bool flag_animation = true;

        public frmMain()
        {
            InitializeComponent();

            //
            btnMain.Visible = false;
            ToggleSwitch.Visible = false;
            btnClose.Enabled = false;
            pbLogo.Enabled = false;

            //
            axWindowsMediaPlayer.Dock = DockStyle.Fill;
            axWindowsMediaPlayer.uiMode = "none";
            axWindowsMediaPlayer.enableContextMenu = false;
            axWindowsMediaPlayer.Ctlenabled = false;
            axWindowsMediaPlayer.URL = "http://cloud.joverse.me:2023/application/Minecraft-Bedrock-Launcher/Intro_MBL.mp4";

            //
            GetClientVersion();

            Dictionary<string, string> versions = new Dictionary<string, string>();
            if (bedrock_version != null)
            {
                versions.Add(bedrock_version, "Minecraft Bedrock");
            }
            if (education_win64_version != null)
            {
                versions.Add(education_win64_version, "Minecraft Education (Win64)");
            }
            if (education_win32_version != null)
            {
                versions.Add(education_win32_version, "Minecraft Education (Win32)");
            }
            run_mode = versions.FirstOrDefault().Value ?? "Minecraft Bedrock";

            RefreshMode();
        }

        private void axWindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                btnMain.Visible = true;
                ToggleSwitch.Visible = true;
                btnClose.Enabled = true;
                pbLogo.Enabled = true;

                axWindowsMediaPlayer.Hide();
                axWindowsMediaPlayer.close();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (run_status) StopBypass();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && permit)
            {
                ContextMenuStrip ContextMenu = new ContextMenuStrip();

                ToolStripMenuItem edition_option = new ToolStripMenuItem(run_mode);
                ToolStripMenuItem option1 = new ToolStripMenuItem("Change Local Gamertag");
                ToolStripMenuItem option2 = new ToolStripMenuItem("Bypass");
                ToolStripMenuItem switch_option = new ToolStripMenuItem("Switch");

                option1.Tag = "ChangeLocalGamertag";
                option2.Tag = "Bypass";
                switch_option.Tag = "Switch";

                option1.Click += new EventHandler(Option_Click);
                option2.Click += new EventHandler(Option_Click);
                switch_option.Click += new EventHandler(Option_Click);

                if ((run_mode == "Minecraft Bedrock" && bedrock_version != null) || (run_mode == "Minecraft Education (Win64)" && education_win64_version != null) || (run_mode == "Minecraft Education (Win32)" && education_win32_version != null)) edition_option.DropDownItems.Add(option1);
                if (((run_mode == "Minecraft Education (Win64)" && education_win64_version != null && education_win64_pointer != "") || (run_mode == "Minecraft Education (Win32)" && education_win32_version != null && education_win32_pointer != "")) && run_status) edition_option.DropDownItems.Add(option2);
                ContextMenu.Items.Add(edition_option);
                ContextMenu.Items.Add(switch_option);
                ContextMenu.Show(this, new Point(e.X, e.Y));
            }
        }

        private void Option_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            string itemTag = clickedItem.Tag.ToString();

            if (itemTag == "ChangeLocalGamertag")
            {
                string path = null;
                if (run_mode == "Minecraft Bedrock") path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang\minecraftpe\options.txt";
                else if (run_mode == "Minecraft Education (Win64)") path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\Microsoft.MinecraftEducationEdition_8wekyb3d8bbwe\LocalState\games\com.mojang\minecraftpe\options.txt";
                else if (run_mode == "Minecraft Education (Win32)") path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Minecraft Education Edition\games\com.mojang\minecraftpe\options.txt";

                string content = File.ReadAllText(path);
                Match match = Regex.Match(content, "mp_username:(.*)");
                string old_username = match.Groups[1].Value;
                string new_username = Interaction.InputBox("Enter GamerTag:", "", old_username);
                if (new_username != "")
                {
                    File.WriteAllText(path, content.Replace("mp_username:" + old_username, "mp_username:" + new_username));
                    if (run_status)
                    {
                        StopBypass();
                        StartBypass();
                    }
                }
            }
            else if (itemTag == "Bypass")
            {
                StartBypass();
            }
            else if (itemTag == "Switch")
            {
                if (run_status) StopBypass();

                if (run_mode == "Minecraft Bedrock") run_mode = "Minecraft Education (Win64)";
                else if (run_mode == "Minecraft Education (Win64)") run_mode = "Minecraft Education (Win32)";
                else if (run_mode == "Minecraft Education (Win32)") run_mode = "Minecraft Bedrock";

                GetClientVersion();
                RefreshMode();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (flag_animation)
            {
                if (pbFlag.Image == vietnam_flag) pbFlag.Image = vietnam_government_flag;
                else pbFlag.Image = vietnam_flag;
            }

            if (run_status && Process.GetProcessesByName("Minecraft.Windows").Length == 0) StopBypass();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            ShowAbout();
        }

        private void pbFlag_Click(object sender, EventArgs e)
        {
            if (flag_animation) flag_animation = false;
            else flag_animation = true;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            if (btnMain.Text == "Start") StartBypass();
            else if (btnMain.Text == "Stop") StopBypass();
            else if (btnMain.Text == "Active") ShowAbout();
            else if (btnMain.Text == "Get Minecraft") GetMinecraft();
        }

        void ShowAbout()
        {
            frmAbout aboutForm = new frmAbout();
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.ShowDialog();

            RefreshMode();
        }

        void GetMinecraft()
        {
            if (run_mode == "Minecraft Bedrock") Process.Start("ms-windows-store://pdp/?PFN=Microsoft.MinecraftUWP_8wekyb3d8bbwe");
            else if (run_mode == "Minecraft Education (Win64)") Process.Start("ms-windows-store://pdp/?PFN=Microsoft.MinecraftEducationEdition_8wekyb3d8bbwe");
            else if (run_mode == "Minecraft Education (Win32)") Process.Start("http://cloud.joverse.me:2023/application/Minecraft-Bedrock-Launcher/Archive/");
        }

        void GetClientVersion()
        {
            foreach (string subFolder in Directory.GetDirectories(@"C:\Program Files\WindowsApps"))
            {
                if (subFolder.Contains("Microsoft.MinecraftUWP"))
                {
                    bedrock_version = GetFileVersion(subFolder + @"\Minecraft.Windows.exe");
                }
                else if (subFolder.Contains("Microsoft.MinecraftEducationEdition") && subFolder.Contains("x64"))
                {
                    education_win64_version = GetFileVersion(subFolder + @"\Minecraft.Windows.exe");
                }
            }
            education_win32_version = GetFileVersion(education_win32_path);
        }

        void RefreshMode()
        {
            if (permit)
            {
                if (run_mode == "Minecraft Bedrock")
                {
                    if (bedrock_version == null) btnMain.Text = "Get Minecraft";
                    else if (!run_status) btnMain.Text = "Start";
                }
                else if (run_mode == "Minecraft Education (Win64)")
                {
                    if (education_win64_version == null) btnMain.Text = "Get Minecraft";
                    else if (education_win64_pointer == null) btnMain.Text = "Not Support";
                    else if (!run_status) btnMain.Text = "Start";
                }
                else if (run_mode == "Minecraft Education (Win32)")
                {
                    if (education_win32_version == null) btnMain.Text = "Get Minecraft";
                    else if (education_win32_pointer == null) btnMain.Text = "Not Support";
                    else if (!run_status) btnMain.Text = "Start";
                }
            }
            else
            {
                if (run_status) StopBypass();
                btnMain.Text = "Active";
            }
        }

        string GetFileVersion(string filePath)
        {
            if (File.Exists(filePath))
            {
                var versInfo = FileVersionInfo.GetVersionInfo(filePath);
                return $"{versInfo.FileMajorPart}.{versInfo.FileMinorPart}.{versInfo.FileBuildPart}.{versInfo.FilePrivatePart}";
            }
            return null;
        }

        public int VerifyFileIntegrity(string filePath, string expectedHash)
        {
            string HashOfFile = ComputeSHA256HashOfFile(filePath);
            if (HashOfFile == null) return -1;
            return HashOfFile.Equals(expectedHash, StringComparison.OrdinalIgnoreCase) ? 1 : 0;
        }

        public string ComputeSHA256HashOfFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (var sha256 = SHA256.Create())
                {
                    using (var stream = File.OpenRead(filePath))
                    {
                        var hash = sha256.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", null);
                    }
                }
            }
            return null;
        }

        void StopProcess()
        {
            String[] list = new String[] { "Minecraft.Windows", "WinStore.App", "GameBar", "RuntimeBroker", "MBL.Helper_x64", "MBL.Helper_x86" };

            foreach (string process_name in list)
            {
                foreach (var process in Process.GetProcessesByName(process_name))
                {
                    process.Kill();
                }
            }
        }

        void RunCommand(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c " + command;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;

            process.Start();
            process.WaitForExit();
        }

        void StartBypass()
        {
            btnMain.Text = "Stop";
            if (!run_status)
            {
                StopProcess();
                Thread.Sleep(1000);
            }

            if (run_mode == "Minecraft Bedrock")
            {
                RunCommand("takeown /f " + original_path);
                RunCommand("icacls " + original_path + " /GRANT ADMINISTRATORS:F");
                Thread.Sleep(1000);

                if (VerifyFileIntegrity(original_path, modified_dll_hash) == 0)
                {
                    File.Move(original_path, backup_path);
                }
                File.WriteAllBytes(original_path, Properties.Resources.Windows_ApplicationModel_Store);
                Process.Start("explorer", "minecraft:");
                Thread.Sleep(1000);
            }
            else if (run_mode == "Minecraft Education (Win64)")
            {
                if (!run_status)
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile("http://cloud.joverse.me:2023/application/Minecraft-Bedrock-Launcher/MBL.Helper_x64.exe", "MBL.Helper_x64.exe");
                    }
                    Process.Start("explorer", "minecraftedu:");
                    Thread.Sleep(1000);
                }
                if (ToggleSwitch.Checked || run_status)
                {
                    RunCommand("MBL.Helper_x64 Minecraft.Windows.exe \"" + education_win64_pointer + "\" 8");
                    RunCommand("MBL.Helper_x64 Minecraft.Windows.exe \"" + education_win64_pointer + "\" 9");
                }
            }
            else if (run_mode == "Minecraft Education (Win32)")
            {
                if (!run_status)
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile("http://cloud.joverse.me:2023/application/Minecraft-Bedrock-Launcher/MBL.Helper_x86.exe", "MBL.Helper_x86.exe");
                    }
                    Process.Start(education_win32_path);
                    Thread.Sleep(1000);
                }
                if (ToggleSwitch.Checked || run_status)
                {
                    RunCommand("MBL.Helper_x86 Minecraft.Windows.exe \"" + education_win32_pointer + "\" 8");
                    RunCommand("MBL.Helper_x86 Minecraft.Windows.exe \"" + education_win32_pointer + "\" 9");
                }
            }

            run_status = true;
        }

        void StopBypass()
        {
            btnMain.Text = "Start";
            StopProcess();
            Thread.Sleep(1000);

            if (run_mode == "Minecraft Bedrock")
            {
                if (VerifyFileIntegrity(original_path, modified_dll_hash) == 1)
                {
                    File.Delete(original_path);
                }
                if (VerifyFileIntegrity(backup_path, modified_dll_hash) == 0)
                {
                    File.Move(backup_path, original_path);
                }
            }
            else if (run_mode == "Minecraft Education (Win64)")
            {
                File.Delete("MBL.Helper_x64.exe");
            }
            else if (run_mode == "Minecraft Education (Win32)")
            {
                File.Delete("MBL.Helper_x86.exe");
            }

            run_status = false;
        }
    }
}