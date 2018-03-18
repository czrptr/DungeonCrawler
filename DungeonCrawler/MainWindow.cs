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

            e.Graphics.DrawCustomBorder(customBorder, 3, 5, 250, 220);
        }
    }
}
