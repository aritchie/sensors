using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.Spi;


namespace Plugin.Sensors.Adxl345.Uwp
{
    // https://developer.microsoft.com/en-us/windows/iot/samples/spiaccelerometer
    public class SpiAccelerometer : AbstractAccelerometer
    {
        const byte SPI_CHIP_SELECT_LINE = 0;        // Chip select line to use
        const byte ACCEL_SPI_RW_BIT = 0x80;         // Bit used in SPI transactions to indicate read/write
        const byte ACCEL_SPI_MB_BIT = 0x40;         // Bit used to indicate multi-byte SPI transactions
        SpiDevice device;


        public override IObservable<bool> IsAvailable()
        {
            return Observable.Create<bool>(async ob =>
            {
                var result = false;
                try
                {
                    await this.InitSpiDevice();
                    result = true;
                }
                finally
                {
                }
                ob.OnNext(result);
                ob.OnCompleted();
            });
        }


        IObservable<MotionReading> readOb;
        public override IObservable<MotionReading> WhenReadingTaken()
        {
            this.readOb = this.readOb ?? Observable.Create<MotionReading>(async ob =>
            {
                await this.InitSpiDevice();
                var readBuffer = new byte[7]; // 2 bytes * 3 axis + 1 padding bytes
                var regAddress = new byte[7]; // register address buffer of size 1 byte + 6 padding

                regAddress[0] = ACCEL_REG_X | ACCEL_SPI_RW_BIT | ACCEL_SPI_MB_BIT;

                var reader = Observable
                    .Interval(this.ReportInterval)
                    .Subscribe(_ =>
                    {
                        this.device.TransferFullDuplex(regAddress, readBuffer);
                        Array.Copy(readBuffer, 1, readBuffer, 0, 6);  // discard first dummy byte from read
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


        protected async Task InitSpiDevice()
        {
            var settings = new SpiConnectionSettings(SPI_CHIP_SELECT_LINE)
            {
                ClockFrequency = 5000000, // 5MHz is the rated speed of the ADXL345 accelerometer
                Mode = SpiMode.Mode3      // The accelerometer expects an idle-high clock polarity, we use Mode3  to set the clock polarity and phase to: CPOL = 1, CPHA = 1
            };
            var deviceInfo = await DeviceInformation.FindAllAsync(SpiDevice.GetDeviceSelector());

            // TODO: NRE check
            var dev = await SpiDevice.FromIdAsync(deviceInfo[0].Id, settings);

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
