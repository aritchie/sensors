using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Windows.Devices.I2c;


namespace Plugin.Sensors.Adxl345.Uwp
{
    // https://developer.microsoft.com/en-us/windows/iot/samples/i2caccelerometer
    public class I2cAccelerometer : AbstractAccelerometer
    {
        const byte ACCEL_I2C_ADDR = 0x53; // 7-bit I2C address of the ADXL345 with SDO pulled low
        I2cDevice device;


        IObservable<MotionReading> readOb;
        public override IObservable<MotionReading> WhenReadingTaken()
        {
            this.readOb = this.readOb ?? Observable.Create<MotionReading>(async ob =>
            {
                await this.InitI2cDevice();

                var readBuffer = new byte[6];
                var reader = Observable
                    .Interval(this.ReportInterval)
                    .Subscribe(_ =>
                    {
                        this.device.WriteRead(RegAddrBuf, readBuffer);
                        var msg = this.ToReading(readBuffer);
                        ob.OnNext(msg);
                    });

                return () =>
                {
                    this.device.Dispose();
                    this.device = null;
                    reader.Dispose();
                };
            })
            .Publish()
            .RefCount();

            return this.readOb;
        }


        protected async Task InitI2cDevice()
        {
            if (this.device != null)
                return;

            var settings = new I2cConnectionSettings(ACCEL_I2C_ADDR)
            {
                BusSpeed = I2cBusSpeed.FastMode,
                SharingMode = I2cSharingMode.Exclusive
            };
            var controller = await I2cController.GetDefaultAsync();

            // Create an I2cDevice with our selected bus controller and I2C settings
            var dev = controller.GetDevice(settings);

            // *
            // * Initialize the accelerometer:
            // *
            // * For this device, we create 2-byte write buffers:
            // * The first byte is the register address we want to write to.
            // * The second byte is the contents that we want to write to the register.
            // *

            // Write the register settings
            try
            {
                dev.Write(WriteBuf_DataFormat);
                dev.Write(WriteBuf_PowerControl);
                this.device = dev;
            }
            // If the write fails display the error and stop running
            catch
            {
                dev.Dispose();
                throw;
            }
        }
    }
}