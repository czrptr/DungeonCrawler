using System;

namespace DungeonCrawler.Graphix
{
    /// <summary>
    ///   Stores a set of intigers that represent dimensions.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     The <c>CustomBorderDimensions</c> type
    ///     is a container ment to facilitate ease
    ///     of use.
    ///   </para>
    /// </remarks>
    struct CustomBorderDimensions
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="CustomBorderDimensions"/>
        ///   class with the specified cut sizes.
        /// </summary>
        /// <param name="cutSize">The universal size for all the sprites.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="cutSize"/> is negative.
        /// </exception>
        public CustomBorderDimensions(int cutSize)
        {
            if (cutSize < 0)
                throw new ArgumentException("Cut size cannot be a negative value.", "cutSize");
            _h1Size = _h2Size = _h3Size = _v1Size = _v2Size = _v3Size = cutSize;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CustomBorderDimensions"/>
        ///   class with the specified corner and edge cut sizes.
        /// </summary>
        /// <param name="cornerSize">The size for all corner sprites.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="cornerSize"/> is negative.
        /// </exception>
        /// /// <param name="edgeSize">The size for all edge sprites.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="edgeSize"/> is negative.
        /// </exception>
        public CustomBorderDimensions(int cornerSize, int edgeSize)
        {
            if(cornerSize < 0)
                throw new ArgumentException("Cut size cannot be a negative value.", "cornerSize");
            if(edgeSize < 0)
                throw new ArgumentException("Cut size cannot be a negative value.", "edgeSize");
            _h1Size = _h3Size = _v1Size = _v3Size = cornerSize;
            _h2Size = _v2Size = edgeSize;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CustomBorderDimensions"/>
        ///   class with the specified horizontal and vertical cut sizes.
        /// </summary>
        /// <param name="h1Size">The size for first horizontal cut.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="h1Size"/> is negative.
        /// </exception>
        /// /// <param name="h2Size">The size for second horizontal cut.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="h2Size"/> is negative.
        /// </exception>
        /// /// <param name="h3Size">The size for third horizontal cut.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="h3Size"/> is negative.
        /// </exception>
        /// <param name="v1Size">The size for first vertical cut.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="v1Size"/> is negative.
        /// </exception>
        /// /// <param name="v2Size">The size for second vertical cut.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="v2Size"/> is negative.
        /// </exception>
        /// /// <param name="v3Size">The size for third vertical cut.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="v3Size"/> is negative.
        /// </exception>
        public CustomBorderDimensions(int h1Size, int h2Size, int h3Size, int v1Size, int v2Size, int v3Size)
        {
            if (h1Size < 0)
                throw new ArgumentException("Cut size cannot be a negative value.", "h1Size");
            if (h2Size < 0)
                throw new ArgumentException("Cut size cannot be a negative value.", "h2Size");
            if (h3Size < 0)
                throw new ArgumentException("Cut size cannot be a negative value.", "h3Size");
            if (v1Size < 0)
                throw new ArgumentException("Cut size cannot be a negative value.", "v1Size");
            if (v2Size < 0)
                throw new ArgumentException("Cut size cannot be a negative value.", "v2Size");
            if (v3Size < 0)
                throw new ArgumentException("Cut size cannot be a negative value.", "v3Size");
            _h1Size = h1Size;
            _h2Size = h2Size;
            _h3Size = h3Size;
            _v1Size = v1Size;
            _v2Size = v2Size;
            _v3Size = v3Size;
        }

        // cut sizes
        private int _h1Size, _h2Size, _h3Size, _v1Size, _v2Size, _v3Size;

        /// <summary>
        ///   Return the size of the specified horizontal slice.
        /// </summary>
        /// <param name="count">Selects the horizontal slice.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="count"/> is less than <c>1</c> or bigger than <c>3</c>.
        /// </exception>
        /// <returns>A <seealso cref="int"/>.</returns>
        public int HSize(int count)
        {
            if (count == 1)
                return _h1Size;
            else if (count == 2)
                return _h2Size;
            else if (count == 3)
                return _h3Size;
            else
                throw new ArgumentException("Slice selector is invalid.", "count");
        }

        /// <summary>
        ///   Return the size of the specified vertical slice.
        /// </summary>
        /// <param name="count">Selects the vertical slice.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="count"/> is less than <c>1</c> or bigger than <c>3</c>.
        /// </exception>
        /// <returns>A <seealso cref="int"/>.</returns>
        public int VSize(int count)
        {
            if (count == 1)
                return _v1Size;
            else if (count == 2)
                return _v2Size;
            else if (count == 3)
                return _v3Size;
            else
                throw new ArgumentException("Slice selector is invalid.", "count");
        }
    }
}
