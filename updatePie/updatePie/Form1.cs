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
                if (routerRly())
                {
                    while (byePie()) { System.Threading.Thread.Sleep(500); }
                    System.Threading.Thread.Sleep(2042);
                    moveOn();
                }
                else this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show (err.Message + err, "Houston, we have a problem..."
                                ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private Boolean routerRly()
        {

            // Alteração feita para não receber mais o codigo por parametro e sim por variavel de ambiente - codigo comentado caso seja necessario reverter o processo.

            /** string upLocation = String.Empty;
             string[] args = Environment.GetCommandLineArgs();
             foreach (string arg in args){upLocation += arg.ToString();}
             upLocation = upLocation.Replace(myLocation, "");
             upLocation = upLocation.Replace(@"\updatePie.exe", null); **/
            try
            {
                this.upLocation = System.Environment.GetEnvironmentVariable("UPDATE_FILES_PATH"); //upLocation;
                DirectoryInfo dir = new DirectoryInfo(upLocation);
                if (upLocation.Length > 0 & dir.Exists)
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }

        }
        
        private void moveOn()
        {
            upDir = new DirectoryInfo(upLocation);
            DirectoryInfo[] dirs = upDir.GetDirectories();

            //for responsavel pelas subs pastas
            for (int i = 0; i < dirs.Length; i++)
            {
                upDir = new DirectoryInfo(upLocation +@"\"+dirs[i].Name);
                FileInfo[] upAr = upDir.GetFiles("*.*");
                foreach (FileInfo fileinfo in upAr)
                {
                    moveArch(upLocation + @"\" + dirs[i], myLocation + @"\" + dirs[i], fileinfo.Name);
                }
            }

            //for responsavel pela pasta raiz
            upDir = new DirectoryInfo(upLocation);
            FileInfo[] upAraiz = upDir.GetFiles("*.*");
            foreach (FileInfo fileinforaiz in upAraiz) moveArch(upLocation + @"\", myLocation + @"\", fileinforaiz.Name);
            try{System.Diagnostics.Process.Start(myLocation + @"\GitPie.exe"); }
            catch{}
            this.Close();
        }

        private void moveArch(string local, string destino,string arquivo)
        {
            if (!Directory.Exists(destino))
            {
                Directory.CreateDirectory(destino);
            }
            if (File.Exists(destino + @"\" + arquivo)) File.Delete(destino + @"\" + arquivo);
            File.Move(local + @"\" + arquivo, destino + @"\" + arquivo);
        }

        private Boolean byePie()
        {
            if (Process.GetProcessesByName("getPie.exe").Length > 1)
            return true;
            else return false;
        }
    }
}
