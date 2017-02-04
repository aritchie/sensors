using System;
using System.Reactive.Linq;
using CoreMotion;
using Foundation;


namespace Plugin.Sensors
{
    public class PedometerImpl : IPedometer
    {
        public bool IsAvailable => CMStepCounter.IsStepCountingAvailable;


        IObservable<int> stepOb;
        public IObservable<int> WhenReadingTaken()
        {
            this.stepOb = this.stepOb ?? Observable.Create<int>(ob =>
            {
                var scm = new CMStepCounter();
                scm.StartStepCountingUpdates(NSOperationQueue.CurrentQueue, 10, (steps, timestamp, error) =>
                    ob.OnNext((int)steps)
                );
                return () =>
                {
                    scm.StopStepCountingUpdates();
                    scm.Dispose();
                };
            })
            .Publish()
            .RefCount();

            return this.stepOb;
        }
    }
}
