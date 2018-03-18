namespace DungeonCrawler.Graphix
{
    struct CustomBorderDimensions
    {
        public CustomBorderDimensions(int cutSize)
        {
            H1Size = H2Size = H3Size = V1Size = V2Size = V3Size = cutSize;
        }

        public CustomBorderDimensions(int cornerSize, int edgeSize)
        {
            H1Size = H3Size = V1Size = V3Size = cornerSize;
            H2Size = V2Size = edgeSize;
        }

        public CustomBorderDimensions(int h1Size, int h2Size, int h3Size, int v1Size, int v2Size, int v3Size)
        {
            H1Size = h1Size;
            H2Size = h2Size;
            H3Size = h3Size;
            V1Size = v1Size;
            V2Size = v2Size;
            V3Size = v3Size;
        }

        public int H1Size { get; set; }
        public int H2Size { get; set; }
        public int H3Size { get; set; }
        public int V1Size { get; set; }
        public int V2Size { get; set; }
        public int V3Size { get; set; }
    }
}
