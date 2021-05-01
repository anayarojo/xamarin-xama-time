using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamaTime.Models;
using XamaTime.Services;
using XamaTime.Views;

namespace XamaTime.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly MainPage _mainPage;
        private readonly ClockService _clockService;

        private ClockTime _currentClockTime;
        private TimeZoneInfo _currentTimeZone;

        public ClockTime CurrentClockTime
        {
            get => _currentClockTime;
            set => SetProperty(ref _currentClockTime, value);
        }

        public TimeZoneInfo CurrentTimeZone
        {
            get => _currentTimeZone;
            set
            {
                SetProperty(ref _currentTimeZone, value);
                _clockService.SetTimeZone(value);
            }
        }

        public IEnumerable<TimeZoneInfo> TimeZones { get; }

        public Command UpdateClockTimeCommand { get; }

        public MainPageViewModel(MainPage mainPage)
        {
            _mainPage = mainPage;
            _clockService = new ClockService(TimeZoneInfo.Local);

            Title = "Xama Clock";
            CurrentClockTime = new ClockTime();
            CurrentTimeZone = TimeZoneInfo.Local;
            TimeZones = TimeZoneInfo.GetSystemTimeZones();

            UpdateClockTimeCommand = new Command(async () => await OnUpdateClockTime());
        }

        private async Task OnUpdateClockTime()
        {
            CurrentClockTime = await _clockService.GetNowClockTime();
        }
    }
}
