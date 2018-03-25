// //-----------------------------------------------------------------------------
// // <copyright file="DCForm.cs">
// //     Copyright (c) Cezar Petriuc. All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------------

namespace DungeonCrawler.CustomControls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using DungeonCrawler.Graphix;
    using DungeonCrawler.Properties;

    public partial class DCForm : Form
    {
        #region Fields

        private bool _mouseDown;
        private Point clickLocation;

        private readonly Bitmap titleImg = Resources.Titlebar_Background;
        private readonly Rectangle titleImgCut = new Rectangle(3, 10, 1, 1);
        private Rectangle titleImgDisplay;

        private readonly Bitmap backImg = Resources.Form_Background;
        private readonly Rectangle backImgCut = new Rectangle(12, 11, 1, 1);
        private Rectangle backImgDisplay;

        #endregion

        #region Constructors

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

        #endregion

        #region Methods

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

        #endregion
    }
}