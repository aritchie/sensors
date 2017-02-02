using System;
using Plugin.Sensors;
using ReactiveUI;


namespace Sample
{
    public class GyroscopeViewModel : AbstractMotionViewModel
    {
        IDisposable sensorSub;


        public GyroscopeViewModel()
        {
            this.Toggle = ReactiveCommand.Create(() =>
            {
                if (this.sensorSub == null)
                {
                    this.ToggleText = "Stop";
                    this.sensorSub = CrossSensors.Gyroscope.WhenReadingTaken().Subscribe(this.Update);
                }
                else
                {
                    this.ToggleText = "Start";
                    this.sensorSub.Dispose();
                    this.sensorSub = null;
                }
            },
            CrossSensors.Gyroscope.IsAvailable());
        }
    }
}
