using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DungeonCrawler.Graphix;
using DungeonCrawler.CustomControls;

namespace DungeonCrawler
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            // Set style optimized for user drawn controls
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(Pens.Black, 0, 4, 0, DisplayRectangle.Height - 2);
            e.Graphics.DrawLine(Pens.Black, DisplayRectangle.Width - 1 , 4, DisplayRectangle.Width - 1, DisplayRectangle.Height - 2);
            e.Graphics.DrawLine(Pens.Black, 1, DisplayRectangle.Height - 1, DisplayRectangle.Width - 2, DisplayRectangle.Height - 1);
            e.Graphics.FillPixel(Brushes.DarkViolet, 0, DisplayRectangle.Height - 1);
            e.Graphics.FillPixel(Brushes.DarkViolet, DisplayRectangle.Width - 1, DisplayRectangle.Height - 1);
        }
    }
}
