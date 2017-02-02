using System;


namespace Plugin.Sensors
{
    public interface IMagnetometer
    {
        // has uncalibrated version
        TimeSpan ReportInterval { get; set; }
        IObservable<bool> IsAvailable();
        IObservable<MotionReading> WhenReadingTaken();
    }
}
