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
        string modified_dll_hash = "C1469DEA551C95D2C68EB42CEB37F020CB5B75D777E7083F24BF2E54AE2E4F55";

        public bool permit = false;
        bool flag_animation = true;
        bool run_status = false;

        public MainForm()
        {
            InitializeComponent();

            //

            foreach (string subFolder in Directory.GetDirectories(@"C:\Program Files\WindowsApps"))
            {
                if (!subFolder.Contains("Microsoft.MinecraftUWP") && Main_Button.Text == "Active") Main_Button.Text = "Install Minecraft";
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (run_status) stop_bypass();
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
            if (flag_animation) flag_animation = false;
            else flag_animation = true;
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            show_AboutForm();
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
            if (permit)
            {
                if (Main_Button.Text == "Active") Main_Button.Text = "Start";
                if (run_status && Process.GetProcessesByName("Minecraft.Windows").Length == 0) stop_bypass();
            }
        }

        private void Main_Button_Click(object sender, EventArgs e)
        {
            if (Main_Button.Text == "Start") start_bypass();
            else if (Main_Button.Text == "Stop") stop_bypass();
            else if (Main_Button.Text == "Active") show_AboutForm();
            else if (Main_Button.Text == "Install Minecraft") Process.Start($"ms-windows-store://pdp/?PFN=Microsoft.MinecraftUWP_8wekyb3d8bbwe");
        }

        void show_AboutForm()
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.ShowDialog();
        }

        bool VerifyFileIntegrity(string filePath, string expectedHash)
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

        void stop_Process()
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

        void start_bypass()
        {
            Main_Button.Text = "Stop";
            stop_Process();
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

        void stop_bypass()
        {
            Main_Button.Text = "Start";
            stop_Process();
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