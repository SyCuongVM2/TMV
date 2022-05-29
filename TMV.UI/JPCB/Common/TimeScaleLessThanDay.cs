using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Native;
using System;
using System.Collections.Generic;

namespace TMV.UI.JPCB.Common
{
  public class TimeScaleLessThanDay : TimeScaleFixedInterval
  {
    private double StartHour;
    private double FinishHour;
    private DateTime Finishdate;
    private DateTime Startdate;
    private static TimeSpan StartTimeLimitation = TimeSpan.FromHours(8.0);
    private static TimeSpan EndTimeLimitation = TimeSpan.FromHours(18.0);

    public TimeScaleLessThanDay(TimeSpan scaleValue, int Start, int Finish, DateTime Startdate1, DateTime Finishdate1, string Thu_Bay,string Chu_Nhat)
      : base(scaleValue)
    {
      StartHour = 8.0;
      FinishHour = 17.0;

      DaysToIgnore = new List<DayOfWeek>();
      if (Thu_Bay.Trim() == "1")
        DaysToIgnore.Add(DayOfWeek.Saturday);
      if (Chu_Nhat.Trim() == "1")
        DaysToIgnore.Add(DayOfWeek.Sunday);

      StartHour = (double)Start;
      FinishHour = (double)Finish;
      Startdate = Startdate1;
      Finishdate = Finishdate1;

      StartTimeLimitation = TimeSpan.FromHours(StartHour);
      EndTimeLimitation = TimeSpan.FromHours(FinishHour);
    }

    public TimeSpan StartTime => StartTimeLimitation;
    public TimeSpan EndTime => EndTimeLimitation;
    protected override string DefaultDisplayFormat => "HH:mm";
    private List<DayOfWeek> DaysToIgnore { get; set; }
    protected override TimeSpan SortingWeight => Value;
    protected DateTime RoundToHour(DateTime date, TimeSpan timeOfDay) => date.Date + timeOfDay;
    protected override bool HasNextDate(DateTime date) => true;

    public override DateTime Floor(DateTime date)
    {
      DateTime dateTime1;
      try
      {
        if (DateTime.Compare(date, DateTime.MinValue) == 0 || DateTime.Compare(date, DateTime.MaxValue) == 0)
          dateTime1 = date;
        else
        {
          date = DateTimeHelper.Floor(date, Value, RoundToHour(date, StartTime));
          TimeSpan timeOfDay = date.TimeOfDay;

          if (timeOfDay < StartTime)
            date = RoundToHour(date.AddDays(-1.0), EndTime);
          else if (timeOfDay > EndTime)
            date = RoundToHour(date, EndTime);

          DateTime dateTime2 = SkipSomeDays(date, -1);
          if (DateTime.Compare(dateTime2, date) != 0)
            date = RoundToHour(dateTime2, EndTime);

          date = DateTimeHelper.Floor(date, Value, RoundToHour(date, StartTime));
          dateTime1 = date;
        }
      }
      catch(Exception ex)
      {
        dateTime1 = date;
      }
      return dateTime1;
    }

    public override DateTime GetNextDate(DateTime date)
    {
      try
      {
        date = HasNextDate(date) ? date + Value : date;
        TimeSpan timeOfDay = date.TimeOfDay;

        if (timeOfDay < StartTime)
          date = RoundToHour(date, StartTime);
        else if (timeOfDay > EndTime)
          date = RoundToHour(date.AddDays(1.0), StartTime);

        DateTime dateTime = SkipSomeDays(date, 1);
        if (DateTime.Compare(dateTime, date) != 0)
          date = RoundToHour(dateTime, StartTime);
      }
      catch(Exception ex)
      {
        date = new DateTime();
      }
      return date;
    }

    private DateTime SkipSomeDays(DateTime date, int skipDayCount)
    {
      int num1 = checked(DaysToIgnore.Count - 1);
      int num2 = 0;
      while (num2 <= num1 && DaysToIgnore.Contains(date.DayOfWeek))
      {
        date = date.AddDays((double)skipDayCount);
        checked { ++num2; }
      }
      return date;
    } 
  }
}