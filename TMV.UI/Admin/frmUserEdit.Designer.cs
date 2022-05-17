
namespace TMV.UI.Admin
{
  partial class frmUserEdit
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserEdit));
      this.btnSave = new DevExpress.XtraEditors.SimpleButton();
      this.imglImporterEdit = new System.Windows.Forms.ImageList(this.components);
      this.LabelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.LabelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.spePASSWORDCHANGEAFTER = new DevExpress.XtraEditors.SpinEdit();
      this.LabelControl9 = new DevExpress.XtraEditors.LabelControl();
      this.dteCREATE_DATE = new DevExpress.XtraEditors.DateEdit();
      this.dteUPDATE_PASSWORD = new DevExpress.XtraEditors.DateEdit();
      this.LabelControl12 = new DevExpress.XtraEditors.LabelControl();
      this.btnClose = new DevExpress.XtraEditors.SimpleButton();
      this.LabelControl11 = new DevExpress.XtraEditors.LabelControl();
      this.LabelControl10 = new DevExpress.XtraEditors.LabelControl();
      this.dteExprired_Date = new DevExpress.XtraEditors.DateEdit();
      this.dteEffective_Date = new DevExpress.XtraEditors.DateEdit();
      this.LabelControl8 = new DevExpress.XtraEditors.LabelControl();
      this.btnClear = new DevExpress.XtraEditors.SimpleButton();
      this.speSendEmail = new DevExpress.XtraEditors.SpinEdit();
      this.LabelControl7 = new DevExpress.XtraEditors.LabelControl();
      this.LabelControl6 = new DevExpress.XtraEditors.LabelControl();
      this.speNOPASSWORDHISTORY = new DevExpress.XtraEditors.SpinEdit();
      this.speDisableAfterFailed = new DevExpress.XtraEditors.SpinEdit();
      this.LabelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.speIsNextLogon = new DevExpress.XtraEditors.CheckEdit();
      this.speIsLocked = new DevExpress.XtraEditors.CheckEdit();
      this.txtRetype = new DevExpress.XtraEditors.TextEdit();
      this.txtUser_Password = new DevExpress.XtraEditors.TextEdit();
      this.PanelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.LabelControl5 = new DevExpress.XtraEditors.LabelControl();
      this.LabelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.txtFull_Name = new DevExpress.XtraEditors.TextEdit();
      this.lblSeriesID = new DevExpress.XtraEditors.LabelControl();
      this.lblCarFamilyID = new DevExpress.XtraEditors.LabelControl();
      this.lblImporterSeriesName = new DevExpress.XtraEditors.LabelControl();
      this.lblImporter = new DevExpress.XtraEditors.LabelControl();
      this.grpUserInfo = new DevExpress.XtraEditors.GroupControl();
      this.txtUser_Name = new DevExpress.XtraEditors.TextEdit();
      this.imgList = new System.Windows.Forms.ImageList(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.spePASSWORDCHANGEAFTER.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteCREATE_DATE.Properties.CalendarTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteCREATE_DATE.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteUPDATE_PASSWORD.Properties.CalendarTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteUPDATE_PASSWORD.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteExprired_Date.Properties.CalendarTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteExprired_Date.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteEffective_Date.Properties.CalendarTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteEffective_Date.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.speSendEmail.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.speNOPASSWORDHISTORY.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.speDisableAfterFailed.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.speIsNextLogon.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.speIsLocked.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtRetype.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtUser_Password.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PanelControl1)).BeginInit();
      this.PanelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtFull_Name.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grpUserInfo)).BeginInit();
      this.grpUserInfo.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtUser_Name.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // btnSave
      // 
      this.btnSave.ImageOptions.ImageIndex = 3;
      this.btnSave.ImageOptions.ImageList = this.imglImporterEdit;
      this.btnSave.Location = new System.Drawing.Point(320, 8);
      this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(124, 45);
      this.btnSave.TabIndex = 15;
      this.btnSave.Text = "&Save";
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // imglImporterEdit
      // 
      this.imglImporterEdit.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglImporterEdit.ImageStream")));
      this.imglImporterEdit.TransparentColor = System.Drawing.Color.Transparent;
      this.imglImporterEdit.Images.SetKeyName(0, "Add.bmp");
      this.imglImporterEdit.Images.SetKeyName(1, "pcCloseButton.png");
      this.imglImporterEdit.Images.SetKeyName(2, "ButtonRefresh.png");
      this.imglImporterEdit.Images.SetKeyName(3, "ButtonSave.png");
      // 
      // LabelControl4
      // 
      this.LabelControl4.Location = new System.Drawing.Point(597, 197);
      this.LabelControl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl4.Name = "LabelControl4";
      this.LabelControl4.Size = new System.Drawing.Size(167, 19);
      this.LabelControl4.TabIndex = 66;
      this.LabelControl4.Text = "Password  Expried after";
      // 
      // LabelControl3
      // 
      this.LabelControl3.Location = new System.Drawing.Point(872, 195);
      this.LabelControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl3.Name = "LabelControl3";
      this.LabelControl3.Size = new System.Drawing.Size(96, 19);
      this.LabelControl3.TabIndex = 65;
      this.LabelControl3.Text = "days changed";
      // 
      // spePASSWORDCHANGEAFTER
      // 
      this.spePASSWORDCHANGEAFTER.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.spePASSWORDCHANGEAFTER.Location = new System.Drawing.Point(794, 191);
      this.spePASSWORDCHANGEAFTER.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.spePASSWORDCHANGEAFTER.Name = "spePASSWORDCHANGEAFTER";
      this.spePASSWORDCHANGEAFTER.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.spePASSWORDCHANGEAFTER.Size = new System.Drawing.Size(64, 28);
      this.spePASSWORDCHANGEAFTER.TabIndex = 10;
      // 
      // LabelControl9
      // 
      this.LabelControl9.Location = new System.Drawing.Point(673, 369);
      this.LabelControl9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl9.Name = "LabelControl9";
      this.LabelControl9.Size = new System.Drawing.Size(91, 19);
      this.LabelControl9.TabIndex = 63;
      this.LabelControl9.Text = "Created Date";
      // 
      // dteCREATE_DATE
      // 
      this.dteCREATE_DATE.EditValue = null;
      this.dteCREATE_DATE.Location = new System.Drawing.Point(794, 363);
      this.dteCREATE_DATE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.dteCREATE_DATE.Name = "dteCREATE_DATE";
      this.dteCREATE_DATE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.dteCREATE_DATE.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.dteCREATE_DATE.Size = new System.Drawing.Size(150, 26);
      this.dteCREATE_DATE.TabIndex = 14;
      // 
      // dteUPDATE_PASSWORD
      // 
      this.dteUPDATE_PASSWORD.EditValue = null;
      this.dteUPDATE_PASSWORD.Location = new System.Drawing.Point(794, 323);
      this.dteUPDATE_PASSWORD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.dteUPDATE_PASSWORD.Name = "dteUPDATE_PASSWORD";
      this.dteUPDATE_PASSWORD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.dteUPDATE_PASSWORD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.dteUPDATE_PASSWORD.Size = new System.Drawing.Size(150, 26);
      this.dteUPDATE_PASSWORD.TabIndex = 13;
      // 
      // LabelControl12
      // 
      this.LabelControl12.Location = new System.Drawing.Point(598, 328);
      this.LabelControl12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl12.Name = "LabelControl12";
      this.LabelControl12.Size = new System.Drawing.Size(166, 19);
      this.LabelControl12.TabIndex = 60;
      this.LabelControl12.Text = "Password updated Date";
      // 
      // btnClose
      // 
      this.btnClose.ImageOptions.ImageIndex = 1;
      this.btnClose.ImageOptions.ImageList = this.imglImporterEdit;
      this.btnClose.Location = new System.Drawing.Point(592, 8);
      this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(124, 45);
      this.btnClose.TabIndex = 17;
      this.btnClose.Text = "&Close";
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // LabelControl11
      // 
      this.LabelControl11.Location = new System.Drawing.Point(872, 149);
      this.LabelControl11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl11.Name = "LabelControl11";
      this.LabelControl11.Size = new System.Drawing.Size(32, 19);
      this.LabelControl11.TabIndex = 59;
      this.LabelControl11.Text = "days";
      // 
      // LabelControl10
      // 
      this.LabelControl10.Location = new System.Drawing.Point(509, 149);
      this.LabelControl10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl10.Name = "LabelControl10";
      this.LabelControl10.Size = new System.Drawing.Size(255, 19);
      this.LabelControl10.TabIndex = 57;
      this.LabelControl10.Text = " Warrning Password  Expried before";
      // 
      // dteExprired_Date
      // 
      this.dteExprired_Date.EditValue = null;
      this.dteExprired_Date.Location = new System.Drawing.Point(794, 283);
      this.dteExprired_Date.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.dteExprired_Date.Name = "dteExprired_Date";
      this.dteExprired_Date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.dteExprired_Date.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.dteExprired_Date.Size = new System.Drawing.Size(150, 26);
      this.dteExprired_Date.TabIndex = 12;
      // 
      // dteEffective_Date
      // 
      this.dteEffective_Date.EditValue = null;
      this.dteEffective_Date.Location = new System.Drawing.Point(794, 237);
      this.dteEffective_Date.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.dteEffective_Date.Name = "dteEffective_Date";
      this.dteEffective_Date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.dteEffective_Date.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.dteEffective_Date.Size = new System.Drawing.Size(150, 26);
      this.dteEffective_Date.TabIndex = 11;
      // 
      // LabelControl8
      // 
      this.LabelControl8.Location = new System.Drawing.Point(674, 288);
      this.LabelControl8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl8.Name = "LabelControl8";
      this.LabelControl8.Size = new System.Drawing.Size(90, 19);
      this.LabelControl8.TabIndex = 54;
      this.LabelControl8.Text = "Expired Date";
      // 
      // btnClear
      // 
      this.btnClear.ImageOptions.ImageIndex = 2;
      this.btnClear.ImageOptions.ImageList = this.imglImporterEdit;
      this.btnClear.Location = new System.Drawing.Point(456, 8);
      this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(124, 45);
      this.btnClear.TabIndex = 16;
      this.btnClear.Text = "C&lear";
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // speSendEmail
      // 
      this.speSendEmail.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.speSendEmail.Location = new System.Drawing.Point(794, 145);
      this.speSendEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.speSendEmail.Name = "speSendEmail";
      this.speSendEmail.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.speSendEmail.Size = new System.Drawing.Size(64, 28);
      this.speSendEmail.TabIndex = 9;
      // 
      // LabelControl7
      // 
      this.LabelControl7.Location = new System.Drawing.Point(668, 242);
      this.LabelControl7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl7.Name = "LabelControl7";
      this.LabelControl7.Size = new System.Drawing.Size(96, 19);
      this.LabelControl7.TabIndex = 53;
      this.LabelControl7.Text = "Effective Date";
      // 
      // LabelControl6
      // 
      this.LabelControl6.Location = new System.Drawing.Point(872, 98);
      this.LabelControl6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl6.Name = "LabelControl6";
      this.LabelControl6.Size = new System.Drawing.Size(193, 19);
      this.LabelControl6.TabIndex = 52;
      this.LabelControl6.Text = "passwords had used before";
      // 
      // speNOPASSWORDHISTORY
      // 
      this.speNOPASSWORDHISTORY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.speNOPASSWORDHISTORY.Location = new System.Drawing.Point(794, 95);
      this.speNOPASSWORDHISTORY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.speNOPASSWORDHISTORY.Name = "speNOPASSWORDHISTORY";
      this.speNOPASSWORDHISTORY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.speNOPASSWORDHISTORY.Size = new System.Drawing.Size(64, 28);
      this.speNOPASSWORDHISTORY.TabIndex = 8;
      // 
      // speDisableAfterFailed
      // 
      this.speDisableAfterFailed.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.speDisableAfterFailed.Location = new System.Drawing.Point(794, 46);
      this.speDisableAfterFailed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.speDisableAfterFailed.Name = "speDisableAfterFailed";
      this.speDisableAfterFailed.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.speDisableAfterFailed.Size = new System.Drawing.Size(64, 28);
      this.speDisableAfterFailed.TabIndex = 7;
      // 
      // LabelControl1
      // 
      this.LabelControl1.Location = new System.Drawing.Point(564, 54);
      this.LabelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl1.Name = "LabelControl1";
      this.LabelControl1.Size = new System.Drawing.Size(200, 19);
      this.LabelControl1.TabIndex = 47;
      this.LabelControl1.Text = "UserID will be disabled after";
      // 
      // speIsNextLogon
      // 
      this.speIsNextLogon.Location = new System.Drawing.Point(148, 228);
      this.speIsNextLogon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.speIsNextLogon.Name = "speIsNextLogon";
      this.speIsNextLogon.Properties.Caption = "User must change password at next logon";
      this.speIsNextLogon.Size = new System.Drawing.Size(342, 27);
      this.speIsNextLogon.TabIndex = 5;
      // 
      // speIsLocked
      // 
      this.speIsLocked.Location = new System.Drawing.Point(148, 266);
      this.speIsLocked.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.speIsLocked.Name = "speIsLocked";
      this.speIsLocked.Properties.Caption = "Account is disabled";
      this.speIsLocked.Size = new System.Drawing.Size(214, 27);
      this.speIsLocked.TabIndex = 6;
      // 
      // txtRetype
      // 
      this.txtRetype.Location = new System.Drawing.Point(152, 186);
      this.txtRetype.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txtRetype.Name = "txtRetype";
      this.txtRetype.Properties.PasswordChar = '*';
      this.txtRetype.Size = new System.Drawing.Size(322, 26);
      this.txtRetype.TabIndex = 4;
      // 
      // txtUser_Password
      // 
      this.txtUser_Password.Location = new System.Drawing.Point(152, 143);
      this.txtUser_Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txtUser_Password.Name = "txtUser_Password";
      this.txtUser_Password.Properties.PasswordChar = '*';
      this.txtUser_Password.Size = new System.Drawing.Size(322, 26);
      this.txtUser_Password.TabIndex = 3;
      // 
      // PanelControl1
      // 
      this.PanelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.PanelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
      this.PanelControl1.Appearance.Options.UseForeColor = true;
      this.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.PanelControl1.Controls.Add(this.btnClose);
      this.PanelControl1.Controls.Add(this.btnClear);
      this.PanelControl1.Controls.Add(this.btnSave);
      this.PanelControl1.Location = new System.Drawing.Point(0, 434);
      this.PanelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.PanelControl1.Name = "PanelControl1";
      this.PanelControl1.Size = new System.Drawing.Size(1113, 58);
      this.PanelControl1.TabIndex = 5;
      // 
      // LabelControl5
      // 
      this.LabelControl5.Location = new System.Drawing.Point(524, 102);
      this.LabelControl5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl5.Name = "LabelControl5";
      this.LabelControl5.Size = new System.Drawing.Size(240, 19);
      this.LabelControl5.TabIndex = 50;
      this.LabelControl5.Text = "Cannot repeat any of the previous";
      // 
      // LabelControl2
      // 
      this.LabelControl2.Location = new System.Drawing.Point(872, 51);
      this.LabelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.LabelControl2.Name = "LabelControl2";
      this.LabelControl2.Size = new System.Drawing.Size(164, 19);
      this.LabelControl2.TabIndex = 49;
      this.LabelControl2.Text = "consecutive failed login";
      // 
      // txtFull_Name
      // 
      this.txtFull_Name.Location = new System.Drawing.Point(152, 52);
      this.txtFull_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txtFull_Name.Name = "txtFull_Name";
      this.txtFull_Name.Size = new System.Drawing.Size(322, 26);
      this.txtFull_Name.TabIndex = 1;
      // 
      // lblSeriesID
      // 
      this.lblSeriesID.Location = new System.Drawing.Point(58, 147);
      this.lblSeriesID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lblSeriesID.Name = "lblSeriesID";
      this.lblSeriesID.Size = new System.Drawing.Size(67, 19);
      this.lblSeriesID.TabIndex = 41;
      this.lblSeriesID.Text = "Password";
      // 
      // lblCarFamilyID
      // 
      this.lblCarFamilyID.Location = new System.Drawing.Point(54, 55);
      this.lblCarFamilyID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lblCarFamilyID.Name = "lblCarFamilyID";
      this.lblCarFamilyID.Size = new System.Drawing.Size(71, 19);
      this.lblCarFamilyID.TabIndex = 39;
      this.lblCarFamilyID.Text = "Full Name";
      // 
      // lblImporterSeriesName
      // 
      this.lblImporterSeriesName.Location = new System.Drawing.Point(34, 190);
      this.lblImporterSeriesName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lblImporterSeriesName.Name = "lblImporterSeriesName";
      this.lblImporterSeriesName.Size = new System.Drawing.Size(91, 19);
      this.lblImporterSeriesName.TabIndex = 43;
      this.lblImporterSeriesName.Text = "Re-Password";
      // 
      // lblImporter
      // 
      this.lblImporter.Location = new System.Drawing.Point(47, 98);
      this.lblImporter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lblImporter.Name = "lblImporter";
      this.lblImporter.Size = new System.Drawing.Size(78, 19);
      this.lblImporter.TabIndex = 37;
      this.lblImporter.Text = "User Name";
      // 
      // grpUserInfo
      // 
      this.grpUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grpUserInfo.Controls.Add(this.LabelControl4);
      this.grpUserInfo.Controls.Add(this.LabelControl3);
      this.grpUserInfo.Controls.Add(this.spePASSWORDCHANGEAFTER);
      this.grpUserInfo.Controls.Add(this.LabelControl9);
      this.grpUserInfo.Controls.Add(this.dteCREATE_DATE);
      this.grpUserInfo.Controls.Add(this.dteUPDATE_PASSWORD);
      this.grpUserInfo.Controls.Add(this.LabelControl12);
      this.grpUserInfo.Controls.Add(this.LabelControl11);
      this.grpUserInfo.Controls.Add(this.speSendEmail);
      this.grpUserInfo.Controls.Add(this.LabelControl10);
      this.grpUserInfo.Controls.Add(this.dteExprired_Date);
      this.grpUserInfo.Controls.Add(this.dteEffective_Date);
      this.grpUserInfo.Controls.Add(this.LabelControl8);
      this.grpUserInfo.Controls.Add(this.LabelControl7);
      this.grpUserInfo.Controls.Add(this.LabelControl6);
      this.grpUserInfo.Controls.Add(this.speNOPASSWORDHISTORY);
      this.grpUserInfo.Controls.Add(this.LabelControl5);
      this.grpUserInfo.Controls.Add(this.LabelControl2);
      this.grpUserInfo.Controls.Add(this.speDisableAfterFailed);
      this.grpUserInfo.Controls.Add(this.LabelControl1);
      this.grpUserInfo.Controls.Add(this.speIsNextLogon);
      this.grpUserInfo.Controls.Add(this.speIsLocked);
      this.grpUserInfo.Controls.Add(this.txtRetype);
      this.grpUserInfo.Controls.Add(this.txtUser_Password);
      this.grpUserInfo.Controls.Add(this.txtFull_Name);
      this.grpUserInfo.Controls.Add(this.lblSeriesID);
      this.grpUserInfo.Controls.Add(this.lblCarFamilyID);
      this.grpUserInfo.Controls.Add(this.lblImporterSeriesName);
      this.grpUserInfo.Controls.Add(this.lblImporter);
      this.grpUserInfo.Controls.Add(this.txtUser_Name);
      this.grpUserInfo.Location = new System.Drawing.Point(0, 0);
      this.grpUserInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.grpUserInfo.Name = "grpUserInfo";
      this.grpUserInfo.Size = new System.Drawing.Size(1113, 432);
      this.grpUserInfo.TabIndex = 4;
      this.grpUserInfo.Text = "User Information";
      // 
      // txtUser_Name
      // 
      this.txtUser_Name.Location = new System.Drawing.Point(152, 95);
      this.txtUser_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txtUser_Name.Name = "txtUser_Name";
      this.txtUser_Name.Size = new System.Drawing.Size(322, 26);
      this.txtUser_Name.TabIndex = 2;
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
      // frmUserEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1113, 492);
      this.Controls.Add(this.PanelControl1);
      this.Controls.Add(this.grpUserInfo);
      this.Name = "frmUserEdit";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Edit";
      ((System.ComponentModel.ISupportInitialize)(this.spePASSWORDCHANGEAFTER.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteCREATE_DATE.Properties.CalendarTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteCREATE_DATE.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteUPDATE_PASSWORD.Properties.CalendarTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteUPDATE_PASSWORD.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteExprired_Date.Properties.CalendarTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteExprired_Date.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteEffective_Date.Properties.CalendarTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteEffective_Date.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.speSendEmail.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.speNOPASSWORDHISTORY.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.speDisableAfterFailed.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.speIsNextLogon.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.speIsLocked.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtRetype.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtUser_Password.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PanelControl1)).EndInit();
      this.PanelControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.txtFull_Name.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grpUserInfo)).EndInit();
      this.grpUserInfo.ResumeLayout(false);
      this.grpUserInfo.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtUser_Name.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    internal DevExpress.XtraEditors.SimpleButton btnSave;
    internal System.Windows.Forms.ImageList imglImporterEdit;
    internal DevExpress.XtraEditors.LabelControl LabelControl4;
    internal DevExpress.XtraEditors.LabelControl LabelControl3;
    internal DevExpress.XtraEditors.SpinEdit spePASSWORDCHANGEAFTER;
    internal DevExpress.XtraEditors.LabelControl LabelControl9;
    internal DevExpress.XtraEditors.DateEdit dteCREATE_DATE;
    internal DevExpress.XtraEditors.DateEdit dteUPDATE_PASSWORD;
    internal DevExpress.XtraEditors.LabelControl LabelControl12;
    internal DevExpress.XtraEditors.SimpleButton btnClose;
    internal DevExpress.XtraEditors.LabelControl LabelControl11;
    internal DevExpress.XtraEditors.LabelControl LabelControl10;
    internal DevExpress.XtraEditors.DateEdit dteExprired_Date;
    internal DevExpress.XtraEditors.DateEdit dteEffective_Date;
    internal DevExpress.XtraEditors.LabelControl LabelControl8;
    internal DevExpress.XtraEditors.SimpleButton btnClear;
    internal DevExpress.XtraEditors.SpinEdit speSendEmail;
    internal DevExpress.XtraEditors.LabelControl LabelControl7;
    internal DevExpress.XtraEditors.LabelControl LabelControl6;
    internal DevExpress.XtraEditors.SpinEdit speNOPASSWORDHISTORY;
    internal DevExpress.XtraEditors.SpinEdit speDisableAfterFailed;
    internal DevExpress.XtraEditors.LabelControl LabelControl1;
    internal DevExpress.XtraEditors.CheckEdit speIsNextLogon;
    internal DevExpress.XtraEditors.CheckEdit speIsLocked;
    internal DevExpress.XtraEditors.TextEdit txtRetype;
    internal DevExpress.XtraEditors.TextEdit txtUser_Password;
    internal DevExpress.XtraEditors.PanelControl PanelControl1;
    internal DevExpress.XtraEditors.LabelControl LabelControl5;
    internal DevExpress.XtraEditors.LabelControl LabelControl2;
    internal DevExpress.XtraEditors.TextEdit txtFull_Name;
    internal DevExpress.XtraEditors.LabelControl lblSeriesID;
    internal DevExpress.XtraEditors.LabelControl lblCarFamilyID;
    internal DevExpress.XtraEditors.LabelControl lblImporterSeriesName;
    internal DevExpress.XtraEditors.LabelControl lblImporter;
    internal DevExpress.XtraEditors.GroupControl grpUserInfo;
    internal DevExpress.XtraEditors.TextEdit txtUser_Name;
    internal System.Windows.Forms.ImageList imgList;
  }
}