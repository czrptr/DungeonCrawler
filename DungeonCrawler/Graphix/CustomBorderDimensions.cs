using System;
using System.ComponentModel;

namespace DungeonCrawler.Graphix
{
    /// <summary>
    ///   Stores a set of intigers that represent dimensions.
    /// </summary>
    [TypeConverter(typeof(ComponentConverter))]
    public struct CustomBorderDimensions
    {
        /* Fields */
        private int _h1, _h2, _h3, _v1, _v2, _v3;

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="CustomBorderDimensions"/>
        ///   class with the specified universal slice size.
        /// </summary>
        /// <param name="sliceSize">The slice size for all the sprites.</param>
        /// <exception cref="ArgumentException">
        ///   Thorwn if <paramref name="sliceSize"/> is negative.
        /// </exception>
        public CustomBorderDimensions(int sliceSize)
        {
            if(sliceSize < 0)
                throw new ArgumentException(@"Slice size cannot be a negative value.", "sliceSize");
            _h1 = _h2 = _h3 = _v1 = _v2 = _v3 = sliceSize;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CustomBorderDimensions"/>
        ///   class with the specified corner and edge slice sizes.
        /// </summary>
        /// <param name="cornerSize">The size for all corner sprites.</param>
        /// <exception cref="ArgumentException">
        ///   Thorwn if <paramref name="cornerSize"/> is negative.
        /// </exception>
        /// /// <param name="edgeSize">The size for all edge sprites.</param>
        /// <exception cref="ArgumentException">
        ///   Thorwn if <paramref name="edgeSize"/> is negative.
        /// </exception>
        public CustomBorderDimensions(int cornerSize, int edgeSize)
        {
            if (cornerSize < 0)
                throw new ArgumentException(@"Slice size cannot be a negative value.", "cornerSize");
            if (edgeSize < 0)
                throw new ArgumentException(@"Slice size cannot be a negative value.", "edgeSize");
            _h1 = _h3 = _v1 = _v3 = cornerSize;
            _h2 = _v2 = edgeSize;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CustomBorderDimensions"/>
        ///   class with the specified horizontal and vertical slice sizes.
        /// </summary>
        /// <param name="h1Size">The size for the first horizontal slice.</param>
        /// <exception cref="ArgumentException">
        ///   Thorwn if <paramref name="h1Size"/> is negative.
        /// </exception>
        /// /// <param name="h2Size">The size for the second horizontal slice.</param>
        /// <exception cref="ArgumentException">
        ///   Thorwn if <paramref name="h2Size"/> is negative.
        /// </exception>
        /// /// <param name="h3Size">The size for the third horizontal slice.</param>
        /// <exception cref="ArgumentException">
        ///   Thorwn if <paramref name="h3Size"/> is negative.
        /// </exception>
        /// <param name="v1Size">The size for the first vertical slice.</param>
        /// <exception cref="ArgumentException">
        ///   Thorwn if <paramref name="v1Size"/> is negative.
        /// </exception>
        /// /// <param name="v2Size">The size for the second vertical slice.</param>
        /// <exception cref="ArgumentException">
        ///   Thorwn if <paramref name="v2Size"/> is negative.
        /// </exception>
        /// /// <param name="v3Size">The size for the third vertical slice.</param>
        /// <exception cref="ArgumentException">
        ///   Thorwn if <paramref name="v3Size"/> is negative.
        /// </exception>
        public CustomBorderDimensions(int h1Size, int h2Size, int h3Size, int v1Size, int v2Size, int v3Size)
        {
            if (h1Size < 0)
                throw new ArgumentException(@"Slice size cannot be a negative value.", "h1Size");
            if (h2Size < 0)
                throw new ArgumentException(@"Slice size cannot be a negative value.", "h2Size");
            if (h3Size < 0)
                throw new ArgumentException(@"Slice size cannot be a negative value.", "h3Size");
            if (v1Size < 0)
                throw new ArgumentException(@"Slice size cannot be a negative value.", "v1Size");
            if (v2Size < 0)
                throw new ArgumentException(@"Slice size cannot be a negative value.", "v2Size");
            if (v3Size < 0)
                throw new ArgumentException(@"Slice size cannot be a negative value.", "v3Size");
            _h1 = h1Size;
            _h2 = h2Size;
            _h3 = h3Size;
            _v1 = v1Size;
            _v2 = v2Size;
            _v3 = v3Size;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the size of the first horizontal slice.
        /// </summary>
        /// <value>First horizontal slice size.</value>
        /// <exception cref="ArgumentException">
        ///   Thrown when a negative value is assigned.
        /// </exception>
        [Description("The width of the first horizontal slice.")]
        public int H1Size
        {
            get => _h1;
            set
            {
                if(value < 0)
                    throw new ArgumentException("Slice size cannot be a negative value.", "value");
                _h1 = value;
            }
        }

        /// <summary>
        ///   Gets or sets the size of the second horizontal slice.
        /// </summary>
        /// <value>Second horizontal slice size.</value>
        /// <exception cref="ArgumentException">
        ///   Thrown when a negative value is assigned.
        /// </exception>
        [Description("The width of the second horizontal slice.")]
        public int H2Size
        {
            get => _h2;
            set
            {
                if (value < 0)
                    throw new ArgumentException(@"Slice size cannot be a negative value.", "value");
                _h2 = value;
            }
        }

        /// <summary>
        ///   Gets or sets the size of the third horizontal slice.
        /// </summary>
        /// <value>Third horizontal slice size.</value>
        /// <exception cref="ArgumentException">
        ///   Thrown when a negative value is assigned.
        /// </exception>
        [Description("The width of the third horizontal slice.")]
        public int H3Size
        {
            get => _h3;
            set
            {
                if (value < 0)
                    throw new ArgumentException(@"Slice size cannot be a negative value.", "value");
                _h3 = value;
            }
        }

        /// <summary>
        ///   Gets or sets the size of the first vertical slice.
        /// </summary>
        /// <value>First vertical slice size.</value>
        /// <exception cref="ArgumentException">
        ///   Thrown when a negative value is assigned.
        /// </exception>
        [Description("The width of the first vertical slice.")]
        public int V1Size
        {
            get => _v1;
            set
            {
                if (value < 0)
                    throw new ArgumentException(@"Slice size cannot be a negative value.", "value");
                _v1 = value;
            }
        }

        /// <summary>
        ///   Gets or sets the size of the second vertical slice.
        /// </summary>
        /// <value>Second vertical slice size.</value>
        /// <exception cref="ArgumentException">
        ///   Thrown when a negative value is assigned.
        /// </exception>
        [Description("The width of the second vertical slice.")]
        public int V2Size
        {
            get => _v2;
            set
            {
                if (value < 0)
                    throw new ArgumentException(@"Slice size cannot be a negative value.", "value");
                _v2 = value;
            }
        }

        /// <summary>
        ///   Gets or sets the size of the third vertical slice.
        /// </summary>
        /// <value>Third vertical slice size.</value>
        /// <exception cref="ArgumentException">
        ///   Thrown when a negative value is assigned.
        /// </exception>
        [Description("The width of the third vertical slice.")]
        public int V3Size
        {
            get => _v3;
            set
            {
                if (value < 0)
                    throw new ArgumentException(@"Slice size cannot be a negative value.", "value");
                _v3 = value;
            }
        }

        /// <summary>
        ///   Gets or sets the same slice size to all the slices.
        /// </summary>
        /// <value>Universal slice size.</value>
        /// <remarks>
        ///   Will return -1 if not all the slices are of the same size.
        /// </remarks>
        /// <exception cref="ArgumentException">
        ///   Thrown when a negative value is assigned.
        /// </exception>
        [Description("The universal slice dimenison.")]
        public int AllSlicesSize
        {
            get => (IntsEqual(_h1, _h2, _h3, _v1, _v2, _v3)) ? _h1 : -1;
            set => H1Size = H2Size = H3Size = V1Size = V2Size = V3Size = value;
        }

        /// <summary>
        ///   Gets or sets the same slice size to all the corners.
        /// </summary>
        /// <value>Universal corner slice size.</value>
        ///  /// <remarks>
        ///   Will return -1 if not all the corner slices are of the same size.
        /// </remarks>
        /// <exception cref="ArgumentException">
        ///   Thrown when a negative value is assigned.
        /// </exception>
        [Description("The corner slice dimenison.")]
        public int AllCornersSize
        {
            get => (IntsEqual(_h1, _h3, _v1, _v3)) ? _h1 : -1;
            set => H1Size = H3Size = V1Size = V3Size = value;
        }

        /// <summary>
        ///   Gets or sets the same slice size to all the edges.
        /// </summary>
        /// <value>Universal edge slice size.</value>
        ///  /// <remarks>
        ///   Will return -1 if not all the edge slices are of the same size.
        /// </remarks>
        /// <exception cref="ArgumentException">
        ///   Thrown when a negative value is assigned.
        /// </exception>
        [Description("The edge slice dimenison.")]
        public int AllEdgesSize
        {
            get => (_h2 == _v2) ? _h2 : -1;
            set => H2Size = V2Size = value;
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Return the size of the specified horizontal slice.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// <param name="count">The horizontal slice selector.</param>
        ///   Thrown if <paramref name="count"/> is less than 1 or bigger than 3.
        /// </exception>
        /// <returns>A <seealso cref="int"/>.</returns>
        public int HSize(int count)
        {
            if (count == 1)
                return _h1;
            else if (count == 2)
                return _h2;
            else if (count == 3)
                return _h3;
            throw new ArgumentException(@"Slice selector is invalid.", "count");
        }

        /// <summary>
        ///   Return the size of the specified vertical slice.
        /// </summary>
        /// <param name="count">The vertical slice selector.</param>
        /// <exception cref="ArgumentException">
        ///   if <paramref name="count"/> is less than 1 or bigger than 3.
        /// </exception>
        /// <returns>A <seealso cref="int"/>.</returns>
        public int VSize(int count)
        {
            if (count == 1)
                return _v1;
            else if (count == 2)
                return _v2;
            else if (count == 3)
                return _v3;
            throw new ArgumentException(@"Slice selector is invalid.", "count");
        }

        /// <summary>
        ///   Converts this <see cref="CustomBorderDimensions"/>
        ///   to a human-readable string.
        /// </summary>
        /// <returns>A <see cref="string"/></returns>
        public override string ToString()
        {
            return "{" + $"_h1={_h1},_h2={_h2},_h3={_h3},_v1={_v1},_v2={_v2},_v3={_v3}" + "}";
        }

        #endregion

        // To check field mutual eqaulity 
        private bool IntsEqual(params int[] ints)
        {
            for (int i = 0; i < ints.Length - 1; ++i)
                if (ints[i] != ints[i + 1])
                    return false;
            return true;
        }
    }
}
