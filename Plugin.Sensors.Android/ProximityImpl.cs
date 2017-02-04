using System;
using Android.Hardware;


namespace Plugin.Sensors
{
    public class ProximityImpl : AbstractSensor<bool>
    {
        public ProximityImpl() : base(SensorType.Proximity)
        {
        }


        protected override bool ToReading(SensorEvent e)
        {
            return true;
        }
    }
}