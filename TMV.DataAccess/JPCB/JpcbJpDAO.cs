using System;
using System.Data;
using TMV.Common;

namespace TMV.DataAccess.JPCB
{
  public class JpcbJpDAO
  {
    #region "Constructor"
    private static JpcbJpDAO _instance;
    private static object _syncLock = new object();

    protected JpcbJpDAO()
    {
    }
    public static JpcbJpDAO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new JpcbJpDAO();
        }
      }
      return _instance;
    }
    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public DataSet JPVisibleTabs(int tenantId, decimal userId)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPVisibleTabs,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(userId)
        }
      );
    }
    public DataSet GetJPConfig(int tenantId, string type)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPGetConfigs,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(type) // AP, GJ, BP
        }
      );
    }
    public DataSet GetConfigDefault(int tenantId, DateTime date)
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
    public DataSet GetJPData(int tenantId, int type, DateTime dateView)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPGetData,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(type),
          Globals.DB_GetNull(dateView)
        }
      );
    }
    public DataSet GetJPCholapKHSuaxong(int tenantId, int type, DateTime dateView)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPCholapKHSuaxong,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(type),
          Globals.DB_GetNull(dateView)
        }
      );
    }
    public DataSet GetJPMolenhGiaoxe(int tenantId, int type, DateTime dateView)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPMolenhGiaoxe,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(type),
          Globals.DB_GetNull(dateView)
        }
      );
    }
    public DataSet GetJPDangSuaChua(int tenantId, int type, DateTime dateView)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPDangSuaChua,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(type),
          Globals.DB_GetNull(dateView)
        }
      );
    }
    public DataSet GetJPXeDung(int tenantId, int type, DateTime dateView)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPXeDung,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(type),
          Globals.DB_GetNull(dateView)
        }
      );
    }
    public DataSet UpdateKeothaResize(decimal userId, int tenantId, string roType, decimal id, string table, DateTime from, DateTime to, int workshop)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPUpdateKeothaResize,
        new object[] {
          Globals.DB_GetNull(userId),
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(roType),
          Globals.DB_GetNull(id),
          Globals.DB_GetNull(table),
          Globals.DB_GetNull(from),
          Globals.DB_GetNull(to),
          Globals.DB_GetNull(workshop)
        }
      );
    }
    public DataSet ConfirmPlan(decimal roId, DateTime planToTime, decimal userId)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPConfirmPlan,
        new object[] {
          Globals.DB_GetNull(roId),
          Globals.DB_GetNull(planToTime),
          Globals.DB_GetNull(userId)
        }
      );
    }
    public DataSet ClonePlan(string type, decimal roId, DateTime planFromTime, DateTime planToTime, int tenantId, decimal userId)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPClonePlan,
        new object[] {
          Globals.DB_GetNull(type),
          Globals.DB_GetNull(roId),
          Globals.DB_GetNull(planFromTime),
          Globals.DB_GetNull(planToTime),
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(userId)
        }
      );
    }
    public DataSet CancelPlan(string type, decimal planId, decimal roId, int tenantId, decimal userId)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPCancelPlan,
        new object[] {
          Globals.DB_GetNull(type),
          Globals.DB_GetNull(planId),
          Globals.DB_GetNull(roId),
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(userId)
        }
      );
    }
    public DataSet CheckPlans(int tenantId, decimal roId)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPCheckPlans,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(roId)
        }
      );
    }
    public DataSet DetailDefault(int tenantId, string type)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPDetailDefault,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(type) // GJ, BP
        }
      );
    }
    public DataSet Detail(int tenantId, decimal id, string eventType)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPDetail,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(id),
          Globals.DB_GetNull(eventType)
        }
      );
    }
    public DataSet DetailJobsParts(decimal roId)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgJPDetailJobsParts,
        new object[] {
          Globals.DB_GetNull(roId)
        }
      );
    }
  }
}