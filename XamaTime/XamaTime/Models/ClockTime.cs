using System;

namespace XamaTime.Models
{
    public class ClockTime
    {
        public DateTime Now { get; set; }

        public TimeZoneInfo TimeZone { get; set; }
    }
}