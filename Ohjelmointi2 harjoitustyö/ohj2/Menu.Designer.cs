namespace Ristinolla
{
    partial class Menu
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
            this.MenuYksipeliNappi = new System.Windows.Forms.Button();
            this.MenuKaksinpeliNappi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MenuYksipeliNappi
            // 
            this.MenuYksipeliNappi.Location = new System.Drawing.Point(137, 173);
            this.MenuYksipeliNappi.Name = "MenuYksipeliNappi";
            this.MenuYksipeliNappi.Size = new System.Drawing.Size(75, 23);
            this.MenuYksipeliNappi.TabIndex = 0;
            this.MenuYksipeliNappi.Text = "Yksinpeli";
            this.MenuYksipeliNappi.UseVisualStyleBackColor = true;
            this.MenuYksipeliNappi.Click += new System.EventHandler(this.Button1_Click);
            // 
            // MenuKaksinpeliNappi
            // 
            this.MenuKaksinpeliNappi.Location = new System.Drawing.Point(570, 172);
            this.MenuKaksinpeliNappi.Name = "MenuKaksinpeliNappi";
            this.MenuKaksinpeliNappi.Size = new System.Drawing.Size(75, 23);
            this.MenuKaksinpeliNappi.TabIndex = 1;
            this.MenuKaksinpeliNappi.Text = "Kaksinpeli";
            this.MenuKaksinpeliNappi.UseVisualStyleBackColor = true;
            this.MenuKaksinpeliNappi.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MenuKaksinpeliNappi);
            this.Controls.Add(this.MenuYksipeliNappi);
            this.Name = "Menu";
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MenuYksipeliNappi;
        private System.Windows.Forms.Button MenuKaksinpeliNappi;
    }
}