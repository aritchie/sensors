using System;
using System.Reactive.Linq;
using Foundation;
using UIKit;


namespace Plugin.Sensors
{
    public class ProximityImpl : IProximity
    {
        public bool IsAvailable => true;


        IObservable<bool> readOb;
        public IObservable<bool> WhenReadingTaken()
        {
            this.readOb = this.readOb ?? Observable.Create<bool>(ob =>
                NSNotificationCenter
                    .DefaultCenter
                    .AddObserver(
                        UIDevice.ProximityStateDidChangeNotification,
                        _ => ob.OnNext(UIDevice.CurrentDevice.ProximityState)
                    )
            );
            return this.readOb;
        }
    }
}
