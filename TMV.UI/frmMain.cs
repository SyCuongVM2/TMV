using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using TMV.BusinessObject;
using TMV.Common;
using TMV.UI.Admin;
using TMV.UI.JPCB.CW;
using TMV.UI.JPCB.JP;

namespace TMV.UI
{
  public partial class frmMain : XtraForm
  {
    #region "Load Form"
    private string skinMask = "Skin: ";
    private DefaultLookAndFeel lookanhFeelMain;
    public frmMain()
    {
      InitializeComponent();
    }
    private void frmMain_Load(object sender, EventArgs e)
    {
      try
      {
        iStatus2.Caption = Application.ProductName;
        setDefaultSkin();
        SetCultureInfo(System.Threading.Thread.CurrentThread);
        InitMenu();
        ips_Init();
        InitSkins();
        InitTabbedMDI();
        InitDockMode();
        Text = Application.ProductName + string.Format(". Version {0} ({1})", Assembly.GetExecutingAssembly().GetName().Version.ToString(),
               File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToShortDateString());
        iStatus1.Caption = "Ready";
        UserLogOff();
        DoLogin();
        FormGlobals.App_ShowProgress(new MethodInvoker(Init_App));
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (HaveChildForm())
      {
        if (!FormGlobals.Message_Confirm("You must close all Open Windows before exit. Do you want system to close all Open Windows?", false))
          e.Cancel = true;
      }
      else if (!FormGlobals.Message_Confirm("Do you want to close applicaton now?", false))
        e.Cancel = true;
    }
    private void tblMdiManageMain_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
    {
      picBackGround.Visible = false;
    }
    private void tblMdiManageMain_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
    {
      if (tblMdiManageMain.Pages.Count == 0)
        picBackGround.Visible = true;
    }
    #endregion

    #region "Skin"
    private void setDefaultSkin()
    {
      lookanhFeelMain = new DevExpress.LookAndFeel.DefaultLookAndFeel();
      lookanhFeelMain.LookAndFeel.SkinName = SkinStyle.DevExpress;
    }
    private void InitSkins()
    {
      bamBarMain.ForceInitialize();
      if (bamBarMain.GetController().PaintStyleName == "Skin")
      {
      }
      foreach (DevExpress.Skins.SkinContainer cnt in DevExpress.Skins.SkinManager.Default.Skins)
      {
        BarButtonItem item = new BarButtonItem(bamBarMain, skinMask + cnt.SkinName)
        {
          Name = "bi" + cnt.SkinName,
          Id = bamBarMain.GetNewItemId()
        };
        item.ItemClick += new ItemClickEventHandler(OnSkinClick);
      }
    }
    private void OnSkinClick(object sender, ItemClickEventArgs e)
    {
      string skinName = e.Item.Caption.Replace(skinMask, "");
      UserLookAndFeel.Default.SetSkinStyle(skinName);
      bamBarMain.GetController().PaintStyleName = "Skin";
    }
    #endregion

    #region "Menu"
    private void AddForm(XtraForm frm, bool ShowDialog)
    {
      XtraForm newForm = frm;
      newForm.ShowInTaskbar = false;

      // TODO
      //if (Globals.LoginUserName != null)
      //  mdlAdmin.SetUserRole(newForm);
      //try
      //{
      //  APP_LogbookBO.Instance().UserOpenScreen(frm.Text, frm.Name);
      //}
      //catch (Exception ex)
      //{
      //  FormGlobals.Message_Error(ex);
      //}

      if (ShowDialog)
        newForm.ShowDialog();
      else
      {
        newForm.MdiParent = this;
        newForm.Show();
      }
    }
    private void barManager_ItemClick(object sender, ItemClickEventArgs e)
    {
      BarSubItem subMenu = e.Item as BarSubItem;
      if (subMenu == null)
      {
        Globals.ActiveMenuName = e.Item.Name;
        Globals.ActiveMenuText = e.Link.DisplayCaption;
        switch (e.Item.Name)
        {
          //System
          case "soLogin":
            DoLogin();
            break;
          case "soExit":
            Close();
            break;
          case "siLogOut":
            if (UserLogOff())
            {
              Text = Application.ProductName + string.Format(". Version {0} ({1})", Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                     File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToShortDateString());
              iStatus1.Caption = "Please login to use application...";
              iStatus2.Caption = Application.ProductName;
              DoLogin();
            }
            break;
          case "siChangePassword":
            AddForm(new frmChangePassword(), true);
            break;
          case "siCW":
            AddForm(new frmCW(), true);
            break;
          case "siGJ":
            AddForm(new frmJP(), true);
            break;
          case "siBP":
            AddForm(new frmJP(), true);
            break;
        }
      }
    }
    private void InitMenu()
    {
      bamBarMain.ItemClick += new ItemClickEventHandler(barManager_ItemClick);
    }
    #endregion

    #region "Init"
    private void InitDockMode()
    {
      Array arr = Enum.GetValues(typeof(DevExpress.XtraBars.Docking.Helpers.DockMode));
      foreach (object mode in arr)
      {
        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem(mode.ToString(), mode, -1));
      }
    }
    private void ips_ItemClick(object sender, ItemClickEventArgs e)
    {
      bamBarMain.GetController().PaintStyleName = e.Item.Description;
      InitPaintStyle(e.Item);
      bamBarMain.GetController().ResetStyleDefaults();
      UserLookAndFeel.Default.SetDefaultStyle();
    }
    private void InitPaintStyle(BarItem item)
    {
      if (item != null)
      {
      }
    }
    private void ips_Init()
    {
      BarItem item = null;
      for (int i = 0; i <= bamBarMain.Items.Count - 1; i++)
      {
        if (bamBarMain.Items[i].Description == bamBarMain.GetController().PaintStyleName)
          item = bamBarMain.Items[i];
      }
      InitPaintStyle(item);
    }
    private void InitTabbedMDI()
    {
      if (biTabbedMDI.Down)
        tblMdiManageMain.MdiParent = this;
      else
        tblMdiManageMain.MdiParent = null;
    }
    private void Init_App()
    {
      AppController controller1 = AppController.Instance();
      FormGlobals.GetField_Function = new FormGlobals.GetField_Invoker(controller1.Table_ListField);
      AppController controller2 = AppController.Instance();
      FormGlobals.GetDataError_Function = new FormGlobals.GetDataError_Invoker(controller2.DataErrorMessage_Get);
    }
    public void SetCultureInfo(System.Threading.Thread mThread)
    {
      DateTimeFormatInfo myDateformat = new DateTimeFormatInfo();
      try
      {
        myDateformat.ShortDatePattern = Globals.CS_DISPLAY_DATE_FORMAT;
        mThread.CurrentCulture = new CultureInfo("en-US");
        mThread.CurrentCulture.DateTimeFormat = myDateformat;
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void biTabbedMDI_ItemClick(object sender, ItemClickEventArgs e)
    {
      InitTabbedMDI();
    }
    #endregion

    #region "Security"
    private void CloseAllForm()
    {
      foreach (Form frm in tblMdiManageMain.MdiParent.MdiChildren)
      {
        frm.Close();
      }
    }
    private bool HaveChildForm()
    {
      foreach (Form frm in tblMdiManageMain.MdiParent.MdiChildren)
      {
        return true;
      }
      return false;
    }
    private bool UserLogOff()
    {
      bool UserLogOff = false;
      try
      {
        if (HaveChildForm())
        {
          if (!FormGlobals.Message_Confirm("You must close all Windows before logout. Do you want system to close all open Windows?", false))
            return false;

          CloseAllForm();
        }

        foreach (BarItem mItem in bamBarMain.Items)
        {
          if (mItem.Name.Substring(0, 2) == "si")
            mItem.Enabled = false;
          else
            mItem.Enabled = true;
        }

        // TODO
        //if (Globals.LoginUserID > 0)
        //{
        //  try
        //  {
        //    APP_LogbookBO.Instance().UserLogOut();
        //  }
        //  catch
        //  {
        //  }
        //}
        Globals.LoginUserID = 0;
        UserLogOff = true;
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
      CloseAllFormOpen();
      return UserLogOff;
    }
    private void CloseAllFormOpen()
    {
      try
      {
        for (int i1 = 1; i1 <= Application.OpenForms.Count - 1; i1++)
        {
          if (Application.OpenForms[i1].Name != "frmMain")
          {
            Form f = Application.OpenForms[i1];
            string name = Application.OpenForms[i1].Name;
            bool bl = Application.OpenForms[i1].Modal;
            f.Dispose();
            CloseAllFormOpen();
          }
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void DoLogin()
    {
      frmLogin oLogin = new frmLogin();
      try
      {
        if (oLogin.ShowForm())
          UserLogin();
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void UserLogin()
    {
      try
      {
        //Code to enable all Menu
        //foreach (BarItem mItem in bamBarMain.Items)
        //{
        //    if (mItem.Name.Substring(0, 2) == "si")
        //    {
        //        expression = "Menu_Name='" + mItem.Name + "'";
        //        mItem.Enabled = true;
        //    }
        //}

        if (Globals.LoginUserName.ToUpper().StartsWith("ADMIN"))
        {
          foreach (BarItem mItem in bamBarMain.Items)
          {
            mItem.Enabled = true;
            mItem.Visibility = BarItemVisibility.Always;
          }
        }

        siLogOut.Enabled = true;
        siLogOut.Visibility = BarItemVisibility.Always;
        siChangePassword.Enabled = true;
        soLogin.Enabled = false;
        try
        {
          Text = Application.ProductName + 
                 string.Format(". Version {0} ({1})", Assembly.GetExecutingAssembly().GetName().Version.ToString(), File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToShortDateString()) + 
                 ". Login (" + DateTime.Now.ToString() + ")";
          iStatus2.Caption = Globals.LoginUserName + " (" + Globals.LoginFullName + ")";
          iStatus1.Caption = Globals.LoginDealerName + " (" + Globals.LoginDealerAbbr + " - " + Globals.LoginDealerCode + ")";
        }
        catch
        {
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    #endregion
  }
}