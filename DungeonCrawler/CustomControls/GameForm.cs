// -----------------------------------------------------------------------
// <copyright file="GameForm.cs">
//     Copyright (c) Cezar Petriuc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace DungeonCrawler.CustomControls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using DungeonCrawler.Graphix;
    using DungeonCrawler.Properties;

    /// <summary>
    ///     Represent a custom <seealso cref="Form" /> that makes up an application's user interface.
    /// </summary>
    public partial class GameForm : Form
    {
        #region Fields

        // Flag used to keep track of current mouse state
        private bool _mouseDown;

        // Point used for calculating the Forms new position when moves
        private Point _clickLocation;

        // Used for storing the custom border image, dimensions and display area for the titlebar
        private Bitmap _titleImage;
        private Rectangle _titleBorderDimensions;
        private Rectangle _titleDisplayRectangle;

        // Used for storing the custom border image, dimensions and display area for the background
        private Bitmap _backgroundImage;
        private Rectangle _backgroundImageDimensions;
        private Rectangle _backgroundDisplayRectangle;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameForm" /> class.
        /// </summary>
        public GameForm()
        {
            // Initializing fields to their default value
            _mouseDown = false;
            _clickLocation = new Point(0, 0);

            _titleImage = Resources.Titlebar_Background;
            _titleBorderDimensions = new Rectangle(3, 10, 1, 1);
            _titleDisplayRectangle = new Rectangle(0, 0, Width, 30);

            _backgroundImage = Resources.Form_Background;
            _backgroundImageDimensions = new Rectangle(12, 11, 1, 1);
            _backgroundDisplayRectangle = new Rectangle(0, 30, Width, Height - 30);

            // Set style optimized for user drawn controls
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            // Initializing child controls
            InitializeComponent();
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            // Updating DisplatRectangles of titlebar and background
            _titleDisplayRectangle.Width = Width;
            _backgroundDisplayRectangle.Width = Width;
            _backgroundDisplayRectangle.Height = Height - 30;
        }

        /// <inheritdoc />
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Invoking Form background painting event
            base.OnPaintBackground(e);

            // Painting the title bar using the custom titlebar image
            e.Graphics.FillCustomBorder(_titleImage, _titleDisplayRectangle, _titleBorderDimensions);

            // Painting the background using the custom background image
            e.Graphics.DrawCustomBorder(_backgroundImage, _backgroundDisplayRectangle, _backgroundImageDimensions);

            // Painting areas tha need to be transparent
            e.Graphics.FillPixel(Brushes.DarkViolet, 0, 0);
            e.Graphics.FillPixel(Brushes.DarkViolet, DisplayRectangle.Width - 1, 0);
            e.Graphics.FillPixel(Brushes.DarkViolet, DisplayRectangle.Width - 1, DisplayRectangle.Height - 1);
            e.Graphics.FillPixel(Brushes.DarkViolet, 0, DisplayRectangle.Height - 1);
        }

        /// <inheritdoc />
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // If click is located on the titlebar
            if (e.Y <= 30)
            {
                _mouseDown = true;
                _clickLocation = e.Location;
            }
        }

        /// <inheritdoc />
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _mouseDown = false;
        }

        /// <inheritdoc />
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_mouseDown)
                Location = new Point(Location.X - _clickLocation.X + e.X, Location.Y - _clickLocation.Y + e.Y);
        }

        // Minimizing form
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Closing program
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}