using System;
using Android.Hardware;


namespace Plugin.Sensors
{
    public class BarometerImpl : AbstractSensor<double>, IBarometer
    {
        public BarometerImpl() : base(SensorType.Pressure) {}


        protected override double ToReading(SensorEvent e) => e.Values[0];
    }
}