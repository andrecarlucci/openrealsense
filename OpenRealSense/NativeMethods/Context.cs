using System;
using System.Runtime.InteropServices;
using OpenRealSense.NativeMethods.Windows;

namespace OpenRealSense.NativeMethods {
    public static class Context {
        [DllImport(DllSource.Path)]
        public static extern IntPtr rs_create_context(int api_version, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern void rs_delete_context(IntPtr context, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern int rs_get_device_count(IntPtr context, out IntPtr error);

        [DllImport(DllSource.Path)]
        public static extern IntPtr rs_get_device(IntPtr context, int index, out IntPtr error);
    }
}