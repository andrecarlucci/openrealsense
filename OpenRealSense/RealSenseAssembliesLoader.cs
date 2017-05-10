using System;
using System.IO;
using System.Reflection;

namespace OpenRealSense {
    public static class RealSenseAssembliesLoader {

        public static void LoadWindows() {
            var platform = IntPtr.Size == 8 ? "x64" : "x32";
            var unmanagedRef = $"OpenRealSense.libs.{platform}.realsense.dll";
            WriteFile(unmanagedRef);
        }

        public static void LoadLinux() {
            var unmanagedRef = "OpenRealSense.libs.linux.realsense.dll";
            WriteFile(unmanagedRef);
        }

        private static void WriteFile(string unmanagedRef) {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(location);
            File.WriteAllBytes(Path.Combine(directory, "realsense.dll"), GetAssembly(unmanagedRef));
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
