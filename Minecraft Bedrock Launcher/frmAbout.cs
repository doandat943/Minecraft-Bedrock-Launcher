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
                using (MySqlConnection connection = new MySqlConnection("server=joverse.me;uid=doandat943;password=kinhvanhoa000;database=doandat943"))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("MBL", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // input
                    command.Parameters.AddWithValue("@app_name", app_name);
                    command.Parameters.AddWithValue("@app_version", app_version);
                    command.Parameters.AddWithValue("@app_hash", mainForm.ComputeSHA256HashOfFile(Application.ExecutablePath));
                    command.Parameters.AddWithValue("@device_id", GetDeviceID());
                    command.Parameters.AddWithValue("@os", new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName);
                    command.Parameters.AddWithValue("@continent", (string)countryData.continent);
                    command.Parameters.AddWithValue("@country", (string)countryData.country);
                    command.Parameters.AddWithValue("@region", (string)countryData.regionName);
                    command.Parameters.AddWithValue("@bedrock_version", mainForm.bedrock_version);
                    command.Parameters.AddWithValue("@education_win64_version", mainForm.education_win64_version);
                    command.Parameters.AddWithValue("@education_win32_version", mainForm.education_win32_version);

                    // output
                    command.Parameters.Add("@result_text", MySqlDbType.VarChar, 4000).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@permit", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@education_win64_pointer", MySqlDbType.VarChar, 64).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@education_win32_pointer", MySqlDbType.VarChar, 64).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@need_update", MySqlDbType.Bit).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    // retrieve results
                    txtMain.Text = command.Parameters["result_text"].Value.ToString();
                    mainForm.permit = Convert.ToBoolean(command.Parameters["permit"].Value);
                    mainForm.education_win64_pointer = command.Parameters["education_win64_pointer"].Value != DBNull.Value ? command.Parameters["education_win64_pointer"].Value.ToString() : null;
                    mainForm.education_win32_pointer = command.Parameters["education_win32_pointer"].Value != DBNull.Value ? command.Parameters["education_win32_pointer"].Value.ToString() : null;
                    if (Convert.ToBoolean(command.Parameters["need_update"].Value)) btnMain.Text = "Update";
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
