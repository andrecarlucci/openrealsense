using System;
using System.IO;

namespace OpenRealSense.NativeMethods {
    public static class Native {

        static Native() {
            if (System.Runtime.InteropServices.RuntimeInformation.OSDescription.ToUpper().Contains("WINDOWS")) {
                RealSenseAssembliesLoader.LoadWindows();
                return;
            }
            RealSenseAssembliesLoader.LoadLinux();
        }

        public delegate void Action<T1>(T1 input, out IntPtr output);
        public delegate void Action<T1, T2, T3, T4, T5, T6>(T1 input1, T2 input2, T3 input3, T4 input4, T5 input5, T6 input6, out IntPtr output);
        public delegate TResult Func<T1, TResult>(T1 input1, out IntPtr output);
        public delegate TResult Func<T1, T2, TResult>(T1 input1, T2 input2, out IntPtr output);


        public static TResult Run<T1, TResult>(Func<T1, TResult> windows, T1 par1) {
            IntPtr error;
            var res = windows.Invoke(par1, out error);
            RealSenseException.ThrowOnError(error, Error.rs_get_error_message);
            return res;
        }

        public static TResult Run<T1, T2, TResult>(Func<T1, T2, TResult> windows,
                                                   T1 par1, T2 par2) {
            IntPtr error;
            var res = windows.Invoke(par1,par2, out error);
            RealSenseException.ThrowOnError(error, Error.rs_get_error_message);
            return res;
        }

        public static void Run<T1>(Action<T1> windows,
                                   T1 par1) {
            IntPtr error;
            windows.Invoke(par1, out error);
            RealSenseException.ThrowOnError(error, Error.rs_get_error_message);
        }

        public static void Run<T1, T2, T3, T4, T5, T6>(
                                   Action<T1, T2, T3, T4, T5, T6> windows,
                                   T1 par1, T2 par2, T3 par3, T4 par4, T5 par5, T6 par6) {
            IntPtr error;
            windows.Invoke(par1, par2, par3, par4,par5,par6, out error);
            RealSenseException.ThrowOnError(error, Error.rs_get_error_message);
        }
    }
}