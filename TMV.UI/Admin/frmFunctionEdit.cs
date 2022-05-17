using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Data;
using System.Windows.Forms;
using TMV.BusinessObject.Admin;
using TMV.Common;
using TMV.Common.Forms;

namespace TMV.UI.Admin
{
  public partial class frmFunctionEdit : DevExpress.XtraEditors.XtraForm
  {
    private DataSet m_dsFunction = null;
    private decimal m_FormID = 0;
    private string m_Pattern1 = "View,Exit,Close,Search,Clear,Excel,Export";
    private string m_Pattern2 = "Add,Edit,Delete,Update";
    private int m_Recomment = 0;
    private XtraForm oGetForm;
    private TreeListNode ParentNode = null;

    public frmFunctionEdit()
    {
      InitializeComponent();
    }

    private void InitForm()
    {
      ParentNode = trlAdmin.Nodes[0];
      txtMenu_Name.Text = Globals.ActiveMenuName;
      txtForm_Name.Text = oGetForm.Name;
      txtForm_Text.Text = oGetForm.Text;
      trlAdmin.BeginUpdate();

      foreach (Control btn in oGetForm.Controls)
      {
        GetButton(btn);
      }

      trlAdmin.ExpandAll();
      trlAdmin.EndUpdate();
      LoadData();
    }
    private void GetButton(Control oControl)
    {
      TreeListNode Node = null;
      if (oControl is SimpleButton)
      {
        object[] Values = new object[] { oControl.Name, oControl.Text.Replace("&", ""), oControl.Name };
        Node = trlAdmin.AppendNode(Values, ParentNode);
        Node.ImageIndex = 20;
        Node.SelectImageIndex = 21;
      }
      else if ((((oControl is PanelControl) || (oControl is GroupControl)) || (oControl is XtraTabControl)) || (oControl is XtraTabPage))
      {
        foreach (Control ctrl in oControl.Controls)
        {
          GetButton(ctrl);
        }
      }
    }
    internal bool ShowForm(XtraForm oForm)
    {
      oGetForm = oForm;
      frmProgress.Instance().Thread = new MethodInvoker(InitForm);
      frmProgress.Instance().Show_Progress();
      return (ShowDialog() == DialogResult.OK);
    }
    private void SaveAddData()
    {
      SaveData(true);
    }
    private void SaveUpdateData()
    {
      SaveData(false);
    }
    private int ValidateOption()
    {
      int iCount = 0;

      foreach (TreeListNode oNode in trlAdmin.Nodes[0].Nodes)
      {
        if (oNode.Checked)
          iCount++;
      }
      return iCount;
    }
    private void SaveData(bool IsAddNew)
    {
      try
      {
        string sMenuName = txtMenu_Name.Text;
        string sMenuText = Globals.ActiveMenuText.Replace("&", "");
        string sParentForm = txtParent_Form.Text;
        string sFormName = txtForm_Name.Text;
        string sFormText = txtForm_Text.Text;
        decimal FunctionID = 0;
        string sFunctionText = txtFunction_Name.Text.Trim();
        string sButtonNameList = "";
        string sButtonTextList = "";

        if (!IsAddNew)
          FunctionID = FormGlobals.Grid_GetDataRowItemDecimal(grvFunction, "FORM_FUNCTION_ID");

        foreach (TreeListNode oNode in trlAdmin.Nodes[0].Nodes)
        {
          if (oNode.Checked)
          {
            if (sButtonNameList == "")
            {
              sButtonNameList = oNode[2].ToString();
              sButtonTextList = oNode[1].ToString();
            }
            else
            {
              sButtonNameList = sButtonNameList + "," + oNode[2].ToString();
              sButtonTextList = sButtonTextList + "," + oNode[1].ToString();
            }
          }
        }
        APP_FormfunctionsBO.Instance().InsertUpdateItem(sMenuName, sMenuText, sParentForm, sFormName, sFormText, FunctionID, sFunctionText, sButtonNameList, sButtonTextList);
        LoadData();
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void LoadData()
    {
      string sMenuName = txtMenu_Name.Text;
      string sFormName = txtForm_Name.Text;
      try
      {
        m_dsFunction = APP_FormsBO.Instance().GetByMenuForm(sMenuName, sFormName);
        if ((m_dsFunction != null) && (m_dsFunction.Tables[0].Rows.Count > 0))
        {
          m_FormID = Convert.ToDecimal(m_dsFunction.Tables[0].Rows[0]["FORM_ID"]);
          grdFunction.DataSource = m_dsFunction.Tables[0];
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void GetRecomment(string Pattern)
    {
      string[] sCmd = Pattern.Split(new char[] { ',' });
      string sKey = "";

      foreach (TreeListNode oNode in trlAdmin.Nodes[0].Nodes)
      {
        sKey = oNode[0].ToString();
        oNode.Checked = false;
        for (int i = 0; i <= sCmd.Length - 1; i++)
        {
          if (sKey.IndexOf(sCmd[i]) >= 0)
          {
            oNode.Checked = true;
            break;
          }
        }
      }
    }
    private void DisplayButton()
    {
      string ButtonList = "";
      DataView dv = m_dsFunction.Tables[1].DefaultView;
      txtFunction_Name.Text = FormGlobals.Grid_GetDataRowITemString(grvFunction, "FORM_FUNCTION_TEXT");
      dv.RowFilter = "FORM_FUNCTION_ID=" + Convert.ToString(FormGlobals.Grid_GetDataRowItemDecimal(grvFunction, "FORM_FUNCTION_ID"));

      if (dv.Count > 0)
        ButtonList = mdlAdmin.DataTable2String(dv, "|", 2);

      foreach (TreeListNode oNode in trlAdmin.Nodes[0].Nodes)
      {
        if (ButtonList.IndexOf("|" + oNode[0].ToString() + "|") >= 0)
          oNode.Checked = true;
        else
          oNode.Checked = false;
      }
    }
    private void DeleteFunctionData()
    {
      decimal FunctionID = FormGlobals.Grid_GetDataRowItemDecimal(grvFunction, "FORM_FUNCTION_ID");
      APP_FormfunctionsBO.Instance().Delete(FunctionID);
      LoadData();
    }

    private void cmdAdd_Click(object sender, EventArgs e)
    {
      if (txtFunction_Name.Text.Trim() == "")
        FormGlobals.Message_Information("Function Text cannot be empty!");
      else if (ValidateOption() == 0)
        FormGlobals.Message_Warning("Please choose at least 1 option button!");
      else
      {
        frmProgress.Instance().Thread = new MethodInvoker(SaveAddData);
        frmProgress.Instance().Show_Progress("Saving data");
        frmProgress.Instance().SetFinishText(Constants.Instance().MESSAGE_SAVE_SUCCESS, 500);
        txtFunction_Name.Text = "";
      }
    }
    private void cmdUpdate_Click(object sender, EventArgs e)
    {
      if (txtFunction_Name.Text.Trim() == "")
        FormGlobals.Message_Information("Function Text cannot be empty!");
      else
      {
        frmProgress.Instance().Thread = new MethodInvoker(SaveUpdateData);
        frmProgress.Instance().Show_Progress("Update Function");
        frmProgress.Instance().SetFinishText(Constants.Instance().MESSAGE_SAVE_SUCCESS, 500);
      }
    }
    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (FormGlobals.Message_Confirm("Do you want delete Function '" + FormGlobals.Grid_GetDataRowITemString(grvFunction, "FORM_FUNCTION_TEXT") + "'?", false))
      {
        frmProgress.Instance().Thread = new MethodInvoker(DeleteFunctionData);
        frmProgress.Instance().Show_Progress("Delete Function");
        frmProgress.Instance().SetFinishText(Constants.Instance().MESSAGE_DELETE_SUCCESS, 500);
      }
    }
    private void cmdRecomment_Click(object sender, EventArgs e)
    {
      try
      {
        if ((m_Recomment % 2) == 0)
        {
          GetRecomment(m_Pattern1);
          txtFunction_Name.Text = "View";
        }
        else if ((m_Recomment % 2) == 1)
        {
          GetRecomment(m_Pattern2);
          txtFunction_Name.Text = "Edit";
        }
        m_Recomment++;
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void grvFunction_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
      try
      {
        DisplayButton();
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void trlAdmin_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
    {
      try
      {
        if (e.Node == trlAdmin.Nodes[0])
        {
          foreach (TreeListNode tnode in e.Node.Nodes)
          {
            tnode.CheckState = e.Node.CheckState;
          }
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
  }
}