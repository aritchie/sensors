using System;
using Android.Hardware;


namespace Plugin.Sensors
{
    public class AmbientLightImpl : AbstractSensor<double>, IAmbientLight
    {
        public AmbientLightImpl() : base(SensorType.Light)
        {
        }


        protected override double ToReading(SensorEvent e)
        {
            return e.Values[0];
        }
    }
}