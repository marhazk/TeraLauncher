using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//
using System.Diagnostics;  //process run
using System.IO;  //file io
using System.Net; //http request
using System.Reflection; //bindings prop control
using System.IO.Compression;

namespace TeraLauncher
{
    public partial class Main : Form
    {
        public Thread patch;
        public bool restart = false;
        public int max = 10000;
        public Main()
        {
            InitializeComponent();
        }
        public void webClientProgress()
        {
            string msg = "";
            string msgdot = "";
            int index = 1000;
            int indexdot = 0;
            while (true)
            {
                index++;
                if (index.ToString().Substring(2, 2) == "00")
                {
                    indexdot++;
                    if (indexdot == 1)
                        msgdot = "";
                    else if (indexdot == 2)
                        msgdot = ".";
                    else if (indexdot == 3)
                        msgdot = "..";
                    else if (indexdot == 4)
                        msgdot = "...";
                    else if (indexdot == 5)
                        msgdot = "....";
                    else
                        indexdot = 0;

                }
                Program.msg.send(_m, msg+msgdot);
                if (index > max)
                {
                    msg = "Launching login screen...";
                    break;
                }
                else if ((index > 8000) && (restart))
                {
                    msg = "Extracting files...";

                    Ionic.Zip.ZipFile zipFile = new Ionic.Zip.ZipFile("TeraPatcher.zip");
                    zipFile.ExtractAll(Application.StartupPath, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                    zipFile.Dispose();
                    FileDB.TryToDelete("TeraPatcher.zip");
                }
                else if (index > 8000)
                    msg = "Checking memories...";
                else if (index > 7000)
                    msg = "Checking version...";
                else if (index > 5500)
                    msg = "Checking configurations...";
                else if (index > 5000)
                    msg = "Checking files...";
            }
            Process.Start("TeraPatcher.exe", "AeraGaming:MarHazK");
            Program.msg.send(_m, "Exiting");
            Environment.Exit(0);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            restart = false;
            if (File.Exists("AERAAUTORESTART.marhazk"))
            {
                max = 100000;
                restart = true;
            }
            Program.msg.send(_m, "");
            _x.Text = "Aera Gaming International";
            patch = new Thread(new ThreadStart(webClientProgress));
            patch.Start();
        }
    }
}
