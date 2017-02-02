using System;
using Plugin.Sensors;
using ReactiveUI;


namespace Sample
{
    public class MagnetometerViewModel : AbstractMotionViewModel
    {
        IDisposable sensorSub;


        public MagnetometerViewModel()
        {
            this.Toggle = ReactiveCommand.Create(() =>
            {
                if (this.sensorSub == null)
                {
                    this.ToggleText = "Stop";
                    this.sensorSub = CrossSensors.Magnetometer.WhenReadingTaken().Subscribe(this.Update);
                }
                else
                {
                    this.ToggleText = "Start";
                    this.sensorSub.Dispose();
                    this.sensorSub = null;
                }
            },
            CrossSensors.Magnetometer.IsAvailable());
        }
    }
}
