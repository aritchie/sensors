using System;
using Windows.Devices.Sensors;


namespace Plugin.Sensors
{
    public class PedometerImpl : IPedometer
    {
        //readonly Pedometer pedometer;


        public PedometerImpl()
        {
            //this.pedometer = Pedometer.GetDefaultAsync();
        }


        public bool IsAvailable => false;


        public IObservable<int> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
