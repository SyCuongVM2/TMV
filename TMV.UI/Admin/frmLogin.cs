using System;
using System.Configuration;
using System.Windows.Forms;
using TMV.BusinessObject.Auth;
using TMV.Common;
using TMV.Common.Forms;
using TMV.ObjectInfo.Auth;

namespace TMV.UI.Admin
{
  public partial class frmLogin : DevExpress.XtraEditors.XtraForm
  {
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
    private void InitControl()
    {
      FormGlobals.Control_SetFont(this, FormGlobals.CS_FONT_NAME);
    }
    private bool Login()
    {
      try
      {
        AppUsersInfo ObjInfo = AppUsersBO.Instance().GetByTenantAndUser(txtDealer.Text.Trim(), txtUser_Name.Text.Trim());
        if (ObjInfo != null)
        {
          bool verified = AppUsersBO.Instance().VerifiedPassword(ObjInfo.Password, txtUser_Password.Text.Trim());
          if (verified)
          {
            Globals.LoginUserID = ObjInfo.Id;
            Globals.LoginUserName = ObjInfo.UserName;
            Globals.LoginFullName = ObjInfo.Name;

            Globals.LoginDlrId = ObjInfo.TenantId;
            Globals.LoginDealerCode = ObjInfo.TenantCode;
            Globals.LoginDealerAbbr = ObjInfo.TenantAbbr;
            Globals.LoginDealerName = ObjInfo.TenantName;

            Globals.LoginTitleId = ObjInfo.TitleId;
            Globals.LoginTitleCode = ObjInfo.TitleCode;
            Globals.LoginTitleName = ObjInfo.TitleName;

            if (m_Dealer.ToUpper() != txtDealer.Text.Trim().ToUpper())
              mdlAdmin.WriteSetting("LastLoginDealer", ObjInfo.TenantAbbr);

            if (m_UserName.ToUpper() != txtUser_Name.Text.Trim().ToUpper())
              mdlAdmin.WriteSetting("LastLoginUser", ObjInfo.UserName);

            if (Convert.ToBoolean(speRememberPassword.EditValue.ToString()))
              mdlAdmin.WriteSetting("LastLoginPassword", AppSecurity.Base64Encode(txtUser_Password.Text.Trim()));
            else
              mdlAdmin.WriteSetting("LastLoginPassword", "");

            ObjInfo.NumLoginFailed = 0;
            AppUsersBO.Instance().UpdateFailedLogin(ObjInfo);

            return true;
          }

          ObjInfo.NumLoginFailed = ObjInfo.NumLoginFailed + 1;
          AppUsersBO.Instance().UpdateFailedLogin(ObjInfo);
          FormGlobals.Message_Warning_Error("Invalid Password! You have " + ObjInfo.NumLoginFailed.ToString() + " consecutive failed login.");

          return false;
        }
        FormGlobals.Message_Information("Invalid Dealer or User Name!");
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }

      return false;
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
        txtUser_Password.Text = string.IsNullOrEmpty(m_UserPassword) ? string.Empty : AppSecurity.Base64Decode(m_UserPassword);

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
        bool isPassed = true;

        if (txtDealer.Text.Trim() == "")
        {
          isPassed = false;
          FormGlobals.Message_Information("Dealer cannot be empty!");
          txtDealer.Focus();
        }
        else
        {
          if (AppUsersBO.Instance().GetByTenant(txtDealer.Text.Trim()).Tables[0].Rows.Count == 0)
          {
            isPassed = false;
            FormGlobals.Message_Information("Dealer is not existed!");
            txtDealer.Focus();
          }
        }

        if (txtUser_Name.Text.Trim() == "")
        {
          isPassed = false;
          FormGlobals.Message_Information("User Name cannot be empty!");
          txtUser_Name.Focus();
        }
        else if (txtUser_Password.Text == "")
        {
          isPassed = false;
          FormGlobals.Message_Information("Password cannot be empty!");
          txtUser_Password.Focus();
        }
        
        if (isPassed && Login())
        {
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