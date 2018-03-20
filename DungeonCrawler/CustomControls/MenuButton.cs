using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DungeonCrawler.Graphix;
using System.ComponentModel;
using System.Diagnostics;
using DungeonCrawler.Properties;

namespace DungeonCrawler.CustomControls
{
    class MenuButton : Button
    {
        /* Usefull for more customizable buttons
        [Category("Custom"),
         Description("The image that will be used to draw the Custom button.")]
        public Image Look { get; set; } = Properties.Resources.Button_Default;

        [Category("Custom"),
         Description("The rectangle that defines the centre of the Look image.")]
        public Rectangle BorderDimensions { get; set; } = new Rectangle(1, 1, 1, 1);
        */

        private Bitmap look = Properties.Resources.Button_Menu;
        private Rectangle borderDim = new Rectangle(3, 3, 1, 1);
        private Bitmap bodyOverlay = Properties.Resources.Button_Menu_Body_Overlay;
        private SolidBrush bodyBrush, borderBrush;
        private Point[] bodyPoly = new Point[8], borderPath = new Point[8];
        private StringFormat sf = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        [Category("Custom"),
         Description("The transparecy of the overlay.")]
        public byte OverlayTransparency
        {
            get => bodyBrush.Color.A;
            set
            {
                bodyBrush.Color = Color.FromArgb(value, bodyBrush.Color);
            }
        }

        [Category("Custom"),
         Description("The color overlay of the button body.")]
        public Color BodyColor
        {
            get => Color.FromArgb(255, bodyBrush.Color);
            set => bodyBrush.Color = Color.FromArgb(OverlayTransparency, value);
        }

        [Category("Custom"),
         Description("The color overlay of the button edge.")]
        public Color BorderColor
        {
            get => Color.FromArgb(255, borderBrush.Color);
            set => borderBrush.Color = Color.FromArgb(100, value);
        }

        public MenuButton() : base()
        {
            sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
            // Set style optimized for user drawn controls
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            // Set FlatStyle that looks better when drawn over
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;

            // Set BorderColor to parent BackColor
            bodyBrush = new SolidBrush(Color.Transparent);
            borderBrush = new SolidBrush(Color.FromArgb(100, BackColor));
            BackColor = Color.Transparent;

            calculateBodyPoly();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            calculateBodyPoly();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            //pevent.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            pevent.Graphics.FillCustomBorder(look, DisplayRectangle, borderDim);
            pevent.Graphics.FillPolygon(bodyBrush, bodyPoly, FillMode.Winding);

            pevent.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), DisplayRectangle, sf);
        }

        private void calculateBodyPoly()
        {
            bodyPoly[0] = new Point(1, 3);
            bodyPoly[1] = new Point(3, 1);
            bodyPoly[2] = new Point(DisplayRectangle.Width - 3, 1);
            bodyPoly[3] = new Point(DisplayRectangle.Width - 1, 3);
            bodyPoly[4] = new Point(DisplayRectangle.Width - 1, DisplayRectangle.Height - 4);
            bodyPoly[5] = new Point(DisplayRectangle.Width - 4, DisplayRectangle.Height - 1);
            bodyPoly[6] = new Point(3, DisplayRectangle.Height - 1);
            bodyPoly[7] = new Point(1, DisplayRectangle.Height - 4);
        }

        private void calculateBorderPath()
        {
            borderPath[0] = new Point();
            borderPath[1] = new Point();
            borderPath[2] = new Point();
            borderPath[3] = new Point();
            borderPath[4] = new Point();
            borderPath[5] = new Point();
            borderPath[6] = new Point();
            borderPath[7] = new Point();
        }
    }
}
