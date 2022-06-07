using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TMV.BusinessObject.Auth;
using TMV.Common;
using TMV.Common.Forms;
using TMV.ObjectInfo.Auth;

namespace TMV.UI.Admin
{
  public partial class frmChangePassword : DevExpress.XtraEditors.XtraForm
  {
    private string m_OldPassword = "";
    private decimal m_UserID;

    public frmChangePassword()
    {
      InitializeComponent();
    }

    private void ShowForm(decimal UserID)
    {
      FormGlobals.Form_InitDialog(this);
      m_UserID = UserID;
      InitForm();
    }
    private void InitForm()
    {
      InitControl();
      txtUserName.Properties.ReadOnly = true;
      txtName.Properties.ReadOnly = true;
      FormGlobals.Control_SetRequire(txtOldPassword, true);
      SetUserData();
      m_OldPassword = txtPassword.Text; // get old hashed password
      txtRetype.Text = "";
      txtPassword.Text = "";
    }
    private void InitControl()
    {
      FormGlobals.Control_SetFont(this, FormGlobals.CS_FONT_NAME);
      FormGlobals.Panel_InitControl(grpUserInfo, "AbpUsers");
    }
    private void SetUserData()
    {
      try
      {
        AppUsersInfo oUserInfo = AppUsersBO.Instance().GetById(m_UserID);
        FormGlobals.Panel_SetControlValue(grpUserInfo, oUserInfo);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private bool ValidOldPassword()
    {
      return AppUsersBO.Instance().VerifiedPassword(m_OldPassword, txtOldPassword.Text.Trim());
    }
    private void SaveData()
    {
      try
      {
        AppUsersInfo ObjInfo = new AppUsersInfo();
        FormGlobals.Panel_GetControlValue(grpUserInfo, ObjInfo, "AbpUsers");
        ObjInfo.Id = m_UserID;
        ObjInfo.Password = txtPassword.Text.Trim();
        AppUsersBO.Instance().UserChangePassword(ObjInfo);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void frmChangePassword_Load(object sender, EventArgs e)
    {
      FormGlobals.Form_InitDialog(this);
      ShowForm(Globals.LoginUserID);
    }
    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        //if (FormGlobals.Panel_CheckError(grpUserInfo))
        //  return;

        if (!ValidOldPassword())
        {
          FormGlobals.Message_Warning_Error("Current Password is invalid!");
          return;
        }

        if (txtPassword.Text.Trim() == txtUserName.Text.Trim())
          FormGlobals.Message_Warning_Error("Password cannot be the same as the User ID");

        if ((txtPassword.Text.Trim() == string.Empty) || (txtRetype.Text.Trim() == string.Empty))
        {
          FormGlobals.Message_Information("Please enter New Password and Retype Password before change password!");
          return;
        }

        if (txtPassword.Text.Length < 6)
        {
          FormGlobals.Message_Warning_Error("Password must be a minimum of 6 characters");
          return;
        }

        string sPattern = @"\d";
        Regex oReg = new Regex(sPattern, RegexOptions.IgnoreCase);
        if (!oReg.IsMatch(txtPassword.Text))
        {
          FormGlobals.Message_Warning_Error("Password should contain mimimum one numeric character. Ex: 1,2 ,3 ...");
          return;
        }

        string sPatternNonAlphabet = "[a-zA-Z]";
        Regex oRegNonAlphabet = new Regex(sPatternNonAlphabet, RegexOptions.IgnoreCase);
        if (!oRegNonAlphabet.IsMatch(txtPassword.Text))
        {
          FormGlobals.Message_Warning_Error("Password should contain mimimum one non-alphanumeric character. Ex: a, b,c, A, B, C ...");
          return;
        }

        string sPatternAlphabet = "[^a-zA-Z_0-9]";
        Regex oRegAlphabet = new Regex(sPatternAlphabet, RegexOptions.IgnoreCase);
        if (!oRegAlphabet.IsMatch(txtPassword.Text))
        {
          FormGlobals.Message_Warning_Error("Password should contain mimimum one alphabet character. Ex:@, #,$,%...");
          return;
        }

        if (txtPassword.Text != txtRetype.Text)
        {
          FormGlobals.Message_Information("Password and Retype Password must the same value!");
          return;
        }

        frmProgress.Instance().Thread = new MethodInvoker(SaveData);
        frmProgress.Instance().Show_Progress("Changing password! Please wait...");
        frmProgress.Instance().SetFinishText(Constants.Instance().MESSAGE_SAVE_SUCCESS, 500);
        Tag = txtUserName.Text;
        DialogResult = DialogResult.OK;
        Close();
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnClose_Click(object sender, EventArgs e)
    {
      try
      {
        if (FormGlobals.Message_Confirm(Constants.Instance().MESSAGE_SAVE_CONFIRM, false))
          btnSave.PerformClick();
        else
          Close();
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
  }
}