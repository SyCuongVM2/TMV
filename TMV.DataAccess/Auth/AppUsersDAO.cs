using System.Data;
using TMV.ObjectInfo.Auth;
using TMV.Common;

namespace TMV.DataAccess.Auth
{
  public class AppUsersDAO
  {
    #region "Constructor"
    private static AppUsersDAO _instance;
    private static object _syncLock = new object();

    protected AppUsersDAO()
    {
    }

    public static AppUsersDAO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new AppUsersDAO();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public AppUsersInfo GetById(decimal UserId)
    {
      return (AppUsersInfo)CBO.FillObject(SqlDataAccess.ExecuteReader(
        SqlConnect.ConnectionString, 
        Constants.Instance().AppAuthPkgGetById, 
          new object[] {
            Globals.DB_GetNull(UserId)
          }), typeof(AppUsersInfo)
      );
    }
    public void UserChangePassword(AppUsersInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(
        SqlConnect.ConnectionString, 
        Constants.Instance().AppAuthPkgUserChangePassword, 
        new object[] {
          Globals.DB_GetNull(objInfo.Id), 
          Globals.DB_GetNull(objInfo.Password)
        });
    }
    public DataSet GetByTenant(string tenantName)
    {
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString, 
        Constants.Instance().AppAuthPkgGetByTenant, 
        new object[] {
          Globals.DB_GetNull(tenantName)
        }
      );
    }
    public AppUsersInfo GetByTenantAndUser(string tenantName, string userName)
    {
      return (AppUsersInfo)CBO.FillObject(SqlDataAccess.ExecuteReader(
        SqlConnect.ConnectionString, 
        Constants.Instance().AppAuthPkgGetByTenantAndUser, 
        new object[] {
          Globals.DB_GetNull(tenantName),
          Globals.DB_GetNull(userName)
        }), 
        typeof(AppUsersInfo)
      );
    }
    public void UpdateFailedLogin(AppUsersInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(
        SqlConnect.ConnectionString, 
        Constants.Instance().AppAuthPkgUpdateFailedLogin, 
        new object[] {
          Globals.DB_GetNull(objInfo.TenantId),
          Globals.DB_GetNull(objInfo.UserName),
          Globals.DB_GetNull(objInfo.NumLoginFailed)
        });
    }
  }
}