using System;
using System.Reactive.Linq;
using Plugin.Sensors;
using ReactiveUI;


namespace Sample
{
    public class AccelerometerViewModel : AbstractMotionViewModel
    {
        IDisposable sensorSub;


        public AccelerometerViewModel()
        {
            this.Toggle = ReactiveCommand.Create(() =>
            {
                if (this.sensorSub == null)
                {
                    this.ToggleText = "Stop";
                    this.sensorSub = CrossSensors.Accelerometer.WhenReadingTaken().Subscribe(this.Update);
                }
                else
                {
                    this.ToggleText = "Start";
                    this.sensorSub.Dispose();
                    this.sensorSub = null;
                }
            }, Observable.Return(CrossSensors.Accelerometer.IsAvailable));
        }
    }
}
