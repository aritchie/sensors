using System;


namespace Plugin.Sensors
{
    public static partial class CrossSensors
    {
        static CrossSensors()
        {
            Accelerometer = new AccelerometerImpl();
            AmbientLight = new AmbientLightImpl();
            Barometer = new BarometerImpl();
            Compass = new CompassImpl();
            DeviceOrientation = new DeviceOrientationImpl();
            Gyroscope = new GyroscopeImpl();
            Magnetometer = new MagnetometerImpl();
            MotionActivity = new MotionActivityImpl();
            Pedometer = new PedometerImpl();
            Proximity = new ProximityImpl();
        }
    }
}
