using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DungeonCrawler.Graphix;
using System.ComponentModel;
using System.Diagnostics;
using DungeonCrawler.Properties;

namespace DungeonCrawler.CustomControls
{
    class MenuButton : Control
    {
        private Bitmap look = Properties.Resources.Button_Menu;
        private Rectangle borderDimensions = new Rectangle(3, 3, 1, 1);
        private SolidBrush bodyHighlight = new SolidBrush(Color.FromArgb(89, 172, 255));
        private StringFormat sf = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        private ImageAttributes imgAtt = new ImageAttributes();

        public MenuButton() : base()
        {
            // Set style optimized for user drawn controls
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            imgAtt.SetWrapMode(WrapMode.Tile);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            look = Properties.Resources.Button_Menu_Hover;
            bodyHighlight = new SolidBrush(Color.FromArgb(156, 210, 255));
            Refresh();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            look = Properties.Resources.Button_Menu;
            bodyHighlight = new SolidBrush(Color.FromArgb(89, 172, 255));
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;
            e.Graphics.FillCustomBorder(look, DisplayRectangle, borderDimensions);
            e.Graphics.FillRectangle(bodyHighlight, 3, 3, DisplayRectangle.Width - 6, DisplayRectangle.Height / 2 - 4);

            if(BackgroundImage != null)
            {
                if (BackgroundImageLayout == ImageLayout.Center)
                    e.Graphics.DrawImage(BackgroundImage, (DisplayRectangle.Width - BackgroundImage.Width) / 2, (DisplayRectangle.Height - BackgroundImage.Height) / 2);
                else if (BackgroundImageLayout == ImageLayout.None)
                    e.Graphics.DrawImage(BackgroundImage, 0, 0);
                else if (BackgroundImageLayout == ImageLayout.Stretch)
                    e.Graphics.DrawImage(BackgroundImage, DisplayRectangle, 0, 0, BackgroundImage.Width, BackgroundImage.Height, GraphicsUnit.Pixel, imgAtt);
            }

            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), DisplayRectangle, sf);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            pevent.Graphics.FillRectangle(new SolidBrush(BackColor), DisplayRectangle);
        }
    }
}
