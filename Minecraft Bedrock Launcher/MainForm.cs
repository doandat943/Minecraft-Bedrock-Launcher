using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Minecraft_Bedrock_Launcher
{
    public partial class MainForm : Form
    {
        Bitmap vietnam_flag = Properties.Resources.vietnam_480px;
        Bitmap vietnam_government_flag = Properties.Resources.vietnam_government_480px;
        string path1 = @"C:\Windows\System32\Windows.ApplicationModel.Store.dll";
        string path2 = @"C:\Windows\System32\Windows.ApplicationModel.Store.Preview.dll";
        bool bypass_status = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Country_Icon.Image == vietnam_flag)
            {
                Country_Icon.Image = vietnam_government_flag;
            }
            else
            {
                Country_Icon.Image = vietnam_flag;
            }

            if (bypass_status == true && Process.GetProcessesByName("Minecraft.Windows").Length == 0) stop_bypass();
        }

        private void Main_Button_Click(object sender, EventArgs e)
        {
            if (Main_Button.Text == "Start") start_bypass();
            else if (Main_Button.Text == "Stop") stop_bypass();
        }

        bool check_original(string path)
        {
            bool temp = false;
            if (File.Exists(path))
            {
                var versInfo = FileVersionInfo.GetVersionInfo(path);
                if ($"V{versInfo.FileMajorPart}.{versInfo.FileMinorPart}.{versInfo.FileBuildPart}.{versInfo.FilePrivatePart}" != "V10.0.18362.1110") temp = true;
            }
            return temp;
        }

        void start_bypass()
        {
            Main_Button.Text = "Stop";
            stop_Process();
            Thread.Sleep(1500);
            //
            if (check_original(path1) == true && check_original(path2) == false)
            {
                if (!File.Exists(path2) && File.Exists(path1)) File.Move(path1, path2);
            }
            else if (check_original(path1) == true && check_original(path2) == true)
            {
                if (File.Exists(path1)) File.Delete(path1);
            }
            //
            File.WriteAllBytes(path1, Properties.Resources.Windows_ApplicationModel_Store);
            Process.Start("explorer", @"shell:appsFolder\Microsoft.MinecraftUWP_8wekyb3d8bbwe!App");
            Thread.Sleep(1000);
            bypass_status = true;
        }

        void stop_bypass()
        {
            Main_Button.Text = "Start";
            stop_Process();
            Thread.Sleep(1500);
            //
            if (check_original(path1) == false && check_original(path2) == true)
            {
                if (File.Exists(path1)) File.Delete(path1);
                if (File.Exists(path2)) File.Move(path2, path1);
            }
            else if (check_original(path1) == false && check_original(path2) == false)
            {
                if (File.Exists(path1)) File.Delete(path1);
                if (File.Exists(path2)) File.Delete(path2);
            }
            else if (check_original(path1) == true && check_original(path2) == false)
            {
                if (File.Exists(path2)) File.Delete(path2);
            }
            //
            bypass_status = false;
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bypass_status == true) stop_bypass();
        }
    }
}
