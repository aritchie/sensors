using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Android.Hardware;


namespace Plugin.Sensors
{
    public abstract class AbstractSensor<T>
    {
        readonly SensorType type;


        protected AbstractSensor(SensorType type)
        {
            this.type = type;
        }


        protected abstract T ToReading(IList<float> values);


        public virtual IObservable<bool> IsAvailable() => Observable.Return(true);
        public TimeSpan ReportInterval { get; set; }

        IObservable<T> readOb;
        public IObservable<T> WhenReadingTaken()
        {
            this.readOb = this.readOb ?? Observable.Create<T>(ob =>
            {
                var mgr = new AcrSensorManager();
                mgr.Start(this.type, this.ToSensorDelay(this.ReportInterval), e =>
                {
                    var reading = this.ToReading(e.Values);
                    ob.OnNext(reading);
                });
                return () => mgr.Stop();
            })
            .Publish()
            .RefCount();

            return this.readOb;
        }


        public IObservable<object> WhenShaken()
        {
            //http://stackoverflow.com/questions/5271448/how-to-detect-shake-event-with-android
            throw new NotImplementedException();
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