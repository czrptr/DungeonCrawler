using System;
using System.Drawing;

namespace DungeonCrawler.Graphix
{
    /// <summary>
    ///   Stores a set of Bitmaps that represent a border template.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     The <c>CustomBorder</c> type
    ///     provides funcionality for easly working
    ///     with rescalable borders.
    ///   </para>
    /// </remarks>
    class CustomBorder
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="CustomBorder"/>
        ///   class with the specified dimensions.
        /// </summary>
        /// <param name="dimensions">The dimensions of the border sprites.</param>
        public CustomBorder(CustomBorderDimensions dimensions)
        {
            Dimensions = dimensions;
            _corners = new Bitmap[4];

            // Initializing each corner sprite Bitmap with proper the dimensions
            this[0, 0] = new Bitmap(VSize(1), HSize(1));
            this[0, 1] = new Bitmap(VSize(3), HSize(1));
            this[0, 2] = new Bitmap(VSize(3), HSize(3));
            this[0, 3] = new Bitmap(VSize(1), HSize(3));
            _edges = new Bitmap[4];

            // Initializing each edge sprite Bitmap with proper the dimensions
            this[1, 0] = new Bitmap(VSize(2), HSize(1));
            this[1, 1] = new Bitmap(VSize(3), HSize(2));
            this[1, 2] = new Bitmap(VSize(2), HSize(3));
            this[1, 3] = new Bitmap(VSize(1), HSize(2));

            // Initializing the body sprite Bitmap with proper the dimensions
            Body = new Bitmap(VSize(2), HSize(2));
        }

        // vectors where we store cornes and edge sprites
        private Bitmap[] _corners { get; set; }
        private Bitmap[] _edges { get; set; }

        /// <summary>
        ///   Gets the body sprite of the <see cref="CustomBorder"/>.
        /// </summary>
        /// <value>The <see cref="Bitmap"/> which the body sprite.</value>
        public Bitmap Body { get; private set; }
        
        /// <summary>
        ///   Gets the <see cref="CustomBorderDimensions"/> of the <see cref="CustomBorder"/>.
        /// </summary>
        /// <value>The dimensions of the sprites.</value>
        public CustomBorderDimensions Dimensions { get; private set; }

        /// <summary>
        ///   Shorthand for accesing the Dimensions HorizontalSliceSize property.
        /// </summary>
        /// <param name="count">Selects the horizontal slice.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="count"/> is less than <c>0</c> or biggger than <c>3</c>.
        /// </exception>
        /// <returns>A <seealso cref="int"/>.</returns>
        public int HSize(int count) => Dimensions.HSize(count);

        /// <summary>
        ///   Shorthand for accesing the Dimensions VerticalSliceSize property.
        /// </summary>
        /// <param name="count">Selects the vertical slice.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="count"/> is less than <c>0</c> or biggger than <c>3</c>.
        /// </exception>
        /// <returns>A <seealso cref="int"/>.</returns>
        public int VSize(int count) => Dimensions.VSize(count);

        /// <summary>
        ///   Returns the specified corner sprite.
        /// </summary>
        /// <param name="count">Selects the specific corner sprite.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="count"/> is less than <c>0</c> or bigger than <c>4</c>.
        /// </exception>
        /// <returns>A <see cref="Bitmap"/> which is a sprite component.</returns>
        public Bitmap Corner(int count)
        {
            if (count > 0 && count < 4)
                return _corners[count];
            throw new ArgumentException("Sprite selector is invalid.", "count");
        }

        /// <summary>
        ///   Returns the specified Edge sprite.
        /// </summary>
        /// <param name="count">Selects the specific edge sprite.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="count"/> is less than <c>0</c> or bigger than <c>4</c>.
        /// </exception>
        /// <returns>A <see cref="Bitmap"/> which is a sprite component.</returns>
        public Bitmap Edge(int count)
        {
            if (count > 0 && count < 4)
                return _corners[count];
            throw new ArgumentException("Sprite selector is invalid.", "count");
        }

