using System;


namespace Plugin.Sensors
{
    public interface IBarometer
    {
        IObservable<bool> IsAvailable();
        IObservable<double> WhenReadingTaken();
    }
}
