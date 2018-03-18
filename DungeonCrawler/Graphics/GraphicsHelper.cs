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
            // Drawing each corner (from top-left counterclockwise)
            graphics.DrawImage(customBorder[0, 0], rect.Left, rect.Top);
            graphics.DrawImage(customBorder[0, 1], rect.Left + rect.Width - customBorder.VSize(3), rect.Top);
            graphics.DrawImage(customBorder[0, 2], rect.Left + rect.Width - customBorder.VSize(3), rect.Top + rect.Height - customBorder.HSize(3));
            graphics.DrawImage(customBorder[0, 3], rect.Left, rect.Top + rect.Height - customBorder.HSize(3));

            // Initialize WrapMode for drawing the edges and fill
            ImageAttributes imgAtt = new ImageAttributes();
            imgAtt.SetWrapMode(WrapMode.Tile);

            /* Drawing each border (from top counterclockwise) */

            // Create a rectagle reprezenting the portion in witch the border will be drawn
            Rectangle edgeRect = new Rectangle(rect.Left + customBorder.VSize(1), rect.Top, rect.Width - customBorder.VSize(1) - customBorder.VSize(3), customBorder.HSize(1));
            // Fill that rectangle with the edge sprite
            graphics.DrawImage(customBorder[1, 0], edgeRect, 0, 0, edgeRect.Width, edgeRect.Height, GraphicsUnit.Pixel, imgAtt);

            // Repeat for each edge
            edgeRect.Y += rect.Height - customBorder.HSize(3);
            graphics.DrawImage(customBorder[1, 2], edgeRect, 0, 0, edgeRect.Width, edgeRect.Height, GraphicsUnit.Pixel, imgAtt);

            edgeRect = new Rectangle(rect.Left, rect.Top + customBorder.HSize(1), customBorder.VSize(1), rect.Height - customBorder.HSize(1) - customBorder.HSize(3));
            graphics.DrawImage(customBorder[1, 3], edgeRect, 0, 0, edgeRect.Width, edgeRect.Height, GraphicsUnit.Pixel, imgAtt);

            edgeRect.X += rect.Width - customBorder.VSize(3);
            graphics.DrawImage(customBorder[1, 1], edgeRect, 0, 0, edgeRect.Width, edgeRect.Height, GraphicsUnit.Pixel, imgAtt);

            // Fill middle with CustomBorder.Fill
            edgeRect = new Rectangle(rect.Left + customBorder.VSize(1), rect.Top + customBorder.HSize(1),
                rect.Width - customBorder.VSize(1) - customBorder.VSize(3), rect.Height - customBorder.HSize(1) - customBorder.HSize(3));
            graphics.DrawImage(customBorder.Body, edgeRect, 0, 0, edgeRect.Width, edgeRect.Height, GraphicsUnit.Pixel, imgAtt);
        }

        public static void DrawCustomBorder(this Graphics graphics, CustomBorder customBorder, int x, int y, int width, int height)
        {
            DrawCustomBorder(graphics, customBorder, new Rectangle(x, y, width, height));
        }
    }
}
