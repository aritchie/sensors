using System;


namespace Plugin.Sensors
{
    public interface IAccelerometer
    {
        TimeSpan ReportInterval { get; set; }
        IObservable<bool> IsAvailable();
        IObservable<MotionReading> WhenReadingTaken();
        //IObservable<object> WhenShaken();
    }
}
