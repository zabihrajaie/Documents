using System;
using System.Globalization;
using Infrastructure.Utilities;
using MD.PersianDateTime;

namespace Infrastructure.Extensions
{
    public class DateTimeExtensions
    {
        public static DateTime ConvertPersianDateToSqlDate(DateTime time)
        {
            var pc = new PersianCalendar();
            return new DateTime(time.Year, time.Month, time.Day, pc);
        }

        public static DateTime ConvertPersianDateToSqlDate(string time)
        {
            Assert.NotNull(time, nameof(time));
            var date = time?.Insert(4, "/").Insert(7, "/");
            return ConvertPersianWithSlashDateToSqlDate(date);
        }

        /// <summary>
        /// تبدیل تاریخ فارسی به تاریخ میلادی
        /// ۱۳۹۹/۰۳/۰۳  1399/03/03
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ConvertPersianWithSlashDateToSqlDate(string date)
        {
            Assert.NotNull(date, nameof(date));
            return PersianDateTime.Parse(date).ToDateTime();
        }
    }
}
