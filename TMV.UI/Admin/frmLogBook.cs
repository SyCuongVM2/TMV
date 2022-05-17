using System;
using TMV.BusinessObject.Admin;
using TMV.Common;

namespace TMV.UI.Admin
{
  public partial class frmLogBook : DevExpress.XtraEditors.XtraForm
  {
    public frmLogBook()
    {
      InitializeComponent();
    }

    private void InitData()
    {
      dteFrom.DateTime = DateTime.Now;
      dteTo.DateTime = DateTime.Now;
      FormGlobals.LookupEdit_BindData(cboAction, APP_DomainBO.Instance().GetByDomain("LOG_ACTION"), "ITEM_VALUE", "ITEM_CODE", "", new object[] { "ITEM_VALUE" });
      FormGlobals.LookupEdit_BindData(cboUserID, APP_UsersBO.Instance().GetAll().Tables[0], "FULL_NAME", "USER_ID", "", new object[] { "USER_NAME", "FULL_NAME" });
    }

    private void frmLogBook_Load(object sender, EventArgs e)
    {
      try
      {
        InitData();
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
        string sLogAction = FormGlobals.LookUpEdit_GetSelectedValue(cboAction, "ITEM_CODE", "").ToString();
        decimal sLoginUserID = Convert.ToDecimal(FormGlobals.LookUpEdit_GetSelectedValue(cboUserID, "USER_ID", Null.NullDecimal));
        DateTime dFromDate = dteFrom.DateTime;
        DateTime dToDate = dteTo.DateTime;
        grcLogBook.DataSource = APP_LogbookBO.Instance().Search(sLogAction, sLoginUserID, dFromDate, dToDate).Tables[0];
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnExportGridToExcel_Click(object sender, EventArgs e)
    {
      FormGlobals.Export_GridViewToExcel(grvLogBook, "");
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