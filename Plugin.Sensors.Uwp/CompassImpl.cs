using System;
using System.Reactive.Linq;
using Windows.Devices.Sensors;
using Windows.Foundation;


namespace Plugin.Sensors
{
    public class CompassImpl : ICompass
    {
        readonly Compass compass;


        public CompassImpl()
        {
            this.compass = Compass.GetDefault();
        }


        public IObservable<bool> IsAvailable()
        {
            return Observable.Return(this.compass != null);
        }


        IObservable<CompassReading> readOb;
        public IObservable<CompassReading> WhenReadingTaken()
        {
            this.readOb = this.readOb ?? Observable.Create<CompassReading>(ob =>
            {
                var handler = new TypedEventHandler<Compass, CompassReadingChangedEventArgs>((sender, args) =>
                {
                    //ob.OnNext(new CompassReading(args.Reading.HeadingAccuracy.Unknown, args.Reading.HeadingMagneticNorth, args.Reading?.HeadingTrueNorth ?? 0));
                });
                this.compass.ReportInterval = 0;
                this.compass.ReadingChanged += handler;

                return () =>
                {
                    this.compass.ReadingChanged -= handler;
                };
            });
            return this.readOb;
        }
    }
}
