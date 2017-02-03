using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.Sensors;
using Xamarin.Forms;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Sample
{
    public abstract class AbstractMotionViewModel : ReactiveObject
    {
        public ICommand Toggle { get; protected set; }
        [Reactive] public string ToggleText { get; protected set; } = "Start";
        [Reactive] public bool IsSupported { get; protected set; }
        [Reactive] public double XAxis { get; protected set; }
        [Reactive] public double YAxis { get; protected set; }
        [Reactive] public double ZAxis { get; protected set; }


        protected virtual void Update(MotionReading reading)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                this.XAxis = reading.X;
                this.YAxis = reading.Y;
                this.ZAxis = reading.Z;
            });
        }
    }
}
