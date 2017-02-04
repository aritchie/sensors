using System;


namespace Plugin.Sensors
{
    public interface ISensor<out T>
    {
        IObservable<bool> IsAvailable();
        IObservable<T> WhenReadingTaken();
    }
}
