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

    public DataTable Table_ListField(string sTableName)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppAuthPkgTableListField, 
        new object[] { 
          sTableName.ToUpper() 
        }).Tables[0];
    }
    public object Table_GetFieldValue(string sTableName, string sFieldName, int iPKValue)
    {
      return Globals.DB_GetValue(SqlDataAccess.ExecuteScalar(
        SqlConnect.ConnectionString,
        Constants.Instance().AppAuthPkgTableGetFieldValue, 
        new object[] { 
          sTableName.ToUpper(), 
          sFieldName, 
          iPKValue 
        }), null);
    }
    public DataTable DataErrorMessage_Get(string sErrType, string sErrObject)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppAuthPkgTableGetErrorMessage, 
        new object[] { 
          Globals.DB_GetNull(sErrType), 
          Globals.DB_GetNull(sErrObject) 
        }).Tables[0];
    }
  }
}