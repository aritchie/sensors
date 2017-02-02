using System;


namespace Plugin.Sensors
{
    public interface IGyroscope
    {
        // TODO: uncalibrated seems to be a common option
        TimeSpan ReportInterval { get; set; }
        IObservable<bool> IsAvailable();
        IObservable<MotionReading> WhenReadingTaken();
    }
}
