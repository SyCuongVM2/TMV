using System;
using System.Configuration;
using System.Windows.Forms;
using TMV.BusinessObject.Admin;
using TMV.Common;
using TMV.Common.Forms;
using TMV.ObjectInfo.Admin;

namespace TMV.UI.Admin
{
  public partial class frmLogin : DevExpress.XtraEditors.XtraForm
  {
    private decimal m_UserID = 0;
    private string m_Dealer;
    private string m_UserName;
    private string m_UserPassword;

    public frmLogin()
    {
      InitializeComponent();
    }
    public bool ShowForm()
    {
      FormGlobals.Form_InitDialog(this);
      frmProgress.Instance().Thread = new MethodInvoker(InitForm);
      frmProgress.Instance().Show_Progress();
      return (ShowDialog() == DialogResult.OK);
    }
    private void InitForm()
    {
      InitControl();
    }
    private void SetUserData()
    {
      try
      {
        APP_UsersInfo oUserInfo = APP_UsersBO.Instance().GetById(m_UserID);
        FormGlobals.Panel_SetControlValue(grpUserInfo, oUserInfo);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void InitControl()
    {
      FormGlobals.Control_SetFont(this, FormGlobals.CS_FONT_NAME);
    }
    private bool Login()
    {
      bool bRet = false;
      try
      {
        // 5YTTn6wFMHmYoNSVLsRIAE8Uv2c=
        APP_UsersInfo ObjInfo = APP_UsersBO.Instance().GetByUserName(txtUser_Name.Text.Trim());
        if (ObjInfo != null)
        {
          if ((ObjInfo.ISLOCKED == 0) || (ObjInfo.PASSWORDCHANGEAFTER < 0))
          {
            bool verified = false;
            if (m_UserPassword != "") // Remember password
              verified = (ObjInfo.USER_PASSWORD == m_UserPassword) ? true : false;
            else
              verified = APP_UsersBO.Instance().VerifiedPassword(ObjInfo.USER_PASSWORD, txtUser_Password.Text.Trim());

            if (verified)
            {
              bRet = true;
              Globals.LoginUserID = ObjInfo.USER_ID;
              Globals.LoginUserName = ObjInfo.USER_NAME;
              Globals.LoginFullName = ObjInfo.FULL_NAME;
              if (m_UserName.ToUpper() != txtUser_Name.Text.Trim().ToUpper())
                mdlAdmin.WriteSetting("LastLoginUser", ObjInfo.USER_NAME);

              if (Convert.ToBoolean(speRememberPassword.EditValue.ToString()))
                mdlAdmin.WriteSetting("LastLoginPassword", ObjInfo.USER_PASSWORD);
              else
                mdlAdmin.WriteSetting("LastLoginPassword", "");

              ObjInfo.NOFAILEDLOGIN = decimal.Zero;
              APP_UsersBO.Instance().UpdateFailed(ObjInfo);
              if (APP_UsersBO.Instance().isExpiredPassword(Globals.LoginUserID).Tables[0].Rows[0]["ISUSEREXPIRED"].ToString() == "1")
              {
                FormGlobals.Message_Warning_Error("Your password is expired. You must contact System Admin to reset your password.");
                Close();
                bRet = false;
              }
              return bRet;
            }
            ObjInfo.NOFAILEDLOGIN = decimal.Add(ObjInfo.NOFAILEDLOGIN, decimal.One);
            APP_UsersBO.Instance().UpdateFailed(ObjInfo);
            FormGlobals.Message_Warning_Error("Invalid Password! You have " + ObjInfo.NOFAILEDLOGIN.ToString() + " consecutive failed login.");
            return bRet;
          }
          FormGlobals.Message_Information("User Name has been Locked. Please contact with Administration!");
          return bRet;
        }
        FormGlobals.Message_Information("Invalid User Name!");
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
      return bRet;
    }

    private void frmLogin_Load(object sender, EventArgs e)
    {
      try
      {
        m_Dealer = ConfigurationManager.AppSettings["LastLoginDealer"];
        txtDealer.Text = m_Dealer;
        m_UserName = ConfigurationManager.AppSettings["LastLoginUser"];
        txtUser_Name.Text = m_UserName;
        m_UserPassword = ConfigurationManager.AppSettings["LastLoginPassword"];
        txtUser_Password.Text = m_UserPassword;
        if (m_UserPassword != "")
          speRememberPassword.EditValue = true;
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnLogin_Click(object sender, EventArgs e)
    {
      try
      {
        if (txtDealer.Text.Trim() == "")
        {
          FormGlobals.Message_Information("Dealer cannot be empty!");
          txtDealer.Focus();
        }
        if (txtUser_Name.Text.Trim() == "")
        {
          FormGlobals.Message_Information("User Name cannot be empty!");
          txtUser_Name.Focus();
        }
        else if (txtUser_Password.Text == "")
        {
          FormGlobals.Message_Information("Password cannot be empty!");
          txtUser_Password.Focus();
        }
        else if (Login())
        {
          if (Convert.ToInt32(APP_UsersBO.Instance().GetAccountPolicy(Globals.LoginUserID).Tables[0].Rows[0]["SENDEMAIL"].ToString()) <= 0)
            FormGlobals.Message_Warning_Error("Password will be locked after " + APP_UsersBO.Instance().GetAccountPolicy(Globals.LoginUserID).Tables[0].Rows[0]["EXPRIRED"].ToString() + " days. You must change your password!");

          DialogResult = DialogResult.OK;
          Close();
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnCancel_Click(object sender, EventArgs e)
    {
      try
      {
        Close();
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
  }
}