using System;
using Android.Hardware;


namespace Plugin.Sensors
{
    public class ProximityImpl : AbstractSensor<bool>, IProximity
    {
        public ProximityImpl() : base(SensorType.Proximity)
        {
        }


        protected override bool ToReading(SensorEvent e)
        {
            if (e.Values[0] < e.Sensor.MaximumRange)
             // Detected something nearby
                return true;
            else
             // Nothing is nearby
                return false;
        }
    }
}
