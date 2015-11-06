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
            this.SuspendLayout();
            // 
            // pb_load
            // 
            this.pb_load.Location = new System.Drawing.Point(5, 12);
            this.pb_load.Name = "pb_load";
            this.pb_load.Size = new System.Drawing.Size(577, 23);
            this.pb_load.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pb_load.TabIndex = 0;
            // 
            // formUpie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(591, 47);
            this.Controls.Add(this.pb_load);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formUpie";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "GitPie";
            this.Text = "GitPie";
            this.Load += new System.EventHandler(this.formUpie_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_load;
    }
}

