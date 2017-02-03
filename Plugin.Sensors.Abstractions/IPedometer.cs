using System;

namespace Plugin.Sensors
{
    public interface IPedometer
    {
        IObservable<bool> IsAvailable();
        IObservable<int> WhenReadingTaken();
    }
}
