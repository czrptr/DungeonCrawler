// -----------------------------------------------------------------------
// <copyright file="DCMenuButtonControl.cs">
//     Copyright (c) Cezar Petriuc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace DungeonCrawler.CustomControls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    using DungeonCrawler.Graphix;
    using DungeonCrawler.Properties;

    /// <summary>
    ///     Represents a custom <seealso cref="Button" /> type control.
    /// </summary>
    [ToolboxBitmap(typeof(Button))]  
    public sealed class DCMenuButtonControl : Control
    {
        #region Fields

        // A Rectangle that stores the dimensions used to cut the border image
        private readonly Rectangle _borderDimensions;

        // A StringFormat used to draw the Text property
        private readonly StringFormat _textFormat;

        // A ImageAttributes instance used when drawing the custom border
        private readonly ImageAttributes _imgAtt;

        // A Bitmap that stores the Image used to draw the custom border
        private Bitmap _borderImage;

        // A SolidBrush used to draw aditional details
        private SolidBrush _highlightBrush;

        // A struct that stores the Text alignment
        private ContentAlignment _textAlign;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DCMenuButtonControl" /> class.
        /// </summary>
        public DCMenuButtonControl()
        {
            // Initializing fields to their default value
            _borderImage = Resources.Button_Menu;
            _borderDimensions = new Rectangle(3, 3, 1, 1);
            _highlightBrush = new SolidBrush(Color.FromArgb(89, 172, 255));
            _textAlign = ContentAlignment.MiddleCenter;
            _textFormat = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            _imgAtt = new ImageAttributes();
            _imgAtt.SetWrapMode(WrapMode.Tile);

            // Setting Style optimized for user drawn controls
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);

            // Setting BackColor optimized for user drawn controls
            BackColor = Color.Transparent;

            // Setting BackgroundImageLayout to new default value
            BackgroundImageLayout = ImageLayout.Center;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the alignment of the text on the button control.
        /// </summary>
        [Category("Appearance")]
        [Description("The alignment of the text that will be displayed on the control.")]
        [DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public ContentAlignment TextAlign
        {
            get => _textAlign;
            set
            {
                _textAlign = value;
                var num = (int)Math.Log((double)value, 2);
                _textFormat.LineAlignment = (StringAlignment)(num / 4);
                _textFormat.Alignment = (StringAlignment)(num % 4);
                Refresh();
            }
        }

        /// <inheritdoc />
        [DefaultValue(typeof(ImageLayout), "Center")]
        public override ImageLayout BackgroundImageLayout
        {
            get => base.BackgroundImageLayout;
            set => base.BackgroundImageLayout = value;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _borderImage = Resources.Button_Menu_Hover;
            _highlightBrush = new SolidBrush(Color.FromArgb(156, 210, 255));
            Refresh();
        }

        /// <inheritdoc />
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _borderImage = Resources.Button_Menu;
            _highlightBrush = new SolidBrush(Color.FromArgb(89, 172, 255));
            Refresh();
        }


        /// <inheritdoc />
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Invoking Control background painting event
            base.OnPaintBackground(pevent);

            // Painting the button using the custom border image
            pevent.Graphics.FillCustomBorder(_borderImage, DisplayRectangle, _borderDimensions);

            // Painting other details
            pevent.Graphics.FillRectangle(_highlightBrush, 3, 3, DisplayRectangle.Width - 6,
                DisplayRectangle.Height / 2 - 4);

            // Painting the BackgroundImage
            if (BackgroundImage != null)
                if (BackgroundImageLayout == ImageLayout.Center)
                    pevent.Graphics.DrawImage(BackgroundImage, (DisplayRectangle.Width - BackgroundImage.Width) / 2,
                        (DisplayRectangle.Height - BackgroundImage.Height) / 2);
                else if (BackgroundImageLayout == ImageLayout.None)
                    pevent.Graphics.DrawImage(BackgroundImage, 0, 0);
                else if (BackgroundImageLayout == ImageLayout.Stretch)
                    pevent.Graphics.DrawImage(BackgroundImage, DisplayRectangle, 0, 0, BackgroundImage.Width,
                        BackgroundImage.Height, GraphicsUnit.Pixel, _imgAtt);
        }

        /// <inheritdoc />
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), DisplayRectangle, _textFormat);
        }

        #endregion
    }
}