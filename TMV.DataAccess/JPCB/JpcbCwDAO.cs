using System;
using System.Data;
using TMV.Common;

namespace TMV.DataAccess.JPCB
{
  public class JpcbCwDAO
  {
    #region "Constructor"
    private static JpcbCwDAO _instance;
    private static object _syncLock = new object();

    protected JpcbCwDAO()
    {
    }
    public static JpcbCwDAO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new JpcbCwDAO();
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
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgGetConfigs,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(type) // CW, GJ, BP
        }
      );
    }
    public DataSet GetCWConfigDefault(int tenantId, DateTime date)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgGetConfigsDefault,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(date)
        }
      );
    }
    public DataSet GetCWData(int tenantId, int type, string dayViewType, DateTime dateView)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgGetCWData,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(type), // CW, GJ, BP
          Globals.DB_GetNull(dayViewType), // 01: Ca ngay, 02: Sang, 03: Chieu
          Globals.DB_GetNull(dateView) // view date
        }
      );
    }
    public DataSet StartFinishCW(decimal userId, int tenantId, string type, decimal Id)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgStartFinishCW,
        new object[] {
          Globals.DB_GetNull(userId),
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(type), // S: Start, F: Finish
          Globals.DB_GetNull(Id) // Id: PlanId, ActualId
        }
      );
    }
    public DataSet GetWorkingTime(int tenantId, DateTime fromDate, DateTime toTime)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgGetWorkingTime,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(fromDate),
          Globals.DB_GetNull(toTime)
        }
      );
    }
  }
}