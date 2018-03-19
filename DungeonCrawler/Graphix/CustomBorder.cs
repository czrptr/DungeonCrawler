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
    public class CustomBorder
    {
        /* Fields */
        private Bitmap[] _corners;
        private Bitmap[] _edges;
        private CustomBorderDimensions _dimensions;

        /* Auto property */
        /// <summary>
        ///   Gets the body sprite of the <see cref="CustomBorder"/>.
        /// </summary>
        /// <value>The <see cref="Bitmap"/> which the body sprite.</value>
        public Bitmap Body { get; private set; }

        /* Constructor */
        /// <summary>
        ///   Initializes a new instance of the <see cref="CustomBorder"/>
        ///   class with the specified dimensions.
        /// </summary>
        /// <param name="dimensions">The dimensions of the border sprites.</param>
        public CustomBorder(CustomBorderDimensions dimensions)
        {
            _dimensions = dimensions;

            // Initializing each corner sprite Bitmap with proper the dimensions
            _corners = new Bitmap[4];
            this[0, 0] = new Bitmap(VSize(1), HSize(1));
            this[0, 1] = new Bitmap(VSize(3), HSize(1));
            this[0, 2] = new Bitmap(VSize(3), HSize(3));
            this[0, 3] = new Bitmap(VSize(1), HSize(3));

            // Initializing each edge sprite Bitmap with proper the dimensions
            _edges = new Bitmap[4];
            this[1, 0] = new Bitmap(VSize(2), HSize(1));
            this[1, 1] = new Bitmap(VSize(3), HSize(2));
            this[1, 2] = new Bitmap(VSize(2), HSize(3));
            this[1, 3] = new Bitmap(VSize(1), HSize(2));

            // Initializing the body sprite Bitmap with proper the dimensions
            Body = new Bitmap(VSize(2), HSize(2));
        }

        #region Methods

        /// <summary>
        ///   Shorthand for accesing the <see cref="CustomBorderDimensions"/>s HSize function.
        /// </summary>
        /// <param name="count">Selects the horizontal slice.</param>
        /// <exception cref="ArgumentException">
        ///   Thrown if <paramref name="count"/> is less than 1 or biggger than 3.
        /// </exception>
        /// <returns>A <seealso cref="int"/>.</returns>
        public int HSize(int count) => _dimensions.HSize(count);

        /// <summary>
        ///   Shorthand for accesing the <see cref="CustomBorderDimensions"/>s VSize function.
        /// </summary>
        /// <param name="count">Selects the vertical slice.</param>
        /// <exception cref="ArgumentException">
        ///   Thrown if <paramref name="count"/> is less than 1 or biggger than 3.
        /// </exception>
        /// <returns>A <seealso cref="int"/>.</returns>
        public int VSize(int count) => _dimensions.VSize(count);

        /// <summary>
        ///   Returns the specified corner sprite.
        /// </summary>
        /// <param name="count">The specific corner sprite selector.</param>
        /// <exception cref="ArgumentException">
        ///   Thrown if <paramref name="count"/> is less than 0 or bigger than 3.
        /// </exception>
        /// <returns>A <see cref="Bitmap"/> which is a sprite component.</returns>
        public Bitmap Corner(int count)
        {
            if (count >= 0 && count < 4)
                return _corners[count];
            throw new ArgumentException("Sprite selector is invalid.", "count");
        }

        /// <summary>
        ///   Returns the specified Edge sprite.
        /// </summary>
        /// <param name="count">The specific edge sprite selector.</param>
        /// <exception cref="ArgumentException">
        ///   Thrown if <paramref name="count"/> is less than 0 or bigger than 3.
        /// </exception>
        /// <returns>A <see cref="Bitmap"/> which is a sprite component.</returns>
        public Bitmap Edge(int count)
        {
            if (count >= 0 && count < 4)
                return _corners[count];
            throw new ArgumentException("Sprite selector is invalid.", "count");
        }

        /// <summary>
        ///   Create a new <see cref="CustomBorder"/>
        ///   from a specified <see cref="Image"/> and with the specified
        ///   <see cref="CustomBorderDimensions"/>.
        /// </summary>
        /// <param name="image">Image from which to create the new CustomBorder.</param>
        /// <exception cref="ArgumentNullException">
        ///   Thrown if <paramref name="image"/> is null.
        /// </exception> 
        /// <param name="dimensions">Dimensions with which to create the new CustomBorder.</param>
        /// <returns>A new CustomBorder with the sprites generated from
        ///   the given <paramref name="image"/> and with the given <paramref name="dimensions"/></returns>
        public static CustomBorder FromImage(Image image, CustomBorderDimensions dimensions)
        {
            if (image == null)
                throw new ArgumentNullException("image", "Source image is null");
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
        /// <param name="filePath">File from which to create the new CustomBorder.</param>
        /// <exception cref="ArgumentNullException">
        ///   Thrown if <paramref name="filePath"/> is null.
        /// </exception> 
        /// <exception cref="ArgumentException">
        ///   Thrown if <paramref name="filePath"/> is not a valid path.
        /// </exception>
        /// <param name="dimensions">Dimensions with which to create the newCustomBorder.</param>
        /// <returns>A new CustomBorder with the sprites generated from
        ///   the given <paramref name="filePath"/> and with the given <paramref name="dimensions"/></returns>
        public static CustomBorder FromFile(string filePath, CustomBorderDimensions dimensions)
        {
            return FromImage(Image.FromFile(filePath), dimensions);
        }

        #endregion

        /* Operator */
        /// <summary>
        ///   Gets the specified <see cref="CustomBorder"/> sprite component.
        /// </summary>
        /// <param name="property">Selects corners or edges.</param>
        /// <exception cref="ArgumentException">
        ///   Thrown if <paramref name="property"/> is not 0 or 1.
        /// </exception>
        /// <param name="count">The specific corner or edge sprite selector .</param>
        /// <exception cref="ArgumentException">
        ///   Thrown if <paramref name="count"/> is less than 0 or bigger than 3.
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
    }
}
