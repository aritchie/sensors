using System;


namespace Plugin.Sensors
{
    public interface IMotionSensor : ISensor<MotionReading>
    {
        TimeSpan ReportInterval { get; set; }
    }
}
