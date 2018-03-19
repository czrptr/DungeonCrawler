using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using DungeonCrawler.Graphix;
using System.ComponentModel;
using System.Diagnostics;

namespace DungeonCrawler.CustomControls
{
    class CustomButton : Button
    {
        private Image _borderImage = Properties.Resources.Button_Menus;
        private CustomBorderDimensions _borderDimensions = new CustomBorderDimensions(3, 1);
        private CustomBorder _border;

        [Category("Custom")]
        [Description("The color of the button.")]
        public Color ButtonColor { get; set; }

        [Category("Custom")]
        [Description("The color of the button border.")]
        public Color BorderColor { get; set; }

        [Category("Custom")]
        [Description("The Image used to generate the border.")]
        public Image BorderImage
        {
            get => _borderImage;
            set
            {
                _borderImage = value;
                _border = CustomBorder.FromImage(_borderImage, _borderDimensions);
            }
        }

        [Category("Custom")]
        [Description("The dimensions of the border.")]
        public CustomBorderDimensions BorderDimensions
        {
            //get => _borderDimensions;
            set
            {
                _borderDimensions = value;
                _border = CustomBorder.FromImage(_borderImage, _borderDimensions);
            }
        }

        public CustomButton() : base()
        {
            // Set style optimized for user drawn controls
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);
            // Set FlatStyle that looks better when drawn over
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;

            // Set default Colors. Inferit BorderColor from parent
            ButtonColor = Color.Transparent;
            BorderColor = BackColor;
            BackColor = Color.Transparent;

            // Set default look to Menu Button
            _border = CustomBorder.FromImage(_borderImage, _borderDimensions);
        }

        // Drawing custom border
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillCustomBorder(_border, DisplayRectangle);
        }
    }
}
