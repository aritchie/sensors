﻿using System;


namespace Plugin.Sensors
{
    public class CompassReading
    {
        public CompassReading(CompassAccuracy accuracy, double magHeading, double? trueHeading)
        {
            this.Accuracy = accuracy;
            this.MagneticHeading = magHeading;
            this.TrueHeading = trueHeading;
        }


        public CompassAccuracy Accuracy { get; }
        public double MagneticHeading { get; }
        public double? TrueHeading { get; }


        public override string ToString() => $"Magnetic: {this.MagneticHeading} - True: {this.TrueHeading} - Accuracy: {this.Accuracy}";
    }
}
