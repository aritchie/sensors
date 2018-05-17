using System;


namespace Plugin.Sensors
{
    public interface ISensor<out T>
    {
        bool IsAvailable { get; }
        IObservable<T> WhenReadingTaken();
    }
}
