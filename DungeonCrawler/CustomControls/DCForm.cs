using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DungeonCrawler.Graphix;

namespace DungeonCrawler.CustomControls
{
    public partial class DCForm : Form
    {
        private bool _mouseDown = false;
        private Point clickLocation;

        private Bitmap titleImg = Properties.Resources.Titlebar_Background;
        private Rectangle titleImgCut = new Rectangle(3, 10, 1, 1);
        private Rectangle titleImgDisplay;

        private Bitmap backImg = Properties.Resources.Form_Background;
        private Rectangle backImgCut = new Rectangle(12, 11, 1, 1);
        private Rectangle backImgDisplay;

        public DCForm()
        {
            // Set style optimized for user drawn controls
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            InitializeComponent();

            titleImgDisplay = new Rectangle(0, 0, Width, 30);
            backImgDisplay = new Rectangle(0, 30, Width, Height - 30);
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            clickLocation = e.Location;
        }

        private void pnlTitle_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void pnlTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
                Location = new Point(Location.X - clickLocation.X + e.X, Location.Y - clickLocation.Y + e.Y);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            titleImgDisplay.Width = Width;
            backImgDisplay = new Rectangle(0, 30, Width, Height - 30);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillCustomBorder(titleImg, titleImgDisplay, titleImgCut);
            e.Graphics.DrawCustomBorder(backImg, backImgDisplay, backImgCut);
            e.Graphics.FillPixel(Brushes.DarkViolet, 0, 0);
            e.Graphics.FillPixel(Brushes.DarkViolet, DisplayRectangle.Width - 1, 0);
            e.Graphics.FillPixel(Brushes.DarkViolet, DisplayRectangle.Width - 1, DisplayRectangle.Height - 1);
            e.Graphics.FillPixel(Brushes.DarkViolet, 0, DisplayRectangle.Height - 1);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            pnlTitle.Refresh();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlTitle_ControlAdded(object sender, ControlEventArgs e)
        {
            throw new Exception("Controls cannot be added to TitleBar");
        }
    }
}
