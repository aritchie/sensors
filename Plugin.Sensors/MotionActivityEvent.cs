using System;


namespace Plugin.Sensors
{
    [Flags]
    public enum MotionFlags
    {
        Unknown = 1,
        Stationary = 2,
        Walking = 4,
        Running = 8,
        Automotive = 16,
        Cycling = 32
    }


    public enum Confidence
    {
        Low,
        Medium,
        High
    }

    public class MotionActivityEvent
    {
        public MotionActivityEvent(MotionFlags flags, Confidence confidence, DateTime dt)
        {
            this.Motions = flags;
            this.Confidence = confidence;
            this.StartDate = dt;
        }


        public MotionFlags Motions { get; }
        public Confidence Confidence { get; }
        public DateTime StartDate { get; }
    }
}
