using System;
using System.Runtime.InteropServices;

namespace OpenRealSense.NativeMethods.Windows {
    public static class Error {
        [DllImport(DllSource.Path)]
        public static extern string rs_get_failed_function(IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern string rs_get_failed_args(IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern string rs_get_error_message(IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern void rs_free_error(IntPtr error);
    }
}