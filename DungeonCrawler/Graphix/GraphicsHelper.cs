using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace DungeonCrawler.Graphix
{
    public static class GraphicsHelper
    {
        public static void FillPixel(this Graphics graphics, Brush brush, int x, int y)
        {
            graphics.FillRectangle(brush, x, y, 1, 1);
        }

        //public static void Fill(this Graphics graphics, Brush brush);

        public static void FillCustomBorder(this Graphics graphics, Bitmap borderImage, Rectangle drawRect, Rectangle cutRect)
        {
            //graphics.FillRectangle(Brushes.LightGreen, drawRect);
            int leftX = borderImage.Width - cutRect.X - cutRect.Width;
            int bottomY = borderImage.Height - cutRect.Y - cutRect.Height;

            // Initialize WrapMode for drawing the edges and fill
            ImageAttributes imgAtt = new ImageAttributes();
            imgAtt.SetWrapMode(WrapMode.Tile);

            // Prepare new Rectangle for drawing slices
            Rectangle sliceRect;

            // Drawing each corner (from top-left counterclockwise)
            sliceRect = new Rectangle(drawRect.X, drawRect.Y, cutRect.X, cutRect.Y);
            graphics.DrawImage(borderImage, sliceRect, 0, 0, sliceRect.Width, sliceRect.Height, GraphicsUnit.Pixel, imgAtt);

            sliceRect = new Rectangle(drawRect.X + drawRect.Width - leftX, drawRect.Y, leftX, cutRect.Y);
            graphics.DrawImage(borderImage, sliceRect, cutRect.X + cutRect.Width, 0, sliceRect.Width, sliceRect.Height, GraphicsUnit.Pixel, imgAtt);

            sliceRect = new Rectangle(drawRect.X, drawRect.Y + drawRect.Height - bottomY, cutRect.X, bottomY);
            graphics.DrawImage(borderImage, sliceRect, 0, cutRect.Y + cutRect.Height, sliceRect.Width, sliceRect.Height, GraphicsUnit.Pixel, imgAtt);

            sliceRect = new Rectangle(drawRect.X + drawRect.Width - leftX, drawRect.Y + drawRect.Height - bottomY, leftX, bottomY);
            graphics.DrawImage(borderImage, sliceRect, cutRect.X + cutRect.Width, cutRect.Y + cutRect.Height, sliceRect.Width, sliceRect.Width, GraphicsUnit.Pixel, imgAtt);

            // Prepare new Bitmap for storing edge tiles
            // For some reason even if the sliceRect is perfet ti still doesn't draw correctly
            // It draws sliceRect.Width + 1
            // graphics.DrawImage(borderImage, sliceRect, cutRect.X, 0, cutRect.Width, cutRect.Y, GraphicsUnit.Pixel, imgAtt);
            Bitmap edgeSprite;

            // Drawing each border (from top counterclockwise)
            sliceRect = new Rectangle(drawRect.X + cutRect.X, drawRect.Y, drawRect.Width - cutRect.X - leftX, cutRect.Y);
            edgeSprite = new Bitmap(cutRect.Width, cutRect.Y);
            Graphics.FromImage(edgeSprite).DrawImage(borderImage, -cutRect.X, 0);
            graphics.DrawImage(edgeSprite, sliceRect, 0, 0, edgeSprite.Width, edgeSprite.Height, GraphicsUnit.Pixel, imgAtt);

            sliceRect.Y += drawRect.Height - bottomY;
            sliceRect.Height = bottomY;
            edgeSprite = new Bitmap(cutRect.Width, bottomY);
            Graphics.FromImage(edgeSprite).DrawImage(borderImage, -cutRect.X, -cutRect.Y - cutRect.Height);
            graphics.DrawImage(edgeSprite, sliceRect, 0, 0, edgeSprite.Width, edgeSprite.Height, GraphicsUnit.Pixel, imgAtt);

            sliceRect = new Rectangle(drawRect.X, drawRect.Y + cutRect.Y, cutRect.X, drawRect.Height - cutRect.Y - bottomY);
            edgeSprite = new Bitmap(cutRect.X, cutRect.Height);
            Graphics.FromImage(edgeSprite).DrawImage(borderImage, 0, -cutRect.Y);
            graphics.DrawImage(edgeSprite, sliceRect, 0, 0, edgeSprite.Width, edgeSprite.Height, GraphicsUnit.Pixel, imgAtt);

            sliceRect.X += drawRect.Width - leftX;
            sliceRect.Width = leftX;
            edgeSprite = new Bitmap(leftX, cutRect.Height);
            Graphics.FromImage(edgeSprite).DrawImage(borderImage, -cutRect.X - cutRect.Width, -cutRect.Y);
            graphics.DrawImage(edgeSprite, sliceRect, 0, 0, edgeSprite.Width, edgeSprite.Height, GraphicsUnit.Pixel, imgAtt);

            sliceRect = new Rectangle(drawRect.X + cutRect.X, drawRect.Y + cutRect.Y, drawRect.Width - cutRect.X - leftX, drawRect.Height - cutRect.Y - bottomY);
            edgeSprite = new Bitmap(cutRect.Width, cutRect.Height);
            Graphics.FromImage(edgeSprite).DrawImage(borderImage, -cutRect.X, -cutRect.Y);
            graphics.DrawImage(edgeSprite, sliceRect, 0, 0, edgeSprite.Width, edgeSprite.Height, GraphicsUnit.Pixel, imgAtt);
        }
    }
}
