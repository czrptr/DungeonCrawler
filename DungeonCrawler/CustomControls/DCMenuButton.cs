//-----------------------------------------------------------------------
// <copyright file="DCMenuButton.cs">
//     Copyright (c) Cezar Petriuc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DungeonCrawler.CustomControls
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    using DungeonCrawler.Graphix;

    /// <summary>
    /// Represents a custom <seealso cref="Button"/> control.
    /// </summary>
    internal class DCMenuButton : Button
    {
        #region Fields

        // A Bitmap that stores the Image used to draw the custom border
        private Bitmap borderImage;

        // A Rectangle that stores the dimensions used to cut the border image
        private Rectangle borderDimensions;

        // A SolidBrush used to draw aditional details
        private SolidBrush highlightBrush;

        // A StringFormat used to draw the Text property
        private StringFormat textFormat;

        // A ImageAttributes instance used when drawing the custom border
        private ImageAttributes imgAtt;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DCMenuButton" /> class.
        /// </summary>
        public DCMenuButton() : base()
        {
            // Initializing fields to their default value
            this.borderImage = Properties.Resources.Button_Menu;
            this.borderDimensions = new Rectangle(3, 3, 1, 1);
            this.highlightBrush = new SolidBrush(Color.FromArgb(89, 172, 255));
            this.textFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            this.imgAtt = new ImageAttributes();
            this.imgAtt.SetWrapMode(WrapMode.Tile);

            // Setting Style optimized for user drawn controls
            this.SetStyle(ControlStyles.AllPaintingInWmPaint  |
                          ControlStyles.DoubleBuffer          |
                          ControlStyles.UserPaint             |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw, true);

            // Setting FlatStyle and FlatAppearance optimized for user drawn controls
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.CheckedBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;

            // Setting BackColor optimized for user drawn controls
            this.BackColor = Color.Transparent;

            // Setting BackgroundImageLayout to new default value
            this.BackgroundImageLayout = ImageLayout.Center;
        }

        // Changing the way Button looks when mouse begins hovering
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.borderImage = Properties.Resources.Button_Menu_Hover;
            this.highlightBrush = new SolidBrush(Color.FromArgb(156, 210, 255));
            this.Refresh();
        }

        // Changing the way Button looks when mouse stops hovering
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.borderImage = Properties.Resources.Button_Menu;
            this.highlightBrush = new SolidBrush(Color.FromArgb(89, 172, 255));
            this.Refresh();
        }

        // Changing the way the Button looks
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*", Justification = "Reviewed. Suppression is OK here.")]
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillCustomBorder(borderImage, DisplayRectangle, borderDimensions);
            e.Graphics.FillRectangle(highlightBrush, 3, 3, DisplayRectangle.Width - 6, (DisplayRectangle.Height / 2) - 4);

            if (BackgroundImage != null)
            {
                if (BackgroundImageLayout == ImageLayout.Center)
                {
                    e.Graphics.DrawImage(BackgroundImage, (DisplayRectangle.Width - BackgroundImage.Width) / 2, (DisplayRectangle.Height - BackgroundImage.Height) / 2);
                }
                else if (BackgroundImageLayout == ImageLayout.None)
                {
                    e.Graphics.DrawImage(BackgroundImage, 0, 0);
                }
                else if (BackgroundImageLayout == ImageLayout.Stretch)
                {
                    e.Graphics.DrawImage(BackgroundImage, DisplayRectangle, 0, 0, BackgroundImage.Width, BackgroundImage.Height, GraphicsUnit.Pixel, imgAtt);
                }
            }

            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), DisplayRectangle, textFormat);
        }
    }
}
