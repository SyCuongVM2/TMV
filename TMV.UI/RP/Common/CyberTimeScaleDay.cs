using DevExpress.XtraScheduler;
using System;

namespace TMV.UI.RP.Common
{
  public class CyberTimeScaleDay : TimeScaleDay
  {
    private int StartHour;
    private int FinishHour;
    private DateTime Finishdate;
    private DateTime Startdate;

    public CyberTimeScaleDay(int Start, int Finish, DateTime Startdate1, DateTime Finishdate1)
    {
      StartHour = Start;
      FinishHour = Finish;
      Startdate = Startdate1;
      Finishdate = Finishdate1;
    }

    protected override string DefaultDisplayFormat => "dd/MM";
    protected override string DefaultDisplayName => "dd/MM";
    protected override string DefaultMenuCaption => "dd/MM";

    public override DateTime Floor(DateTime date)
    {
      if (DateTime.Compare(date, DateTime.MinValue) == 0 || DateTime.Compare(date, DateTime.MaxValue) == 0)
        return date.AddHours(FinishHour);

      DateTime dateTime = base.Floor(date);
      if (date.Hour < StartHour)
        dateTime = dateTime.AddDays(-1.0);

      return dateTime.AddHours(StartHour);
    }
  }
}