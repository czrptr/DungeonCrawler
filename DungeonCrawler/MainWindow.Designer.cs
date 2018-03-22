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
            this.btnTest = new DungeonCrawler.CustomControls.DCMenuButton();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.Transparent;
            this.btnTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTest.FlatAppearance.BorderSize = 0;
            this.btnTest.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Location = new System.Drawing.Point(141, 178);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(259, 105);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "test";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(556, 399);
            this.Controls.Add(this.btnTest);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Controls.SetChildIndex(this.btnTest, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.DCMenuButton btnTest;
    }
}