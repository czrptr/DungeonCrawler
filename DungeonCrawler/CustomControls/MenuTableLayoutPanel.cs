// -----------------------------------------------------------------------
// <copyright file="MenuTableLayoutPanel.cs">
//     Copyright (c) Cezar Petriuc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace DungeonCrawler.CustomControls
{
    using System.Drawing;
    using System.Windows.Forms;
    using DungeonCrawler.Graphix;
    using DungeonCrawler.Properties;

    /// <summary>
    ///     A custom <seealso cref="MenuTableLayoutPanel" /> control.
    /// </summary>
    [ToolboxBitmap(typeof(TableLayoutPanel))]
    public sealed class MenuTableLayoutPanel : TableLayoutPanel
    {
        #region Fields

        // A Bitmap that stores the Image used to draw the custom border
        private Bitmap _borderImage;

        // A Rectangle that stores the dimensions used to cut the border image
        private Rectangle _borderDimensions;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MenuTableLayoutPanel" /> class.
        /// </summary>
        public MenuTableLayoutPanel()
        {
            // Initializing fields to their default value
            _borderImage = Resources.Panel_Menu;
            _borderDimensions = new Rectangle(3, 10, 1, 1);

            // Set style optimized for user drawn controls
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            // Setting BackColor optimized for user drawn controls
            BackColor = Color.Transparent;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.FillCustomBorder(_borderImage, DisplayRectangle, _borderDimensions);
        }

        #endregion
    }
}