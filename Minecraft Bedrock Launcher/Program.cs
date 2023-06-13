using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Minecraft_Bedrock_Launcher
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int SW_RESTORE = 9;

        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "ABC-unique-mutex"))
            {
                if (!mutex.WaitOne(TimeSpan.Zero, true))
                {
                    Process currentProcess = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
                    {
                        if (process.Id != currentProcess.Id && process.MainWindowHandle != IntPtr.Zero)
                        {
                            ShowWindow(process.MainWindowHandle, SW_RESTORE);
                            SetForegroundWindow(process.MainWindowHandle);
                            break;
                        }
                    }
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());

                mutex.ReleaseMutex();
            }
        }
    }
}
