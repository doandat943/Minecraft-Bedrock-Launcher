﻿using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Windows.Forms;

namespace Minecraft_Bedrock_Launcher
{
    public partial class AboutForm : Form
    {
        MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
        string continent, country, region;
        string app_id;
        string app_name = Application.ProductName;
        string app_version = Application.ProductVersion;

        public AboutForm()
        {
            InitializeComponent();

            //

            try
            {
                string device_id = GetDeviceID();
                string os = GetOSInfo();
                string today = GetDate();
                GetIPInfo();

                // let's initialize sql
                using (MySqlConnection connection = new MySqlConnection("server=cloud.kamvdta.xyz;port=3306;database=doandat943;uid=phpmyadmin;password=kinhvanhoa000"))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("", connection);
                    command.Parameters.AddWithValue("@device_id", device_id);
                    command.Parameters.AddWithValue("@permit", false);
                    command.Parameters.AddWithValue("@os", os);
                    command.Parameters.AddWithValue("@continent", continent);
                    command.Parameters.AddWithValue("@country", country);
                    command.Parameters.AddWithValue("@region", region);
                    command.Parameters.AddWithValue("@date", today);
                    command.Parameters.AddWithValue("@app_name", app_name);
                    command.Parameters.AddWithValue("@app_version", app_version);
                    command.Parameters.AddWithValue("@bedrock_version", mainForm.bedrock_version);
                    command.Parameters.AddWithValue("@education_win64_version", mainForm.education_win64_version);
                    command.Parameters.AddWithValue("@education_win32_version", mainForm.education_win32_version);

                    // App_Info (GET)
                    command.CommandText = "SELECT app_id FROM Application WHERE app_name = @app_name";
                    app_id = (string)command.ExecuteScalar();
                    command.Parameters.AddWithValue("@app_id", app_id);

                    command.CommandText = "SELECT app_hash FROM App_Info WHERE app_id = @app_id and app_version = @app_version";
                    string app_hash = (string)command.ExecuteScalar();
                    command.Parameters.AddWithValue("@app_hash", app_hash);

                    // App_Info (GET) --> Lastest

                    command.CommandText = "SELECT app_version FROM App_Info WHERE app_id = @app_id ORDER BY release_date DESC LIMIT 1";
                    string lastest_version = (string)command.ExecuteScalar();
                    command.Parameters.AddWithValue("@lastest_version", lastest_version);

                    command.CommandText = "SELECT release_date FROM App_Info WHERE app_version = @lastest_version";
                    DateTime release_date = (DateTime)command.ExecuteScalar();

                    // User (UPDATE)
                    command.CommandText = "SELECT * FROM User WHERE device_id = @device_id";
                    if (command.ExecuteScalar() != null)
                    {
                        command.CommandText = "UPDATE User SET continent = @continent, country = @country, region = @region WHERE device_id = @device_id";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.CommandText = "INSERT INTO User VALUES (@device_id, @permit, @os, @continent, @country, @region, @date)";
                        command.ExecuteNonQuery();
                    }

                    // User_Logs (UPDATE)
                    command.CommandText = "SELECT * FROM User_Logs WHERE device_id = @device_id";
                    if (command.ExecuteScalar() != null)
                    {
                        command.CommandText = "UPDATE User_Logs SET app_version = @app_version, last_used = @date, note = CONCAT_WS(' | ', IFNULL(@bedrock_version, '0'), IFNULL(@education_win64_version, '0'), IFNULL(@education_win32_version, '0')) WHERE device_id = @device_id";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.CommandText = "INSERT INTO User_Logs VALUES (@device_id, @app_id, @app_version, @date, @date, CONCAT_WS(' | ', IFNULL(@bedrock_version, '0'), IFNULL(@education_win64_version, '0'), IFNULL(@education_win32_version, '0')))";
                        command.ExecuteNonQuery();
                    }

                    // return permit
                    command.CommandText = "SELECT permit FROM User WHERE device_id = @device_id";
                    mainForm.permit = (bool)command.ExecuteScalar();

                    if (mainForm.permit == true)
                    {
                        // ME_Pointer_Win64 (GET)
                        command.CommandText = "SELECT education_pointer FROM ME_Pointer_Win64 WHERE education_version = @education_win64_version";
                        mainForm.education_win64_pointer = (string)command.ExecuteScalar();

                        // ME_Pointer_Win32 (GET)
                        command.CommandText = "SELECT education_pointer FROM ME_Pointer_Win32 WHERE education_version = @education_win32_version";
                        mainForm.education_win32_pointer = (string)command.ExecuteScalar();
                    }

                    textBox1.Text = "UUID: " + device_id + "\r\nStatus: " + (mainForm.permit ? "Activated" : "Waiting-For-Active") + "\r\nOS: " + os + "\r\nContinent: " + continent + " - " + country + "\r\nRegion: " + region;

                    string temp;
                    if (lastest_version != app_version)
                    {
                        Main_Button.Text = "Update";
                        temp = " (Outdated)";
                    }
                    else temp = " (Lastest)";
                    textBox1.Text += "\r\n-----------------------------------------------" + "\r\nApplication: " + app_name + "\r\nVersion: " + app_version + temp + "\r\nDeveloper: @doandat943\r\nWebsite: cloud.kamvdta.xyz\r\nEmail: doandat943@kamvdta.xyz";

                    if (!mainForm.VerifyFileIntegrity(Application.ExecutablePath, app_hash))
                    {
                        Main_Button.Text = "Update";
                        temp = "This app may be corrupted or tampered with.";
                    }
                    else temp = "This app is verified as genuine.";
                    textBox1.Text += "\r\n-----------------------------------------------" + "\r\nNote: " + temp + "\r\nLastest Version: " + lastest_version + " (" + release_date.ToString("yyyy/MM/dd") + ")";
                }
            }
            catch
            {
                textBox1.Text = "No Internet Connection\n";
            }
        }

        private void Main_Button_Click(object sender, EventArgs e)
        {
            if (Main_Button.Text == "Update")
            {
                string updater_path = Path.GetTempPath() + Path.GetRandomFileName().Replace(".", "") + ".bat";
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
            string deviceID = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProduct");
            foreach (ManagementObject mo in searcher.Get())
            {
                deviceID = mo["UUID"].ToString();
                break;
            }
            return deviceID;
        }

        string GetOSInfo()
        {
            return new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName;
        }

        string GetDate()
        {
            return DateTime.UtcNow.ToString("yyyy/MM/dd");
        }

        void GetIPInfo()
        {
            using (WebClient client = new WebClient())
            {
                string ip_api = client.DownloadString("http://ip-api.com/json/?fields=continent,country,regionName");
                dynamic countryData = JsonConvert.DeserializeObject(ip_api);

                continent = countryData.continent;
                country = countryData.country;
                region = countryData.regionName;
            }
        }
    }
}
