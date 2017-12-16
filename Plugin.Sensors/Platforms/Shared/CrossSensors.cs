using System;


namespace Plugin.Sensors
{
    public static class CrossSensors
    {

        static IAccelerometer currentAccel;
        public static IAccelerometer Accelerometer
        {
            get
            {
#if BAIT
                if (currentAccel == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");
#else
                currentAccel = currentAccel ?? new AccelerometerImpl();
#endif
                return currentAccel;
            }
            set { currentAccel = value; }
        }


        static IAmbientLight currentLight;
        public static IAmbientLight AmbientLight
        {
            get
            {
#if BAIT
                if (currentLight == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");
#else
                currentLight = currentLight ?? new AmbientLightImpl();
#endif
                return currentLight;
            }
            set => currentLight = value;
        }


        static IBarometer currentBaro;
        public static IBarometer Barometer
        {
            get
            {
#if BAIT
                if (currentBaro == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");
#else
                currentBaro = currentBaro ?? new BarometerImpl();
#endif
                return currentBaro;
            }
            set => currentBaro = value;
        }


        static ICompass currentCompass;
        public static ICompass Compass
        {
            get
            {
#if BAIT
                if (currentCompass == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");
#else
                currentCompass = currentCompass ?? new CompassImpl();
#endif
                return currentCompass;
            }
            set => currentCompass = value;
        }


        static IDeviceOrientation currentDeviceOrientation;
        public static IDeviceOrientation DeviceOrientation
        {
            get
            {
#if BAIT
                if (currentDeviceOrientation == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");
#else
                currentDeviceOrientation = currentDeviceOrientation ?? new DeviceOrientationImpl();
#endif
                return currentDeviceOrientation;
            }
            set => currentDeviceOrientation = value;
        }

        static IGyroscope currentGyro;
        public static IGyroscope Gyroscope
        {
            get
            {
#if BAIT
                if (currentGyro == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");
#else
                currentGyro = currentGyro ?? new GyroscopeImpl();
#endif
                return currentGyro;
            }
            set => currentGyro = value;
        }


        static IMagnetometer currentMagnetometer;

        public static IMagnetometer Magnetometer
        {
            get
            {
#if BAIT
                if (currentMagnetometer == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");
#else
                currentMagnetometer = currentMagnetometer ?? new MagnetometerImpl();
#endif
                return currentMagnetometer;
            }
            set => currentMagnetometer = value;
        }



        static IPedometer currentPedometer;
        public static IPedometer Pedometer
        {
            get
            {
#if BAIT
                if (currentPedometer == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");
#else
                currentPedometer = currentPedometer ?? new PedometerImpl();
#endif
                return currentPedometer;
            }
            set => currentPedometer = value;
        }


        static IProximity currentProximity;
        public static IProximity Proximity
        {
            get
            {
#if BAIT
                if (currentProximity == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");
#else
                currentProximity = currentProximity ?? new ProximityImpl();
#endif
                return currentProximity;
            }
            set => currentProximity = value;
        }
    }
}
