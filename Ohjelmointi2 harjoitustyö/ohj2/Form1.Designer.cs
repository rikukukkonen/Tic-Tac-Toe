namespace Ristinolla
{
    partial class Ristinolla
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
            this.Lauta = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Lauta
            // 
            this.Lauta.BackColor = System.Drawing.Color.White;
            this.Lauta.Location = new System.Drawing.Point(114, 12);
            this.Lauta.Name = "Lauta";
            this.Lauta.Size = new System.Drawing.Size(600, 600);
            this.Lauta.TabIndex = 0;
            this.Lauta.Click += new System.EventHandler(this.Lauta_Click);
            this.Lauta.Paint += new System.Windows.Forms.PaintEventHandler(this.Lauta_Paint);
            // 
            // Ristinolla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 661);
            this.Controls.Add(this.Lauta);
            this.Name = "Ristinolla";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ristinolla_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Lauta;
    }
}

