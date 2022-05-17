using System;
using System.Data;
using System.Windows.Forms;
using TMV.BusinessObject.Admin;
using TMV.Common;
using TMV.Common.Forms;
using TMV.ObjectInfo.Admin;

namespace TMV.UI.Admin
{
  public partial class frmSystemDomainEdit : DevExpress.XtraEditors.XtraForm
  {
    private string m_DomainCode;
    private string m_ItemCode;
    private FormGlobals.DataInputState m_States;
    private string m_Test;
    private string MESSAGE_DUPLICATE = "More than 1 record duplicate Domain Code and Item Code";
    private string MESSAGE_SAVE = "Saving data";

    public frmSystemDomainEdit()
    {
      InitializeComponent();
    }

    private void BindData()
    {
      try
      {
        if (m_States != FormGlobals.DataInputState.AddMode)
        {
          APP_DomainInfo info = new APP_DomainInfo();
          info = APP_DomainBO.Instance().GetById(m_DomainCode, m_ItemCode);
          FormGlobals.Panel_SetControlValue(grpALCParamEdit, info, "APP_MASTER_DOMAIN");
        }
        if (m_States == FormGlobals.DataInputState.EditMode)
        {
          txtDomain_Code.Properties.ReadOnly = true;
          txtItem_Code.Properties.ReadOnly = true;
        }
        else
        {
          txtDomain_Code.Properties.ReadOnly = false;
          txtItem_Code.Properties.ReadOnly = false;
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void SaveData()
    {
      APP_DomainInfo SystemParameterInfo = new APP_DomainInfo();
      FormGlobals.Panel_GetControlValue(grpALCParamEdit, SystemParameterInfo, "APP_MASTER_DOMAIN");
      if (SystemParameterInfo != null)
      {
        if (m_States == FormGlobals.DataInputState.EditMode)
        {
          APP_DomainBO.Instance().Update(SystemParameterInfo);
          m_Test = "1";
        }
        else
        {
          DataTable tblTest = APP_DomainBO.Instance().Insert(SystemParameterInfo);
          if (tblTest.Rows.Count >= 1)
            m_Test = tblTest.Rows[0][0].ToString();
        }
      }
    }
    private void InitForm()
    {
      FormGlobals.Control_SetFont(this, FormGlobals.CS_FONT_NAME);
      FormGlobals.Panel_InitControl(grpALCParamEdit, "APP_MASTER_DOMAIN");
      BindData();
    }
    public bool LoadForm(string eDomainCode, string eItemCode, FormGlobals.DataInputState estates)
    {
      bool LoadForm = false;
      try
      {
        FormGlobals.Form_SetText(this, "System Domain Edit", estates, "");
        FormGlobals.Form_InitDialog(this);
        m_ItemCode = eItemCode;
        m_States = estates;
        m_DomainCode = eDomainCode;
        if ((m_States == FormGlobals.DataInputState.AddMode) || (m_States == FormGlobals.DataInputState.CopyMode))
          txtItem_Order.Enabled = false;
        frmProgress.Instance().Thread = new MethodInvoker(InitForm);
        frmProgress.Instance().Show_Progress();
        LoadForm = ShowDialog() == DialogResult.OK;
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
      return LoadForm;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        if (FormGlobals.Panel_CheckError(grpALCParamEdit))
        {
          frmProgress.Instance().Thread = new MethodInvoker(SaveData);
          frmProgress.Instance().Show_Progress(MESSAGE_SAVE);
          if (m_Test == "1")
          {
            frmProgress.Instance().SetFinishText(Constants.Instance().MESSAGE_SAVE_SUCCESS, 500);
            Close();
          }
          else
            FormGlobals.Message_Information(MESSAGE_DUPLICATE);
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnClear_Click(object sender, EventArgs e)
    {
      try
      {
        FormGlobals.Control_ClearData(grpALCParamEdit, false);
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
        {
          if (FormGlobals.Panel_CheckError(grpALCParamEdit))
          {
            frmProgress.Instance().Thread = new MethodInvoker(SaveData);
            frmProgress.Instance().Show_Progress(MESSAGE_SAVE);
            if (m_Test == "1")
            {
              frmProgress.Instance().SetFinishText(Constants.Instance().MESSAGE_SAVE_SUCCESS, 500);
              Close();
            }
            else
              FormGlobals.Message_Information(MESSAGE_DUPLICATE);
          }
        }
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