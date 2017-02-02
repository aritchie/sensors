using System;
using Android.App;
using Android.Content;
using Android.Hardware;


namespace Plugin.Sensors
{
    public class AcrSensorManager : Java.Lang.Object, ISensorEventListener
    {
        SensorManager sensorManager;
        Action<SensorEvent> action;


        public bool Start(SensorType sensorType, SensorDelay delay, Action<SensorEvent> sensorAction)
        {
            this.action = sensorAction;
            this.sensorManager = (SensorManager)Application.Context.GetSystemService(Context.SensorService);
            var sensor = this.sensorManager.GetDefaultSensor(sensorType);
            var result = this.sensorManager.RegisterListener(this, sensor, delay);
            return result;
        }


        public void Stop()
        {
            this.sensorManager.UnregisterListener(this);
        }


        public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
        {
        }


        public void OnSensorChanged(SensorEvent e)
        {
            this.action(e);
        }
    }
}