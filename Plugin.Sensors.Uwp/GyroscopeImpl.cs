using System;
using System.Reactive.Linq;
using Windows.Devices.Sensors;
using Windows.Foundation;


namespace Plugin.Sensors
{
    public class GyroscopeImpl : IGyroscope
    {
        readonly Gyrometer gyrometer;


        public GyroscopeImpl()
        {
            this.gyrometer = Gyrometer.GetDefault();
        }


        public TimeSpan ReportInterval { get; set; }
        public bool IsAvailable => this.gyrometer != null;


        IObservable<MotionReading> readOb;
        public IObservable<MotionReading> WhenReadingTaken()
        {
            this.readOb = this.readOb ?? Observable.Create<MotionReading>(ob =>
            {
                var handler = new TypedEventHandler<Gyrometer, GyrometerReadingChangedEventArgs>((sender, args) =>
                    ob.OnNext(new MotionReading(
                        args.Reading.AngularVelocityX,
                        args.Reading.AngularVelocityY,
                        args.Reading.AngularVelocityZ
                    ))
                );
                //this.gyrometer.ReportInterval = this.ReportInterval.TotalSeconds;
                this.gyrometer.ReadingChanged += handler;

                return () => this.gyrometer.ReadingChanged -= handler;
            });
            return this.readOb;
        }
    }
}
