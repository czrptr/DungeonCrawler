using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DungeonCrawler.CustomControls
{
    class CustomButton : Button
    {
        public Color ButtonColor { get; set; }
        public Color BorderColor { get; set; }

        public CustomButton() : base()
        {
            // Set style optimized for user drawn controls
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            // Set FlatStyle that looks better when drawn over
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;

            // Set default Colors. Inferit BorderColor from parent
            ButtonColor = Color.Transparent;
            BorderColor = BackColor;
            BackColor = Color.Transparent;

            // Set custom draw
            Paint += new PaintEventHandler(CustomButton_Paint);
        }

        private void CustomButton_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
