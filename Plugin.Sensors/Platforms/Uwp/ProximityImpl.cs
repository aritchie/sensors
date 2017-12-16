using System;
using Windows.Devices.Sensors;


namespace Plugin.Sensors
{
    public class ProximityImpl : IProximity
    {
        public ProximityImpl()
        {
            //ProximitySensor.GetReadingsFromTriggerDetails()
        }


        public bool IsAvailable => false;


        public IObservable<bool> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
