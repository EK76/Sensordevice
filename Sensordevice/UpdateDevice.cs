using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CameraDevice
{
    public partial class FormUpdatedevice : Form
    {
        public FormUpdatedevice()
        {
            InitializeComponent();
        }

        string numbers, error;
        int numbers2;

        string password;
        private void FormUpdatedevice_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBoxStatus.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxStatus.BorderStyle = BorderStyle.None;
                pictureBoxStatus.Image = Image.FromFile("Pictures\\green.png");
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C ssh sensoruser@sensordevice /home/sensoruser/Sensordevice/checkupdates.sh";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardError = true;
                startInfo.CreateNoWindow = true;

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.Start();
                    numbers = process.StandardOutput.ReadToEnd();
                    error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                }
                numbers2 = Convert.ToInt32(numbers);
                if (numbers2 == 0)
                {
                    labelUpdate.Text = "No new updates available for \nSensor Device operating system.";
                    buttonUpdate.Enabled = false;
                    pictureBoxStatus.Image = Image.FromFile("Pictures\\green.png");
                }
                else
                {
                    labelUpdate.Text = "There are new updates for \nSensor Device operating system.";
                    buttonUpdate.Enabled = true;
                    pictureBoxStatus.Image = Image.FromFile("Pictures\\yellow.png");
                }
            
            }
            catch (Exception ex)
            {
                labelUpdate.Text = "Error occurred while checking for \nSensor Device operating system updates.";
                buttonUpdate.Enabled = false;
                pictureBoxStatus.Image = Image.FromFile("Pictures\\red.png");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                labelUpdate.Text = "Sensor device operating system \n is being updated with latest version.";
                buttonUpdate.Enabled = false;
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C ssh sensoruser@sensordevice sudo /home/sensoruser/Sensordevice/updatesystem.sh & pause";
                startInfo.WindowStyle = ProcessWindowStyle.Normal;

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                }

                labelUpdate.Text = "Sensor device operating system \n is updated with latest version.";
                pictureBoxStatus.Image = Image.FromFile("Pictures\\green.png");
            }
            catch (Exception ex)
            {
                buttonUpdate.Enabled = false;
                labelUpdate.Text = "Error occurred while updating \n Sensor device operating system.";
                pictureBoxStatus.Image = Image.FromFile("Pictures\\red.png");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
