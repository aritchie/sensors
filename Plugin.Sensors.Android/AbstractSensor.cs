using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Android.App;
using Android.Content;
using Android.Hardware;


namespace Plugin.Sensors
{
    public abstract class AbstractSensor<T>
    {
		readonly SensorManager sensorManager;
		readonly SensorType type;
		protected bool IsSensorAvailable { get; }

        protected AbstractSensor(SensorType type)
        {
            this.type = type;
			this.sensorManager = (SensorManager)Application.Context.GetSystemService(Context.SensorService);
			this.IsSensorAvailable = this.sensorManager.GetSensorList(type).Any();
        }


        protected abstract T ToReading(SensorEvent e);


		public virtual IObservable<bool> IsAvailable() => Observable.Return(this.IsSensorAvailable);
		public TimeSpan ReportInterval { get; set; } = TimeSpan.FromMilliseconds(500);



        IObservable<T> readOb;
        public IObservable<T> WhenReadingTaken()
        {
            this.readOb = this.readOb ?? Observable.Create<T>(ob =>
            {
				var mgr = new AcrSensorManager(this.sensorManager);
                var delay = this.ToSensorDelay(this.ReportInterval);

                mgr.Start(this.type, delay, e =>
                {
                    var reading = this.ToReading(e);
                    ob.OnNext(reading);
                });
                return () => mgr.Stop();
            })
            .Publish()
            .RefCount();

            return this.readOb;
        }


        protected SensorDelay ToSensorDelay(TimeSpan timeSpan)
        {
            if (timeSpan.TotalMilliseconds <= 100)
                return SensorDelay.Fastest;

            if (timeSpan.TotalMilliseconds <= 250)
                return SensorDelay.Game;

            if (timeSpan.TotalMilliseconds <= 500)
                return SensorDelay.Ui;

           return SensorDelay.Normal;
        }
    }
}