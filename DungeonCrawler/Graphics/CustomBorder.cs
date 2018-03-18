using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DungeonCrawler.Graphix
{
    class CustomBorder
    {
        public CustomBorder(CustomBorderDimensions dimensions)
        {
            Dimensions = dimensions;
            Corners = new Bitmap[4];
            Corners[0] = new Bitmap(Dimensions.V1Size, Dimensions.H1Size);
            Corners[1] = new Bitmap(Dimensions.V3Size, Dimensions.H1Size);
            Corners[2] = new Bitmap(Dimensions.V3Size, Dimensions.H3Size);
            Corners[3] = new Bitmap(Dimensions.V1Size, Dimensions.H3Size);
            Edges = new Bitmap[4];
            Edges[0] = new Bitmap(Dimensions.V2Size, Dimensions.H1Size);
            Edges[1] = new Bitmap(Dimensions.V3Size, Dimensions.H2Size);
            Edges[2] = new Bitmap(Dimensions.V2Size, Dimensions.H3Size);
            Edges[3] = new Bitmap(Dimensions.V1Size, Dimensions.H2Size);
            Fill = new Bitmap(Dimensions.V2Size, Dimensions.H2Size);
        }

        public Bitmap[] Corners { get; set; }
        public Bitmap[] Edges { get; set; }
        public Bitmap Fill { get; set; }
        public CustomBorderDimensions Dimensions { get; set; }

        public static CustomBorder FromFile(string filePath, CustomBorderDimensions dimensions)
        {
            return FromImage(Image.FromFile(filePath), dimensions);
        }

        public static CustomBorder FromImage(Image image, CustomBorderDimensions dimensions)
        {
            CustomBorder newBorder = new CustomBorder(dimensions);
            System.Drawing.Graphics cutter;
            cutter = Graphics.FromImage(newBorder.Corners[0]);
            cutter.DrawImage(image, 0, 0);
            cutter = Graphics.FromImage(newBorder.Corners[1]);
            cutter.DrawImage(image, -dimensions.V1Size - dimensions.V2Size, 0);
            cutter = Graphics.FromImage(newBorder.Corners[2]);
            cutter.DrawImage(image, -dimensions.V1Size - dimensions.V2Size, -dimensions.H1Size - dimensions.H2Size);
            cutter = Graphics.FromImage(newBorder.Corners[3]);
            cutter.DrawImage(image, 0, -dimensions.H1Size - dimensions.H2Size);

            cutter = Graphics.FromImage(newBorder.Edges[0]);
            cutter.DrawImage(image, -dimensions.V1Size, 0);
            cutter = Graphics.FromImage(newBorder.Edges[1]);
            cutter.DrawImage(image, -dimensions.V1Size - dimensions.V2Size, -dimensions.H1Size);
            cutter = Graphics.FromImage(newBorder.Edges[2]);
            cutter.DrawImage(image, -dimensions.V1Size, -dimensions.H1Size - dimensions.H2Size);
            cutter = Graphics.FromImage(newBorder.Edges[3]);
            cutter.DrawImage(image, 0, -dimensions.H1Size);

            cutter = Graphics.FromImage(newBorder.Fill);
            cutter.DrawImage(image, -dimensions.V1Size, -dimensions.H1Size);
            return newBorder;
        }
    }
}
