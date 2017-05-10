using System;
using OpenRealSense.NativeMethods;

namespace OpenRealSense {
    public class Context : IDisposable {
        private IntPtr _context;

        private Context(IntPtr context) {
            _context = context;
        }

        public static Context Create(int version = 11201) {
            var context = Native.Run(NativeMethods.Context.rs_create_context, version);
            return new Context(context);
        }

        public int GetDeviceCount() {
            return Native.Run(NativeMethods.Context.rs_get_device_count, _context);
        }

        public Device GetDevice(int index) {
            var device = Native.Run(NativeMethods.Context.rs_get_device,_context, index);
            return new Device(device);
        }

        public void Close() {
            if (_context == IntPtr.Zero) {
                return;
            }
            Native.Run(NativeMethods.Context.rs_delete_context,_context);
            _context = IntPtr.Zero;
        }
        public void Dispose() {
            Close();
        }
    }
}