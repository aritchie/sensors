using System;
using Android.Hardware;


namespace Plugin.Sensors
{
    public class PedometerImpl : AbstractSensor<int>, IPedometer
    {
        public PedometerImpl() : base(SensorType.StepCounter)
        {
        }


        protected override int ToReading(SensorEvent e)
        {
            return Convert.ToInt32(e.Values[0]);
        }
    }
}