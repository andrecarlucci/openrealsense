using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OpenRealSense {
    public static class RealSenseAssembliesLoader {
        private static bool _isInitialized = false;

        public static void Load() {
            if (_isInitialized) {
                return;
            }
            var platform = IntPtr.Size == 8 ? "x64" : "x32";
            var unmanagedRef = $"OpenRealSense.libs.{platform}.realsense.dll";
            File.WriteAllBytes("realsense.dll", GetAssembly(unmanagedRef));
        }

        private static byte[] GetAssembly(string path) {
            var assembly = typeof(RealSenseAssembliesLoader).GetTypeInfo().Assembly;
            using (var stm = assembly.GetManifestResourceStream(path)) {
                var ba = new byte[(int)stm.Length];
                stm.Read(ba, 0, (int)stm.Length);
                return ba;
            }
        }
    }
}
