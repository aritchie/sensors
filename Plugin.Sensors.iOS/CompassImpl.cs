using System;
using System.Reactive.Linq;
using CoreLocation;


namespace Plugin.Sensors
{
    public class CompassImpl : ICompass
    {
        public IObservable<bool> IsAvailable()
        {
            return Observable.Return(true);
        }


        IObservable<double> readOb;
        public IObservable<double> WhenReadingTaken()
        {
            this.readOb = this.readOb ?? Observable.Create<double>(ob =>
            {
                var handler = new EventHandler<CLHeadingUpdatedEventArgs>((sender, args) =>
                {
                    // TODO: TrueHeading, MagneticHeading, Accuracy
                    ob.OnNext(args.NewHeading.TrueHeading);
                });
                var lm = new CLLocationManager
                {
                    DesiredAccuracy = CLLocation.AccuracyBest,
                    HeadingFilter = 1
                };
                lm.UpdatedHeading += handler;
                lm.StartUpdatingHeading();

                return () =>
                {
                    lm.StopUpdatingHeading();
                    lm.UpdatedHeading -= handler;
                };
            })
            .Publish()
            .RefCount();

            return this.readOb;
        }
    }
}
