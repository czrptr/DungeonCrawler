namespace DungeonCrawler
{
    partial class MainWindow
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
            this.menuButton1 = new DungeonCrawler.CustomControls.MenuButton();
            this.SuspendLayout();
            // 
            // menuButton1
            // 
            this.menuButton1.BackColor = System.Drawing.Color.Transparent;
            this.menuButton1.BodyColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.menuButton1.FlatAppearance.BorderSize = 0;
            this.menuButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton1.Location = new System.Drawing.Point(135, 163);
            this.menuButton1.Name = "menuButton1";
            this.menuButton1.OverlayTransparency = ((byte)(0));
            this.menuButton1.Size = new System.Drawing.Size(109, 62);
            this.menuButton1.TabIndex = 0;
            this.menuButton1.Text = "menuButton1";
            this.menuButton1.UseVisualStyleBackColor = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(391, 327);
            this.Controls.Add(this.menuButton1);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Window";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.MenuButton menuButton1;
    }
}

