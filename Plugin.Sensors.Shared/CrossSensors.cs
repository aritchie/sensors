using System;


namespace Plugin.Sensors
{
    public static class CrossSensors
    {
        static IAccelerometer customAccel;

        public static IAccelerometer Accelerometer
        {
            get
            {
#if PCL
                if (customAccel == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");

                return customAccel;
#else
                customAccel = customAccel ?? new AccelerometerImpl();
                return customAccel;
#endif
            }
            set { customAccel = value; }
        }


        static IAmbientLight customLight;

        public static IAmbientLight AmbientLight
        {
            get
            {
#if PCL
                if (customLight == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");

                return customLight;
#else
                customLight = customLight ?? new AmbientLightImpl();
                return customLight;
#endif
            }
            set { customLight = value; }
        }


        static IBarometer customBaro;

        public static IBarometer Barometer
        {
            get
            {
#if PCL
                if (customBaro == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");

                return customBaro;
#else
                customBaro = customBaro ?? new BarometerImpl();
                return customBaro;
#endif
            }
            set { customBaro = value; }
        }


        static ICompass customCompass;
        public static ICompass Compass
        {
            get
            {
#if PCL
                if (customCompass == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");

                return customCompass;
#else
                customCompass = customCompass ?? new CompassImpl();
                return customCompass;
#endif
            }
            set { customCompass = value; }
        }


        static IGyroscope customGyro;
        public static IGyroscope Gyroscope
        {
            get
            {
#if PCL
                if (customGyro == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");

                return customGyro;
#else
                customGyro = customGyro ?? new GyroscopeImpl();
                return customGyro;
#endif
            }
            set { customGyro = value; }
        }


        static IMagnetometer customMagnetometer;

        public static IMagnetometer Magnetometer
        {
            get
            {
#if PCL
                if (customMagnetometer == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");

                return customMagnetometer;
#else
                customMagnetometer = customMagnetometer ?? new MagnetometerImpl();
                return customMagnetometer;
#endif
            }
            set { customMagnetometer = value; }
        }



        static IPedometer customPedometer;
        public static IPedometer Pedometer
        {
            get
            {
#if PCL
                if (customPedometer == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");

                return customPedometer;
#else
                customPedometer = customPedometer ?? new PedometerImpl();
                return customPedometer;
#endif
            }
            set { customPedometer = value; }
        }


        static IProximity customProximity;
        public static IProximity Proximity
        {
            get
            {
#if PCL
                if (customProximity == null)
                    throw new ArgumentException("[Plugin.Sensors] This is the bait PCL library.  Make sure to install the nuget package into your platform projects as well!");

                return customProximity;
#else
                customProximity = customProximity ?? new ProximityImpl();
                return customProximity;
#endif
            }
            set { customProximity = value; }
        }
    }
}
