using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using DungeonCrawler.Graphix;

namespace DungeonCrawler.CustomControls
{
    class MenuTableLayoutPanel : TableLayoutPanel
    {
        public MenuTableLayoutPanel() : base()
        {
            // Set style optimized for user drawn controls
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillCustomBorder(Properties.Resources.Panel_Menu, DisplayRectangle, new Rectangle(3, 10, 1, 1));
        }
    }
}
