using System;
using System.Collections.Generic;
using Android.Hardware;


namespace Plugin.Sensors
{
    public class ProximityImpl : AbstractSensor<bool>
    {
        public ProximityImpl() : base(SensorType.Proximity)
        {
        }


        protected override bool ToReading(IList<float> values)
        {

        }
    }
}