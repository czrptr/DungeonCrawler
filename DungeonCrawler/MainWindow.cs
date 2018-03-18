using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using DungeonCrawler.Graphix;
using DungeonCrawler.CustomControls;

namespace DungeonCrawler
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            CustomBorderDimensions dimensions = new CustomBorderDimensions(3, 1);
            CustomBorder customBorder = CustomBorder.FromImage(Properties.Resources.Button_Menus, dimensions);

            /*
            e.Graphics.DrawImage(customBorder.Corners[0], 0, 0);
            e.Graphics.DrawImage(customBorder.Corners[1], 4, 0);
            e.Graphics.DrawImage(customBorder.Corners[2], 8, 0);
            e.Graphics.DrawImage(customBorder.Corners[3], 12, 0);

            e.Graphics.DrawImage(customBorder.Edges[0], 16, 0);
            e.Graphics.DrawImage(customBorder.Edges[1], 20, 0);
            e.Graphics.DrawImage(customBorder.Edges[2], 24, 0);
            e.Graphics.DrawImage(customBorder.Edges[3], 28, 0);

            e.Gra☺phics.DrawImage(customBorder.Fill, 32, 0);
            */

            /*
            ImageAttributes imgAtt = new ImageAttributes();
            imgAtt.SetWrapMode(WrapMode.TileFlipXY);

            Rectangle r = new Rectangle(5, 5, 200, 100);
            e.Graphics.DrawImage(Properties.Resources.Button_Menus, r, 0, 0, 200, 100, GraphicsUnit.Pixel, imgAtt);
            */
            e.Graphics.DrawCustomBorder(customBorder, 3, 5, 250, 220);
        }
    }
}
