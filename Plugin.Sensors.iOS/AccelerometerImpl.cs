using System;
using System.Reactive.Linq;
using CoreMotion;
using Foundation;


namespace Plugin.Sensors
{
    public class AccelerometerImpl : AbstractMotionSensor, IAccelerometer
    {
        protected override bool IsSensorAvailable(CMMotionManager mgr)
        {
            return mgr.AccelerometerAvailable;
        }


        protected override void Start(CMMotionManager mgr, IObserver<MotionReading> ob)
        {
            mgr.StartAccelerometerUpdates(NSOperationQueue.CurrentQueue, (data, err) =>
                ob.OnNext(new MotionReading(data.Acceleration.X, data.Acceleration.Y, data.Acceleration.Z))
            );
        }


        protected override void Stop(CMMotionManager mgr)
        {
            mgr.StopAccelerometerUpdates();
        }


        protected override void SetReportInterval(CMMotionManager mgr, TimeSpan timeSpan)
        {
            mgr.AccelerometerUpdateInterval = timeSpan.TotalSeconds;
        }
    }
}
