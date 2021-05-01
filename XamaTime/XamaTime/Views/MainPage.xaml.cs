using System;
using Xamarin.Forms;
using XamaTime.ViewModels;

namespace XamaTime.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;
        
        public MainPage()
        {
            InitializeComponent();

            _viewModel = new MainPageViewModel(this);
            BindingContext = _viewModel;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (!_viewModel.UpdateClockTimeCommand.CanExecute(null)) return;

                    _viewModel.UpdateClockTimeCommand.Execute(null);
                });

                return true;
            });
        }
    }
}
