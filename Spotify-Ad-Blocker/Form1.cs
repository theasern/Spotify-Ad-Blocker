using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotify_Ad_Blocker
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = @"C:\Windows\System32\drivers\etc\hosts";
            var backuppath = @"C:\Windows\System32\drivers\etc\hostsbackup";
            File.Copy(path, backuppath);
            try
            {
                WebClient client = new WebClient();
                string txt = client.DownloadString("https://raw.githubusercontent.com/theasern/Spotify-Ad-Blocker/master/Spotify-Ad-Blocker/hosts");
                string[] txtS = new[] { txt };
                File.AppendAllText(path, txt);
                MessageBox.Show("Done!", "Spotify Ad Utility", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown Error", "Spotify Ad Utility", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

                

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var path = @"C:\Windows\System32\drivers\etc\hosts";
            var backuppath = @"C:\Windows\System32\drivers\etc\hostsbackup";
            if (File.Exists(backuppath))
            {
                File.Delete(path);
                File.Move(backuppath, path);
                MessageBox.Show("Done!", "Spotify Ad Utility", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("You already see ads", "Spotify Ad Utility", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }


        }
    }
}
