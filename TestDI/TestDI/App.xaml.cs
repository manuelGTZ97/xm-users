using System;
using System.Collections.Generic;
using TestDI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Singleton.GetInstance();
            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
