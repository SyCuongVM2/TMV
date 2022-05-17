using System;

namespace TMV.ObjectInfo.Admin
{
  public class APP_UsersInfo
  {
    public DateTime CREATE_DATE { get; set; }
    public decimal DISABLEAFTERFAILED { get; set; }
    public DateTime EFFECTIVE_DATE { get; set; }
    public string EMAIL { get; set; }
    public DateTime EXPRIRED_DATE { get; set; }
    public string FULL_NAME { get; set; }
    public decimal ISCHANGEPASSWORD { get; set; }
    public decimal ISLOCKED { get; set; }
    public decimal ISNEXTLOGON { get; set; }
    public decimal NOFAILEDLOGIN { get; set; }
    public decimal NOPASSWORDHISTORY { get; set; }
    public string PASSWORD_HISTORY { get; set; }
    public decimal PASSWORDCHANGEAFTER { get; set; }
    public decimal SENDEMAIL { get; set; }
    public string TEL { get; set; }
    public DateTime UPDATE_DATE { get; set; }
    public DateTime UPDATE_PASSWORD { get; set; }
    public decimal USER_ID { get; set; }
    public string USER_NAME { get; set; }
    public string USER_PASSWORD { get; set; }

    public APP_UsersInfo()
    {
    }

    public APP_UsersInfo(decimal ISLOCKED, decimal USERID, string USERNAME, string FULLNAME, string USERPASSWORD)
    {
      ISLOCKED = ISLOCKED;
      USER_ID = USERID;
      USER_NAME = USERNAME;
      FULL_NAME = FULLNAME;
      USER_PASSWORD = USERPASSWORD;
    }
  }
}