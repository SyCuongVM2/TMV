using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraTreeList;
using System.Drawing;
using System.Windows.Forms;

namespace TMV.UI.RP.CW
{
  partial class frmCW2
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
      DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
      DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
      DevExpress.XtraScheduler.TimeScaleYear timeScaleYear1 = new DevExpress.XtraScheduler.TimeScaleYear();
      DevExpress.XtraScheduler.TimeScaleQuarter timeScaleQuarter1 = new DevExpress.XtraScheduler.TimeScaleQuarter();
      DevExpress.XtraScheduler.TimeScaleMonth timeScaleMonth1 = new DevExpress.XtraScheduler.TimeScaleMonth();
      DevExpress.XtraScheduler.TimeScaleWeek timeScaleWeek1 = new DevExpress.XtraScheduler.TimeScaleWeek();
      DevExpress.XtraScheduler.TimeScaleDay timeScaleDay1 = new DevExpress.XtraScheduler.TimeScaleDay();
      DevExpress.XtraScheduler.TimeScaleHour timeScaleHour1 = new DevExpress.XtraScheduler.TimeScaleHour();
      DevExpress.XtraScheduler.TimeScale15Minutes timeScale15Minutes1 = new DevExpress.XtraScheduler.TimeScale15Minutes();
      DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
      this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
      this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
      this.MasterCho_Rua = new DevExpress.XtraGrid.GridControl();
      this.MasterCho_RuaGRV = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.RepositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
      this.RepositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
      this.LabWait = new System.Windows.Forms.Label();
      this.SplitContainer3 = new System.Windows.Forms.SplitContainer();
      this.SplitContainer5 = new System.Windows.Forms.SplitContainer();
      this.ResourcesTree1 = new DevExpress.XtraScheduler.UI.ResourcesTree();
      this.BarManagerCho_Rua = new DevExpress.XtraBars.BarManager(this.components);
      this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      this.SchedulerControl = new DevExpress.XtraScheduler.SchedulerControl();
      this.SchedulerStorage = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
      this.LabPlan = new System.Windows.Forms.Label();
      this.SplitContainer4 = new System.Windows.Forms.SplitContainer();
      this.MasterDang_Rua = new DevExpress.XtraGrid.GridControl();
      this.MasterDang_RuaGRV = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.RepositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
      this.RepositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
      this.LabWash = new System.Windows.Forms.Label();
      this.MasterRua_Xong = new DevExpress.XtraGrid.GridControl();
      this.MasterRua_XongGRV = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.RepositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
      this.RepositoryItemTextEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
      this.LabTy_Hieusuat = new System.Windows.Forms.Label();
      this.LabFinish = new System.Windows.Forms.Label();
      this.LabKQ_RX = new System.Windows.Forms.Label();
      this.LabKQ_DR = new System.Windows.Forms.Label();
      this.LabKQ_CR = new System.Windows.Forms.Label();
      this.Label4 = new System.Windows.Forms.Label();
      this.Label2 = new System.Windows.Forms.Label();
      this.Label1 = new System.Windows.Forms.Label();
      this.CbbKieu_Xem = new System.Windows.Forms.ComboBox();
      this.TxtSo_RO = new System.Windows.Forms.TextBox();
      this.TxtMa_Xe = new System.Windows.Forms.TextBox();
      this.CbbMa_HS = new System.Windows.Forms.ComboBox();
      this.CmdRefresh = new DevExpress.XtraEditors.SimpleButton();
      this.CbbGio_Xem = new System.Windows.Forms.ComboBox();
      this.CbbCa_Ngay = new System.Windows.Forms.ComboBox();
      this.ChkAuto_Data = new System.Windows.Forms.CheckBox();
      this.CbbDo_Rong = new System.Windows.Forms.ComboBox();
      this.CbbTime_Data = new System.Windows.Forms.ComboBox();
      this.CbbMa_BN = new System.Windows.Forms.ComboBox();
      this.Timer_Data = new System.Windows.Forms.Timer(this.components);
      this.Timer_PercentComplete = new System.Windows.Forms.Timer(this.components);
      this.PopupMenuSchedulerControl = new DevExpress.XtraBars.PopupMenu(this.components);
      this.BarManager_Scheduler = new DevExpress.XtraBars.BarManager(this.components);
      this.BarDockControl5 = new DevExpress.XtraBars.BarDockControl();
      this.BarDockControl6 = new DevExpress.XtraBars.BarDockControl();
      this.BarDockControl7 = new DevExpress.XtraBars.BarDockControl();
      this.BarDockControl8 = new DevExpress.XtraBars.BarDockControl();
      this.PopupMenuCho_Rua = new DevExpress.XtraBars.PopupMenu(this.components);
      this.PopupMenuDang_Rua = new DevExpress.XtraBars.PopupMenu(this.components);
      this.BarManagerDang_Rua = new DevExpress.XtraBars.BarManager(this.components);
      this.BarDockControl1 = new DevExpress.XtraBars.BarDockControl();
      this.BarDockControl2 = new DevExpress.XtraBars.BarDockControl();
      this.BarDockControl3 = new DevExpress.XtraBars.BarDockControl();
      this.BarDockControl4 = new DevExpress.XtraBars.BarDockControl();
      this.BarManagerRua_Xong = new DevExpress.XtraBars.BarManager(this.components);
      this.Bar1 = new DevExpress.XtraBars.Bar();
      this.BarDockControl9 = new DevExpress.XtraBars.BarDockControl();
      this.BarDockControl10 = new DevExpress.XtraBars.BarDockControl();
      this.BarDockControl11 = new DevExpress.XtraBars.BarDockControl();
      this.BarDockControl12 = new DevExpress.XtraBars.BarDockControl();
      this.PopupMenuRua_Xong = new DevExpress.XtraBars.PopupMenu(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
      this.SplitContainer1.Panel1.SuspendLayout();
      this.SplitContainer1.Panel2.SuspendLayout();
      this.SplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
      this.SplitContainer2.Panel1.SuspendLayout();
      this.SplitContainer2.Panel2.SuspendLayout();
      this.SplitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.MasterCho_Rua)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MasterCho_RuaGRV)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3)).BeginInit();
      this.SplitContainer3.Panel1.SuspendLayout();
      this.SplitContainer3.Panel2.SuspendLayout();
      this.SplitContainer3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer5)).BeginInit();
      this.SplitContainer5.Panel1.SuspendLayout();
      this.SplitContainer5.Panel2.SuspendLayout();
      this.SplitContainer5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ResourcesTree1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BarManagerCho_Rua)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SchedulerControl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SchedulerStorage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer4)).BeginInit();
      this.SplitContainer4.Panel1.SuspendLayout();
      this.SplitContainer4.Panel2.SuspendLayout();
      this.SplitContainer4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.MasterDang_Rua)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MasterDang_RuaGRV)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MasterRua_Xong)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MasterRua_XongGRV)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit6)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PopupMenuSchedulerControl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BarManager_Scheduler)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PopupMenuCho_Rua)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PopupMenuDang_Rua)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BarManagerDang_Rua)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BarManagerRua_Xong)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PopupMenuRua_Xong)).BeginInit();
      this.SuspendLayout();
      // 
      // SplitContainer1
      // 
      this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SplitContainer1.Location = new System.Drawing.Point(0, 20);
      this.SplitContainer1.Name = "SplitContainer1";
      this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // SplitContainer1.Panel1
      // 
      this.SplitContainer1.Panel1.Controls.Add(this.SplitContainer2);
      // 
      // SplitContainer1.Panel2
      // 
      this.SplitContainer1.Panel2.Controls.Add(this.LabKQ_RX);
      this.SplitContainer1.Panel2.Controls.Add(this.LabKQ_DR);
      this.SplitContainer1.Panel2.Controls.Add(this.LabKQ_CR);
      this.SplitContainer1.Panel2.Controls.Add(this.Label4);
      this.SplitContainer1.Panel2.Controls.Add(this.Label2);
      this.SplitContainer1.Panel2.Controls.Add(this.Label1);
      this.SplitContainer1.Panel2.Controls.Add(this.CbbKieu_Xem);
      this.SplitContainer1.Panel2.Controls.Add(this.TxtSo_RO);
      this.SplitContainer1.Panel2.Controls.Add(this.TxtMa_Xe);
      this.SplitContainer1.Panel2.Controls.Add(this.CbbMa_HS);
      this.SplitContainer1.Panel2.Controls.Add(this.CmdRefresh);
      this.SplitContainer1.Panel2.Controls.Add(this.CbbGio_Xem);
      this.SplitContainer1.Panel2.Controls.Add(this.CbbCa_Ngay);
      this.SplitContainer1.Panel2.Controls.Add(this.ChkAuto_Data);
      this.SplitContainer1.Panel2.Controls.Add(this.CbbDo_Rong);
      this.SplitContainer1.Panel2.Controls.Add(this.CbbTime_Data);
      this.SplitContainer1.Panel2.Controls.Add(this.CbbMa_BN);
      this.SplitContainer1.Panel2MinSize = 15;
      this.SplitContainer1.Size = new System.Drawing.Size(1288, 498);
      this.SplitContainer1.SplitterDistance = 353;
      this.SplitContainer1.TabIndex = 45;
      // 
      // SplitContainer2
      // 
      this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
      this.SplitContainer2.Name = "SplitContainer2";
      // 
      // SplitContainer2.Panel1
      // 
      this.SplitContainer2.Panel1.Controls.Add(this.MasterCho_Rua);
      this.SplitContainer2.Panel1.Controls.Add(this.LabWait);
      // 
      // SplitContainer2.Panel2
      // 
      this.SplitContainer2.Panel2.Controls.Add(this.SplitContainer3);
      this.SplitContainer2.Size = new System.Drawing.Size(1288, 353);
      this.SplitContainer2.SplitterDistance = 292;
      this.SplitContainer2.TabIndex = 0;
      // 
      // MasterCho_Rua
      // 
      this.MasterCho_Rua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.MasterCho_Rua.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MasterCho_Rua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MasterCho_Rua.Location = new System.Drawing.Point(0, 23);
      this.MasterCho_Rua.MainView = this.MasterCho_RuaGRV;
      this.MasterCho_Rua.Name = "MasterCho_Rua";
      this.MasterCho_Rua.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemTextEdit1,
            this.RepositoryItemTextEdit2});
      this.MasterCho_Rua.Size = new System.Drawing.Size(292, 330);
      this.MasterCho_Rua.TabIndex = 1791;
      this.MasterCho_Rua.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MasterCho_RuaGRV});
      // 
      // MasterCho_RuaGRV
      // 
      this.MasterCho_RuaGRV.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.MasterCho_RuaGRV.Appearance.FocusedRow.Options.UseBackColor = true;
      this.MasterCho_RuaGRV.Appearance.SelectedRow.BackColor = System.Drawing.Color.Red;
      this.MasterCho_RuaGRV.Appearance.SelectedRow.Options.UseBackColor = true;
      this.MasterCho_RuaGRV.Appearance.ViewCaption.Options.UseTextOptions = true;
      this.MasterCho_RuaGRV.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.MasterCho_RuaGRV.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
      this.MasterCho_RuaGRV.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
      this.MasterCho_RuaGRV.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MasterCho_RuaGRV.AppearancePrint.EvenRow.Options.UseFont = true;
      this.MasterCho_RuaGRV.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
      this.MasterCho_RuaGRV.GridControl = this.MasterCho_Rua;
      this.MasterCho_RuaGRV.GroupRowHeight = 30;
      this.MasterCho_RuaGRV.Name = "MasterCho_RuaGRV";
      this.MasterCho_RuaGRV.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
      this.MasterCho_RuaGRV.OptionsLayout.Columns.AddNewColumns = false;
      this.MasterCho_RuaGRV.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
      this.MasterCho_RuaGRV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
      this.MasterCho_RuaGRV.OptionsView.ColumnAutoWidth = false;
      this.MasterCho_RuaGRV.OptionsView.ShowGroupPanel = false;
      this.MasterCho_RuaGRV.RowHeight = 21;
      // 
      // RepositoryItemTextEdit1
      // 
      this.RepositoryItemTextEdit1.AutoHeight = false;
      this.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1";
      // 
      // RepositoryItemTextEdit2
      // 
      this.RepositoryItemTextEdit2.AutoHeight = false;
      this.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2";
      // 
      // LabWait
      // 
      this.LabWait.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.LabWait.Dock = System.Windows.Forms.DockStyle.Top;
      this.LabWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LabWait.ForeColor = System.Drawing.Color.White;
      this.LabWait.Location = new System.Drawing.Point(0, 0);
      this.LabWait.Name = "LabWait";
      this.LabWait.Size = new System.Drawing.Size(292, 23);
      this.LabWait.TabIndex = 3;
      this.LabWait.Tag = "WAITING";
      this.LabWait.Text = "XE CHỜ RỬA";
      this.LabWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // SplitContainer3
      // 
      this.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SplitContainer3.Location = new System.Drawing.Point(0, 0);
      this.SplitContainer3.Name = "SplitContainer3";
      // 
      // SplitContainer3.Panel1
      // 
      this.SplitContainer3.Panel1.Controls.Add(this.SplitContainer5);
      this.SplitContainer3.Panel1.Controls.Add(this.LabPlan);
      // 
      // SplitContainer3.Panel2
      // 
      this.SplitContainer3.Panel2.Controls.Add(this.SplitContainer4);
      this.SplitContainer3.Size = new System.Drawing.Size(992, 353);
      this.SplitContainer3.SplitterDistance = 798;
      this.SplitContainer3.TabIndex = 1;
      // 
      // SplitContainer5
      // 
      this.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SplitContainer5.Location = new System.Drawing.Point(0, 23);
      this.SplitContainer5.Name = "SplitContainer5";
      // 
      // SplitContainer5.Panel1
      // 
      this.SplitContainer5.Panel1.Controls.Add(this.ResourcesTree1);
      this.SplitContainer5.Panel1MinSize = 0;
      // 
      // SplitContainer5.Panel2
      // 
      this.SplitContainer5.Panel2.Controls.Add(this.SchedulerControl);
      this.SplitContainer5.Panel2MinSize = 0;
      this.SplitContainer5.Size = new System.Drawing.Size(798, 330);
      this.SplitContainer5.SplitterDistance = 640;
      this.SplitContainer5.TabIndex = 6;
      // 
      // ResourcesTree1
      // 
      this.ResourcesTree1.FixedLineWidth = 1;
      this.ResourcesTree1.HorzScrollStep = 1;
      this.ResourcesTree1.Location = new System.Drawing.Point(0, 0);
      this.ResourcesTree1.MenuManager = this.BarManagerCho_Rua;
      this.ResourcesTree1.Name = "ResourcesTree1";
      this.ResourcesTree1.OptionsBehavior.Editable = false;
      this.ResourcesTree1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
      this.ResourcesTree1.OptionsView.ShowButtons = false;
      this.ResourcesTree1.OptionsView.ShowRoot = false;
      this.ResourcesTree1.OptionsView.ShowVertLines = true;
      this.ResourcesTree1.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
      this.ResourcesTree1.SchedulerControl = this.SchedulerControl;
      this.ResourcesTree1.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
      this.ResourcesTree1.Size = new System.Drawing.Size(640, 330);
      this.ResourcesTree1.TabIndex = 4;
      // 
      // BarManagerCho_Rua
      // 
      this.BarManagerCho_Rua.DockControls.Add(this.barDockControlTop);
      this.BarManagerCho_Rua.DockControls.Add(this.barDockControlBottom);
      this.BarManagerCho_Rua.DockControls.Add(this.barDockControlLeft);
      this.BarManagerCho_Rua.DockControls.Add(this.barDockControlRight);
      this.BarManagerCho_Rua.Form = this;
      // 
      // barDockControlTop
      // 
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.barDockControlTop.Location = new System.Drawing.Point(0, 20);
      this.barDockControlTop.Manager = this.BarManagerCho_Rua;
      this.barDockControlTop.Size = new System.Drawing.Size(1288, 0);
      // 
      // barDockControlBottom
      // 
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.barDockControlBottom.Location = new System.Drawing.Point(0, 518);
      this.barDockControlBottom.Manager = this.BarManagerCho_Rua;
      this.barDockControlBottom.Size = new System.Drawing.Size(1288, 0);
      // 
      // barDockControlLeft
      // 
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
      this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
      this.barDockControlLeft.Manager = this.BarManagerCho_Rua;
      this.barDockControlLeft.Size = new System.Drawing.Size(0, 498);
      // 
      // barDockControlRight
      // 
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.barDockControlRight.Location = new System.Drawing.Point(1288, 20);
      this.barDockControlRight.Manager = this.BarManagerCho_Rua;
      this.barDockControlRight.Size = new System.Drawing.Size(0, 498);
      // 
      // SchedulerControl
      // 
      this.SchedulerControl.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Gantt;
      this.SchedulerControl.Appearance.Appointment.Options.UseTextOptions = true;
      this.SchedulerControl.Appearance.Appointment.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
      this.SchedulerControl.Appearance.Appointment.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
      this.SchedulerControl.Appearance.ResourceHeaderCaption.ForeColor = System.Drawing.Color.Blue;
      this.SchedulerControl.Appearance.ResourceHeaderCaption.Options.UseForeColor = true;
      this.SchedulerControl.Appearance.ResourceHeaderCaption.Options.UseTextOptions = true;
      this.SchedulerControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
      this.SchedulerControl.DataStorage = this.SchedulerStorage;
      this.SchedulerControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SchedulerControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.SchedulerControl.Location = new System.Drawing.Point(0, 0);
      this.SchedulerControl.MenuManager = this.BarManagerCho_Rua;
      this.SchedulerControl.Name = "SchedulerControl";
      this.SchedulerControl.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None;
      this.SchedulerControl.OptionsView.ResourceHeaders.Height = 80;
      this.SchedulerControl.OptionsView.ResourceHeaders.ImageAlign = DevExpress.XtraScheduler.HeaderImageAlign.Right;
      this.SchedulerControl.OptionsView.ResourceHeaders.ImageSizeMode = DevExpress.XtraScheduler.HeaderImageSizeMode.ZoomImage;
      this.SchedulerControl.OptionsView.ResourceHeaders.RotateCaption = false;
      this.SchedulerControl.OptionsView.ToolTipVisibility = DevExpress.XtraScheduler.ToolTipVisibility.Always;
      this.SchedulerControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.SchedulerControl.Size = new System.Drawing.Size(154, 330);
      this.SchedulerControl.Start = new System.DateTime(2022, 5, 16, 0, 0, 0, 0);
      this.SchedulerControl.TabIndex = 5;
      this.SchedulerControl.Text = "SchedulerControl1";
      this.SchedulerControl.Views.DayView.TimeRulers.Add(timeRuler1);
      this.SchedulerControl.Views.FullWeekView.Enabled = true;
      this.SchedulerControl.Views.FullWeekView.TimeRulers.Add(timeRuler2);
      this.SchedulerControl.Views.GanttView.CellsAutoHeightOptions.AutoHeightMode = DevExpress.XtraScheduler.SchedulerCellAutoHeightMode.Limited;
      this.SchedulerControl.Views.GanttView.CellsAutoHeightOptions.Enabled = true;
      this.SchedulerControl.Views.GanttView.CellsAutoHeightOptions.MinHeight = 150;
      timeScaleYear1.Enabled = false;
      timeScaleQuarter1.Enabled = false;
      timeScaleMonth1.Enabled = false;
      timeScaleWeek1.Enabled = false;
      this.SchedulerControl.Views.GanttView.Scales.Add(timeScaleYear1);
      this.SchedulerControl.Views.GanttView.Scales.Add(timeScaleQuarter1);
      this.SchedulerControl.Views.GanttView.Scales.Add(timeScaleMonth1);
      this.SchedulerControl.Views.GanttView.Scales.Add(timeScaleWeek1);
      this.SchedulerControl.Views.GanttView.Scales.Add(timeScaleDay1);
      this.SchedulerControl.Views.GanttView.Scales.Add(timeScaleHour1);
      this.SchedulerControl.Views.GanttView.Scales.Add(timeScale15Minutes1);
      this.SchedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
      this.SchedulerControl.Views.YearView.UseOptimizedScrolling = false;
      // 
      // SchedulerStorage
      // 
      this.SchedulerStorage.Appointments.Labels.Add(System.Drawing.Color.LightGray, "Chờ sửa chữa", "&Chờ sửa chữa");
      this.SchedulerStorage.Appointments.Labels.Add(System.Drawing.Color.GreenYellow, "Đang sửa chữa", "&Đang sửa chữa");
      this.SchedulerStorage.Appointments.Labels.Add(System.Drawing.Color.Red, "Dừng", "&Dừng");
      this.SchedulerStorage.Appointments.Labels.Add(System.Drawing.Color.MediumPurple, "Đặt chỗ", "Đặt chỗ");
      this.SchedulerStorage.Appointments.Labels.Add(System.Drawing.Color.Yellow, "Đặt hẹn", "Đặt hẹn");
      this.SchedulerStorage.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(206)))), ((int)(((byte)(147))))), "Must Attend", "Must &Attend");
      this.SchedulerStorage.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(244)))), ((int)(((byte)(255))))), "Travel Required", "&Travel Required");
      this.SchedulerStorage.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(152))))), "Needs Preparation", "&Needs Preparation");
      this.SchedulerStorage.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(207)))), ((int)(((byte)(233))))), "Birthday", "&Birthday");
      this.SchedulerStorage.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(233)))), ((int)(((byte)(223))))), "Anniversary", "&Anniversary");
      this.SchedulerStorage.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(165))))), "Phone Call", "Phone &Call");
      // 
      // LabPlan
      // 
      this.LabPlan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.LabPlan.Dock = System.Windows.Forms.DockStyle.Top;
      this.LabPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LabPlan.ForeColor = System.Drawing.Color.White;
      this.LabPlan.Location = new System.Drawing.Point(0, 0);
      this.LabPlan.Name = "LabPlan";
      this.LabPlan.Size = new System.Drawing.Size(798, 23);
      this.LabPlan.TabIndex = 7;
      this.LabPlan.Tag = "PLANNING";
      this.LabPlan.Text = "XE KẾ HOẠCH";
      this.LabPlan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // SplitContainer4
      // 
      this.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SplitContainer4.Location = new System.Drawing.Point(0, 0);
      this.SplitContainer4.Name = "SplitContainer4";
      this.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // SplitContainer4.Panel1
      // 
      this.SplitContainer4.Panel1.Controls.Add(this.MasterDang_Rua);
      this.SplitContainer4.Panel1.Controls.Add(this.LabWash);
      // 
      // SplitContainer4.Panel2
      // 
      this.SplitContainer4.Panel2.Controls.Add(this.MasterRua_Xong);
      this.SplitContainer4.Panel2.Controls.Add(this.LabTy_Hieusuat);
      this.SplitContainer4.Panel2.Controls.Add(this.LabFinish);
      this.SplitContainer4.Size = new System.Drawing.Size(190, 353);
      this.SplitContainer4.SplitterDistance = 250;
      this.SplitContainer4.TabIndex = 5;
      // 
      // MasterDang_Rua
      // 
      this.MasterDang_Rua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.MasterDang_Rua.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MasterDang_Rua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MasterDang_Rua.Location = new System.Drawing.Point(0, 23);
      this.MasterDang_Rua.MainView = this.MasterDang_RuaGRV;
      this.MasterDang_Rua.Name = "MasterDang_Rua";
      this.MasterDang_Rua.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemTextEdit3,
            this.RepositoryItemTextEdit4});
      this.MasterDang_Rua.Size = new System.Drawing.Size(190, 227);
      this.MasterDang_Rua.TabIndex = 1792;
      this.MasterDang_Rua.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MasterDang_RuaGRV});
      // 
      // MasterDang_RuaGRV
      // 
      this.MasterDang_RuaGRV.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.MasterDang_RuaGRV.Appearance.FocusedRow.Options.UseBackColor = true;
      this.MasterDang_RuaGRV.Appearance.SelectedRow.BackColor = System.Drawing.Color.Red;
      this.MasterDang_RuaGRV.Appearance.SelectedRow.Options.UseBackColor = true;
      this.MasterDang_RuaGRV.Appearance.ViewCaption.Options.UseTextOptions = true;
      this.MasterDang_RuaGRV.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.MasterDang_RuaGRV.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
      this.MasterDang_RuaGRV.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
      this.MasterDang_RuaGRV.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MasterDang_RuaGRV.AppearancePrint.EvenRow.Options.UseFont = true;
      this.MasterDang_RuaGRV.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
      this.MasterDang_RuaGRV.GridControl = this.MasterDang_Rua;
      this.MasterDang_RuaGRV.GroupRowHeight = 30;
      this.MasterDang_RuaGRV.Name = "MasterDang_RuaGRV";
      this.MasterDang_RuaGRV.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
      this.MasterDang_RuaGRV.OptionsLayout.Columns.AddNewColumns = false;
      this.MasterDang_RuaGRV.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
      this.MasterDang_RuaGRV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
      this.MasterDang_RuaGRV.OptionsView.ColumnAutoWidth = false;
      this.MasterDang_RuaGRV.OptionsView.ShowGroupPanel = false;
      this.MasterDang_RuaGRV.RowHeight = 21;
      // 
      // RepositoryItemTextEdit3
      // 
      this.RepositoryItemTextEdit3.AutoHeight = false;
      this.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3";
      // 
      // RepositoryItemTextEdit4
      // 
      this.RepositoryItemTextEdit4.AutoHeight = false;
      this.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4";
      // 
      // LabWash
      // 
      this.LabWash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.LabWash.Dock = System.Windows.Forms.DockStyle.Top;
      this.LabWash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LabWash.ForeColor = System.Drawing.Color.White;
      this.LabWash.Location = new System.Drawing.Point(0, 0);
      this.LabWash.Name = "LabWash";
      this.LabWash.Size = new System.Drawing.Size(190, 23);
      this.LabWash.TabIndex = 4;
      this.LabWash.Tag = "WASHING";
      this.LabWash.Text = "XE ĐANG RỬA";
      this.LabWash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // MasterRua_Xong
      // 
      this.MasterRua_Xong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.MasterRua_Xong.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MasterRua_Xong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MasterRua_Xong.Location = new System.Drawing.Point(0, 23);
      this.MasterRua_Xong.MainView = this.MasterRua_XongGRV;
      this.MasterRua_Xong.Name = "MasterRua_Xong";
      this.MasterRua_Xong.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemTextEdit5,
            this.RepositoryItemTextEdit6});
      this.MasterRua_Xong.Size = new System.Drawing.Size(190, 53);
      this.MasterRua_Xong.TabIndex = 1795;
      this.MasterRua_Xong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MasterRua_XongGRV});
      // 
      // MasterRua_XongGRV
      // 
      this.MasterRua_XongGRV.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.MasterRua_XongGRV.Appearance.FocusedRow.Options.UseBackColor = true;
      this.MasterRua_XongGRV.Appearance.SelectedRow.BackColor = System.Drawing.Color.Red;
      this.MasterRua_XongGRV.Appearance.SelectedRow.Options.UseBackColor = true;
      this.MasterRua_XongGRV.Appearance.ViewCaption.Options.UseTextOptions = true;
      this.MasterRua_XongGRV.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.MasterRua_XongGRV.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
      this.MasterRua_XongGRV.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
      this.MasterRua_XongGRV.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MasterRua_XongGRV.AppearancePrint.EvenRow.Options.UseFont = true;
      this.MasterRua_XongGRV.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
      this.MasterRua_XongGRV.GridControl = this.MasterRua_Xong;
      this.MasterRua_XongGRV.GroupRowHeight = 30;
      this.MasterRua_XongGRV.Name = "MasterRua_XongGRV";
      this.MasterRua_XongGRV.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
      this.MasterRua_XongGRV.OptionsLayout.Columns.AddNewColumns = false;
      this.MasterRua_XongGRV.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
      this.MasterRua_XongGRV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
      this.MasterRua_XongGRV.OptionsView.ColumnAutoWidth = false;
      this.MasterRua_XongGRV.OptionsView.ShowGroupPanel = false;
      this.MasterRua_XongGRV.RowHeight = 21;
      // 
      // RepositoryItemTextEdit5
      // 
      this.RepositoryItemTextEdit5.AutoHeight = false;
      this.RepositoryItemTextEdit5.Name = "RepositoryItemTextEdit5";
      // 
      // RepositoryItemTextEdit6
      // 
      this.RepositoryItemTextEdit6.AutoHeight = false;
      this.RepositoryItemTextEdit6.Name = "RepositoryItemTextEdit6";
      // 
      // LabTy_Hieusuat
      // 
      this.LabTy_Hieusuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.LabTy_Hieusuat.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.LabTy_Hieusuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LabTy_Hieusuat.ForeColor = System.Drawing.Color.White;
      this.LabTy_Hieusuat.Location = new System.Drawing.Point(0, 76);
      this.LabTy_Hieusuat.Name = "LabTy_Hieusuat";
      this.LabTy_Hieusuat.Size = new System.Drawing.Size(190, 23);
      this.LabTy_Hieusuat.TabIndex = 1794;
      this.LabTy_Hieusuat.Tag = "FINISH";
      this.LabTy_Hieusuat.Text = "XE RỬA XONG";
      this.LabTy_Hieusuat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // LabFinish
      // 
      this.LabFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.LabFinish.Dock = System.Windows.Forms.DockStyle.Top;
      this.LabFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LabFinish.ForeColor = System.Drawing.Color.White;
      this.LabFinish.Location = new System.Drawing.Point(0, 0);
      this.LabFinish.Name = "LabFinish";
      this.LabFinish.Size = new System.Drawing.Size(190, 23);
      this.LabFinish.TabIndex = 4;
      this.LabFinish.Tag = "FINISH";
      this.LabFinish.Text = "XE RỬA XONG";
      this.LabFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // LabKQ_RX
      // 
      this.LabKQ_RX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.LabKQ_RX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.LabKQ_RX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LabKQ_RX.ForeColor = System.Drawing.Color.White;
      this.LabKQ_RX.Location = new System.Drawing.Point(0, 116);
      this.LabKQ_RX.Name = "LabKQ_RX";
      this.LabKQ_RX.Size = new System.Drawing.Size(100, 23);
      this.LabKQ_RX.TabIndex = 7231;
      this.LabKQ_RX.Tag = "Wait";
      this.LabKQ_RX.Text = "CR";
      this.LabKQ_RX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // LabKQ_DR
      // 
      this.LabKQ_DR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.LabKQ_DR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.LabKQ_DR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LabKQ_DR.ForeColor = System.Drawing.Color.White;
      this.LabKQ_DR.Location = new System.Drawing.Point(0, 116);
      this.LabKQ_DR.Name = "LabKQ_DR";
      this.LabKQ_DR.Size = new System.Drawing.Size(100, 23);
      this.LabKQ_DR.TabIndex = 7230;
      this.LabKQ_DR.Tag = "Wait";
      this.LabKQ_DR.Text = "CR";
      this.LabKQ_DR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // LabKQ_CR
      // 
      this.LabKQ_CR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.LabKQ_CR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.LabKQ_CR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LabKQ_CR.ForeColor = System.Drawing.Color.White;
      this.LabKQ_CR.Location = new System.Drawing.Point(0, 116);
      this.LabKQ_CR.Name = "LabKQ_CR";
      this.LabKQ_CR.Size = new System.Drawing.Size(100, 23);
      this.LabKQ_CR.TabIndex = 7229;
      this.LabKQ_CR.Tag = "Wait";
      this.LabKQ_CR.Text = "CR";
      this.LabKQ_CR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // Label4
      // 
      this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.Label4.AutoSize = true;
      this.Label4.ForeColor = System.Drawing.Color.Red;
      this.Label4.Location = new System.Drawing.Point(0, 116);
      this.Label4.Name = "Label4";
      this.Label4.Size = new System.Drawing.Size(28, 19);
      this.Label4.TabIndex = 7228;
      this.Label4.Tag = "Fn";
      this.Label4.Text = "RX";
      // 
      // Label2
      // 
      this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.Label2.AutoSize = true;
      this.Label2.ForeColor = System.Drawing.Color.Red;
      this.Label2.Location = new System.Drawing.Point(0, 116);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(30, 19);
      this.Label2.TabIndex = 7226;
      this.Label2.Text = "ĐR";
      // 
      // Label1
      // 
      this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.Label1.AutoSize = true;
      this.Label1.ForeColor = System.Drawing.Color.Red;
      this.Label1.Location = new System.Drawing.Point(0, 116);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(29, 19);
      this.Label1.TabIndex = 7225;
      this.Label1.Tag = "Wait";
      this.Label1.Text = "CR";
      // 
      // CbbKieu_Xem
      // 
      this.CbbKieu_Xem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.CbbKieu_Xem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CbbKieu_Xem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CbbKieu_Xem.ForeColor = System.Drawing.Color.Navy;
      this.CbbKieu_Xem.FormattingEnabled = true;
      this.CbbKieu_Xem.Location = new System.Drawing.Point(0, 116);
      this.CbbKieu_Xem.Name = "CbbKieu_Xem";
      this.CbbKieu_Xem.Size = new System.Drawing.Size(121, 28);
      this.CbbKieu_Xem.TabIndex = 7224;
      // 
      // TxtSo_RO
      // 
      this.TxtSo_RO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.TxtSo_RO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.TxtSo_RO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TxtSo_RO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.TxtSo_RO.ForeColor = System.Drawing.Color.Navy;
      this.TxtSo_RO.Location = new System.Drawing.Point(1138, 116);
      this.TxtSo_RO.Name = "TxtSo_RO";
      this.TxtSo_RO.Size = new System.Drawing.Size(100, 27);
      this.TxtSo_RO.TabIndex = 7223;
      this.TxtSo_RO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // TxtMa_Xe
      // 
      this.TxtMa_Xe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.TxtMa_Xe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.TxtMa_Xe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TxtMa_Xe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.TxtMa_Xe.ForeColor = System.Drawing.Color.Navy;
      this.TxtMa_Xe.Location = new System.Drawing.Point(1138, 116);
      this.TxtMa_Xe.Name = "TxtMa_Xe";
      this.TxtMa_Xe.Size = new System.Drawing.Size(100, 27);
      this.TxtMa_Xe.TabIndex = 7222;
      this.TxtMa_Xe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // CbbMa_HS
      // 
      this.CbbMa_HS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.CbbMa_HS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CbbMa_HS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CbbMa_HS.ForeColor = System.Drawing.Color.Navy;
      this.CbbMa_HS.FormattingEnabled = true;
      this.CbbMa_HS.Location = new System.Drawing.Point(1138, 116);
      this.CbbMa_HS.Name = "CbbMa_HS";
      this.CbbMa_HS.Size = new System.Drawing.Size(121, 28);
      this.CbbMa_HS.TabIndex = 7232;
      // 
      // CmdRefresh
      // 
      this.CmdRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.CmdRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
      this.CmdRefresh.Location = new System.Drawing.Point(0, 116);
      this.CmdRefresh.Name = "CmdRefresh";
      this.CmdRefresh.Size = new System.Drawing.Size(112, 34);
      this.CmdRefresh.TabIndex = 7219;
      // 
      // CbbGio_Xem
      // 
      this.CbbGio_Xem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.CbbGio_Xem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CbbGio_Xem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CbbGio_Xem.ForeColor = System.Drawing.Color.Navy;
      this.CbbGio_Xem.FormattingEnabled = true;
      this.CbbGio_Xem.Location = new System.Drawing.Point(0, 116);
      this.CbbGio_Xem.Name = "CbbGio_Xem";
      this.CbbGio_Xem.Size = new System.Drawing.Size(121, 30);
      this.CbbGio_Xem.TabIndex = 7218;
      // 
      // CbbCa_Ngay
      // 
      this.CbbCa_Ngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.CbbCa_Ngay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CbbCa_Ngay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CbbCa_Ngay.ForeColor = System.Drawing.Color.Navy;
      this.CbbCa_Ngay.FormattingEnabled = true;
      this.CbbCa_Ngay.Location = new System.Drawing.Point(0, 116);
      this.CbbCa_Ngay.Name = "CbbCa_Ngay";
      this.CbbCa_Ngay.Size = new System.Drawing.Size(121, 30);
      this.CbbCa_Ngay.TabIndex = 7217;
      // 
      // ChkAuto_Data
      // 
      this.ChkAuto_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.ChkAuto_Data.AutoSize = true;
      this.ChkAuto_Data.ForeColor = System.Drawing.Color.Red;
      this.ChkAuto_Data.Location = new System.Drawing.Point(0, 117);
      this.ChkAuto_Data.Name = "ChkAuto_Data";
      this.ChkAuto_Data.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.ChkAuto_Data.Size = new System.Drawing.Size(69, 23);
      this.ChkAuto_Data.TabIndex = 7213;
      this.ChkAuto_Data.Text = "Auto";
      this.ChkAuto_Data.UseVisualStyleBackColor = true;
      // 
      // CbbDo_Rong
      // 
      this.CbbDo_Rong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.CbbDo_Rong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CbbDo_Rong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CbbDo_Rong.ForeColor = System.Drawing.Color.Navy;
      this.CbbDo_Rong.FormattingEnabled = true;
      this.CbbDo_Rong.Location = new System.Drawing.Point(0, 116);
      this.CbbDo_Rong.Name = "CbbDo_Rong";
      this.CbbDo_Rong.Size = new System.Drawing.Size(121, 28);
      this.CbbDo_Rong.TabIndex = 7216;
      // 
      // CbbTime_Data
      // 
      this.CbbTime_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.CbbTime_Data.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CbbTime_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CbbTime_Data.ForeColor = System.Drawing.Color.Navy;
      this.CbbTime_Data.FormattingEnabled = true;
      this.CbbTime_Data.Location = new System.Drawing.Point(0, 116);
      this.CbbTime_Data.Name = "CbbTime_Data";
      this.CbbTime_Data.Size = new System.Drawing.Size(121, 28);
      this.CbbTime_Data.TabIndex = 7214;
      // 
      // CbbMa_BN
      // 
      this.CbbMa_BN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.CbbMa_BN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CbbMa_BN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CbbMa_BN.ForeColor = System.Drawing.Color.Navy;
      this.CbbMa_BN.FormattingEnabled = true;
      this.CbbMa_BN.Location = new System.Drawing.Point(0, 116);
      this.CbbMa_BN.Name = "CbbMa_BN";
      this.CbbMa_BN.Size = new System.Drawing.Size(121, 28);
      this.CbbMa_BN.TabIndex = 7215;
      // 
      // Timer_PercentComplete
      // 
      this.Timer_PercentComplete.Interval = 1000;
      // 
      // PopupMenuSchedulerControl
      // 
      this.PopupMenuSchedulerControl.Manager = this.BarManager_Scheduler;
      this.PopupMenuSchedulerControl.Name = "PopupMenuSchedulerControl";
      // 
      // BarManager_Scheduler
      // 
      this.BarManager_Scheduler.DockControls.Add(this.BarDockControl5);
      this.BarManager_Scheduler.DockControls.Add(this.BarDockControl6);
      this.BarManager_Scheduler.DockControls.Add(this.BarDockControl7);
      this.BarManager_Scheduler.DockControls.Add(this.BarDockControl8);
      this.BarManager_Scheduler.Form = this;
      // 
      // BarDockControl5
      // 
      this.BarDockControl5.CausesValidation = false;
      this.BarDockControl5.Dock = System.Windows.Forms.DockStyle.Top;
      this.BarDockControl5.Location = new System.Drawing.Point(0, 20);
      this.BarDockControl5.Manager = this.BarManager_Scheduler;
      this.BarDockControl5.Size = new System.Drawing.Size(1288, 0);
      // 
      // BarDockControl6
      // 
      this.BarDockControl6.CausesValidation = false;
      this.BarDockControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.BarDockControl6.Location = new System.Drawing.Point(0, 518);
      this.BarDockControl6.Manager = this.BarManager_Scheduler;
      this.BarDockControl6.Size = new System.Drawing.Size(1288, 0);
      // 
      // BarDockControl7
      // 
      this.BarDockControl7.CausesValidation = false;
      this.BarDockControl7.Dock = System.Windows.Forms.DockStyle.Left;
      this.BarDockControl7.Location = new System.Drawing.Point(0, 20);
      this.BarDockControl7.Manager = this.BarManager_Scheduler;
      this.BarDockControl7.Size = new System.Drawing.Size(0, 498);
      // 
      // BarDockControl8
      // 
      this.BarDockControl8.CausesValidation = false;
      this.BarDockControl8.Dock = System.Windows.Forms.DockStyle.Right;
      this.BarDockControl8.Location = new System.Drawing.Point(1288, 20);
      this.BarDockControl8.Manager = this.BarManager_Scheduler;
      this.BarDockControl8.Size = new System.Drawing.Size(0, 498);
      // 
      // PopupMenuCho_Rua
      // 
      this.PopupMenuCho_Rua.Manager = this.BarManagerCho_Rua;
      this.PopupMenuCho_Rua.Name = "PopupMenuCho_Rua";
      // 
      // PopupMenuDang_Rua
      // 
      this.PopupMenuDang_Rua.Manager = this.BarManagerDang_Rua;
      this.PopupMenuDang_Rua.Name = "PopupMenuDang_Rua";
      // 
      // BarManagerDang_Rua
      // 
      this.BarManagerDang_Rua.DockControls.Add(this.BarDockControl1);
      this.BarManagerDang_Rua.DockControls.Add(this.BarDockControl2);
      this.BarManagerDang_Rua.DockControls.Add(this.BarDockControl3);
      this.BarManagerDang_Rua.DockControls.Add(this.BarDockControl4);
      this.BarManagerDang_Rua.Form = this;
      // 
      // BarDockControl1
      // 
      this.BarDockControl1.CausesValidation = false;
      this.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.BarDockControl1.Location = new System.Drawing.Point(0, 20);
      this.BarDockControl1.Manager = this.BarManagerDang_Rua;
      this.BarDockControl1.Size = new System.Drawing.Size(1288, 0);
      // 
      // BarDockControl2
      // 
      this.BarDockControl2.CausesValidation = false;
      this.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.BarDockControl2.Location = new System.Drawing.Point(0, 518);
      this.BarDockControl2.Manager = this.BarManagerDang_Rua;
      this.BarDockControl2.Size = new System.Drawing.Size(1288, 0);
      // 
      // BarDockControl3
      // 
      this.BarDockControl3.CausesValidation = false;
      this.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
      this.BarDockControl3.Location = new System.Drawing.Point(0, 20);
      this.BarDockControl3.Manager = this.BarManagerDang_Rua;
      this.BarDockControl3.Size = new System.Drawing.Size(0, 498);
      // 
      // BarDockControl4
      // 
      this.BarDockControl4.CausesValidation = false;
      this.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
      this.BarDockControl4.Location = new System.Drawing.Point(1288, 20);
      this.BarDockControl4.Manager = this.BarManagerDang_Rua;
      this.BarDockControl4.Size = new System.Drawing.Size(0, 498);
      // 
      // BarManagerRua_Xong
      // 
      this.BarManagerRua_Xong.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.Bar1});
      this.BarManagerRua_Xong.DockControls.Add(this.BarDockControl9);
      this.BarManagerRua_Xong.DockControls.Add(this.BarDockControl10);
      this.BarManagerRua_Xong.DockControls.Add(this.BarDockControl11);
      this.BarManagerRua_Xong.DockControls.Add(this.BarDockControl12);
      this.BarManagerRua_Xong.Form = this;
      // 
      // Bar1
      // 
      this.Bar1.BarName = "Custom_Hoan_Thanh";
      this.Bar1.DockCol = 0;
      this.Bar1.DockRow = 0;
      this.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      this.Bar1.Text = "Custom_Hoan_Thanh";
      this.Bar1.Visible = false;
      // 
      // BarDockControl9
      // 
      this.BarDockControl9.CausesValidation = false;
      this.BarDockControl9.Dock = System.Windows.Forms.DockStyle.Top;
      this.BarDockControl9.Location = new System.Drawing.Point(0, 0);
      this.BarDockControl9.Manager = this.BarManagerRua_Xong;
      this.BarDockControl9.Size = new System.Drawing.Size(1288, 20);
      // 
      // BarDockControl10
      // 
      this.BarDockControl10.CausesValidation = false;
      this.BarDockControl10.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.BarDockControl10.Location = new System.Drawing.Point(0, 518);
      this.BarDockControl10.Manager = this.BarManagerRua_Xong;
      this.BarDockControl10.Size = new System.Drawing.Size(1288, 0);
      // 
      // BarDockControl11
      // 
      this.BarDockControl11.CausesValidation = false;
      this.BarDockControl11.Dock = System.Windows.Forms.DockStyle.Left;
      this.BarDockControl11.Location = new System.Drawing.Point(0, 20);
      this.BarDockControl11.Manager = this.BarManagerRua_Xong;
      this.BarDockControl11.Size = new System.Drawing.Size(0, 498);
      // 
      // BarDockControl12
      // 
      this.BarDockControl12.CausesValidation = false;
      this.BarDockControl12.Dock = System.Windows.Forms.DockStyle.Right;
      this.BarDockControl12.Location = new System.Drawing.Point(1288, 20);
      this.BarDockControl12.Manager = this.BarManagerRua_Xong;
      this.BarDockControl12.Size = new System.Drawing.Size(0, 498);
      // 
      // PopupMenuRua_Xong
      // 
      this.PopupMenuRua_Xong.Manager = this.BarManagerRua_Xong;
      this.PopupMenuRua_Xong.Name = "PopupMenuRua_Xong";
      // 
      // frmCW2
      // 
      this.ClientSize = new System.Drawing.Size(1288, 518);
      this.Controls.Add(this.SplitContainer1);
      this.Controls.Add(this.barDockControlLeft);
      this.Controls.Add(this.barDockControlRight);
      this.Controls.Add(this.barDockControlBottom);
      this.Controls.Add(this.barDockControlTop);
      this.Controls.Add(this.BarDockControl7);
      this.Controls.Add(this.BarDockControl8);
      this.Controls.Add(this.BarDockControl6);
      this.Controls.Add(this.BarDockControl5);
      this.Controls.Add(this.BarDockControl3);
      this.Controls.Add(this.BarDockControl4);
      this.Controls.Add(this.BarDockControl2);
      this.Controls.Add(this.BarDockControl1);
      this.Controls.Add(this.BarDockControl11);
      this.Controls.Add(this.BarDockControl12);
      this.Controls.Add(this.BarDockControl10);
      this.Controls.Add(this.BarDockControl9);
      this.Name = "frmCW2";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.SplitContainer1.Panel1.ResumeLayout(false);
      this.SplitContainer1.Panel2.ResumeLayout(false);
      this.SplitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
      this.SplitContainer1.ResumeLayout(false);
      this.SplitContainer2.Panel1.ResumeLayout(false);
      this.SplitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
      this.SplitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.MasterCho_Rua)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MasterCho_RuaGRV)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit2)).EndInit();
      this.SplitContainer3.Panel1.ResumeLayout(false);
      this.SplitContainer3.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3)).EndInit();
      this.SplitContainer3.ResumeLayout(false);
      this.SplitContainer5.Panel1.ResumeLayout(false);
      this.SplitContainer5.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer5)).EndInit();
      this.SplitContainer5.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ResourcesTree1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BarManagerCho_Rua)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SchedulerControl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SchedulerStorage)).EndInit();
      this.SplitContainer4.Panel1.ResumeLayout(false);
      this.SplitContainer4.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.SplitContainer4)).EndInit();
      this.SplitContainer4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.MasterDang_Rua)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MasterDang_RuaGRV)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MasterRua_Xong)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MasterRua_XongGRV)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit6)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PopupMenuSchedulerControl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BarManager_Scheduler)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PopupMenuCho_Rua)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PopupMenuDang_Rua)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BarManagerDang_Rua)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BarManagerRua_Xong)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PopupMenuRua_Xong)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    internal SplitContainer SplitContainer1;
    internal SplitContainer SplitContainer2;
    internal SplitContainer SplitContainer3;
    internal SimpleButton CmdRefresh;
    internal System.Windows.Forms.ComboBox CbbGio_Xem;
    internal System.Windows.Forms.ComboBox CbbCa_Ngay;
    internal CheckBox ChkAuto_Data;
    internal System.Windows.Forms.ComboBox CbbDo_Rong;
    internal System.Windows.Forms.ComboBox CbbTime_Data;
    internal System.Windows.Forms.ComboBox CbbMa_BN;
    internal System.Windows.Forms.TextBox TxtSo_RO;
    internal System.Windows.Forms.TextBox TxtMa_Xe;
    internal System.Windows.Forms.ComboBox CbbMa_HS;
    internal SchedulerStorage SchedulerStorage;
    internal Timer Timer_Data;
    internal Timer Timer_PercentComplete;
    internal PopupMenu PopupMenuSchedulerControl;
    internal System.Windows.Forms.ComboBox CbbKieu_Xem;
    internal BarDockControl barDockControlTop;
    internal BarDockControl barDockControlBottom;
    internal BarDockControl barDockControlLeft;
    internal BarDockControl barDockControlRight;
    internal Label LabKQ_RX;
    internal Label LabKQ_DR;
    internal Label LabKQ_CR;
    internal Label Label4;
    internal Label Label2;
    internal Label Label1;
    internal ResourcesTree ResourcesTree1;
    internal SchedulerControl SchedulerControl;
    internal SplitContainer SplitContainer4;
    internal SplitContainer SplitContainer5;
    internal Label LabWait;
    internal Label LabWash;
    internal Label LabFinish;
    internal Label LabPlan;
    internal PopupMenu PopupMenuDang_Rua;
    internal BarDockControl BarDockControl1;
    internal BarDockControl BarDockControl2;
    internal BarDockControl BarDockControl3;
    internal BarDockControl BarDockControl4;
    internal BarDockControl BarDockControl5;
    internal BarDockControl BarDockControl6;
    internal BarDockControl BarDockControl7;
    internal BarDockControl BarDockControl8;
    internal BarDockControl BarDockControl9;
    internal BarDockControl BarDockControl10;
    internal BarDockControl BarDockControl11;
    internal BarDockControl BarDockControl12;
    internal BarManager BarManager_Scheduler;
    internal BarManager BarManagerDang_Rua;
    internal Bar Bar1;
    private BarManager BarManagerRua_Xong;
    private PopupMenu PopupMenuCho_Rua;
    private BarManager BarManagerCho_Rua;
    private PopupMenu PopupMenuRua_Xong;
    internal GridControl MasterCho_Rua;
    internal GridView MasterCho_RuaGRV;
    internal RepositoryItemTextEdit RepositoryItemTextEdit1;
    internal RepositoryItemTextEdit RepositoryItemTextEdit2;
    internal GridControl MasterDang_Rua;
    internal GridView MasterDang_RuaGRV;
    internal RepositoryItemTextEdit RepositoryItemTextEdit3;
    internal RepositoryItemTextEdit RepositoryItemTextEdit4;
    internal GridControl MasterRua_Xong;
    internal GridView MasterRua_XongGRV;
    internal RepositoryItemTextEdit RepositoryItemTextEdit5;
    internal RepositoryItemTextEdit RepositoryItemTextEdit6;
    internal Label LabTy_Hieusuat;
  }
}