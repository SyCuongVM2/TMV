using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TMV.BusinessObject.Admin;
using TMV.Common;
using TMV.Common.Forms;
using TMV.ObjectInfo.Admin;

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
      txtUser_Name.Properties.ReadOnly = true;
      txtFull_Name.Properties.ReadOnly = true;
      FormGlobals.Control_SetRequire(txtOld_Password, true);
      SetUserData();
      m_OldPassword = txtUser_Password.Text; // get old hashed password
      txtRetype.Text = "";
      txtUser_Password.Text = "";
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
      FormGlobals.Panel_InitControl(grpUserInfo, "APP_USERS");
    }
    private bool ValidOldPassword()
    {
      return APP_UsersBO.Instance().VerifiedPassword(m_OldPassword, txtOld_Password.Text.Trim());
      //return (APP_UsersBO.Instance().EncryptPassword(txtUser_Name.Text, txtOld_Password.Text) == m_OldPassword);
    }
    private bool ValidPasswordHistory()
    {
      int iNOPASSWORDHISTORY = Convert.ToInt32(APP_UsersBO.Instance().GetAccountPolicy(Globals.LoginUserID).Tables[0].Rows[0]["NOPASSWORDHISTORY"].ToString());
      bool result = true;
      string sType = APP_UsersBO.Instance().EncryptPassword(txtUser_Name.Text, txtUser_Password.Text);
      string sHistory = APP_UsersBO.Instance().GetAccountPolicy(Globals.LoginUserID).Tables[0].Rows[0]["PASSWORD_HISTORY"].ToString();
      int I = 0;
      string[] sArray = sHistory.Split(";;;##".ToCharArray());
      if (sArray.Length > iNOPASSWORDHISTORY)
      {
        for (I = sArray.Length - iNOPASSWORDHISTORY; I <= sArray.Length - 1; I++)
        {
          if (sType.ToString() == sArray[I].ToString())
            result = false;
        }
      }
      else
      {
        for (I = 0; I <= sArray.Length - 1; I++)
        {
          if (sType.ToString() == sArray[I].ToString())
            result = false;
        }
      }
      return result;
    }
    private void SaveData()
    {
      try
      {
        APP_UsersInfo ObjInfo = new APP_UsersInfo();
        FormGlobals.Panel_GetControlValue(grpUserInfo, ObjInfo, "APP_USERS");
        ObjInfo.USER_ID = m_UserID;
        ObjInfo.USER_PASSWORD = APP_UsersBO.Instance().EncryptPassword(txtUser_Name.Text.Trim(), txtUser_Password.Text.Trim());
        ObjInfo.PASSWORD_HISTORY = APP_UsersBO.Instance().GetAccountPolicy(Globals.LoginUserID).Tables[0].Rows[0]["PASSWORD_HISTORY"].ToString();
        APP_UsersBO.Instance().UserChangePassword(ObjInfo);
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
      int iNOPASSWORDHISTORY = 0;
      string passwordMinimum = "";

      try
      {
        iNOPASSWORDHISTORY = Convert.ToInt32(APP_UsersBO.Instance().GetAccountPolicy(Globals.LoginUserID).Tables[0].Rows[0]["NOPASSWORDHISTORY"].ToString());

        if (FormGlobals.Panel_CheckError(grpUserInfo))
          return;

        if (!ValidOldPassword())
        {
          FormGlobals.Message_Warning_Error("Old Password not valid!");
          return;
        }

        if (txtUser_Password.Text.Trim() == txtUser_Name.Text.Trim())
          FormGlobals.Message_Warning_Error("Password cannot be the same as the User ID");

        if ((txtUser_Password.Text.Trim() == string.Empty) || (txtRetype.Text.Trim() == string.Empty))
        {
          FormGlobals.Message_Information("Please enter New Password and Retype Password before change password!");
          return;
        }

        DataTable tbUserInfor = APP_DomainBO.Instance().GetByDomainAndItem("USER_INFOR", "PASSWORD_LENGTH");
        if (txtUser_Password.Text.Length < Convert.ToInt32(tbUserInfor.Rows[0]["ITEM_VALUE"].ToString()))
        {
          passwordMinimum = "Password must be a minimum of " + tbUserInfor.Rows[0]["ITEM_VALUE"].ToString() + " characters";
          FormGlobals.Message_Warning_Error(passwordMinimum);
          return;
        }
        string sPattern = @"\d";
        Regex oReg = new Regex(sPattern, RegexOptions.IgnoreCase);
        if (!oReg.IsMatch(txtUser_Password.Text))
        {
          FormGlobals.Message_Warning_Error("Password should contain mimimum one numeric character. Ex: 1,2 ,3 ...");
          return;
        }
        string sPatternNonAlphabet = "[a-zA-Z]";
        Regex oRegNonAlphabet = new Regex(sPatternNonAlphabet, RegexOptions.IgnoreCase);
        if (!oRegNonAlphabet.IsMatch(txtUser_Password.Text))
        {
          FormGlobals.Message_Warning_Error("Password should contain mimimum one non-alphanumeric character. Ex: a, b,c, A, B, C ...");
          return;
        }

        string sPatternAlphabet = "[^a-zA-Z_0-9]";
        Regex oRegAlphabet = new Regex(sPatternAlphabet, RegexOptions.IgnoreCase);
        if (!oRegAlphabet.IsMatch(txtUser_Password.Text))
        {
          FormGlobals.Message_Warning_Error("Password should contain mimimum one alphabet character. Ex:@, #,$,%...");
          return;
        }

        //if (!ValidPasswordHistory())
        //{
        //  FormGlobals.Message_Warning_Error("Password cannot repeat any of the previous" + iNOPASSWORDHISTORY.ToString() + " passwords they had used before");
        //  return;
        //}

        if (txtUser_Password.Text != txtRetype.Text)
        {
          FormGlobals.Message_Information("Password and Retype Password must the same value!");
          return;
        }

        frmProgress.Instance().Thread = new MethodInvoker(SaveData);
        frmProgress.Instance().Show_Progress("Changing password! Please wait...");
        frmProgress.Instance().SetFinishText(Constants.Instance().MESSAGE_SAVE_SUCCESS, 500);
        Tag = txtUser_Name.Text;
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