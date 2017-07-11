using System;


namespace Plugin.Sensors
{
    public class AccelerometerImpl : IAccelerometer
    {
        public bool IsAvailable { get; }
        public IObservable<MotionReading> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
