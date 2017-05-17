using System;
using System.Collections.Generic;
using Plugin.Sensors;


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
                new SensorViewModel<double>(CrossSensors.AmbientLight, "Light"),
                new SensorViewModel<double>(CrossSensors.Barometer, "Pressure"),
                new SensorViewModel<int>(CrossSensors.Pedometer, "Steps"),
                new SensorViewModel<bool>(CrossSensors.Proximity, "Near")
            };
        }
    }
}
