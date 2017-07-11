using System;


namespace Plugin.Sensors
{
    public class DeviceOrientationImpl : IDeviceOrientation
    {
        public bool IsAvailable { get; }
        public IObservable<DeviceOrientation> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
