using System;

namespace Sakura.Extensions
{
    public static class DateExtension
    {
        public static long Timestamp(this DateTime str)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (long)(DateTime.Now - startTime).TotalMilliseconds;
        }
    }
}