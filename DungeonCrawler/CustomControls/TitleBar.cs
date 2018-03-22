using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DungeonCrawler.Graphix;

namespace DungeonCrawler.CustomControls
{
    public partial class TitleBar : UserControl
    {
        private bool _mouseDown = false;
        private Point clickLocation;

        private Bitmap borderImg = Properties.Resources.Titlebar;
        private Rectangle borderDim = new Rectangle(3, 9, 1, 1);

        public TitleBar()
        {
            InitializeComponent();
            //MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, 30);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillCustomBorder(borderImg, DisplayRectangle, borderDim);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _mouseDown = true;
            clickLocation = e.Location;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _mouseDown = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_mouseDown)
                Parent.Location = new Point(Parent.Location.X - clickLocation.X + e.Location.X, Parent.Location.Y - clickLocation.Y + e.Location.Y);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            ((Form)Parent).WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
