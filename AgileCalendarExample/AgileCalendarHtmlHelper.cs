﻿using AgileCalendarExample.App_GlobalResources;
using AgileCalendarExample.Models.Domain;
using AgileCalendarExample.Models.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileCalendarExample
{
    public static class AgileCalendarHtmlHelper
    {
        public static DayOfWeek WeekStart = DayOfWeek.Monday;
        public static DayOfWeek WeekEnd = (DayOfWeek)(AgileCalendarHtmlHelper.WeekStart == DayOfWeek.Sunday ? 6 : (int)AgileCalendarHtmlHelper.WeekStart - 1);

        /// <summary>
        /// Returns an enumerator for the days of the week in a custom order.
        /// <see cref="WeekStart"/>
        /// </summary>
        /// <param name="htmlHelper">Represents support for rendering HTML controls in a strongly typed view</param>
        /// <returns>The name of the day of the week</returns>
        public static IEnumerable<String> GetDaysOfWeek(this HtmlHelper<ReleaseCycleModel> htmlHelper)
        {
            int dayIndex = (int)AgileCalendarHtmlHelper.WeekStart;
            for (int c = 0; c < 7; c++)
            {
                DayOfWeek dayOfWeek = (DayOfWeek)dayIndex;
                switch (dayOfWeek)
                {
                    case DayOfWeek.Monday:
                        yield return Resources.Monday;
                        break;
                    case DayOfWeek.Tuesday:
                        yield return Resources.Tuesday;
                        break;
                    case DayOfWeek.Wednesday:
                        yield return Resources.Wednesday;
                        break;
                    case DayOfWeek.Thursday:
                        yield return Resources.Thursday;
                        break;
                    case DayOfWeek.Friday:
                        yield return Resources.Friday;
                        break;
                    case DayOfWeek.Saturday:
                        yield return Resources.Saturday;
                        break;
                    default:
                        yield return Resources.Sunday;
                        break;
                }

                if (++dayIndex == 7)
                    dayIndex = 0;
            }
        }

        public static IEnumerable<AgileDate> GetAllDatesInReleaseCycle(this HtmlHelper<ReleaseCycleModel> htmlHelper)
        {
            DateTime startDate = htmlHelper.ViewData.Model.Items.Min(item => item.StartDate);
            DateTime endDate = htmlHelper.ViewData.Model.Items.Max(item => item.EndDate);

            //align startDate witha a beginning of the week
            while (startDate.DayOfWeek != AgileCalendarHtmlHelper.WeekStart)
                startDate = startDate.AddDays(-1);

            //align endDate witha an end of the week
            while (endDate.DayOfWeek != AgileCalendarHtmlHelper.WeekEnd)
                endDate = endDate.AddDays(1);

            bool isNewMonth = true;
            while (startDate <= endDate)
            {
                PeriodEnum weekPeriod = AgileCalendarHtmlHelper.GetWeekPeriod(startDate);

                yield return new AgileDate
                {
                    Date = startDate,
                    Color = "",
                    WeekPeriod = weekPeriod,
                    IsNewMonth = isNewMonth
                };

                DateTime nextDate = startDate.AddDays(1);
                isNewMonth = nextDate.Month > startDate.Month;
                startDate = nextDate;
            }
        }

        /// <summary>
        /// Gets the state of a week
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>An enum value which indicates whether the week starts, ends or is current</returns>
        private static PeriodEnum GetWeekPeriod(DateTime date)
        {
            if (date.DayOfWeek == AgileCalendarHtmlHelper.WeekStart)
                return PeriodEnum.Start;
            else if (date.DayOfWeek == AgileCalendarHtmlHelper.WeekEnd)
                return PeriodEnum.End;
            else
                return PeriodEnum.Current;
        }
    }
}