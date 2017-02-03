using System;


namespace Plugin.Sensors
{
    public interface ICompass
    {
        IObservable<bool> IsAvailable();
        IObservable<CompassReading> WhenReadingTaken();
    }
}
