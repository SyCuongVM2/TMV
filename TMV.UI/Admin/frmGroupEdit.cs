using System;
using System.Windows.Forms;
using TMV.BusinessObject.Admin;
using TMV.Common;
using TMV.Common.Forms;
using TMV.ObjectInfo.Admin;

namespace TMV.UI.Admin
{
  public partial class frmGroupEdit : DevExpress.XtraEditors.XtraForm
  {
    private decimal m_GroupID;
    private FormGlobals.DataInputState m_InputState;

    public frmGroupEdit()
    {
      InitializeComponent();
    }

    public bool ShowForm(decimal UserID, FormGlobals.DataInputState state)
    {
      FormGlobals.Form_SetText(this, "Group", state, "");
      FormGlobals.Form_InitDialog(this);
      m_InputState = state;
      m_GroupID = UserID;
      frmProgress.Instance().Thread = new MethodInvoker(InitForm);
      frmProgress.Instance().Show_Progress();
      return (ShowDialog() == DialogResult.OK);
    }
    private void InitForm()
    {
      InitControl();
      if (m_InputState == FormGlobals.DataInputState.EditMode)
        SetUserData();
    }
    private void SetUserData()
    {
      try
      {
        APP_GroupsInfo oGroupInfo = APP_GroupsBO.Instance().GetById(m_GroupID);
        FormGlobals.Panel_SetControlValue(grpGroupInfo, oGroupInfo);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void InitControl()
    {
      FormGlobals.Control_SetFont(this, FormGlobals.CS_FONT_NAME);
      FormGlobals.Panel_InitControl(grpGroupInfo, "APP_GROUPS");
    }
    private void SaveData()
    {
      try
      {
        APP_GroupsInfo ObjInfo = new APP_GroupsInfo();
        FormGlobals.Panel_GetControlValue(grpGroupInfo, ObjInfo, "APP_GROUPS");
        ObjInfo.GROUP_ID = m_GroupID;
        switch (m_InputState)
        {
          case FormGlobals.DataInputState.AddMode:
          case FormGlobals.DataInputState.CopyMode:
            APP_GroupsBO.Instance().Insert(ObjInfo);
            break;
          case FormGlobals.DataInputState.EditMode:
            APP_GroupsBO.Instance().Update(ObjInfo);
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
        if (FormGlobals.Panel_CheckError(grpGroupInfo))
        {
          frmProgress.Instance().Thread = new MethodInvoker(SaveData);
          frmProgress.Instance().Show_Progress("Saving data");
          frmProgress.Instance().SetFinishText(Constants.Instance().MESSAGE_SAVE_SUCCESS, 500);
          Tag = txtGROUP_TEXT.Text;
          DialogResult = DialogResult.OK;
          Close();
        }
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