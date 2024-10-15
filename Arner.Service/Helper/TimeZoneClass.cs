using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.Service.Helper
{
    public static class TimeZoneClass
    {
        public static DateTime GetCurrentVietNameTime()
        {
            DateTime currTime = DateTime.UtcNow;

            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            return TimeZoneInfo.ConvertTimeFromUtc(currTime, vietnamTimeZone);
        }
    }
}
