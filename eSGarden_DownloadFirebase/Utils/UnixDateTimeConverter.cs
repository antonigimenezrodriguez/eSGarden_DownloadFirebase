using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class UnixDateTimeConverter
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp, TypeConversion type)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            switch (type)
            {
                case TypeConversion.Milliseconds:
                    dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
                    break;
                case TypeConversion.Seconds:
                    dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
                    break;
            }

            return dtDateTime;
        }
        public static double DateTimeToUnixTimestamp(DateTime dateTime, TypeConversion type)
        {
            switch (type)
            {
                case TypeConversion.Milliseconds:
                    return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                    new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalMilliseconds;
                case TypeConversion.Seconds:
                    return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                    new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
            }
            return -1;
        }

        public enum TypeConversion
        {
            Seconds = 1,
            Milliseconds = 2,
        }
    }
}
