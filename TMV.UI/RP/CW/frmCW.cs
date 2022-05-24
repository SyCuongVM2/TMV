using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraTreeList;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TMV.Common;
using TMV.UI.RP.Common;

namespace TMV.UI.RP.CW
{ 
  public partial class frmCW : DevExpress.XtraEditors.XtraForm
  {
    #region "variables"
    public string M_Loai_SC = "1";
    public string M_Tang = "1";
    private string _Cp_Load_Config = "CP_RO_CW_ConFig";
    private string _Cp_Load_Data = "CP_RO_CW_Data";
    private string _Cp_Load_Ngay_Ngam_Dinh = "CP_RO_CW_Ngay_Ngam_Dinh";
    private CyberColumnGridView EditMa_Xe_Cho = new CyberColumnGridView();
    private CyberColumnGridView EditMa_Xe_Dang_Rua = new CyberColumnGridView();
    private CyberColumnGridView EditMa_Xe_Rua_Xong = new CyberColumnGridView();
    private DataTable Dt_ConFigColor_KH_SCC;
    private DataTable Dt_Set_SCC;
    private DataTable Dt_Buoc_Nhay_KH_SCC;
    private DataTable Dt_Do_Rong_KH_SCC;
    private DataTable Dt_Kieu_Xem;
    private DataTable DmCVDV_Loc_KH_SCC;
    private DataTable DmKhoang_Loc_KH_SCC;
    private DataTable DmCVDV_KH_SCC;
    private DataTable DmKhoang_KH_SCC;
    private DataView Dv_DmCVDV_KH_SCC;
    private DataView Dv_DmKhoang_KH_SCC;
    private int M_StartHour;
    private int M_FinishHour;
    private int M_StartMINUTE;
    private int M_FinishMINUTE;
    private DateTime M_Ngay_LimitInterval_Min;
    private DateTime M_Ngay_LimitInterval_Max_RX;
    private string M_Thu_Bay = "0";
    private string M_Chu_Nhat = "1";
    private string M_Loai_KH = "3";
    private DataTable Dt_Time;
    private DataTable Dt_Ca_Ngay;
    private DataTable Dt_Gio_Xem;
    private bool _Bold_Data = false;
    private bool _BackColor_Data = false;
    private bool _BackColor2_Data = false;
    private bool _ForeColor_Data = false;
    private bool _BorderColor_Data = false;
    private bool _Underline_Data = false;
    private string _FieldBold_Data = "";
    private string _FieldBackColor_Data = "";
    private string _FieldBackColor2_Data = "";
    private string _FieldForeColor_Data = "";
    private string _FieldBorderColor_Data = "";
    private string _FieldUnderline_Data = "";
    private DataTable Dt_Cho_Rua;
    private DataTable Dt_Data;
    private DataTable Dt_Dang_Rua;
    private DataTable Dt_Rua_Xong;
    private DataTable Dt_Data_Xe;
    private DataView Dv_Cho_Rua;
    private DataView Dv_Data;
    private DataView Dv_Dang_Rua;
    private DataView Dv_Rua_Xong;
    private DataView Dv_Data_Xe;
    private DataTable Dt_Cho_Rua_H;
    private DataTable Dt_Dang_Rua_H;
    private DataTable Dt_Rua_Xong_H;
    private DataTable Dt_Xe_H;
    private CyberColor CyberColor = new CyberColor();
    private bool _Bold_Cho_KH = false;
    private bool _BackColor_Cho_KH = false;
    private bool _BackColor2_Cho_KH = false;
    private bool _ForeColor_Cho_KH = false;
    private bool _Underline_Cho_KH = false;
    private string _FieldBold_Cho_KH = "";
    private string _FieldBackColor_Cho_KH = "";
    private string _FieldBackColor2_Cho_KH = "";
    private string _FieldForeColor_Cho_KH = "";
    private string _FieldUnderline_Cho_KH = "";
    private bool _Bold_Dang_Rua_KH = false;
    private bool _BackColor_Dang_Rua_KH = false;
    private bool _BackColor2_Dang_Rua_KH = false;
    private bool _ForeColor_Dang_Rua_KH = false;
    private bool _Underline_Dang_Rua_KH = false;
    private string _FieldBold_Dang_Rua_KH = "";
    private string _FieldBackColor_Dang_Rua_KH = "";
    private string _FieldBackColor2_Dang_Rua_KH = "";
    private string _FieldForeColor_Dang_Rua_KH = "";
    private string _FieldUnderline_Dang_Rua_KH = "";
    private bool _Bold_Rua_Xong_KH = false;
    private bool _BackColor_Rua_Xong_KH = false;
    private bool _BackColor2_Rua_Xong_KH = false;
    private bool _ForeColor_Rua_Xong_KH = false;
    private bool _Underline_Rua_Xong_KH = false;
    private string _FieldBold_Rua_Xong_KH = "";
    private string _FieldBackColor_Rua_Xong_KH = "";
    private string _FieldBackColor2_Rua_Xong_KH = "";
    private string _FieldForeColor_Rua_Xong_KH = "";
    private string _FieldUnderline_Rua_Xong_KH = "";
    #endregion

    public frmCW()
    {
      InitializeComponent();
    }

    private void frmCW_Load(object sender, EventArgs e)
    {
      TxtM_Ngay_Ct.EditValue = DateTime.Today.Date;
      Timer_Data.Enabled = false;
      ChkAuto_Data.Checked = false;

      V_GetKieu_Xem_Loai();
      V_SetTree();
      V_SetRowHeight_KH();
      V_CreateTime_Kieu_Xem_RX();
      V_Load();
      V_GetColumn();
      V_AddHander();
      V_SetScheduler_RXControl_KH_RX();
      V_Auto_Data_KH_RX(new object(), new EventArgs());
      V_Buoc_Nhay_KH_RX(new object(), new EventArgs());
    }

