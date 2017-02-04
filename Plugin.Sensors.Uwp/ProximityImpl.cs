using System;


namespace Plugin.Sensors
{
    public class ProximityImpl : IProximity
    {
        public IObservable<bool> IsAvailable()
        {
            throw new NotImplementedException();
        }


        public IObservable<bool> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
