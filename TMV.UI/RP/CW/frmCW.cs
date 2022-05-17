using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraTreeList;
using System;
using System.Data;
using System.Drawing;
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
    private DataView Dv_Cho_Rua_H;
    private DataView Dv_Dang_Rua_H;
    private DataView Dv_Rua_Xong_H;
    private DataView Dv_Xe_H;
    private bool _Bold_Cho_KH = false;
    private bool _BackColor_Cho_KH = false;
    private bool _BackColor2_Cho_KH = false;
    private bool _ForeColor_Cho_KH = false;
    private bool _BorderColor_Cho_KH = false;
    private bool _Underline_Cho_KH = false;
    private string _FieldBold_Cho_KH = "";
    private string _FieldBackColor_Cho_KH = "";
    private string _FieldBackColor2_Cho_KH = "";
    private string _FieldForeColor_Cho_KH = "";
    private string _FieldBorderColor_Cho_KH = "";
    private string _FieldUnderline_Cho_KH = "";
    private bool _Bold_Dang_Rua_KH = false;
    private bool _BackColor_Dang_Rua_KH = false;
    private bool _BackColor2_Dang_Rua_KH = false;
    private bool _ForeColor_Dang_Rua_KH = false;
    private bool _BorderColor_Dang_Rua_KH = false;
    private bool _Underline_Dang_Rua_KH = false;
    private string _FieldBold_Dang_Rua_KH = "";
    private string _FieldBackColor_Dang_Rua_KH = "";
    private string _FieldBackColor2_Dang_Rua_KH = "";
    private string _FieldForeColor_Dang_Rua_KH = "";
    private string _FieldBorderColor_Dang_Rua_KH = "";
    private string _FieldUnderline_Dang_Rua_KH = "";
    private bool _Bold_Rua_Xong_KH = false;
    private bool _BackColor_Rua_Xong_KH = false;
    private bool _BackColor2_Rua_Xong_KH = false;
    private bool _ForeColor_Rua_Xong_KH = false;
    private bool _BorderColor_Rua_Xong_KH = false;
    private bool _Underline_Rua_Xong_KH = false;
    private string _FieldBold_Rua_Xong_KH = "";
    private string _FieldBackColor_Rua_Xong_KH = "";
    private string _FieldBackColor2_Rua_Xong_KH = "";
    private string _FieldForeColor_Rua_Xong_KH = "";
    private string _FieldBorderColor_Rua_Xong_KH = "";
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
      resourcesTree1.OptionsView.FocusRectStyle = DrawFocusRectStyle.None;
      resourcesTree1.TreeLineStyle = LineStyle.None;
      resourcesTree1.OptionsView.ShowHorzLines = false;
      resourcesTree1.Visible = false;
    }
    private void V_SetRowHeight_KH()
    {
      if (Dt_Set_SCC == null || Dt_Set_SCC.Rows.Count == 0)
        return;

      SchedulerControl.Views.GanttView.ResourcesPerPage = 3;
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
    }
    private void V_GetColumn()
    {

    }
    private void V_AddHander()
    {

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
      SchedulerStorage.Appointments.DataSource = (object)Dv_Data;
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

      SchedulerControl.GanttView.Appearance.Appointment.ForeColor = System.Drawing.Color.White;
      SchedulerControl.GanttView.Appearance.Appointment.Font = new Font(SchedulerControl.DayView.Appearance.Appointment.Font.FontFamily, 8f);
      SchedulerControl.DayView.Appearance.Appointment.ForeColor = System.Drawing.Color.White;
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
      Decimal d1 = V_StringToNumeric(CbbTime_Data);
      if (Decimal.Compare(d1, 0M) <= 0)
        d1 = 3000M;
      Timer_Data.Interval = Convert.ToInt32(d1);
    }
    private void V_Buoc_Nhay_KH_RX(object sender, EventArgs e)
    {
      V_CyberSetTime_KH_RX();
      V_Do_Rong_KH_RX(sender, e);
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
          TimeMarkerVisibility = (TimeMarkerVisibility?)TimeMarkerVisibility.Always
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
        SchedulerStorage.Appointments.Labels[num2].Color = CyberColor.GetBackColor(Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["BackColor"]));
        SchedulerStorage.Appointments.Labels[num2].DisplayName = Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["Ten_Color"]);
        SchedulerStorage.Appointments.Labels[num2].MenuCaption = Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["Ten_Color"]);
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
    public void V_FillComBoxDefaul(System.Windows.Forms.ComboBox ComBoxName, DataTable Dt, string FieldValue, string FieldDispLay, string FieldDefault = "Default")
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
          if (Dt.Rows[index][Dt.Columns[FieldDefault].ColumnName].ToString().Trim().ToUpper() == "1" || Dt.Rows[index][Dt.Columns[FieldDefault].ColumnName].ToString().Trim().ToUpper() == "TRUE")
          {
            string str = Dt.Rows[index][Dt.Columns[FieldValue].ColumnName].ToString();
            ComBoxName.SelectedValue = (object)str;
            break;
          }
          checked { ++index; }
        }
      }
    }
    public decimal V_StringToNumeric(System.Windows.Forms.ComboBox _Cbb)
    {
      decimal numeric = 0M;
      string str = V_GetvalueCombox(_Cbb);
      if (str.Trim() == "")
        str = "0";
      try
      {
        numeric = Convert.ToDecimal(str);
      }
      catch
      {
      }
      return numeric;
    }
    public string V_GetvalueCombox(System.Windows.Forms.ComboBox _Cbb)
    {
      string str = "";
      try
      {
        str = _Cbb.SelectedValue.ToString().Trim();
      }
      catch
      {
      }
      return str;
    }
    #endregion
  }
}