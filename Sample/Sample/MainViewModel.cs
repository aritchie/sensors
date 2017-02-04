using System;
using Plugin.Sensors;


namespace Sample
{
    public class MainViewModel
    {
        public ISensorViewModel[] Sensors =
        {
            new SensorViewModel<MotionReading>(CrossSensors.Accelerometer, "G"),
            new SensorViewModel<MotionReading>(CrossSensors.Gyroscope, "G"),
            new SensorViewModel<MotionReading>(CrossSensors.Magnetometer, ""),
            new SensorViewModel<double>(CrossSensors.AmbientLight, "Light"),
            new SensorViewModel<double>(CrossSensors.Barometer, "Pressure"),
            new SensorViewModel<int>(CrossSensors.Pedometer, "Steps"),
            new SensorViewModel<bool>(CrossSensors.Proximity, "Near"),
        };
    }
}
