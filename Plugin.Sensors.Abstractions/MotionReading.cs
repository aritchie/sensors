using System;


namespace Plugin.Sensors
{
    public class MotionReading
    {
        public MotionReading(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }


        public double X { get; }
        public double Y { get; }
        public double Z { get; }
    }
}
