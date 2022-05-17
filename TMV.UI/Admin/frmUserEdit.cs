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
  public partial class frmUserEdit : DevExpress.XtraEditors.XtraForm
  {
    private FormGlobals.DataInputState m_InputState;
    private decimal m_UserID;

    public frmUserEdit()
    {
      InitializeComponent();
    }

    public bool ShowForm(decimal UserID, FormGlobals.DataInputState state)
    {
      FormGlobals.Form_SetText(this, "User", state, "");
      FormGlobals.Form_InitDialog(this);
      m_InputState = state;
      m_UserID = UserID;
      frmProgress.Instance().Thread = new MethodInvoker(InitForm);
      frmProgress.Instance().Show_Progress();
      return (ShowDialog() == DialogResult.OK);
    }
    private void InitForm()
    {
      InitControl();
      switch (m_InputState)
      {
        case FormGlobals.DataInputState.EditMode:
          txtUser_Name.Properties.ReadOnly = true;
          txtUser_Password.Properties.ReadOnly = true;
          txtRetype.Properties.ReadOnly = true;
          dteUPDATE_PASSWORD.Properties.ReadOnly = true;
          dteCREATE_DATE.Properties.ReadOnly = true;
          SetUserData();
          txtRetype.Text = txtUser_Password.Text;
          break;
        case FormGlobals.DataInputState.AddMode:
          setDefaultValue();
          break;
        case FormGlobals.DataInputState.VersionMode:
          txtUser_Name.Properties.ReadOnly = true;
          txtFull_Name.Properties.ReadOnly = true;
          speIsLocked.Properties.ReadOnly = true;
          speDisableAfterFailed.Properties.ReadOnly = true;
          speNOPASSWORDHISTORY.Properties.ReadOnly = true;
          speSendEmail.Properties.ReadOnly = true;
          speIsLocked.Properties.ReadOnly = true;
          dteEffective_Date.Properties.ReadOnly = true;
          dteExprired_Date.Properties.ReadOnly = true;
          speIsLocked.Properties.ReadOnly = true;
          dteUPDATE_PASSWORD.Properties.ReadOnly = true;
          dteCREATE_DATE.Properties.ReadOnly = true;
          SetUserData();
          txtRetype.Text = "";
          txtUser_Password.Text = "";
          spePASSWORDCHANGEAFTER.Properties.ReadOnly = true;
          break;
      }
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
    private void setDefaultValue()
    {
      DataTable tbUserInfor = APP_DomainBO.Instance().GetByDomainAndItem("USER_INFOR", "PASSWORD_EXPIRED");
      DataTable tblPASSWORD_WARRNING = APP_DomainBO.Instance().GetByDomainAndItem("USER_INFOR", "PASSWORD_WARRNING");
      DataTable tblPASSWORD_CANNOT_REPEAT = APP_DomainBO.Instance().GetByDomainAndItem("USER_INFOR", "PASSWORD_CANNOT_REPEAT");
      DataTable tblPASSWORD_DISABLED = APP_DomainBO.Instance().GetByDomainAndItem("USER_INFOR", "PASSWORD_DISABLED");
      dteEffective_Date.EditValue = DateTime.Today;
      dteExprired_Date.EditValue = Globals.DateAdd(Globals.DateInterval.Month, DateTime.Today, 3);
      dteUPDATE_PASSWORD.Properties.ReadOnly = true;
      dteCREATE_DATE.EditValue = DateTime.Today;
      dteCREATE_DATE.Properties.ReadOnly = true;
      spePASSWORDCHANGEAFTER.EditValue = Convert.ToInt32(tbUserInfor.Rows[0]["ITEM_VALUE"].ToString());
      speSendEmail.EditValue = Convert.ToInt32(tblPASSWORD_WARRNING.Rows[0]["ITEM_VALUE"].ToString());
      speNOPASSWORDHISTORY.EditValue = Convert.ToInt32(tblPASSWORD_CANNOT_REPEAT.Rows[0]["ITEM_VALUE"].ToString());
      speDisableAfterFailed.EditValue = Convert.ToInt32(tblPASSWORD_DISABLED.Rows[0]["ITEM_VALUE"].ToString());
    }
    private int ValidateLogon()
    {
      if ((txtUser_Name.Text.ToUpper() == "ADMIN") & speIsLocked.Checked)
      {
        FormGlobals.Message_Information("User cannot locked Admin User!");
        return 1;
      }
      if (txtUser_Password.Text.Trim() == txtUser_Name.Text.Trim())
      {
        FormGlobals.Message_Warning_Error("Password cannot be the same as the User ID");
        return 1;
      }
      DataTable tbUserInfor = APP_DomainBO.Instance().GetByDomainAndItem("USER_INFOR", "PASSWORD_LENGTH");
      if (txtUser_Password.Text.Length < Convert.ToInt32(tbUserInfor.Rows[0]["ITEM_VALUE"].ToString()))
      {
        FormGlobals.Message_Warning_Error("Password must be a minimum of " + tbUserInfor.Rows[0]["ITEM_VALUE"].ToString() + " characters");
        return 1;
      }
      string sPattern = @"\d";
      Regex oReg = new Regex(sPattern, RegexOptions.IgnoreCase);
      if (!oReg.IsMatch(txtUser_Password.Text))
      {
        FormGlobals.Message_Warning_Error("Password should contain mimimum one numeric character. Ex: 1,2 ,3 ...");
        return 1;
      }
      string sPatternNonAlphabet = "[a-zA-Z]";
      Regex oRegNonAlphabet = new Regex(sPatternNonAlphabet, RegexOptions.IgnoreCase);
      if (!oRegNonAlphabet.IsMatch(txtUser_Password.Text))
      {
        FormGlobals.Message_Warning_Error("Password should contain mimimum one non-alphanumeric character. Ex: a, b,c, A, B, C ...");
        return 1;
      }
      string sPatternAlphabet = "[^a-zA-Z_0-9]";
      Regex oRegAlphabet = new Regex(sPatternAlphabet, RegexOptions.IgnoreCase);
      if (!oRegAlphabet.IsMatch(txtUser_Password.Text))
      {
        FormGlobals.Message_Warning_Error("Password should contain mimimum one alphabet character. Ex:@, #,$,%...");
        return 1;
      }
      if (txtUser_Password.Text.Trim().Length < 6)
      {
        FormGlobals.Message_Warning_Error("Password cannot less than 6 charaters");
        return 1;
      }
      if (txtUser_Password.Text != txtRetype.Text)
      {
        FormGlobals.Message_Information("Password and Retype Password must the same value!");
        return 1;
      }
      if (Convert.ToInt32(speNOPASSWORDHISTORY.EditValue.ToString()) < 6)
      {
        FormGlobals.Message_Warning_Error("Password history must repeat greater than 6");
        return 1;
      }
      if (Convert.ToInt32(speDisableAfterFailed.EditValue.ToString()) < 5)
      {
        FormGlobals.Message_Warning_Error("Password disable after failed must greater than 5");
        return 1;
      }
      if (Convert.ToInt32(spePASSWORDCHANGEAFTER.EditValue.ToString()) > 180)
      {
        FormGlobals.Message_Warning_Error("Password expried must less than 180 days");
        return 1;
      }
      return 0;
    }
    private void SaveData()
    {
      try
      {
        APP_UsersInfo ObjInfo = new APP_UsersInfo();
        FormGlobals.Panel_GetControlValue(grpUserInfo, ObjInfo, "APP_USERS");
        ObjInfo.USER_ID = m_UserID;
        switch (m_InputState)
        {
          case FormGlobals.DataInputState.EditMode:
            APP_UsersBO.Instance().Update(ObjInfo);
            break;
          case FormGlobals.DataInputState.AddMode:
          case FormGlobals.DataInputState.CopyMode:
            APP_UsersBO.Instance().Insert(ObjInfo);
            break;
          case FormGlobals.DataInputState.VersionMode:
            APP_UsersBO.Instance().ChangePassword(ObjInfo);
            break;
        }
      }
      catch (Exception ex)
      {
        throw new Exception(ex.ToString());
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        if (FormGlobals.Panel_CheckError(grpUserInfo) && (ValidateLogon() == 0))
        {
          frmProgress.Instance().Thread = new MethodInvoker(SaveData);
          frmProgress.Instance().Show_Progress("Saving data");
          frmProgress.Instance().SetFinishText(Constants.Instance().MESSAGE_SAVE_SUCCESS, 500);
          Tag = txtUser_Name.Text;
          DialogResult = DialogResult.OK;
          Close();
        }
      }
      catch (Exception ex)
      {
        if (ex.Message.IndexOf("Duplicate entry") >= 0)
          FormGlobals.Message_Information("User Name '" + txtUser_Name.Text.ToUpper() + "' already existed in the system!");
        else
          FormGlobals.Message_Error(ex);
      }
    }
    private void btnClear_Click(object sender, EventArgs e)
    {
      FormGlobals.Control_ClearData(grpUserInfo, false);
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