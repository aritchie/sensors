using System;
using System.Reactive.Linq;
using System.Windows.Input;
using Plugin.Sensors;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Xamarin.Forms;


namespace Sample
{
    public class SensorViewModel<TReading> : ReactiveObject, ISensorViewModel
    {
        IDisposable sensorSub;


        public SensorViewModel(ISensor<TReading> sensor, string valueName, string title = null)
        {
            this.Title = title ?? sensor.GetType().Name.Replace("Impl", String.Empty);
            this.ValueName = valueName;
            this.ToggleText = sensor.IsAvailable ? "Start" : "Sensor Not Available";

            this.Toggle = ReactiveCommand.Create(() =>
            {
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
            }, Observable.Return(sensor.IsAvailable));
        }


        public string Title { get; }
        public ICommand Toggle { get; }
        public string ValueName { get; }
        [Reactive] public string Value { get; private set; }
        [Reactive] public string ToggleText { get; private set; }


        protected virtual void Update(TReading reading)
        {
            Device.BeginInvokeOnMainThread(() =>
                this.Value = reading.ToString()
            );
        }
    }
}