    #region "frmCW_Load"
    private void V_GetKieu_Xem_Loai()
    {
      M_Loai_SC = "2";
      M_Loai_KH = "3";
    }
    private void V_SetTree()
    {
      resourcesTree1.VertScrollVisibility = ScrollVisibility.Never;
      resourcesTree1.OptionsView.ShowIndicator = false;
      resourcesTree1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
      resourcesTree1.TreeLineStyle = LineStyle.None;
      resourcesTree1.OptionsView.ShowHorzLines = false;
      resourcesTree1.Visible = false;
    }
    private void V_SetRowHeight_KH()
    {
      decimal num = 0M;
      decimal d1_1 = 0M;
      if (Dt_Set_SCC == null || Dt_Set_SCC.Rows.Count == 0)
        return;

      if (Dt_Set_SCC.Columns.Contains("RowHeight"))
        num = Convert.ToDecimal(Dt_Set_SCC.Rows[0]["RowHeight"]);
      if (Dt_Set_SCC.Columns.Contains("RowPage"))
        d1_1 = Convert.ToDecimal(Dt_Set_SCC.Rows[0]["RowPage"]);
      if (decimal.Compare(num, 0M) == 0 & decimal.Compare(d1_1, 0M) == 0)
        return;

      decimal d1_2 = new decimal(checked(SchedulerControl.Size.Height - 70));
      if (decimal.Compare(num, 0M) > 0)
        d1_1 = Convert.ToDecimal(Math.Round(decimal.Divide(d1_2, num)));
      if (decimal.Compare(d1_1, 0M) <= 0)
        return;

      SchedulerControl.Views.GanttView.ResourcesPerPage = Convert.ToInt32(d1_1);
    }
    private void V_CreateTime_Kieu_Xem_RX()
    {
      Dt_Time = new DataTable()
      {
        Columns = {
          "Tg",
          "Ten_Tg",
          "Ten_Tg2",
          "Default"
        },
        Rows = {
          new object[]{ "10000", "10 s", "", "0" },
          new object[]{ "20000", "20 s", "", "0" },
          new object[]{ "30000", "30 s", "", "0" },
          new object[]{ "60000", "1 phút", "", "0" },
          new object[]{ "90000", "1 phút 30s", "", "0" },
          new object[]{ "120000", "2 phút", "", "0" },
          new object[]{ "180000", "3 phút", "", "0" },
          new object[]{ "240000", "4 phút", "", "0" },
          new object[]{ "300000", "5 phút", "", "0" },
          new object[]{ "360000", "6 phút", "", "0" },
          new object[]{ "420000", "7 phút", "", "0" },
          new object[]{ "480000", "8 phút", "", "0" },
          new object[]{ "540000", "9 phút", "", "0" },
          new object[]{ "600000", "10 phút", "", "0" },
        }
      };
      Dt_Ca_Ngay = new DataTable()
      {
        Columns = {
          "Ca_Ngay",
          "Ten",
          "Ten2",
          "Default"
        },
        Rows = {
          new object[]{ "01", "Cả ngày", "All", "1" },
          new object[]{ "02", "Sáng", "All", "0" },
          new object[]{ "03", "Chiều", "All", "0" },
        }
      };
      Dt_Gio_Xem = new DataTable()
      {
        Columns = {
          "Gio_Xem",
          "Ten",
          "Ten2",
          "Default"
        },
        Rows = {
          new object[]{ "01", "Theo giờ", "Hour", "0" },
          new object[]{ "02", "Theo Cầu", "Hour", "1" },
        }
      };

      V_FillComBoxDefaul(CbbTime_Data, Dt_Time, "Tg", "Ten_Tg");
      V_FillComBoxDefaul(CbbCa_Ngay, Dt_Ca_Ngay, "Ca_Ngay", "Ten");
      V_FillComBoxDefaul(CbbGio_Xem, Dt_Gio_Xem, "Gio_Xem", "Ten");
    }
    private void V_Load() 
    {
      DataSet dataSet1 = CP_RO_CW_ConFig.CreateData(); // CP_RO_CW_ConFig
      Dt_ConFigColor_KH_SCC = dataSet1.Tables[0].Copy();
      Dt_Set_SCC = dataSet1.Tables[1].Copy();
      Dt_Buoc_Nhay_KH_SCC = dataSet1.Tables[2].Copy();
      Dt_Do_Rong_KH_SCC = dataSet1.Tables[3].Copy();
      DmKhoang_Loc_KH_SCC = dataSet1.Tables[4].Copy();
      DmKhoang_KH_SCC = DmKhoang_Loc_KH_SCC.Copy();

      V_DeleteRowEmpty(DmKhoang_KH_SCC, "Ma_Khoang");

      Dv_DmKhoang_KH_SCC = new DataView(DmKhoang_KH_SCC);
      DmCVDV_Loc_KH_SCC = dataSet1.Tables[5].Copy();
      DmCVDV_KH_SCC = DmCVDV_Loc_KH_SCC.Copy();

      V_DeleteRowEmpty(DmCVDV_KH_SCC, "Ma_HS");

      Dv_DmCVDV_KH_SCC = new DataView(DmCVDV_KH_SCC);
      Dt_Kieu_Xem = dataSet1.Tables[6].Copy();
      if (Dt_Set_SCC == null)
      {
        DataSet dataSet2 = CP_RO_CW_Ngay_Ngam_Dinh.CreateData(); // CP_RO_CW_Ngay_Ngam_Dinh
        Dt_Set_SCC.Clear();
        Dt_Set_SCC.ImportRow(dataSet2.Tables[0].Rows[0]);
        dataSet2.Dispose();
      }
      M_StartHour = Convert.ToInt32(Dt_Set_SCC.Rows[0]["StartHour"]);
      M_FinishHour = Convert.ToInt32(Dt_Set_SCC.Rows[0]["FinishHour"]);
      M_StartMINUTE = Convert.ToInt32(Dt_Set_SCC.Rows[0]["StartMINUTE"]);
      M_FinishMINUTE = Convert.ToInt32(Dt_Set_SCC.Rows[0]["FinishMINUTE"]);
      M_Ngay_LimitInterval_Min = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_LimitInterval_Min"]);
      M_Ngay_LimitInterval_Max_RX = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_LimitInterval_Max"]);
      M_Thu_Bay = Dt_Set_SCC.Rows[0]["Thu_Bay"].ToString().Trim();
      M_Chu_Nhat = Dt_Set_SCC.Rows[0]["Chu_Nhat"].ToString().Trim();

      SchedulerControl.LimitInterval.Start = M_Ngay_LimitInterval_Min;
      SchedulerControl.LimitInterval.End = M_Ngay_LimitInterval_Max_RX;
      SchedulerControl.Start = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_Ct"]);

      V_FillComBoxDefaul(CbbMa_HS, DmCVDV_Loc_KH_SCC, "Ma_Hs", "Ten_Hs", "Ngam_Dinh");
      V_FillComBoxDefaul(CbbMa_BN, Dt_Buoc_Nhay_KH_SCC, "Ma_BN", "Ten_BN", "Ngam_Dinh");
      V_FillComBoxDefaul(CbbDo_Rong, Dt_Do_Rong_KH_SCC, "Ma_Width", "Ten_Width", "Ngam_Dinh");
      V_FillComBoxDefaul(CbbKieu_Xem, Dt_Kieu_Xem, "Kieu_Xem", "Ten_Kieu", "Ngam_Dinh");

      V_Kieu_Xem(V_GetvalueCombox(CbbKieu_Xem));
      V_LoadDatabases("1", "");
    }
    private void V_GetColumn()
    {
      EditMa_Xe_Cho.GetColumn(MasterCho_RuaGRV, "Ma_XE");
      EditMa_Xe_Dang_Rua.GetColumn(MasterDang_RuaGRV, "Ma_XE");
      EditMa_Xe_Rua_Xong.GetColumn(MasterRua_XongGRV, "Ma_XE");
    }
    private void V_AddHander()
    {
      //EditMa_Xe_Cho.EditColumn.Click -= new EventHandler(V_Ma_Xe_Cho);
      //EditMa_Xe_Cho.EditColumn.Click += new EventHandler(V_Ma_Xe_Cho);
      //EditMa_Xe_Dang_Rua.EditColumn.Click -= new EventHandler(V_Ma_Xe_Dang_Rua);
      //EditMa_Xe_Dang_Rua.EditColumn.Click += new EventHandler(V_Ma_Xe_Dang_Rua);
      //EditMa_Xe_Rua_Xong.EditColumn.Click -= new EventHandler(V_Ma_Xe_Rua_Xong);
      //EditMa_Xe_Rua_Xong.EditColumn.Click += new EventHandler(V_Ma_Xe_Rua_Xong);

      MasterCho_RuaGRV.PopupMenuShowing -= new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(MasterCho_RuaGRV_PopupMenuShowing);
      MasterCho_RuaGRV.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(MasterCho_RuaGRV_PopupMenuShowing);
      MasterCho_RuaGRV.RowCellStyle -= new RowCellStyleEventHandler(MasterCho_RuaGRV_RowCellStyle);
      MasterCho_RuaGRV.RowCellStyle += new RowCellStyleEventHandler(MasterCho_RuaGRV_RowCellStyle);

      MasterDang_RuaGRV.PopupMenuShowing -= new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(MasterDang_Rua_KHGRV_PopupMenuShowing);
      MasterDang_RuaGRV.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(MasterDang_Rua_KHGRV_PopupMenuShowing);
      MasterDang_RuaGRV.RowCellStyle -= new RowCellStyleEventHandler(MasterDang_Rua_KHGRV_RowCellStyle);
      MasterDang_RuaGRV.RowCellStyle += new RowCellStyleEventHandler(MasterDang_Rua_KHGRV_RowCellStyle);

      MasterRua_XongGRV.PopupMenuShowing -= new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(MasterRua_Xong_PopupMenuShowing);
      MasterRua_XongGRV.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(MasterRua_Xong_PopupMenuShowing);
      MasterRua_XongGRV.RowCellStyle -= new RowCellStyleEventHandler(MasterRua_Xong_RowCellStyle);
      MasterRua_XongGRV.RowCellStyle += new RowCellStyleEventHandler(MasterRua_Xong_RowCellStyle);

      SchedulerControl.PopupMenuShowing -= new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(V_PopupMenu_RX);
      SchedulerControl.PopupMenuShowing += new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(V_PopupMenu_RX);
      SchedulerControl.EditAppointmentFormShowing -= new AppointmentFormEventHandler(V_Lap_F3F4_KH_RX);
      SchedulerControl.EditAppointmentFormShowing += new AppointmentFormEventHandler(V_Lap_F3F4_KH_RX);
      SchedulerControl.CustomDrawTimeIndicator -= new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(SchedulerControl_CustomDrawTimeIndicator_RX);
      SchedulerControl.CustomDrawTimeIndicator += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(SchedulerControl_CustomDrawTimeIndicator_RX);
      SchedulerControl.CustomDrawAppointmentBackground -= new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(SchedulerControl_CustomDrawAppointmentBackground);
      SchedulerControl.CustomDrawAppointmentBackground += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(SchedulerControl_CustomDrawAppointmentBackground);
      SchedulerControl.AppointmentViewInfoCustomizing -= new AppointmentViewInfoCustomizingEventHandler(V_AppointmentViewInfoCustomizing);
      SchedulerControl.AppointmentViewInfoCustomizing += new AppointmentViewInfoCustomizingEventHandler(V_AppointmentViewInfoCustomizing);
      SchedulerControl.CustomDrawDayHeader -= new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(schedulerControl_CustomDrawDayHeader);
      SchedulerControl.CustomDrawDayHeader += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(schedulerControl_CustomDrawDayHeader);
      SchedulerControl.DoubleClick -= new EventHandler(V_BD_KT);
      SchedulerControl.DoubleClick += new EventHandler(V_BD_KT);
      SchedulerControl.AppointmentDrop -= new AppointmentDragEventHandler(SchedulerControl_KH_RX_AppointmentDrop);
      SchedulerControl.AppointmentDrop += new AppointmentDragEventHandler(SchedulerControl_KH_RX_AppointmentDrop);
      SchedulerControl.AppointmentResized -= new AppointmentResizeEventHandler(SchedulerControl_KH_RX_AppointmentResized);
      SchedulerControl.AppointmentResized += new AppointmentResizeEventHandler(SchedulerControl_KH_RX_AppointmentResized);
      SchedulerControl.InitAppointmentImages -= new AppointmentImagesEventHandler(SchedulerControl_InitAppointmentImages);
      SchedulerControl.InitAppointmentImages += new AppointmentImagesEventHandler(SchedulerControl_InitAppointmentImages);

      ChkAuto_Data.CheckedChanged -= new EventHandler(V_Auto_Data_KH_RX);
      ChkAuto_Data.CheckedChanged += new EventHandler(V_Auto_Data_KH_RX);
      CbbTime_Data.SelectedValueChanged -= new EventHandler(V_Auto_Data_KH_RX);
      CbbTime_Data.SelectedValueChanged += new EventHandler(V_Auto_Data_KH_RX);
      Timer_Data.Tick -= new EventHandler(V_Timer_Data_KH_RX);
      Timer_Data.Tick += new EventHandler(V_Timer_Data_KH_RX);
      CbbMa_BN.SelectedValueChanged -= new EventHandler(V_Buoc_Nhay_KH_RX);
      CbbMa_BN.SelectedValueChanged += new EventHandler(V_Buoc_Nhay_KH_RX);
      CbbDo_Rong.SelectedValueChanged -= new EventHandler(V_Do_Rong_KH_RX);
      CbbDo_Rong.SelectedValueChanged += new EventHandler(V_Do_Rong_KH_RX);
      CbbCa_Ngay.SelectedIndexChanged -= new EventHandler(V_Ca_Ngay);
      CbbCa_Ngay.SelectedIndexChanged += new EventHandler(V_Ca_Ngay);
      CbbKieu_Xem.SelectedIndexChanged -= new EventHandler(V_Kieu_Xem_RX);
      CbbKieu_Xem.SelectedIndexChanged += new EventHandler(V_Kieu_Xem_RX);
      CbbGio_Xem.SelectedIndexChanged -= new EventHandler(V_Gio_Xem_RX);
      CbbGio_Xem.SelectedIndexChanged += new EventHandler(V_Gio_Xem_RX);
      CmdRefresh.Click -= new EventHandler(V_RefreshData_KH_RX);
      CmdRefresh.Click += new EventHandler(V_RefreshData_KH_RX);
      TxtM_Ngay_Ct.TextChanged -= new EventHandler(V_Ngay_Ct_KH);
      TxtM_Ngay_Ct.TextChanged += new EventHandler(V_Ngay_Ct_KH);
      CbbMa_HS.SelectedValueChanged -= new EventHandler(V_Filter_KH_RX);
      CbbMa_HS.SelectedValueChanged += new EventHandler(V_Filter_KH_RX);
      TxtMa_Xe.TextChanged -= new EventHandler(V_Filter_KH_RX);
      TxtMa_Xe.TextChanged += new EventHandler(V_Filter_KH_RX);
      TxtSo_RO.TextChanged -= new EventHandler(V_Filter_KH_RX);
      TxtSo_RO.TextChanged += new EventHandler(V_Filter_KH_RX);

      resourcesTree1.CustomDrawNodeCell -= new CustomDrawNodeCellEventHandler(ResourcesTree1_CustomDrawNodeCell);
      resourcesTree1.CustomDrawNodeCell += new CustomDrawNodeCellEventHandler(ResourcesTree1_CustomDrawNodeCell);
      resourcesTree1.DoubleClick -= new EventHandler(ResourcesTree1_DoubleClick);
      resourcesTree1.DoubleClick += new EventHandler(ResourcesTree1_DoubleClick);
      resourcesTree1.PopupMenuShowing -= new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(ResourcesTree1_PopupMenuShowing);
      resourcesTree1.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(ResourcesTree1_PopupMenuShowing);
    }
    private void V_SetScheduler_RXControl_KH_RX()
    {
      SchedulerControl.DateNavigationBar.Visible = false;

      if (V_GetvalueCombox(CbbGio_Xem) == "01")
      {
        SchedulerControl.ActiveViewType = SchedulerViewType.Gantt;
        SchedulerControl.OptionsView.ResourceHeaders.Height = 80;
      }
      else
      {
        SchedulerControl.ActiveViewType = SchedulerViewType.Day;
        SchedulerControl.OptionsView.ResourceHeaders.Height = 30;
      }

      SchedulerControl.Views.GanttView.Scales[6].Width = Convert.ToInt32(Dt_Set_SCC.Rows[0]["HourWidth"]);
      SchedulerControl.Views.GanttView.ResourcesPerPage = Convert.ToInt32(Dt_Set_SCC.Rows[0]["RowPage"]);
      SchedulerControl.GroupType = SchedulerGroupType.Resource;

      V_SetScheduler_SetValue_RX();
      V_SetColorAppointments_RX();

      if (DmKhoang_KH_SCC.Columns.Contains("Color"))
        SchedulerStorage.Resources.Mappings.Color = DmKhoang_KH_SCC.Columns["Color"].ColumnName.ToString().Trim();
      if (DmKhoang_KH_SCC.Columns.Contains("Image"))
        SchedulerStorage.Resources.Mappings.Image = DmKhoang_KH_SCC.Columns["Image"].ColumnName.ToString().Trim();

      SchedulerStorage.Appointments.DataSource = Dv_Data;
      SchedulerStorage.Appointments.Mappings.AllDay = "AllDay";
      SchedulerStorage.Appointments.Mappings.AppointmentId = Dt_Data.Columns["Stt_Rec"].ColumnName;

      if (Dt_Data.Columns.Contains("Dien_Giai"))
        SchedulerStorage.Appointments.Mappings.Description = Dt_Data.Columns["Dien_Giai"].ColumnName;

      SchedulerStorage.Appointments.Mappings.Start = Dt_Data.Columns["Ngay_BD"].ColumnName;
      SchedulerStorage.Appointments.Mappings.End = Dt_Data.Columns["Ngay_KT"].ColumnName;
      SchedulerControl.Views.GanttView.AppointmentDisplayOptions.AutoAdjustForeColor = false;

      if (Dt_Data.Columns.Contains("Size_Border"))
        SchedulerStorage.Appointments.Mappings.Status = Dt_Data.Columns["Size_Border"].ColumnName;

      if (Dt_Data.Columns.Contains("PercentComplete"))
        SchedulerStorage.Appointments.Mappings.PercentComplete = Dt_Data.Columns["PercentComplete"].ColumnName;
      else
        SchedulerControl.Views.GanttView.AppointmentDisplayOptions.PercentCompleteDisplayType = PercentCompleteDisplayType.None;

      if (Dt_Data.Columns.Contains("Type"))
        SchedulerStorage.Appointments.Mappings.Type = Dt_Data.Columns["Type"].ColumnName;

      if (Dt_Data.Columns.Contains("Tootip"))
        SchedulerStorage.Appointments.Mappings.Location = Dt_Data.Columns["Tootip"].ColumnName;
      else if (Dt_Data.Columns.Contains("Dien_Giai"))
        SchedulerStorage.Appointments.Mappings.Location = Dt_Data.Columns["Dien_Giai"].ColumnName;

      SchedulerControl.GanttView.Appearance.Appointment.ForeColor = Color.White;
      SchedulerControl.GanttView.Appearance.Appointment.Font = new Font(SchedulerControl.DayView.Appearance.Appointment.Font.FontFamily, 8f);
      SchedulerControl.DayView.Appearance.Appointment.ForeColor = Color.White;
      SchedulerControl.DayView.Appearance.Appointment.Font = new Font(SchedulerControl.DayView.Appearance.Appointment.Font.FontFamily, 8f);
      SchedulerControl.Views.GanttView.AppointmentDisplayOptions.StartTimeVisibility = AppointmentTimeVisibility.Never;
      SchedulerControl.Views.GanttView.AppointmentDisplayOptions.EndTimeVisibility = AppointmentTimeVisibility.Never;
      SchedulerControl.Views.GanttView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Disabled;
      SchedulerControl.Views.DayView.AppointmentDisplayOptions.StartTimeVisibility = AppointmentTimeVisibility.Never;
      SchedulerControl.Views.DayView.AppointmentDisplayOptions.EndTimeVisibility = AppointmentTimeVisibility.Never;
      SchedulerControl.Views.DayView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Disabled;
    }
    private void V_Auto_Data_KH_RX(object sender, EventArgs e)
    {
      Timer_Data.Enabled = ChkAuto_Data.Checked;
      CbbTime_Data.Enabled = ChkAuto_Data.Checked;
      decimal d1 = V_StringToNumeric(CbbTime_Data);
      if (d1 <= 0M)
        d1 = 3000M;
      Timer_Data.Interval = Convert.ToInt32(d1);
    }
    private void V_Buoc_Nhay_KH_RX(object sender, EventArgs e)
    {
      V_CyberSetTime_KH_RX();
      V_Do_Rong_KH_RX(sender, e);
    }
    #endregion

