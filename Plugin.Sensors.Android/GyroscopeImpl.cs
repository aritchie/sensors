using System;
using System.Collections.Generic;
using Android.Hardware;


namespace Plugin.Sensors
{
    public class GyroscopeImpl : AbstractSensor<MotionReading>, IGyroscope
    {
        public GyroscopeImpl() : base(SensorType.Gyroscope)
        {
        }


        protected override MotionReading ToReading(IList<float> values)
        {
            return new MotionReading(values[0], values[1], values[2]);
        }
    }
}
