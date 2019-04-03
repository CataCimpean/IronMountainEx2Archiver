using System;

namespace IronMountainEx2Archiver.Utils.Date
{
    public class DateUtil
    {

        public static double ConvertToJulian(DateTime date)
        {
            return date.ToOADate();
        }

        public static DateTime ConvertFromJulian(double julianDate)
        {
            return DateTime.FromOADate(julianDate);
        }
        
        public static double GetWholeNumberPart(double value)
        {
            return Math.Floor(Math.Abs(value));
        }

        public static string GetDateYYYMMDDHHMMSS()
        {
            return DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
        }

        public static string GetDateTimeWithoutPMorAM(DateTime datetime)
        {
            return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public static string GetToday()
        {
            return DateTime.Now.DayOfWeek.ToString();
        }

        public static string ConvertDateTimeToJulianYYJJJ(DateTime date)
        {
           return date.ToString("yy") + date.DayOfYear.ToString("000");
        }
    }
}
