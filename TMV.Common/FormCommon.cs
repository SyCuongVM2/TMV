using System;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Globalization;
using System.Threading;
using Microsoft.Win32;
using ADOX;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

using GemBox.Spreadsheet;
using FAMP;

using TMV.Common.Forms;
using TMV.Common.ControlHandles;

namespace TMV.Common
{
  public class TabbedForm
  {
    #region "Class TabbedForm"

    private static TabbedForm _instance;
    private static Object _syncLock = new Object();
    private Form frmMain = new Form();
    private FATabStrip tabMDIChild = new FATabStrip();
    private MdiClientController MdiClientController;
    private FATabStripItem _PreviousTabItem;
    private bool _HasControlInit = false;
    private int g_iScreenHeight;
    private int g_iScreenWidth;

    protected TabbedForm()
    {
      tabMDIChild.TabStripItemClosed += new System.EventHandler(tabMDIChild_TabStripItemClosed);
      tabMDIChild.TabStripItemClosing += new TabStripItemClosingHandler(tabMDIChild_TabStripItemClosing);
      tabMDIChild.TabStripItemSelectionChanged += new TabStripItemChangedHandler(tabMDIChild_TabStripITemselectionChanged);
      frmMain.Resize += new System.EventHandler(frmMain_Resize);
      frmMain.KeyDown += new KeyEventHandler(frmMain_KeyDown);
      frmMain.MdiChildActivate += new System.EventHandler(frmMain_MdiChildActivate);
    }