        /// <summary>
        ///   Gets the specified <see cref="CustomBorder"/> sprite component.
        /// </summary>
        /// <param name="property">Selects corners or edges.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="property"/> is not <c>1</c> or <c>0</c>.
        /// </exception>
        /// <param name="count">Selects the specific corner or edge sprite.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="property"/> is not <c>1</c> or <c>0</c>.
        /// </exception>
        /// <returns>A <see cref="Bitmap"/> which is a sprite component.</returns>
        public Bitmap this[int property, int count]
        {
            get
            {
                if (count < 0 && count > 3)
                    throw new ArgumentException("Sprite selector is invalid.", "count");
                if (property == 0)
                    return _corners[count];
                if (property == 1)
                    return _edges[count];
                throw new ArgumentException("Propertie selector is invalid.", "property");
            }
            private set
            {
                if (property == 0 && count >= 0 && count < 4)
                    _corners[count] = value;
                else if (property == 1 && count >= 0 && count < 4)
                    _edges[count] = value;
            }
        }

        /// <summary>
        ///   Create a new <see cref="CustomBorder"/>
        ///   from a specified <see cref="Image"/> and with the specified
        ///   <see cref="CustomBorderDimensions"/>.
        /// </summary>
        /// <param name="image">Image from which to create the new <c>CustomBorder</c>.</param>
        /// <exception cref="ArgumentNullException">
        ///   if <paramref name="image"/> is <c>null</c>.
        /// </exception> 
        /// <param name="dimensions">Dimensions with which to create the new <c>CustomBorder</c>.</param>
        /// <returns>A new <c>CustomBorder</c> with the sprites generated from
        ///   the given <paramref name="image"/> and with the given <paramref name="dimensions"/></returns>
        public static CustomBorder FromImage(Image image, CustomBorderDimensions dimensions)
        {
            CustomBorder newBorder = new CustomBorder(dimensions);
            Graphics cutter;

            // Saving each corner sprite (from top-left counterclockwise)
            cutter = Graphics.FromImage(newBorder[0, 0]);
            cutter.DrawImage(image, 0, 0);
            cutter = Graphics.FromImage(newBorder[0, 1]);
            cutter.DrawImage(image, -dimensions.VSize(1) - dimensions.VSize(2), 0);
            cutter = Graphics.FromImage(newBorder[0, 2]);
            cutter.DrawImage(image, -dimensions.VSize(1) - dimensions.VSize(2), -dimensions.HSize(1) - dimensions.HSize(2));
            cutter = Graphics.FromImage(newBorder[0, 3]);
            cutter.DrawImage(image, 0, -dimensions.HSize(1) - dimensions.HSize(2));

            // Saving each edge sprite (from top counterclockwise)
            cutter = Graphics.FromImage(newBorder[1, 0]);
            cutter.DrawImage(image, -dimensions.VSize(1), 0);
            cutter = Graphics.FromImage(newBorder[1, 1]);
            cutter.DrawImage(image, -dimensions.VSize(1) - dimensions.VSize(2), -dimensions.HSize(1));
            cutter = Graphics.FromImage(newBorder[1, 2]);
            cutter.DrawImage(image, -dimensions.VSize(1), -dimensions.HSize(1) - dimensions.HSize(2));
            cutter = Graphics.FromImage(newBorder[1, 3]);
            cutter.DrawImage(image, 0, -dimensions.HSize(1));

            // Saving body sprite
            cutter = Graphics.FromImage(newBorder.Body);
            cutter.DrawImage(image, -dimensions.VSize(1), -dimensions.HSize(1));

            return newBorder;
        }

        /// <summary>
        ///   Create a new <see cref="CustomBorder"/>
        ///   from a specified file and with the specified
        ///   <see cref="CustomBorderDimensions"/>.
        /// </summary>
        /// <param name="filePath">File from which to create the new <c>CustomBorder</c>.</param>
        /// <exception cref="ArgumentNullException">
        ///   if <paramref name="filePath"/> is <c>null</c>.
        /// </exception> 
        /// <exception cref="ArgumentException">
        ///   if <paramref name="filePath"/> is not a valid path.
        /// </exception>
        /// <param name="dimensions">Dimensions with which to create the new <c>CustomBorder</c>.</param>
        /// <returns>A new <c>CustomBorder</c> with the sprites generated from
        ///   the given <paramref name="filePath"/> and with the given <paramref name="dimensions"/></returns>
        public static CustomBorder FromFile(string filePath, CustomBorderDimensions dimensions)
        {
            return FromImage(Image.FromFile(filePath), dimensions);
        }
    }
}
