using System;


namespace Plugin.Sensors.Adxl345.Uwp
{
    public abstract class AbstractAccelerometer : IAccelerometer
    {
        const int ACCEL_RES = 1024;         // The ADXL345 has 10 bit resolution giving 1024 unique values
        const int ACCEL_DYN_RANGE_G = 8;    // The ADXL345 had a total dynamic range of 8G, since we're configuring it to +-4G
        const int UNITS_PER_G = ACCEL_RES / ACCEL_DYN_RANGE_G;  // Ratio of raw int values to G units

        protected static readonly byte[] RegAddrBuf = { ACCEL_REG_X }; // Register address we want to read from
        protected readonly byte[] WriteBuf_DataFormat = { ACCEL_REG_DATA_FORMAT, 0x01 };        // 0x01 sets range to +- 4Gs
        protected readonly byte[] WriteBuf_PowerControl = { ACCEL_REG_POWER_CONTROL, 0x08 };    // 0x08 puts the accelerometer into measurement mode
        protected const byte ACCEL_REG_POWER_CONTROL = 0x2D;  // Address of the Power Control register
        protected const byte ACCEL_REG_DATA_FORMAT = 0x31;    // Address of the Data Format register
        protected const byte ACCEL_REG_X = 0x32;              // Address of the X Axis data register
        protected const byte ACCEL_REG_Y = 0x34;              // Address of the Y Axis data register
        protected const byte ACCEL_REG_Z = 0x36;              // Address of the Z Axis data register


        public TimeSpan ReportInterval { get; set; } = TimeSpan.FromMilliseconds(100);


        public bool IsAvailable => true;
        public abstract IObservable<MotionReading> WhenReadingTaken();


        public IObservable<object> WhenShaken()
        {
            throw new NotImplementedException();
        }


        protected virtual MotionReading ToReading(byte[] readBuffer)
        {
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(readBuffer, 0, 2);
                Array.Reverse(readBuffer, 2, 2);
                Array.Reverse(readBuffer, 4, 2);
            }

            var rawX = BitConverter.ToInt16(readBuffer, 0);
            var rawY = BitConverter.ToInt16(readBuffer, 2);
            var rawZ = BitConverter.ToInt16(readBuffer, 4);

            var axisX = (double)rawX / UNITS_PER_G;
            var axisY = (double)rawY / UNITS_PER_G;
            var axisZ = (double)rawZ / UNITS_PER_G;

            var msg = new MotionReading(axisX, axisY, axisZ);
            return msg;
        }
    }
}
