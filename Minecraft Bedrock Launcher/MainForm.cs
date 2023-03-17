using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
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
        public string education_pointer;

        public bool permit = false;
        bool flag_animation = true;
        string run_mode = "Minecraft Bedrock";
        bool run_status = false;

        public MainForm()
        {
            InitializeComponent();

            //

            Main_Button.Visible = false;
            Close_Button.Enabled = false;
            Logo.Enabled = false;

            axWindowsMediaPlayer.Dock = DockStyle.Fill;
            axWindowsMediaPlayer.uiMode = "none";
            axWindowsMediaPlayer.enableContextMenu = false;
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
                Main_Button.Visible = true;
                Close_Button.Enabled = true;
                Logo.Enabled = true;
                axWindowsMediaPlayer.Hide();
                axWindowsMediaPlayer.close();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (run_status == true) Stop_Bypass();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && permit == true)
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

                if ((run_mode == "Minecraft Bedrock" && bedrock_version != null) || (run_mode == "Minecraft Education" && education_version != null)) edition_option.DropDownItems.Add(option1);
                if (run_mode == "Minecraft Education" && education_version != null && run_status == true) edition_option.DropDownItems.Add(option2);
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
                string path = "";
                if (run_mode == "Minecraft Bedrock") path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang\minecraftpe\options.txt";
                else if (run_mode == "Minecraft Education") path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Minecraft Education Edition\games\com.mojang\minecraftpe\options.txt";

                string content = File.ReadAllText(path);
                Match match = Regex.Match(content, "mp_username:(.*)");
                string old_username = match.Groups[1].Value;
                string new_username = Interaction.InputBox("Enter GamerTag:", "", old_username);
                if (new_username != "")
                {
                    File.WriteAllText(path, content.Replace("mp_username:" + old_username, "mp_username:" + new_username));
                    if (run_status == true)
                    {
                        Stop_Bypass();
                        Start_Bypass();
                    }
                }
            }
            else if (itemTag == "Bypass")
            {
                Start_Bypass();
            }
            else if (itemTag == "Switch")
            {
                if (run_status == true) Stop_Bypass();
                if (run_mode == "Minecraft Bedrock")
                {
                    run_mode = "Minecraft Education";
                }
                else if (run_mode == "Minecraft Education")
                {
                    run_mode = "Minecraft Bedrock";
                }
                if (bedrock_version == null || education_version == null) Main_Button.Text = "Install Minecraft";
            }
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                else if (run_status == true && Process.GetProcessesByName("Minecraft.Windows").Length == 0) Stop_Bypass();
            }
        }

        private void Main_Button_Click(object sender, EventArgs e)
        {
            if (Main_Button.Text == "Start") Start_Bypass();
            else if (Main_Button.Text == "Stop") Stop_Bypass();
            else if (Main_Button.Text == "Active") Show_AboutForm();
            else if (Main_Button.Text == "Install Minecraft") Install();
        }

        void Show_AboutForm()
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.ShowDialog();
        }

        void Install()
        {
            if (run_mode == "Minecraft Bedrock") Process.Start($"ms-windows-store://pdp/?PFN=Microsoft.MinecraftUWP_8wekyb3d8bbwe");
            else if (run_mode == "Minecraft Education") Process.Start("https://archive.org/details/minecraft-education-edition-win32");
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
                return $"{versInfo.FileMajorPart}.{versInfo.FileMinorPart}.{versInfo.FileBuildPart}.{versInfo.FilePrivatePart}";
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
            if (run_mode == "Minecraft Bedrock")
            {
                StopProcess();
                Process process = new Process();
                process.StartInfo.FileName = "icacls";
                process.StartInfo.Arguments = original_path + " /GRANT ADMINISTRATORS:F";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();

                Thread.Sleep(1000);
                //
                if (!VerifyFileIntegrity(original_path, modified_dll_hash))
                {
                    File.Move(original_path, backup_path);
                }
                File.WriteAllBytes(original_path, Properties.Resources.Windows_ApplicationModel_Store);
                //
                Process.Start("minecraft:\\");
            }
            else if (run_mode == "Minecraft Education")
            {
                Process.Start(education_path);

                File.WriteAllBytes("MBL_Helper.exe", Properties.Resources.MBL_Helper);
                Process process = new Process();
                process.StartInfo.FileName = "MBL_Helper";
                process.StartInfo.Arguments = "\"" + education_pointer + "\"";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();
            }

            Thread.Sleep(1000);
            run_status = true;
        }

        void Stop_Bypass()
        {
            Main_Button.Text = "Start";
            StopProcess();
            if (run_mode == "Minecraft Bedrock")
            {
                Thread.Sleep(1000);
                //
                if (VerifyFileIntegrity(original_path, modified_dll_hash))
                {
                    File.Delete(original_path);
                }
                if (!VerifyFileIntegrity(backup_path, modified_dll_hash))
                {
                    File.Move(backup_path, original_path);
                }
            }
            else if (run_mode == "Minecraft Education")
            {
                File.Delete("MBL_Helper.exe");
            }
            //
            run_status = false;
        }
    }
}