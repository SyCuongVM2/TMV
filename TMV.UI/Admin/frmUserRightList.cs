using DevExpress.XtraTreeList.Nodes;
using System;
using System.Data;
using System.Windows.Forms;
using TMV.BusinessObject.Admin;
using TMV.Common;
using TMV.Common.Forms;
using TMV.ObjectInfo.Admin;

namespace TMV.UI.Admin
{
  public partial class frmUserRightList : DevExpress.XtraEditors.XtraForm
  {
    public frmUserRightList()
    {
      InitializeComponent();
    }

    private void DisplaySelectedNode(TreeListNode SelectedNode)
    {
      string sRoot;
      if (SelectedNode == null)
        sRoot = "U";
      else
        sRoot = SelectedNode.RootNode[0].ToString();

      switch (sRoot)
      {
        case "U":
          pnlUser.Visible = true;
          pnlGroup.Visible = false;
          pnlFunction.Visible = false;
          DisplayUser(GetSelectedItemID());
          break;
        case "G":
          pnlGroup.Visible = true;
          pnlUser.Visible = false;
          pnlFunction.Visible = false;
          DisplayGroup(GetSelectedItemID());
          break;
        case "F":
          pnlFunction.Visible = true;
          pnlUser.Visible = false;
          pnlGroup.Visible = false;
          DisplayFunctionTree();
          break;
      }
    }
    private void RemoveChildNode(TreeListNode ParentNode)
    {
      trlAdmin.BeginUnboundLoad();
      ParentNode.Nodes.Clear();
      trlAdmin.EndUnboundLoad();
    }
    private void DisplayNode(DataTable dt, TreeListNode ParentNode, int ImageIndex, int SelectImageIndex, string KeyField, string DisplayField, string DisplayValue, string TagField)
    {
      TreeListNode Node = null;
      trlAdmin.BeginUnboundLoad();
      try
      {
        if (dt != null)
        {
          foreach (DataRow dr in dt.Rows)
          {
            object[] Values = new object[] { dr[KeyField], dr[DisplayField], DisplayValue };
            Node = trlAdmin.AppendNode(Values, ParentNode);
            Node.ImageIndex = ImageIndex;
            Node.SelectImageIndex = SelectImageIndex;
            if (TagField != "")
              Node.Tag = dr[TagField].ToString();
          }
          ParentNode.HasChildren = true;
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
      trlAdmin.EndUnboundLoad();
    }
    private void InitForm()
    {
      InitControl();
      InitData();
    }
    private void InitData()
    {
      DataSet ds = null;
      try
      {
        ds = APP_UsersBO.Instance().GetAll();
        DisplayNode(ds.Tables[0], trlAdmin.Nodes[0], 25, 24, "USER_ID", "FULL_NAME", "User", "USER_NAME");
        ds = APP_GroupsBO.Instance().GetAll();
        DisplayNode(ds.Tables[0], trlAdmin.Nodes[1], 20, 19, "GROUP_ID", "GROUP_TEXT", "Group", "");
        trlAdmin.ExpandAll();
        DisplaySelectedNode(trlAdmin.Nodes[0]);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void ReloadUser(string sUserName)
    {
      DataSet ds = null;
      try
      {
        ds = APP_UsersBO.Instance().GetAll();
        RemoveChildNode(trlAdmin.Nodes[0]);
        DisplayNode(ds.Tables[0], trlAdmin.Nodes[0], 25, 24, "USER_ID", "FULL_NAME", "User", "USER_NAME");
        trlAdmin.ExpandAll();
        if (sUserName != "")
        {
          foreach (TreeListNode oNode in trlAdmin.Nodes[0].Nodes)
          {
            if ((oNode.Tag != null) && (oNode.Tag.ToString() == sUserName))
            {
              trlAdmin.FocusedNode = oNode;
              return;
            }
          }
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void ReloadGroup(string GroupID)
    {
      DataSet ds = null;
      try
      {
        ds = APP_GroupsBO.Instance().GetAll();
        RemoveChildNode(trlAdmin.Nodes[1]);
        DisplayNode(ds.Tables[0], trlAdmin.Nodes[1], 20, 19, "GROUP_ID", "GROUP_TEXT", "Group", "GROUP_ID");
        trlAdmin.ExpandAll();

        if (GroupID == "")
          trlAdmin.FocusedNode = trlAdmin.Nodes[1];
        else
        {
          foreach (TreeListNode oNode in trlAdmin.Nodes[1].Nodes)
          {
            if ((oNode.Tag != null) && (oNode.Tag.ToString() == GroupID))
            {
              trlAdmin.FocusedNode = oNode;
              return;
            }
          }
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void InitControl()
    {
      FormGlobals.Control_SetFont(this, FormGlobals.CS_FONT_NAME);
      pnlUser.Dock = DockStyle.Fill;
      pnlGroup.Dock = DockStyle.Fill;
      pnlFunction.Dock = DockStyle.Fill;
      FormGlobals.Control_SetState(grpUser, FormGlobals.DataInputState.ViewMode);
      FormGlobals.Control_SetState(grpGroup, FormGlobals.DataInputState.ViewMode);
      FormGlobals.Panel_InitControl(grpUser, "APP_USERS");
    }
    private decimal GetSelectedItemID()
    {
      TreeListNode curentNode;
      decimal dRet = 0;
      string sSelectedValue = "";

      if (trlAdmin.FocusedNode != null)
        curentNode = trlAdmin.FocusedNode;
      else
        curentNode = trlAdmin.Nodes[0];

      sSelectedValue = curentNode[0].ToString();
      if (Globals.IsNumeric(sSelectedValue))
        return Convert.ToDecimal(sSelectedValue);

      if (curentNode.HasChildren)
      {
        sSelectedValue = curentNode.Nodes[0][0].ToString();
        if (Globals.IsNumeric(sSelectedValue))
          dRet = Convert.ToDecimal(sSelectedValue);
      }
      else
        dRet = 1;
      return dRet;
    }
    private bool AllNodeIsChecked(TreeListNode oNode)
    {
      if (oNode == null)
        return false;

      foreach (TreeListNode tnode in oNode.Nodes)
      {
        if ((decimal)tnode["CHECKED"] == 0)
          return false;
      }

      return true;
    }
    private bool AllTreeNodeIsChecked(TreeListNode oNode)
    {
      if (oNode == null)
        return false;

      foreach (TreeListNode tnode in oNode.Nodes)
      {
        if (!tnode.Checked)
          return false;
      }
      return true;
    }
    private void DisplayFunctionTree()
    {
      DataSet ds = APP_FormfunctionsBO.Instance().GetTree();
      if (ds != null)
      {
        trlFunction.DataSource = ds.Tables[0];
        trlFunction.KeyFieldName = "ID";
        trlFunction.ParentFieldName = "PARENT_ID";
      }
    }
    private void DisplayUser(decimal UserID)
    {
      if (UserID > 0)
      {
        DataSet ds = APP_UsergroupBO.Instance().GetByUser(UserID);
        APP_UsersInfo oUser = APP_UsersBO.Instance().GetById(UserID);
        FormGlobals.Panel_SetControlValue(grpUser, oUser);
        txtUser_Name.Tag = oUser.USER_ID;
        txtUser_Name.Text = oUser.USER_NAME;
        txtFull_Name.Text = oUser.FULL_NAME;
        grcUUserGroup.DataSource = ds.Tables[0];
      }
    }
    private void ChangeCheckedNode(TreeListNode oNode)
    {
      if (oNode["CHECKED"].ToString() == "1")
        oNode.Checked = true;
      else
        oNode.Checked = false;

      if (oNode.Nodes != null)
      {
        foreach (TreeListNode oChild in oNode.Nodes)
        {
          ChangeCheckedNode(oChild);
        }
      }
    }
    private void DisplayGroup(decimal GroupID)
    {
      if (GroupID > 0)
      {
        DataSet dsUG = APP_UsergroupBO.Instance().GetByGroup(GroupID);
        DataSet dsGF = APP_GroupfunctionsBO.Instance().GetByGroup(GroupID);
        APP_GroupsInfo oGroup = APP_GroupsBO.Instance().GetById(GroupID);
        txtGroup_Name.Text = oGroup.GROUP_TEXT;
        txtGroup_Name.Tag = oGroup.GROUP_ID;
        grdGUserGroup.DataSource = dsUG.Tables[0];
        trlGFunctionGroup.DataSource = dsGF.Tables[0];
        trlGFunctionGroup.KeyFieldName = "ID";
        trlGFunctionGroup.ParentFieldName = "PARENT_ID";
        trlGFunctionGroup.ExpandAll();

        foreach (TreeListNode oNode in trlGFunctionGroup.Nodes)
        {
          ChangeCheckedNode(oNode);
        }
      }
    }
    private void DeleteGroup(decimal GroupID)
    {
      try
      {
        APP_GroupsBO.Instance().Delete(GroupID);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void UserGroupSave()
    {
      string sFunctionList = "";
      try
      {
        decimal UserID = Convert.ToDecimal(txtUser_Name.Tag);
        DataTable dt = (DataTable)grcUUserGroup.DataSource;

        foreach (DataRow dr in dt.Rows)
        {
          if (dr["CHECKED"].ToString() == "1")
          {
            if (sFunctionList == "")
              sFunctionList = dr["GROUP_ID"].ToString();
            else
              sFunctionList = sFunctionList + "," + dr["GROUP_ID"].ToString();
          }
        }
        APP_UsergroupBO.Instance().Update(UserID, sFunctionList);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void GroupFunctionSave()
    {
      string sFunctionList = "";
      try
      {
        decimal GroupID = Convert.ToDecimal(txtGroup_Name.Tag);
        foreach (TreeListNode oNode in trlGFunctionGroup.Nodes)
        {
          if ((oNode["ITEM_TYPE"].ToString() == "Menu Form") & oNode.HasChildren)
          {
            foreach (TreeListNode oChild in oNode.Nodes)
            {
              if ((oChild["ITEM_TYPE"].ToString() == "Function") && oChild.Checked)
              {
                if (sFunctionList == "")
                  sFunctionList = oChild["ID"].ToString();
                else
                  sFunctionList = sFunctionList + "," + oChild["ID"].ToString();
              }
            }
          }
        }
        APP_GroupfunctionsBO.Instance().Update(sFunctionList, GroupID);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void chkFunctionInGroup_EditValueChanged(object sender, EventArgs e)
    {
      decimal dRet = 0;
      try
      {
        switch (trlGFunctionGroup.FocusedNode["ITEM_TYPE"].ToString())
        {
          case "Menu Form":
            dRet = Convert.ToDecimal(trlGFunctionGroup.FocusedNode["CHECKED"]);
            if (dRet == 0)
              dRet = 1;
            else
              dRet = 0;

            trlGFunctionGroup.FocusedNode["CHECKED"] = dRet;
            foreach (TreeListNode tnode in trlGFunctionGroup.FocusedNode.Nodes)
            {
              tnode["CHECKED"] = dRet;
            }
            break;
          case "Function":
            dRet = Convert.ToDecimal(trlGFunctionGroup.FocusedNode["CHECKED"]);
            if (dRet == 0)
              dRet = 1;
            else
              dRet = 0;

            trlGFunctionGroup.FocusedNode["CHECKED"] = dRet;
            if (dRet == 0)
              trlGFunctionGroup.FocusedNode.ParentNode["CHECKED"] = 0;
            else if (AllNodeIsChecked(trlGFunctionGroup.FocusedNode.ParentNode))
              trlGFunctionGroup.FocusedNode.ParentNode["CHECKED"] = 1;

            break;
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void tapUsers_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
    {
      if (tapUsers.SelectedTabPageIndex == -1)
        pnlFunctionOfGroup.Visible = true;
      else
        pnlFunctionOfGroup.Visible = tapUsers.SelectedTabPageIndex == 1;
    }
    private void cmdUCancel_Click(object sender, EventArgs e)
    {
      DisplayUser(GetSelectedItemID());
    }
    private void cmdUSave_Click(object sender, EventArgs e)
    {
      try
      {
        frmProgress.Instance().Thread = new MethodInvoker(UserGroupSave);
        frmProgress.Instance().Show_Progress("Saving data");
        frmProgress.Instance().SetFinishText(Constants.Instance().MESSAGE_SAVE_SUCCESS, 500);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnGEdit_Click(object sender, EventArgs e)
    {
      try
      {
        decimal GroupID = Convert.ToDecimal(txtGroup_Name.Tag);
        frmGroupEdit oGroup = new frmGroupEdit();
        if (oGroup.ShowForm(GroupID, FormGlobals.DataInputState.EditMode))
          ReloadGroup(txtGroup_Name.Tag.ToString());
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnGAdd_Click(object sender, EventArgs e)
    {
      try
      {
        frmGroupEdit oGrp = new frmGroupEdit();
        if (oGrp.ShowForm(0, FormGlobals.DataInputState.AddMode))
          ReloadGroup("");
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnFClose_Click(object sender, EventArgs e)
    {
      Close();
    }
    private void frmUserRightList_Load(object sender, EventArgs e)
    {
      InitForm();
    }
    private void trlAdmin_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
    {
      DisplaySelectedNode(e.Node);
    }
    private void trlGFunctionGroup_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
    {
      try
      {
        switch (e.Node["ITEM_TYPE"].ToString())
        {
          case "Menu Form":
            foreach (TreeListNode tnode in e.Node.Nodes)
            {
              tnode.CheckState = e.Node.CheckState;
            }
            break;
          case "Function":
            if (e.Node.CheckState == CheckState.Unchecked)
              e.Node.ParentNode.CheckState = e.Node.CheckState;
            else if (AllTreeNodeIsChecked(e.Node.ParentNode))
              e.Node.ParentNode.CheckState = e.Node.CheckState;
            break;
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void trlFunction_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
    {
      DataRowView dr = (DataRowView)e.Node.TreeList.GetDataRecordByNode(e.Node);
      if (dr != null)
      {
        switch (dr["ITEM_TYPE"].ToString())
        {
          case "Menu Form":
            e.NodeImageIndex = 21;
            break;
          case "Function":
            e.NodeImageIndex = 26;
            break;
          case "Button":
            e.NodeImageIndex = 7;
            break;
        }
      }
    }
    private void btnUAdd_Click(object sender, EventArgs e)
    {
      try
      {
        frmUserEdit oUsr = new frmUserEdit();
        if (oUsr.ShowForm(0, FormGlobals.DataInputState.AddMode))
          ReloadUser(oUsr.Tag.ToString());
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnUEdit_Click(object sender, EventArgs e)
    {
      try
      {
        decimal UserID = Convert.ToDecimal(txtUser_Name.Tag);
        frmUserEdit oUsr = new frmUserEdit();
        if (oUsr.ShowForm(UserID, FormGlobals.DataInputState.EditMode))
          ReloadUser(txtUser_Name.Text);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnSetPassword_Click(object sender, EventArgs e)
    {
      try
      {
        decimal UserID = Convert.ToDecimal(txtUser_Name.Tag);
        new frmUserEdit().ShowForm(UserID, FormGlobals.DataInputState.VersionMode);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void btnGDelete_Click(object sender, EventArgs e)
    {
      if ((txtGroup_Name.Tag != null) && FormGlobals.Message_Confirm("Do you want remove user in Group and delete this Group?", false))
      {
        try
        {
          decimal GroupID = Convert.ToDecimal(txtGroup_Name.Tag);
          DeleteGroup(GroupID);
          ReloadGroup("");
        }
        catch (Exception ex)
        {
          FormGlobals.Message_Error(ex);
        }
      }
    }
    private void cmdCancel_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}