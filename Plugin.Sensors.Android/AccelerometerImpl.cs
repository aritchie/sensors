using System;
using Android.Hardware;


namespace Plugin.Sensors
{
    public class AccelerometerImpl : AbstractSensor<MotionReading>, IAccelerometer
    {
        public AccelerometerImpl() : base(SensorType.Accelerometer)
        {
        }


        protected override MotionReading ToReading(SensorEvent e)
        {
            return new MotionReading(e.Values[0], e.Values[1], e.Values[2]);
        }
    }
}
