using System;

namespace OpenRealSense {
    public enum FormatType {
        Any = 0,      //When passed to enable stream, librealsense will try to provide best suited format 
        Z16 = 1,      //16-bit linear depth values. The depth is meters is equal to depth scale * pixel value.
        Disparity16 = 2,  //16-bit linear disparity values. The depth in meters is equal to depth scale / pixel value.
        xyz32f = 3,   //32-bit floating point 3D coordinates. 
        yuyv = 4,     //Standard YUV pixel format as described in https://en.wikipedia.org/wiki/YUV 
        rgb8 = 5,     //8-bit red, green and blue channels
        bgr8 = 6,     //8-bit blue, green, and red channels -- suitable for OpenCV
        rgba8 = 7,    //8-bit red, green and blue channels + constant alpha channel equal to FF
        bgra8 = 8,    //8-bit blue, green, and red channels + constant alpha channel equal to FF
        y8 = 9,       //8-bit per-pixel grayscale image
        y16 = 10,     //16-bit per-pixel grayscale image 
        raw10 = 11,   //Four 10-bit luminance values encoded into a 5-byte macropixel
        raw16 = 12,   //16-bit raw image
        raw8 = 13     //8-bit raw image 
    }

    public static class FormatTypeExtensions {
        public static int BitsPerPixel(this FormatType formatType) {
            switch (formatType) {
                case FormatType.y8:
                case FormatType.raw8:
                    return 8;
                case FormatType.raw10:
                    return 10;
                case FormatType.Z16:
                case FormatType.Disparity16:
                case FormatType.yuyv:
                case FormatType.y16:
                case FormatType.raw16:
                    return 16;
                case FormatType.rgb8:
                case FormatType.bgr8:
                    return 24;
                case FormatType.rgba8:
                case FormatType.bgra8:
                    return 32;
                case FormatType.xyz32f:
                    return 12 * 8;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
