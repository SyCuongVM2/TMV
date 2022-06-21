using System;
using System.Data;
using TMV.DataAccess.JPCB;

namespace TMV.BusinessObject.JPCB
{
  public class JpcbCwBO
  {
    #region "Constructor"
    private static JpcbCwBO _instance;
    private static object _syncLock = new object();

    protected JpcbCwBO()
    {
    }
    public static JpcbCwBO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new JpcbCwBO();
        }
      }
      return _instance;
    }
    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public DataSet GetCWConfig(int tenantId, string type)
    {
      return JpcbCwDAO.Instance().GetCWConfig(tenantId, type); // CW, GJ, BP
    }
    public DataSet GetCWConfigDefault(int tenantId, DateTime date)
    {
      return JpcbCwDAO.Instance().GetCWConfigDefault(tenantId, date);
    }
    public DataSet GetCWData(int tenantId, string type, string dayViewType, DateTime dateView)
    {
      return JpcbCwDAO.Instance().GetCWData(
        tenantId, 
        (type == "CW") ? 3 : (type == "GJ") ? 2 : 1,
        dayViewType, 
        dateView
      );
    }
    public DataSet StartFinishCW(decimal userId, int tenantId, string type, decimal Id)
    {
      return JpcbCwDAO.Instance().StartFinishCW(
        userId,
        tenantId,
        type,
        Id
      );
    }
    public DataSet GetWorkingTime(int tenantId, DateTime fromDate, DateTime toTime)
    {
      return JpcbCwDAO.Instance().GetWorkingTime(tenantId, fromDate, toTime);
    }
    public DataSet GetCWWorkshops(int tenantId, string type)
    {
      return JpcbCwDAO.Instance().GetCWWorkshops(
        tenantId,
        type
      );
    }
    public DataSet GetCWDetail(int tenantId, decimal Id)
    {
      return JpcbCwDAO.Instance().GetCWDetail(
        tenantId,
        Id
      );
    }
    public DataSet CalcWorkingTime(int tenantId, DateTime fromTime, DateTime toTime)
    {
      return JpcbCwDAO.Instance().CalcWorkingTime(
        tenantId,
        fromTime,
        toTime
      );
    }
    public DataSet AddOrUpdateCW(decimal userId, int tenantId, string type, string registerNo, int workshopId,
                                 DateTime planFromTime, DateTime planToTime, int planCalcTime, decimal Id)
    {
      return JpcbCwDAO.Instance().AddOrUpdateCW(
        userId,
        tenantId,
        type,
        registerNo,
        workshopId,
        planFromTime,
        planToTime,
        planCalcTime,
        Id
      );
    }
    public DataSet DeleteCWPlan(int tenantId, decimal Id)
    {
      return JpcbCwDAO.Instance().DeleteCWPlan(
        tenantId,
        Id
      );
    }
    public DataSet CWGoback(int tenantId, decimal userId, string type, decimal Id)
    {
      return JpcbCwDAO.Instance().CWGoback(
        tenantId,
        userId,
        type,
        Id
      );
    }
  }
}