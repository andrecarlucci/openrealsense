using System;
using System.Runtime.InteropServices;
using OpenRealSense.NativeMethods.Windows;

namespace OpenRealSense.NativeMethods {
    public static class Error {
        [DllImport(DllSource.Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern string rs_get_failed_function(IntPtr error);

        [DllImport(DllSource.Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern string rs_get_failed_args(IntPtr error);

        [DllImport(DllSource.Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern string rs_get_error_message(IntPtr error);

        [DllImport(DllSource.Path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void rs_free_error(IntPtr error);
    }
}