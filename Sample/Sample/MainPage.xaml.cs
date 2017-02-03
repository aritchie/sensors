using System;
using Xamarin.Forms;


namespace Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
			this.accelSection.BindingContext = new AccelerometerViewModel();
			this.gyroSection.BindingContext = new GyroscopeViewModel();
			this.magnetSection.BindingContext = new MagnetometerViewModel();
        }
    }
}
