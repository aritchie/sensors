using System;
using System.Collections.Generic;
using Android.Hardware;


namespace Plugin.Sensors
{
    public class BarometerImpl : AbstractSensor<double>, IBarometer
    {
        public BarometerImpl() : base(SensorType.Pressure)
        {
        }


        protected override double ToReading(IList<float> values)
        {
            return values[0];
        }
    }
}