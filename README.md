# OpenRealSense

C# wrapper for the cross-platform camera capture for Intel® RealSense™ F200,  R200, SR300 and LR200. See the original C++ project on https://github.com/IntelRealSense/librealsense

_Nuget: Install-Package openrealsense_

*Usage:*

```
var context = Context.Create(11100);
var device = context.GetDevice(0);

device.EnableStream(StreamType.depth, width, height, FormatType.z16, 30);
device.Start();

while (true) {
    device.WaitForFrames();
    var frameInBytes = device.GetFrameData(StreamType.depth).Bytes;
    using (var stream = new MemoryStream(frameInBytes)) {
        using (var reader = new BinaryReader(stream)) {
            //do something with the frame :)
        }
    }
}
```
