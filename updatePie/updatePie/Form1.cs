using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace updatePie
{
    public partial class formUpie : Form
    {
        public string myLocation = Application.StartupPath, upLocation = String.Empty, logtext = String.Empty;
        DirectoryInfo upDir;
        public formUpie(){InitializeComponent();}

        private void formUpie_Load(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(2042);
                if (routerRly())
                {
                    while (byePie())
                    {
                        log("Aguardando GitPie Fechar");
                        System.Threading.Thread.Sleep(500);
                    }
                    log("Gitpie Fechado. Iniciando processo.");
                    moveOn();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception err)
            {
                log("ERRO CRITICO: "+err.Message);
                log(err.ToString());
                MessageBox.Show (err.Message, "Houston, we have a problem... Verifique o log dentro da pasta do GitPie!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            for (int i = 0; i > dirs.Length; i++)
            {
                upDir = new DirectoryInfo(myLocation +@"\"+dirs[i].Name);
                FileInfo[] upAr = upDir.GetFiles("*.*");
                pb_load.Maximum = upAr.Length;
                foreach (FileInfo fileinfo in upAr)
                {
                    if (!Directory.Exists(upLocation + @"\" + dirs[i]))
                    {
                        Directory.CreateDirectory(upLocation + @"\" + dirs[i]);
                    }
                    if (fileinfo.Name != "updatePie.exe") { 
                    if (File.Exists(upLocation + @"\" + dirs[i] + @"\" + fileinfo.Name)) File.Delete(upLocation + @"\" + dirs[i] + @"\" + fileinfo.Name);
                        File.Move(myLocation + @"\" + dirs[i] + @"\" + fileinfo.Name, upLocation + @"\" + dirs[i] + @"\" + fileinfo.Name);
                        log("Arquivo atualizado: " + fileinfo.Name);
                    pb_load.Increment(1);
                    }
                }
            }
            System.Diagnostics.Process.Start(upLocation + @"\GitPie.exe");
            log("Fim da atualização...");
            saveLog();
            this.Close();
        }

        private Boolean byePie()
        {
            if (Process.GetProcessesByName("getPie.exe").Length > 1)
            return true;
            else return false;
        }

        private void log(string text)
        {
            logtext += Environment.NewLine + DateTime.Now +" > "+ text;
        }

        private void saveLog()
        {
            string txt = upLocation + @"/log_erro_updateGitPie.txt";
            FileInfo aFile = new FileInfo(txt);
            if (!aFile.Exists)
            {
                System.IO.File.Create(txt).Close();
            }
                System.IO.TextWriter arqTXT = System.IO.File.AppendText(logtext);
                arqTXT.WriteLine(logtext);
                arqTXT.Close();
        }
    }
}
