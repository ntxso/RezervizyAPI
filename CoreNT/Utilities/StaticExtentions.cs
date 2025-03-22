using CoreNT.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CoreNT.Utilities.StaticVariables;

namespace CoreNT.Utilities
{
    public static class Extentions
    {

        public static DateTime FirstMondayInYear = new DateTime(2022, 1, 3).AddHours(3);

        public static TSTypeEnum GetNearestFromTS(this TimeSpan timeSpan)
        {
            TimeSpan timeSpanNearest = TSList.OrderBy(p => Math.Abs((timeSpan - p).Ticks)).First();
            for (int i = 0; i < TSList.Length; i++)
            {
                if (timeSpanNearest == TSList[i])
                {
                    return (TSTypeEnum)i;
                }
            }
            return TSTypeEnum.Undefined;
        }

        public static bool IsEmptyOrNull<T>(this List<T> list)
        {
            if (list == null) return true;
            return !list.Any();
        }
        public static bool AnyNT(this IEnumerable<INameId> nameIds, int id)
        {
            return (nameIds.Any(p => p.Id == id));
        }


        /// <summary>
        /// Object listeyi interface listeye dönüştürmek için kullanılmalı
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="objectList"></param>
        /// <returns>Uyumsuz türlerde liste boş döner</returns>
        public static List<T2> GetListAs<T1, T2>(this IEnumerable<T1> objectList)
            where T1 : class
            where T2 : class
        {
            try
            {
                return objectList.Cast<T2>().ToList();

            }
            catch
            {
                return new List<T2>();
            }
        }
        public static string TrimPhoneNumber(this string phoneNumber)
        {
            string result = phoneNumber.Replace(" ", "");
            result = result.Replace("(", "");
            result = result.Replace(")", "");
            if (result.Length > 11)
            {
                result = result.Substring(result.Length - 11, 11);
            }
            return result;
        }
        public static DateTime Round(this DateTime dateTime, TimeSpan timeSpan)
        {
            DateTime result;
            dateTime = dateTime.AddSeconds(-dateTime.Second);
            TimeSpan difTS = dateTime - FirstMondayInYear;
            double totalMinutes = Math.Round(difTS.TotalMinutes, MidpointRounding.AwayFromZero);
            double spanMinutes = timeSpan.TotalMinutes;

            double difMod = dateTime.ModTimeSpanMinutes(timeSpan);

            if (difMod == 0) return dateTime;

            if (difMod < spanMinutes / 2)
            {
                result = dateTime.AddMinutes(-difMod);
            }
            else
            {
                result = dateTime.AddMinutes(spanMinutes - difMod);
            }
            return result;
        }
        /// <summary>
        /// 2022 Yılının ilk pazartesi saat 3 referans noktası
        /// Saat saniyesi otomatik 0 (sıfır) alınır.
        /// </summary>
        /// <param name="dateTime">DateTime value</param>
        /// <param name="timeSpan">TimeSpan value</param>
        /// <returns>referans noktasında dakika bazında mod değeri döndürür.</returns>
        public static double ModTimeSpanMinutes(this DateTime dateTime, TimeSpan timeSpan)
        {
            dateTime = dateTime.AddSeconds(-dateTime.Second);
            TimeSpan difTS = dateTime - FirstMondayInYear;
            double totalMinutes = Math.Round(difTS.TotalMinutes, MidpointRounding.AwayFromZero);
            double spanMinutes = timeSpan.TotalMinutes;
            return totalMinutes % spanMinutes;
        }
        /// <summary>
        /// Zamanı sayısal olarak mod alır
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="timeSpan"></param>
        /// <returns>1 dakika farkla mod 0 ise true değilse false döndürür</returns>
        public static bool EqualModSpan(this DateTime dateTime, TimeSpan timeSpan)
        {
            double temp = dateTime.ModTimeSpanMinutes(timeSpan);
            return (temp >= -1 && temp <= 1);
        }

        public static bool EqualModSpanTrue(this DateTime dateTime, TimeSpan timeSpan)
        {
            double temp = dateTime.ModTimeSpanMinutes(timeSpan);
            return (temp == 0);
        }

        /// <summary>
        /// En yakın 5 dk ya yuvarlar
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>5 in katları dk olan zamanı döndürür</returns>
        public static DateTime RoundTime(this DateTime dateTime)
        {
            double minute = dateTime.Minute;
            double roundMinute = minute * 2 / 10;
            roundMinute = Math.Round(roundMinute) * 5;
            return dateTime.AddMinutes(roundMinute - minute);
        }
        public static TimeSpan Abs(this TimeSpan timeSpan)
        {
            return TimeSpan.FromMinutes(Math.Abs(timeSpan.TotalMinutes));
        }
        public static decimal PercentToPercent(this decimal first, decimal second)
        {
            return (100 + first) * (1 + second / 100) - 100;
        }
        public static int GetLevel<T>(this IList<T> list, T value)
            where T : IComparable
        {

            ArrayList.Adapter((IList)list).Sort();
            for (int i = 0; i < list.Count; i++)
            {
                if (value.CompareTo(list[i]) < 1)
                {
                    return i;
                }
            }
            return list.Count;
        }
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            if (list == null) return true;
            return !list.Any();
        }
        public static decimal CalcPercent(this decimal valueSource, decimal valueDestination)
        {
            if (valueSource == 0) return 0;
            return Math.Round((valueDestination / valueSource - 1) * 100, 4);
        }
    }
}
