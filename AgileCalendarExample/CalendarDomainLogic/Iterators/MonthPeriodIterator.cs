﻿using AgileCalendarExample.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileCalendarExample.CalendarDomainLogic.Iterators
{
    /// <summary>
    /// Iterator to get all the dates in a period and
    /// to indicate the beginning of each new month
    /// </summary>
    public class MonthPeriodIterator : DatesIteratorBase
    {
        /// <summary>
        /// A flag that indicates if a new month starts
        /// </summary>
        private bool isNewMonth;

        /// <summary>
        /// End date
        /// </summary>
        private DateTime endDate;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startDate">Start date for the iterator</param>
        /// <param name="endDate">End date for the iterator</param>
        /// <param name="calendarBuilder">Reference to the builder</param>
        public MonthPeriodIterator(DateTime startDate, DateTime endDate, CalendarBuilder calendarBuilder)
            :base(startDate, calendarBuilder)
        {
            this.endDate = endDate;
            this.isNewMonth = false;
        }

        /// <summary>
        /// If there are elements in a list
        /// </summary>
        /// <returns>True - yes, False - it is empty</returns>
        public override bool HasNext
        {
            get { return this.currentDate <= this.endDate; }
        }

        /// <summary>
        /// True - if a new month starts, False - current month
        /// </summary>
        public bool IsNewMonth
        {
            get { return this.isNewMonth; }
            set { this.isNewMonth = value; }
        }

        /// <summary>
        /// Populates the agileItem for the calendar
        /// and shifts the pointer to the next date
        /// </summary>
        /// <param name="model">Abstract view model</param>
        /// <returns>Populated model. Same pointer to an object.</returns>
        public override CalendarDateBase ReadNext(CalendarDateBase model)
        {
            model.Date = this.currentDate;
            model.WeekPeriod = this.GetCurrentWeekPeriod();
            model.IsNewMonth = false;

            DateTime nextDate = this.currentDate.AddDays(1);
            this.isNewMonth = nextDate.Month != this.currentDate.Month;
            this.currentDate = nextDate;

            return model;
        }

        /// <summary>
        /// Get current date
        /// </summary>
        public DateTime CurrentDate
        {
            get { return this.currentDate; }
        }
    }
}