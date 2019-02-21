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
using System.Windows.Forms;

namespace Spotify_Ad_Blocker
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            var backuppath = @"C:\Windows\System32\drivers\etc\hostsbackup";
            if (File.Exists(backuppath)) Remove();
            else Enable();
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
                Remove();
                MessageBox.Show("Done! Ads are now DISABLED", "Spotify Ad Utility", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Spotify Ad Utility", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                Enable();
                MessageBox.Show("Done! Ads are now ACTIVE", "Spotify Ad Utility", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("You already see ads", "Spotify Ad Utility", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }


        }

        internal void Remove()
        {
            button1.Enabled = false;
            button2.Enabled = true;
        }

        internal void Enable()
        {
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
