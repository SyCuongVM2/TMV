using System;
using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.Common;

namespace TMV.DataAccess.Admin
{
  public class APP_LogbookDAO
  {
    #region "Constructor"
    private static APP_LogbookDAO _instance;
    private static object _syncLock = new object();

    protected APP_LogbookDAO()
    {
    }

    public static APP_LogbookDAO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_LogbookDAO();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public void Delete(decimal LOG_ID)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_LOGBOOK_PKG_APP_LOGBOOK_DELETE, new object[] { LOG_ID });
    }

    public DataSet GetAll()
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_LOGBOOK_PKG_APP_LOGBOOK_GETALL, new object[0]);
    }

    public APP_LogbookInfo GetById(decimal LOG_ID)
    {
      return (APP_LogbookInfo)CBO.FillObject(SqlDataAccess.ExecuteReader(SqlConnect.ConnectionString, Constants.Instance().APP_LOGBOOK_PKG_APP_LOGBOOK_GETBYID, new object[] { LOG_ID }), typeof(APP_LogbookInfo));
    }

    public void Insert(string Computer_Name, string Windows_User, string Log_Action, string Log_Description, string Form_Name, decimal User_Id)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_LOGBOOK_PKG_APP_LOGBOOK_INSERT, new object[] {
                Globals.DB_GetNull(Computer_Name),
                Globals.DB_GetNull(Windows_User),
                Globals.DB_GetNull(Log_Action),
                Globals.DB_GetNull(Log_Description),
                Globals.DB_GetNull(Form_Name),
                Globals.DB_GetNull(User_Id)
            });
    }

    public DataSet Search(string Log_Action, decimal Login_User_ID, DateTime From_Date, DateTime To_Date)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_LOGBOOK_PKG_APP_LOGBOOK_SEARCH, new object[] {
                Globals.DB_GetNull(Log_Action),
                Globals.DB_GetNull(Login_User_ID),
                Globals.DB_GetNull(From_Date),
                Globals.DB_GetNull(To_Date)
            });
    }

    public void Update(APP_LogbookInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_LOGBOOK_PKG_APP_LOGBOOK_UPDATE, new object[] {
                Globals.DB_GetNull(objInfo.LOG_ID),
                Globals.DB_GetNull(objInfo.COMPUTER_NAME),
                Globals.DB_GetNull(objInfo.WINDOWS_USER),
                Globals.DB_GetNull(objInfo.LOG_ACTION),
                Globals.DB_GetNull(objInfo.LOG_DESCRIPTION),
                Globals.DB_GetNull(objInfo.FORM_NAME),
                Globals.DB_GetNull(objInfo.USER_ID),
                Globals.DB_GetNull(objInfo.USER_NAME),
                Globals.DB_GetNull(objInfo.LOG_TIME)
            });
    }
  }
}