    #region "Other Functions"
    private void scheduler_CustomDrawResourceHeader(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
    {
      ResourceHeader objectInfo = (ResourceHeader)e.ObjectInfo;
      string str1 = objectInfo.Resource.Id.ToString().Trim();
      int emSize = 0;
      string Left1 = V_GetvalueCombox(CbbKieu_Xem);
      bool _Bold = false;
      bool _BackColor = false;
      bool _BackColor2 = false;
      bool _ForeColor = false;
      string _FieldBold = "";
      string _FieldBackColor = "";
      string _FieldBackColor2 = "";
      string _FieldForeColor = "";
      bool flag1 = false;
      string columnName1 = "";
      DataRow[] dataRowArray = null;
      if (Left1 == "02")
      {
        CyberColor.V_GetColorBold(Dt_Data_Xe, ref _Bold, ref _BackColor, ref _BackColor2, ref _ForeColor, ref _FieldBold, ref _FieldBackColor, ref _FieldBackColor2, ref _FieldForeColor);
        dataRowArray = Dt_Data_Xe.Select("Stt_Rec='" + str1 + "'");
      }
      if (dataRowArray == null || dataRowArray.Length <= 0)
        return;

      bool flag2 = false;
      _FieldBackColor = "";
      string columnName2 = "";
      bool flag3 = false;
      bool flag4 = false;
      if (dataRowArray[0].Table.Columns.Contains("BackColorHead"))
      {
        flag3 = true;
        _FieldBackColor = dataRowArray[0].Table.Columns["BackColorHead"].ColumnName;
      }
      if (dataRowArray[0].Table.Columns.Contains("BackColor2Head"))
      {
        flag4 = true;
        columnName2 = dataRowArray[0].Table.Columns["BackColor2Head"].ColumnName;
      }
      if (dataRowArray[0].Table.Columns.Contains("Italic"))
        flag2 = true;
      if (flag2)
        flag2 = (dataRowArray[0]["Italic"].ToString().Trim() == "1");
      if (dataRowArray[0].Table.Columns.Contains("FontSize"))
        emSize = Convert.ToInt32(dataRowArray[0]["FontSize"]);
      if (emSize <= 0)
        emSize = checked((int)Math.Round(objectInfo.Appearance.HeaderCaption.Font.Size));
      if (dataRowArray[0].Table.Columns.Contains("UnDerLine"))
        flag1 = true;
      if (dataRowArray[0].Table.Columns.Contains("UnDerLine"))
        columnName1 = dataRowArray[0].Table.Columns["UnDerLine"].ColumnName;
      if (_Bold)
      {
        string Left2 = dataRowArray[0][_FieldBold].ToString().Trim();
        string str2 = "0";
        if (flag1)
          str2 = dataRowArray[0][columnName1].ToString().Trim();
        if (str2.ToString().Trim() != "1")
          flag1 = false;
        if (Left2 == "1")
        {
          if (flag1)
          {
            if (flag2)
              objectInfo.Appearance.HeaderCaption.Font = new Font(objectInfo.Appearance.HeaderCaption.Font.Name, (float)emSize, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            else
              objectInfo.Appearance.HeaderCaption.Font = new Font(objectInfo.Appearance.HeaderCaption.Font.Name, (float)emSize, FontStyle.Bold | FontStyle.Underline);
          }
          else if (flag2)
            objectInfo.Appearance.HeaderCaption.Font = new Font(objectInfo.Appearance.HeaderCaption.Font.Name, (float)emSize, FontStyle.Bold | FontStyle.Italic);
          else
            objectInfo.Appearance.HeaderCaption.Font = new Font(objectInfo.Appearance.HeaderCaption.Font.Name, (float)emSize, FontStyle.Bold);
        }
        else if (flag1)
        {
          if (flag2)
            objectInfo.Appearance.HeaderCaption.Font = new Font(objectInfo.Appearance.HeaderCaption.Font.Name, (float)emSize, FontStyle.Italic | FontStyle.Underline);
          else
            objectInfo.Appearance.HeaderCaption.Font = new Font(objectInfo.Appearance.HeaderCaption.Font.Name, (float)emSize, FontStyle.Underline);
        }
        else if (flag2)
          objectInfo.Appearance.HeaderCaption.Font = new Font(objectInfo.Appearance.HeaderCaption.Font.Name, (float)emSize, FontStyle.Italic);
        else
          objectInfo.Appearance.HeaderCaption.Font = new Font(objectInfo.Appearance.HeaderCaption.Font.Name, (float)emSize, FontStyle.Regular);
      }
      else
      {
        string str3 = "0";
        if (flag1)
          str3 = dataRowArray[0][columnName1].ToString().Trim();
        if (str3.ToString().Trim() != "1")
          flag1 = false;
        if (flag1)
        {
          if (flag2)
            objectInfo.Appearance.HeaderCaption.Font = new Font(objectInfo.Appearance.HeaderCaption.Font.Name, (float)emSize, FontStyle.Italic | FontStyle.Underline);
          else
            objectInfo.Appearance.HeaderCaption.Font = new Font(objectInfo.Appearance.HeaderCaption.Font.Name, (float)emSize, FontStyle.Underline);
        }
        else if (flag2)
          objectInfo.Appearance.HeaderCaption.Font = new Font(objectInfo.Appearance.HeaderCaption.Font.Name, (float)emSize, FontStyle.Italic);
        else
          objectInfo.Appearance.HeaderCaption.Font = new Font(objectInfo.Appearance.HeaderCaption.Font.Name, (float)emSize, FontStyle.Regular);
      }
      if (_ForeColor)
      {
        string ColorName = dataRowArray[0][_FieldForeColor].ToString().Trim();
        objectInfo.Appearance.HeaderCaption.ForeColor = CyberColor.GetForeColor(ColorName);
      }
      string ColorName1 = "";
      string ColorName2 = "";
      if (flag3)
        ColorName1 = dataRowArray[0][_FieldBackColor].ToString().Trim();
      if (flag4)
        ColorName2 = dataRowArray[0][columnName2].ToString().Trim();
      string str4 = "0";
      if (dataRowArray[0].Table.Columns.Contains("Flag"))
        str4 = dataRowArray[0]["Flag"].ToString().Trim();
      if (flag3 | flag4 | (str4.Trim() == "1") | (str4.Trim() == "2") | (str4.Trim() == "3") | (str4.Trim() == "4"))
      {
        if (flag3 | flag4)
        {
          AppearanceObject headerCaption = objectInfo.Appearance.HeaderCaption;
          SchedulerGroupType groupType = SchedulerControl.ActiveView.GroupType;
          bool flag5 = SchedulerControl.ActiveView is WeekView && groupType.Equals((object)SchedulerGroupType.Date) || SchedulerControl.ActiveView is TimelineView && !groupType.Equals((object)SchedulerGroupType.None);
          LinearGradientMode linearGradientMode = flag5 ? LinearGradientMode.Horizontal : LinearGradientMode.Vertical;
          if (ColorName1.Trim() == "")
            ColorName1 = "White";
          if (ColorName2.Trim() == "")
            ColorName2 = ColorName1;
          Rectangle rectangle = Rectangle.Inflate(e.Bounds, -2, -2);
          e.Cache.FillRectangle(new LinearGradientBrush(e.Bounds, CyberColor.GetBackColor(ColorName1), CyberColor.GetBackColor(ColorName2), linearGradientMode), rectangle);
          StringFormat stringFormat = headerCaption.TextOptions.GetStringFormat(TextOptions.DefaultOptionsCenteredWithEllipsis);
          if (flag5)
            e.Cache.DrawVString(objectInfo.Caption, headerCaption.Font, headerCaption.GetForeBrush(e.Cache), rectangle, stringFormat, 0);
          else
            e.Cache.DrawString(objectInfo.Caption, headerCaption.Font, headerCaption.GetForeBrush(e.Cache), rectangle, stringFormat);
        }
        if ((str4.Trim() == "1") | (str4.Trim() == "2") | (str4.Trim() == "3") | (str4.Trim() == "4"))
        {
          int num = Math.Min(16, objectInfo.ImageBounds.Height);
          ResourceHeader resourceHeader = objectInfo;
          Rectangle rectangle1 = new Rectangle(checked(objectInfo.ImageBounds.X + 2), objectInfo.ImageBounds.Y, num, num);
          Rectangle rectangle2 = rectangle1;
          resourceHeader.ImageBounds = rectangle2;
          string Left3 = str4;
          if (Left3 == "1")
          {
            Graphics graphics = e.Graphics;
            Bitmap flag1_1 = Properties.Resources.Warning;
            rectangle1 = new Rectangle(objectInfo.ImageBounds.X, objectInfo.ImageBounds.Y, num, num);
            Rectangle rect = rectangle1;
            graphics.DrawImage((Image)flag1_1, rect);
          }
          else if (Left3 == "2")
          {
            Graphics graphics = e.Graphics;
            Bitmap flag2_1 = Properties.Resources.Warning;
            rectangle1 = new Rectangle(objectInfo.ImageBounds.X, objectInfo.ImageBounds.Y, num, num);
            Rectangle rect = rectangle1;
            graphics.DrawImage((Image)flag2_1, rect);
          }
          else if (Left3 == "3")
          {
            Graphics graphics = e.Graphics;
            Bitmap flag3_1 = Properties.Resources.Warning;
            rectangle1 = new Rectangle(objectInfo.ImageBounds.X, objectInfo.ImageBounds.Y, num, num);
            Rectangle rect = rectangle1;
            graphics.DrawImage((Image)flag3_1, rect);
          }
          else if (Left3 == "4")
          {
            Graphics graphics = e.Graphics;
            Bitmap flag4_1 = Properties.Resources.Warning;
            rectangle1 = new Rectangle(objectInfo.ImageBounds.X, objectInfo.ImageBounds.Y, num, num);
            Rectangle rect = rectangle1;
            graphics.DrawImage((Image)flag4_1, rect);
          }
          else
          {
            Graphics graphics = e.Graphics;
            Bitmap flag1_2 = Properties.Resources.Warning;
            rectangle1 = new Rectangle(objectInfo.ImageBounds.X, objectInfo.ImageBounds.Y, num, num);
            Rectangle rect = rectangle1;
            graphics.DrawImage(flag1_2, rect);
            objectInfo.Image = Properties.Resources.Warning;
          }
        }
      }
      else
        e.DrawDefault();
      e.Handled = true;
    }
    #endregion

    #region "V_AddHander"
    private void V_Ma_Xe_Cho(object sender, EventArgs e)
    {
      int dataSourceRowIndex = MasterCho_RuaGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0)
        return;

      string _Stt_Rec = Dv_Cho_Rua[dataSourceRowIndex]["Stt_Rec"].ToString().Trim();
      if (_Stt_Rec.Trim() == "")
        return;

      V_Thuc_Hien(_Stt_Rec);
    }
    private void V_Ma_Xe_Dang_Rua(object sender, EventArgs e)
    {
      int dataSourceRowIndex = MasterDang_RuaGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0)
        return;

      string _Stt_Rec = Dv_Dang_Rua[dataSourceRowIndex]["Stt_Rec"].ToString().Trim();
      if (_Stt_Rec.Trim() == "")
        return;

      V_Thuc_Hien(_Stt_Rec);
    }
    private void V_Ma_Xe_Rua_Xong(object sender, EventArgs e)
    {
      int dataSourceRowIndex = MasterRua_XongGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0)
        return;

