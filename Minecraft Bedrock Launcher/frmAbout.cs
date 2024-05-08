using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Windows.Forms;

namespace Minecraft_Bedrock_Launcher
{
    public partial class frmAbout : Form
    {
        frmMain mainForm = Application.OpenForms.OfType<frmMain>().FirstOrDefault();

        string app_name = Application.ProductName;
        string app_version = Application.ProductVersion;

        public frmAbout()
        {
            InitializeComponent();

            try
            {
                // get info from IP
                WebClient client = new WebClient();
                dynamic countryData = JsonConvert.DeserializeObject(client.DownloadString("http://ip-api.com/json/?fields=continent,country,regionName"));

                // sync data with MariaDB
                using (MySqlConnection connection = new MySqlConnection("server=joverse.us;port=3002;uid=root;password=kinhvanhoa0@Aa;database=joverse"))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("MBL", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Input
                    command.Parameters.AddWithValue("@in_app_name", app_name);
                    command.Parameters.AddWithValue("@in_app_version", app_version);
                    command.Parameters.AddWithValue("@in_app_hash", mainForm.ComputeSHA256HashOfFile(Application.ExecutablePath));
                    command.Parameters.AddWithValue("@in_device_id", GetDeviceID());
                    command.Parameters.AddWithValue("@in_os", new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName);
                    command.Parameters.AddWithValue("@in_continent", (string)countryData.continent);
                    command.Parameters.AddWithValue("@in_country", (string)countryData.country);
                    command.Parameters.AddWithValue("@in_region", (string)countryData.regionName);
                    command.Parameters.AddWithValue("@in_bedrock_version", mainForm.bedrock_version);
                    command.Parameters.AddWithValue("@in_education_win64_version", mainForm.education_win64_version);
                    command.Parameters.AddWithValue("@in_education_win32_version", mainForm.education_win32_version);

                    // Output
                    command.Parameters.Add("@out_result_text", MySqlDbType.Text).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@out_permit", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@out_need_update", MySqlDbType.Bit).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    // retrieve results
                    txtMain.Text = command.Parameters["out_result_text"].Value.ToString();
                    mainForm.permit = Convert.ToBoolean(command.Parameters["out_permit"].Value);
                    if (Convert.ToBoolean(command.Parameters["out_need_update"].Value)) btnMain.Text = "Update";
                }
            }
            catch (Exception e)
            {
                txtMain.Text = "No Internet Connection\n" + e;
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            if (btnMain.Text == "Update")
            {
                string updater_path = Path.GetTempPath() + Path.GetRandomFileName().Replace(".", null) + ".bat";
                File.WriteAllText(updater_path, Properties.Resources.updater);

                Process process = new Process();
                process.StartInfo.FileName = updater_path;
                process.StartInfo.Arguments = "\"" + Process.GetCurrentProcess().ProcessName + "\" \"" + Application.ExecutablePath + "\" \"" + app_name.Replace(" ", "-") + "\" \"" + app_name.Replace(" ", "_") + "\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
            }
            else this.Close();
        }

        string GetDeviceID()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProduct");
            foreach (ManagementObject mo in searcher.Get())
            {
                return mo["UUID"].ToString();
            }
            return null;
        }
    }
}
