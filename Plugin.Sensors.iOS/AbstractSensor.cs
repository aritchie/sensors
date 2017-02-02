using System;
using System.Reactive.Linq;
using CoreMotion;


namespace Plugin.Sensors
{
    public abstract class AbstractSensor
    {
        readonly CMMotionManager motionManager = new CMMotionManager();


        protected abstract bool IsSensorAvailable(CMMotionManager mgr);
        protected abstract void Start(CMMotionManager mgr, IObserver<MotionReading> ob);
        protected abstract void Stop(CMMotionManager mgr);
        protected abstract void SetReportInterval(CMMotionManager mgr, TimeSpan timeSpan);


        public IObservable<bool> IsAvailable() => Observable.Return(this.IsSensorAvailable(this.motionManager));


        TimeSpan reportInterval;
        public TimeSpan ReportInterval
        {
            get { return this.reportInterval; }
            set
            {
                this.reportInterval = value;
                this.SetReportInterval(this.motionManager, value);
            }
        }


        IObservable<MotionReading> readOb;
        public IObservable<MotionReading> WhenReadingTaken()
        {
            this.readOb = this.readOb ?? Observable.Create<MotionReading>(ob =>
            {
                this.Start(this.motionManager, ob);
                return () => this.Stop(this.motionManager);
            })
            .Publish()
            .RefCount();

            return this.readOb;
        }
    }
}