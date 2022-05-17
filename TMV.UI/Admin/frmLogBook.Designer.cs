
namespace TMV.UI.Admin
{
  partial class frmLogBook
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogBook));
      this.RepositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.RepositoryItemRadioGroup2 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
      this.RepositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.GroupControl1 = new DevExpress.XtraEditors.GroupControl();
      this.grcLogBook = new DevExpress.XtraGrid.GridControl();
      this.grvLogBook = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.LOG_ID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.COMPUTER_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
      this.WINDOWS_USER = new DevExpress.XtraGrid.Columns.GridColumn();
      this.LOG_ACTION_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
      this.LOG_DESCRIPTION = new DevExpress.XtraGrid.Columns.GridColumn();
      this.USER_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
      this.LOG_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
      this.grpFilterImporter = new DevExpress.XtraEditors.GroupControl();
      this.dteTo = new DevExpress.XtraEditors.DateEdit();
      this.LabelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.dteFrom = new DevExpress.XtraEditors.DateEdit();
      this.lblPackingDate = new DevExpress.XtraEditors.LabelControl();
      this.cboAction = new DevExpress.XtraEditors.LookUpEdit();
      this.LabelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.cboUserID = new DevExpress.XtraEditors.LookUpEdit();
      this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
      this.imgList = new System.Windows.Forms.ImageList(this.components);
      this.LabelControl8 = new DevExpress.XtraEditors.LabelControl();
      this.btnExportGridToExcel = new DevExpress.XtraEditors.SimpleButton();
      this.PanelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.navControls = new DevExpress.XtraEditors.ControlNavigator();
      this.btnClose = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemRadioGroup2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).BeginInit();
      this.GroupControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grcLogBook)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grvLogBook)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grpFilterImporter)).BeginInit();
      this.grpFilterImporter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dteTo.Properties.CalendarTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteTo.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteFrom.Properties.CalendarTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteFrom.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboAction.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboUserID.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PanelControl2)).BeginInit();
      this.PanelControl2.SuspendLayout();
      this.SuspendLayout();
      // 
      // RepositoryItemCheckEdit2
      // 
      this.RepositoryItemCheckEdit2.AccessibleName = "USED";
      this.RepositoryItemCheckEdit2.AutoHeight = false;
      this.RepositoryItemCheckEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
      this.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2";
      this.RepositoryItemCheckEdit2.Tag = 1;
      this.RepositoryItemCheckEdit2.ValueChecked = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.RepositoryItemCheckEdit2.ValueUnchecked = new decimal(new int[] {
            0,
            0,
            0,
            0});
      // 
      // RepositoryItemRadioGroup2
      // 
      this.RepositoryItemRadioGroup2.Name = "RepositoryItemRadioGroup2";
      // 
      // RepositoryItemCheckEdit1
      // 
      this.RepositoryItemCheckEdit1.AutoHeight = false;
      this.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1";
      // 
      // GroupControl1
      // 
      this.GroupControl1.Controls.Add(this.grcLogBook);
      this.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GroupControl1.Location = new System.Drawing.Point(0, 114);
      this.GroupControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.GroupControl1.Name = "GroupControl1";
      this.GroupControl1.Size = new System.Drawing.Size(1266, 639);
      this.GroupControl1.TabIndex = 7;
      this.GroupControl1.Text = "Log Book";
      // 
      // grcLogBook
      // 
      this.grcLogBook.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grcLogBook.Location = new System.Drawing.Point(2, 34);
      this.grcLogBook.MainView = this.grvLogBook;
      this.grcLogBook.Name = "grcLogBook";
      this.grcLogBook.Size = new System.Drawing.Size(1262, 603);
      this.grcLogBook.TabIndex = 0;
      this.grcLogBook.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLogBook});
      // 
      // grvLogBook
      // 
      this.grvLogBook.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.LOG_ID,
            this.COMPUTER_NAME,
            this.WINDOWS_USER,
            this.LOG_ACTION_NAME,
            this.LOG_DESCRIPTION,
            this.USER_NAME,
            this.LOG_TIME});
      this.grvLogBook.GridControl = this.grcLogBook;
      this.grvLogBook.Name = "grvLogBook";
      this.grvLogBook.OptionsBehavior.Editable = false;
      this.grvLogBook.OptionsSelection.MultiSelect = true;
      this.grvLogBook.OptionsView.EnableAppearanceEvenRow = true;
      this.grvLogBook.OptionsView.EnableAppearanceOddRow = true;
      this.grvLogBook.OptionsView.ShowGroupPanel = false;
      // 
      // LOG_ID
      // 
      this.LOG_ID.Caption = "Log ID";
      this.LOG_ID.FieldName = "LOG_ID";
      this.LOG_ID.MinWidth = 30;
      this.LOG_ID.Name = "LOG_ID";
      this.LOG_ID.Width = 112;
      // 
      // COMPUTER_NAME
      // 
      this.COMPUTER_NAME.Caption = "Computer Name";
      this.COMPUTER_NAME.FieldName = "COMPUTER_NAME";
      this.COMPUTER_NAME.MinWidth = 30;
      this.COMPUTER_NAME.Name = "COMPUTER_NAME";
      this.COMPUTER_NAME.Visible = true;
      this.COMPUTER_NAME.VisibleIndex = 0;
      this.COMPUTER_NAME.Width = 112;
      // 
      // WINDOWS_USER
      // 
      this.WINDOWS_USER.Caption = "Windows User";
      this.WINDOWS_USER.FieldName = "WINDOWS_USER";
      this.WINDOWS_USER.MinWidth = 30;
      this.WINDOWS_USER.Name = "WINDOWS_USER";
      this.WINDOWS_USER.Visible = true;
      this.WINDOWS_USER.VisibleIndex = 1;
      this.WINDOWS_USER.Width = 112;
      // 
      // LOG_ACTION_NAME
      // 
      this.LOG_ACTION_NAME.Caption = "User Action";
      this.LOG_ACTION_NAME.FieldName = "LOG_ACTION_NAME";
      this.LOG_ACTION_NAME.MinWidth = 30;
      this.LOG_ACTION_NAME.Name = "LOG_ACTION_NAME";
      this.LOG_ACTION_NAME.Visible = true;
      this.LOG_ACTION_NAME.VisibleIndex = 2;
      this.LOG_ACTION_NAME.Width = 112;
      // 
      // LOG_DESCRIPTION
      // 
      this.LOG_DESCRIPTION.Caption = "Description";
      this.LOG_DESCRIPTION.FieldName = "LOG_DESCRIPTION";
      this.LOG_DESCRIPTION.MinWidth = 30;
      this.LOG_DESCRIPTION.Name = "LOG_DESCRIPTION";
      this.LOG_DESCRIPTION.Visible = true;
      this.LOG_DESCRIPTION.VisibleIndex = 3;
      this.LOG_DESCRIPTION.Width = 112;
      // 
      // USER_NAME
      // 
      this.USER_NAME.Caption = "Application User";
      this.USER_NAME.FieldName = "USER_NAME";
      this.USER_NAME.MinWidth = 30;
      this.USER_NAME.Name = "USER_NAME";
      this.USER_NAME.Visible = true;
      this.USER_NAME.VisibleIndex = 4;
      this.USER_NAME.Width = 112;
      // 
      // LOG_TIME
      // 
      this.LOG_TIME.Caption = "Log Time";
      this.LOG_TIME.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
      this.LOG_TIME.FieldName = "LOG_TIME";
      this.LOG_TIME.MinWidth = 30;
      this.LOG_TIME.Name = "LOG_TIME";
      this.LOG_TIME.Visible = true;
      this.LOG_TIME.VisibleIndex = 5;
      this.LOG_TIME.Width = 112;
      // 
      // grpFilterImporter
      // 
      this.grpFilterImporter.Controls.Add(this.dteTo);
      this.grpFilterImporter.Controls.Add(this.LabelControl2);
      this.grpFilterImporter.Controls.Add(this.dteFrom);
      this.grpFilterImporter.Controls.Add(this.lblPackingDate);
      this.grpFilterImporter.Controls.Add(this.cboAction);
      this.grpFilterImporter.Controls.Add(this.LabelControl1);
      this.grpFilterImporter.Controls.Add(this.cboUserID);
      this.grpFilterImporter.Controls.Add(this.btnSearch);
      this.grpFilterImporter.Controls.Add(this.LabelControl8);
      this.grpFilterImporter.Dock = System.Windows.Forms.DockStyle.Top;
      this.grpFilterImporter.Location = new System.Drawing.Point(0, 0);
      this.grpFilterImporter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.grpFilterImporter.Name = "grpFilterImporter";
      this.grpFilterImporter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.grpFilterImporter.Size = new System.Drawing.Size(1266, 114);
      this.grpFilterImporter.TabIndex = 5;
      this.grpFilterImporter.Text = "Log Book Filter Options";
      // 
      // dteTo
      // 
      this.dteTo.EditValue = null;
      this.dteTo.Location = new System.Drawing.Point(897, 55);
      this.dteTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.dteTo.Name = "dteTo";
      this.dteTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.dteTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.dteTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
      this.dteTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.dteTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
      this.dteTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.dteTo.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
      this.dteTo.Size = new System.Drawing.Size(134, 26);
      this.dteTo.TabIndex = 7;
      // 
      // LabelControl2
      // 
      this.LabelControl2.Location = new System.Drawing.Point(828, 57);
      this.LabelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl2.Name = "LabelControl2";
      this.LabelControl2.Size = new System.Drawing.Size(56, 19);
      this.LabelControl2.TabIndex = 6;
      this.LabelControl2.Text = "To Date";
      // 
      // dteFrom
      // 
      this.dteFrom.EditValue = null;
      this.dteFrom.Location = new System.Drawing.Point(676, 55);
      this.dteFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.dteFrom.Name = "dteFrom";
      this.dteFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.dteFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.dteFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
      this.dteFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.dteFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
      this.dteFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.dteFrom.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
      this.dteFrom.Size = new System.Drawing.Size(134, 26);
      this.dteFrom.TabIndex = 5;
      // 
      // lblPackingDate
      // 
      this.lblPackingDate.Location = new System.Drawing.Point(560, 57);
      this.lblPackingDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lblPackingDate.Name = "lblPackingDate";
      this.lblPackingDate.Size = new System.Drawing.Size(105, 19);
      this.lblPackingDate.TabIndex = 4;
      this.lblPackingDate.Text = "Log From Date";
      // 
      // cboAction
      // 
      this.cboAction.Location = new System.Drawing.Point(374, 55);
      this.cboAction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.cboAction.Name = "cboAction";
      this.cboAction.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cboAction.Size = new System.Drawing.Size(162, 26);
      this.cboAction.TabIndex = 3;
      // 
      // LabelControl1
      // 
      this.LabelControl1.Location = new System.Drawing.Point(309, 57);
      this.LabelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl1.Name = "LabelControl1";
      this.LabelControl1.Size = new System.Drawing.Size(52, 19);
      this.LabelControl1.TabIndex = 2;
      this.LabelControl1.Text = "Actions";
      // 
      // cboUserID
      // 
      this.cboUserID.Location = new System.Drawing.Point(116, 55);
      this.cboUserID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.cboUserID.Name = "cboUserID";
      this.cboUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cboUserID.Size = new System.Drawing.Size(170, 26);
      this.cboUserID.TabIndex = 1;
      // 
      // btnSearch
      // 
      this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSearch.ImageOptions.ImageIndex = 3;
      this.btnSearch.ImageOptions.ImageList = this.imgList;
      this.btnSearch.Location = new System.Drawing.Point(1114, 49);
      this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(138, 43);
      this.btnSearch.TabIndex = 8;
      this.btnSearch.Text = "&Search";
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // imgList
      // 
      this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
      this.imgList.TransparentColor = System.Drawing.Color.Transparent;
      this.imgList.Images.SetKeyName(0, "pcCloseButton.png");
      this.imgList.Images.SetKeyName(1, "BtnSave.png");
      this.imgList.Images.SetKeyName(2, "ButtonSaveAndClose.png");
      this.imgList.Images.SetKeyName(3, "find_selection.png");
      this.imgList.Images.SetKeyName(4, "Copy of save-32x32.png");
      this.imgList.Images.SetKeyName(5, "document_delete.png");
      this.imgList.Images.SetKeyName(6, "document_edit.png");
      this.imgList.Images.SetKeyName(7, "selection.png");
      this.imgList.Images.SetKeyName(8, "copy.png");
      this.imgList.Images.SetKeyName(9, "document_add.png");
      this.imgList.Images.SetKeyName(10, "export1.png");
      this.imgList.Images.SetKeyName(11, "cashier.png");
      this.imgList.Images.SetKeyName(12, "printer.png");
      this.imgList.Images.SetKeyName(13, "EDITITEM.GIF");
      this.imgList.Images.SetKeyName(14, "icon-excel-16x16.gif");
      this.imgList.Images.SetKeyName(15, "cubes_yellow.png");
      this.imgList.Images.SetKeyName(16, "cubes.png");
      this.imgList.Images.SetKeyName(17, "cubes_blue.png");
      this.imgList.Images.SetKeyName(18, "cubes_green.png");
      this.imgList.Images.SetKeyName(19, "cube_blue.png");
      this.imgList.Images.SetKeyName(20, "cube_green.png");
      this.imgList.Images.SetKeyName(21, "cube_yellow.png");
      // 
      // LabelControl8
      // 
      this.LabelControl8.Location = new System.Drawing.Point(24, 57);
      this.LabelControl8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl8.Name = "LabelControl8";
      this.LabelControl8.Size = new System.Drawing.Size(78, 19);
      this.LabelControl8.TabIndex = 0;
      this.LabelControl8.Text = "User Name";
      // 
      // btnExportGridToExcel
      // 
      this.btnExportGridToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnExportGridToExcel.ImageOptions.ImageIndex = 14;
      this.btnExportGridToExcel.ImageOptions.ImageList = this.imgList;
      this.btnExportGridToExcel.Location = new System.Drawing.Point(15, 11);
      this.btnExportGridToExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnExportGridToExcel.Name = "btnExportGridToExcel";
      this.btnExportGridToExcel.Size = new System.Drawing.Size(174, 43);
      this.btnExportGridToExcel.TabIndex = 0;
      this.btnExportGridToExcel.Text = "Export to Excel";
      this.btnExportGridToExcel.Click += new System.EventHandler(this.btnExportGridToExcel_Click);
      // 
      // PanelControl2
      // 
      this.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.PanelControl2.Controls.Add(this.navControls);
      this.PanelControl2.Controls.Add(this.btnExportGridToExcel);
      this.PanelControl2.Controls.Add(this.btnClose);
      this.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelControl2.Location = new System.Drawing.Point(0, 753);
      this.PanelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.PanelControl2.Name = "PanelControl2";
      this.PanelControl2.Size = new System.Drawing.Size(1266, 62);
      this.PanelControl2.TabIndex = 6;
      // 
      // navControls
      // 
      this.navControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.navControls.Buttons.Append.Visible = false;
      this.navControls.Buttons.CancelEdit.Visible = false;
      this.navControls.Buttons.Edit.Visible = false;
      this.navControls.Buttons.EndEdit.Visible = false;
      this.navControls.Buttons.Remove.Visible = false;
      this.navControls.Location = new System.Drawing.Point(789, 11);
      this.navControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.navControls.Name = "navControls";
      this.navControls.NavigatableControl = this.grcLogBook;
      this.navControls.Size = new System.Drawing.Size(316, 38);
      this.navControls.TabIndex = 3;
      this.navControls.Text = "ControlNavigator1";
      this.navControls.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.ImageOptions.ImageIndex = 0;
      this.btnClose.ImageOptions.ImageList = this.imgList;
      this.btnClose.Location = new System.Drawing.Point(1114, 9);
      this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(138, 43);
      this.btnClose.TabIndex = 1;
      this.btnClose.Text = "&Close";
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // frmLogBook
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1266, 815);
      this.Controls.Add(this.GroupControl1);
      this.Controls.Add(this.grpFilterImporter);
      this.Controls.Add(this.PanelControl2);
      this.Name = "frmLogBook";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "View Log Book";
      this.Load += new System.EventHandler(this.frmLogBook_Load);
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemRadioGroup2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).EndInit();
      this.GroupControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grcLogBook)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grvLogBook)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grpFilterImporter)).EndInit();
      this.grpFilterImporter.ResumeLayout(false);
      this.grpFilterImporter.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dteTo.Properties.CalendarTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteTo.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteFrom.Properties.CalendarTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteFrom.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboAction.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboUserID.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PanelControl2)).EndInit();
      this.PanelControl2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    internal DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit RepositoryItemCheckEdit2;
    internal DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup RepositoryItemRadioGroup2;
    internal DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit RepositoryItemCheckEdit1;
    internal DevExpress.XtraEditors.GroupControl GroupControl1;
    private DevExpress.XtraGrid.GridControl grcLogBook;
    private DevExpress.XtraGrid.Views.Grid.GridView grvLogBook;
    internal DevExpress.XtraEditors.GroupControl grpFilterImporter;
    internal DevExpress.XtraEditors.DateEdit dteTo;
    internal DevExpress.XtraEditors.LabelControl LabelControl2;
    internal DevExpress.XtraEditors.DateEdit dteFrom;
    internal DevExpress.XtraEditors.LabelControl lblPackingDate;
    internal DevExpress.XtraEditors.LookUpEdit cboAction;
    internal DevExpress.XtraEditors.LabelControl LabelControl1;
    internal DevExpress.XtraEditors.LookUpEdit cboUserID;
    internal DevExpress.XtraEditors.SimpleButton btnSearch;
    internal System.Windows.Forms.ImageList imgList;
    internal DevExpress.XtraEditors.LabelControl LabelControl8;
    internal DevExpress.XtraEditors.SimpleButton btnExportGridToExcel;
    internal DevExpress.XtraEditors.PanelControl PanelControl2;
    internal DevExpress.XtraEditors.ControlNavigator navControls;
    internal DevExpress.XtraEditors.SimpleButton btnClose;
    private DevExpress.XtraGrid.Columns.GridColumn LOG_ID;
    private DevExpress.XtraGrid.Columns.GridColumn COMPUTER_NAME;
    private DevExpress.XtraGrid.Columns.GridColumn WINDOWS_USER;
    private DevExpress.XtraGrid.Columns.GridColumn LOG_ACTION_NAME;
    private DevExpress.XtraGrid.Columns.GridColumn LOG_DESCRIPTION;
    private DevExpress.XtraGrid.Columns.GridColumn USER_NAME;
    private DevExpress.XtraGrid.Columns.GridColumn LOG_TIME;
  }
}