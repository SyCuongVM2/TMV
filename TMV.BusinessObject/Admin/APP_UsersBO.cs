using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.DataAccess.Admin;
using TMV.Common;

namespace TMV.BusinessObject.Admin
{
  public class APP_UsersBO
  {
    #region "Constructor"
    private static APP_UsersBO _instance;
    private static object _syncLock = new object();

    protected APP_UsersBO()
    {
    }

    public static APP_UsersBO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_UsersBO();
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
      objInfo.USER_PASSWORD = EncryptPassword(objInfo.USER_NAME, objInfo.USER_PASSWORD);
      APP_UsersDAO.Instance().ChangePassword(objInfo);
    }
    public void Delete(decimal USER_ID)
    {
      APP_UsersDAO.Instance().Delete(USER_ID);
    }
    private string EncodePassword(string pass, int passwordFormat, string salt)
    {
      //if (passwordFormat == 0)
      //  return pass;

      //byte[] bIn = Encoding.Unicode.GetBytes(pass);
      //byte[] bSalt = Convert.FromBase64String(salt);
      //byte[] bAll = new byte[(bSalt.Length + (bIn.Length - 1)) + 1];
      //byte[] bRet = null;
      //Buffer.BlockCopy(bSalt, 0, bAll, 0, bSalt.Length);
      //Buffer.BlockCopy(bIn, 0, bAll, bSalt.Length, bIn.Length);

      //if (passwordFormat == 1)
      //  bRet = HashAlgorithm.Create("SHA1").ComputeHash(bAll);
      //else
      //  bRet = null;

      //return Convert.ToBase64String(bRet);

      return AppSecurity.HashPassword(pass);
    }
    public string EncryptPassword(string UserName, string Password)
    {
      string salt = "Mu1Ig2cnhuugFbWQpRmo4g==";
      //return EncodePassword(UserName.ToUpper().Trim() + Password, 1, salt);
      return EncodePassword(Password, 1, salt);
    }
    public bool VerifiedPassword(string hashedPassword, string Password)
    {
      return AppSecurity.VerifyHashedPassword(hashedPassword, Password);
    }
    public DataSet GetAccountPolicy(decimal USERID)
    {
      return APP_UsersDAO.Instance().GetAccountPolicy(USERID);
    }
    public DataSet GetAll()
    {
      return APP_UsersDAO.Instance().GetAll();
    }
    public APP_UsersInfo GetById(decimal USER_ID)
    {
      return APP_UsersDAO.Instance().GetById(USER_ID);
    }
    public APP_UsersInfo GetByUserName(string USERNAME)
    {
      return APP_UsersDAO.Instance().GetByUserName(USERNAME);
    }
    public DataSet GetUserFormButton(decimal USERID, string MENUNAME, string FORMNAME, string PARENTNAME)
    {
      return APP_UsersDAO.Instance().GetUserFormButton(USERID, MENUNAME, FORMNAME, PARENTNAME);
    }
    public DataSet GetUserGroup(decimal USERID)
    {
      return APP_UsersDAO.Instance().GetUserGroup(USERID);
    }
    public DataSet GetUserMenu(decimal USERID)
    {
      return APP_UsersDAO.Instance().GetUserMenu(USERID);
    }
    public void Insert(APP_UsersInfo objInfo)
    {
      objInfo.USER_PASSWORD = EncryptPassword(objInfo.USER_NAME, objInfo.USER_PASSWORD);
      APP_UsersDAO.Instance().Insert(objInfo);
    }
    public DataSet isExpiredPassword(decimal USERID)
    {
      return APP_UsersDAO.Instance().isExpiredPassword(USERID);
    }
    public void Update(APP_UsersInfo objInfo)
    {
      APP_UsersDAO.Instance().Update(objInfo);
    }
    public void UpdateFailed(APP_UsersInfo objInfo)
    {
      APP_UsersDAO.Instance().UpdateFailed(objInfo);
    }
    public void UserChangePassword(APP_UsersInfo objInfo)
    {
      objInfo.USER_PASSWORD = this.EncryptPassword(objInfo.USER_NAME, objInfo.USER_PASSWORD);
      objInfo.PASSWORD_HISTORY = objInfo.PASSWORD_HISTORY + ";;;##" + objInfo.USER_PASSWORD;
      APP_UsersDAO.Instance().UserChangePassword(objInfo);
    }
  }
}