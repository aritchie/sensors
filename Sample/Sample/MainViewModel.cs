using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Plugin.Sensors;
using ReactiveUI;


namespace Sample
{
    public class MainViewModel
    {

        public List<ISensorViewModel> Sensors { get; }


        public MainViewModel()
        {
            this.Sensors = new List<ISensorViewModel>
            {
                new SensorViewModel<MotionReading>(CrossSensors.Accelerometer, "G"),
                new SensorViewModel<MotionReading>(CrossSensors.Gyroscope, "G"),
                new SensorViewModel<MotionReading>(CrossSensors.Magnetometer, "M"),
                new SensorViewModel<CompassReading>(CrossSensors.Compass, "D"),
                new SensorViewModel<DeviceOrientation>(CrossSensors.DeviceOrientation, "Position"),
                new SensorViewModel<double>(CrossSensors.AmbientLight, "Light"),
                new SensorViewModel<double>(CrossSensors.Barometer, "Pressure"),
                new SensorViewModel<int>(CrossSensors.Pedometer, "Steps"),
                new SensorViewModel<bool>(CrossSensors.Proximity, "Near")
            };
            CrossSensors
                .MotionActivity
                .WhenActivityChanged()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(x => this.MotionActivities.Add(new MotionActivityViewModel
                {
                    Text = $"{x.Motions} ({x.Confidence})",
                    Detail = x.StartDate.ToString()
                }));
        }


        public bool IsMotionActivityAvailable => CrossSensors.MotionActivity.IsSupported;
        public ObservableCollection<MotionActivityViewModel> MotionActivities { get; } = new ObservableCollection<MotionActivityViewModel>();
    }


    public class MotionActivityViewModel
    {
        public string Text { get; set; }
        public string Detail { get; set; }
    }
}
