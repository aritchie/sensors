using System;
using System.Reactive.Linq;
using System.Windows.Input;
using Plugin.Sensors;
using Xamarin.Forms;
using PropertyChanged;


namespace Sample
{
    [ImplementPropertyChanged]
    public class SensorViewModel<TReading> : ISensorViewModel
    {
        IDisposable sensorSub;


        public SensorViewModel(ISensor<TReading> sensor, string valueName, string title = null)
        {
            this.Title = title ?? sensor.GetType().Name.Replace("Impl", String.Empty);
            this.ValueName = valueName;
            this.ToggleText = sensor.IsAvailable ? "Start" : "Sensor Not Available";

            this.Toggle = new Command(() =>
            {
                if (!sensor.IsAvailable)
                    return;

                if (this.sensorSub == null)
                {
                    this.ToggleText = "Stop";
                    this.sensorSub = sensor
                        .WhenReadingTaken()
                        .Subscribe(this.Update);
                }
                else
                {
                    this.ToggleText = "Start";
                    this.sensorSub.Dispose();
                    this.sensorSub = null;
                }
            });
        }


        public string Title { get; }
        public ICommand Toggle { get; }
        public string ValueName { get; }
        public string Value { get; set; }
        public string ToggleText { get; set; }


        protected virtual void Update(TReading reading)
        {
            Device.BeginInvokeOnMainThread(() =>
                this.Value = reading.ToString()
            );
        }
    }
}
