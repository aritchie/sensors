using System;


namespace Plugin.Sensors
{
    public class AmbientLightImpl : IAmbientLight
    {
        public IObservable<bool> IsAvailable()
        {
            throw new NotImplementedException();
        }


        public IObservable<double> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