      V_Vi_Tri_Xe(Dv_Rua_Xong[dataSourceRowIndex]["Ma_Xe"].ToString().Trim());
    }
    private void V_Timer_Data_KH_RX(object sender, EventArgs e)
    {
      if (!Timer_Data.Enabled)
        return;

      V_LoadDatabases("0", "");
    }
    private void V_Ca_Ngay(object sender, EventArgs e)
    {
      V_CyberSetTime_KH_RX();
      V_Do_Rong_KH_RX(sender, e);
      V_LoadDatabases("0", "");
    }
    private void V_Kieu_Xem_RX(object sender, EventArgs e)
    {
      V_Kieu_Xem(CbbKieu_Xem.SelectedValue.ToString());
      V_SetScheduler_SetValue_RX();
    }
    private void V_Gio_Xem_RX(object sender, EventArgs e)
    {
      string Left = V_GetvalueCombox(CbbGio_Xem);
      if (Left == "01")
        V_ActiView_Gantt_RX(sender, e);
      if (Left != "02")
        return;

      V_ActiView_Day_RX(sender, e);
    }
    private void V_Ngay_Ct_KH(object sender, EventArgs e)
    {
      DataSet dataSet = new DataSet(); // CP_RO_CW_Ngay_Ngam_Dinh
      Dt_Set_SCC.Clear();
      Dt_Set_SCC.ImportRow(dataSet.Tables[0].Rows[0]);
      dataSet.Dispose();

      M_StartHour = Convert.ToInt32(Dt_Set_SCC.Rows[0]["StartHour"]);
      M_FinishHour = Convert.ToInt32(Dt_Set_SCC.Rows[0]["FinishHour"]);
      M_StartMINUTE = Convert.ToInt32(Dt_Set_SCC.Rows[0]["StartMINUTE"]);
      M_FinishMINUTE = Convert.ToInt32(Dt_Set_SCC.Rows[0]["FinishMINUTE"]);
      M_Ngay_LimitInterval_Min = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_LimitInterval_Min"]);
      M_Ngay_LimitInterval_Max_RX = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_LimitInterval_Max"]);
      M_Thu_Bay = Dt_Set_SCC.Rows[0]["Thu_Bay"].ToString().Trim();
      M_Chu_Nhat = Dt_Set_SCC.Rows[0]["Chu_Nhat"].ToString().Trim();
      SchedulerControl.LimitInterval.Start = M_Ngay_LimitInterval_Min;
      SchedulerControl.LimitInterval.End = M_Ngay_LimitInterval_Max_RX;
      SchedulerControl.Start = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_Ct"]);
      V_LoadDatabases("0", "");
      V_SetScheduler_SetValue_RX();
      V_SetScheduler_RXControl_KH_RX();
    }
    private void SchedulerControl_InitAppointmentImages(object sender, AppointmentImagesEventArgs e)
    {
      try
      {
        if (!Dt_Data.Columns.Contains("Uu_Tien"))
          return;

        string str1 = e.Appointment.Id.ToString().Trim();
        if (str1.Trim() == "")
          return;

        DataRow[] dataRowArray = Dt_Data.Select("Stt_Rec = '" + str1 + "'");
        if (dataRowArray.Length == 0)
          return;

        string str2 = "0";
        string str3 = "0";
        if (Dt_Data.Columns.Contains("Flag"))
          str2 = dataRowArray[0]["Flag"].ToString().Trim();
        if (Dt_Data.Columns.Contains("Uu_Tien"))
          str3 = dataRowArray[0]["Uu_Tien"].ToString().Trim();
        if (!(str2.Trim() == "1" | str2.Trim() == "2" | str2.Trim() == "3" | str2.Trim() == "4"))
          return;

        AppointmentImageInfo appointmentImageInfo = new AppointmentImageInfo();
        string Left = str2;
        appointmentImageInfo.Image = (Left != "1") ? Properties.Resources.Warning : 
                                     ((Left != "2") ? Properties.Resources.Warning : 
                                     ((Left != "3") ? Properties.Resources.Warning : 
                                     ((Left != "4") ? Properties.Resources.Warning : null))); // TODO
        e.ImageInfoList.Add(appointmentImageInfo);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
    private void SchedulerControl_CustomDrawTimeIndicator_RX(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
    {
      TimeIndicatorViewInfo objectInfo = (TimeIndicatorViewInfo)e.ObjectInfo;
      int num = checked(objectInfo.Items.Count - 1);
      int index = 0;
      while (index <= num)
      {
        TimeIndicatorBaseItem indicatorBaseItem = (TimeIndicatorBaseItem)objectInfo.Items[index];
        e.Cache.FillRectangle(Brushes.Red, indicatorBaseItem.Bounds);
        checked { ++index; }
      }
      e.Handled = true;
    }
    private void SchedulerControl_CustomDrawAppointmentBackground(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
    {
      if (!(e.ObjectInfo is AppointmentViewInfo objectInfo))
        return;
      try
      {
        string str = objectInfo.Appointment.Id.ToString().Trim();
        if (str.Trim() == "")
          return;

        DataRow[] dataRowArray = Dt_Data.Select("Stt_Rec = '" + str.ToString().Trim() + "'");
        if (!(_BorderColor_Data & dataRowArray.Length > 0) || dataRowArray[0][_FieldBorderColor_Data].ToString().Trim() == "")
          return;

        decimal d1 = 2M;
        if (Dt_Data.Columns.Contains("SizeBorder"))
          d1 = Convert.ToDecimal(dataRowArray[0]["SizeBorder"]);
        if (d1 < 2M)
          d1 = 2M;
        e.Handled = true;
        Rectangle bounds = e.Bounds;
        e.DrawDefault();
        e.Graphics.DrawRectangle(new Pen(CyberColor.GetBackColor(Convert.ToString(dataRowArray[0][_FieldBorderColor_Data])), Convert.ToSingle(d1)), bounds);
        e.Handled = true;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
    private void V_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e)
    {
      if (Dt_Data == null)
        return;

      int emSize = 0;
      string str1 = "";
      DataRow[] dataRowArray = null;
      try
      {
        str1 = e.ViewInfo.Appointment.Id.ToString().Trim();
        dataRowArray = Dt_Data.Select("Stt_Rec = '" + str1.ToString().Trim() + "'");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      if (str1.Trim() == "" || dataRowArray == null || dataRowArray.Length == 0)
        return;

      bool flag = false;
      if (Dt_Data.Columns.Contains("Italic"))
        flag = true;
      if (flag)
        flag = (dataRowArray[0]["Italic"].ToString().Trim() == "1");
      if (!_BackColor_Data & !_BackColor2_Data & !_ForeColor_Data & !_BorderColor_Data & !_Bold_Data & !_Underline_Data & !flag)
        return;
      try
      {
        if (_BackColor_Data)
          e.ViewInfo.Appearance.BackColor = CyberColor.GetBackColor(Convert.ToString(dataRowArray[0][_FieldBackColor_Data]));
        if (_BackColor2_Data && dataRowArray[0][_FieldBackColor2_Data].ToString().Trim() != "")
          e.ViewInfo.Appearance.BackColor2 = CyberColor.GetBackColor(Convert.ToString(dataRowArray[0][_FieldBackColor2_Data]));
        if (_ForeColor_Data)
          e.ViewInfo.Appearance.ForeColor = CyberColor.GetForeColor(Convert.ToString(dataRowArray[0][_FieldForeColor_Data]));
        if (_BorderColor_Data)
          e.ViewInfo.Appearance.BorderColor = CyberColor.GetBackColor(Convert.ToString(dataRowArray[0][_FieldBorderColor_Data]));

        string str2 = "0";
        string str3 = "0";
        if (Dt_Data.Columns.Contains("FontSize"))
          emSize = Convert.ToInt32(dataRowArray[0]["FontSize"]);
        if (emSize <= 0)
          emSize = checked((int)Math.Round((double)Font.Size));
        if (_Bold_Data && dataRowArray[0][_FieldBold_Data].ToString().Trim() == "1")
          str2 = "1";
        if (_Underline_Data && dataRowArray[0][_FieldUnderline_Data].ToString().Trim() == "1")
          str3 = "1";

        if (!(_Bold_Data | _Underline_Data | flag))
          return;

        if (str2.Trim() == "1")
        {
          if (str3.Trim() == "1")
          {
            if (flag)
              e.ViewInfo.Appearance.Font = new Font(Font.FontFamily, (float)emSize, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            else
              e.ViewInfo.Appearance.Font = new Font(Font.FontFamily, (float)emSize, FontStyle.Bold | FontStyle.Underline);
          }
          else if (flag)
            e.ViewInfo.Appearance.Font = new Font(Font.FontFamily, (float)emSize, FontStyle.Bold | FontStyle.Italic);
          else
            e.ViewInfo.Appearance.Font = new Font(Font.FontFamily, (float)emSize, FontStyle.Bold);
        }
        else if (str3.Trim() == "1")
        {
          if (flag)
            e.ViewInfo.Appearance.Font = new Font(Font.FontFamily, (float)emSize, FontStyle.Italic | FontStyle.Underline);
          else
            e.ViewInfo.Appearance.Font = new Font(Font.FontFamily, (float)emSize, FontStyle.Underline);
        }
        else if (flag)
          e.ViewInfo.Appearance.Font = new Font(Font.FontFamily, (float)emSize, FontStyle.Italic);
        else
          e.ViewInfo.Appearance.Font = new Font(Font.FontFamily, (float)emSize, FontStyle.Regular);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
    private void schedulerControl_CustomDrawDayHeader(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
    {
      DateTime date = DateTime.Now.Date;
      DateTime t2 = DateTime.Now.Date;
      t2 = t2.AddHours(23.0);
      t2 = t2.AddMinutes(59.0);
      SchedulerHeader objectInfo = e.ObjectInfo as SchedulerHeader;
      AppearanceObject headerCaption = objectInfo.Appearance.HeaderCaption;
      if (!(DateTime.Compare(objectInfo.Interval.Start, date) >= 0 & DateTime.Compare(objectInfo.Interval.Start, t2) <= 0 & DateTime.Compare(objectInfo.Interval.End, t2) > 0))
        return;
      if (e.Bounds.Height > 0 && e.Bounds.Width > 0)
      {
        e.Cache.FillRectangle(new LinearGradientBrush(e.Bounds, Color.FromArgb(175, 231, 228), Color.FromArgb(125, 181, 178), LinearGradientMode.Vertical), e.Bounds);
        Rectangle rectangle = Rectangle.Inflate(e.Bounds, -2, -2);
        e.Cache.FillRectangle((Brush)new LinearGradientBrush(e.Bounds, Color.FromArgb(125, 181, 178), Color.FromArgb(175, 231, 228), LinearGradientMode.Vertical), rectangle);
        StringFormat stringFormat = headerCaption.TextOptions.GetStringFormat(TextOptions.DefaultOptionsCenteredWithEllipsis);
        e.Cache.DrawString(objectInfo.Caption, headerCaption.Font, new SolidBrush(Color.Black), rectangle, stringFormat);
      }
      e.Handled = true;
    }
    private void SchedulerControl_KH_RX_AppointmentDrop(object sender, AppointmentDragEventArgs e)
    {
      bool flag = V_Update_Keo_Tha_KH_RX(e.EditedAppointment);
      e.Allow = flag;
    }
    private void SchedulerControl_KH_RX_AppointmentResized(object sender, AppointmentResizeEventArgs e)
    {
      bool flag = V_Update_Keo_Tha_KH_RX(e.EditedAppointment);
      e.Allow = flag;
      e.Handled = !flag;
    }
    private bool V_Update_Keo_Tha_KH_RX(Appointment _Appointment)
    {
      string _Stt_Rec = "";
      if (SchedulerControl.SelectedAppointments.Count > 0)
      {
        try
        {
          _Stt_Rec = SchedulerControl.SelectedAppointments[0].Id.ToString();
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
        }
      }
      if (_Stt_Rec.ToString().Trim() == "")
        return false;

      DateTime start = SchedulerControl.SelectedInterval.Start;
      DateTime end = SchedulerControl.SelectedInterval.End;
      string _Ma_khoang = "";
      string _ma_khoangOld = "";
      V_GetFromSetScheduler_RX(ref _Ma_khoang, ref start, ref end, _Appointment);
      V_GetFromSetScheduler_RXOld(ref _ma_khoangOld, _Appointment);

      DataSet dataSet = new DataSet(); // CP_RO_CW_Save_Keo_Tha
      bool flag = (dataSet.Tables[0] != null);
      dataSet.Dispose();
      if (flag)
        V_LoadDatabases("0", _Stt_Rec);

      return flag;
    }
    private void V_GetFromSetScheduler_RXOld(ref string _ma_khoangOld, Appointment _Appointment = null)
    {
      Appointment selectedAppointment = SchedulerControl.SelectedAppointments[0];
      DataRowView dataRowView = null;
      try
      {
        dataRowView = !(selectedAppointment.Type == AppointmentType.Normal | selectedAppointment.Type == AppointmentType.Pattern) ? 
          (DataRowView)SchedulerControl.SelectedAppointments[0].RecurrencePattern.GetSourceObject(SchedulerControl.Storage) : 
          (DataRowView)SchedulerControl.SelectedAppointments[0].GetSourceObject(SchedulerControl.Storage);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      if (dataRowView == null || !Dt_Data.Columns.Contains("ma_khoang"))
        return;
      _ma_khoangOld = dataRowView["Ma_khoang"].ToString().Trim();
    }
    private void V_GetFromSetScheduler_RX(ref string _Ma_khoang, ref DateTime _Ngay_BD, ref DateTime _Ngay_KT, Appointment _Appointment = null)
    {
      _Ngay_BD = DateTime.Now.Date;
      _Ngay_KT = DateTime.Now.Date;
      if (_Appointment == null)
      {
        _Ngay_BD = SchedulerControl.SelectedInterval.Start;
        _Ngay_KT = SchedulerControl.SelectedInterval.End;
      }
      else
      {
        _Ngay_BD = _Appointment.Start;
        _Ngay_KT = _Appointment.End;
      }

      string str = GetvalueSelectedResource_RX(_Appointment);
      if (str.ToUpper().Trim() == "DevExpress.XtraScheduler.EmptyResourceId".ToUpper().Trim())
        str = "";
      _Ma_khoang = str;
    }
    private string GetvalueSelectedResource_RX(Appointment _Appointment = null)
    {
      string str = "";
      try
      {
        str = _Appointment != null ? _Appointment.ResourceId.ToString() : SchedulerControl.SelectedResource.Id.ToString().Trim().ToUpper().Trim();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      if (str.ToUpper().Trim() == "DevExpress.XtraScheduler.EmptyResourceId".ToUpper().Trim())
        str = "";
      if (str.ToUpper().Trim().Contains("DevExpress.XtraScheduler".ToUpper().Trim()))
        str = "";

      return str;
    }
    private void V_Lap_F3F4_KH_RX(object sender, AppointmentFormEventArgs e) => e.Handled = true;
    private void V_PopupMenu_RX(object sender, DevExpress.XtraScheduler.PopupMenuShowingEventArgs e)
    {
      SchedulerControl schedulerControl = (SchedulerControl)sender;
      string str = "";
      if (schedulerControl.SelectedAppointments.Count > 0)
      {
        try
        {
          str = schedulerControl.SelectedAppointments[0].Id.ToString();
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
        }
      }

      e.Menu.Items.Clear();
      int rowHandle = 0;
      PopupMenuSchedulerControl.ItemLinks.Clear();
      PopupMenuSchedulerControl.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Bắt đầu/Kết thúc rửa xe", new EventHandler(V_BD_KT), Shortcut.F10, null, true), false);
      PopupMenuSchedulerControl.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Tạo KH rửa", new EventHandler(V_Tao_KH_Scheduler), Shortcut.F4, null, true), true);
      PopupMenuSchedulerControl.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Sửa KH rửa", new EventHandler(V_Sua_KH_Scheduler), Shortcut.F3, null, true), false);
      PopupMenuSchedulerControl.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Xóa KH", new EventHandler(V_Xoa_KH_Scheduler), Shortcut.F8, null, true), false);
      PopupMenuSchedulerControl.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Xem lệnh", new EventHandler(V_Preview_RX), Shortcut.F7, null, true), true);
      PopupMenuSchedulerControl.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Làm tươi dữ liệu", new EventHandler(V_RefreshData_KH_RX), Shortcut.F5, null, true), false);
      
      CyberBarSubMenuPopup cyberBarSubMenuPopup = new CyberBarSubMenuPopup(sender, rowHandle, "Tùy chọn", (EventHandler)null, null);
      PopupMenuSchedulerControl.ItemLinks.Add(cyberBarSubMenuPopup, true);
      CyberMenuPopup cyberMenuPopup1 = new CyberMenuPopup(sender, rowHandle, "Theo cầu", new EventHandler(V_ActiView_Day_RX));
      CyberMenuPopup cyberMenuPopup2 = new CyberMenuPopup(sender, rowHandle, "Thời gian", new EventHandler(V_ActiView_Gantt_RX));
      cyberBarSubMenuPopup.AddItem(cyberMenuPopup1).BeginGroup = false;
      cyberBarSubMenuPopup.AddItem(cyberMenuPopup2).BeginGroup = false;

      PopupMenuSchedulerControl.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Quay ra", new EventHandler(V_Quay_Ra), Shortcut.None, null, true), true);

      if (e == null)
        return;
      PopupMenuSchedulerControl.ShowPopup(MousePosition);
    }
    private void MasterCho_RuaGRV_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
    {
      int rowHandle = e != null ? e.HitInfo.RowHandle : -1;
      PopupMenuCho_Rua.ItemLinks.Clear();
      PopupMenuCho_Rua.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Bắt đầu/Kết thúc rửa xe", new EventHandler(V_BD_KT_Cho_Rua), Shortcut.F10, null, true), false);
      PopupMenuCho_Rua.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Tạo KH rửa", new EventHandler(V_Tao_Cho_Rua), Shortcut.F4, null, true), true);
      PopupMenuCho_Rua.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Sửa KH rửa", new EventHandler(V_Sua_Cho_Rua), Shortcut.F3, null, true), false);
      PopupMenuCho_Rua.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Xóa KH", new EventHandler(V_Xoa_Cho_Rua), Shortcut.F8, null, true), false);
      PopupMenuCho_Rua.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Xem lệnh", new EventHandler(V_Preview_Cho_Rua), Shortcut.F7, null, true), true);
      PopupMenuCho_Rua.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Làm tươi dữ liệu", new EventHandler(V_RefreshData_KH_RX), Shortcut.F5, null, true), false);
      PopupMenuCho_Rua.ItemLinks.Add(new CyberMenuPopup(sender, rowHandle, "Quay ra", new EventHandler(V_Quay_Ra), null, true), true);
      PopupMenuCho_Rua.ShowPopup(MousePosition);
      if (e == null)
        return;
      PopupMenuCho_Rua.ShowPopup(MousePosition);
    }
    private void MasterDang_Rua_KHGRV_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
    {
      int rowHandle = e != null ? e.HitInfo.RowHandle : -1;
      PopupMenuDang_Rua.ItemLinks.Clear();
      PopupMenuDang_Rua.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Bắt đầu/Kết thúc rửa xe", new EventHandler(V_BD_KT_Dang_Rua), Shortcut.F10, null, true), false);
      PopupMenuDang_Rua.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Xem lệnh", new EventHandler(V_Preview_Dang_Rua), Shortcut.F7, null, true), true);
      PopupMenuDang_Rua.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Làm tươi dữ liệu", new EventHandler(V_RefreshData_KH_RX), Shortcut.F5, null, true), false);
      PopupMenuDang_Rua.ItemLinks.Add(new CyberMenuPopup(sender, rowHandle, "Quay ra", new EventHandler(V_Quay_Ra), null, true), true);
      PopupMenuDang_Rua.ShowPopup(MousePosition);
      if (e == null)
        return;
      PopupMenuDang_Rua.ShowPopup(MousePosition);
    }
    private void MasterRua_Xong_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
    {
      int rowHandle = e != null ? e.HitInfo.RowHandle : -1;
      PopupMenuRua_Xong.ItemLinks.Clear();
      PopupMenuRua_Xong.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Đặt vị trí xe", new EventHandler(V_Vi_Tri_Xe), Shortcut.F4, null, true), false);
      PopupMenuRua_Xong.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Xem vị trí xe", new EventHandler(V_Vi_Tri_Xe_Load), Shortcut.F10, null, true), false);
      PopupMenuRua_Xong.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Giao xe", new EventHandler(V_Giao_Xe), Shortcut.F3, null, true), false);
      PopupMenuRua_Xong.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Xem lệnh", new EventHandler(V_Preview_Rua_Xong), Shortcut.F7, null, true), true);
      PopupMenuRua_Xong.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Làm tươi dữ liệu", new EventHandler(V_RefreshData_KH_RX), Shortcut.F5, null, true), false);
      PopupMenuRua_Xong.ItemLinks.Add(new CyberMenuPopup(sender, rowHandle, "Quay ra", new EventHandler(V_Quay_Ra), null, true), true);
      PopupMenuRua_Xong.ShowPopup(MousePosition);
      if (e == null)
        return;
      PopupMenuRua_Xong.ShowPopup(MousePosition);
    }
    private void MasterCho_RuaGRV_RowCellStyle(object sender, RowCellStyleEventArgs e) => 
      GRV_RowCellStyle2(sender, e, MasterCho_RuaGRV, _Bold_Cho_KH, _BackColor_Cho_KH, _BackColor2_Cho_KH, _ForeColor_Cho_KH, 
        _Underline_Cho_KH, _FieldBold_Cho_KH, _FieldBackColor_Cho_KH, _FieldBackColor2_Cho_KH, 
        _FieldForeColor_Cho_KH, _FieldUnderline_Cho_KH);
    private void MasterDang_Rua_KHGRV_RowCellStyle(object sender, RowCellStyleEventArgs e) => 
      GRV_RowCellStyle2(sender, e, MasterDang_RuaGRV, _Bold_Dang_Rua_KH, _BackColor_Dang_Rua_KH, _BackColor2_Dang_Rua_KH, 
        _ForeColor_Dang_Rua_KH, _Underline_Dang_Rua_KH, _FieldBold_Dang_Rua_KH, _FieldBackColor_Dang_Rua_KH, 
        _FieldBackColor2_Dang_Rua_KH, _FieldForeColor_Dang_Rua_KH, _FieldUnderline_Dang_Rua_KH);
    private void MasterRua_Xong_RowCellStyle(object sender, RowCellStyleEventArgs e) => 
      GRV_RowCellStyle2(sender, e, MasterRua_XongGRV, _Bold_Rua_Xong_KH, _BackColor_Rua_Xong_KH, _BackColor2_Rua_Xong_KH, 
        _ForeColor_Rua_Xong_KH, _Underline_Rua_Xong_KH, _FieldBold_Rua_Xong_KH, _FieldBackColor_Rua_Xong_KH, 
        _FieldBackColor2_Rua_Xong_KH, _FieldForeColor_Rua_Xong_KH, _FieldUnderline_Rua_Xong_KH);
    private void GRV_RowCellStyle2(object sender, RowCellStyleEventArgs e, GridView _GRV, bool _Bold, bool _BackColor, bool _BackColor2, bool _Forecolor, bool _UnderLine, string _FieldBold, string _FieldBackColor, string _FieldBackColor2, string _FieldForecolor, string _FieldUnderline)
    {
      e.Appearance.BackColor = System.Drawing.Color.Silver;
    }
    private void ResourcesTree1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
    {
      if (!resourcesTree1.Visible)
        return;

      DataView dataSource = (DataView)SchedulerStorage.Resources.DataSource;
      if (dataSource == null)
        return;

      int nodeIndex = resourcesTree1.GetNodeIndex(e.Node);
      bool flag1 = false;
      bool flag2 = false;
      string str1 = "0";
      if (dataSource.Table.Columns.Contains("Bold_Cot"))
        str1 = dataSource[nodeIndex]["Bold_Cot"].ToString().Trim();
      else if (dataSource.Table.Columns.Contains("Bold"))
        str1 = dataSource[nodeIndex]["Bold"].ToString().Trim();
      if (str1.Trim() == "1")
        flag2 = true;
      bool flag3 = false;
      string str2 = "0";
      if (dataSource.Table.Columns.Contains("Underline_Cot"))
        str2 = dataSource[nodeIndex]["Underline_Cot"].ToString().Trim();
      else if (dataSource.Table.Columns.Contains("Underline"))
        str2 = dataSource[nodeIndex]["Underline"].ToString().Trim();
      if (str2.Trim() == "1")
        flag3 = true;

      if (flag2)
      {
        if (flag3)
          e.Appearance.Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold | FontStyle.Underline);
        else
          e.Appearance.Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
      }
      else if (flag3)
        e.Appearance.Font = new Font(Font.FontFamily, Font.Size, FontStyle.Underline);
      else
        e.Appearance.Font = new Font(Font.FontFamily, Font.Size, FontStyle.Regular);

      if (dataSource.Table.Columns.Contains("BackColor_Cot"))
      {
        Brush brush = new SolidBrush(CyberColor.GetBackColor(Convert.ToString(dataSource[nodeIndex]["BackColor_Cot"])));
        e.Cache.FillRectangle(brush, e.Bounds);
        flag1 = true;
      }
      else if (dataSource.Table.Columns.Contains("BackColor"))
      {
        e.Appearance.BackColor = CyberColor.GetBackColor(Convert.ToString(dataSource[nodeIndex]["BackColor"]));
        flag1 = true;
      }

      if (dataSource.Table.Columns.Contains("ForeColor_Cot"))
      {
        Brush foreBrush = new SolidBrush(CyberColor.GetForeColor(Convert.ToString(dataSource[nodeIndex]["ForeColor_Cot"])));
        e.Cache.DrawString(e.CellText, e.Appearance.Font, foreBrush, e.Bounds, e.Appearance.GetStringFormat());
        flag1 = true;
      }
      else
      {
        if (!dataSource.Table.Columns.Contains("ForeColor"))
          return;
        e.Appearance.ForeColor = CyberColor.GetForeColor(Convert.ToString(dataSource[nodeIndex]["ForeColor"]));
      }
    }
    private void ResourcesTree1_DoubleClick(object sender, EventArgs e)
    {
      if (!resourcesTree1.Visible)
        return;

      DataView dataSource = (DataView)SchedulerStorage.Resources.DataSource;
      if (dataSource == null || !dataSource.Table.Columns.Contains("Stt_Rec"))
        return;

      int recordIndex = -1;
      try
      {
        recordIndex = resourcesTree1.FocusedNode.Id;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }

      string _Stt_Rec = "";
      if (recordIndex >= 0)
        _Stt_Rec = dataSource[recordIndex]["Stt_Rec"].ToString().Trim();
      if (_Stt_Rec.Trim() == "")
        return;

      V_Thuc_Hien(_Stt_Rec);
    }
    private void ResourcesTree1_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
    {
      PopupMenuCho_Rua.ItemLinks.Clear();
      PopupMenuCho_Rua.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Cập nhập màu xe/Kiểu xe", new EventHandler(V_Nhap_Mau_Xe_Tree), Shortcut.F4, null, true), false);
      PopupMenuCho_Rua.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Làm tươi dữ liệu", new EventHandler(V_RefreshData_KH_RX), Shortcut.F5, null, true), false);
      PopupMenuCho_Rua.ItemLinks.Add(new CyberMenuPopup(sender, 0, "Quay ra", new EventHandler(V_Quay_Ra), null, true));
      PopupMenuCho_Rua.ShowPopup(MousePosition);
      if (e == null)
        return;
      PopupMenuCho_Rua.ShowPopup(MousePosition);
    }
    private void V_Nhap_Mau_Xe_Tree(object sender, EventArgs e)
    {
      DataView dataSource = (DataView)SchedulerStorage.Resources.DataSource;
      if (dataSource == null || !dataSource.Table.Columns.Contains("Stt_Rec"))
        return;
      int recordIndex = -1;
      try
      {
        recordIndex = resourcesTree1.FocusedNode.Id;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      string str1 = "";
      string str2 = "";
      if (recordIndex >= 0)
        str1 = dataSource[recordIndex]["Stt_Rec"].ToString().Trim();
      if (recordIndex >= 0)
        str2 = dataSource[recordIndex]["Ma_Xe"].ToString().Trim();
    }
    #endregion

    #region "V_PopupMenu_RX"
    private void V_BD_KT(object sender, EventArgs e)
    {
      string _Stt_Rec = "";
      if (SchedulerControl.SelectedAppointments.Count > 0)
      {
        try
        {
          _Stt_Rec = SchedulerControl.SelectedAppointments[0].Id.ToString();
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
        }
      }

      if (_Stt_Rec.ToString().Trim() == "")
        return;

      V_Thuc_Hien(_Stt_Rec);
    }
    private void V_Tao_KH_Scheduler(object sender, EventArgs e)
    {
      string _Mode = "M";
      string _Stt_Rec = "";
      DateTime start = SchedulerControl.SelectedInterval.Start;
      DateTime end = SchedulerControl.SelectedInterval.End;
      string _Ma_khoang = SchedulerControl.SelectedResource.Id.ToString().Trim();
      V_GetFromSetScheduler(ref start, ref end, ref _Ma_khoang);

      int integer = Convert.ToInt32(CbbMa_BN.SelectedValue);
      DataTable dataTable = CP_RO_CW_Execute.CreateData().Tables[0]; // TODO: Ma_Xe, So_Ro, Stt_Rec, Ma_Ct (CyberProgress.V_KH_CW)
      if (dataTable == null || dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("Stt_Rec") || dataTable.Rows[0]["Stt_Rec"].ToString().Trim() == "")
        return;

      V_LoadDatabases("0", dataTable.Rows[0]["Stt_Rec"].ToString().Trim());
    }
    private void V_Sua_KH_Scheduler(object sender, EventArgs e)
    {
      string _Mode = "S";
      string _Stt_Rec = "";
      if (SchedulerControl.SelectedAppointments.Count > 0)
      {
        try
        {
          _Stt_Rec = SchedulerControl.SelectedAppointments[0].Id.ToString();
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
        }
      }
      if (_Stt_Rec.ToString().Trim() == "")
        return;

      string _Ma_Khoang = "";
      DateTime _Ngay_BD = DateTime.Now;
      DateTime _Ngay_KT = DateTime.Now;
      DataRow[] dataRowArray = Dt_Data.Select("Stt_Rec = '" + _Stt_Rec + "'");
      if (dataRowArray.Length > 0)
      {
        _Ma_Khoang = dataRowArray[0]["Ma_khoang"].ToString().Trim();
        _Ngay_BD = Convert.ToDateTime(dataRowArray[0]["Ngay_Bd"]);
        _Ngay_KT = Convert.ToDateTime(dataRowArray[0]["Ngay_KT"]);
      }
      int integer = Convert.ToInt32(CbbMa_BN.SelectedValue);
      DataTable dataTable = CP_RO_CW_Execute.CreateData().Tables[0]; // TODO: Ma_Xe, So_Ro, Stt_Rec, Ma_Ct (CyberProgress.V_KH_CW)
      if (dataTable == null || dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("Stt_Rec") || dataTable.Rows[0]["Stt_Rec"].ToString().Trim() == "")
        return;

      V_LoadDatabases("0", dataTable.Rows[0]["Stt_Rec"].ToString().Trim());
    }
    private void V_Xoa_KH_Scheduler(object sender, EventArgs e)
    {
      object Right = null;
      if (SchedulerControl.SelectedAppointments.Count > 0)
      {
        try
        {
          Right = SchedulerControl.SelectedAppointments[0].Id;
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
        }
      }
      if (Right.ToString().Trim() == "" || !FormGlobals.Message_Confirm("Bạn có chắc chắn xóa không?", false))
        return;

      DataSet dataSet = new DataSet(); // CP_RO_CW_Delete
      if (dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0)
        dataSet.Dispose();
      else
      {
        int index1 = checked(Dt_Data.Rows.Count - 1);
        while (index1 >= 0)
        {
          if (Dt_Data.Rows[index1]["Stt_Rec"] == Right)
            Dt_Data.Rows[index1].Delete();
          checked { index1 += -1; }
        }
        Dt_Data.AcceptChanges();

        int index2 = checked(Dt_Cho_Rua.Rows.Count - 1);
        while (index2 >= 0)
        {
          if (Dt_Cho_Rua.Rows[index2]["Stt_Rec"] == Right)
            Dt_Cho_Rua.Rows[index2].Delete();
          checked { index2 += -1; }
        }
        Dt_Cho_Rua.AcceptChanges();

        int index3 = checked(Dt_Rua_Xong.Rows.Count - 1);
        while (index3 >= 0)
        {
          if (Dt_Rua_Xong.Rows[index3]["Stt_Rec"] == Right)
            Dt_Rua_Xong.Rows[index3].Delete();
          checked { index3 += -1; }
        }
        Dt_Rua_Xong.AcceptChanges();

        dataSet.Dispose();
      }
    }
    private void V_Preview_RX(object sender, EventArgs e)
    {
    }
    private void V_ActiView_Day_RX(object sender, EventArgs e)
    {
      SchedulerControl.ActiveViewType = SchedulerViewType.Day;
      SchedulerControl.DayView.ShowDayHeaders = false;
      V_CyberSetTime_KH_RX();
      SchedulerControl.OptionsView.ResourceHeaders.Height = 30;
    }
    private void V_ActiView_Gantt_RX(object sender, EventArgs e)
    {
      SchedulerControl.ActiveViewType = SchedulerViewType.Gantt;
      V_CyberSetTime_KH_RX();
      SchedulerControl.OptionsView.ResourceHeaders.Height = 80;
    }
    #endregion

    #region "MasterCho_RuaGRV_PopupMenuShowing"
    private void V_BD_KT_Cho_Rua(object sender, EventArgs e)
    {
      if (!Dt_Cho_Rua.Columns.Contains("Stt_Rec"))
        return;

      int dataSourceRowIndex = MasterCho_RuaGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0)
        return;

      string _Stt_Rec = Convert.ToString(Dv_Cho_Rua[dataSourceRowIndex]["Stt_Rec"]);
      if (_Stt_Rec.ToString().Trim() == "")
        return;

      V_Thuc_Hien(_Stt_Rec);
    }
    private void V_Tao_Cho_Rua(object sender, EventArgs e)
    {
      string _Mode = "M";
      string _Stt_Rec = "";
      string _Ma_khoang = "";
      DateTime _Ngay_BD = default;
      DateTime _Ngay_KT1 = default;
      V_GetFromSetScheduler(ref _Ngay_BD, ref _Ngay_KT1, ref _Ma_khoang);

      DateTime now = DateTime.Now;
      DateTime _Ngay_KT2 = now.AddMinutes(10.0);
      int integer = Convert.ToInt32(CbbMa_BN.SelectedValue);
      DataTable dataTable = CP_RO_CW_Execute.CreateData().Tables[0]; // TODO: Ma_Xe, So_Ro, Stt_Rec, Ma_Ct (CyberProgress.V_KH_CW)
      if (dataTable == null || dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("Stt_Rec") || (dataTable.Rows[0]["Stt_Rec"].ToString().Trim() == ""))
        return;
      V_LoadDatabases("0", dataTable.Rows[0]["Stt_Rec"].ToString().Trim());
    }
    private void V_Sua_Cho_Rua(object sender, EventArgs e)
    {
      if (!Dt_Cho_Rua.Columns.Contains("Stt_Rec"))
        return;

      int dataSourceRowIndex = MasterCho_RuaGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0)
        return;

      string _Mode = "S";
      string _Stt_Rec = Convert.ToString(Dv_Cho_Rua[dataSourceRowIndex]["Stt_Rec"]);
      if (_Stt_Rec.ToString().Trim() == "")
        return;

      string _Ma_Khoang = "";
      DateTime _Ngay_BD = DateTime.Now;
      DateTime _Ngay_KT = DateTime.Now;
      DataRow[] dataRowArray = Dt_Data.Select("Stt_Rec = '" + _Stt_Rec + "'");
      if (dataRowArray.Length > 0)
      {
        _Ma_Khoang = dataRowArray[0]["Ma_khoang"].ToString().Trim();
        _Ngay_BD = Convert.ToDateTime(dataRowArray[0]["Ngay_Bd"]);
        _Ngay_KT = Convert.ToDateTime(dataRowArray[0]["Ngay_KT"]);
      }
      int integer = Convert.ToInt32(CbbMa_BN.SelectedValue);
      DataTable dataTable = CP_RO_CW_Execute.CreateData().Tables[0]; // TODO: Ma_Xe, So_Ro, Stt_Rec, Ma_Ct (CyberProgress.V_KH_CW)
      if (dataTable == null || dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("Stt_Rec") || (dataTable.Rows[0]["Stt_Rec"].ToString().Trim() == ""))
        return;

      V_LoadDatabases("0", dataTable.Rows[0]["Stt_Rec"].ToString().Trim());
    }
    private void V_Xoa_Cho_Rua(object sender, EventArgs e)
    {
      if (!Dt_Cho_Rua.Columns.Contains("Stt_Rec"))
        return;

      int dataSourceRowIndex = MasterCho_RuaGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0)
        return;

      object Right = Dv_Cho_Rua[dataSourceRowIndex]["Stt_Rec"];
      if (Right.ToString().Trim() == "" || !FormGlobals.Message_Confirm("Bạn có chắc chắn xóa không?", false))
        return;

      DataSet dataSet = new DataSet(); // CP_RO_CW_Delete"
      if (dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0)
        dataSet.Dispose();
      else
      {
        int index1 = checked(Dt_Data.Rows.Count - 1);
        while (index1 >= 0)
        {
          if (Dt_Data.Rows[index1]["Stt_Rec"] == Right)
            Dt_Data.Rows[index1].Delete();
          checked { index1 += -1; }
        }
        Dt_Data.AcceptChanges();

        int index2 = checked(Dt_Cho_Rua.Rows.Count - 1);
        while (index2 >= 0)
        {
          if (Dt_Cho_Rua.Rows[index2]["Stt_Rec"] == Right)
            Dt_Cho_Rua.Rows[index2].Delete();
          checked { index2 += -1; }
        }
        Dt_Cho_Rua.AcceptChanges();

        int index3 = checked(Dt_Rua_Xong.Rows.Count - 1);
        while (index3 >= 0)
        {
          if (Dt_Rua_Xong.Rows[index3]["Stt_Rec"] == Right)
            Dt_Rua_Xong.Rows[index3].Delete();
          checked { index3 += -1; }
        }
        Dt_Rua_Xong.AcceptChanges();

        dataSet.Dispose();
      }
    }
    private void V_Preview_Cho_Rua(object sender, EventArgs e)
    {
    }
    private void V_RefreshData_KH_RX(object sender, EventArgs e) => V_LoadDatabases("0", "");
    private void V_Quay_Ra(object sender, EventArgs e) => Close();
    private bool V_Thuc_Hien(string _Stt_Rec)
    {
      if (_Stt_Rec.Trim() == "")
        return false;

      DataSet dataSet = CP_RO_CW_Execute.CreateData(); // TODO: CP_RO_CW_BD_KT: status (Y/N), Msg (Y/N), Note
      bool flag = (dataSet.Tables[0] != null);
      if (flag)
        V_LoadDatabases("0", _Stt_Rec);

      return flag;
    }
    private void V_GetFromSetScheduler(ref DateTime _Ngay_BD, ref DateTime _Ngay_KT, ref string _Ma_khoang, Appointment _Appointment = null)
    {
      string Left = V_GetvalueCombox(CbbKieu_Xem);
      _Ngay_BD = DateTime.Now.Date;
      _Ngay_KT = DateTime.Now.Date;
      _Ma_khoang = "";

      if (_Appointment == null)
      {
        _Ngay_BD = SchedulerControl.SelectedInterval.Start;
        _Ngay_KT = SchedulerControl.SelectedInterval.End;
      }
      else
      {
        _Ngay_BD = _Appointment.Start;
        _Ngay_KT = _Appointment.End;
      }
      string str1 = GetvalueSelectedResource(_Appointment);
      if (str1.ToUpper().Trim() == "DevExpress.XtraScheduler.EmptyResourceId".ToUpper().Trim())
        str1 = "";
      string str2 = str1.Replace("_THUCHIEN", "");
      if (Left == "01")
        _Ma_khoang = str2;
      else
        _Ma_khoang = "";
    }
    private string GetvalueSelectedResource(Appointment _Appointment = null)
    {
      string str = "";
      try
      {
        str = _Appointment != null ? _Appointment.ResourceId.ToString() : SchedulerControl.SelectedResource.Id.ToString().Trim().ToUpper().Trim();
      }
      catch (Exception)
      {
      }
      if (str.ToUpper().Trim() == "DevExpress.XtraScheduler.EmptyResourceId")
        str = "";
      if (str.ToUpper().Trim().Contains("DevExpress.XtraScheduler".ToUpper().Trim()))
        str = "";
      return str;
    }
    #endregion

    #region "MasterDang_Rua_KHGRV_PopupMenuShowing"
    private void V_BD_KT_Dang_Rua(object sender, EventArgs e)
    {
      if (!Dt_Dang_Rua.Columns.Contains("Stt_Rec"))
        return;

      int dataSourceRowIndex = MasterDang_RuaGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0)
        return;

      string _Stt_Rec = Convert.ToString(Dv_Dang_Rua[dataSourceRowIndex]["Stt_Rec"]);
      if (_Stt_Rec.ToString().Trim() == "")
        return;

      V_Thuc_Hien(_Stt_Rec);
    }
    private void V_Preview_Dang_Rua(object sender, EventArgs e)
    {
    }
    #endregion

    #region "MasterRua_Xong_PopupMenuShowing"
    private void V_Vi_Tri_Xe(object sender, EventArgs e)
    {
    }
    private void V_Vi_Tri_Xe_Load(object sender, EventArgs e)
    {
      if (!Dt_Rua_Xong.Columns.Contains("Ma_Xe"))
        return;

      int dataSourceRowIndex = MasterRua_XongGRV.GetFocusedDataSourceRowIndex();
      string _Ma_Xe = "";
      if (dataSourceRowIndex >= 0)
        _Ma_Xe = Convert.ToString(Dv_Rua_Xong[dataSourceRowIndex]["Ma_Xe"]);

      V_Vi_Tri_Xe(_Ma_Xe);
    }
    private void V_Vi_Tri_Xe(string _Ma_Xe)
    {
    }
    private void V_Preview_Rua_Xong(object sender, EventArgs e)
    {

    }
    private void V_Giao_Xe(object sender, EventArgs e)
    {
      if (!Dt_Rua_Xong.Columns.Contains("Stt_Rec"))
        return;

      int dataSourceRowIndex = MasterRua_XongGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0)
        return;

      string _Stt_Rec = Convert.ToString(Dv_Rua_Xong[dataSourceRowIndex]["Stt_Rec"]);
      if (_Stt_Rec.ToString().Trim() == "")
        return;

      DataSet dataSet = new DataSet(); // CP_RO_CW_Giai_phong
      if (dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count == 0)
        dataSet.Dispose();
      else
      {
        dataSet.Dispose();
        V_LoadDatabases("0", _Stt_Rec);
      }
    }
    #endregion

    #region "V_Load"
    private void V_Kieu_Xem(string _Kieu_Xem)
    {
      if (_Kieu_Xem == "02")
        CbbGio_Xem.SelectedValue = "01";

      CbbGio_Xem.Enabled = (_Kieu_Xem == "01");
    }
    private void V_LoadDatabases(string status, string _Stt_Rec)
    {
      SchedulerStorage.Appointments.AutoReload = false;
      SchedulerStorage.BeginUpdate();

      DateTime date = Convert.ToDateTime(TxtM_Ngay_Ct.EditValue);
      string str = CbbCa_Ngay.SelectedValue.ToString();

      DataSet dataSet = CP_RO_CW_Data.CreateData(); // CP_RO_CW_Data
      int num = checked(dataSet.Tables.Count - 1);
      int index = 0;
      while (index <= num)
      {
        SetNotNullTable(dataSet.Tables[index]);
        checked { ++index; }
      }

      if (status == "1")
      {
        Dt_Cho_Rua = null;
        Dt_Data = null;
        Dt_Dang_Rua = null;
        Dt_Rua_Xong = null;
        Dt_Cho_Rua_H = null;
        Dt_Dang_Rua_H = null;
        Dt_Rua_Xong_H = null;

        Dt_Cho_Rua = dataSet.Tables[0].Copy();
        Dv_Cho_Rua = new DataView(Dt_Cho_Rua);
        if (Dt_Cho_Rua.Columns.Contains("Stt"))
          Dv_Cho_Rua.Sort = Dt_Cho_Rua.Columns["Stt"].ColumnName;

        Dt_Data = dataSet.Tables[1].Copy();
        Dv_Data = new DataView(Dt_Data);
        if (Dt_Data.Columns.Contains("Stt"))
          Dv_Data.Sort = Dt_Data.Columns["Stt"].ColumnName;

        Dt_Dang_Rua = dataSet.Tables[2].Copy();
        Dv_Dang_Rua = new DataView(Dt_Dang_Rua);
        if (Dt_Dang_Rua.Columns.Contains("Stt"))
          Dv_Dang_Rua.Sort = Dt_Dang_Rua.Columns["Stt"].ColumnName;

        Dt_Rua_Xong = dataSet.Tables[3].Copy();
        Dv_Rua_Xong = new DataView(Dt_Rua_Xong);
        if (Dt_Rua_Xong.Columns.Contains("Stt"))
          Dv_Rua_Xong.Sort = Dt_Rua_Xong.Columns["Stt"].ColumnName;

        Dt_Data_Xe = dataSet.Tables[4].Copy();
        Dv_Data_Xe = new DataView(Dt_Data_Xe);
        if (Dt_Data_Xe.Columns.Contains("Stt"))
          Dv_Data_Xe.Sort = Dt_Cho_Rua.Columns["Stt"].ColumnName;

        Dt_Cho_Rua_H = dataSet.Tables[5].Copy();
        Dt_Dang_Rua_H = dataSet.Tables[6].Copy();
        Dt_Rua_Xong_H = dataSet.Tables[7].Copy();

        if (dataSet.Tables.Count > 8)
        {
          Dt_Xe_H = dataSet.Tables[8].Copy();
        }
        if (dataSet.Tables.Count > 9)
          V_SetSortView(ref Dv_Cho_Rua, dataSet.Tables[9]);
        if (dataSet.Tables.Count > 10)
          V_SetSortView(ref Dv_Data, dataSet.Tables[10]);
        if (dataSet.Tables.Count > 11)
          V_SetSortView(ref Dv_Dang_Rua, dataSet.Tables[11]);
        if (dataSet.Tables.Count > 12)
          V_SetSortView(ref Dv_Rua_Xong, dataSet.Tables[12]);

        MasterCho_Rua.DataSource = Dv_Cho_Rua;
        MasterCho_RuaGRV.GridControl = MasterCho_Rua;
        MasterCho_RuaGRV.OptionsView.ShowViewCaption = false;
        MasterCho_RuaGRV.OptionsSelection.MultiSelect = false;
        MasterCho_RuaGRV.Appearance.SelectedRow.BackColor = Color.YellowGreen;
        CyberColor.V_GetColorBold2(Dt_Cho_Rua, ref _Bold_Cho_KH, ref _BackColor_Cho_KH, ref _BackColor2_Cho_KH, ref _ForeColor_Cho_KH, ref _Underline_Cho_KH, ref _FieldBold_Cho_KH, ref _FieldBackColor_Cho_KH, ref _FieldBackColor2_Cho_KH, ref _FieldForeColor_Cho_KH, ref _FieldUnderline_Cho_KH);
        CyberColor.V_GetColorBold2(Dt_Data, ref _Bold_Data, ref _BackColor_Data, ref _BackColor2_Data, ref _ForeColor_Data, ref _Underline_Data, ref _FieldBold_Data, ref _FieldBackColor_Data, ref _FieldBackColor2_Data, ref _FieldForeColor_Data, ref _FieldUnderline_Data);
        if (Dt_Data.Columns.Contains("Border") & Dt_Data.Columns.Contains("BorderColor") & Dt_Data.Columns.Contains("SizeBorder"))
          _BorderColor_Data = true;
        if (_BorderColor_Data)
          _FieldBorderColor_Data = Dt_Data.Columns["BorderColor"].ColumnName;
        MasterDang_Rua.DataSource = Dv_Dang_Rua;
        MasterDang_RuaGRV.GridControl = MasterDang_Rua;

        MasterDang_RuaGRV.Appearance.SelectedRow.BackColor = Color.YellowGreen;
        MasterDang_RuaGRV.OptionsSelection.MultiSelect = false;
        CyberColor.V_GetColorBold2(Dt_Dang_Rua, ref _Bold_Dang_Rua_KH, ref _BackColor_Dang_Rua_KH, ref _BackColor2_Dang_Rua_KH, ref _ForeColor_Dang_Rua_KH, ref _Underline_Dang_Rua_KH, ref _FieldBold_Dang_Rua_KH, ref _FieldBackColor_Dang_Rua_KH, ref _FieldBackColor2_Dang_Rua_KH, ref _FieldForeColor_Dang_Rua_KH, ref _FieldUnderline_Dang_Rua_KH);
        MasterRua_Xong.DataSource = Dv_Rua_Xong;
        MasterRua_XongGRV.GridControl = MasterRua_Xong;

        MasterRua_XongGRV.Appearance.SelectedRow.BackColor = Color.YellowGreen;
        MasterRua_XongGRV.OptionsSelection.MultiSelect = false;
        CyberColor.V_GetColorBold2(Dt_Rua_Xong, ref _Bold_Rua_Xong_KH, ref _BackColor_Rua_Xong_KH, ref _BackColor2_Rua_Xong_KH, ref _ForeColor_Rua_Xong_KH, ref _Underline_Rua_Xong_KH, ref _FieldBold_Rua_Xong_KH, ref _FieldBackColor_Rua_Xong_KH, ref _FieldBackColor2_Rua_Xong_KH, ref _FieldForeColor_Rua_Xong_KH, ref _FieldUnderline_Rua_Xong_KH);
      }
      else if (_Stt_Rec.Trim() == "")
      {
        Dt_Cho_Rua.Clear();
        Dt_Cho_Rua.Load(dataSet.Tables[0].CreateDataReader());

        Dt_Data.Clear();
        Dt_Data.Load(dataSet.Tables[1].CreateDataReader());

        Dt_Dang_Rua.Clear();
        Dt_Dang_Rua.Load(dataSet.Tables[2].CreateDataReader());

        Dt_Rua_Xong.Clear();
        Dt_Rua_Xong.Load(dataSet.Tables[3].CreateDataReader());

        Dt_Data_Xe.Clear();
        Dt_Data_Xe.Load(dataSet.Tables[4].CreateDataReader());
      }
      else
      {
        if (Dt_Cho_Rua != null)
        {
          V_Delete_KH_Rx(Dt_Cho_Rua, _Stt_Rec);
          if (dataSet.Tables.Count > 0)
            Dt_Cho_Rua.Load(dataSet.Tables[0].CreateDataReader());
        }
        if (Dt_Data != null)
        {
          V_Delete_KH_Rx(Dt_Data, _Stt_Rec);
          if (dataSet.Tables.Count > 1)
            Dt_Data.Load(dataSet.Tables[1].CreateDataReader());
        }
        if (Dt_Dang_Rua != null)
        {
          V_Delete_KH_Rx(Dt_Dang_Rua, _Stt_Rec);
          if (dataSet.Tables.Count > 2)
            Dt_Dang_Rua.Load((IDataReader)dataSet.Tables[2].CreateDataReader());
        }
        if (Dt_Rua_Xong != null)
        {
          V_Delete_KH_Rx(Dt_Rua_Xong, _Stt_Rec);
          if (dataSet.Tables.Count > 3)
            Dt_Rua_Xong.Load(dataSet.Tables[3].CreateDataReader());
        }
        if (Dt_Data_Xe != null)
        {
          V_Delete_KH_Rx(Dt_Data_Xe, _Stt_Rec);
          if (dataSet.Tables.Count > 4)
            Dt_Data_Xe.Load(dataSet.Tables[4].CreateDataReader());
        }
      }
      dataSet.Dispose();

      SchedulerStorage.EndUpdate();
      V_Filter_KH_RX(new object(), new EventArgs());
      SchedulerControl.Storage.RefreshData();
      SchedulerStorage.Appointments.AutoReload = true;
      V_Hieu_suat();
    }
    #endregion

    #region "V_LoadDatabases"
    private void V_Delete_KH_Rx(DataTable _Dt, string _Stt_Rec)
    {
      if (_Dt == null)
        return;
      int num = checked(_Dt.Rows.Count - 1);
      if (_Stt_Rec.Trim() == "")
      {
        _Dt.Clear();
        _Dt.AcceptChanges();
      }
      else
      {
        if (!_Dt.Columns.Contains("Stt_Rec"))
          return;
        int index = checked(_Dt.Rows.Count - 1);
        while (index >= 0)
        {
          if (_Dt.Rows[index]["Stt_Rec"].ToString().Trim() == _Stt_Rec.Trim())
            _Dt.Rows[index].Delete();
          checked { index += -1; }
        }
        _Dt.AcceptChanges();
      }
    }
    private void V_Filter_KH_RX(object sender, EventArgs e)
    {
      string filterKhScc1 = V_GetFilter_KH_SCC(Dt_Cho_Rua);
      string filterKhScc2 = V_GetFilter_KH_SCC(Dt_Data);
      string filterKhScc3 = V_GetFilter_KH_SCC(Dt_Rua_Xong);
      string filterKhScc4 = V_GetFilter_KH_SCC(Dt_Data_Xe);
      string filterKhScc5 = V_GetFilter_KH_SCC(Dt_Dang_Rua);

      try
      {
        Dv_Cho_Rua.RowFilter = filterKhScc1;
      }
      catch (Exception ex)
      {
      }

      try
      {
        Dv_Data.RowFilter = filterKhScc2;
      }
      catch (Exception ex)
      {
      }

      try
      {
        Dv_Rua_Xong.RowFilter = filterKhScc3;
      }
      catch (Exception ex)
      {
      }

      try
      {
        Dv_Data_Xe.RowFilter = filterKhScc4;
      }
      catch (Exception ex)
      {
      }
      try
      {
        Dv_Dang_Rua.RowFilter = filterKhScc5;
      }
      catch (Exception ex)
      {
      }

      T_tinh_So_Xe_RX();
    }
    private void V_Hieu_suat()
    {
      LabTy_Hieusuat.Text = "";

      DataSet dataSet = new DataSet(); // CP_RO_CW_Tinh_Hieu_suat
      if (dataSet.Tables.Count == 0)
        dataSet.Dispose();
      else if (dataSet.Tables[0].Rows.Count == 0)
        dataSet.Dispose();
      else
      {
        if (dataSet.Tables[0].Columns.Contains("VISIBLE"))
          LabTy_Hieusuat.Visible = Convert.ToInt32(dataSet.Tables[0].Rows[0]["VISIBLE"]) == 1 ? true : false;
        if (dataSet.Tables[0].Columns.Contains("Hieusuat"))
          LabTy_Hieusuat.Text = Convert.ToString(dataSet.Tables[0].Rows[0]["Hieusuat"]);
        if (dataSet.Tables[0].Columns.Contains("BackColor"))
          LabTy_Hieusuat.BackColor = CyberColor.GetBackColor(Convert.ToString(dataSet.Tables[0].Rows[0]["BackColor"]));
        if (dataSet.Tables[0].Columns.Contains("ForeColor"))
          LabTy_Hieusuat.ForeColor = CyberColor.GetBackColor(Convert.ToString(dataSet.Tables[0].Rows[0]["ForeColor"]));
        dataSet.Dispose();
      }
    }
    #endregion

    #region "V_Filter_KH_RX"
    private string V_GetFilter_KH_SCC(DataTable _DT_Filter)
    {
      string filterKhScc = "1=1";
      if (_DT_Filter == null)
        return filterKhScc;

      string Left = V_GetvalueCombox(CbbMa_HS);
      if (_DT_Filter.Columns.Contains("Ma_Hs") & Left != "")
        filterKhScc = filterKhScc + " AND Ma_Hs = '" + Left.Trim() + "'";

      string text1 = TxtMa_Xe.Text;
      if (_DT_Filter.Columns.Contains("Ma_Xe") & text1 != "")
        filterKhScc = filterKhScc + " AND Ma_Xe LIKE '*" + text1.Trim() + "*'";

      string text2 = TxtSo_RO.Text;
      if (_DT_Filter.Columns.Contains("So_RO") & text2 != "")
        filterKhScc = filterKhScc + " AND So_RO LIKE '*" + text2.Trim() + "*'";

      return filterKhScc;
    }
    private void T_tinh_So_Xe_RX()
    {
      LabKQ_CR.Text = "0";
      LabKQ_DR.Text = "0";
      LabKQ_RX.Text = "0";

      int count1 = Dv_Cho_Rua.Count;
      int count2 = Dv_Dang_Rua.Count;
      int count3 = Dv_Rua_Xong.Count;

      int num = checked(count1 + count2 + count3);
      LabKQ_CR.Text = Convert.ToString(count1);
      LabKQ_DR.Text = Convert.ToString(count2);
      string str = (num == 0) ? "0%" : Math.Round(new decimal(count3 * 100 / num)).ToString().Trim() + "%";
      LabKQ_RX.Text = count3.ToString().Trim() + "/" + num.ToString().Trim() + " - " + str.Trim();
    }
    #endregion

    #region "V_Buoc_Nhay_KH_RX"
    private void V_CyberSetTime_KH_RX()
    {
      string Left = V_GetvalueCombox(CbbCa_Ngay);
      decimal num1 = new decimal(M_StartHour);
      decimal num2 = new decimal(M_StartMINUTE);
      decimal num3 = new decimal(M_FinishHour);
      decimal num4 = new decimal(M_FinishMINUTE);
      DateTime Startdate1 = M_Ngay_LimitInterval_Min;
      DateTime limitIntervalMaxRx = M_Ngay_LimitInterval_Max_RX;

      if (Left == "02")
      {
        num1 = Convert.ToDecimal(Dt_Set_SCC.Rows[0]["H_Sang1"]);
        num2 = Convert.ToDecimal(Dt_Set_SCC.Rows[0]["M_Sang1"]);
        num3 = Convert.ToDecimal(Dt_Set_SCC.Rows[0]["H_Sang2"]);
        num4 = Convert.ToDecimal(Dt_Set_SCC.Rows[0]["M_Sang2"]);
        Startdate1 = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_Sang1"]);
        M_Ngay_LimitInterval_Max_RX = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_Sang2"]);
      }

      if (Left == "03")
      {
        num1 = Convert.ToDecimal(Dt_Set_SCC.Rows[0]["H_Chieu1"]);
        num2 = Convert.ToDecimal(Dt_Set_SCC.Rows[0]["M_Chieu1"]);
        num3 = Convert.ToDecimal(Dt_Set_SCC.Rows[0]["H_Chieu2"]);
        num4 = Convert.ToDecimal(Dt_Set_SCC.Rows[0]["M_Chieu2"]);
        Startdate1 = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_Chieu1"]);
        M_Ngay_LimitInterval_Max_RX = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_Chieu2"]);
      }

      if (SchedulerControl.ActiveViewType == SchedulerViewType.Gantt)
      {
        TimeScaleCollection scales = SchedulerControl.GanttView.Scales;
        scales.BeginUpdate();
        try
        {
          scales.Clear();
          TimeScaleLessThanDay scaleLessThanDay1 = new TimeScaleLessThanDay(TimeSpan.FromHours(1.0), Convert.ToInt32(num1), Convert.ToInt32(num3), Startdate1, limitIntervalMaxRx, M_Thu_Bay, M_Chu_Nhat);
          TimeScaleLessThanDay scaleLessThanDay2 = new TimeScaleLessThanDay(TimeSpan.FromMinutes(Convert.ToDouble(V_GetvalueCombox(CbbMa_BN))), Convert.ToInt32(num1), Convert.ToInt32(num3), Startdate1, limitIntervalMaxRx, M_Thu_Bay, M_Chu_Nhat);
          scales.Add(new TimeScaleYear());
          scales.Add(new TimeScaleQuarter());
          scales.Add(new TimeScaleMonth());
          scales.Add(new TimeScaleWeek());
          scales.Add(new CyberTimeScaleDay(Convert.ToInt32(num1), Convert.ToInt32(num3), Startdate1, limitIntervalMaxRx));
          scales.Add(scaleLessThanDay1);
          scales.Add(scaleLessThanDay2);
        }
        finally
        {
          SchedulerControl.GanttView.Scales[0].Visible = false;
          SchedulerControl.GanttView.Scales[1].Visible = false;
          SchedulerControl.GanttView.Scales[2].Visible = false;
          SchedulerControl.GanttView.Scales[3].Visible = false;
          SchedulerControl.GanttView.Scales[4].Visible = true;
          SchedulerControl.GanttView.Scales[5].Visible = true;
          SchedulerControl.Views.GanttView.Scales[6].DisplayFormat = "mm";
          if (CbbMa_BN.SelectedValue.ToString() == "60")
            SchedulerControl.GanttView.Scales[6].Visible = false;
          else
            SchedulerControl.GanttView.Scales[6].Visible = true;
          scales.EndUpdate();
        }
      }
      else if (SchedulerControl.ActiveViewType == SchedulerViewType.Day)
      {
        SchedulerControl.Views.DayView.ShowWorkTimeOnly = true;
        SchedulerControl.DayView.ShowDayHeaders = false;
        TimeSpan timeSpan1 = new TimeSpan(Convert.ToInt32(num1), Convert.ToInt32(num2), 0);
        TimeSpan timeSpan2 = new TimeSpan(Convert.ToInt32(num3), Convert.ToInt32(num4), 0);
        SchedulerControl.Views.DayView.WorkTime.End = new TimeSpan(M_FinishHour, M_FinishMINUTE, 0);
        SchedulerControl.Views.DayView.WorkTime.Start = timeSpan1;
        SchedulerControl.Views.DayView.WorkTime.End = timeSpan2;
        int integer = Convert.ToInt32(CbbMa_BN.SelectedValue);
        SchedulerControl.Views.DayView.TimeScale = TimeSpan.FromMinutes((double)integer);
        SchedulerControl.DayView.VisibleTimeSnapMode = true;
        SchedulerControl.DayView.TimeScale = new TimeSpan(0, integer, 0);
        SchedulerControl.DayView.TimeRulers.Clear();
        SchedulerControl.DayView.TimeRulers.Add(new TimeRuler()
        {
          Caption = "",
          ShowMinutes = true,
          TimeMarkerVisibility = TimeMarkerVisibility.Always
        });
      }
      SchedulerControl.LimitInterval.Start = Startdate1;
      SchedulerControl.LimitInterval.End = M_Ngay_LimitInterval_Max_RX;
      SchedulerControl.Start = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_Ct"]);
    }
    private void V_Do_Rong_KH_RX(object sender, EventArgs e)
    {
      if (SchedulerControl.ActiveViewType == SchedulerViewType.Gantt)
      {
        int index = 0;
        do
        {
          if (SchedulerControl.GanttView.Scales[index].Visible)
            SchedulerControl.Views.GanttView.Scales[index].Width = Convert.ToInt32(V_GetvalueCombox(CbbDo_Rong));
          checked { ++index; }
        }
        while (index <= 6);
      }
      if (SchedulerControl.ActiveViewType != SchedulerViewType.Day)
        return;
      SchedulerControl.DayView.RowHeight = Convert.ToInt32(V_GetvalueCombox(CbbDo_Rong));
    }
    #endregion

    #region "V_SetScheduler_RXControl_KH_RX"
    private void V_SetScheduler_SetValue_RX()
    {
      string Left1 = V_GetvalueCombox(CbbKieu_Xem);
      string Left2 = V_GetvalueCombox(CbbCa_Ngay);
      string Left3 = V_GetvalueCombox(CbbGio_Xem);
      decimal _Do_Rong = 50M;

      if (Left2 == "02")
        _Do_Rong = 120M;
      if (Left1 == "02")
        _Do_Rong = 120M;
      if (Left3 == "01")
        _Do_Rong = 120M;

      bool flag = true;
      if (Dt_Kieu_Xem != null && Dt_Kieu_Xem.Columns.Contains("ShowHead"))
      {
        DataRow[] dataRowArray = Dt_Kieu_Xem.Select("Kieu_Xem ='" + Left1 + "'");
        if (dataRowArray.Length > 0 && Convert.ToInt32(dataRowArray[0]["ShowHead"]) == 0)
          flag = false;
      }
      SchedulerControl.Views.GanttView.ShowResourceHeaders = flag;

      if (Left1 == "01")
        V_SetScheduler_RX(Dv_DmKhoang_KH_SCC, "Ma_khoang", DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang", _Do_Rong);
      if (Left1 != "02")
        return;

      V_SetScheduler_RX(Dv_Cho_Rua, "Stt_Rec", "Ma_Xe", _Do_Rong, Dt_Xe_H);
    }
    private void V_SetScheduler_RX(DataView _Dv_DataSource, string _Id, string _Caption, decimal _Do_Rong, DataTable _Dt_Head_tree = null)
    {
      if (_Dv_DataSource == null)
        return;

      int num1 = checked(Dt_ConFigColor_KH_SCC.Rows.Count - 1);
      int num2 = 0;
      while (num2 <= num1)
      {
        // SchedulerStorage.Appointments.Labels[num2].Color = CyberColor.GetBackColor(Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["BackColor"]));
        // SchedulerStorage.Appointments.Labels[num2].DisplayName = Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["Ten_Color"]);
        // SchedulerStorage.Appointments.Labels[num2].MenuCaption = Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["Ten_Color"]);
        SchedulerStorage.Appointments.Labels.GetByIndex(num2).Color = CyberColor.GetBackColor(Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["BackColor"]));
        SchedulerStorage.Appointments.Labels.GetByIndex(num2).DisplayName = Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["Ten_Color"]);
        SchedulerStorage.Appointments.Labels.GetByIndex(num2).MenuCaption = Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["Ten_Color"]);
        V_SetColorlabel_RX(num2, Dt_ConFigColor_KH_SCC.Rows[num2]);
        checked { ++num2; }
      }

      V_AddResourcesTree(Dv_Cho_Rua, _Dt_Head_tree);

      SchedulerStorage.Resources.DataSource = null;
      SchedulerStorage.Resources.Mappings.Id = "";
      SchedulerStorage.Resources.Mappings.Caption = "";
      SchedulerStorage.Resources.DataSource = _Dv_DataSource;
      SchedulerStorage.Resources.Mappings.Id = _Dv_DataSource.Table.Columns[_Id].ColumnName.ToString().Trim();
      SchedulerStorage.Resources.Mappings.Caption = _Dv_DataSource.Table.Columns[_Caption].ColumnName.ToString().Trim();

      if (_Dv_DataSource.Table.Columns.Contains("Color"))
        SchedulerStorage.Resources.Mappings.Color = _Dv_DataSource.Table.Columns["Color"].ColumnName.ToString().Trim();

      if (_Dv_DataSource.Table.Columns.Contains("Image"))
        SchedulerStorage.Resources.Mappings.Image = _Dv_DataSource.Table.Columns["Image"].ColumnName.ToString().Trim();

      if (_Do_Rong > 0M)
        SchedulerControl.OptionsView.ResourceHeaders.Height = Convert.ToInt32(_Do_Rong);

      SchedulerStorage.Appointments.Mappings.ResourceId = Dt_Data.Columns[_Id].ColumnName;
      SchedulerStorage.Appointments.Mappings.Subject = Dt_Data.Columns["Ma_Xe"].ColumnName;
    }
    private void V_AddResourcesTree(DataView _Dv_DataSource, DataTable _Dt_Header)
    {
      resourcesTree1.Columns.Clear();
      if (_Dv_DataSource == null | _Dt_Header == null)
      {
        SchedulerControl.Views.GanttView.ShowResourceHeaders = true;
        resourcesTree1.Visible = false;
        splitContainer5.SplitterDistance = 0;
      }
      else
      {
        resourcesTree1.BorderStyle = SchedulerControl.BorderStyle;
        int num = 10;
        int Left1 = num;
        resourcesTree1.Visible = true;
        resourcesTree1.Columns.Clear();
        string str = "L";

        try
        {
          foreach (DataRow row in _Dt_Header.Rows)
          {
            if (_Dv_DataSource.Table.Columns.Contains(Convert.ToString(row["Field_Name"])))
            {
              str = !_Dt_Header.Columns.Contains("TxtAlign") ? "L" : row["TxtAlign"].ToString().Trim().ToUpper();
              string Left2 = !_Dt_Header.Columns.Contains("Field_Type") ? "C" : row["Field_Type"].ToString().Trim().ToUpper();
              if (Left2 == "N")
                str = "R";
              if (Left2 == "D")
                str = "C";

              ResourceTreeColumn column = new ResourceTreeColumn();
              RepositoryItemMemoEdit repositoryItemMemoEdit = new RepositoryItemMemoEdit();
              repositoryItemMemoEdit.BorderStyle = BorderStyles.HotFlat;
              column.ColumnEdit = repositoryItemMemoEdit;
              column.OptionsColumn.AllowSort = false;
              Left1 = Left1 + Convert.ToInt32(row["Field_Width"]);
              column.Caption = Convert.ToString(row["Field_Head1"]);
              column.Visible = true;
              column.AppearanceHeader.Options.UseTextOptions = true;
              column.AppearanceHeader.Options.UseFont = true;
              column.AppearanceHeader.Options.UseBackColor = true;
              column.AppearanceHeader.Options.UseForeColor = true;
              column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
              column.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
              column.AppearanceHeader.BorderColor = Color.AliceBlue;
              column.AppearanceHeader.ForeColor = Color.Blue;
              column.AppearanceHeader.Font = new Font(column.AppearanceHeader.Font.FontFamily, 9f, FontStyle.Regular);
              column.AppearanceCell.Options.UseBackColor = true;
              column.AppearanceCell.Options.UseBorderColor = true;
              column.AppearanceCell.Options.UseFont = true;
              column.AppearanceCell.Options.UseForeColor = true;
              column.AppearanceCell.Options.UseTextOptions = true;
              column.AppearanceCell.Font = new Font(column.AppearanceHeader.Font.FontFamily, 8f, FontStyle.Regular);
              column.AppearanceCell.ForeColor = Color.Navy;
              column.AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;
              column.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
              column.Width = Convert.ToInt32(row["Field_Width"]);
              resourcesTree1.Columns.Add(column);
            }
          }
        }
        finally
        {
        }
        if (num == Left1)
        {
          resourcesTree1.Visible = false;
          splitContainer5.SplitterDistance = 0;
        }
        else
        {
          resourcesTree1.Width = Left1;
          resourcesTree1.Visible = true;
          splitContainer5.SplitterDistance = Left1;
        }
      }
    }
    private void V_SetColorAppointments_RX()
    {
      int num1 = checked(Dt_ConFigColor_KH_SCC.Rows.Count - 1);
      int num2 = 0;
      while (num2 <= num1)
      {
        SchedulerStorage.Appointments.Labels[num2].Color = CyberColor.GetBackColor(Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["BackColor"]));
        SchedulerStorage.Appointments.Labels[num2].DisplayName = Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["Ten_Color"]);
        SchedulerStorage.Appointments.Labels[num2].MenuCaption = Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["Ten_Color"]);
        V_SetColorlabel_RX(num2, Dt_ConFigColor_KH_SCC.Rows[num2]);
        checked { ++num2; }
      }
    }
    private void V_SetColorlabel_RX(int _i, DataRow _Dr)
    {
    }
    #endregion

    #region "from others"
    private void V_FillComBoxDefaul(ComboBox ComBoxName, DataTable Dt, string FieldValue, string FieldDispLay, string FieldDefault = "Default")
    {
      if (Dt == null)
        return;

      ComBoxName.DataSource = Dt;
      ComBoxName.DisplayMember = Dt.Columns[FieldDispLay].ColumnName;
      ComBoxName.ValueMember = Dt.Columns[FieldValue].ColumnName;
      if (!Dt.Columns.Contains(FieldDefault))
      {
        if (Dt.Rows.Count == 0)
          return;
        string str = Dt.Rows[0][Dt.Columns[FieldValue].ColumnName].ToString();
        ComBoxName.SelectedValue = str;
      }
      else
      {
        int num = checked(Dt.Rows.Count - 1);
        int index = 0;
        while (index <= num)
        {
          if (Dt.Rows[index][Dt.Columns[FieldDefault].ColumnName].ToString().Trim().ToUpper() == "1" || 
              Dt.Rows[index][Dt.Columns[FieldDefault].ColumnName].ToString().Trim().ToUpper() == "TRUE")
          {
            string str = Dt.Rows[index][Dt.Columns[FieldValue].ColumnName].ToString();
            ComBoxName.SelectedValue = str;
            break;
          }
          checked { ++index; }
        }
      }
    }
    private decimal V_StringToNumeric(ComboBox _Cbb)
    {
      decimal numeric = 0M;
      string str = V_GetvalueCombox(_Cbb);
      if (str.Trim() == "")
        str = "0";
      try
      {
        numeric = Convert.ToDecimal(str);
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      return numeric;
    }
    private string V_GetvalueCombox(ComboBox _Cbb)
    {
      string str = "";
      try
      {
        str = _Cbb.SelectedValue.ToString().Trim();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      return str;
    }
    private void V_DeleteRowEmpty(DataTable _Dt, string _Fieldname)
    {
      if (_Dt == null)
        return;

      _Fieldname = _Fieldname.Trim();
      if (!_Dt.Columns.Contains(_Fieldname))
        return;

      _Fieldname = _Dt.Columns[_Fieldname].ColumnName;
      int index = checked(_Dt.Rows.Count - 1);
      while (index >= 0)
      {
        if (_Dt.Rows[index][_Fieldname].ToString().Trim() == "")
          _Dt.Rows[index].Delete();
        checked { index += -1; }
      }
      _Dt.AcceptChanges();
    }
    private void SetNotNullTable(DataTable tb)
    {
      int num1 = checked(tb.Rows.Count - 1);
      int index = 0;
      while (index <= num1)
      {
        tb.Rows[index].BeginEdit();
        int num2 = checked(tb.Columns.Count - 1);
        int num3 = 0;
        while (num3 <= num2)
        {
          if (tb.Rows[index][num3] == null)
          {
            string upper = tb.Columns[num3].DataType.Name.Trim().ToUpper();
            if (upper == "STRING")
              tb.Rows[index][num3] = "";
            else if (upper == "DATETIME")
              tb.Rows[index][num3] = new DateTime(1900, 1, 1);
            else if (upper == "DECIMAL")
              tb.Rows[index][num3] = 0;
            else if (upper == "DOUBLE")
              tb.Rows[index][num3] = (object)0;
            else if (upper == "BOOLEAN")
              tb.Rows[index][num3] = "1";
          }
          checked { ++num3; }
        }
        tb.Rows[index].EndEdit();
        checked { ++index; }
      }
      tb.AcceptChanges();
    }
    private void V_SetSortView(ref DataView _Dv, DataTable _Dt)
    {
      string sortView = V_GetSortView(_Dv, _Dt);
      if (sortView.Trim() == "")
        return;

      _Dv.Sort = sortView;
    }
    private string V_GetSortView(DataView _Dv, DataTable _Dt)
    {
      if (_Dv == null | _Dt == null || !_Dt.Columns.Contains("FieldSort"))
        return "";
      string sortView = "";
      int num = checked(_Dt.Rows.Count - 1);
      int index = 0;
      while (index <= num)
      {
        string name = _Dt.Rows[index]["FieldSort"].ToString().Trim();
        string Left = (!_Dt.Columns.Contains("Is_DESC") ? "0" : _Dt.Rows[index]["Is_DESC"].ToString().Trim()).Trim();
        if (_Dv.Table.Columns.Contains(name))
        {
          string columnName = _Dv.Table.Columns[name].ColumnName;
          if (Left == "1")
            columnName += " DESC";
          sortView = sortView.Trim() != "" ? sortView + "," + columnName : columnName;
        }
        checked { ++index; }
      }
      return sortView;
    }
    #endregion
  }
}