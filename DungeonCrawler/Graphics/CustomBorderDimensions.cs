namespace DungeonCrawler.Graphix
{
    struct CustomBorderDimensions
    {
        public CustomBorderDimensions(int cutSize)
        {
            _h1Size = _h2Size = _h3Size = _v1Size = _v2Size = _v3Size = cutSize;
        }

        public CustomBorderDimensions(int cornerSize, int edgeSize)
        {
            _h1Size = _h3Size = _v1Size = _v3Size = cornerSize;
            _h2Size = _v2Size = edgeSize;
        }

        public CustomBorderDimensions(int h1Size, int h2Size, int h3Size, int v1Size, int v2Size, int v3Size)
        {
            _h1Size = h1Size;
            _h2Size = h2Size;
            _h3Size = h3Size;
            _v1Size = v1Size;
            _v2Size = v2Size;
            _v3Size = v3Size;
        }

        private int _h1Size, _h2Size, _h3Size, _v1Size, _v2Size, _v3Size;

        public int HSize(int count)
        {
            if (count == 1)
                return _h1Size;
            else if (count == 2)
                return _h2Size;
            else if (count == 3)
                return _h3Size;
            else
                return -1;
        }

        public int VSize(int count)
        {
            if (count == 1)
                return _v1Size;
            else if (count == 2)
                return _v2Size;
            else if (count == 3)
                return _v3Size;
            else
                return -1;
        }
    }
}
