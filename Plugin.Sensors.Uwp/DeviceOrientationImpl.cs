using System;
using System.Reactive.Linq;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Graphics.Display;


namespace Plugin.Sensors
{
    public class DeviceOrientationImpl : IDeviceOrientation
    {
        public bool IsAvailable => Gyrometer.GetDefault() != null;


        IObservable<DeviceOrientation> readOb;
        public IObservable<DeviceOrientation> WhenReadingTaken()
        {
            this.readOb = this.readOb ?? Observable.Create<DeviceOrientation>(ob =>
            {
                var displayInfo = DisplayInformation.GetForCurrentView();
                this.Broadcast(ob, displayInfo); // startwith
                var handler = new TypedEventHandler<DisplayInformation, object>((sender, args) => this.Broadcast(ob, displayInfo));
                displayInfo.OrientationChanged += handler;

                return () => displayInfo.OrientationChanged -= handler;
            })
            .Publish()
            .RefCount()
            .Repeat(1);

            return this.readOb;
        }


        void Broadcast(IObserver<DeviceOrientation> ob, DisplayInformation displayInfo)
        {
            switch (displayInfo.CurrentOrientation)
            {
                case DisplayOrientations.Landscape:
                    ob.OnNext(DeviceOrientation.LandscapeLeft);
                    break;

                case DisplayOrientations.Portrait:
                    ob.OnNext(DeviceOrientation.Portrait);
                    break;

                case DisplayOrientations.LandscapeFlipped:
                    ob.OnNext(DeviceOrientation.LandscapeRight);
                    break;

                case DisplayOrientations.PortraitFlipped:
                    ob.OnNext(DeviceOrientation.PortraitUpsideDown);
                    break;
            }
        }
    }
}