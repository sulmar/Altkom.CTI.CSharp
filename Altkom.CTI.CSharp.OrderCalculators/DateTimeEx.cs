using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CTI.CSharp.OrderCalculators
{
    public class DateTimeHelper
    {
        public static bool IsWeekend(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday
                || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }

    public static class MyLinq
    {
        public static bool IsEmpty<T>(this IEnumerable<T> items)
        {
            return items != null;
        }
    }

    public static class DateTimeExtensions
    {
        public static bool IsWeekend(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday
                || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }

    public static class StringExtensions
    {
        public static string Clean(this string input, string replacement)
        {
            return input.Replace(replacement, string.Empty);
        }

    }


}
