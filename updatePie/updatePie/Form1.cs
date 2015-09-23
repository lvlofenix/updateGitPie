using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace updatePie
{
    public partial class formUpie : Form
    {
        public string myLocation = Application.StartupPath, upLocation = String.Empty;
        DirectoryInfo upDir;
        public formUpie(){InitializeComponent();}

        private void formUpie_Load(object sender, EventArgs e)
        {
            try
            {
                if (routerRly()){byePie();moveOn();}
                else this.Close();
            }
            catch (Exception err)
            {MessageBox.Show (err.Message, "Houston, we have a problem...",MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }

        private Boolean routerRly()
        {
            string[] args = Environment.GetCommandLineArgs();
            foreach (string arg in args){upLocation = arg.ToString();}
            DirectoryInfo dir = new DirectoryInfo(upLocation);
            if (upLocation.Length > 0 & dir.Exists)
            return true;
            else return false;
        }
        
        private void moveOn()
        {
            upDir = new DirectoryInfo(myLocation);
            DirectoryInfo[] dirs = upDir.GetDirectories();
            for (int i = 0; i >= dirs.Length; i++)
            {
                upDir = new DirectoryInfo(myLocation +@"\"+dirs[i].Name);
                FileInfo[] upAr = upDir.GetFiles("*.*");
                pb_load.Maximum = upAr.Length;
                foreach (FileInfo fileinfo in upAr)
                {
                    if(!Directory.Exists(upLocation + @"\" + dirs[i]))
                    {
                        Directory.CreateDirectory(upLocation + @"\" + dirs[i]);
                    }
                    if (File.Exists(upLocation + @"\" + dirs[i] + @"\" + fileinfo.Name)) File.Delete(upLocation + @"\" + dirs[i] + @"\" + fileinfo.Name);
                    File.Move(myLocation + @"\" + dirs[i] + @"\" + fileinfo.Name, upLocation + @"\" + dirs[i] + @"\" + fileinfo.Name);
                    pb_load.Increment(1);
                }
            }
            System.Diagnostics.Process.Start(upLocation + @"\GitPie.exe");
            Directory.Delete(myLocation, true);
            File.Delete(upLocation + @"\updatePie.exe");
            this.Close();
        }

        private void byePie()
        {
            if (Process.GetProcessesByName("getPie.exe").Length > 1)
            {
                Process[] processes = Process.GetProcessesByName("getPie.exe");
                foreach (Process process in processes) { process.Kill(); }
            }
        }
    }
}
