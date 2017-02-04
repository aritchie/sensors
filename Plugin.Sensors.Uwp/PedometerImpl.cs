using System;


namespace Plugin.Sensors
{
    public class PedometerImpl : IPedometer
    {
        public IObservable<bool> IsAvailable()
        {
            throw new NotImplementedException();
        }


        public IObservable<int> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
