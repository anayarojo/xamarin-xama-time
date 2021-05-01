using System;
using System.Threading.Tasks;
using XamaTime.Models;

namespace XamaTime.Services
{
    public class ClockService
    {
        private TimeZoneInfo _timeZone;

        public ClockService(TimeZoneInfo timeZone)
        {
            _timeZone = timeZone;
        }

        public void SetTimeZone(TimeZoneInfo timeZone)
        {
            _timeZone = timeZone;
        }

        public Task<ClockTime> GetNowClockTime()
        {
            var utcNow = DateTime.UtcNow;
            var tzNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, _timeZone);

            var clockTime = new ClockTime()
            {
                Now = tzNow,
                TimeZone = _timeZone
            };

            return Task.FromResult(clockTime);
        }
    }
}