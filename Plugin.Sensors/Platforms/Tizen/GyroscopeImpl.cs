using System;


namespace Plugin.Sensors
{
    public class GyroscopeImpl : IGyroscope
    {
        public bool IsAvailable { get; }
        public IObservable<MotionReading> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
