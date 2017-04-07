namespace OpenRealSense {
    public class FrameData {
        public byte[] Bytes { get; }
        public int Width { get; }
        public int Height { get; }
        public FormatType FormatType { get; }

        public FrameData(byte[] bytes, int width, int height, FormatType formatType) {
            Bytes = bytes;
            Width = width;
            Height = height;
            FormatType = formatType;
        }
    }
}