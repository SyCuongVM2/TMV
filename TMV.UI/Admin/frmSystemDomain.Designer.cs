
namespace TMV.UI.Admin
{
  partial class frmSystemDomain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemDomain));
      this.btnClear = new DevExpress.XtraEditors.SimpleButton();
      this.imgList = new System.Windows.Forms.ImageList(this.components);
      this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
      this.txtItemCode = new DevExpress.XtraEditors.TextEdit();
      this.lblItemValue = new DevExpress.XtraEditors.LabelControl();
      this.lblItemCode = new DevExpress.XtraEditors.LabelControl();
      this.lblDomainCoce = new DevExpress.XtraEditors.LabelControl();
      this.GroupControl2 = new DevExpress.XtraEditors.GroupControl();
      this.grcALCParam = new DevExpress.XtraGrid.GridControl();
      this.grvALCParam = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.DOMAIN_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
      this.ITEM_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
      this.ITEM_VALUE = new DevExpress.XtraGrid.Columns.GridColumn();
      this.DESCRIPTION = new DevExpress.XtraGrid.Columns.GridColumn();
      this.ITEM_ORDER = new DevExpress.XtraGrid.Columns.GridColumn();
      this.RepositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.btnAddAndCopy = new DevExpress.XtraEditors.SimpleButton();
      this.btnClose = new DevExpress.XtraEditors.SimpleButton();
      this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
      this.ControlNavigator1 = new DevExpress.XtraEditors.ControlNavigator();
      this.PanelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
      this.imglImporter = new System.Windows.Forms.ImageList(this.components);
      this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
      this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
      this.txtDomainCode = new DevExpress.XtraEditors.TextEdit();
      this.txtItemValue = new DevExpress.XtraEditors.TextEdit();
      this.grpSystemParameter = new DevExpress.XtraEditors.GroupControl();
      ((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.GroupControl2)).BeginInit();
      this.GroupControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grcALCParam)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grvALCParam)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PanelControl2)).BeginInit();
      this.PanelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtDomainCode.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtItemValue.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grpSystemParameter)).BeginInit();
      this.grpSystemParameter.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnClear
      // 
      this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClear.ImageOptions.ImageIndex = 7;
      this.btnClear.ImageOptions.ImageList = this.imgList;
      this.btnClear.Location = new System.Drawing.Point(1472, 43);
      this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(138, 43);
      this.btnClear.TabIndex = 7;
      this.btnClear.Text = "C&lear";
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
      // btnSearch
      // 
      this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSearch.ImageOptions.ImageIndex = 3;
      this.btnSearch.ImageOptions.ImageList = this.imgList;
      this.btnSearch.Location = new System.Drawing.Point(1324, 43);
      this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(138, 43);
      this.btnSearch.TabIndex = 6;
      this.btnSearch.Text = "&Search";
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // txtItemCode
      // 
      this.txtItemCode.Location = new System.Drawing.Point(522, 49);
      this.txtItemCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txtItemCode.Name = "txtItemCode";
      this.txtItemCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.txtItemCode.Size = new System.Drawing.Size(219, 26);
      this.txtItemCode.TabIndex = 3;
      // 
      // lblItemValue
      // 
      this.lblItemValue.Location = new System.Drawing.Point(770, 55);
      this.lblItemValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lblItemValue.Name = "lblItemValue";
      this.lblItemValue.Size = new System.Drawing.Size(77, 19);
      this.lblItemValue.TabIndex = 4;
      this.lblItemValue.Text = "Item Value";
      // 
      // lblItemCode
      // 
      this.lblItemCode.Location = new System.Drawing.Point(422, 55);
      this.lblItemCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lblItemCode.Name = "lblItemCode";
      this.lblItemCode.Size = new System.Drawing.Size(74, 19);
      this.lblItemCode.TabIndex = 2;
      this.lblItemCode.Text = "Item Code";
      // 
      // lblDomainCoce
      // 
      this.lblDomainCoce.Location = new System.Drawing.Point(20, 55);
      this.lblDomainCoce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lblDomainCoce.Name = "lblDomainCoce";
      this.lblDomainCoce.Size = new System.Drawing.Size(96, 19);
      this.lblDomainCoce.TabIndex = 0;
      this.lblDomainCoce.Text = "Domain Code";
      // 
      // GroupControl2
      // 
      this.GroupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GroupControl2.Controls.Add(this.grcALCParam);
      this.GroupControl2.Location = new System.Drawing.Point(0, 97);
      this.GroupControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.GroupControl2.Name = "GroupControl2";
      this.GroupControl2.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
      this.GroupControl2.ShowCaption = false;
      this.GroupControl2.Size = new System.Drawing.Size(1618, 631);
      this.GroupControl2.TabIndex = 30;
      this.GroupControl2.Text = "Importer Deatails";
      // 
      // grcALCParam
      // 
      this.grcALCParam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grcALCParam.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.grcALCParam.Location = new System.Drawing.Point(4, 14);
      this.grcALCParam.MainView = this.grvALCParam;
      this.grcALCParam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.grcALCParam.Name = "grcALCParam";
      this.grcALCParam.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemCheckEdit1});
      this.grcALCParam.Size = new System.Drawing.Size(1610, 611);
      this.grcALCParam.TabIndex = 1;
      this.grcALCParam.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvALCParam});
      // 
      // grvALCParam
      // 
      this.grvALCParam.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grvALCParam.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grvALCParam.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.ColumnFilterButton.Options.UseBackColor = true;
      this.grvALCParam.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
      this.grvALCParam.Appearance.ColumnFilterButton.Options.UseForeColor = true;
      this.grvALCParam.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
      this.grvALCParam.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
      this.grvALCParam.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
      this.grvALCParam.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
      this.grvALCParam.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
      this.grvALCParam.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grvALCParam.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
      this.grvALCParam.Appearance.Empty.Options.UseBackColor = true;
      this.grvALCParam.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
      this.grvALCParam.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
      this.grvALCParam.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.EvenRow.Options.UseBackColor = true;
      this.grvALCParam.Appearance.EvenRow.Options.UseBorderColor = true;
      this.grvALCParam.Appearance.EvenRow.Options.UseForeColor = true;
      this.grvALCParam.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
      this.grvALCParam.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
      this.grvALCParam.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.FilterCloseButton.Options.UseBackColor = true;
      this.grvALCParam.Appearance.FilterCloseButton.Options.UseBorderColor = true;
      this.grvALCParam.Appearance.FilterCloseButton.Options.UseForeColor = true;
      this.grvALCParam.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grvALCParam.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
      this.grvALCParam.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.FilterPanel.Options.UseBackColor = true;
      this.grvALCParam.Appearance.FilterPanel.Options.UseForeColor = true;
      this.grvALCParam.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
      this.grvALCParam.Appearance.FixedLine.Options.UseBackColor = true;
      this.grvALCParam.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
      this.grvALCParam.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.FocusedCell.Options.UseBackColor = true;
      this.grvALCParam.Appearance.FocusedCell.Options.UseForeColor = true;
      this.grvALCParam.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(157)))));
      this.grvALCParam.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
      this.grvALCParam.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.FocusedRow.Options.UseBackColor = true;
      this.grvALCParam.Appearance.FocusedRow.Options.UseBorderColor = true;
      this.grvALCParam.Appearance.FocusedRow.Options.UseForeColor = true;
      this.grvALCParam.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grvALCParam.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grvALCParam.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.FooterPanel.Options.UseBackColor = true;
      this.grvALCParam.Appearance.FooterPanel.Options.UseBorderColor = true;
      this.grvALCParam.Appearance.FooterPanel.Options.UseForeColor = true;
      this.grvALCParam.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
      this.grvALCParam.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
      this.grvALCParam.Appearance.GroupButton.Options.UseBackColor = true;
      this.grvALCParam.Appearance.GroupButton.Options.UseBorderColor = true;
      this.grvALCParam.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grvALCParam.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grvALCParam.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.GroupFooter.Options.UseBackColor = true;
      this.grvALCParam.Appearance.GroupFooter.Options.UseBorderColor = true;
      this.grvALCParam.Appearance.GroupFooter.Options.UseForeColor = true;
      this.grvALCParam.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
      this.grvALCParam.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
      this.grvALCParam.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.GroupPanel.Options.UseBackColor = true;
      this.grvALCParam.Appearance.GroupPanel.Options.UseForeColor = true;
      this.grvALCParam.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grvALCParam.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grvALCParam.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.GroupRow.Options.UseBackColor = true;
      this.grvALCParam.Appearance.GroupRow.Options.UseBorderColor = true;
      this.grvALCParam.Appearance.GroupRow.Options.UseForeColor = true;
      this.grvALCParam.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grvALCParam.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grvALCParam.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.HeaderPanel.Options.UseBackColor = true;
      this.grvALCParam.Appearance.HeaderPanel.Options.UseBorderColor = true;
      this.grvALCParam.Appearance.HeaderPanel.Options.UseForeColor = true;
      this.grvALCParam.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
      this.grvALCParam.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
      this.grvALCParam.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.HideSelectionRow.Options.UseBackColor = true;
      this.grvALCParam.Appearance.HideSelectionRow.Options.UseBorderColor = true;
      this.grvALCParam.Appearance.HideSelectionRow.Options.UseForeColor = true;
      this.grvALCParam.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grvALCParam.Appearance.HorzLine.Options.UseBackColor = true;
      this.grvALCParam.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
      this.grvALCParam.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
      this.grvALCParam.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.OddRow.Options.UseBackColor = true;
      this.grvALCParam.Appearance.OddRow.Options.UseBorderColor = true;
      this.grvALCParam.Appearance.OddRow.Options.UseForeColor = true;
      this.grvALCParam.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
      this.grvALCParam.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
      this.grvALCParam.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
      this.grvALCParam.Appearance.Preview.Options.UseBackColor = true;
      this.grvALCParam.Appearance.Preview.Options.UseFont = true;
      this.grvALCParam.Appearance.Preview.Options.UseForeColor = true;
      this.grvALCParam.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
      this.grvALCParam.Appearance.Row.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.Row.Options.UseBackColor = true;
      this.grvALCParam.Appearance.Row.Options.UseForeColor = true;
      this.grvALCParam.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grvALCParam.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
      this.grvALCParam.Appearance.RowSeparator.Options.UseBackColor = true;
      this.grvALCParam.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(188)))));
      this.grvALCParam.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
      this.grvALCParam.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
      this.grvALCParam.Appearance.SelectedRow.Options.UseBackColor = true;
      this.grvALCParam.Appearance.SelectedRow.Options.UseBorderColor = true;
      this.grvALCParam.Appearance.SelectedRow.Options.UseForeColor = true;
      this.grvALCParam.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
      this.grvALCParam.Appearance.TopNewRow.Options.UseBackColor = true;
      this.grvALCParam.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grvALCParam.Appearance.VertLine.Options.UseBackColor = true;
      this.grvALCParam.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DOMAIN_CODE,
            this.ITEM_CODE,
            this.ITEM_VALUE,
            this.DESCRIPTION,
            this.ITEM_ORDER});
      this.grvALCParam.DetailHeight = 538;
      this.grvALCParam.GridControl = this.grcALCParam;
      this.grvALCParam.GroupCount = 1;
      this.grvALCParam.Name = "grvALCParam";
      this.grvALCParam.OptionsPrint.PrintFilterInfo = true;
      this.grvALCParam.OptionsSelection.MultiSelect = true;
      this.grvALCParam.OptionsView.EnableAppearanceEvenRow = true;
      this.grvALCParam.OptionsView.EnableAppearanceOddRow = true;
      this.grvALCParam.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.DOMAIN_CODE, DevExpress.Data.ColumnSortOrder.Ascending)});
      // 
      // DOMAIN_CODE
      // 
      this.DOMAIN_CODE.Caption = "Domain Code";
      this.DOMAIN_CODE.FieldName = "DOMAIN_CODE";
      this.DOMAIN_CODE.MinWidth = 75;
      this.DOMAIN_CODE.Name = "DOMAIN_CODE";
      this.DOMAIN_CODE.OptionsColumn.ReadOnly = true;
      this.DOMAIN_CODE.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
      this.DOMAIN_CODE.Width = 150;
      // 
      // ITEM_CODE
      // 
      this.ITEM_CODE.Caption = "Item Code";
      this.ITEM_CODE.FieldName = "ITEM_CODE";
      this.ITEM_CODE.MinWidth = 30;
      this.ITEM_CODE.Name = "ITEM_CODE";
      this.ITEM_CODE.OptionsColumn.ReadOnly = true;
      this.ITEM_CODE.Visible = true;
      this.ITEM_CODE.VisibleIndex = 0;
      this.ITEM_CODE.Width = 225;
      // 
      // ITEM_VALUE
      // 
      this.ITEM_VALUE.Caption = "Item Value";
      this.ITEM_VALUE.FieldName = "ITEM_VALUE";
      this.ITEM_VALUE.MinWidth = 30;
      this.ITEM_VALUE.Name = "ITEM_VALUE";
      this.ITEM_VALUE.OptionsColumn.ReadOnly = true;
      this.ITEM_VALUE.Visible = true;
      this.ITEM_VALUE.VisibleIndex = 1;
      this.ITEM_VALUE.Width = 450;
      // 
      // DESCRIPTION
      // 
      this.DESCRIPTION.Caption = "Description";
      this.DESCRIPTION.FieldName = "DESCRIPTION";
      this.DESCRIPTION.MinWidth = 30;
      this.DESCRIPTION.Name = "DESCRIPTION";
      this.DESCRIPTION.OptionsColumn.ReadOnly = true;
      this.DESCRIPTION.Visible = true;
      this.DESCRIPTION.VisibleIndex = 2;
      this.DESCRIPTION.Width = 825;
      // 
      // ITEM_ORDER
      // 
      this.ITEM_ORDER.Caption = "Order";
      this.ITEM_ORDER.FieldName = "ITEM_ORDER";
      this.ITEM_ORDER.MinWidth = 30;
      this.ITEM_ORDER.Name = "ITEM_ORDER";
      this.ITEM_ORDER.OptionsColumn.ReadOnly = true;
      this.ITEM_ORDER.Visible = true;
      this.ITEM_ORDER.VisibleIndex = 3;
      this.ITEM_ORDER.Width = 78;
      // 
      // RepositoryItemCheckEdit1
      // 
      this.RepositoryItemCheckEdit1.AccessibleName = "XDOCK";
      this.RepositoryItemCheckEdit1.AutoHeight = false;
      this.RepositoryItemCheckEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
      this.RepositoryItemCheckEdit1.DisplayValueChecked = "checked";
      this.RepositoryItemCheckEdit1.DisplayValueUnchecked = "unchecked";
      this.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1";
      this.RepositoryItemCheckEdit1.Tag = 1;
      this.RepositoryItemCheckEdit1.ValueChecked = 1;
      this.RepositoryItemCheckEdit1.ValueUnchecked = 0;
      // 
      // btnAddAndCopy
      // 
      this.btnAddAndCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnAddAndCopy.ImageOptions.ImageIndex = 8;
      this.btnAddAndCopy.ImageOptions.ImageList = this.imgList;
      this.btnAddAndCopy.Location = new System.Drawing.Point(159, 9);
      this.btnAddAndCopy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnAddAndCopy.Name = "btnAddAndCopy";
      this.btnAddAndCopy.Size = new System.Drawing.Size(138, 43);
      this.btnAddAndCopy.TabIndex = 1;
      this.btnAddAndCopy.Text = "Add as &Copy";
      this.btnAddAndCopy.Click += new System.EventHandler(this.btnAddAndCopy_Click);
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.ImageOptions.ImageIndex = 0;
      this.btnClose.ImageOptions.ImageList = this.imgList;
      this.btnClose.Location = new System.Drawing.Point(1472, 9);
      this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(138, 43);
      this.btnClose.TabIndex = 4;
      this.btnClose.Text = "&Close";
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // btnExportExcel
      // 
      this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnExportExcel.ImageOptions.ImageIndex = 14;
      this.btnExportExcel.ImageOptions.ImageList = this.imgList;
      this.btnExportExcel.Location = new System.Drawing.Point(945, 9);
      this.btnExportExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnExportExcel.Name = "btnExportExcel";
      this.btnExportExcel.Size = new System.Drawing.Size(165, 43);
      this.btnExportExcel.TabIndex = 3;
      this.btnExportExcel.Text = "&Export To Excel";
      this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
      // 
      // ControlNavigator1
      // 
      this.ControlNavigator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ControlNavigator1.Buttons.Append.Visible = false;
      this.ControlNavigator1.Buttons.CancelEdit.Visible = false;
      this.ControlNavigator1.Buttons.Edit.Visible = false;
      this.ControlNavigator1.Buttons.EndEdit.Visible = false;
      this.ControlNavigator1.Buttons.Remove.Visible = false;
      this.ControlNavigator1.Location = new System.Drawing.Point(1136, 12);
      this.ControlNavigator1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ControlNavigator1.Name = "ControlNavigator1";
      this.ControlNavigator1.NavigatableControl = this.grcALCParam;
      this.ControlNavigator1.Size = new System.Drawing.Size(316, 38);
      this.ControlNavigator1.TabIndex = 5;
      this.ControlNavigator1.Text = "ControlNavigator1";
      this.ControlNavigator1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
      // 
      // PanelControl2
      // 
      this.PanelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.PanelControl2.Controls.Add(this.btnDelete);
      this.PanelControl2.Controls.Add(this.btnExportExcel);
      this.PanelControl2.Controls.Add(this.ControlNavigator1);
      this.PanelControl2.Controls.Add(this.btnEdit);
      this.PanelControl2.Controls.Add(this.btnAdd);
      this.PanelControl2.Controls.Add(this.btnAddAndCopy);
      this.PanelControl2.Controls.Add(this.btnClose);
      this.PanelControl2.Location = new System.Drawing.Point(0, 733);
      this.PanelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.PanelControl2.Name = "PanelControl2";
      this.PanelControl2.Size = new System.Drawing.Size(1618, 62);
      this.PanelControl2.TabIndex = 29;
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnDelete.ImageOptions.ImageIndex = 3;
      this.btnDelete.ImageOptions.ImageList = this.imglImporter;
      this.btnDelete.Location = new System.Drawing.Point(456, 9);
      this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(138, 43);
      this.btnDelete.TabIndex = 6;
      this.btnDelete.Text = "Delete";
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // imglImporter
      // 
      this.imglImporter.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglImporter.ImageStream")));
      this.imglImporter.TransparentColor = System.Drawing.Color.Transparent;
      this.imglImporter.Images.SetKeyName(0, "save-as-32x32.png");
      this.imglImporter.Images.SetKeyName(1, "close-32x32.png");
      this.imglImporter.Images.SetKeyName(2, "copy-32x32.png");
      this.imglImporter.Images.SetKeyName(3, "delete-32x32.png");
      this.imglImporter.Images.SetKeyName(4, "edit-32x32.png");
      this.imglImporter.Images.SetKeyName(5, "find-32x32.png");
      this.imglImporter.Images.SetKeyName(6, "open-32x32.png");
      this.imglImporter.Images.SetKeyName(7, "preview-32x32.png");
      this.imglImporter.Images.SetKeyName(8, "refresh-32x32.png");
      this.imglImporter.Images.SetKeyName(9, "save-32x32.png");
      this.imglImporter.Images.SetKeyName(10, "save-all-32x32.png");
      this.imglImporter.Images.SetKeyName(11, "save-and-close-32x32.png");
      // 
      // btnEdit
      // 
      this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnEdit.ImageOptions.ImageIndex = 6;
      this.btnEdit.ImageOptions.ImageList = this.imgList;
      this.btnEdit.Location = new System.Drawing.Point(309, 9);
      this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(138, 43);
      this.btnEdit.TabIndex = 2;
      this.btnEdit.Text = "&Update";
      this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnAdd.ImageOptions.ImageIndex = 9;
      this.btnAdd.ImageOptions.ImageList = this.imgList;
      this.btnAdd.Location = new System.Drawing.Point(9, 9);
      this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(138, 43);
      this.btnAdd.TabIndex = 0;
      this.btnAdd.Text = "&Add";
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // txtDomainCode
      // 
      this.txtDomainCode.Location = new System.Drawing.Point(135, 49);
      this.txtDomainCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txtDomainCode.Name = "txtDomainCode";
      this.txtDomainCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.txtDomainCode.Size = new System.Drawing.Size(248, 26);
      this.txtDomainCode.TabIndex = 1;
      // 
      // txtItemValue
      // 
      this.txtItemValue.Location = new System.Drawing.Point(867, 49);
      this.txtItemValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txtItemValue.Name = "txtItemValue";
      this.txtItemValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.txtItemValue.Size = new System.Drawing.Size(219, 26);
      this.txtItemValue.TabIndex = 5;
      // 
      // grpSystemParameter
      // 
      this.grpSystemParameter.Controls.Add(this.btnClear);
      this.grpSystemParameter.Controls.Add(this.btnSearch);
      this.grpSystemParameter.Controls.Add(this.txtItemValue);
      this.grpSystemParameter.Controls.Add(this.txtItemCode);
      this.grpSystemParameter.Controls.Add(this.lblItemValue);
      this.grpSystemParameter.Controls.Add(this.lblItemCode);
      this.grpSystemParameter.Controls.Add(this.lblDomainCoce);
      this.grpSystemParameter.Controls.Add(this.txtDomainCode);
      this.grpSystemParameter.Dock = System.Windows.Forms.DockStyle.Top;
      this.grpSystemParameter.Location = new System.Drawing.Point(0, 0);
      this.grpSystemParameter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.grpSystemParameter.Name = "grpSystemParameter";
      this.grpSystemParameter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.grpSystemParameter.Size = new System.Drawing.Size(1618, 98);
      this.grpSystemParameter.TabIndex = 28;
      this.grpSystemParameter.Text = "Filter Options";
      // 
      // frmSystemDomain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1618, 795);
      this.Controls.Add(this.GroupControl2);
      this.Controls.Add(this.PanelControl2);
      this.Controls.Add(this.grpSystemParameter);
      this.Name = "frmSystemDomain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "System Domain";
      this.Load += new System.EventHandler(this.frmSystemDomain_Load);
      ((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.GroupControl2)).EndInit();
      this.GroupControl2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grcALCParam)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grvALCParam)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEdit1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PanelControl2)).EndInit();
      this.PanelControl2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.txtDomainCode.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtItemValue.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grpSystemParameter)).EndInit();
      this.grpSystemParameter.ResumeLayout(false);
      this.grpSystemParameter.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    internal DevExpress.XtraEditors.SimpleButton btnClear;
    internal System.Windows.Forms.ImageList imgList;
    internal DevExpress.XtraEditors.SimpleButton btnSearch;
    internal DevExpress.XtraEditors.TextEdit txtItemCode;
    internal DevExpress.XtraEditors.LabelControl lblItemValue;
    internal DevExpress.XtraEditors.LabelControl lblItemCode;
    internal DevExpress.XtraEditors.LabelControl lblDomainCoce;
    internal DevExpress.XtraEditors.GroupControl GroupControl2;
    internal DevExpress.XtraGrid.GridControl grcALCParam;
    internal DevExpress.XtraGrid.Views.Grid.GridView grvALCParam;
    internal DevExpress.XtraGrid.Columns.GridColumn DOMAIN_CODE;
    internal DevExpress.XtraGrid.Columns.GridColumn ITEM_CODE;
    internal DevExpress.XtraGrid.Columns.GridColumn ITEM_VALUE;
    private DevExpress.XtraGrid.Columns.GridColumn DESCRIPTION;
    internal DevExpress.XtraGrid.Columns.GridColumn ITEM_ORDER;
    internal DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit RepositoryItemCheckEdit1;
    internal DevExpress.XtraEditors.SimpleButton btnAddAndCopy;
    internal DevExpress.XtraEditors.SimpleButton btnClose;
    internal DevExpress.XtraEditors.SimpleButton btnExportExcel;
    internal DevExpress.XtraEditors.ControlNavigator ControlNavigator1;
    internal DevExpress.XtraEditors.PanelControl PanelControl2;
    internal DevExpress.XtraEditors.SimpleButton btnDelete;
    internal System.Windows.Forms.ImageList imglImporter;
    internal DevExpress.XtraEditors.SimpleButton btnEdit;
    internal DevExpress.XtraEditors.SimpleButton btnAdd;
    internal DevExpress.XtraEditors.TextEdit txtDomainCode;
    internal DevExpress.XtraEditors.TextEdit txtItemValue;
    internal DevExpress.XtraEditors.GroupControl grpSystemParameter;
  }
}