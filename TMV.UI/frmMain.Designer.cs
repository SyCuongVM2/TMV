
namespace TMV.UI
{
  partial class frmMain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
      this.bamBarMain = new DevExpress.XtraBars.BarManager(this.components);
      this.barMenuTop = new DevExpress.XtraBars.Bar();
      this.mnuSystem = new DevExpress.XtraBars.BarSubItem();
      this.soLogin = new DevExpress.XtraBars.BarButtonItem();
      this.siLogOut = new DevExpress.XtraBars.BarButtonItem();
      this.siChangePassword = new DevExpress.XtraBars.BarButtonItem();
      this.siUserManagement = new DevExpress.XtraBars.BarButtonItem();
      this.siSystemDomain = new DevExpress.XtraBars.BarButtonItem();
      this.siUserActionReport = new DevExpress.XtraBars.BarButtonItem();
      this.soExit = new DevExpress.XtraBars.BarButtonItem();
      this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
      this.siCW = new DevExpress.XtraBars.BarButtonItem();
      this.siGJ = new DevExpress.XtraBars.BarButtonItem();
      this.siBP = new DevExpress.XtraBars.BarButtonItem();
      this.mnuWindow = new DevExpress.XtraBars.BarSubItem();
      this.biTabbedMDI = new DevExpress.XtraBars.BarButtonItem();
      this.barStatus = new DevExpress.XtraBars.Bar();
      this.iStatus2 = new DevExpress.XtraBars.BarStaticItem();
      this.iStatus1 = new DevExpress.XtraBars.BarStaticItem();
      this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      this.imgListMainMenu = new System.Windows.Forms.ImageList(this.components);
      this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
      this.repositoryImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
      this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
      this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
      this.RepositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
      this.picBackGround = new DevExpress.XtraEditors.PictureEdit();
      this.tblMdiManageMain = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
      this.dkmMain = new DevExpress.XtraBars.Docking.DockManager(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.bamBarMain)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryImageComboBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picBackGround.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.tblMdiManageMain)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dkmMain)).BeginInit();
      this.SuspendLayout();
      // 
      // bamBarMain
      // 
      this.bamBarMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMenuTop,
            this.barStatus});
      this.bamBarMain.DockControls.Add(this.barDockControlTop);
      this.bamBarMain.DockControls.Add(this.barDockControlBottom);
      this.bamBarMain.DockControls.Add(this.barDockControlLeft);
      this.bamBarMain.DockControls.Add(this.barDockControlRight);
      this.bamBarMain.Form = this;
      this.bamBarMain.Images = this.imgListMainMenu;
      this.bamBarMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1,
            this.iStatus2,
            this.iStatus1,
            this.mnuSystem,
            this.soLogin,
            this.siLogOut,
            this.siChangePassword,
            this.siUserManagement,
            this.siSystemDomain,
            this.siUserActionReport,
            this.soExit,
            this.mnuWindow,
            this.biTabbedMDI,
            this.barSubItem1,
            this.siCW,
            this.siGJ,
            this.siBP});
      this.bamBarMain.MainMenu = this.barMenuTop;
      this.bamBarMain.MaxItemId = 20;
      this.bamBarMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryImageComboBox1,
            this.repositoryItemComboBox1,
            this.repositoryItemImageComboBox1,
            this.RepositoryItemHyperLinkEdit1});
      this.bamBarMain.StatusBar = this.barStatus;
      // 
      // barMenuTop
      // 
      this.barMenuTop.BarName = "MainMenu";
      this.barMenuTop.DockCol = 0;
      this.barMenuTop.DockRow = 0;
      this.barMenuTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      this.barMenuTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuSystem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuWindow)});
      this.barMenuTop.OptionsBar.AllowQuickCustomization = false;
      this.barMenuTop.OptionsBar.UseWholeRow = true;
      this.barMenuTop.Text = "MainMenu";
      // 
      // mnuSystem
      // 
      this.mnuSystem.Caption = "&System";
      this.mnuSystem.Id = 3;
      this.mnuSystem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.soLogin),
            new DevExpress.XtraBars.LinkPersistInfo(this.siLogOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.siChangePassword),
            new DevExpress.XtraBars.LinkPersistInfo(this.siUserManagement, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.siSystemDomain, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.siUserActionReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.soExit, true)});
      this.mnuSystem.Name = "mnuSystem";
      // 
      // soLogin
      // 
      this.soLogin.Caption = "Log &In";
      this.soLogin.Id = 4;
      this.soLogin.ImageOptions.ImageIndex = 2;
      this.soLogin.Name = "soLogin";
      // 
      // siLogOut
      // 
      this.siLogOut.Caption = "Log &Out";
      this.siLogOut.Id = 5;
      this.siLogOut.ImageOptions.ImageIndex = 3;
      this.siLogOut.Name = "siLogOut";
      // 
      // siChangePassword
      // 
      this.siChangePassword.Caption = "Change &Password";
      this.siChangePassword.Id = 6;
      this.siChangePassword.ImageOptions.ImageIndex = 4;
      this.siChangePassword.Name = "siChangePassword";
      // 
      // siUserManagement
      // 
      this.siUserManagement.Caption = "&User Management";
      this.siUserManagement.Id = 7;
      this.siUserManagement.ImageOptions.ImageIndex = 6;
      this.siUserManagement.Name = "siUserManagement";
      // 
      // siSystemDomain
      // 
      this.siSystemDomain.Caption = "System Domain";
      this.siSystemDomain.Id = 8;
      this.siSystemDomain.ImageOptions.ImageIndex = 0;
      this.siSystemDomain.Name = "siSystemDomain";
      // 
      // siUserActionReport
      // 
      this.siUserActionReport.Caption = "User &Action Report";
      this.siUserActionReport.Id = 9;
      this.siUserActionReport.ImageOptions.ImageIndex = 8;
      this.siUserActionReport.Name = "siUserActionReport";
      // 
      // soExit
      // 
      this.soExit.Caption = "&Exit";
      this.soExit.Id = 10;
      this.soExit.ImageOptions.ImageIndex = 7;
      this.soExit.Name = "soExit";
      // 
      // barSubItem1
      // 
      this.barSubItem1.Caption = "&JPCB";
      this.barSubItem1.Id = 16;
      this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.siCW),
            new DevExpress.XtraBars.LinkPersistInfo(this.siGJ),
            new DevExpress.XtraBars.LinkPersistInfo(this.siBP)});
      this.barSubItem1.Name = "barSubItem1";
      // 
      // siCW
      // 
      this.siCW.Caption = "&CW";
      this.siCW.Id = 17;
      this.siCW.ImageOptions.ImageIndex = 31;
      this.siCW.Name = "siCW";
      // 
      // siGJ
      // 
      this.siGJ.Caption = "&GJ";
      this.siGJ.Id = 18;
      this.siGJ.ImageOptions.ImageIndex = 32;
      this.siGJ.Name = "siGJ";
      // 
      // siBP
      // 
      this.siBP.Caption = "&BP";
      this.siBP.Id = 19;
      this.siBP.ImageOptions.ImageIndex = 33;
      this.siBP.Name = "siBP";
      // 
      // mnuWindow
      // 
      this.mnuWindow.Caption = "&Window";
      this.mnuWindow.Id = 11;
      this.mnuWindow.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.biTabbedMDI, "Kiểu &Tab")});
      this.mnuWindow.Name = "mnuWindow";
      // 
      // biTabbedMDI
      // 
      this.biTabbedMDI.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
      this.biTabbedMDI.Caption = "Use TabbedMDI";
      this.biTabbedMDI.Down = true;
      this.biTabbedMDI.Id = 12;
      this.biTabbedMDI.Name = "biTabbedMDI";
      this.biTabbedMDI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biTabbedMDI_ItemClick);
      // 
      // barStatus
      // 
      this.barStatus.BarName = "Status bar";
      this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
      this.barStatus.DockCol = 0;
      this.barStatus.DockRow = 0;
      this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
      this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iStatus2),
            new DevExpress.XtraBars.LinkPersistInfo(this.iStatus1)});
      this.barStatus.OptionsBar.AllowQuickCustomization = false;
      this.barStatus.OptionsBar.DrawDragBorder = false;
      this.barStatus.OptionsBar.UseWholeRow = true;
      this.barStatus.Text = "Status bar";
      // 
      // iStatus2
      // 
      this.iStatus2.Id = 1;
      this.iStatus2.Name = "iStatus2";
      // 
      // iStatus1
      // 
      this.iStatus1.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
      this.iStatus1.Caption = "Ready";
      this.iStatus1.Id = 2;
      this.iStatus1.Name = "iStatus1";
      // 
      // barDockControlTop
      // 
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
      this.barDockControlTop.Manager = this.bamBarMain;
      this.barDockControlTop.Size = new System.Drawing.Size(1536, 52);
      // 
      // barDockControlBottom
      // 
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.barDockControlBottom.Location = new System.Drawing.Point(0, 947);
      this.barDockControlBottom.Manager = this.bamBarMain;
      this.barDockControlBottom.Size = new System.Drawing.Size(1536, 31);
      // 
      // barDockControlLeft
      // 
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
      this.barDockControlLeft.Location = new System.Drawing.Point(0, 52);
      this.barDockControlLeft.Manager = this.bamBarMain;
      this.barDockControlLeft.Size = new System.Drawing.Size(0, 895);
      // 
      // barDockControlRight
      // 
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.barDockControlRight.Location = new System.Drawing.Point(1536, 52);
      this.barDockControlRight.Manager = this.bamBarMain;
      this.barDockControlRight.Size = new System.Drawing.Size(0, 895);
      // 
      // imgListMainMenu
      // 
      this.imgListMainMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListMainMenu.ImageStream")));
      this.imgListMainMenu.TransparentColor = System.Drawing.Color.Magenta;
      this.imgListMainMenu.Images.SetKeyName(0, "trafficlight_on.png");
      this.imgListMainMenu.Images.SetKeyName(1, "user1_information.png");
      this.imgListMainMenu.Images.SetKeyName(2, "user1_into.png");
      this.imgListMainMenu.Images.SetKeyName(3, "user1_lock.png");
      this.imgListMainMenu.Images.SetKeyName(4, "user1_monitor.png");
      this.imgListMainMenu.Images.SetKeyName(5, "user1_preferences.png");
      this.imgListMainMenu.Images.SetKeyName(6, "users_family.png");
      this.imgListMainMenu.Images.SetKeyName(7, "stop.png");
      this.imgListMainMenu.Images.SetKeyName(8, "data_information.png");
      this.imgListMainMenu.Images.SetKeyName(9, "data_edit.png");
      this.imgListMainMenu.Images.SetKeyName(10, "data_add.png");
      this.imgListMainMenu.Images.SetKeyName(11, "data_view.png");
      this.imgListMainMenu.Images.SetKeyName(12, "calendar_up.png");
      this.imgListMainMenu.Images.SetKeyName(13, "shoppingbasket_add.png");
      this.imgListMainMenu.Images.SetKeyName(14, "earth_time.png");
      this.imgListMainMenu.Images.SetKeyName(15, "home.png");
      this.imgListMainMenu.Images.SetKeyName(16, "id_card_ok.png");
      this.imgListMainMenu.Images.SetKeyName(17, "shoppingbasket_full.png");
      this.imgListMainMenu.Images.SetKeyName(18, "currency_dollar.png");
      this.imgListMainMenu.Images.SetKeyName(19, "businessman.png");
      this.imgListMainMenu.Images.SetKeyName(20, "calendar_preferences.png");
      this.imgListMainMenu.Images.SetKeyName(21, "businessman_preferences.png");
      this.imgListMainMenu.Images.SetKeyName(22, "businessman_find.png");
      this.imgListMainMenu.Images.SetKeyName(23, "businessmen.png");
      this.imgListMainMenu.Images.SetKeyName(24, "security_agent.png");
      this.imgListMainMenu.Images.SetKeyName(25, "box_out.png");
      this.imgListMainMenu.Images.SetKeyName(26, "box_into.png");
      this.imgListMainMenu.Images.SetKeyName(27, "die_gold.png");
      this.imgListMainMenu.Images.SetKeyName(28, "cube_blue.png");
      this.imgListMainMenu.Images.SetKeyName(29, "cube_green.png");
      this.imgListMainMenu.Images.SetKeyName(30, "cube_yellow.png");
      this.imgListMainMenu.Images.SetKeyName(31, "cubes.png");
      this.imgListMainMenu.Images.SetKeyName(32, "cubes_blue.png");
      this.imgListMainMenu.Images.SetKeyName(33, "cubes_green.png");
      this.imgListMainMenu.Images.SetKeyName(34, "cubes_yellow.png");
      this.imgListMainMenu.Images.SetKeyName(35, "die.png");
      // 
      // barStaticItem1
      // 
      this.barStaticItem1.Caption = "barStaticItem1";
      this.barStaticItem1.Id = 0;
      this.barStaticItem1.Name = "barStaticItem1";
      // 
      // repositoryImageComboBox1
      // 
      this.repositoryImageComboBox1.AutoHeight = false;
      this.repositoryImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryImageComboBox1.Name = "repositoryImageComboBox1";
      // 
      // repositoryItemComboBox1
      // 
      this.repositoryItemComboBox1.AutoHeight = false;
      this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
      // 
      // repositoryItemImageComboBox1
      // 
      this.repositoryItemImageComboBox1.AutoHeight = false;
      this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
      // 
      // RepositoryItemHyperLinkEdit1
      // 
      this.RepositoryItemHyperLinkEdit1.AutoHeight = false;
      this.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1";
      // 
      // picBackGround
      // 
      this.picBackGround.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.picBackGround.EditValue = ((object)(resources.GetObject("picBackGround.EditValue")));
      this.picBackGround.Location = new System.Drawing.Point(0, 35);
      this.picBackGround.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.picBackGround.MenuManager = this.bamBarMain;
      this.picBackGround.Name = "picBackGround";
      this.picBackGround.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
      this.picBackGround.Size = new System.Drawing.Size(1536, 911);
      this.picBackGround.TabIndex = 4;
      // 
      // tblMdiManageMain
      // 
      this.tblMdiManageMain.MdiParent = null;
      this.tblMdiManageMain.PageAdded += new DevExpress.XtraTabbedMdi.MdiTabPageEventHandler(this.tblMdiManageMain_PageAdded);
      this.tblMdiManageMain.PageRemoved += new DevExpress.XtraTabbedMdi.MdiTabPageEventHandler(this.tblMdiManageMain_PageRemoved);
      // 
      // dkmMain
      // 
      this.dkmMain.Form = this;
      this.dkmMain.Images = this.imgListMainMenu;
      this.dkmMain.MenuManager = this.bamBarMain;
      this.dkmMain.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar"});
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1536, 978);
      this.Controls.Add(this.picBackGround);
      this.Controls.Add(this.barDockControlLeft);
      this.Controls.Add(this.barDockControlRight);
      this.Controls.Add(this.barDockControlBottom);
      this.Controls.Add(this.barDockControlTop);
      this.IsMdiContainer = true;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "frmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "TMV.UI";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
      this.Load += new System.EventHandler(this.frmMain_Load);
      ((System.ComponentModel.ISupportInitialize)(this.bamBarMain)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryImageComboBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemHyperLinkEdit1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picBackGround.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.tblMdiManageMain)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dkmMain)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraBars.BarManager bamBarMain;
    private DevExpress.XtraBars.Bar barMenuTop;
    private DevExpress.XtraBars.Bar barStatus;
    private DevExpress.XtraBars.BarDockControl barDockControlTop;
    private DevExpress.XtraBars.BarDockControl barDockControlBottom;
    private DevExpress.XtraBars.BarDockControl barDockControlLeft;
    private DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraBars.BarStaticItem iStatus2;
    private DevExpress.XtraBars.BarStaticItem iStatus1;
    private DevExpress.XtraBars.BarStaticItem barStaticItem1;
    private DevExpress.XtraBars.BarSubItem mnuSystem;
    private DevExpress.XtraBars.BarButtonItem soLogin;
    private DevExpress.XtraEditors.PictureEdit picBackGround;
    private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tblMdiManageMain;
    private DevExpress.XtraBars.Docking.DockManager dkmMain;
    private System.Windows.Forms.ImageList imgListMainMenu;
    private DevExpress.XtraBars.BarButtonItem siLogOut;
    private DevExpress.XtraBars.BarButtonItem siChangePassword;
    private DevExpress.XtraBars.BarButtonItem siUserManagement;
    private DevExpress.XtraBars.BarButtonItem siSystemDomain;
    private DevExpress.XtraBars.BarButtonItem siUserActionReport;
    private DevExpress.XtraBars.BarButtonItem soExit;
    private DevExpress.XtraBars.BarSubItem mnuWindow;
    private DevExpress.XtraBars.BarButtonItem biTabbedMDI;
    private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryImageComboBox1;
    private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
    private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit RepositoryItemHyperLinkEdit1;
    private DevExpress.XtraBars.BarSubItem barSubItem1;
    private DevExpress.XtraBars.BarButtonItem siCW;
    private DevExpress.XtraBars.BarButtonItem siGJ;
    private DevExpress.XtraBars.BarButtonItem siBP;
  }
}