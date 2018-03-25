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
            this.button1 = new System.Windows.Forms.Button();
            this.dcMenuButtonControl1 = new DungeonCrawler.CustomControls.DCMenuButtonControl();
            this.dcMenuButtonControl2 = new DungeonCrawler.CustomControls.DCMenuButtonControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dcMenuButtonControl1
            // 
            this.dcMenuButtonControl1.BackColor = System.Drawing.Color.Transparent;
            this.dcMenuButtonControl1.Location = new System.Drawing.Point(253, 118);
            this.dcMenuButtonControl1.Name = "dcMenuButtonControl1";
            this.dcMenuButtonControl1.Size = new System.Drawing.Size(109, 70);
            this.dcMenuButtonControl1.TabIndex = 5;
            this.dcMenuButtonControl1.Text = "dcMenuButtonControl1";
            // 
            // dcMenuButtonControl2
            // 
            this.dcMenuButtonControl2.BackColor = System.Drawing.Color.Transparent;
            this.dcMenuButtonControl2.Location = new System.Drawing.Point(339, 151);
            this.dcMenuButtonControl2.Name = "dcMenuButtonControl2";
            this.dcMenuButtonControl2.Size = new System.Drawing.Size(121, 60);
            this.dcMenuButtonControl2.TabIndex = 6;
            this.dcMenuButtonControl2.Text = "dcMenuButtonControl2";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(558, 367);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dcMenuButtonControl2);
            this.Controls.Add(this.dcMenuButtonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Controls.SetChildIndex(this.dcMenuButtonControl1, 0);
            this.Controls.SetChildIndex(this.dcMenuButtonControl2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private CustomControls.DCMenuButtonControl dcMenuButtonControl1;
        private CustomControls.DCMenuButtonControl dcMenuButtonControl2;
    }
}