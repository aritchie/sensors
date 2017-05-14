﻿using System;
using System.Reactive.Linq;
using Windows.Devices.Sensors;
using Windows.Foundation;


namespace Plugin.Sensors
{
    public class AccelerometerImpl : IAccelerometer
    {
        readonly Accelerometer accel;


        public AccelerometerImpl()
        {
            this.accel = Accelerometer.GetDefault();
        }


        public bool IsAvailable => this.accel != null;


        IObservable<MotionReading> readOb;
        public IObservable<MotionReading> WhenReadingTaken()
        {
            this.readOb = this.readOb ?? Observable.Create<MotionReading>(ob =>
            {
                var handler = new TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>((sender, args) =>
                    ob.OnNext(new MotionReading(
                        args.Reading.AccelerationX,
                        args.Reading.AccelerationY,
                        args.Reading.AccelerationZ
                    ))
                );
                this.accel.ReadingChanged += handler;

                return () => this.accel.ReadingChanged -= handler;
            })
            .Publish()
            .RefCount();

            return this.readOb;
        }


        public IObservable<object> WhenShaken()
        {
            throw new NotImplementedException();
        }
    }
}
