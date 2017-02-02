using System;
using System.Reactive.Linq;


namespace Plugin.Sensors
{
    public class MagnetometerImpl : IMagnetometer
    {
        public TimeSpan ReportInterval { get; set; }


        public IObservable<bool> IsAvailable()
        {
            return Observable.Return(false);
        }


        public IObservable<MotionReading> WhenReadingTaken()
        {
            return Observable.Empty<MotionReading>();
        }
    }
}
