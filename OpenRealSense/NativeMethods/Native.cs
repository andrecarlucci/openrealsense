using System;
using System.IO;

namespace OpenRealSense.NativeMethods {
    public static class Native {
        private static bool _isWindows = IsWindows();

        public static bool IsWindows() {
            if(System.Runtime.InteropServices.RuntimeInformation.OSDescription.ToUpper().Contains("WINDOWS")) {
            //var windir = Environment.GetEnvironmentVariable("windir");
            //if(!String.IsNullOrEmpty(windir) && windir.Contains(@"\") && Directory.Exists(windir)) {
                RealSenseAssembliesLoader.Load();
                return true;
            }
            return false;
        }
        
        public class Context {

            public static IntPtr rs_create_context(int api_version) {
                return Run(Windows.Context.rs_create_context,
                           Linux.Context.rs_create_context,
                           api_version);
            }

            public static void rs_delete_context(IntPtr context) {
                Run(Windows.Context.rs_delete_context,
                    Linux.Context.rs_delete_context,
                    context);
            }

            public static int rs_get_device_count(IntPtr context) {
                return Run(Windows.Context.rs_get_device_count,
                           Linux.Context.rs_get_device_count,
                           context
                );
            }

            public static IntPtr rs_get_device(IntPtr context, int index) {
                return Run(Windows.Context.rs_get_device,
                           Linux.Context.rs_get_device,
                           context, index
                );
            }
        }

        public class Device {
            public static string rs_get_device_name(IntPtr device) {
                return Run(Windows.Device.rs_get_device_name,
                           Linux.Device.rs_get_device_name,
                           device
                );
            }

            public static void rs_enable_stream(IntPtr device, StreamType stream, int width, int height, FormatType format, int framerate) {
                Run(Windows.Device.rs_enable_stream,
                    Linux.Device.rs_enable_stream,
                    device, stream, width, height, format, framerate);
            }

            public static void rs_wait_for_frames(IntPtr device) {
                Run(Windows.Device.rs_wait_for_frames,
                    Linux.Device.rs_wait_for_frames,
                    device);
            }

            public static IntPtr rs_get_frame_data(IntPtr device, StreamType stream) {
                return Run(Windows.Device.rs_get_frame_data,
                           Linux.Device.rs_get_frame_data,
                           device, stream);
            }

            public static void rs_start_device(IntPtr device) {
                Run(Windows.Device.rs_start_device,
                    Linux.Device.rs_start_device,
                    device);
            }

            public static void rs_stop_device(IntPtr device) {
                Run(Windows.Device.rs_stop_device,
                    Linux.Device.rs_stop_device,
                    device);
            }
            public static float rs_get_device_depth_scale(IntPtr device) {
                return Run(Windows.Device.rs_get_device_depth_scale,
                    Linux.Device.rs_get_device_depth_scale,
                    device);
            }

            public static int rs_get_stream_width(IntPtr device, StreamType streamType) {
                return Run(Windows.Device.rs_get_stream_width,
                       Linux.Device.rs_get_stream_width,
                       device, streamType);
            }

            public static int rs_get_stream_height(IntPtr device, StreamType streamType) {
                return Run(Windows.Device.rs_get_stream_height,
                       Linux.Device.rs_get_stream_height,
                       device, streamType);
            }

            public static FormatType rs_get_stream_format(IntPtr device, StreamType streamType) {
                return Run(Windows.Device.rs_get_stream_format,
                       Linux.Device.rs_get_stream_format,
                       device, streamType);
            }
        }

        public class Error {
            public static string rs_get_error_message(IntPtr error) {
                return _isWindows
                    ? Windows.Error.rs_get_error_message(error)
                    : Linux.Error.rs_get_error_message(error);
            }
        }

        public delegate void Action<T1>(T1 input, out IntPtr output);
        public delegate void Action<T1, T2, T3, T4, T5, T6>(T1 input1, T2 input2, T3 input3, T4 input4, T5 input5, T6 input6, out IntPtr output);
        public delegate TResult Func<T1, TResult>(T1 input1, out IntPtr output);
        public delegate TResult Func<T1, T2, TResult>(T1 input1, T2 input2, out IntPtr output);


        public static TResult Run<T1, TResult>(Func<T1, TResult> windows,
                                               Func<T1, TResult> linux,
                                               T1 par1) {
            var error = IntPtr.Zero;
            var res = _isWindows
                ? windows.Invoke(par1, out error)
                : linux.Invoke(par1, out error);
            RealSenseException.ThrowOnError(error, Error.rs_get_error_message);
            return res;
        }

        public static TResult Run<T1, T2, TResult>(Func<T1, T2, TResult> windows,
                                                   Func<T1, T2, TResult> linux,
                                                   T1 par1, T2 par2) {
            var error = IntPtr.Zero;
            var res = _isWindows
                ? windows.Invoke(par1, par2, out error)
                : linux.Invoke(par1, par2, out error);
            RealSenseException.ThrowOnError(error, Error.rs_get_error_message);
            return res;
        }

        public static void Run<T1>(Action<T1> windows,
                                   Action<T1> linux,
                                   T1 par1) {
            var error = IntPtr.Zero;
            if (_isWindows) {
                windows.Invoke(par1, out error);
            }
            else {
                linux.Invoke(par1, out error);
            }
            RealSenseException.ThrowOnError(error, Error.rs_get_error_message);
        }

        public static void Run<T1, T2, T3, T4, T5, T6>(
                                   Action<T1, T2, T3, T4, T5, T6> windows,
                                   Action<T1, T2, T3, T4, T5, T6> linux,
                                   T1 par1, T2 par2, T3 par3, T4 par4, T5 par5, T6 par6) {
            var error = IntPtr.Zero;
            if (_isWindows) {
                windows.Invoke(par1, par2, par3, par4, par5, par6, out error);
            }
            else {
                linux.Invoke(par1, par2, par3, par4, par5, par6, out error);
            }
            RealSenseException.ThrowOnError(error, Error.rs_get_error_message);
        }
    }
}