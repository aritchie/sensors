using System;
using System.Reactive.Linq;


namespace Plugin.Sensors
{
    public class DeviceOrientationImpl : IDeviceOrientation
    {
        public bool IsAvailable { get; }


        IObservable<DeviceOrientation> readOb;
        public IObservable<DeviceOrientation> WhenReadingTaken()
        {
            this.readOb = this.readOb ?? Observable.Create<DeviceOrientation>(ob =>
            {
                return () =>
                {
                };
            })
            .Publish()
            .RefCount();

            return this.readOb;
        }
    }
}