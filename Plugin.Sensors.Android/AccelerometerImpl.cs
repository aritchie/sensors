using System;
using System.Collections.Generic;
using Android.Hardware;


namespace Plugin.Sensors
{
    public class AccelerometerImpl : AbstractSensor<MotionReading>, IAccelerometer
    {
        public AccelerometerImpl() : base(SensorType.Accelerometer)
        {
        }


        protected override MotionReading ToReading(IList<float> values)
        {
            return new MotionReading(values[0], values[1], values[2]);
        }
    }
}
