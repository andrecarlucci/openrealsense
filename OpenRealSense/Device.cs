using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenRealSense.NativeMethods;

namespace OpenRealSense {
    public class Device {
        private IntPtr _device;

        internal Device(IntPtr device) {
            _device = device;
        }

        public string GetDeviceName() {
            return Native.Device.rs_get_device_name(_device);
        }

        public void EnableStream(StreamType stream, int width = 640, int height = 480, FormatType format = FormatType.z16, int framerate = 30) {
            Native.Device.rs_enable_stream(_device, stream, width, height, format, framerate);
        }

        public void Start() {
            Native.Device.rs_start_device(_device);
        }

        public void WaitForFrames() {
            Native.Device.rs_wait_for_frames(_device);
        }

        public FrameData GetFrameData(StreamType stream) {
            var poiterToData = Native.Device.rs_get_frame_data(_device, stream);
            var width = Native.Device.rs_get_stream_width(_device, stream);
            var height = Native.Device.rs_get_stream_height(_device, stream);
            var format = Native.Device.rs_get_stream_format(_device, stream);

            var bitsPerPixel = format.BitsPerPixel();
            var length = bitsPerPixel/8*width*height;
            var b = new byte[length];
            Marshal.Copy(poiterToData, b, 0, length);
            return new FrameData(b, width, height, format);
        }

        public float GetDepthScale() {
            return Native.Device.rs_get_device_depth_scale(_device);
        }

        public void Stop() {
            Native.Device.rs_stop_device(_device);
        }
    }
}
