using System;
using System.Data;
using System.Collections.Generic;
using TMV.BusinessObject.JPCB;
using TMV.Common;

namespace TMV.UI.JPCB.Common
{
  public class CalcTime
  {
    private const int ONE_MINUTE_IN_MILLIS = 60000;
    private const int FUTURE_DAYS = 14;

    public FromToTimeDto CalcCloneRepairTime(int estimateTime, DateTime pFromTime)
    {
      DateTime startDate = pFromTime;
      DateTime seek = startDate;
      long remainTime = estimateTime * ONE_MINUTE_IN_MILLIS;
      bool checkingStartDate = false;
      var config = new DealerConfigDTO();
      var copyConf = new DealerConfigDTO();

      while (remainTime > 0)
      {
        List<DealerCalendarDTO> daysFuture = new List<DealerCalendarDTO>();
        DateTime day_n_Future = startDate.AddDays(FUTURE_DAYS);
        List<DateTime> listHolidays = new List<DateTime>();

        DataSet ds = JpcbCwBO.Instance().GetWorkingTime(Globals.LoginDlrId, pFromTime, day_n_Future); // TODO
        if (ds != null && ds.Tables.Count > 0)
        {
          DataTable dt = ds.Tables[0].Copy();
          config.wkAMFrom = Convert.ToDateTime(dt.Rows[0]["wkAMFrom"]);
          config.wkAMTo = Convert.ToDateTime(dt.Rows[0]["wkAMTo"]);
          config.wkPMFrom = Convert.ToDateTime(dt.Rows[0]["wkPMFrom"]);
          config.wkPMTo = Convert.ToDateTime(dt.Rows[0]["wkPMTo"]);
          config.restAMFrom = null;
          config.restAMTo = null;
          config.restPMFrom = null;
          config.restPMTo = null;

          foreach (DataRow item in ds.Tables[1].Rows)
          {
            listHolidays.Add(Convert.ToDateTime(item["ValueDate"]));
          }
        }

        while (startDate <= day_n_Future)
        {
          var item = new DealerCalendarDTO
          {
            startTime = setDateToDateTime(startDate, config.wkAMFrom),
            endTime = setDateToDateTime(startDate, config.wkPMTo),
            isHoliday = listHolidays.Contains(startDate.Date) ? true : false
          };
          daysFuture.Add(item);

          startDate = startDate.AddDays(1);
        }

        int count = 0;
        copyConf = config;
        setDateToConfig(ref copyConf, daysFuture[count]);
        DateTime end_n_Date = daysFuture[daysFuture.Count - 1].endTime; // Lay gio ket thuc cua ngay cuoi cung sau FUTURE_DAYS ngay 

        while (seek < end_n_Date && count < daysFuture.Count && remainTime > 0)
        {
          // before work am
          if (count < 0)
            break;

          #region "Check if fromDate is in non-working time"
          // --- START: Check if fromDate is in non-working time			
          // if fromDate < WkAmFrom -> set WkAmFrom (07:30)
          if (seek < daysFuture[count].startTime)
            seek = copyConf.wkAMFrom;

          // if RestAmFrom < fromDate < RestAmTo: set RestAmTo (09:00 - 09:10)
          if ((null != copyConf.restAMFrom && seek > copyConf.restAMFrom) && (null != copyConf.restAMTo && seek < copyConf.restAMTo))
            seek = copyConf.restAMTo.Value;

          // if WkAmTo < fromDate < WkPmFrom: set WkPmFrom (12:00 - 13:00)
          if (seek > copyConf.wkAMTo && seek < copyConf.wkPMFrom)
            seek = copyConf.wkPMFrom;

          // if RestPmFrom < fromDate < RestPmTo: set RestPmTo (15:00 - 15:10)
          if ((null != copyConf.restPMFrom && seek > copyConf.restPMFrom) && (null != copyConf.restPMTo && seek < copyConf.restPMTo))
            seek = copyConf.restPMTo.Value;

          // if fromDate > WkPmTo: set next day WkAmFrom (after work pm => set to new day morning)
          if (seek > daysFuture[count].endTime)
          {
            count = checkNewDate(count, daysFuture, ref seek, config, ref copyConf);
            if (count < 0)
              break;
          }
          // --- END: Check if fromDate is in non-working time
          #endregion

          if (!checkingStartDate)
            startDate = seek; // If fromDate is in non-working time -> set to next working time point, if not then = fromDate

          checkingStartDate = true;

          #region "Check if fromDate is in working time"
          // --- START: Check if fromDate is in working time
          // if WkAmTo < fromDate < RestAmFrom (07:30 - 09:00/07:30)
          if (seek >= copyConf.wkAMFrom && seek <= copyConf.restAMFrom)
          {
            // if seek set to rest AM from is ok
            if ((copyConf.restAMFrom.Value - seek).TotalMilliseconds < remainTime)
            {
              // jump to rest AM from
              long timeBeforeJump = (long)(copyConf.restAMFrom.Value - seek).TotalMilliseconds;
              seek = copyConf.restAMTo.Value;
              remainTime -= timeBeforeJump;
            }
            else
            {
              // jump forward to some minutes
              seek = seek.AddMilliseconds(remainTime);
              remainTime = 0;
              break;
            }
          }
          if (remainTime <= 0)
            break;

          // if RestAmTo < fromDate < WkAmTo (09:10/07:30 - 12:00)
          if (seek >= copyConf.restAMTo && seek <= copyConf.wkAMTo)
          {
            // come back to rest am from
            if ((copyConf.wkAMTo - seek).TotalMilliseconds < remainTime)
            {
              long timeBeforeJump = (long)(copyConf.wkAMTo - seek).TotalMilliseconds;
              seek = copyConf.wkPMFrom;
              remainTime -= timeBeforeJump;
            }
            else
            {
              // jump forward to some minutes
              seek = seek.AddMilliseconds(remainTime);
              remainTime = 0;
              break;
            }
          }
          if (remainTime <= 0)
            break;

          // if WkPmFrom < fromDate < RestPmFrom (13:00 - 15:00/13:00)
          if (seek >= copyConf.wkPMFrom && seek <= copyConf.restPMFrom)
          {
            if ((copyConf.restPMFrom.Value - seek).TotalMilliseconds < remainTime)
            {
              long timeBeforeJump = (long)(copyConf.restPMFrom.Value - seek).TotalMilliseconds;
              seek = copyConf.restPMTo.Value;
              remainTime -= timeBeforeJump;
            }
            else
            {
              // jump forward to some minutes
              seek = seek.AddMilliseconds(remainTime);
              remainTime = 0;
              break;
            }
          }
          if (remainTime <= 0)
            break;

          // if RestPmTo < fromDate < WkPmTo (15:10/13:00 - 18:00)
          if (seek >= copyConf.restPMTo && seek <= copyConf.wkPMTo)
          {
            if ((copyConf.wkPMTo - seek).TotalMilliseconds < remainTime)
            {
              long timeBeforeJump = (long)(copyConf.wkPMTo - seek).TotalMilliseconds;
              count = checkNewDate(count, daysFuture, ref seek, config, ref copyConf);
              if (count < 0)
                break;

              remainTime -= timeBeforeJump;
            }
            else
            {
              // jump forward to some minutes
              seek = seek.AddMilliseconds(remainTime);
              remainTime = 0;
              break;
            }
          }
          if (remainTime <= 0)
            break;
          // --- END: Check if fromDate is in working time
          #endregion
        }
      }

      return new FromToTimeDto
      {
        StartPlanTime = startDate,
        EndPlanTime = seek
      };
    }
    #region "privates"
    private int checkNewDate(int count, List<DealerCalendarDTO> daysFuture, ref DateTime seek, DealerConfigDTO config, ref DealerConfigDTO copyConf)
    {
      count++;
      if (count >= daysFuture.Count)
        return -1;

      if (daysFuture[count].isHoliday) // Neu la ngay nghi thi + them 1 ngay
        count = checkNewDate(count, daysFuture, ref seek, config, ref copyConf);

      copyConf = config;
      setDateToConfig(ref copyConf, daysFuture[count]);
      seek = daysFuture[count].startTime;

      return count;
    }
    private void setDateToConfig(ref DealerConfigDTO config, DealerCalendarDTO calendar)
    {
      DateTime fromTime = calendar.startTime;
      DateTime toTime = calendar.endTime;
      config.wkAMFrom = setDateToDateTime(fromTime, config.wkAMFrom);
      config.wkAMTo = setDateToDateTime(fromTime, config.wkAMTo);
      config.wkPMFrom = setDateToDateTime(fromTime, config.wkPMFrom);
      config.wkPMTo = setDateToDateTime(fromTime, config.wkPMTo);

      if (config.restAMFrom != null)
        config.restAMFrom = setDateToDateTime(fromTime, config.restAMFrom.Value);
      if (config.restAMTo != null)
        config.restAMTo = setDateToDateTime(fromTime, config.restAMTo.Value);
      if (config.restPMFrom != null)
        config.restPMFrom = setDateToDateTime(toTime, config.restPMFrom.Value);
      if (config.restPMTo != null)
        config.restPMTo = setDateToDateTime(toTime, config.restPMTo.Value);

      if (config.restAMFrom == null)
      {
        config.restAMFrom = config.wkAMFrom;
        config.restAMTo = config.wkAMFrom;
      }

      if (config.restPMFrom == null)
      {
        config.restPMFrom = config.wkPMFrom;
        config.restPMTo = config.wkPMFrom;
      }
    }
    private DateTime setDateToDateTime(DateTime date, DateTime dateTime)
    {
      return date.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);
    }
    #endregion
  }
  public class FromToTimeDto
  {
    public DateTime StartPlanTime { get; set; }
    public DateTime EndPlanTime { get; set; }
  }
  public class DealerConfigDTO
  {
    public DateTime wkAMFrom { get; set; }
    public DateTime wkAMTo { get; set; }
    public DateTime wkPMFrom { get; set; }
    public DateTime wkPMTo { get; set; }
    public DateTime? restAMFrom { get; set; }
    public DateTime? restAMTo { get; set; }
    public DateTime? restPMFrom { get; set; }
    public DateTime? restPMTo { get; set; }
  }
  public class DealerCalendarDTO
  {
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public bool isHoliday { get; set; } = false;
  }
}