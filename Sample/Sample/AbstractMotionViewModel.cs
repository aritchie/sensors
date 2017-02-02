using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.Sensors;
using PropertyChanged;
using Xamarin.Forms;


namespace Sample
{
    [ImplementPropertyChanged]
    public abstract class AbstractMotionViewModel : INotifyPropertyChanged
    {
        public ICommand Toggle { get; protected set; }
        public string ToggleText { get; set; } = "Start";
        public bool IsSupported { get; set; }
        public double XAxis { get; set; }
        public double YAxis { get; set; }
        public double ZAxis { get; set; }


        protected virtual void Update(MotionReading reading)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                this.XAxis = reading.X;
                this.YAxis = reading.Y;
                this.ZAxis = reading.Z;
            });
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
