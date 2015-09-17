using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace updatePie
{
    public partial class formUpie : Form
    {
        public string myLocation = Application.StartupPath, upLocation = String.Empty;
        public formUpie()
        {
            InitializeComponent();
        }

        private void formUpie_Load(object sender, EventArgs e)
        {
            try
            {
                if (routerRly())
                {
                    byePie(); moveOn();
                }
                else this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show (err.Message, "Houston, we have a problem...",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean routerRly()
        {
            string[] args = Environment.GetCommandLineArgs();
            foreach (string arg in args)
            {
                if (!(arg.Contains(@"\") || arg.Contains("/"))) upLocation = arg.ToString();
            }
            DirectoryInfo dir = new DirectoryInfo(Path.GetTempPath() + upLocation);
            if (upLocation.Length >0 & dir.Exists)
            {
                return true;
            }
            else return false;
        }
        
        private void moveOn()
        {
            DirectoryInfo upDir = new DirectoryInfo(Path.GetTempPath() + upLocation);
            FileInfo[] upAr = upDir.GetFiles("*.*");
            pb_load.Maximum = upAr.Length;
            foreach (FileInfo fileinfo in upAr)
            {
                if (File.Exists(myLocation + @"\" + fileinfo.Name)) File.Delete(myLocation + @"\" + fileinfo.Name);
                File.Move(Path.GetTempPath() + upLocation + @"\" + fileinfo.Name, myLocation + @"\" + fileinfo.Name);
                pb_load.Increment(1); 
            }
            System.Diagnostics.Process.Start(myLocation + @"\GitPie.exe");
            this.Close();
        }

        private void byePie()
        {
            if (Process.GetProcessesByName("getPie.exe").Length > 1)
            {
                Process[] processes = Process.GetProcessesByName("getPie.exe");
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
        }
    }
}
