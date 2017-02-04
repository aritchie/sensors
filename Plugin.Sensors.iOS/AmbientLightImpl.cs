using System;
using System.Reactive.Linq;


namespace Plugin.Sensors
{
    public class AmbientLightImpl : IAmbientLight
    {
        public IObservable<bool> IsAvailable()
        {
            return Observable.Return(false);
        }


        public IObservable<int> WhenReadingTaken()
        {
            return Observable.Empty<int>();
        }
    }
}
