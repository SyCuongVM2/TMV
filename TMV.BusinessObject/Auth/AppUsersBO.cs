using System.Data;
using TMV.ObjectInfo.Auth;
using TMV.DataAccess.Auth;
using TMV.Common;

namespace TMV.BusinessObject.Auth
{
  public class AppUsersBO
  {
    #region "Constructor"
    private static AppUsersBO _instance;
    private static object _syncLock = new object();

    protected AppUsersBO()
    {
    }
    public static AppUsersBO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new AppUsersBO();
        }
      }
      return _instance;
    }
    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public bool VerifiedPassword(string hashedPassword, string password)
    {
      return AppSecurity.VerifyHashedPassword(hashedPassword, password);
    }
    public string EncryptPassword(string password)
    {
      return AppSecurity.HashPassword(password);
    }
    public AppUsersInfo GetById(decimal UserId)
    {
      return AppUsersDAO.Instance().GetById(UserId);
    }
    public void UserChangePassword(AppUsersInfo objInfo)
    {
      objInfo.Password = EncryptPassword(objInfo.Password);
      AppUsersDAO.Instance().UserChangePassword(objInfo);
    }
    public DataSet GetByTenant(string tenantName)
    {
      return AppUsersDAO.Instance().GetByTenant(tenantName);
    }
    public AppUsersInfo GetByTenantAndUser(string tenantName, string userName)
    {
      return AppUsersDAO.Instance().GetByTenantAndUser(tenantName, userName);
    }
    public void UpdateFailedLogin(AppUsersInfo objInfo)
    {
      AppUsersDAO.Instance().UpdateFailedLogin(objInfo);
    }
  }
}