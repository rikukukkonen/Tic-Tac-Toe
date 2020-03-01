namespace Ristinolla
{
    partial class TietokonePeli
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
            this.TietokoneLauta = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // TietokoneLauta
            // 
            this.TietokoneLauta.Location = new System.Drawing.Point(114, 12);
            this.TietokoneLauta.Name = "TietokoneLauta";
            this.TietokoneLauta.Size = new System.Drawing.Size(600, 600);
            this.TietokoneLauta.TabIndex = 0;
            this.TietokoneLauta.Click += new System.EventHandler(this.TietokoneLauta_Click);
            this.TietokoneLauta.Paint += new System.Windows.Forms.PaintEventHandler(this.TietokoneLauta_Paint);
            // 
            // TietokonePeli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 673);
            this.Controls.Add(this.TietokoneLauta);
            this.Name = "TietokonePeli";
            this.Text = "TietokonePeli";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TietokonePeli_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TietokoneLauta;
    }
}