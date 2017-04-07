using System;
namespace OpenRealSense {
    public class RealSenseException : Exception {
        public static void ThrowOnError(IntPtr error, Func<IntPtr, string> getErrorFunc) {
            if (error == IntPtr.Zero) {
                return;
            }
            throw new RealSenseException(getErrorFunc.Invoke(error));
        }
        private RealSenseException(string message) : base(message) {
        }
    }
}