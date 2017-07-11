using System;


namespace Plugin.Sensors
{
    public class MagnetometerImpl : IMagnetometer
    {
        public bool IsAvailable { get; }
        public IObservable<MotionReading> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
