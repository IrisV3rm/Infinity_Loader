using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infinity
{
    public partial class Main : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
        );

        string Path = "c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity";

        public Main()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Main_Load(object sender, EventArgs e)
        {
            label1.Text = "Please accept our TOS to continue!";
            label1.Font = new Font("Consolas", (float)15.75, FontStyle.Regular);


            if (Directory.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity"))
            {
                if (File.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\__VERSION"))
                {
                    using (WebClient web = new WebClient())
                    {
                        string Version = web.DownloadString(new Uri("https://irishost.xyz/InfinityHosting/VERSION"));
                        string CurrentVersion = File.ReadAllText("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\__VERSION");
                        //"c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity"
                        if (CurrentVersion == Version)
                        {
                            Process.Start("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity" + "\\InfinityMain.exe");
                            Task.Delay(250);
                            Environment.Exit(0);
                            return;
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity");
                if (File.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\__VERSION"))
                {
                    using (WebClient web = new WebClient())
                    {
                        string Version = web.DownloadString(new Uri("https://irishost.xyz/InfinityHosting/VERSION"));
                        string CurrentVersion = File.ReadAllText("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\__VERSION");
                        //"c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity"
                        if (CurrentVersion == Version)
                        {
                            Process.Start("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity" + "\\InfinityMain.exe");
                            Task.Delay(250);
                            Environment.Exit(0);
                            return;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.irishost.xyz/#TOS");
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private async void Init()
        {
            try
            {
                if (Process.GetProcessesByName("InfinityMain").Length != 0) for (var i = 0; i < Process.GetProcessesByName("InfinityMain").Length; i++) Process.GetProcessesByName("InfinityMain")[i].Kill(); Task.Delay(500);
            }
            catch (Exception)
            {
                MessageBox.Show("An error has a occured while closing old proccess's please try again!", "Yikes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Environment.Exit(0);
                return;
            }
            try
            {

                if (Directory.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity"))
                {
                    if (File.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\InfinityMain.exe") || File.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\x86\\SQLite.Interop.dll") || File.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\x86\\SQLite.Interop.dll") || File.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\Update.zip"))
                    {
                        if (File.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\InfinityMain.exe"))
                        {
                            File.Delete("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\InfinityMain.exe");
                        }
                        if (File.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\x64\\SQLite.Interop.dll"))
                        {
                            File.Delete("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\x64\\SQLite.Interop.dll");
                        }
                        if (File.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\x86\\SQLite.Interop.dll"))
                        {
                            File.Delete("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\x86\\SQLite.Interop.dll");
                        }
                        if (File.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\Multiple_ROBLOX.exe"))
                        {
                            File.Delete("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\Multiple_ROBLOX.exe");
                        }
                        if (File.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\Update.zip"))
                        {
                            File.Delete("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\Update.zip");
                        }
                        await Task.Delay(500);
                    }
                }
                else
                {
                    Directory.CreateDirectory("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error has a occured while deleting the old files please try again!", "Yikes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Environment.Exit(0);
            }
        }

        private void ProgChange(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                bunifuCircleProgressbar1.MaxValue = (int)e.TotalBytesToReceive;
                bunifuCircleProgressbar1.Value = (int)e.BytesReceived;
            }
            catch { }
        }

        private async void Web_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            label1.Font = new Font("Consolas", (float)15.75, FontStyle.Regular);
            label1.Location = new Point(106, 145);
            label1.Text = "Download Complete, Launching!";

            if (Process.GetProcessesByName("InfinityMain").Length != 0) for (var i = 0; i < Process.GetProcessesByName("InfinityMain").Length; i++) Process.GetProcessesByName("InfinityMain")[i].Kill();

            ZipFile.ExtractToDirectory("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\Update.zip", "c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity");

            

            await Task.Delay(1000); Process.Start("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity" + "\\InfinityMain.exe");

            if (File.Exists("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\__VERSION"))
            {
                File.Delete("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\__VERSION");
                await Task.Delay(100);

                File.Create("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\__VERSION").Close();

                await Task.Delay(250);
                using (WebClient web = new WebClient())
                {
                    File.WriteAllText("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\__VERSION", web.DownloadString("https://irishost.xyz/InfinityHosting/VERSION"));
                }
            }
            else
            {
                using (WebClient web = new WebClient())
                {
                    File.WriteAllText("c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity\\__VERSION", web.DownloadString("https://irishost.xyz/InfinityHosting/VERSION"));
                }
            }
            await Task.Delay(2000);
            Application.Exit();
        }

        private void StartDownload()
        {
            if (CheckForInternetConnection())
            {
                Init();
                using (WebClient web = new WebClient())
                {
                    web.DownloadFileAsync(new Uri(new WebClient().DownloadString("https://www.irishost.xyz/InfinityHosting/Update")), "c:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Infinity" + "\\Update.zip");
                    web.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgChange);
                    web.DownloadFileCompleted += new AsyncCompletedEventHandler(Web_DownloadFileCompleted);
                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show("This requries an internet connection!", "Yikes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Environment.Exit(0);
            }
        }



        private void flatToggle1_CheckedChanged(object sender)
        {
            if (flatToggle1.Checked == true)
            {
                flatToggle1.Checked = false;
                DialogResult dialog = MessageBox.Show("You have just agree'd to our terms you cannot undo now, would you like to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dialog == DialogResult.Yes)
                {
                    label1.Text = "Thank you for accepting our TOS the download will start!";
                    label1.Font = new Font("Consolas", 12, FontStyle.Regular);
                    label1.Location = new Point(29, 149);
                    flatToggle1.Enabled = false;
                    flatToggle1.Checked = true;
                    StartDownload();
                }
                else
                {
                    flatToggle1.Checked = false;
                    label1.Text = "Please accept our TOS to continue!";
                    label1.Font = new Font("Consolas", (float)15.75, FontStyle.Regular);
                    label1.Location = new Point(76, 145);
                }
            }
            else
            {
                label1.Text = "Please accept our TOS to continue!";
                label1.Font = new Font("Consolas", (float)15.75, FontStyle.Regular);
                label1.Location = new Point(76, 145);
            }
        }
    }
}
