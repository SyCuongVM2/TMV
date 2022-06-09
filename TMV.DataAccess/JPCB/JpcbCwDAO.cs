﻿using System;
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
    public DataSet GetCWData(int tenantId, int type, int dayViewType, DateTime dateView, decimal cvdv, string bks, string roNo)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgGetCWData,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(type), // CW, GJ, BP
          Globals.DB_GetNull(dayViewType), // 01: Ca ngay, 02: Sang, 03: Chieu
          Globals.DB_GetNull(dateView), // view date
          Globals.DB_GetNull(cvdv),
          Globals.DB_GetNull(bks),
          Globals.DB_GetNull(roNo)
        }
      );
    }
  }
}