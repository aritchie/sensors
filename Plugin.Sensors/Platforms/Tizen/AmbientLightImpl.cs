using System;


namespace Plugin.Sensors
{
    public class AmbientLightImpl : IAmbientLight
    {
        public bool IsAvailable { get; }
        public IObservable<double> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
