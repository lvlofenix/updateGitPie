namespace updatePie
{
    partial class formUpie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb_load = new System.Windows.Forms.ProgressBar();
            this.lb_log = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pb_load
            // 
            this.pb_load.Location = new System.Drawing.Point(12, 12);
            this.pb_load.Name = "pb_load";
            this.pb_load.Size = new System.Drawing.Size(539, 23);
            this.pb_load.TabIndex = 0;
            // 
            // lb_log
            // 
            this.lb_log.AutoSize = true;
            this.lb_log.Location = new System.Drawing.Point(11, 38);
            this.lb_log.Name = "lb_log";
            this.lb_log.Size = new System.Drawing.Size(92, 13);
            this.lb_log.TabIndex = 1;
            this.lb_log.Text = "Vamos começar...";
            // 
            // formUpie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 57);
            this.ControlBox = false;
            this.Controls.Add(this.lb_log);
            this.Controls.Add(this.pb_load);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formUpie";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update";
            this.Load += new System.EventHandler(this.formUpie_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_load;
        private System.Windows.Forms.Label lb_log;
    }
}

