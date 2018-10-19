using System;


namespace Plugin.Sensors
{
    public static partial class CrossSensors
    {
        const string ERROR = "[Plugin.Sensors] This is the bait library.  Make sure to install the nuget package into your platform projects as well!";


        static IAccelerometer currentAccel;
        public static IAccelerometer Accelerometer
        {
            get
            {
                if (currentAccel == null)
                    throw new ArgumentException(ERROR);

                return currentAccel;
            }
            set => currentAccel = value;
        }


        static IAmbientLight currentLight;
        public static IAmbientLight AmbientLight
        {
            get
            {
                if (currentLight == null)
                    throw new ArgumentException(ERROR);

                return currentLight;
            }
            set => currentLight = value;
        }


        static IBarometer currentBaro;
        public static IBarometer Barometer
        {
            get
            {
                if (currentBaro == null)
                    throw new ArgumentException(ERROR);

                return currentBaro;
            }
            set => currentBaro = value;
        }


        static ICompass currentCompass;
        public static ICompass Compass
        {
            get
            {
                if (currentCompass == null)
                    throw new ArgumentException(ERROR);

                return currentCompass;
            }
            set => currentCompass = value;
        }


        static IDeviceOrientation currentDeviceOrientation;
        public static IDeviceOrientation DeviceOrientation
        {
            get
            {
                if (currentDeviceOrientation == null)
                    throw new ArgumentException(ERROR);

                return currentDeviceOrientation;
            }
            set => currentDeviceOrientation = value;
        }


        static IGyroscope currentGyro;
        public static IGyroscope Gyroscope
        {
            get
            {
                if (currentGyro == null)
                    throw new ArgumentException(ERROR);

                return currentGyro;
            }
            set => currentGyro = value;
        }


        static IMagnetometer currentMagnetometer;
        public static IMagnetometer Magnetometer
        {
            get
            {
                if (currentMagnetometer == null)
                    throw new ArgumentException(ERROR);

                return currentMagnetometer;
            }
            set => currentMagnetometer = value;
        }


        //static IMotionActivity currentMA;
        //public static IMotionActivity MotionActivity
        //{
        //    get
        //    {
        //        if (currentMA == null)
        //            throw new ArgumentException(ERROR);

        //        return currentMA;
        //    }
        //    set => currentMA = value;
        //}


        static IPedometer currentPedometer;
        public static IPedometer Pedometer
        {
            get
            {
                if (currentPedometer == null)
                    throw new ArgumentException(ERROR);

                return currentPedometer;
            }
            set => currentPedometer = value;
        }


        static IProximity currentProximity;
        public static IProximity Proximity
        {
            get
            {
                if (currentProximity == null)
                    throw new ArgumentException(ERROR);

                return currentProximity;
            }
            set => currentProximity = value;
        }
    }
}
