using System;

namespace OpenRealSense {
    public enum FormatType {
        any = 0, //When passed to enable stream, librealsense will try to provide best suited format 
        z16 = 1,  //16-bit linear depth values. The depth is meters is equal to depth scale * pixel value.
        disparity16 = 2,  //16-bit linear disparity values. The depth in meters is equal to depth scale / pixel value.
        xyz32f = 3,  //32-bit floating point 3D coordinates. 
        yuyv = 4,
        rgb8 = 5,
        bgr8 = 6,
        rgba8 = 7,
        bgra8 = 8,
        y8 = 9,
        y16 = 10,
        raw10 = 11,  //Four 10-bit luminance values encoded into a 5-byte macropixel
        raw16 = 12,  //Four 10-bit luminance filled in 16 bit pixel (6 bit unused)
        raw8 =13
    }

    public static class FormatTypeExtensions {
        public static int BitsPerPixel(this FormatType formatType) {
            switch (formatType) {
                case FormatType.y8:
                case FormatType.raw8:
                    return 8;
                case FormatType.raw10:
                    return 10;
                case FormatType.z16:
                case FormatType.disparity16:
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