    public static TabbedForm Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new TabbedForm();
        }
      }
      return _instance;
    }
    protected void Dispose()
    {
      _instance = null;
    }

    public void Init_TabbedForm(Form _frmMain, FATabStrip _TabStrip, MdiClientController _MdiClient)
    {
      frmMain = _frmMain;
      frmMain.KeyPreview = true;
      FormGlobals.Control_SetFont(frmMain, FormGlobals.CS_FONT_NAME);
      tabMDIChild = _TabStrip;
      MdiClientController = _MdiClient;
      g_iScreenWidth = MdiClientController.MdiClient.Width - 4;
      g_iScreenHeight = MdiClientController.MdiClient.Height - 4;
      g_iScreenHeight -= tabMDIChild.Height;
      _HasControlInit = true;
    }

    public void Resize_Update()
    {
      int iWidth = MdiClientController.MdiClient.Width - 4;
      int iHeight = MdiClientController.MdiClient.Height - 4;
      bool bChange = (g_iScreenWidth != iWidth) || (g_iScreenHeight != iHeight);
      g_iScreenWidth = iWidth;
      g_iScreenHeight = iHeight;
      if (!tabMDIChild.Visible)
        g_iScreenHeight -= tabMDIChild.Height;
      else if (bChange)
      {
        foreach (Form mChild in frmMain.MdiChildren)
        {
          mChild.Size = new Size(g_iScreenWidth, g_iScreenHeight);
        }
      }
    }

    public string GetKey_FormChildTab(Form f)
    {
      return (f.Name + "|" + f.Text);
    }

    public FATabStripItem Find_FormChildTab(Form fChild)
    {
      Form f = new Form();
      foreach (FATabStripItem tabItem in tabMDIChild.Items)
      {
        f = (Form)tabItem.Tag;
        if (GetKey_FormChildTab(f) == GetKey_FormChildTab(fChild))
          return tabItem;
      }
      return null;
    }

    public bool Show_FormChild(Form fChild, bool CheckExist)
    {
      bool bExist = false;
      FATabStripItem tabItem = null;
      if (CheckExist)
      {
        tabItem = Find_FormChildTab(fChild);
        bExist = tabItem != null;
      }

      if (bExist)
        fChild.Close();
      else
      {
        if (!tabMDIChild.Visible)
        {
          tabMDIChild.Visible = true;
          tabMDIChild.BringToFront();
        }
        FormGlobals.Form_BeginInit(ref fChild, false);
        fChild.MdiParent = frmMain;
        fChild.ShowInTaskbar = false;
        fChild.ControlBox = false;
        fChild.FormBorderStyle = FormBorderStyle.None;
        fChild.StartPosition = FormStartPosition.Manual;
        fChild.Location = new Point(0, 0);
        tabItem = new FATabStripItem() { Title = fChild.Text };
        tabMDIChild.Items.Add(tabItem);
        tabItem.Tag = fChild;
        fChild.Size = new Size(g_iScreenWidth, g_iScreenHeight);
        fChild.Show();
        fChild.BringToFront();
        fChild.FormClosed += new FormClosedEventHandler(Handles_FormClosed);
      }
      _PreviousTabItem = tabMDIChild.SelectedItem;
      tabMDIChild.SelectedItem = tabItem;
      return bExist;
    }

    public bool Exist_FormChild(Form fChild)
    {
      return (Find_FormChildTab(fChild) != null);
    }

    public void Close_FormChild(bool bOnClosed)
    {
      if ((tabMDIChild.SelectedItem != null) && (frmMain.MdiChildren.Length <= tabMDIChild.Items.Count))
      {
        if (!bOnClosed && (tabMDIChild.SelectedItem.Tag is Form))
          ((Form)tabMDIChild.SelectedItem.Tag).Close();
        else if ((tabMDIChild.Tag == null) && (tabMDIChild.SelectedItem != null))
        {
          int iIndex = tabMDIChild.Items.IndexOf(tabMDIChild.SelectedItem);
          if (iIndex >= 0)
          {
            tabMDIChild.Items.RemoveAt(iIndex);
            if ((tabMDIChild.Items.DrawnCount == 0) || (frmMain.MdiChildren.Length == 0))
              tabMDIChild.Visible = false;
            else if (_PreviousTabItem == null)
            {
              if (iIndex <= (tabMDIChild.Items.DrawnCount - 1))
                tabMDIChild.SelectedItem = tabMDIChild.Items[iIndex];
              else
                tabMDIChild.SelectedItem = tabMDIChild.Items.LastVisible;
            }
            else
              tabMDIChild.SelectedItem = _PreviousTabItem;
          }
        }
      }
    }

    private void Handles_FormClosed(object sender, FormClosedEventArgs e)
    {
      try
      {
        if (e.CloseReason == CloseReason.UserClosing)
          Close_FormChild(true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    // ---------------------
    // Handle events
    // ---------------------
    private void tabMDIChild_TabStripItemClosed(object sender, EventArgs e)
    {
      if (tabMDIChild.Items.Count == 0)
        tabMDIChild.Visible = false;
    }

    private void tabMDIChild_TabStripItemClosing(TabStripItemClosingEventArgs e)
    {
      try
      {
        if (tabMDIChild.SelectedItem != null)
        {
          Form f = (Form)tabMDIChild.SelectedItem.Tag;
          f.AutoValidate = AutoValidate.Disable;
          f.Close();
          e.Cancel = true;
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void tabMDIChild_TabStripITemselectionChanged(TabStripItemChangedEventArgs e)
    {
      try
      {
        if (tabMDIChild.SelectedItem != null)
          ((Form)tabMDIChild.SelectedItem.Tag).BringToFront();
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void frmMain_Resize(object sender, EventArgs e)
    {
      try
      {
        if (frmMain.WindowState == FormWindowState.Maximized)
          Resize_Update();
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void frmMain_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.Control & (e.KeyCode == System.Windows.Forms.Keys.F4))
          Close_FormChild(false);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void frmMain_MdiChildActivate(object sender, EventArgs e)
    {
      try
      {
        if (frmMain.ActiveMdiChild != null)
        {
          FATabStripItem tab = Find_FormChildTab(frmMain.ActiveMdiChild);
          if (tab != null)
            tabMDIChild.SelectedItem = tab;
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    #endregion
  }

  public class ListBoxItem
  {
    #region "Class ListBoxItem"

    private string _DisplayField;
    private string _ValueField;

    public ListBoxItem()
    {
    }

    public ListBoxItem(string iValue, string sName)
    {
      _DisplayField = sName;
      _ValueField = iValue;
    }

    public string DisplayField
    {
      get
      {
        return _DisplayField;
      }
      set
      {
        _DisplayField = value;
      }
    }

    public string ValueField
    {
      get
      {
        return _ValueField;
      }
      set
      {
        _ValueField = value;
      }
    }

    #endregion
  }

  public sealed class FormGlobals
  {
    #region "Class FormGlobals"

    #region "Variables"

    public static string CS_FONT_NAME;
    private const string ERROR_REFERENCES_CONSTRAINT = "ORA-02292: integrity constraint";
    private const string ERROR_TNS_TIME_OUT = "ORA-12170: TNS:Connect timeout occurred";
    private const string ERROR_UNIQUE_CONSTRAINT = "ORA-00001: unique constraint";
    private const string ERROR_VALUE_TOO_LARGE = "ORA-12899: value too large for column";
    internal static string g_ExportExcelFilePath;
    internal static GridView g_GridviewExport;
    public static GetDataError_Invoker GetDataError_Function;
    public static GetField_Invoker GetField_Function;
    private static Dictionary<string, List<FormField>> mFieldCache;
    private static Dictionary<string, DataTable> mTableCache;

    public delegate DataTable GetDataError_Invoker(string sErrType, string sErrObject);
    public delegate DataTable GetField_Invoker(string sTable);

    #endregion

    #region "Constructor"
    static FormGlobals()
    {
      g_ExportExcelFilePath = "";
      g_GridviewExport = null;
      CS_FONT_NAME = "Tahoma";
      mFieldCache = new Dictionary<string, List<FormField>>();
      mTableCache = new Dictionary<string, DataTable>();
    }
    #endregion

    #region "Struct, Enum"
    private struct DataErrorObject
    {
      public string ErrorType;
      public string ErrorObjectName;
      public string ErrorMessage;
      public bool GetFromDB;
    }

    public struct FormControlExt
    {
      public bool Required;
      public string FieldName;
      public object HandleObject;
      public object Tag;
    }

    private struct FormField
    {
      public string FieldName;
      public string ControlType;
      public string ControlName;
      public int DataLength;
      public string DataType;
      public bool Required;
      public object MaxValue;
    }

    private struct FormProperty
    {
      public bool ControlBox;
      public FormBorderStyle FormBorderStyle;
      public bool ShowIcon;
      public bool ShowInTaskbar;
      public FormStartPosition StartPosition;
      public Point Location;
      public Size Size;
    }

    public enum DataInputState
    {
      BrowseMode = 0,
      ViewMode = 1,
      EditMode = 2,
      AddMode = 4,
      CopyMode = 8,
      VersionMode = 16
    }

    public enum ExportDataType
    {
      invoiceData = 1,
      shippingData = 2
    }
    #endregion

    #region "Message"
    public static void Message_Error(Exception ex, string sDesc)
    {
      string sMessage;
      if (sDesc != "")
        sMessage = "Description: " + sDesc + "\rMessage: ";
      else
        sMessage = "";

      MessageBox.Show((sMessage + ex.Message.Replace("\r\n", "\r ")) + "\r\rError Trace: " +
                        ex.StackTrace, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    public static void Message_Error(Exception ex)
    {
      string sDesc = ex.Message;
      string sErrMessage = "";
      sErrMessage = GetDataError(sDesc);
      if (sErrMessage != "")
        MessageBox.Show(sErrMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      else if (sDesc.IndexOf("Could not find file") >= 0)
        Message_Information(sDesc);
      else if (sDesc.IndexOf("20000: Period is close or not exists") >= 0)
        Message_Information("Period is closed or not exist. " + Environment.NewLine +
                            "You have to create period or re-open period by function: Master Data/TMV/Period Control ");
      else if (sDesc.IndexOf("ORA-20000: Data has changed since you retrieved it.") >= 0)
        Message_Information("Data has changed since you retrieved it. " + Environment.NewLine +
                            "Could you please re-load and re-update. ");
      else if ((sDesc.IndexOf("The process cannot access the file") >= 0) & (sDesc.IndexOf("because it is being used by another process") > 0))
        Message_Information(sDesc);
      else
        Message_Error(ex, "");
    }

    public static bool Message_Confirm(string sMessage, bool bShowRetry)
    {
      if (bShowRetry)
        return (MessageBox.Show(sMessage, Application.ProductName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Retry);

      return (MessageBox.Show(sMessage, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
    }

    public static bool Message_Delete(string objType, string sObjName)
    {
      return (MessageBox.Show("Are you sure you want to delete " + objType +
                              ((sObjName == "") ? "" : " '" + sObjName + "'"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
    }

    public static void Message_Information(string sMessage)
    {
      MessageBox.Show(sMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
    }

    public static void Message_Warning(string sMessage)
    {
      MessageBox.Show(sMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    public static void Message_Warning_Error(Exception ex)
    {
      MessageBox.Show(ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
    }

    public static void Message_Warning_Error(string sMessage)
    {
      MessageBox.Show(sMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
    }

    public static bool Message_YesNo_Cancel(string sMessage)
    {
      return (MessageBox.Show(sMessage, Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes);
    }

    public static DialogResult Message_YesNoCancel(string sMessage)
    {
      return MessageBox.Show(sMessage, Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
    }

    private static DataErrorObject GetErrorObject(string sMsg)
    {
      DataErrorObject oRet = new DataErrorObject();
      int iBegin = 0;
      int iEnd = 0;
      int iLen = 0;
      string sObjName = "";

      if (sMsg.IndexOf("ORA-02292: integrity constraint") >= 0)
      {
        iBegin = sMsg.IndexOf("(");
        iBegin = sMsg.IndexOf(".", iBegin) + 1;
        iEnd = sMsg.IndexOf(")", iBegin);
        sObjName = sMsg.Substring(iBegin, iEnd - iBegin);
        oRet.ErrorType = "R";
        oRet.ErrorObjectName = sObjName;
        oRet.ErrorMessage = "";
        oRet.GetFromDB = true;
        return oRet;
      }
      if (sMsg.IndexOf("ORA-00001: unique constraint") >= 0)
      {
        iBegin = sMsg.IndexOf("(");
        iBegin = sMsg.IndexOf(".", iBegin) + 1;
        iEnd = sMsg.IndexOf(")", iBegin);
        sObjName = sMsg.Substring(iBegin, iEnd - iBegin);
        oRet.ErrorType = "U";
        oRet.ErrorObjectName = sObjName;
        oRet.ErrorMessage = "";
        oRet.GetFromDB = true;
        return oRet;
      }
      if (sMsg.IndexOf("ORA-12899: value too large for column") >= 0)
      {
        iBegin = sMsg.IndexOf(".");
        iBegin = sMsg.IndexOf(".", (int)(iBegin + 1)) + 2;
        iEnd = sMsg.IndexOf("\" (", iBegin);
        iLen = sMsg.IndexOf(")", iEnd);
        sObjName = sMsg.Substring(iBegin, iEnd - iBegin);
        oRet.ErrorMessage = sMsg.Substring(iEnd + 1, iLen - iEnd);
        oRet.ErrorType = "L";
        oRet.ErrorObjectName = "";
        oRet.ErrorMessage = "Value too large for column '" + sObjName + "' -" + oRet.ErrorMessage;
        oRet.GetFromDB = false;
        return oRet;
      }
      if (sMsg.IndexOf("ORA-12170: TNS:Connect timeout occurred") >= 0)
      {
        oRet.ErrorType = "L";
        oRet.ErrorObjectName = "";
        oRet.ErrorMessage = "Having problem with Network or Oracle connection. Please contact TMV IT";
        oRet.GetFromDB = false;
      }
      return oRet;
    }

    private static string GetDataError(string sMsg)
    {
      string sRet = "";
      DataErrorObject oErr = new DataErrorObject();
      DataTable dt = null;
      oErr = GetErrorObject(sMsg);

      try
      {
        if (!((oErr.ErrorType != null) & (oErr.ErrorObjectName != null)))
          return sRet;

        if (oErr.GetFromDB)
        {
          dt = GetDataError_Function(oErr.ErrorType, oErr.ErrorObjectName);
          if ((dt != null) && (dt.Rows.Count > 0))
            sRet = dt.Rows[0][0].ToString();

          return sRet;
        }
        if (oErr.ErrorMessage != "")
          sRet = oErr.ErrorMessage;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      return sRet;
    }

    #endregion

    #region "Common"
    public static void SetCultureInfo(Thread mThread)
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
        Message_Error(ex);
      }
    }
    #endregion

    #region "Forms"

    public static void Form_InitDialog(Form f)
    {
      f.StartPosition = FormStartPosition.CenterParent;
      f.ShowInTaskbar = false;
      f.FormBorderStyle = FormBorderStyle.FixedDialog;
      f.MinimizeBox = false;
      f.MaximizeBox = false;
    }

    public static void Form_BeginInit(ref Form objForm, bool KeepProperty)
    {
      if (KeepProperty)
      {
        FormProperty p = new FormProperty
        {
          ControlBox = objForm.ControlBox,
          FormBorderStyle = objForm.FormBorderStyle,
          Location = objForm.Location,
          ShowIcon = objForm.ShowIcon,
          ShowInTaskbar = objForm.ShowInTaskbar,
          Size = objForm.Size,
          StartPosition = objForm.StartPosition
        };
        objForm.Tag = p;
      }
      objForm.ControlBox = false;
      objForm.ShowIcon = false;
      objForm.ShowInTaskbar = false;
      objForm.StartPosition = FormStartPosition.Manual;
      objForm.WindowState = FormWindowState.Normal;
      objForm.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
      objForm.FormBorderStyle = FormBorderStyle.None;
      objForm.Show();
    }

    public static void Form_EndInit(Form objForm)
    {
      objForm.Hide();
      if (objForm.Tag is FormProperty)
      {
        FormProperty p = (FormProperty)objForm.Tag;
        objForm.ControlBox = p.ControlBox;
        objForm.FormBorderStyle = p.FormBorderStyle;
        objForm.ShowIcon = p.ShowIcon;
        objForm.ShowInTaskbar = p.ShowInTaskbar;
        objForm.Size = p.Size;
        if (p.StartPosition == FormStartPosition.Manual)
          objForm.Location = p.Location;
        else
          objForm.Location = Point.Empty;

        objForm.StartPosition = p.StartPosition;
      }
    }

    public static void Form_SetText(Form f, string sFunctionName, DataInputState mDataInputState, string sDescText)
    {
      string sReturn = sFunctionName.Trim();
      switch (((int)mDataInputState))
      {
        case 0:
          sReturn += " [Browse]";
          break;
        case 1:
          sReturn += " [View";
          break;
        case 2:
          sReturn += " [Edit";
          break;
        case 4:
          sReturn += " [Add New";
          break;
        case 8:
          sReturn += " [Copy";
          break;
        case 16:
          sReturn += " [New Version";
          break;
      }
      if (mDataInputState != DataInputState.BrowseMode)
      {
        if (sDescText.Length > 0)
          sReturn += " " + sDescText.Trim() + "]";
        else
          sReturn += "]";
      }
      f.Text = sReturn;
    }

    public static ToolTip Form_GetToolTip(Form f)
    {
      Control ctlDummy = f.Controls[f.Name + "_ToolTip"];
      ToolTip objToolTip = null;
      if (ctlDummy == null)
      {
        ctlDummy = new Control();
        ctlDummy.Name = f.Name + "_ToolTip";
        f.Controls.Add(ctlDummy);
        objToolTip = new ToolTip();
        objToolTip.ToolTipIcon = ToolTipIcon.Info;
        objToolTip.IsBalloon = true;
        objToolTip.UseAnimation = true;
        objToolTip.UseFading = true;
        objToolTip.AutoPopDelay = 3000;
        ctlDummy.Tag = objToolTip;
      }
      else
        objToolTip = (ToolTip)ctlDummy.Tag;

      return objToolTip;
    }

    public static ErrorProvider Form_GetErrorProvider(Form f)
    {
      Control ctlDummy = f.Controls[f.Name + "_ErrorProvider"];
      ErrorProvider objErrorProvider = null;
      if (ctlDummy == null)
      {
        ctlDummy = new Control();
        ctlDummy.Name = f.Name + "_ErrorProvider";
        f.Controls.Add(ctlDummy);
        objErrorProvider = new ErrorProvider();
        ctlDummy.Tag = objErrorProvider;
      }
      else
        objErrorProvider = (ErrorProvider)ctlDummy.Tag;

      return objErrorProvider;
    }

    #endregion

    #region "Control"

    public static void Control_InitByField(Control objControl, string sTableName, string sFieldName)
    {
      try
      {
        DataRow dtRow = GetTableField(sTableName).Rows.Find(sFieldName);
        if (dtRow == null)
          throw new Exception("Field not found");

        FormField mFormField = new FormField
        {
          ControlType = objControl.GetType().Name
        };
        SetControlField(objControl, ref mFormField, dtRow);
      }
      catch
      {
        throw;
      }
    }

    public static void Control_SetValue(Control ctlSource, ref object objDest)
    {
      object sValue;
      if (ctlSource is TextEdit)
        sValue = ctlSource.Text;
      else if (ctlSource is LookUpEdit)
        sValue = ctlSource.Text;
      else if (ctlSource is TextBox)
        sValue = ctlSource.Text;
      else
      {
        if (!(ctlSource is System.Windows.Forms.ComboBox))
          throw new Exception(string.Format("Control type '{0}' isn't support", ctlSource.GetType().Name));
        sValue = Combo_GetValue((System.Windows.Forms.ComboBox)ctlSource);
        if (!(sValue == null) && (sValue.ToString() == COMBO_ITEM_NULL_VALUE))
        {
          objDest = Null.SetNull(DBNull.Value, objDest);
          return;
        }
      }
      Globals.Object_SetValue(sValue, ref objDest);
    }

    public static void Control_SetFont(Control objControl, string sFont)
    {
      objControl.Font = new Font(sFont, objControl.Font.Size, objControl.Font.Style);
    }

    public static void Control_SetFlat(Control objControl)
    {
      if (objControl.HasChildren)
      {
        foreach (Control objChild in objControl.Controls)
        {
          Control_SetFlat(objChild);
        }
      }
      bool bDrawRect = false;
      if (objControl is TextBox)
        ((TextBox)objControl).BorderStyle = BorderStyle.FixedSingle;
      else if (objControl is Button)
        ((Button)objControl).FlatStyle = FlatStyle.Flat;
      else if (objControl is CheckBox)
        ((CheckBox)objControl).FlatStyle = FlatStyle.Flat;
      else if (objControl is RadioButton)
        ((RadioButton)objControl).FlatStyle = FlatStyle.Flat;
      else if (objControl is System.Windows.Forms.ComboBox)
      {
        ((System.Windows.Forms.ComboBox)objControl).FlatStyle = FlatStyle.Flat;
        bDrawRect = true;
      }
      else if (objControl is RichTextBox)
      {
        ((RichTextBox)objControl).BorderStyle = BorderStyle.None;
        bDrawRect = true;
      }
      else
        return;

      if (!bDrawRect)
        return;

      objControl.Height -= 2;
      Label lb = new Label
      {
        Name = objControl.Name + "_Flat",
        AutoSize = false,
        BorderStyle = BorderStyle.FixedSingle,
        Width = objControl.Width,
        Height = objControl.Height + 2,
        Location = objControl.Location
      };
      objControl.Parent.Controls.Add(lb);
      lb.SendToBack();
      objControl.Left++;
      objControl.Width -= 2;
      objControl.Top++;
    }

    public static void Button_SetState(Control objControl, DataInputState sState)
    {
      foreach (Control mControl in objControl.Controls)
      {
        if ((((mControl.Name.IndexOf("Add") > -1) || (mControl.Name.IndexOf("Edit") > -1)) || (mControl.Name.IndexOf("Delete") > -1)) || (mControl.Name.IndexOf("AddCopy") > -1))
          mControl.Enabled = sState == DataInputState.ViewMode;
        else if (((mControl.Name.IndexOf("Save") > -1) || (mControl.Name.IndexOf("cmdOK") > -1)) || (mControl.Name.IndexOf("Cancel") > -1))
          mControl.Enabled = sState != DataInputState.ViewMode;
      }
    }

    public static void Control_SetState(Control objControl, DataInputState sState)
    {
      foreach (Control mControl in objControl.Controls)
      {
        switch (mControl.GetType().Name)
        {
          case "TextBox":
          case "ComboBox":
          case "DataGridView":
            SetControlViewOnly(mControl, true, true, sState == DataInputState.ViewMode);
            break;
          case "ListBox":
          case "TreeView":
            if (mControl.Parent.Parent is Form)
              mControl.Enabled = sState == DataInputState.ViewMode;
            else
              mControl.Enabled = sState != DataInputState.ViewMode;
            break;
          case "Button":
          case "RadioButton":
          case "CheckBox":
            mControl.Enabled = sState != DataInputState.ViewMode;
            break;
          case "TextEdit":
          case "LookUpEdit":
          case "DateEdit":
          case "CheckEdit":
          case "TimeEdit":
            ((BaseEdit)mControl).Properties.ReadOnly = sState == DataInputState.ViewMode;
            break;
          default:
            Control_SetState(mControl, sState);
            break;
        }
      }
    }

    public static void Control_ClearData(Control objControl, bool ClearReadOnlyControl)
    {
      foreach (Control mControl in objControl.Controls)
      {
        switch (mControl.GetType().Name)
        {
          case "CheckedListBoxControl":
            {
              if (!(mControl.Parent.Parent is Form))
                ((CheckedListBoxControl)mControl).Items.Clear();
              break;
            }
          case "LookUpEdit":
            {
              ((LookUpEdit)mControl).ItemIndex = 0;
              break;
            }
          case "TextBox":
            {
              ((TextBox)mControl).Text = "";
              break;
            }
          case "ComboBox":
            {
              if (((System.Windows.Forms.ComboBox)mControl).Items.Count > 0)
                ((System.Windows.Forms.ComboBox)mControl).SelectedIndex = 0;
              break;
            }
          case "ListBox":
            {
              if (!(mControl.Parent.Parent is Form))
                ((ListBox)mControl).Items.Clear();
              break;
            }
          case "TreeView":
            {
              if (!(mControl.Parent.Parent is Form))
                ((TreeView)mControl).Nodes.Clear();
              break;
            }
          case "CheckEdit":
            {
              CheckEdit xControl = (CheckEdit)mControl;
              if (xControl.Properties.ReadOnly)
              {
                if (ClearReadOnlyControl)
                  xControl.Checked = false;
              }
              else
                xControl.Checked = false;
              break;
            }
          case "TextBoxMaskBox":
            {
              TextEdit xControl = (TextEdit)objControl;
              if (xControl.Properties.ReadOnly)
              {
                if (ClearReadOnlyControl)
                  xControl.Text = "";
              }
              else
                xControl.Text = "";
              break;
            }
          case "SpinEdit":
            {
              SpinEdit spin = (SpinEdit)mControl;
              if (spin.Properties.ReadOnly)
              {
                if (ClearReadOnlyControl)
                  spin.Value = spin.Properties.MinValue;
              }
              else
                spin.Value = spin.Properties.MinValue;
              break;
            }
          case "DateEdit":
            {
              ((DateEdit)mControl).DateTime = DateTime.Now;
              break;
            }
          case "TimeEdit":
            ((TimeEdit)mControl).Time = DateTime.Now;
            break;
          default:
            if (mControl.HasChildren)
              Control_ClearData(mControl, false);
            break;
        }
      }
    }

    public static void Control_SetViewOnly(Control objControl, bool bViewOnly)
    {
      Control_SetViewOnly(objControl, bViewOnly, true);
    }

    public static void Control_SetViewOnly(Control objControl, bool bViewOnly, bool bSetChildOnly)
    {
      Control_SetViewOnly(objControl, bViewOnly, bSetChildOnly, true);
    }

    public static void Control_SetViewOnly(Control objControl, bool bViewOnly, bool bSetChildOnly, bool bForceVisible)
    {
      if (objControl.HasChildren && !(objControl is DataGridView))
      {
        Form objForm = null;
        if (!bForceVisible)
        {
          objForm = objControl.FindForm();
          if (objForm != null)
          {
            if (!objForm.Visible)
              Form_BeginInit(ref objForm, true);
            else
              objForm = null;
          }
        }
        foreach (Control mControl in objControl.Controls)
        {
          SetControlViewOnly(mControl, bSetChildOnly, bForceVisible, bViewOnly);
        }

        if (objForm != null)
          Form_EndInit(objForm);
      }
      else
      {
        SetControlViewOnly(objControl, bSetChildOnly, true, bViewOnly);
      }
    }

    private static void SetControlViewOnly(Control objControl, bool bSetChildOnly, bool bForceVisible, bool bSetOn)
    {
      if (((!objControl.HasChildren || (objControl is DataGridView)) ? 1 : 0) == 0)
      {
        if ((objControl.Visible || bForceVisible) & !bSetChildOnly)
        {
          foreach (Control mControl in objControl.Controls)
          {
            SetControlViewOnly(mControl, bSetChildOnly, bForceVisible, true);
          }
        }
      }
      else if (objControl.Visible || bForceVisible)
      {
        switch (objControl.GetType().Name)
        {
          case "TextBox":
            ((TextBox)objControl).ReadOnly = bSetOn;
            if (bSetOn)
              ((TextBox)objControl).BackColor = ColorTranslator.FromHtml("#eaeaea");
            else
              ((TextBox)objControl).BackColor = SystemColors.Window;
            break;
          case "ComboBox":
            {
              TextBox objTextBox = (TextBox)objControl.Parent.Controls[objControl.Name + "_View"];
              Control objFlat = objControl.Parent.Controls[objControl.Name + "_Flat"];
              if (bSetOn)
              {
                if (objTextBox == null)
                {
                  objTextBox = new TextBox
                  {
                    Location = objControl.Location,
                    Size = objControl.Size,
                    Anchor = objControl.Anchor,
                    Name = objControl.Name + "_View"
                  };
                  objControl.Parent.Controls.Add(objTextBox);
                  Control_SetViewOnly(objTextBox, true);
                  if (((System.Windows.Forms.ComboBox)objControl).FlatStyle == FlatStyle.Flat)
                    objTextBox.BorderStyle = BorderStyle.FixedSingle;
                }
                objTextBox.Visible = true;
                objTextBox.BringToFront();
                objTextBox.Text = objControl.Text;
              }
              else if (objTextBox != null)
                objTextBox.Visible = false;

              if (objFlat != null)
                objFlat.Visible = !bSetOn;

              objControl.Visible = !bSetOn;
              break;
            }
          case "Button":
          case "CheckedListBox":
          case "RadioButton":
          case "CheckBox":
          case "TreeView":
            objControl.Enabled = !bSetOn;
            break;
          case "DataGridView":
            {
              DataGridView objGrid = (DataGridView)objControl;
              objGrid.ReadOnly = bSetOn;
              objGrid.AllowUserToAddRows = !bSetOn;
              objGrid.AllowUserToDeleteRows = !bSetOn;
              if (bSetOn)
              {
                objGrid.RowHeadersWidth = 30;
                objGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
              }
              else
              {
                objGrid.RowHeadersWidth = 0x2d;
                objGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
              }
              foreach (DataGridViewColumn mCol in objGrid.Columns)
              {
                if (mCol is DataGridViewButtonColumn)
                  mCol.Visible = !bSetOn;
              }
              break;
            }
          case "TextEdit":
          case "LookUpEdit":
          case "DateEdit":
          case "CheckEdit":
          case "TimeEdit":
            ((BaseEdit)objControl).Properties.ReadOnly = bSetOn;
            break;
          default:
            break;
        }
        if (bSetOn)
        {
          Control ctl = objControl.Parent.Controls[objControl.Name + "_Required"];
          if (ctl != null)
            ctl.Visible = false;
        }
        objControl.TabStop = !bSetOn;
      }
    }

    public static void Button_SetViewOnly(Control objControl)
    {
      foreach (Control mControl in objControl.Controls)
      {
        if (!((mControl.Name == "cmdExit") || (mControl.Name.IndexOf("cmdView") > -1)))
          mControl.Visible = false;
        else
          mControl.Visible = true;
      }
    }

    public static bool Control_GetRequire(Control mControl)
    {
      if ((mControl.Tag != null) && (mControl.Tag is FormControlExt))
      {
        FormControlExt objFormControl = (FormControlExt)mControl.Tag;
        return objFormControl.Required;
      }
      return false;
    }

    public static void Control_SetRequire(Control mControl, bool bSetOnOff)
    {
      FormControlExt objFormControl;
      if (mControl.Tag == null)
        objFormControl = new FormControlExt();
      else
      {
        if (mControl.Tag is FormControlExt)
          objFormControl = (FormControlExt)mControl.Tag;
        else
        {
          if (!bSetOnOff)
            return;
          else
          {
            objFormControl = new FormControlExt();
            objFormControl.Tag = mControl.Tag;
          }
        }
      }
      string sLabelName = mControl.Name + "_Required";
      Control objControl = mControl.Parent.Controls[sLabelName];
      if (bSetOnOff)
      {
        Label mLabel = (Label)objControl;
        if (mLabel == null)
        {
          mLabel = new Label();
          mLabel.Name = sLabelName;
          mLabel.AutoSize = true;
          mLabel.Anchor = mControl.Anchor;
          mLabel.Text = "*";
          mLabel.ForeColor = Color.OrangeRed;
          mLabel.Top = mControl.Top;
          mLabel.Left = mControl.Left - 20;
          mControl.Parent.Controls.Add(mLabel);
          mLabel.Visible = true;
          mLabel.BringToFront();
        }
        else if ((objControl.Name == sLabelName) & (objControl.Text == "*"))
          objControl.Visible = true;

        objFormControl.Required = true;
      }
      else
      {
        if (objControl != null)
        {
          if ((objControl.Name == sLabelName) & (objControl.Text == "*"))
            objControl.Visible = false;
        }
        objFormControl.Required = false;
      }
      mControl.Tag = objFormControl;
    }

    public static object Control_GetLabel(Control mControl)
    {
      string sCaption = null;
      mControl = mControl.Parent.GetNextControl(mControl, false);
      if ((mControl != null) && (mControl is Label))
        sCaption = mControl.Text.Replace("&", "");

      if ((mControl != null) && (mControl is LabelControl))
        sCaption = mControl.Text.Replace("&", "");

      return sCaption;
    }

    private static List<FormField> SetControlByField(Control objControl, DataTable mReader, string sExcepControl)
    {
      List<FormField> arrControl = new List<FormField>();
      List<FormField> arrReturn = new List<FormField>();

      FormField mFormField;
      Control mControl;

      foreach (Control mControl1 in objControl.Controls)
      {
        //Modify: Cannot modify members of 'mControl' because it is a 'foreach iteration variable'
        mControl = mControl1;
        if (!string.IsNullOrEmpty(mControl.Name) && !sExcepControl.Contains(mControl.Name.ToUpper()))
        {
          if (((((mControl is TextBox) || (mControl is System.Windows.Forms.ComboBox)) || ((mControl is RichTextBox) || (mControl is ComboBoxEdit))) || (((mControl is TextEdit) || (mControl is SpinEdit)) || ((mControl is CheckEdit) || (mControl is LookUpEdit)))) || (((mControl is CalcEdit) || (mControl is DateEdit)) || (mControl is MemoEdit)))
          {
            mFormField = new FormField
            {
              ControlName = mControl.Name,
              FieldName = mControl.Name.Substring(3).ToUpper(),
              ControlType = mControl.GetType().Name
            };
            arrControl.Add(mFormField);
          }
          else if (mControl.Controls.Count > 0)
          {
            List<FormField> arrSub = SetControlByField(mControl, mReader, sExcepControl);
            if (arrSub.Count > 0)
              arrReturn.AddRange(arrSub);
          }
        }
      }

      foreach (FormField mFormField1 in arrControl)
      {
        //Modify: Cannot modify members of 'mFormField' because it is a 'foreach iteration variable'
        mFormField = mFormField1;
        DataRow mDataRow = mReader.Rows.Find(mFormField.FieldName);
        if ((mDataRow == null) && (mFormField.ControlType == "ComboBox"))
        {
          mDataRow = mReader.Rows.Find(mFormField.FieldName + "_ID");
          if (mDataRow == null)
            mDataRow = mReader.Rows.Find(mFormField.FieldName + "_CODE");

          if (mDataRow == null)
            mDataRow = mReader.Rows.Find(mFormField.FieldName + "ID");

          if (mDataRow != null)
            mFormField.FieldName = Convert.ToString(mDataRow["COLUMN_NAME"]);
        }
        if (mDataRow != null)
        {
          mControl = objControl.Controls[mFormField.ControlName];
          SetControlField(mControl, ref mFormField, mDataRow);
          arrReturn.Add(mFormField);
        }
      }
      return arrReturn;
    }

    private static void SetControlField(Control mParentControl, List<FormField> arrFormField)
    {
      foreach (FormField mFormField in arrFormField)
      {
        Control mControl = (Control)Find_Control(mParentControl, mFormField.ControlName);
        FormControlExt objFormControl = new FormControlExt();
        if (mFormField.ControlType == "TextBox")
        {
          TextBoxHandle txtHandle = new TextBoxHandle((TextBox)mControl, mFormField.DataType, null, mFormField.MaxValue);
          ((TextBox)mControl).MaxLength = mFormField.DataLength;
          objFormControl.HandleObject = txtHandle;
        }
        else if (mFormField.ControlType == "ComboBox")
        {
          ComboBoxHandle cboHandle = new ComboBoxHandle((System.Windows.Forms.ComboBox)mControl);
          objFormControl.HandleObject = cboHandle;
        }
        else if (mFormField.ControlType == "RichTextBox")
          ((RichTextBox)mControl).MaxLength = mFormField.DataLength;
        else if (mFormField.ControlType == "TextEdit")
        {
          TextEditHandle txtEditHandle = new TextEditHandle((TextEdit)mControl, mFormField.DataType, null, mFormField.MaxValue);
          ((TextEdit)mControl).Properties.MaxLength = mFormField.DataLength;
          objFormControl.HandleObject = txtEditHandle;
        }
        else if (mFormField.ControlType == "SpinEdit") { }
        else if (mFormField.ControlType == "DateEdit") { }
        else if (mFormField.ControlType == "TimeEdit") { }
        else if (mFormField.ControlType == "CalcEdit") { }
        else if (mFormField.ControlType == "LookUpEdit") { }
        else if (mFormField.ControlType == "CheckEdit") { }
        else if (mFormField.ControlType == "MemoEdit") { }
        else
          throw new Exception("Not support type of control " + mControl.GetType().Name);

        objFormControl.FieldName = mFormField.FieldName;
        mControl.Tag = objFormControl;
        if (mFormField.Required)
          Control_SetRequire(mControl, true);
      }
    }

    private static void SetControlField(Control mControl, ref FormField mFormField, DataRow mDataRow)
    {
      FormControlExt objFormControl = new FormControlExt();

      //TextBox
      if (mFormField.ControlType == "TextBox")
      {
        string mDataType = mDataRow["DATA_TYPE"].ToString().ToUpper();
        object iMaxValue = null;
        if (mDataType == "NUMBER")
        {
          if (Convert.ToInt32(mDataRow["DATA_SCALE"]) > 0)
          {
            if (Convert.ToInt32(mDataRow["DATA_LENGTH"]) > double.MaxValue.ToString().Length)
              mDataType = "double";

            iMaxValue = Math.Pow(10, (Convert.ToInt32(mDataRow["DATA_LENGTH"]) - Convert.ToInt32(mDataRow["DATA_SCALE"]) - 1)) - 1 / Math.Pow(10, Convert.ToInt32((mDataRow["DATA_SCALE"])));
          }
          else
          {
            if ((Convert.ToInt32(mDataRow["DATA_LENGTH"]) > int.MaxValue.ToString().Length) || (Convert.ToInt32(mDataRow["DATA_LENGTH"]) > 0))
              mDataType = "bigint";
            else if (Convert.ToInt32(mDataRow["DATA_LENGTH"]) > short.MaxValue.ToString().Length)
              mDataType = "integer";
            else
            {
              mDataType = "smallint";
              iMaxValue = Math.Pow(10, Convert.ToInt32(mDataRow["DATA_LENGTH"])) - 1;
            }
          }
        }
        TextBoxHandle txtHandle = new TextBoxHandle((TextBox)mControl, mDataType, null, iMaxValue);
        switch (mDataRow["DATA_TYPE"].ToString().ToUpper())
        {
          case "CHAR":
          case "VARCHAR":
            ((TextBox)mControl).MaxLength = Convert.ToInt32(mDataRow["DATA_LENGTH"]);
            break;
          case "CLOB":
          case "NCLOB":
          case "NTEXT":
          case "TEXT":
            ((TextBox)mControl).MaxLength = Int32.MaxValue;
            break;
          case "NUMBER":
            ((TextBox)mControl).MaxLength = Convert.ToInt32(mDataRow["DATA_LENGTH"]);
            break;
        }
        objFormControl.HandleObject = txtHandle;
        mFormField.DataType = mDataType;
        mFormField.MaxValue = iMaxValue;
        mFormField.DataLength = ((TextBox)mControl).MaxLength;
      }
      //TextEdit
      else if (mFormField.ControlType == "TextEdit")
      {
        string mDataType = mDataRow["DATA_TYPE"].ToString().ToUpper();
        object iMaxValue = null;
        if (mDataType == "NUMBER")
        {
          if (Convert.ToInt32(mDataRow["DATA_SCALE"]) > 0)
          {
            if (Convert.ToInt32(mDataRow["DATA_LENGTH"]) > double.MaxValue.ToString().Length)
              mDataType = "DOUBLE";

            iMaxValue = Math.Pow(10, (Convert.ToInt32(mDataRow["DATA_LENGTH"]) - Convert.ToInt32(mDataRow["DATA_SCALE"]) - 1)) - 1 / Math.Pow(10, Convert.ToInt32(mDataRow["DATA_SCALE"]));
          }
          else
          {
            if ((Convert.ToInt32(mDataRow["DATA_LENGTH"]) > int.MaxValue.ToString().Length) || (Convert.ToInt32(mDataRow["DATA_LENGTH"]) == 0))
              mDataType = "LONG";
            else
            {
              if (Convert.ToInt32(mDataRow["DATA_LENGTH"]) > short.MaxValue.ToString().Length)
                mDataType = "INTEGER";
              else
              {
                mDataType = "SMALLINT";
                iMaxValue = Math.Pow(10, Convert.ToInt32(mDataRow["DATA_LENGTH"])) - 1;
              }
            }
          }
        }
        TextEditHandle txtEditHandle = new TextEditHandle((TextEdit)mControl, mDataType, null, iMaxValue);
        switch (mDataRow["DATA_TYPE"].ToString().ToUpper())
        {
          case "NVARCHAR2":
          case "CHAR":
          case "VARCHAR2":
          case "NCHAR":
          case "VARCHAR":
          case "NVARCHAR":
            ((TextEdit)mControl).Properties.MaxLength = Convert.ToInt32(mDataRow["DATA_LENGTH"]);
            break;
          case "CLOB":
          case "NCLOB":
          case "NTEXT":
          case "TEXT":
            ((TextEdit)mControl).Properties.MaxLength = Int32.MaxValue;
            break;
          case "NUMBER":
            if (((TextEdit)mControl).Properties.MaxLength > Convert.ToInt32(mDataRow["DATA_LENGTH"]))
              ((TextEdit)mControl).Properties.MaxLength = Convert.ToInt32(mDataRow["DATA_LENGTH"]);
            break;
        }
        objFormControl.HandleObject = txtEditHandle;
        mFormField.DataType = mDataType;
        mFormField.MaxValue = iMaxValue;
        mFormField.DataLength = ((TextEdit)mControl).Properties.MaxLength;
      }
      //RichTextBox
      else if (mFormField.ControlType == "RichTextBox")
      {
        ((RichTextBox)mControl).MaxLength = Convert.ToInt32(Globals.DB_GetValue(mDataRow["DATA_LENGTH"], Int32.MaxValue));
      }
      //ComboBox
      else if (mFormField.ControlType == "ComboBox")
      {
        if (mControl.TabStop)
        {
          ComboBoxHandle cboHandle = new ComboBoxHandle((System.Windows.Forms.ComboBox)mControl);
          objFormControl.HandleObject = cboHandle;
        }
      }
      //SpinEdit
      else if (mFormField.ControlType == "SpinEdit")
      {
        string mDataType = mDataRow["DATA_TYPE"].ToString().ToUpper();
        object iMaxValue = null;
        SpinEditHandle txtSpinEditHandle = new SpinEditHandle((SpinEdit)mControl, mDataType, null, iMaxValue);
        objFormControl.HandleObject = txtSpinEditHandle;
        mFormField.DataType = mDataType;
        mFormField.MaxValue = iMaxValue;
        mFormField.DataLength = ((SpinEdit)mControl).Properties.MaxLength;
      }
      //Other
      else if (((mFormField.ControlType != "LookUpEdit") && (mFormField.ControlType != "CalcEdit")) && (((mFormField.ControlType != "DateEdit") && (mFormField.ControlType != "TimeEdit")) && ((mFormField.ControlType != "CheckEdit") && (mFormField.ControlType != "MemoEdit"))))
      {
        throw new Exception("Not support type of control " + mFormField.ControlType);
      }
      if (mControl.Tag != null)
      {
        if (mControl.Tag is FormControlExt)
          objFormControl.Tag = (FormControlExt)mControl.Tag;
        else
          objFormControl.Tag = mControl.Tag;
      }
      objFormControl.FieldName = mFormField.FieldName;
      mControl.Tag = objFormControl;
      mFormField.Required = (mDataRow["IS_NULLABLE"].ToString() == "NO");
      if (mFormField.Required && mControl.TabStop)
        Control_SetRequire(mControl, true);
    }

    private static string ControlField_GetKey(Control objControl, string sTableName)
    {
      return (objControl.FindForm().Name + "|" + objControl.Name + "|" + sTableName);
    }

    private static object Find_Control(Control mParentControl, string sName)
    {
      Control[] arrControl = mParentControl.Controls.Find(sName, true);
      if (arrControl.Length == 0)
        return null;

      return arrControl[0];
    }

    private static List<FormField> FormField_GetCache(Control objControl, string sTableName)
    {
      string sKey = ControlField_GetKey(objControl, sTableName);
      if (!mFieldCache.ContainsKey(sKey))
        return null;

      return mFieldCache[sKey];
    }

    private static DataTable GetTableField(string sTableName)
    {
      sTableName = sTableName.ToUpper();
      if (!mTableCache.ContainsKey(sTableName))
      {
        DataTable mDataTable = GetField_Function(sTableName);
        mDataTable.PrimaryKey = new DataColumn[] { mDataTable.Columns["COLUMN_NAME"] };
        mDataTable.AcceptChanges();
        mTableCache.Add(sTableName, mDataTable);
      }
      return mTableCache[sTableName];
    }

    public static void ListControl_BindData(object objList, object mDataSource, string mDisplayField, string mValueField, bool bSort)
    {
      if (mDisplayField != null)
      {
        ((ListBox)objList).DisplayMember = mDisplayField;
        ((ListBox)objList).ValueMember = mValueField;
      }
      if (mDataSource is ArrayList)
      {
        ArrayList arr = (ArrayList)mDataSource;
        ((ListBox)objList).Items.Clear();
        if (arr.Count != 0)
        {
          if (Globals.Object_GetProperty(arr[0].GetType(), ref mValueField) == null)
            throw new Exception(string.Format("Value field '{0}' not found in object property", mValueField));

          foreach (Object objItem in (ArrayList)mDataSource)
          {
            ((ListBox)objList).Items.Add(objItem);
          }
        }
      }
      else if (mDataSource is IDataReader)
      {
        ((ListBox)objList).Items.Clear();
        ((ListControl)objList).DisplayMember = "DisplayField";
        ((ListControl)objList).ValueMember = "ValueField";
        IDataReader mReader = (IDataReader)mDataSource;
        try
        {
          string[] arr;
          string sDisplayField = "";
          int iDisplayField = 1;
          int iValueField = 0;

          try
          {
            iValueField = mReader.GetOrdinal(mValueField);
          }
          catch
          {
            throw new Exception(string.Format("Value field '{0}' not found in data", mValueField));
          }

          try
          {
            arr = mDisplayField.Split(new char[] { ' ' });
            if (arr.Length == 1)
              iDisplayField = mReader.GetOrdinal(mDisplayField);
            else
            {
              for (int i = 0; i <= arr.Length - 1; i++)
              {
                int iOrd = -1;
                try
                {
                  iOrd = mReader.GetOrdinal(arr[i]);
                }
                catch
                {
                }

                if (iOrd >= 0)
                  sDisplayField = sDisplayField + "," + iOrd.ToString();
                else
                  sDisplayField = sDisplayField + "," + arr[i];
              }
              sDisplayField = sDisplayField.Substring(1);
            }
          }
          catch
          {
          }

          while (mReader.Read())
          {
            ListBoxItem mItem = new ListBoxItem();
            arr = sDisplayField.Split(new char[] { ',' });
            if (arr.Length == 1)
              mItem.DisplayField = mReader[iDisplayField].ToString();
            else
            {
              string sTemp = "";
              for (int i = 0; i <= arr.Length - 1; i++)
              {
                if (int.TryParse(arr[i], out iDisplayField))
                  sTemp += " " + mReader[iDisplayField];
                else
                  sTemp += " " + arr[i];
              }
              mItem.DisplayField = sTemp.TrimStart(new char[0]);
            }
            mItem.ValueField = mReader[iValueField].ToString();
            ((ListBox)objList).Items.Add(mItem);
          }
        }
        finally
        {
          Globals.Reader_Close(mReader);
          mReader = null;
        }
      }
      else
      {
        DataTable dt;
        if (mDataSource is DataTable)
          dt = (DataTable)mDataSource;
        else
        {
          if (!(mDataSource is DataView))
            throw new Exception("Function isn't support data source " + mDataSource.GetType().Name);
          dt = ((DataView)mDataSource).Table;
        }
        if (!dt.Columns.Contains(mValueField))
          throw new Exception(string.Format("Value field '{0}' not found in data", mValueField));

        string[] arr = mDisplayField.Split(new char[] { ' ' });
        if (arr.Length > 1)
        {
          mDisplayField = mDisplayField.Replace(" ", "_");
          dt.Columns.Add(mDisplayField, typeof(string));

          foreach (DataRow mRow in dt.Rows)
          {
            string sTemp = "";
            foreach (string mField in arr)
            {
              if (dt.Columns.Contains(mField))
                sTemp = sTemp + mRow[mField].ToString() + " ";
              else
                sTemp = sTemp + mField + " ";
            }
            mRow[mDisplayField] = sTemp.Trim();
          }
        }
        if (bSort)
        {
          dt.Columns.Add("Sort_Field", typeof(string));
          foreach (DataRow mRow in dt.Rows)
          {
            mRow["Sort_Field"] = mRow[mDisplayField];
          }
          dt.DefaultView.Sort = "Sort_Field";
        }
          ((ListBox)objList).DisplayMember = mDisplayField;
        ((ListBox)objList).ValueMember = mDataSource.ToString();
      }
    }

    #endregion

    #region "DataTable"

    public static DataTable TableAddColumn(DataTable dt)
    {
      dt.Columns.Add("NO", typeof(decimal));
      for (int i = 0; i <= dt.Rows.Count - 1; i++)
      {
        dt.Rows[i]["NO"] = i + 1;
      }
      return dt;
    }

    #endregion

    #region "Application Function"

    public static string App_GetTheme()
    {
      string s = "WindowsClassic";
      RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\ThemeManager");
      if ((key != null) && ("1" == key.GetValue("ThemeActive").ToString()))
        s = key.GetValue("ColorName").ToString();

      return s;
    }

    public static Color App_GetColor(string sColor)
    {
      if (sColor.StartsWith("#"))
        return ColorTranslator.FromHtml(sColor);
      else
        return Color.FromName(sColor);
    }

    public static long App_TextWidth(string sText, Font f)
    {
      Bitmap i = new Bitmap(1, 1);
      return (long)Math.Round((double)Graphics.FromImage(i).MeasureString(sText, f).Width);
    }

    public static void App_ShowProgress(MethodInvoker _MethodAddress)
    {
      frmProgress.Instance().Thread = _MethodAddress;
      frmProgress.Instance().Show_Progress();
    }

    public static void App_ShowProgress(MethodInvoker _MethodAddress, string sInitText)
    {
      frmProgress.Instance().Thread = _MethodAddress;
      frmProgress.Instance().Show_Progress(sInitText);
    }

    public static void App_ShowProgress(MethodInvoker _MethodAddress, string sInitText, string sFinishText)
    {
      frmProgress.Instance().Thread = _MethodAddress;
      frmProgress.Instance().Show_Progress(sInitText, sFinishText);
    }

    public static object App_ShowProgress(frmProgress.FunctionInvoker _FunctionAddress, object objInput, string sDesc)
    {
      frmProgress.Instance().ThreadFunction = _FunctionAddress;
      frmProgress.Instance().ThreadInputObject = objInput;
      return frmProgress.Instance().Show_Progress(sDesc);
    }

    public static void App_ShowProgress(frmProgress.SubInvoker _SubAddress, object objInput, string sInitText)
    {
      frmProgress.Instance().ThreadSub = _SubAddress;
      frmProgress.Instance().ThreadInputObject = objInput;
      frmProgress.Instance().Show_Progress(sInitText);
    }

    #endregion

    #region "Panel Function"

    public static bool Panel_CheckError(Control objControl)
    {
      return Panel_CheckError(objControl, false);
    }

    public static bool Panel_CheckError(Control objControl, bool bSilent)
    {
      try
      {
        bool bReturn = true;
        Control mControl = null;
        string sControlType = null;
        string sError = null;
        bool bError = false;
        string sCaption = null;

        for (int i = 0; i <= objControl.Controls.Count - 1; i++)
        {
          mControl = objControl.Controls[i];
          sControlType = mControl.GetType().Name;
          if ((mControl.Controls.Count > 0) && (mControl.Enabled) && (sControlType.IndexOf("Panel") > -1 || sControlType.IndexOf("Tab") > -1 || sControlType.IndexOf("Group") > -1))
          {
            bReturn = Panel_CheckError(mControl, bSilent);
            if (!bReturn)
              return bReturn;
          }
          else
          {
            if (mControl.Tag is FormControlExt)
            {
              FormControlExt objControlExt = (FormControlExt)mControl.Tag;
              switch (sControlType)
              {
                case "TextBox":
                  if (objControlExt.Required)
                    bReturn = (mControl.Text.Trim() != "");
                  break;
                case "TextEdit":
                  if (objControlExt.Required)
                    bReturn = (mControl.Text.Trim() != "");
                  break;
                case "DateEdit":
                  if (objControlExt.Required)
                    bReturn = (mControl.Text.Trim() != "");
                  break;
                case "TimeEdit":
                  if (objControlExt.Required)
                    bReturn = (mControl.Text.Trim() != "");
                  break;
                case "CheckEdit":
                  bReturn = true;
                  break;
                case "ComboBox":
                  if (objControlExt.Required)
                    bReturn = !Null.IsNull(Combo_GetValue((System.Windows.Forms.ComboBox)mControl));
                  break;
                case "HtmlEditorControl":
                  if (objControlExt.Required)
                  {
                  }
                  break;
                default:
                  if (objControlExt.Required)
                    bReturn = (mControl.Text.Trim() != "");
                  break;
              }
            }
            else
              continue;
          }
          if ((sControlType == "TextBox") && !((TextBox)mControl).ReadOnly)
          {
            sError = Control_GetError(mControl);
            bError = !string.IsNullOrEmpty(sError);
          }
          if ((sControlType == "TextEdit") && !((TextEdit)mControl).Properties.ReadOnly)
          {
            sError = Control_GetError(mControl);
            bError = !string.IsNullOrEmpty(sError);
          }
          if (!bReturn || bError)
          {
            if (!bSilent)
            {
              Control ctlParent = mControl.Parent;
              while (!(ctlParent is Form))
              {
                if ((ctlParent is TabPage) && (((TabControl)ctlParent.Parent).SelectedIndex != ((TabPage)ctlParent).TabIndex))
                {
                  ((TabControl)ctlParent.Parent).SelectedIndex = ((TabPage)ctlParent).TabIndex;
                  break;
                }
                ctlParent = ctlParent.Parent;
              }
              mControl.Focus();
              sCaption = Control_GetLabel(mControl).ToString();
              if (string.IsNullOrEmpty(sCaption))
                sCaption = "required field";
              else
                sCaption = "'" + sCaption + "'";

              if (!bReturn)
                sCaption = sCaption + " is required field";

              if (bError)
              {
                if (sCaption == "required field")
                  sCaption = sError;
                else
                  sCaption = sError + " for " + sCaption;
                bReturn = false;
              }
              Message_Information(sCaption);
            }
          }
        }
        return bReturn;
      }
      catch(Exception ex)
      {
        string exM = ex.Message;
        return false;
      }
    }

    public static void Panel_GetControlValue(Control objPanel, object objInfo)
    {
      string sTableName = objPanel.Tag.ToString();
      Panel_GetControlValue(objPanel, objInfo, sTableName);
    }

    public static void Panel_GetControlValue(Control objPanel, object objInfo, string sTableName)
    {
      List<FormField> arrFormField = FormField_GetCache(objPanel, sTableName);
      if (arrFormField == null)
        throw new Exception(string.Format("Control '{0}' isn't init control with table '{1}'", objPanel.Name, sTableName));

      foreach (FormField mFormField1 in arrFormField)
      {
        //Modify: Cannot modify members of 'mFormField' because it is a 'foreach iteration variable'
        FormField mFormField;
        mFormField = mFormField1;

        Control mControl = (Control)Find_Control(objPanel, mFormField.ControlName);
        if (mControl != null)
        {
          string temp = mFormField.FieldName;
          PropertyInfo objProperty = Globals.Object_GetProperty(objInfo.GetType(), ref temp);
          //Modify: A property or indexer may not be passed as an out or ref parameter
          mFormField.FieldName = temp;
          if ((objProperty != null) && objProperty.CanWrite)
          {
            object objValue = objProperty.GetValue(objInfo, null);
            if (mFormField.ControlType == "TextBox")
              objValue = ((TextBox)mControl).Text;
            else if (mFormField.ControlType == "RichTextBox")
              objValue = ((RichTextBox)mControl).Rtf;
            else if (mFormField.ControlType == "ComboBox")
              objValue = Combo_GetValue((System.Windows.Forms.ComboBox)mControl);
            else if (mFormField.ControlType == "TextEdit")
              objValue = ((TextEdit)mControl).Text;
            else if (mFormField.ControlType == "DateEdit")
              objValue = ((DateEdit)mControl).DateTime.Date;
            else if (mFormField.ControlType == "TimeEdit")
              objValue = ((TimeEdit)mControl).Time;
            else if (mFormField.ControlType == "SpinEdit")
              objValue = ((SpinEdit)mControl).Text;
            else if (mFormField.ControlType == "LookUpEdit")
              objValue = ((LookUpEdit)mControl).EditValue;
            else if (mFormField.ControlType == "CheckBox")
              objValue = ((CheckBox)mControl).Checked;
            else
            {
              if (mFormField.ControlType != "CheckEdit")
                continue;

              if (((CheckEdit)mControl).Checked)
                objValue = 1;
              else
                objValue = 0;
            }
            objValue = Globals.Object_SetValueEx(objValue, objProperty.PropertyType.Name, false);
            objProperty.SetValue(objInfo, objValue, null);
          }
        }
      }
    }

    public static void Panel_SetControlValue(Control objPanel, object objInfo)
    {
      Panel_SetControlValue(objPanel, objInfo, false);
    }

    public static void Panel_SetControlValue(Control objPanel, object objInfo, bool bIgnoreError)
    {
      string sTableName = objPanel.Tag.ToString();
      Panel_SetControlValue(objPanel, objInfo, sTableName, bIgnoreError);
    }

    public static void Panel_SetControlValue(Control objPanel, object objInfo, string sTableName)
    {
      Panel_SetControlValue(objPanel, objInfo, sTableName, false);
    }

    public static void Panel_SetControlValue(Control objPanel, object objInfo, string sTableName, bool bIgnoreError)
    {
      List<FormField> arrFormField = FormField_GetCache(objPanel, sTableName);
      if (arrFormField == null)
        throw new Exception(string.Format("Control '{0}' isn't init control with table '{1}'", objPanel.Name, sTableName));

      foreach (FormField mFormField1 in arrFormField)
      {
        //Modify: Cannot modify members of 'mFormField' because it is a 'foreach iteration variable'
        FormField mFormField;
        mFormField = mFormField1;

        Control mControl = (Control)Find_Control(objPanel, mFormField.ControlName);
        if (mControl != null)
        {
          string temp = mFormField.FieldName;
          object objValue = Globals.Object_GetProperty(objInfo.GetType(), ref temp).GetValue(objInfo, null);
          //Modify: A property or indexer may not be passed as an out or ref parameter
          mFormField.FieldName = temp;

          if (mFormField.ControlType == "TextBox")
            ((TextBox)mControl).Text = Globals.Object_GetDisplayValue(objValue, "");
          else if (mFormField.ControlType == "TextEdit")
            ((TextEdit)mControl).Text = Globals.Object_GetDisplayValue(objValue, "");
          else if (mFormField.ControlType == "RichTextBox")
            ((RichTextBox)mControl).Rtf = Globals.Object_GetDisplayValue(objValue, "");
          else if (mFormField.ControlType == "ComboBox")
            Combo_SetValue((System.Windows.Forms.ComboBox)mControl, objValue, bIgnoreError);
          else if (mFormField.ControlType == "LookUpEdit")
            LookUpEdit_SetValue((LookUpEdit)mControl, objValue, bIgnoreError);
          else if (mFormField.ControlType == "SpinEdit")
            ((SpinEdit)mControl).Text = Globals.Object_GetDisplayValue(objValue, "");
          else if (mFormField.ControlType == "MemoEdit")
            ((TextEdit)mControl).Text = Globals.Object_GetDisplayValue(objValue, "");
          else if (mFormField.ControlType == "DateEdit")
          {
            if (Globals.Object_GetDisplayValue(objValue, "") != "")
              ((DateEdit)mControl).DateTime = Convert.ToDateTime(Globals.Object_GetDisplayValue(objValue, ""));
            else
              ((DateEdit)mControl).EditValue = null;
          }
          else if (mFormField.ControlType == "TimeEdit")
          {
            if (Globals.Object_GetDisplayValue(objValue, "") != "")
              ((TimeEdit)mControl).Time = Convert.ToDateTime(((DateTime)objValue).ToString("HH:mm:ss"));
          }
          else if (mFormField.ControlType == "CheckBox")
            ((CheckBox)mControl).Checked = Convert.ToBoolean(objValue);
          else if (mFormField.ControlType == "CheckEdit")
            ((CheckEdit)mControl).Checked = Convert.ToBoolean(objValue);
          else
            throw new Exception("Not support type of control: " + mControl.GetType().Name);
        }
      }
    }

    public static void Panel_InitControl(Control objControl, string sTableName)
    {
      Panel_InitControl(objControl, sTableName, "");
    }

    public static void Panel_InitControl(Control objControl, string sTableName, string sExceptControl)
    {
      DataTable mDataTable;
      string sKey = ControlField_GetKey(objControl, sTableName);
      try
      {
        List<FormField> arrCache;
        if (!mFieldCache.ContainsKey(sKey))
        {
          mDataTable = GetTableField(sTableName);
          if (mDataTable.Rows.Count > 0)
          {
            arrCache = SetControlByField(objControl, mDataTable, sExceptControl);
            mFieldCache.Add(sKey, arrCache);
          }
          else
            throw new Exception("Table '" + sTableName + "' do not exist");
        }
        else
        {
          arrCache = mFieldCache[sKey];
          SetControlField(objControl, arrCache);
        }
        objControl.Tag = sTableName;
      }
      catch
      {
        throw;
      }
    }

    #endregion

    #region "Textbox, TextEdit Function"

    public static void TextBox_SetHandle(TextBox tb, string DataType, object MinValue, object MaxValue, bool AutoClearError)
    {
      FormControlExt objFormControl;
      if (tb.Tag == null)
        objFormControl = new FormControlExt();
      else
        objFormControl = (FormControlExt)tb.Tag;

      if (objFormControl.HandleObject == null)
      {
        TextBoxHandle mHandle = new TextBoxHandle(tb, DataType, MinValue, MaxValue)
        {
          AutoClearError = AutoClearError
        };
        objFormControl.HandleObject = mHandle;
      }
      else
      {
        ((TextBoxHandle)objFormControl.HandleObject).DataType = DataType;
        ((TextBoxHandle)objFormControl.HandleObject).MinValue = MinValue;
        ((TextBoxHandle)objFormControl.HandleObject).MaxValue = MaxValue;
      }
      tb.Tag = objFormControl;
    }

    public static void TextEdit_SetHandle(TextEdit te, string DataType, object MinValue, object MaxValue, bool AutoClearError)
    {
      FormControlExt objFormControl;
      if (te.Tag == null)
        objFormControl = new FormControlExt();
      else
        objFormControl = (FormControlExt)te.Tag;

      if (objFormControl.HandleObject == null)
      {
        TextEditHandle mHandle = new TextEditHandle(te, DataType, MinValue, MaxValue)
        {
          AutoClearError = AutoClearError
        };
        objFormControl.HandleObject = mHandle;
      }
      else
      {
        ((TextEditHandle)objFormControl.HandleObject).DataType = DataType;
        ((TextEditHandle)objFormControl.HandleObject).MinValue = MinValue;
        ((TextEditHandle)objFormControl.HandleObject).MaxValue = MaxValue;
      }
      te.Tag = objFormControl;
    }

    public static void Control_SetError(Control objControl, string sError)
    {
      ErrorProvider errPro = Form_GetErrorProvider(objControl.FindForm());
      errPro.SetError(objControl, sError);
      if (sError.Length > 0)
      {
        Control objErrControl = objControl.Parent.GetChildAtPoint(new Point(objControl.Left - 18, objControl.Top));
        int iPadding = 2;
        if (((objErrControl != null) && (objErrControl is TextBox)) && ((TextBox)objErrControl).ReadOnly)
          iPadding += objControl.Left - objErrControl.Left;

        if (((objErrControl != null) && (objErrControl is TextEdit)) && ((TextEdit)objErrControl).Properties.ReadOnly)
          iPadding += objControl.Left - objErrControl.Left;

        errPro.SetIconAlignment(objControl, ErrorIconAlignment.TopLeft);
        errPro.SetIconPadding(objControl, iPadding);
        Form mForm = objControl.FindForm();
        if (mForm.AutoValidate != AutoValidate.EnableAllowFocusChange)
          mForm.AutoValidate = AutoValidate.EnableAllowFocusChange;
      }
    }

    public static string Control_GetError(Control objControl)
    {
      return Form_GetErrorProvider(objControl.FindForm()).GetError(objControl);
    }

    #endregion

    #region "Combobox Function"

    public const string COMBO_ITEM_BLANK = "";
    public const string COMBO_ITEM_NULL_VALUE = "-1111111111";
    public const string COMBO_ITEM_REQUIRE = "<Please choose>";
    public const string COMBO_ITEM_SELECT_ALL = "<All>";

    public static void Combo_BindData(System.Windows.Forms.ComboBox objList, object mDataSource, string mDisplayField, bool bSort)
    {
      Combo_BindData(objList, mDataSource, mDisplayField, "", bSort);
    }

    public static void Combo_BindData(DataGridViewComboBoxColumn objList, object mDataSource, string mDisplayField, string mValueField, bool bSort)
    {
      Combo_BindData(objList, mDataSource, mDisplayField, mValueField, "", bSort);
    }

    public static void Combo_BindData(System.Windows.Forms.ComboBox objList, object mDataSource, string mDisplayField, string sFirstItem, bool bSort)
    {
      string mValueField;
      if (objList.Tag is FormControlExt)
        mValueField = ((FormControlExt)objList.Tag).FieldName;
      else if (string.IsNullOrEmpty(objList.ValueMember))
      {
        mValueField = objList.Name.Substring(3);
        if (!mValueField.EndsWith("_ID"))
          mValueField = mValueField + "_ID";
      }
      else
        mValueField = objList.ValueMember;

      if (string.IsNullOrEmpty(mValueField))
        throw new Exception("Can't get Value Field because control don't have extend property");

      Combo_BindData(objList, mDataSource, mDisplayField, mValueField, sFirstItem, bSort);
    }

    public static void Combo_BindData(object objList, object mDataSource, string mDisplayField, string mValueField, string sFirstItem, bool bSort)
    {
      ListControl_BindData(objList, mDataSource, mDisplayField, mValueField, bSort);
      string sDisplayText = "";

      if (sFirstItem != "")
      {
        sDisplayText = sFirstItem;
        if (mDataSource is DataTable)
        {
          DataRow mRow = ((DataTable)mDataSource).NewRow();
          foreach (DataColumn mCol in mRow.Table.Columns)
          {
            mCol.AllowDBNull = true;
          }
          mRow[((System.Windows.Forms.ComboBox)objList).DisplayMember] = sDisplayText;
          if (((System.Windows.Forms.ComboBox)objList).DisplayMember != ((System.Windows.Forms.ComboBox)objList).ValueMember)
            mRow[((System.Windows.Forms.ComboBox)objList).ValueMember] = DBNull.Value;
          ((DataTable)mDataSource).Rows.InsertAt(mRow, 0);
        }
        else if (mDataSource is DataView)
        {
          DataRowView mRow = ((DataView)mDataSource).AddNew();
          foreach (DataColumn mCol in mRow.DataView.Table.Columns)
          {
            mCol.AllowDBNull = true;
          }
          mRow[((System.Windows.Forms.ComboBox)objList).DisplayMember] = sDisplayText;
          if (((System.Windows.Forms.ComboBox)objList).DisplayMember != ((System.Windows.Forms.ComboBox)objList).ValueMember)
          {
            int iMaxLen = mRow.DataView.Table.Columns[((System.Windows.Forms.ComboBox)objList).ValueMember].MaxLength;
            if (iMaxLen > 0)
              mRow[((System.Windows.Forms.ComboBox)objList).ValueMember] = COMBO_ITEM_NULL_VALUE.Substring(0, iMaxLen);
            else
              mRow[((System.Windows.Forms.ComboBox)objList).ValueMember] = DBNull.Value;
          }
            ((DataView)mDataSource).Sort = ((System.Windows.Forms.ComboBox)objList).DisplayMember;
          ((DataView)mDataSource).ApplyDefaultSort = true;
        }
        else
        {
          sDisplayText = sFirstItem;
          Type objType = ((System.Windows.Forms.ComboBox)objList).Items[0].GetType();
          object mObject = Activator.CreateInstance(objType);

          string vMember = ((System.Windows.Forms.ComboBox)objList).ValueMember;
          string dMember = ((System.Windows.Forms.ComboBox)objList).DisplayMember;
          PropertyInfo objProperty = Globals.Object_GetProperty(objType, ref vMember);
          //Modify: A property or indexer may not be passed as an out or ref parameter
          ((System.Windows.Forms.ComboBox)objList).ValueMember = vMember;
          objProperty.SetValue(mObject, Null.SetNull(objProperty), null);

          objProperty = Globals.Object_GetProperty(objType, ref dMember);
          //Modify: A property or indexer may not be passed as an out or ref parameter
          ((System.Windows.Forms.ComboBox)objList).DisplayMember = dMember;
          objProperty.SetValue(mObject, sDisplayText, null);

          ((System.Windows.Forms.ComboBox)objList).Items.Insert(0, mObject);
        }
      }
      if (objList is System.Windows.Forms.ComboBox)
      {
        System.Windows.Forms.ComboBox objCombo = (System.Windows.Forms.ComboBox)objList;
        if (sFirstItem != "")
          objCombo.SelectedIndex = 0;
      }
    }

    public static void Combo_SetHandle(System.Windows.Forms.ComboBox cb, bool RequiredField)
    {
      FormControlExt objFormControl = new FormControlExt
      {
        HandleObject = new ComboBoxHandle(cb)
      };
      cb.Tag = objFormControl;
      Control_SetRequire(cb, RequiredField);
    }

    public static void Combo_SetValue(System.Windows.Forms.ComboBox objCombo, object sValue)
    {
      Combo_SetValue(objCombo, sValue, false, "");
    }

    public static void Combo_SetValue(System.Windows.Forms.ComboBox objCombo, object sValue, bool bIgnoreError)
    {
      Combo_SetValue(objCombo, sValue, bIgnoreError, "");
    }

    public static void Combo_SetValue(System.Windows.Forms.ComboBox objCombo, object sValue, bool bIgnoreError, string sCorrectDisplay)
    {
      if (((sValue == null) || (sValue == DBNull.Value)) || Null.IsNull(sValue))
      {
        if (objCombo.Items.Count > 0)
          objCombo.SelectedIndex = 0;
        return;
      }
      if (((objCombo.Items.Count == 0) && !bIgnoreError) && (sCorrectDisplay == ""))
      {
        throw new Exception("Can't set value with blank combo: " + objCombo.Name);
      }
      bool bFound = false;
      object mSource = objCombo.DataSource;
      if (objCombo.Items.Count > 0)
      {
        objCombo.SelectedIndex = -1;
        if (!((mSource is DataView) || (mSource is DataTable)))
        {
          DataView mDataView;
          if (mSource is DataView)
            mDataView = (DataView)mSource;
          else
            mDataView = ((DataTable)mSource).DefaultView;

          int i = 0;
          for (i = 0; i <= mDataView.Count - 1; i++)
          {
            object oItemValue = mDataView.Table.Rows[i][objCombo.ValueMember];
            if ((oItemValue != null) && (oItemValue == sValue))
            {
              bFound = true;
              break;
            }
          }
          if (bFound)
            objCombo.SelectedIndex = i;
          else
            objCombo.SelectedIndex = 0;
        }
        else
        {
          Type objType = objCombo.Items[0].GetType();
          string temp = objCombo.ValueMember;
          PropertyInfo objProperty = Globals.Object_GetProperty(objType, ref temp);
          //Modify: A property or indexer may not be passed as an out or ref parameter
          objCombo.ValueMember = temp;

          foreach (Object objItem in objCombo.Items)
          {
            if (objItem.GetType().Name == sValue.GetType().Name)
            {
              if (Globals.Object_Compare(objItem, sValue))
              {
                objCombo.SelectedItem = objItem;
                bFound = true;
                break;
              }
            }
            else if (objProperty == null)
              break;
            else if (objProperty.GetValue(objItem, null).ToString() == sValue.ToString())
            {
              objCombo.SelectedItem = objItem;
              bFound = true;
              break;
            }
          }
        }
      }
      if (!bFound)
      {
        if (sCorrectDisplay != "")
        {
          if (objCombo.DataSource is DataTable)
          {
            DataRow mRow = ((DataTable)objCombo.DataSource).NewRow();
            mRow[objCombo.DisplayMember] = sCorrectDisplay;
            mRow[objCombo.ValueMember] = sValue;
            ((DataTable)objCombo.DataSource).Rows.Add(mRow);
            objCombo.SelectedValue = sValue;
          }
          else if (objCombo.DataSource is DataView)
          {
            DataRowView mRow = ((DataView)objCombo.DataSource).AddNew();
            mRow[objCombo.DisplayMember] = sCorrectDisplay;
            mRow[objCombo.ValueMember] = sValue;
            objCombo.SelectedValue = sValue;
          }
          else
          {
            ListBoxItem obj = new ListBoxItem(sValue.ToString(), sCorrectDisplay);
            objCombo.Items.Add(obj);
            objCombo.SelectedItem = obj;
          }
        }
        else if (sCorrectDisplay != "")
          objCombo.Text = sCorrectDisplay;
        else if (!bIgnoreError)
          throw new Exception(string.Format("Item with value '{0}' not found in ComboBox: " + objCombo.Name, sValue));
      }
      TextBox objView = (TextBox)Find_Control(objCombo.Parent, objCombo.Name + "_View");
      if (objView != null)
        objView.Text = objCombo.Text;
    }

    public static object Combo_GetValue(System.Windows.Forms.ComboBox objCombo)
    {
      if (objCombo.SelectedValue != null)
        return objCombo.SelectedValue;
      else if (objCombo.SelectedItem != null)
      {
        object objItem = objCombo.Items[objCombo.SelectedIndex];
        if (objCombo.ValueMember == "")
          return objItem;
        else
        {
          string temp = objCombo.ValueMember;
          PropertyInfo objProperty = Globals.Object_GetProperty(objItem.GetType(), ref temp);
          //Modify: A property or indexer may not be passed as an out or ref parameter
          objCombo.ValueMember = temp;
          if (objProperty == null)
            return objItem;
          else
            return objProperty.GetValue(objItem, null);
        }
      }
      else
        return Null.NullString;
    }

    public static void LookUpEdit_SetValue(LookUpEdit objLookUpEdit, object sValue, bool bIgnoreError, string sCorrectDisplay)
    {
      objLookUpEdit.DataBindings.Clear();
      objLookUpEdit.EditValue = sValue;
    }

    public static void LookUpEdit_SetHandle(LookUpEdit objLookUpEdit)
    {
      FormControlExt objFormControl = new FormControlExt
      {
        HandleObject = new LookUpEditHandle(objLookUpEdit)
      };
      objLookUpEdit.Tag = objFormControl;
    }

    #endregion

    #region "DataGridView Function"

    public static bool Grid_CheckValid(DataGridView objGrid)
    {
      DataTable mTable;
      if (objGrid.DataSource is DataView)
        mTable = ((DataView)objGrid.DataSource).Table;
      else if (objGrid.DataSource is DataTable)
        mTable = (DataTable)objGrid.DataSource;
      else
        return true;

      foreach (DataRow mRow in mTable.GetErrors())
      {
        if (mRow.RowState != DataRowState.Deleted)
          return false;
      }
      return true;
    }

    public static void Grid_FormatButtonColumn(DataGridViewButtonColumn clmButton)
    {
      clmButton.UseColumnTextForButtonValue = true;
      clmButton.HeaderText = "";
      clmButton.DefaultCellStyle.BackColor = SystemColors.Control;
      clmButton.DefaultCellStyle.NullValue = clmButton.Text;
      clmButton.DefaultCellStyle.SelectionBackColor = SystemColors.Control;
      clmButton.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
    }

    public static void Grid_SetColumnCopy(DataColumn objColumn, bool bSetOn)
    {
      if (bSetOn)
        objColumn.Caption = objColumn.ColumnName;
      else
        objColumn.Caption = "HIDE";
    }

    public static void Grid_SetColumnViewOnly(DataGridViewColumn objColumn, bool bSetOn)
    {
      objColumn.ReadOnly = bSetOn;
      if (bSetOn)
        objColumn.DefaultCellStyle.ForeColor = Color.Gray;
      else
        objColumn.DefaultCellStyle.ForeColor = Color.Black;
    }

    public static void Grid_SetRowObject(DataGridView objGrid, object objInfo)
    {
      foreach (PropertyInfo mProperty in objInfo.GetType().GetProperties())
      {
        if (objGrid.Columns.Contains(mProperty.Name))
        {
          if (objGrid.Columns[mProperty.Name] is DataGridViewCheckBoxColumn)
          {
            if (Convert.ToBoolean(mProperty.GetValue(objInfo, null)))
              objGrid.CurrentRow.Cells[mProperty.Name].Value = "1";
            else
              objGrid.CurrentRow.Cells[mProperty.Name].Value = "0";
          }
          else
            objGrid.CurrentRow.Cells[mProperty.Name].Value = Globals.DB_GetNull(mProperty.GetValue(objInfo, null));
        }
        else
        {
          if (!objGrid.CurrentRow.IsNewRow)
          {
            DataRow objRow;
            try
            {
              if (objGrid.DataSource is DataTable)
                objRow = ((DataTable)objGrid.DataSource).Rows[objGrid.CurrentRow.Index];
              else
                objRow = ((DataView)objGrid.DataSource).Table.Rows[objGrid.CurrentRow.Index];
            }
            catch
            {
              continue;
            }
            if (objRow.Table.Columns.Contains(mProperty.Name))
            {
              if (mProperty.GetValue(objInfo, null) is bool)
              {
                if (Convert.ToBoolean(mProperty.GetValue(objInfo, null)))
                  objRow[mProperty.Name] = "1";
                else
                  objRow[mProperty.Name] = "0";
              }
              else
                objRow[mProperty.Name] = Globals.DB_GetNull(mProperty.GetValue(objInfo, null));
            }
          }
        }
      }
    }

    public static void Grid_GetRowObject(DataGridView objGrid, object objInfo)
    {
      foreach (PropertyInfo mProperty in objInfo.GetType().GetProperties())
      {
        object objValue;
        if (objGrid.Columns.Contains(mProperty.Name))
          objValue = objGrid.CurrentRow.Cells[mProperty.Name].Value;
        else
        {
          DataRow objRow;
          if (objGrid.CurrentRow.IsNewRow)
            continue;
          try
          {
            if (objGrid.DataSource is DataTable)
              objRow = ((DataTable)objGrid.DataSource).Rows[objGrid.CurrentRow.Index];
            else
              objRow = ((DataView)objGrid.DataSource).Table.Rows[objGrid.CurrentRow.Index];
          }
          catch
          {
            continue;
          }
          if (objRow.Table.Columns.Contains(mProperty.Name))
            objValue = objRow[mProperty.Name];
          else
            continue;
        }
        if (objValue == null)
          mProperty.SetValue(objInfo, Null.SetNull(mProperty), null);
        else if (mProperty.PropertyType.Name == "Boolean")
          mProperty.SetValue(objInfo, Convert.ToBoolean(objValue), null);
        else
          mProperty.SetValue(objInfo, Convert.ChangeType(objValue, mProperty.PropertyType), null);
      }
    }

    public static void Grid_MoveSelect(DataGridView dtgSource, DataGridView dtgDest)
    {
      int iCount = dtgSource.SelectedRows.Count;
      while (dtgSource.SelectedRows.Count > 0)
      {
        DataGridViewRow dtgRow = dtgSource.SelectedRows[dtgSource.SelectedRows.Count - 1];
        if (dtgSource.DataSource is DataTable)
        {
          object[] arrItem = ((DataRowView)dtgRow.DataBoundItem).Row.ItemArray;
          ((DataTable)dtgDest.DataSource).Rows.Add(arrItem);
        }
        else if (dtgSource.DataSource is DataView)
        {
          object[] arrItem = ((DataRowView)dtgRow.DataBoundItem).Row.ItemArray;
          ((DataView)dtgDest.DataSource).Table.Rows.Add(arrItem);
        }
        else
          dtgDest.Rows.Add(new object[] { dtgRow.Clone() });

        dtgSource.Rows.Remove(dtgRow);
        iCount--;
        if (iCount == 0)
        {
          dtgSource.ClearSelection();
          break;
        }
      }
    }

    public static void Grid_MoveAll(DataGridView dtgSource, DataGridView dtgDest)
    {
      int iCount = dtgSource.Rows.Count;
      while (dtgSource.Rows.Count > 0)
      {
        DataGridViewRow dtgRow = dtgSource.Rows[0];
        if (dtgSource.DataSource is DataTable)
        {
          object[] arrItem = ((DataRowView)dtgRow.DataBoundItem).Row.ItemArray;
          ((DataTable)dtgDest.DataSource).Rows.Add(arrItem);
        }
        else if (dtgSource.DataSource is DataView)
        {
          object[] arrItem = ((DataRowView)dtgRow.DataBoundItem).Row.ItemArray;
          ((DataView)dtgDest.DataSource).Table.Rows.Add(arrItem);
        }
        else
          dtgDest.Rows.Add(new object[] { dtgRow.Clone() });

        dtgSource.Rows.Remove(dtgRow);
        iCount--;
        if (iCount == 0)
        {
          dtgSource.ClearSelection();
          break;
        }
      }
    }

    public static void Grid_SetRowDisplay(DataGridView ctlGrid, string sColumnName)
    {
      Grid_SetRowDisplay(ctlGrid, sColumnName, 100);
    }

    public static void Grid_SetRowDisplay(DataGridView ctlGrid, string sColumnName, int iMaxHeight)
    {
      foreach (DataGridViewRow dtgRow in ctlGrid.Rows)
      {
        if (ctlGrid.Columns.Contains("Order_Code"))
          dtgRow.Cells["Order_Code"].Value = dtgRow.Index + 1;

        dtgRow.Height = iMaxHeight;
        dtgRow.Height = dtgRow.Cells[sColumnName].GetContentBounds(dtgRow.Index).Height + 10;
      }
    }

    #endregion

    #region "DevExpress.LookupEdit Function"

    public static object LookUpEdit_GetSelectedValue(LookUpEdit objLookUpEdit, string sColumnName)
    {
      object oRet = null;
      if (objLookUpEdit.EditValue != DBNull.Value)
      {
        DataRowView rvData = objLookUpEdit.Properties.GetDataSourceRowByKeyValue(objLookUpEdit.EditValue) as DataRowView;
        if (rvData != null)
        {
          DataRow row = rvData.Row;
          if (row[sColumnName] != DBNull.Value)
            oRet = row[sColumnName];
        }
      }
      return oRet;
    }

    public static object LookUpEdit_GetSelectedValue(LookUpEdit objLookUpEdit, string sColumnName, object ValueIfNull)
    {
      object oRet = null;
      if (objLookUpEdit.EditValue != DBNull.Value)
      {
        DataRowView rvData = objLookUpEdit.Properties.GetDataSourceRowByKeyValue(objLookUpEdit.EditValue) as DataRowView;
        if (rvData != null)
        {
          DataRow row = rvData.Row;
          if (row[sColumnName] != DBNull.Value)
            oRet = row[sColumnName];
        }
      }
      else
        oRet = ValueIfNull;
      return oRet;
    }

    public static void LookUpEdit_SetValue(LookUpEdit objLookUpEdit, object sValue, bool bIgnoreError)
    {
      LookUpEdit_SetValue(objLookUpEdit, sValue, bIgnoreError, "");
    }

    public static void LookupEdit_BindData(object objList, object mDataSource, string mDisplayField, string mValueField, string sSelectedValue, params object[] arrayDisplayField)
    {
      if ((arrayDisplayField != null) || (arrayDisplayField != null))
      {
        ((LookUpEdit)objList).Properties.Columns.Clear();

        int iUpper = arrayDisplayField.GetUpperBound(0);
        if ((iUpper >= 0) && arrayDisplayField[iUpper].GetType().IsArray)
        {
          object[] arr = (object[])arrayDisplayField[iUpper];
          Array.Resize<object>(ref arrayDisplayField, (arrayDisplayField.Length + arr.Length) - 1);
          for (int i = 0; i <= arr.Length - 1; i++)
          {
            arrayDisplayField[iUpper + i] = arr[i];
          }
        }
        if (sSelectedValue == "")
        {
          string sDisplayText = sSelectedValue;
          if (mDataSource is DataTable)
          {
            DataRow mRow = ((DataTable)mDataSource).NewRow();
            foreach (DataColumn mCol in mRow.Table.Columns)
            {
              mCol.AllowDBNull = true;
            }
            if (mRow[mValueField] is decimal)
              mRow[mValueField] = Null.NullDecimal;

            if (mRow[mValueField] is string)
              mRow[mValueField] = Null.NullString;

            if (mRow[mValueField] is bool)
              mRow[mValueField] = Null.NullBoolean;

            if (mRow[mValueField] is int)
              mRow[mValueField] = Null.NullInteger;

            if (mRow[mValueField] is DateTime)
              mRow[mValueField] = Null.NullDate;

            mRow[mDisplayField] = sSelectedValue;
            ((DataTable)mDataSource).Rows.InsertAt(mRow, 0);
            ((DataTable)mDataSource).AcceptChanges();
            ((LookUpEdit)objList).Properties.NullText = String.Empty;
          }
        }
          ((LookUpEdit)objList).DataBindings.Clear();
        ((LookUpEdit)objList).DataBindings.Add("EditValue", mDataSource, mValueField);

        ((LookUpEdit)objList).Properties.DataSource = mDataSource;
        ((LookUpEdit)objList).Properties.DisplayMember = mDisplayField;
        ((LookUpEdit)objList).Properties.ValueMember = mValueField;

        LookUpColumnInfoCollection coll = ((LookUpEdit)objList).Properties.Columns;
        int iColIndex = -1;
        foreach (string fieldDisplay in arrayDisplayField)
        {
          iColIndex = coll.Add(new LookUpColumnInfo(fieldDisplay, 0));
          if ((mDataSource is DataTable) && (((DataTable)mDataSource).Columns[fieldDisplay].DataType.Name == "DateTime"))
          {
            coll[iColIndex].FormatType = FormatType.DateTime;
            coll[iColIndex].FormatString = "d";
          }
        }

          ((LookUpEdit)objList).Properties.BestFitMode = BestFitMode.BestFitResizePopup;
        ((LookUpEdit)objList).Properties.SearchMode = SearchMode.AutoComplete;
        ((LookUpEdit)objList).Properties.AutoSearchColumnIndex = 0;

        LookUpEdit_SetHandle((LookUpEdit)objList);
      }
    }

    public static void Grid_LookUpEdit_BindData(object objList, object mDataSource, string mDisplayField, string mValueField, string sSelectedValue, params object[] arrayDisplayField)
    {
      if ((arrayDisplayField != null) || (arrayDisplayField != null))
      {
        ((LookUpEdit)objList).Properties.Columns.Clear();
        int iUpper = arrayDisplayField.GetUpperBound(0);
        if ((iUpper >= 0) && arrayDisplayField[iUpper].GetType().IsArray)
        {
          object[] arr = (object[])arrayDisplayField[iUpper];
          Array.Resize<object>(ref arrayDisplayField, (arrayDisplayField.Length + arr.Length) - 1);
          for (int i = 0; i <= arr.Length - 1; i++)
          {
            arrayDisplayField[iUpper + i] = arr[i];
          }
        }
        if (sSelectedValue == "")
        {
          string sDisplayText = sSelectedValue;
          if (mDataSource is DataTable)
          {
            DataRow mRow = ((DataTable)mDataSource).NewRow();
            foreach (DataColumn mCol in mRow.Table.Columns)
            {
              mCol.AllowDBNull = true;
            }

            if (mRow[mValueField] is decimal)
              mRow[mValueField] = Null.NullDecimal;

            if (mRow[mValueField] is string)
              mRow[mValueField] = Null.NullString;

            if (mRow[mValueField] is bool)
              mRow[mValueField] = Null.NullBoolean;

            if (mRow[mValueField] is int)
              mRow[mValueField] = Null.NullInteger;

            mRow[mDisplayField] = sSelectedValue;
            ((DataTable)mDataSource).Rows.InsertAt(mRow, 0);
            ((DataTable)mDataSource).AcceptChanges();
            ((LookUpEdit)objList).Properties.NullText = String.Empty;
          }
        }
          ((LookUpEdit)objList).Properties.DataSource = mDataSource;
        ((LookUpEdit)objList).Properties.DisplayMember = mDisplayField;
        ((LookUpEdit)objList).Properties.ValueMember = mValueField;

        LookUpColumnInfoCollection coll = ((LookUpEdit)objList).Properties.Columns;
        foreach (string fieldDisplay in arrayDisplayField)
        {
          coll.Add(new LookUpColumnInfo(fieldDisplay, 0));
        }

          ((LookUpEdit)objList).Properties.BestFitMode = BestFitMode.BestFitResizePopup;
        ((LookUpEdit)objList).Properties.SearchMode = SearchMode.AutoComplete;
        ((LookUpEdit)objList).Properties.AutoSearchColumnIndex = 0;
      }
    }

    #endregion

    #region "DevExpress.XtraGrid Function"

    public static void Grid_SetReadOnly(GridControl grc)
    {
      foreach (GridView grv in grc.Views)
      {
        grv.OptionsBehavior.Editable = true;
        foreach (GridColumn col in grv.Columns)
        {
          col.OptionsColumn.AllowEdit = true;
          col.OptionsColumn.ReadOnly = true;
        }
      }
    }

    public static void Grid_PainEditColunm(GridControl grc)
    {
      foreach (GridView grv in grc.Views)
      {
        foreach (GridColumn col in grv.Columns)
        {
          if ((col.OptionsColumn.AllowEdit == true) && (col.OptionsColumn.ReadOnly == false) && (col.ColumnEditName != ""))
          {
          }
        }
      }
    }

    public static DataRow Grid_GetDataRowItemDecimal(GridView grvGridView)
    {
      return grvGridView.GetDataRow(grvGridView.FocusedRowHandle);
    }

    public static decimal Grid_GetDataRowItemDecimal(GridView grvGridView, string itemName)
    {
      decimal dRet = Null.NullDecimal;
      DataRow currentRow = grvGridView.GetDataRow(grvGridView.FocusedRowHandle);
      if (currentRow == null)
        return decimal.Zero;

      if (!decimal.TryParse(currentRow[itemName].ToString(), out dRet))
        dRet = Null.NullDecimal;

      return dRet;
    }

    public static decimal Grid_GetDataRowItemDecimal(GridView grvGridView, string itemName, ref string andItemName)
    {
      DataRow currentRow = grvGridView.GetDataRow(grvGridView.FocusedRowHandle);
      if (currentRow == null)
        return decimal.Zero;

      andItemName = currentRow[andItemName].ToString();
      return decimal.Parse(currentRow[itemName].ToString());
    }

    public static string Grid_GetDataRowITemString(GridView grvGridView, string itemName)
    {
      DataRow currentRow = grvGridView.GetDataRow(grvGridView.FocusedRowHandle);
      if (currentRow == null)
        return Convert.ToString(0);

      return currentRow[itemName].ToString();
    }

    public static int Grid_GetDataRowItemInteger(GridView grvGridView, string itemName)
    {
      DataRow currentRow = grvGridView.GetDataRow(grvGridView.FocusedRowHandle);
      if (currentRow == null)
        return 0;

      return int.Parse(currentRow[itemName].ToString());
    }

    public static void Grid_LoadData(GridView gridviewName, DataTable table)
    {
      int indexVal = -1;
      indexVal = gridviewName.GetFocusedDataSourceRowIndex();
      gridviewName.GridControl.DataSource = table;
      if (indexVal >= 0)
        gridviewName.GridControl.BindingContext[table].Position = indexVal;
    }

    public static void Grid_AddRow(GridView grv)
    {
      if (!(grv.DataSource is DataView))
        throw new Exception("Not support type data source");

      ((DataView)grv.DataSource).AddNew();
    }

    public static void Grid_DeleteSelectRows(GridView grv)
    {
      grv.DeleteSelectedRows();
    }

    public static DataTable Grid_GetChanges(GridView grv, DataRowState iRowChangeState)
    {
      if (grv.DataSource is DataView)
        return ((DataView)grv.DataSource).Table.GetChanges(iRowChangeState);

      if (grv.DataSource != null)
        throw new Exception("Not support type data source");

      return null;
    }

    public static DataTable Grid_GetDeletedRows(GridView grv)
    {
      return Grid_GetChanges(grv, DataRowState.Deleted);
    }

    public static DataTable Grid_GetUpdatedRows(GridView grv)
    {
      return Grid_GetChanges(grv, DataRowState.Modified);
    }

    public static DataTable Grid_GetAddedRows(GridView grv)
    {
      return Grid_GetChanges(grv, DataRowState.Added);
    }

    public static void Grid_AcceptChanges(GridView grv)
    {
      if (grv.DataSource is DataView)
        ((DataView)grv.DataSource).Table.AcceptChanges();
      else if (grv.DataSource != null)
        throw new Exception("Not support type data source");
    }

    public static void Grid_BindDataLookupEdit(RepositoryItemLookUpEdit objList, DataTable mDataSource, string mDisplayField, string mValueField, params object[] arrayDisplayField)
    {
      objList.Columns.Clear();
      objList.DataSource = mDataSource;
      objList.DisplayMember = mDisplayField;
      objList.ValueMember = mValueField;
      LookUpColumnInfoCollection coll = objList.Columns;
      foreach (string fieldDisplay in arrayDisplayField)
      {
        coll.Add(new LookUpColumnInfo(fieldDisplay, 0));
      }
      objList.BestFitMode = BestFitMode.BestFitResizePopup;
    }
    #endregion

    #region "Excel: Export Function"

    public static void SetLicenseSpreadsheet()
    {
      SpreadsheetInfo.SetLicense(Commons.Instance().getKeyValueByKeyName("LicenseSpreadsheet"));
    }

    public static void Export_GridViewToExcel(GridView gridviewName, string fileName)
    {
      g_GridviewExport = null;
      g_ExportExcelFilePath = "";
      using (SaveFileDialog SaveFile = new SaveFileDialog())
      {
        SaveFile.Filter = "Excel (*.xls)|*.xls";
        if (fileName == "")
          SaveFile.FileName = gridviewName.Name.Remove(0, 3) + "_" + Export_GetDefaultFileName();
        else
          SaveFile.FileName = fileName;

        if (SaveFile.ShowDialog() == DialogResult.OK)
        {
          g_ExportExcelFilePath = SaveFile.FileName;
          g_GridviewExport = gridviewName;
          frmProgress.Instance().Thread = new MethodInvoker(FormGlobals.ExportGridToExcel);
          frmProgress.Instance().Show_Progress("Exporting data...");
          frmProgress.Instance().SetFinishText("Exported data sucessfully!", 500);
          if (Message_Confirm("Exported successfully. Do you want to open the file?", false))
            Export_OpenExcelFile(SaveFile.FileName);
        }
      }
    }

    private static void ExportGridToExcel()
    {
      if (g_GridviewExport != null)
      {
        g_GridviewExport.OptionsPrint.PrintDetails = true;
        g_GridviewExport.OptionsPrint.ExpandAllDetails = true;
        g_GridviewExport.OptionsPrint.ExpandAllGroups = true;
        g_GridviewExport.OptionsPrint.AutoWidth = false;
        g_GridviewExport.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
        g_GridviewExport.AppearancePrint.HeaderPanel.TextOptions.VAlignment = VertAlignment.Center;
        g_GridviewExport.AppearancePrint.Row.Options.UseTextOptions = true;
        g_GridviewExport.AppearancePrint.Row.TextOptions.VAlignment = VertAlignment.Center;
        g_GridviewExport.ExportToXls(g_ExportExcelFilePath);
      }
    }

    public static void Export_TableToExcel(DataTable dataTable, string sheetName, string startPossison)
    {
      SetLicenseSpreadsheet();
      ExcelFile ef = new ExcelFile();
      ef.Worksheets.Add(sheetName).InsertDataTable(dataTable, new InsertDataTableOptions(startPossison) { ColumnHeaders = true });
      using (SaveFileDialog SaveFile = new SaveFileDialog())
      {
        SaveFile.Filter = "Excel (*.xls)|*.xls";
        if (SaveFile.ShowDialog() == DialogResult.OK)
          ef.Save(SaveFile.FileName);
      }
    }

    public static string Export_TableToExcel_ReturnFileName(DataTable dataTable, string sheetName, string startPossison, string fileName)
    {
      SetLicenseSpreadsheet();
      ExcelFile ef = new ExcelFile();
      ef.Worksheets.Add(sheetName).InsertDataTable(dataTable, new InsertDataTableOptions(startPossison) { ColumnHeaders = true });
      using (SaveFileDialog SaveFile = new SaveFileDialog())
      {
        SaveFile.Filter = "Excel (*.xls)|*.xls";
        if (SaveFile.ShowDialog() == DialogResult.OK)
        {
          SaveFile.FileName = fileName + "_" + Export_GetDefaultFileName();
          ef.Save(SaveFile.FileName);
          return SaveFile.FileName;
        }
      }
      return "";
    }

    public static void Export_TableToExcelTemplate(ExcelWorksheet worksheet, DataTable dataTable, string startPossison)
    {
      SetLicenseSpreadsheet();
      worksheet.InsertDataTable(dataTable, new InsertDataTableOptions(startPossison) { ColumnHeaders = true });
    }

    public static void Export_SaveExcelFile(ExcelFile ef, string fileName)
    {
      SetLicenseSpreadsheet();
      using (SaveFileDialog SaveFile = new SaveFileDialog())
      {
        SaveFile.Filter = "Excel (*.xls)|*.xls";
        if (fileName == "")
          SaveFile.FileName = fileName + "_" + Export_GetDefaultFileName();
        else
          SaveFile.FileName = fileName;

        if (SaveFile.ShowDialog() == DialogResult.OK)
          ef.Save(SaveFile.FileName);
      }
    }

    public static string Export_SaveExcelFile_ReturnFileName(ExcelFile ef, string fileName)
    {
      SetLicenseSpreadsheet();
      using (SaveFileDialog SaveFile = new SaveFileDialog())
      {
        SaveFile.Filter = "Excel (*.xls)|*.xls";
        if (fileName == "")
          SaveFile.FileName = Export_GetDefaultFileName();
        else
          SaveFile.FileName = fileName;

        if (SaveFile.ShowDialog() == DialogResult.OK)
        {
          fileName = SaveFile.FileName;
          ef.Save(SaveFile.FileName);
        }
      }
      return fileName;
    }

    public static string Export_GetDefaultFileName()
    {
      return DateTime.Now.ToString("ddMMyyyy_HHmmss");
    }

    public static ExcelFile Export_GetExcelTemplateFile(string fileTemplateName)
    {
      SetLicenseSpreadsheet();
      ExcelFile ef = new ExcelFile();
      Module myMod = Assembly.GetExecutingAssembly().GetModules()[0];
      string aPath = Path.GetFullPath(Path.GetDirectoryName(myMod.FullyQualifiedName)).Replace(@"bin\Debug", @"\") + Commons.Instance().getKeyValueByKeyName("URLFileTemplate") + fileTemplateName + ".xls";
      ef = ExcelFile.Load(aPath);
      return ef;
    }

    public static void Export_OpenExcelFile(string fileName)
    {
      try
      {
        System.Diagnostics.Process.Start(fileName);
      }
      catch
      {
        Console.WriteLine(fileName + " created in application folder.");
      }
    }

    public static void Export_OpenExcelTemplateFile(string sPathName)
    {
      Module myMod = Assembly.GetExecutingAssembly().GetModules()[0];
      string aPath = Path.GetFullPath(Path.GetDirectoryName(myMod.FullyQualifiedName)).Replace(@"bin\Debug", @"\") + @"\" + sPathName;
      try
      {
        if (Message_Confirm("Exported successfully. Do you want to open the file?", false))
          Export_OpenExcelFile(aPath);
      }
      catch
      {
        Console.WriteLine(aPath + " created in application folder.");
      }
    }

    public static void Export_CheckSheet(DataTable dt, string PathFile, string fileName)
    {
      SetLicenseSpreadsheet();

      ExcelFile ef = new ExcelFile();
      ef = ExcelFile.Load(PathFile);
      ExcelWorksheet ws = ef.Worksheets.ActiveWorksheet;
      if (fileName.IndexOf("AT") != -1 || fileName.IndexOf("AS") != -1 || fileName.IndexOf("AU") != -1
          || fileName.IndexOf("VH") != -1 || fileName.IndexOf("VJ") != -1 || fileName.IndexOf("VK") != -1)
      {
        ws.Cells["P1"].Value = dt.Rows[0]["A_IN_DATE"].ToString();
        ws.Cells["Y1"].Value = dt.Rows[0]["LOT_NO"].ToString();
        ws.Cells["AE1"].Value = dt.Rows[0]["SEQUENCE_NO"].ToString();
        ws.Cells["AY1"].Value = dt.Rows[0]["ENGINE_NO"].ToString();
        ws.Cells["Q2"].Value = dt.Rows[0]["BODY_NO"].ToString();
        ws.Cells["Y2"].Value = dt.Rows[0]["COLOR"].ToString();
        ws.Cells["AL2"].Value = dt.Rows[0]["VIN"].ToString();
      }
      else if (fileName.IndexOf("AL") != -1 || fileName.IndexOf("AZ") != -1 || fileName.IndexOf("BE") != -1
          || fileName.IndexOf("ZA") != -1 || fileName.IndexOf("ZB") != -1 || fileName.IndexOf("ZC") != -1
          || fileName.IndexOf("ZD") != -1 || fileName.IndexOf("HA") != -1 || fileName.IndexOf("HB") != -1
          || fileName.IndexOf("HC") != -1)
      {
        ws.Cells["P1"].Value = dt.Rows[0]["A_IN_DATE"].ToString();
        ws.Cells["Y1"].Value = dt.Rows[0]["LOT_NO"].ToString();
        ws.Cells["AE1"].Value = dt.Rows[0]["SEQUENCE_NO"].ToString();
        ws.Cells["AT1"].Value = dt.Rows[0]["ENGINE_NO"].ToString();
        ws.Cells["Q2"].Value = dt.Rows[0]["BODY_NO"].ToString();
        ws.Cells["Y2"].Value = dt.Rows[0]["COLOR"].ToString();
        ws.Cells["AI2"].Value = dt.Rows[0]["VIN"].ToString();
      }
      using (SaveFileDialog SaveFile = new SaveFileDialog())
      {
        SaveFile.Filter = "Excel (*.xlsx)|*.xlsx";
        string[] arr = fileName.Split('.');
        SaveFile.FileName = arr[0] + DateTime.Now.ToString("HHmmssyyyyMMd");
        if (SaveFile.ShowDialog() == DialogResult.OK)
        {
          ef.Save(SaveFile.FileName);
          if (Message_Confirm("Do you want to open the excel file?", false))
            System.Diagnostics.Process.Start(SaveFile.FileName);
        }
      }
    }

    #endregion

    #region "Excel: Import Template"

    public static string[] Import_LoadExceltoTable(string strFileName)
    {
      string[] strTables = new string[1];
      Catalog oCatlog = new Catalog();
      ADOX.Table oTable = new Table();
      ADODB.Connection oConn = new ADODB.Connection();
      oConn.Open("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";", "", "", 0);
      oCatlog.ActiveConnection = oConn;
      if (oCatlog.Tables.Count > 0)
      {
        int item = 0;
        foreach (ADOX.Table tab in oCatlog.Tables)
        {
          if (tab.Type == "TABLE")
          {
            strTables[item] = tab.Name;
            item++;
            return strTables;
          }
        }
      }
      return null;
    }

    public static DataTable Import_GetDataTableExcel(string strFileName, string Table)
    {
      System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";");
      conn.Open();
      System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [" + Table + "]", conn);
      DataSet ds = new DataSet();
      adapter.Fill(ds);
      return ds.Tables[0];
    }

    private static DataTable CreateDataTable(int rows, int columns)
    {
      DataTable skeleton = new DataTable();
      for (int i = 1; i <= rows - 1; i++)
      {
        skeleton.Rows.Add(new object[0]);
      }
      for (int x = 0; x <= columns - 1; x++)
      {
        skeleton.Columns.Add();
      }
      return skeleton;
    }

    public static void ImportExcel(string strFile, string sheetName, GridControl grc)
    {
      SetLicenseSpreadsheet();
      ExcelFile excel = new ExcelFile();

      if (strFile.ToUpper().EndsWith(".XLSX"))
        excel = ExcelFile.Load(strFile, LoadOptions.XlsxDefault);
      else
        excel = ExcelFile.Load(strFile, LoadOptions.XlsDefault);

      ExcelWorksheet worksheet = excel.Worksheets[sheetName];
      int rows_ = worksheet.Rows.Count;
      int columns_ = worksheet.Columns.Count;
      DataTable tb = CreateDataTable(rows_, columns_);

      for (int idxRow = 1; idxRow <= rows_ - 1; idxRow++)
      {
        for (int idxCol = 0; idxCol <= columns_ - 1; idxCol++)
        {
          tb.Rows[idxRow - 1][idxCol] = worksheet.Rows[idxRow].Cells[idxCol].Value;
        }
      }
      for (int i = 0; i <= tb.Columns.Count - 1; i++)
      {
        tb.Columns[i].ColumnName = worksheet.Rows[0].Cells[i].Value.ToString().Replace(" ", "");
      }
      grc.DataSource = tb;
    }

    public static DataTable ImportExcelToTable(int rows, int columns, string strFile, string sheetName)
    {
      SetLicenseSpreadsheet();
      ExcelFile excel = new ExcelFile();
      strFile = Application.StartupPath + @"\..\..\Template\Prototype\" + strFile;

      if (strFile.ToUpper().EndsWith(".XLSX"))
        excel = ExcelFile.Load(strFile, LoadOptions.XlsxDefault);
      else
        excel = ExcelFile.Load(strFile, LoadOptions.XlsDefault);

      ExcelWorksheet worksheet = excel.Worksheets[sheetName];
      DataTable tb = CreateDataTable(rows, columns);

      for (int idxRow = 1; idxRow <= rows - 1; idxRow++)
      {
        for (int idxCol = 0; idxCol <= columns - 1; idxCol++)
        {
          tb.Rows[idxRow - 1][idxCol] = worksheet.Rows[idxRow].Cells[idxCol].Value;
        }
      }
      for (int i = 0; i <= tb.Columns.Count - 1; i++)
      {
        tb.Columns[i].ColumnName = worksheet.Rows[0].Cells[i].Value.ToString().Replace(" ", "");
      }
      return tb;
    }

    public static DataTable LoadExcelXLSX(string file, string sheet, ref object obj)
    {
      const int MAX_ROW = 2000;
      SetLicenseSpreadsheet();
      ExcelFile excel = new ExcelFile();
      //excel.LoadXlsx(Application.StartupPath + @"\..\..\Template\Prototype\" + file, XlsxOptions.None);
      ExcelWorksheet worksheet = excel.Worksheets[sheet];
      DataTable tbl = Commons.CreateDataTable(Convert.ToInt16(obj), 0);

      for (int idxRow10 = 0; idxRow10 <= MAX_ROW - 1; idxRow10++)
      {
        DataRow row = tbl.NewRow();
        for (int idxCell = 0; idxCell <= tbl.Columns.Count - 1; idxCell++)
        {
          row[idxCell] = worksheet.Rows[idxRow10].Cells[idxCell].Value;
        }
        tbl.Rows.Add(row);
      }
      return tbl;
    }

    #endregion

    #region "Excel: Import"

    public static DataSet Import_CsvFile(DataSet i_dsImport, List<string> listFile, int[] i_columnsIndex, int[] i_fileInfo, int[] i_fieldRequire)
    {
      DataSet Import_CsvFile;
      try
      {
        SetLicenseSpreadsheet();
        DataSet m_dsImport = i_dsImport;
        ExcelFile excel = new ExcelFile();
        List<string> m_listFile = listFile;
        int[] m_columnsIndex = i_columnsIndex;
        int[] m_fieldRequire = i_fieldRequire;
        if (m_listFile.Count > 0)
        {
          for (int i = 0; i <= listFile.Count; i++)
          {
            if (listFile[i].EndsWith(".csv"))
            {
              excel = ExcelFile.Load(listFile[i].ToString(), LoadOptions.CsvDefault);
              foreach (ExcelWorksheet ws in excel.Worksheets)
              {
                if (ws.Rows.Count > 0)
                {
                  DataTable m_dtImport = m_dsImport.Tables[0];
                  for (int j = (int)i_fileInfo.GetValue(0); j <= ws.Rows.Count - 1; j++)
                  {
                    object[] arrRow = new object[(m_dtImport.Columns.Count - 1) + 1];
                    for (int k = 0; k <= m_dtImport.Columns.Count - 1; k++)
                    {
                      for (int x = 0; x <= m_fieldRequire.Count<int>() - 1; x++)
                      {
                        arrRow[k] = ws.Rows[j].Cells[(int)m_columnsIndex.GetValue(k)].Value;
                      }
                    }
                    m_dtImport.Rows.Add(arrRow);
                  }
                }
              }
            }
          }
        }
        Import_CsvFile = m_dsImport;
      }
      catch (Exception ex)
      {
        Message_Error(ex);
        return null;
      }
      return Import_CsvFile;
    }

    public static DataTable Import_Csv_File(DB_Import_Excel imp_Excels)
    {
      DataTable Import_Csv_File;
      try
      {
        SetLicenseSpreadsheet();
        ExcelFile excel = new ExcelFile();
        DataTable dt_Import = new DataTable();
        bool flag = false;
        if (imp_Excels.ImpExcels.Count > 0)
        {
          foreach (Import_Excel col in imp_Excels.ImpExcels)
          {
            dt_Import.Columns.Add(col.ColumnName);
          }
        }
        else
          return null;

        if (imp_Excels.FileExcelPath.ToUpper().EndsWith(".CSV"))
          excel = ExcelFile.Load(imp_Excels.FileExcelPath, LoadOptions.CsvDefault);
        else if (imp_Excels.FileExcelPath.ToUpper().EndsWith(".XLS"))
          excel = ExcelFile.Load(imp_Excels.FileExcelPath, LoadOptions.XlsDefault);
        else if (imp_Excels.FileExcelPath.ToUpper().EndsWith(".XLSX"))
          excel = ExcelFile.Load(imp_Excels.FileExcelPath, LoadOptions.XlsxDefault);
        else
        {
          Message_Information("Parameter File Not Found!");
          return null;
        }

        ExcelWorksheet ws = excel.Worksheets[0];
        if (ws.Rows.Count > 0)
        {
          DataTable m_dtImport = dt_Import;
          for (int j = imp_Excels.StartRow; j <= ws.Rows.Count - 1; j++)
          {
            DataRow arrRow = dt_Import.NewRow();
            foreach (Import_Excel col in imp_Excels.ImpExcels)
            {
              if (col.DataType == 0)
                arrRow[col.ColumnName] = ws.Rows[j].Cells[col.IndexColumn].Value;
              else if (col.DataType == 1)
              {
                try
                {
                  arrRow[col.ColumnName] = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                }
                catch
                {
                  arrRow[col.ColumnName] = string.Empty;
                }
              }
              else if (col.DataType == 2)
              {
                try
                {
                  arrRow[col.ColumnName] = string.Format("{0:HH:mm}", DateTime.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                }
                catch
                {
                  arrRow[col.ColumnName] = string.Empty;
                }
              }
              else if (col.DataType == 4)
              {
                try
                {
                  arrRow[col.ColumnName] = string.Format("{0:#,##0.00}", decimal.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                }
                catch
                {
                  arrRow[col.ColumnName] = string.Empty;
                }
              }
              else if (col.DataType == 5)
              {
                try
                {
                  arrRow[col.ColumnName] = string.Format("{0:#,###}", decimal.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                }
                catch
                {
                  arrRow[col.ColumnName] = string.Empty;
                }
              }
              if (col.isRequired & string.IsNullOrEmpty(Convert.ToString(arrRow[col.ColumnName])))
              {
                flag = true;
                break;
              }
            }
            if (!flag)
              m_dtImport.Rows.Add(arrRow);
          }
        }
        Import_Csv_File = dt_Import;
      }
      catch (Exception ex)
      {
        Message_Error(ex);
        return null;
      }
      return Import_Csv_File;
    }

    public static DataSet Import_ExcelFile(string fileTemplateName, List<ObjImportExcel> listData)
    {
      SetLicenseSpreadsheet();
      ExcelFile ef = new ExcelFile();
      if (fileTemplateName.ToUpper().EndsWith(".XLS"))
        ef = ExcelFile.Load(fileTemplateName, LoadOptions.XlsDefault);
      else
        ef = ExcelFile.Load(fileTemplateName, LoadOptions.XlsxDefault);

      DataSet ds = new DataSet();
      foreach (ObjImportExcel oImportExcel in listData)
      {
        DataTable dt = new DataTable();
        foreach (Import_Excel col in oImportExcel.DataTableImportExcel.ImpExcels)
        {
          dt.Columns.Add(col.ColumnName);
        }
        dt.TableName = oImportExcel.SheetName;

        foreach (ExcelWorksheet ws in ef.Worksheets)
        {
          if ((ws.Name.Trim().Replace(" ", string.Empty) == oImportExcel.SheetName.Trim().Replace(" ", string.Empty)) && (ws.Rows.Count > 0))
          {
            for (int j = oImportExcel.DataTableImportExcel.StartRow; j <= ws.Rows.Count - 1; j++)
            {
              DataRow arrRow = dt.NewRow();
              foreach (Import_Excel col in oImportExcel.DataTableImportExcel.ImpExcels)
              {
                if (col.IndexColumn >= 0)
                {
                  if (col.DataType == 0)
                    arrRow[col.ColumnName] = ws.Rows[j].Cells[col.IndexColumn].Value;
                  else if (col.DataType == 1)
                  {
                    try
                    {
                      arrRow[col.ColumnName] = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                    }
                    catch
                    {
                      arrRow[col.ColumnName] = string.Empty;
                    }
                  }
                  else if (col.DataType == 2)
                  {
                    try
                    {
                      arrRow[col.ColumnName] = string.Format("{0:HH:mm}", DateTime.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                    }
                    catch
                    {
                      arrRow[col.ColumnName] = string.Empty;
                    }
                  }
                  else if (col.DataType == 4)
                  {
                    try
                    {
                      arrRow[col.ColumnName] = string.Format("{0:#,##0.00}", decimal.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                    }
                    catch
                    {
                      arrRow[col.ColumnName] = string.Empty;
                    }
                  }
                  else if (col.DataType == 5)
                  {
                    try
                    {
                      arrRow[col.ColumnName] = string.Format("{0:#,###}", decimal.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                    }
                    catch
                    {
                      arrRow[col.ColumnName] = string.Empty;
                    }
                  }
                  if (col.isRequired & string.IsNullOrEmpty(Convert.ToString(arrRow[col.ColumnName])))
                    ds.Tables.Add(dt);
                }
              }
              dt.Rows.Add(arrRow);
            }
          }
        }
      }
      return ds;
    }

    public static DataSet Import_ExcelFile_Ignore_Sheetname(string fileTemplateName, List<ObjImportExcel> listData)
    {
      SetLicenseSpreadsheet();
      ExcelFile ef = new ExcelFile();
      if (fileTemplateName.ToUpper().EndsWith(".XLS"))
        ef = ExcelFile.Load(fileTemplateName, LoadOptions.XlsDefault);
      else
        ef = ExcelFile.Load(fileTemplateName, LoadOptions.XlsxDefault);

      DataSet ds = new DataSet();
      foreach (ObjImportExcel oImportExcel in listData)
      {
        DataTable dt = new DataTable();
        foreach (Import_Excel col in oImportExcel.DataTableImportExcel.ImpExcels)
        {
          dt.Columns.Add(col.ColumnName);
        }
        dt.TableName = oImportExcel.SheetName;
        ExcelWorksheet ws = ef.Worksheets[0];
        if (ws.Rows.Count > 0)
        {
          for (int j = oImportExcel.DataTableImportExcel.StartRow; j <= ws.Rows.Count - 1; j++)
          {
            DataRow arrRow = dt.NewRow();
            foreach (Import_Excel col in oImportExcel.DataTableImportExcel.ImpExcels)
            {
              if (col.IndexColumn >= 0)
              {
                if (col.DataType == 0)
                  arrRow[col.ColumnName] = ws.Rows[j].Cells[col.IndexColumn].Value;
                else if (col.DataType == 1)
                {
                  try
                  {
                    arrRow[col.ColumnName] = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                  }
                  catch
                  {
                    arrRow[col.ColumnName] = string.Empty;
                  }
                }
                else if (col.DataType == 2)
                {
                  try
                  {
                    arrRow[col.ColumnName] = string.Format("{0:HH:mm}", DateTime.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                  }
                  catch
                  {
                    arrRow[col.ColumnName] = string.Empty;
                  }
                }
                else if (col.DataType == 4)
                {
                  try
                  {
                    arrRow[col.ColumnName] = string.Format("{0:#,##0.00}", decimal.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                  }
                  catch
                  {
                    arrRow[col.ColumnName] = string.Empty;
                  }
                }
                else if (col.DataType == 5)
                {
                  try
                  {
                    arrRow[col.ColumnName] = string.Format("{0:#,###}", decimal.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                  }
                  catch
                  {
                    arrRow[col.ColumnName] = string.Empty;
                  }
                }
                if (col.isRequired & string.IsNullOrEmpty(Convert.ToString(arrRow[col.ColumnName])))
                  break;
              }
            }
            dt.Rows.Add(arrRow);
          }
        }
        ds.Tables.Add(dt);
      }
      return ds;
    }

    public static DataSet Import_ExcelFileByActiveSheet(string fileTemplateName, List<ObjImportExcel> listData)
    {
      SetLicenseSpreadsheet();
      ExcelFile ef = new ExcelFile();
      if (fileTemplateName.ToUpper().EndsWith(".XLS"))
        ef = ExcelFile.Load(fileTemplateName, LoadOptions.XlsDefault);
      else
        ef = ExcelFile.Load(fileTemplateName, LoadOptions.XlsxDefault);

      DataSet ds = new DataSet();
      foreach (ObjImportExcel oImportExcel in listData)
      {
        DataTable dt = new DataTable();
        foreach (Import_Excel col in oImportExcel.DataTableImportExcel.ImpExcels)
        {
          dt.Columns.Add(col.ColumnName);
        }
        dt.TableName = oImportExcel.SheetName;

        foreach (ExcelWorksheet ws in ef.Worksheets)
        {
          if ((ef.Worksheets.ActiveWorksheet.Name == ws.Name) && (ws.Rows.Count > 0))
          {
            for (int j = oImportExcel.DataTableImportExcel.StartRow; j <= ws.Rows.Count - 1; j++)
            {
              DataRow arrRow = dt.NewRow();
              foreach (Import_Excel col in oImportExcel.DataTableImportExcel.ImpExcels)
              {
                if (col.IndexColumn >= 0)
                {
                  if (col.DataType == 0)
                    arrRow[col.ColumnName] = ws.Rows[j].Cells[col.IndexColumn].Value;
                  else if (col.DataType == 1)
                  {
                    try
                    {
                      arrRow[col.ColumnName] = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                    }
                    catch
                    {
                      arrRow[col.ColumnName] = string.Empty;
                    }
                  }
                  else if (col.DataType == 2)
                  {
                    try
                    {
                      arrRow[col.ColumnName] = string.Format("{0:HH:mm}", DateTime.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                    }
                    catch
                    {
                      arrRow[col.ColumnName] = string.Empty;
                    }
                  }
                  else if (col.DataType == 4)
                  {
                    try
                    {
                      arrRow[col.ColumnName] = string.Format("{0:#,##0.00}", decimal.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                    }
                    catch
                    {
                      arrRow[col.ColumnName] = string.Empty;
                    }
                  }
                  else if (col.DataType == 5)
                  {
                    try
                    {
                      arrRow[col.ColumnName] = string.Format("{0:#,###}", decimal.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                    }
                    catch
                    {
                      arrRow[col.ColumnName] = string.Empty;
                    }
                  }
                  if (col.isRequired & string.IsNullOrEmpty(Convert.ToString(arrRow[col.ColumnName])))
                    ds.Tables.Add(dt);
                }
              }
              dt.Rows.Add(arrRow);
            }
          }
        }
      }
      return ds;
    }

    public static DataSet Import_ExcelFileByActiveSheet_Ignore_Sheetname(string fileTemplateName, List<ObjImportExcel> listData)
    {
      SetLicenseSpreadsheet();
      ExcelFile ef = new ExcelFile();
      if (fileTemplateName.ToUpper().EndsWith(".XLS"))
        ef = ExcelFile.Load(fileTemplateName, LoadOptions.XlsDefault);
      else
        ef = ExcelFile.Load(fileTemplateName, LoadOptions.XlsxDefault);

      DataSet ds = new DataSet();
      foreach (ObjImportExcel oImportExcel in listData)
      {
        DataTable dt = new DataTable();
        foreach (Import_Excel col in oImportExcel.DataTableImportExcel.ImpExcels)
        {
          dt.Columns.Add(col.ColumnName);
        }
        dt.TableName = oImportExcel.SheetName;
        ExcelWorksheet ws = ef.Worksheets[0];
        if (ws.Rows.Count > 0)
        {
          for (int j = oImportExcel.DataTableImportExcel.StartRow; j <= ws.Rows.Count - 1; j++)
          {
            DataRow arrRow = dt.NewRow();
            foreach (Import_Excel col in oImportExcel.DataTableImportExcel.ImpExcels)
            {
              if (col.IndexColumn >= 0)
              {
                if (col.DataType == 0)
                  arrRow[col.ColumnName] = ws.Rows[j].Cells[col.IndexColumn].Value;
                else if (col.DataType == 1)
                {
                  try
                  {
                    arrRow[col.ColumnName] = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                  }
                  catch
                  {
                    arrRow[col.ColumnName] = string.Empty;
                  }
                }
                else if (col.DataType == 2)
                {
                  try
                  {
                    arrRow[col.ColumnName] = string.Format("{0:HH:mm}", DateTime.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                  }
                  catch
                  {
                    arrRow[col.ColumnName] = string.Empty;
                  }
                }
                else if (col.DataType == 4)
                {
                  try
                  {
                    arrRow[col.ColumnName] = string.Format("{0:#,##0.00}", decimal.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                  }
                  catch
                  {
                    arrRow[col.ColumnName] = string.Empty;
                  }
                }
                else if (col.DataType == 5)
                {
                  try
                  {
                    arrRow[col.ColumnName] = string.Format("{0:#,###}", decimal.Parse(ws.Rows[j].Cells[col.IndexColumn].Value.ToString()));
                  }
                  catch
                  {
                    arrRow[col.ColumnName] = string.Empty;
                  }
                }
                if (col.isRequired & string.IsNullOrEmpty(Convert.ToString(arrRow[col.ColumnName])))
                  break;
              }
            }
            dt.Rows.Add(arrRow);
          }
        }
        ds.Tables.Add(dt);
      }
      return ds;
    }

    #endregion

    #endregion
  }
}