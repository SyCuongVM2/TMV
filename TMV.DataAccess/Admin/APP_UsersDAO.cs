using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.Common;

namespace TMV.DataAccess.Admin
{
  public class APP_UsersDAO
  {
    #region "Constructor"
    private static APP_UsersDAO _instance;
    private static object _syncLock = new object();

    protected APP_UsersDAO()
    {
    }

    public static APP_UsersDAO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_UsersDAO();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public void ChangePassword(APP_UsersInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_CHANGEPASSWORD, new object[] {
                Globals.DB_GetNull(objInfo.USER_ID),
                Globals.DB_GetNull(objInfo.ISNEXTLOGON),
                Globals.DB_GetNull(objInfo.USER_PASSWORD)
            });
    }

    public void Delete(decimal USER_ID)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_DELETE, new object[] { USER_ID });
    }

    public DataSet GetAccountPolicy(decimal USERID)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_ACCOUNTPOLICY, new object[] { USERID });
    }

    public DataSet GetAll()
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_GETALL, new object[0]);
    }

    public APP_UsersInfo GetById(decimal USER_ID)
    {
      return (APP_UsersInfo)CBO.FillObject(SqlDataAccess.ExecuteReader(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_GETBYID, new object[] { USER_ID }), typeof(APP_UsersInfo));
    }

    public APP_UsersInfo GetByUserName(string USERNAME)
    {
      return (APP_UsersInfo)CBO.FillObject(SqlDataAccess.ExecuteReader(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_GETBYUSERNAME, new object[] { USERNAME }), typeof(APP_UsersInfo));
    }

    public DataSet GetUserFormButton(decimal USERID, string MENUNAME, string FORMNAME, string PARENTNAME)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_GETUSERBUTTON, new object[] {
                Globals.DB_GetNull(USERID),
                Globals.DB_GetNull(MENUNAME),
                Globals.DB_GetNull(FORMNAME),
                Globals.DB_GetNull(PARENTNAME)
            });
    }

    public DataSet GetUserGroup(decimal USERID)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_GETUSERGROUP, new object[] { USERID });
    }

    public DataSet GetUserMenu(decimal USERID)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_GETUSERMENU, new object[] { USERID });
    }

    public void Insert(APP_UsersInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_INSERT, new object[] {
                Globals.DB_GetNull(objInfo.ISLOCKED),
                Globals.DB_GetNull(objInfo.USER_ID),
                Globals.DB_GetNull(objInfo.USER_NAME),
                Globals.DB_GetNull(objInfo.FULL_NAME),
                Globals.DB_GetNull(objInfo.DISABLEAFTERFAILED),
                Globals.DB_GetNull(objInfo.EFFECTIVE_DATE),
                Globals.DB_GetNull(objInfo.EXPRIRED_DATE),
                Globals.DB_GetNull(objInfo.ISNEXTLOGON),
                Globals.DB_GetNull(objInfo.NOPASSWORDHISTORY),
                Globals.DB_GetNull(objInfo.PASSWORD_HISTORY),
                Globals.DB_GetNull(objInfo.SENDEMAIL),
                Globals.DB_GetNull(objInfo.PASSWORDCHANGEAFTER),
                Globals.DB_GetNull(objInfo.USER_PASSWORD)
            });
    }

    public DataSet isExpiredPassword(decimal USERID)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_ISEXPIREDPASSWORD, new object[] { USERID });
    }

    public void Update(APP_UsersInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_UPDATE, new object[] {
                Globals.DB_GetNull(objInfo.ISLOCKED),
                Globals.DB_GetNull(objInfo.USER_ID),
                Globals.DB_GetNull(objInfo.USER_NAME),
                Globals.DB_GetNull(objInfo.FULL_NAME),
                Globals.DB_GetNull(objInfo.DISABLEAFTERFAILED),
                Globals.DB_GetNull(objInfo.EFFECTIVE_DATE),
                Globals.DB_GetNull(objInfo.EXPRIRED_DATE),
                Globals.DB_GetNull(objInfo.ISNEXTLOGON),
                Globals.DB_GetNull(objInfo.NOPASSWORDHISTORY),
                Globals.DB_GetNull(objInfo.PASSWORD_HISTORY),
                Globals.DB_GetNull(objInfo.SENDEMAIL),
                Globals.DB_GetNull(objInfo.PASSWORDCHANGEAFTER),
                Globals.DB_GetNull(objInfo.USER_PASSWORD)
            });
    }

    public void UpdateFailed(APP_UsersInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_UpdateFailed, new object[] {
                Globals.DB_GetNull(objInfo.USER_NAME),
                Globals.DB_GetNull(objInfo.NOFAILEDLOGIN)
            });
    }

    public void UserChangePassword(APP_UsersInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_USERS_PKG_APP_USERS_USERCHANGEPASSWORD, new object[] {
                Globals.DB_GetNull(objInfo.USER_ID), Globals.DB_GetNull(objInfo.ISNEXTLOGON), Globals.DB_GetNull(objInfo.PASSWORD_HISTORY),
                Globals.DB_GetNull(objInfo.USER_PASSWORD)
            });
    }
  }
}