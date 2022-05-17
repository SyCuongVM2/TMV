using System;
using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.Common;
using TMV.DataAccess.Admin;

namespace TMV.BusinessObject.Admin
{
  public class APP_LogbookBO
  {
    #region "Constructor"
    private static APP_LogbookBO _instance;
    private static object _syncLock = new object();

    protected APP_LogbookBO()
    {
    }

    public static APP_LogbookBO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_LogbookBO();
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
      APP_LogbookDAO.Instance().Delete(LOG_ID);
    }

    public DataSet GetAll()
    {
      return APP_LogbookDAO.Instance().GetAll();
    }

    public APP_LogbookInfo GetById(decimal LOG_ID)
    {
      return APP_LogbookDAO.Instance().GetById(LOG_ID);
    }

    public void Insert(UserActionEnum Log_Action, string Log_Description, string Form_Name)
    {
      string Computer_Name = Environment.MachineName;
      string Windows_User = Environment.UserName;
      decimal User_Id = Globals.LoginUserID;
      APP_LogbookDAO.Instance().Insert(Computer_Name, Windows_User, Convert.ToString((int)Log_Action), Log_Description, Form_Name, User_Id);
    }

    public DataSet Search(string Log_Action, decimal Login_User_ID, DateTime From_Date, DateTime To_Date)
    {
      return APP_LogbookDAO.Instance().Search(Log_Action, Login_User_ID, From_Date, To_Date);
    }

    public void Update(APP_LogbookInfo objInfo)
    {
      APP_LogbookDAO.Instance().Update(objInfo);
    }

    public void UserCloseScreen(string FormDesc, string FormName)
    {
      this.Insert(UserActionEnum.UserCloseScreen, FormDesc, FormName);
    }

    public void UserLogin()
    {
      this.Insert(UserActionEnum.UserLogin, "User Login", "");
    }

    public void UserLogOut()
    {
      this.Insert(UserActionEnum.UserLogOut, "User LogOut", "");
    }

    public void UserOpenScreen(string FormDesc, string FormName)
    {
      this.Insert(UserActionEnum.UserOpenScreen, FormDesc, FormName);
    }

    public enum UserActionEnum
    {
      UserCloseScreen = 4,
      UserLogin = 1,
      UserLogOut = 2,
      UserOpenScreen = 3
    }
  }
}