using System;
using TMV.BusinessObject.Admin;
using TMV.Common;

namespace TMV.UI.Admin
{
  public partial class frmSystemDomain : DevExpress.XtraEditors.XtraForm
  {
    public frmSystemDomain()
    {
      InitializeComponent();
    }

    private void BindGridView()
    {
      string domain = txtDomainCode.Text;
      string itemCode = txtItemCode.Text;
      string itemValue = txtItemValue.Text;
      FormGlobals.Grid_LoadData(grvALCParam, APP_DomainBO.Instance().Search(domain, itemCode, itemValue).Tables[0]);
    }
    private void ShowFromEdit(FormGlobals.DataInputState state)
    {
      string domainCode;
      string itemCode;
      if (state == FormGlobals.DataInputState.AddMode)
      {
        domainCode = "";
        itemCode = "";
      }
      else
      {
        domainCode = FormGlobals.Grid_GetDataRowITemString(grvALCParam, "DOMAIN_CODE");
        itemCode = FormGlobals.Grid_GetDataRowITemString(grvALCParam, "ITEM_CODE");
      }
      new frmSystemDomainEdit().LoadForm(domainCode, itemCode, state);
      BindGridView();
    }

    private void frmSystemDomain_Load(object sender, EventArgs e)
    {
      try
      {
        BindGridView();
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnSearch_Click(object sender, EventArgs e)
    {
      try
      {
        BindGridView();
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
        FormGlobals.Control_ClearData(grpSystemParameter, false);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnAdd_Click(object sender, EventArgs e)
    {
      try
      {
        ShowFromEdit(FormGlobals.DataInputState.AddMode);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnAddAndCopy_Click(object sender, EventArgs e)
    {
      try
      {
        ShowFromEdit(FormGlobals.DataInputState.CopyMode);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnEdit_Click(object sender, EventArgs e)
    {
      try
      {
        ShowFromEdit(FormGlobals.DataInputState.EditMode);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnDelete_Click(object sender, EventArgs e)
    {
      string domainCode = FormGlobals.Grid_GetDataRowITemString(grvALCParam, "DOMAIN_CODE");
      string itemCode = FormGlobals.Grid_GetDataRowITemString(grvALCParam, "ITEM_CODE");

      try
      {
        if ((domainCode == "") && (itemCode == ""))
          FormGlobals.Message_Information("Please select a Domain Code!");
        else if (FormGlobals.Message_Confirm("Are you sure you want to delete this Domain Code?", false))
        {
          APP_DomainBO.Instance().Delete(domainCode, itemCode);
          FormGlobals.Message_Information("Delete successfully!");
          BindGridView();
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnExportExcel_Click(object sender, EventArgs e)
    {
      try
      {
        FormGlobals.Export_GridViewToExcel(grvALCParam, "");
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
        Close();
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
  }
}