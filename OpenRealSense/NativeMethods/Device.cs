using System;
using System.Runtime.InteropServices;
using OpenRealSense.NativeMethods.Windows;

namespace OpenRealSense.NativeMethods {

    public static class Device {
        [DllImport(DllSource.Path)]
        public static extern string rs_get_device_name(IntPtr device, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern string rs_get_device_serial(IntPtr device, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern string rs_get_device_firmware_version(IntPtr device, out IntPtr error);


        [DllImport(DllSource.Path)]
        public static extern int rs_get_stream_mode_count(IntPtr device, StreamType stream, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern void rs_get_stream_mode(IntPtr device, StreamType stream, int index, out int width, out int height, out FormatType format, out int framerate, out IntPtr error);


        //[DllImport(DllSource.Path)]
        //public static extern void rs_get_device_extrinsics(IntPtr device, StreamType from_stream, StreamType to_stream, ref Extrinsics extrin, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern void rs_enable_stream(IntPtr device, StreamType stream, int width, int height, FormatType format, int framerate, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern void rs_enable_stream_preset(IntPtr device, StreamType stream, PresetType preset, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern int rs_is_stream_enabled(IntPtr device, StreamType stream, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern int rs_get_stream_width(IntPtr device, StreamType stream, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern int rs_get_stream_height(IntPtr device, StreamType stream, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern FormatType rs_get_stream_format(IntPtr device, StreamType stream, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern int rs_get_stream_framerate(IntPtr device, StreamType stream, out IntPtr error);

        //[DllImport(DllSource.Path)]
        //public static extern void rs_get_stream_intrinsics(IntPtr device, StreamType stream, ref Intrinsics intrin, out IntPtr error);


        [DllImport(DllSource.Path)]
        public static extern void rs_wait_for_frames(IntPtr device, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern int rs_get_frame_timestamp(IntPtr device, StreamType stream, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern IntPtr rs_get_frame_data(IntPtr device, StreamType stream, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern void rs_start_device(IntPtr device, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern void rs_stop_device(IntPtr device, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern float rs_get_device_depth_scale(IntPtr device, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern int rs_device_supports_option(IntPtr device, OptionType option, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern void rs_get_device_option_range(IntPtr device, OptionType option, out double min, out double max, out double step, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern void rs_get_device_options(IntPtr device, ref OptionType options, int count, ref double[] values, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern void rs_set_device_options(IntPtr device, ref OptionType options, int count, double[] values, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern double rs_get_device_option(IntPtr device, OptionType option, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern void rs_set_device_option(IntPtr device, OptionType option, double value, out IntPtr error);


    }
}