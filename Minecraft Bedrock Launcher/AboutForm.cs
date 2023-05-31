using AxWMPLib;
using Microsoft.VisualBasic.Logging;
using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Minecraft_Bedrock_Launcher
{
    public partial class AboutForm : Form
    {
        MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();

        public AboutForm()
        {
            InitializeComponent();
            
            try
            {
                // Get App Info
                string app_id;
                string app_name = Application.ProductName;
                string app_version = Application.ProductVersion;
                string app_hash;

                // Get Environment Info
                string device_id = GetDeviceID();
                string os = new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName;
                string today = DateTime.UtcNow.ToString("yyyy/MM/dd");

                // Get IP Info
                WebClient client = new WebClient();
                string ip_api = client.DownloadString("http://ip-api.com/json/?fields=continent,country,regionName");
                dynamic countryData = JsonConvert.DeserializeObject(ip_api);

                string continent = countryData.continent;
                string country = countryData.country;
                string region = countryData.regionName;
                
                // Let's initialize sql
                using (MySqlConnection connection = new MySqlConnection("server=joverse.me;port=3306;database=doandat943;uid=phpmyadmin;password=kinhvanhoa000"))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("", connection);
                    command.Parameters.AddWithValue("@device_id", device_id);
                    command.Parameters.AddWithValue("@permit", false);
                    command.Parameters.AddWithValue("@os", os);
                    command.Parameters.AddWithValue("@continent", continent);
                    command.Parameters.AddWithValue("@country", country);
                    command.Parameters.AddWithValue("@region", region);
                    command.Parameters.AddWithValue("@today", today);
                    command.Parameters.AddWithValue("@app_name", app_name);
                    command.Parameters.AddWithValue("@app_version", app_version);
                    command.Parameters.AddWithValue("@bedrock_version", mainForm.bedrock_version);
                    command.Parameters.AddWithValue("@education_win64_version", mainForm.education_win64_version);
                    command.Parameters.AddWithValue("@education_win32_version", mainForm.education_win32_version);

                    DataTable dataTable = new DataTable();
                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(command);

                    // App_Info (GET)
                    command.CommandText = "SELECT app_id, app_hash FROM Application AS A JOIN App_Info AS AI ON A.app_id = AI.app_id WHERE A.app_name = @app_name AND AI.app_version = @app_version";
                    sqlDataAdapter.Fill(dataTable);
                    app_id = dataTable.Rows[0][0].ToString();
                    app_hash = dataTable.Rows[0][1].ToString();

                    // App_Info (GET) --> Lastest
                    command.Parameters.AddWithValue("@app_id", app_id);
                    command.CommandText = "SELECT app_version, release_date FROM App_Info WHERE app_id = @app_id ORDER BY release_date DESC LIMIT 1";
                    sqlDataAdapter.Fill(dataTable);

                    string lastest_version = dataTable.Rows[0][0].ToString();
                    string release_date = Convert.ToDateTime(dataTable.Rows[0][1]).ToString("yyyy/MM/dd");

                    // User (UPDATE)
                    command.CommandText = "SELECT * FROM User WHERE device_id = @device_id";
                    if (command.ExecuteScalar() != null)
                    {
                        command.CommandText = "UPDATE User SET continent = @continent, country = @country, region = @region WHERE device_id = @device_id";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.CommandText = "INSERT INTO User VALUES (@device_id, @permit, @os, @continent, @country, @region, @today)";
                        command.ExecuteNonQuery();
                    }

                    // ME_Pointer (GET)
                    command.CommandText = "SELECT education_pointer FROM ME_Pointer WHERE (education_version = @education_win64_version and type = 'win64') or (education_version = @education_win32_version and type = 'win32') ORDER BY type DESC";
                    sqlDataAdapter.Fill(dataTable);
                    mainForm.education_win64_pointer = dataTable.Rows[0][0].ToString();
                    mainForm.education_win32_pointer = dataTable.Rows[1][0].ToString();
                    
                    // Permit (GET)
                    command.CommandText = "SELECT permit FROM User WHERE device_id = @device_id";
                    mainForm.permit = (bool)command.ExecuteScalar();


                    // User_Log (UPDATE)
                    command.CommandText = "SELECT * FROM User_Logs WHERE device_id = @device_id";
                    if (command.ExecuteScalar() != null)
                    {
                        command.CommandText = "UPDATE User_Logs SET app_version = @app_version, last_used = @today, note = CONCAT_WS(' | ', IFNULL(@bedrock_version, '0'), IFNULL(@education_win64_version, '0'), IFNULL(@education_win32_version, '0')) WHERE device_id = @device_id";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.CommandText = "INSERT INTO User_Logs VALUES (@device_id, @app_id, @app_version, @today, @today, CONCAT_WS(' | ', IFNULL(@bedrock_version, '0'), IFNULL(@education_win64_version, '0'), IFNULL(@education_win32_version, '0')))";
                        command.ExecuteNonQuery();
                    }

                    // Show on UI

                    string note1;
                    string note2;

                    string config_file = "config.txt";
                    if (File.Exists(config_file)) config_file = File.ReadAllText(config_file);

                    if (config_file.Contains("developer_mode:true"))
                    {
                        mainForm.permit = true;
                        note1 = "DEV";
                        note2 = "This app is in development mode";

                        command.Parameters.AddWithValue("@app_hash", mainForm.ComputeSHA256HashOfFile(Application.ExecutablePath));
                        command.CommandText = "Update App_Info Set app_hash = @app_hash WHERE app_id = @app_id and app_version = @app_version";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        if (lastest_version != app_version)
                        {
                            Main_Button.Text = "Update";
                            note1 = "Outdated";
                        }
                        else note1 = "Lastest";

                        if (!mainForm.VerifyFileIntegrity(Application.ExecutablePath, app_hash))
                        {
                            Main_Button.Text = "Update";
                            note2 = "This app may be corrupted or tampered with";
                        }
                        else note2 = "This app is verified as genuine";
                    }

                    textBox1.Text = "UUID: " + device_id + "\r\nStatus: " + (mainForm.permit ? "Activated" : "Waiting-For-Active") + "\r\nOS: " + os + "\r\nContinent: " + continent + " - " + country + "\r\nRegion: " + region
                    + "\r\n-----------------------------------------------" + "\r\nApplication: " + app_name + "\r\nVersion: " + app_version + " (" + note1 + ")\r\nDeveloper: @doandat943\r\nWebsite: joverse.me\r\nEmail: doandat943@joverse.me"
                    + "\r\n-----------------------------------------------" + "\r\nNote: " + note2 + ".\r\nLastest Version: " + lastest_version + " (" + release_date + ")";
                }
            }
            catch (Exception e)
            {
                textBox1.Text = "No Internet Connection\n" + e;
            }
        }

        private void Main_Button_Click(object sender, EventArgs e)
        {
            if (Main_Button.Text == "Update")
            {
                string updater_path = Path.GetTempPath() + Path.GetRandomFileName().Replace(".", null) + ".bat";
                File.WriteAllText(updater_path, Properties.Resources.updater);

                Process process = new Process();
                process.StartInfo.FileName = updater_path;
                process.StartInfo.Arguments = "\"" + Process.GetCurrentProcess().ProcessName + "\" \"" + Application.ExecutablePath + "\" \"" + app_id + "\" \"" + app_name.Replace(" ", "_") + "\"";
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
