using System;
using System.Reactive.Linq;
using Android.App;
using Android.Content;
using Android.Hardware;


namespace Plugin.Sensors
{
    public class CompassImpl : ICompass
    {
        readonly SensorManager sensorManager;


        public CompassImpl()
        {
            this.sensorManager = (SensorManager)Application.Context.GetSystemService(Context.SensorService);
            //var mgr = new AcrSensorManager(this.sensorManager);
            //var delay = this.ToSensorDelay(this.ReportInterval);
        }


        public IObservable<bool> IsAvailable()
        {
            return Observable.Return(false);
        }


        public IObservable<CompassReading> WhenReadingTaken()
        {
            return Observable.Empty<CompassReading>();
        }
    }
}