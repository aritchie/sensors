using System;


namespace Plugin.Sensors
{
    public class BarometerImpl : IBarometer
    {
        public BarometerImpl()
        {

        }


        public IObservable<bool> IsAvailable()
        {
            throw new NotImplementedException();
        }


        public IObservable<double> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
/*
 Barometer barometer = Barometer.GetDefault();
BarometerReading reading = barometer.GetCurrentReading();

double pressure = reading.StationPressureInHectopascals;
barometer.ReadingChanged += ...

Altimeter altimeter = Altimeter.GetDefault();
AltimeterReading altimeterReading = altimeter.GetCurrentReading();

double altitudeChange = altimeterReading.AltitudeChangeInMeters;
altimeter.ReadingChanged += ...

//Selecting a report interval
mySensor.ReportInterval = 500;
     */
