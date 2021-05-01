using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamaTime.Views;

namespace XamaTime
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
