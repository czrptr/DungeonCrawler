using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using DungeonCrawler.Graphix;

namespace DungeonCrawler.Graphix
{
    static class GraphicsHelper
    {
        static void FillPixel(this Graphics graphics, Brush brush, int x, int y)
        {
            graphics.FillRectangle(brush, x, y, 1, 1);
        }

        public static void DrawCustomBorder(this Graphics graphics, CustomBorder customBorder, Rectangle rect)
        {
            graphics.DrawImage(customBorder.Corners[0], rect.Left, rect.Top);
            graphics.DrawImage(customBorder.Corners[1], rect.Left + rect.Width - customBorder.Dimensions.V3Size, rect.Top);
            graphics.DrawImage(customBorder.Corners[2], rect.Left + rect.Width - customBorder.Dimensions.V3Size, rect.Top + rect.Height - customBorder.Dimensions.H3Size);
            graphics.DrawImage(customBorder.Corners[3], rect.Left, rect.Top + rect.Height - customBorder.Dimensions.H3Size);

            ImageAttributes imgAtt = new ImageAttributes();
            imgAtt.SetWrapMode(WrapMode.Tile);

            Bitmap edge = new Bitmap(rect.Width - customBorder.Dimensions.V1Size - customBorder.Dimensions.V3Size, customBorder.Dimensions.H1Size);
            Rectangle edgeRect = new Rectangle(0, 0, edge.Width, edge.Height);
            edge.SetResolution(customBorder.Edges[0].HorizontalResolution, customBorder.Edges[0].VerticalResolution);
            Graphics.FromImage(edge).DrawImage(customBorder.Edges[0], edgeRect, 0, 0, edge.Width, edge.Height, GraphicsUnit.Pixel, imgAtt);
            graphics.DrawImage(edge, rect.Left + customBorder.Dimensions.V1Size, rect.Top);

            edge = new Bitmap(rect.Width - customBorder.Dimensions.V1Size - customBorder.Dimensions.V3Size, customBorder.Dimensions.H3Size);
            edgeRect = new Rectangle(0, 0, edge.Width, edge.Height);
            Graphics.FromImage(edge).DrawImage(customBorder.Edges[2], edgeRect, 0, 0, edge.Width, edge.Height, GraphicsUnit.Pixel, imgAtt);
            graphics.DrawImage(edge, rect.Left + customBorder.Dimensions.V1Size, rect.Top + rect.Height - customBorder.Dimensions.H3Size);

            
            edge = new Bitmap(customBorder.Dimensions.V1Size, rect.Height - customBorder.Dimensions.H1Size - customBorder.Dimensions.H3Size);
            edgeRect = new Rectangle(0, 0, edge.Width, edge.Height);
            Graphics.FromImage(edge).DrawImage(customBorder.Edges[3], edgeRect, 0, 0, edge.Width, edge.Height, GraphicsUnit.Pixel, imgAtt);
            graphics.DrawImage(edge, rect.Left, rect.Top + customBorder.Dimensions.H1Size);

            edge = new Bitmap(customBorder.Dimensions.V3Size, rect.Height - customBorder.Dimensions.H1Size - customBorder.Dimensions.H3Size);
            edgeRect = new Rectangle(0, 0, edge.Width, edge.Height);
            Graphics.FromImage(edge).DrawImage(customBorder.Edges[1], edgeRect, 0, 0, edge.Width, edge.Height, GraphicsUnit.Pixel, imgAtt);
            graphics.DrawImage(edge, rect.Left + rect.Width - customBorder.Dimensions.V3Size, rect.Top + customBorder.Dimensions.H1Size);

            edge = new Bitmap(rect.Width - customBorder.Dimensions.V1Size - customBorder.Dimensions.V3Size, rect.Height - customBorder.Dimensions.H1Size - customBorder.Dimensions.H3Size);
            edgeRect = new Rectangle(0, 0, edge.Width, edge.Height);
            Graphics.FromImage(edge).DrawImage(customBorder.Fill, edgeRect, 0, 0, edge.Width, edge.Height, GraphicsUnit.Pixel, imgAtt);
            graphics.DrawImage(edge, rect.Left + customBorder.Dimensions.V1Size, rect.Top + customBorder.Dimensions.H1Size);
        }

        public static void DrawCustomBorder(this Graphics graphics, CustomBorder customBorder, int x, int y, int width, int height)
        {
            DrawCustomBorder(graphics, customBorder, new Rectangle(x, y, width, height));
        }
    }
}
