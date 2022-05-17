using System;
using System.Collections.Generic;
using System.Data;
using TMV.Common;

namespace TMV.DataAccess
{
  public class AppHandler
  {
    #region "Constructor"
    private static AppHandler _instance;
    private static object _syncLock = new object();

    protected AppHandler()
    {
    }

    public static AppHandler Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
              _instance = new AppHandler();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    private Dictionary<string, DataTable> m_dicDomain;

    public DataTable Table_ListField(string sTableName)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, "APP_CONTROLLER_PKG_App_Table_ListField", new object[] { 
        sTableName.ToUpper() 
      }).Tables[0];
    }

    public bool Table_Deletable(string sTableName, int iPKValue)
    {
      return Convert.ToBoolean(SqlDataAccess.ExecuteScalar(SqlConnect.ConnectionString, "APP_CONTROLLER_PKG_App_Table_Deletable", new object[] { 
        sTableName.ToUpper(), iPKValue 
      }));
    }

    public object Table_GetFieldValue(string sTableName, string sFieldName, int iPKValue)
    {
      return Globals.DB_GetValue(SqlDataAccess.ExecuteScalar(SqlConnect.ConnectionString, "APP_CONTROLLER_PKG_App_Table_GetFieldValue", new object[] { 
        sTableName.ToUpper(), 
        sFieldName, iPKValue 
      }), null);
    }

    public DataTable Domain_GetDic(string sDomain)
    {
      return Domain_GetDic(sDomain, false);
    }

    private DataTable Domain_GetDic(string sDomain, bool bReadOnly)
    {
      DataTable dtReturn;
      sDomain = sDomain.ToUpper();
      if (m_dicDomain == null)
        m_dicDomain = new Dictionary<string, DataTable>();

      if (m_dicDomain.ContainsKey(sDomain))
        dtReturn = m_dicDomain[sDomain];
      else
      {
        dtReturn = SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, "APP_CONTROLLER_PKG_App_Domain_GetData", new object[] { sDomain }).Tables[0];
        if (dtReturn.Rows.Count == 0)
            throw new Exception(string.Format("Domain code '{0}' not found in Domain Table", sDomain));

        dtReturn.PrimaryKey = new DataColumn[] { dtReturn.Columns["Item_Code"] };
        dtReturn.AcceptChanges();
        m_dicDomain.Add(sDomain, dtReturn);
      }
      if (bReadOnly)
        return dtReturn;

      return dtReturn.Copy();
    }

    public string Domain_GetItemCode(string sDomain, int iIndex)
    {
      DataTable dt = Domain_GetDic(sDomain, true);
      if (iIndex >= dt.Rows.Count)
        throw new Exception(string.Format("Item with index {0} not found in dic '{1}'", iIndex, sDomain));

      return Convert.ToString(dt.Rows[iIndex][0]);
    }

    public string Domain_GetItemValue(string sDomain, int iIndex)
    {
      DataTable dt = Domain_GetDic(sDomain, true);
      if (iIndex >= dt.Rows.Count)
        throw new Exception(string.Format("Item with index {0} not found in dic '{1}'", iIndex, sDomain));

      return Convert.ToString(dt.Rows[iIndex][1]);
    }

    public string Domain_GetItemValue(string sDomain, string sCode)
    {
      DataRow dr = Domain_GetDic(sDomain, true).Rows.Find(sCode);
      if (dr == null)
        throw new Exception(string.Format("Item with code {0} not found in dic '{1}'", sCode, sDomain));

      return Convert.ToString(dr[1]);
    }

    public string Default_GetValue(string sName)
    {
      DataRow dtRow = Domain_GetDic("DEFAULT_VALUE").Rows.Find(sName);
      if (dtRow == null)
        return null;

      return Convert.ToString(dtRow[1]);
    }

    public DataTable Widget_List()
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, "APP_CONTROLLER_PKG_App_Widget_List", new object[0]).Tables[0];
    }

    public DataTable Widget_Data(string sSQL)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, CommandType.Text, sSQL).Tables[0];
    }

    public DataTable DataErrorMessage_Get(string sErrType, string sErrObject)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, "APP_CONTROLLER_PKG_Get_Error_Message", new object[] { 
        Globals.DB_GetNull(sErrType), 
        Globals.DB_GetNull(sErrObject) 
      }).Tables[0];
    }
  }
}