﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Skip)]

namespace Sample
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

			this.MainPage = new NavigationPage(new MainPage());
        }
    }
}
