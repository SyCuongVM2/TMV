﻿using DevExpress.Images;
using DevExpress.Services;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TMV.Common;
using TMV.UI.JPCB.Common;

namespace TMV.UI.JPCB.JP
{
  public partial class frmJP : DevExpress.XtraEditors.XtraForm
  {
    #region "variables"
    private CyberFuncs CyberFunc = new CyberFuncs();
    private CyberColor CyberColor = new CyberColor();
    private bool _TabVisible1 = false;
    private bool _TabVisible2 = false;
    private bool _TabVisible3 = false;
    private bool _TabVisible4 = false;
    private bool _TabVisible5 = false;
    private bool _TabVisible6 = false;
    private bool _TabVisible7 = false;
    private bool _TabVisible8 = false;
    private bool _TabVisible9 = false;
    private bool _TabVisible10 = false;
    private bool _TabVisible11 = false;
    private bool _TabVisible12 = false;
    private DataTable DmCVDV;
    private DataTable Dt_CVDV_Hen;
    private DataTable Dt_CVDV_Cho_Tiep_Don;
    private DataTable Dt_CVDV_KH_SCC;
    private DataTable Dt_CVDV_Cho_Rua;
    private DataTable Dt_CVDV_Dang_Rua;
    private DataTable Dt_CVDV_Cho_Giao;
    private DataTable Dt_CVDV_Cho_SC;
    private DataTable Dt_CVDV_HonHop;
    private DataTable Dt_CVDV_Dung;
    private DataTable Dt_CVDV_ChayThu;
    private DataTable Dt_CVDV_ThemGio;
    private DataTable Dt_Time_Hen;
    private DataTable Dt_Time_Cho_Tiep_Don;
    private DataTable Dt_Time_KH_SCC;
    private DataTable Dt_Time_Cho_Rua;
    private DataTable Dt_Time_Dang_Rua;
    private DataTable Dt_Time_Cho_Giao;
    private DataTable Dt_Time_Cho_SC;
    private DataTable Dt_Time_Honhop;
    private DataTable Dt_Time_Dung;
    private DataTable Dt_Time_ChayThu;
    private DataTable Dt_Time_ThemGio;
    private DataTable Dt_To_Hen;
    private DataTable Dt_To_Cho_Tiep_Don;
    private DataTable Dt_To_Cho_Lap_KH;
    private DataTable Dt_To_KH_SCC;
    private DataTable Dt_To_Cho_Rua;
    private DataTable Dt_To_Dang_Rua;
    private DataTable Dt_To_Cho_Giao;
    private DataTable Dt_To_Cho_SC;
    private DataTable Dt_Khoang_Hen;
    private DataTable Dt_Khoang_Cho_Tiep_Don;
    private DataTable Dt_Khoang_Cho_Lap_KH;
    private DataTable Dt_Khoang_KH_SCC;
    private DataTable Dt_Khoang_Cho_Rua;
    private DataTable Dt_Khoang_Dang_Rua;
    private DataTable Dt_Khoang_Cho_Giao;
    private DataTable Dt_Khoang_Cho_SC;
    private string _CP_Cho_SC = "CP_RO_CVDV_Cho_SC";
    private string _CP_HonHop = "CP_RO_CVDV_Honhop";
    private string _CP_Dung = "CP_RO_CVDV_Dung";
    private string M_Ma_CT_DLH = "DLH";
    private string M_Ma_CT_PKH = "PKH";
    private string M_Ma_CT_PDC = "PDC";
    private string M_Kieu_Xem = "TIEN_DO";
    private string M_Loai_SC = "1";
    private string M_Stt_Rec_Ro = "";
    private DataTable dt_configTab;
    private DataTable Dt_Hen;
    private DataTable Dt_Cho_SC;
    private DataTable Dt_Cho_SC_H;
    private DataView Dv_Cho_SC;
    private DataView Dv_Cho_SC_H;
    private bool _Bold_Cho_SC = false;
    private bool _BackColor_Cho_SC = false;
    private bool _BackColor2_Cho_SC = false;
    private bool _Forecolor_Cho_SC = false;
    private string _FieldBold_Cho_SC = "";
    private string _FieldBackColor_Cho_SC = "";
    private string _FieldBackColor2_Cho_SC = "";
    private string _FieldForecolor_Cho_SC = "";
    private string _Loai_SC_Cho_SC = "3";
    private DataTable Dt_HonHop;
    private DataTable Dt_HonHop_H;
    private DataView Dv_HonHop;
    private DataView Dv_HonHop_H;
    private bool _Bold_HonHop = false;
    private bool _BackColor_HonHop = false;
    private bool _BackColor2_HonHop = false;
    private bool _ForeColor_HonHop = false;
    private bool _BorderColor_HonHop = false;
    private bool _Underline_HonHop = false;
    private string _FieldBold_HonHop = "";
    private string _FieldBackColor_HonHop = "";
    private string _FieldBackColor2_HonHop = "";
    private string _FieldForeColor_HonHop = "";
    private string _FieldBorderColor_HonHop = "";
    private string _FieldUnderline_HonHop = "";
    private DataTable Dt_Dung;
    private DataTable Dt_Dung_H;
    private DataView Dv_Dung;
    private DataView Dv_Dung_H;
    private bool _Bold_Dung = false;
    private bool _BackColor_Dung = false;
    private bool _BackColor2_Dung = false;
    private bool _ForeColor_Dung = false;
    private bool _BorderColor_Dung = false;
    private bool _Underline_Dung = false;
    private string _FieldBold_Dung = "";
    private string _FieldBackColor_Dung = "";
    private string _FieldBackColor2_Dung = "";
    private string _FieldForeColor_Dung = "";
    private string _FieldBorderColor_Dung = "";
    private string _FieldUnderline_Dung = "";
    private DataTable Dt_Cho_Lap_KH;
    private DataTable Dt_Cho_Lap_KH_H;
    private DataTable Dt_Mo_Lenh_Trong_Ngay;
    private DataTable Dt_Lenh_Giao_Trong_Ngay;
    private DataView Dv_Cho_Lap_KH;
    private DataView Dv_Cho_Lap_KH_H;
    private DataView Dv_Mo_Lenh_Trong_Ngay;
    private DataView Dv_Lenh_Giao_Trong_Ngay;
    private bool _Bold_Cho_Lap_KH = false;
    private bool _BackColor_Cho_Lap_KH = false;
    private bool _BackColor2_Cho_Lap_KH = false;
    private bool _Forecolor_Cho_Lap_KH = false;
    private bool _Underline_Cho_Lap_KH = false;
    private string _FieldBold_Cho_Lap_KH = "";
    private string _FieldBackColor_Cho_Lap_KH = "";
    private string _FieldBackColor2_Cho_Lap_KH = "";
    private string _FieldForecolor_Cho_Lap_KH = "";
    private string _FieldUnderline_Cho_Lap_KH = "";
    private DataTable Dt_Sua_Xong_KH;
    private DataTable Dt_Sua_Xong_KH_H;
    private DataView Dv_Sua_Xong_KH;
    private DataView Dv_Sua_Xong_KH_H;
    private bool _Bold_Sua_Xong_KH = false;
    private bool _BackColor_Sua_Xong_KH = false;
    private bool _BackColor2_Sua_Xong_KH = false;
    private bool _Forecolor_Sua_Xong_KH = false;
    private bool _Underline_Sua_Xong_KH = false;
    private string _FieldBold_Sua_Xong_KH = "";
    private string _FieldBackColor_Sua_Xong_KH = "";
    private string _FieldBackColor2_Sua_Xong_KH = "";
    private string _FieldForecolor_Sua_Xong_KH = "";
    private string _FieldUnderline_Sua_Xong_KH = "";
    private string _CP_Cho_Lap_KH = "";
    private GridviewDragDrop _keotha2Grid = new GridviewDragDrop();
    private int M_StartHour;
    private int M_FinishHour;
    private int M_StartMINUTE;
    private int M_FinishMINUTE;
    private DateTime M_Ngay_LimitInterval_Min;
    private DateTime M_Ngay_LimitInterval_Max;
    private string M_Thu_Bay = "0";
    private string M_Chu_Nhat = "1";
    private string M_Loai_KH_SCC = "1";
    private DataTable Dt_Right;
    private DataTable Dt_Xem_Gio;
    private DataTable Dt_Data_KH_SCC;
    private DataView Dv_Data_KH_SCC;
    private DataTable Dt_Data_Parent_KH_SCC;
    private DataView Dv_Data_Parent_KH_SCC;
    private DataTable Dt_Data_Xe_KH_SCC;
    private DataView Dv_Data_Xe_KH_SCC;
    private DataTable Dt_Data_KTV_KH_SCC;
    private DataView Dv_Data_KTV_KH_SCC;
    private bool _BackColor_Data_KH_SCC = false;
    private bool _BackColor2_Data_KH_SCC = false;
    private bool _ForeColor_Data_KH_SCC = false;
    private bool _BorderColor_Data_KH_SCC = false;
    private bool _Bold_Data_KH_SCC = false;
    private bool _Underline_KH_SCC = false;
    private string _BackColorField_Data_KH_SCC = "";
    private string _BackColorField2_Data_KH_SCC = "";
    private string _ForeColorField_Data_KH_SCC = "";
    private string _BorderColorField_Data_KH_SCC = "";
    private string _BoldField_Data_KH_SCC = "";
    private string _UnderlineField_KH_SCC = "";
    private DataTable Dt_ConFigColor_KH_SCC;
    private DataTable Dt_Set_SCC;
    private DataTable Dt_Buoc_Nhay_KH_SCC;
    private DataTable Dt_Do_Rong_KH_SCC;
    private DataTable DmCVDV_Loc_KH_SCC;
    private DataTable DmKhoang_Loc_KH_SCC;
    private DataTable DmTo_Loc_KH_SCC;
    private DataTable DmKTV_Loc_KH_SCC;
    private DataTable DmCd_Loc_KH_SCC;
    private DataTable DmMucSBD_Loc_KH_SCC;
    private DataTable DmMucSDS_Loc_KH_SCC;
    private DataTable DmLoai_Xem_Loc_KH_SCC;
    private DataTable DmTang_Loc_KH_SCC;
    private DataTable DmCVDV_KH_SCC;
    private DataTable DmKhoang_KH_SCC;
    private DataTable DmTo_KH_SCC;
    private DataTable DmKTV_KH_SCC;
    private DataTable DmCd_KH_SCC;
    private DataTable DmMucSBD_KH_SCC;
    private DataTable DmMucSDS_KH_SCC;
    private DataTable DmLoai_Xem_KH_SCC;
    private DataTable DmTang_KH_SCC;
    private DataTable DmDungSC;
    private DataTable DmChayThu;
    private DataTable DmKCSCD;
    private DataTable DmQGate;
    private DataTable DmCVDV_KH_SCC_H;
    private DataTable DmKhoang_KH_SCC_H;
    private DataTable DmTo_KH_SCC_H;
    private DataTable DmKTV_KH_SCC_H;
    private DataTable DmCd_KH_SCC_H;
    private DataView Dv_DmCVDV_KH_SCC;
    private DataView Dv_DmKhoang_KH_SCC;
    private DataView Dv_DmTo_KH_SCC;
    private DataView Dv_DmKTV_KH_SCC;
    private DataView Dv_DmCd_KH_SCC;
    private DataView Dv_DmMucSBD_KH_SCC;
    private DataView Dv_DmMucSDS_KH_SCC;
    private DataView Dv_DmLoai_Xem_KH_SCC;
    private DataView Dv_DmTang_KH_SCC;
    private DataTable Dt_Khoang_H;
    private DataTable Dt_Xe_H;
    private string M_Loai_XemOld = "";
    private int Flass = 0;
    private int Stt_Flass = 0;
    private string ForeColor_Flass = "";
    private string BackColor_Flass = "";
    private DataTable dt_TabChange;
    private int Interval = 1000;
    private int Show_iconNew = 0;
    private string Caption = "";
    #endregion

    public frmJP()
    {
      InitializeComponent();
    }
    private void CmdDong_Lai_Click(object sender, EventArgs e)
    {
      Close();
    }
    private void frmJP_Load(object sender, EventArgs e)
    {
      Text = "BẢNG THEO DÕI SỬA CHỮA";
      V_SetTree();
      IMouseHandlerService service = (IMouseHandlerService)SchedulerControl_KH_SCC.GetService(typeof(IMouseHandlerService));
      if (service != null)
      {
        CyberBarSubMenuPopup.CustomMouseHandlerService serviceInstance = new CyberBarSubMenuPopup.CustomMouseHandlerService((System.IServiceProvider)SchedulerControl_KH_SCC, service);
        SchedulerControl_KH_SCC.RemoveService(typeof(IMouseHandlerService));
        SchedulerControl_KH_SCC.AddService(typeof(IMouseHandlerService), (object)serviceInstance);
      }
      SchedulerControl_KH_SCC.MouseWheel += new MouseEventHandler(V_SchedulerControl_KH_SCC_MouseWheel);
      V_GetKieu_Xem_Loai_SC();
      LabLock.Visible = (M_Kieu_Xem.Trim().ToUpper() != "HEN");
      TxtM_Ngay_Ct_KH_SCC.EditValue = DateTime.Today.Date;

      V_LoadTabVisible();
      V_CreateTimeALl();

      if (_TabVisible3)
        V_Load_System_KH_SC();
      if (_TabVisible8)
        V_Load_System_HonHop();
      if (_TabVisible9)
        V_Load_System_Dung();

      V_LoadHonHop_Dung_ChayTHU();

      TabCVDV.DrawMode = TabDrawMode.OwnerDrawFixed;
      TabCVDV.Padding = new Point(20, 6);
      TabCVDV.DrawItem += new DrawItemEventHandler(V_DrawItem);
    }

    #region "frmCW_Load"
    private void V_SetTree()
    {
      ResourcesTree1.VertScrollVisibility = ScrollVisibility.Never;
      ResourcesTree1.OptionsView.ShowIndicator = false;
      ResourcesTree1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFocus;
      ResourcesTree1.TreeLineStyle = LineStyle.None;
      ResourcesTree1.TreeLevelWidth = 0;
      ResourcesTree1.OptionsView.ShowHorzLines = true;
      ResourcesTree1.Visible = false;
      ResourcesTree1.OptionsSelection.MultiSelect = true;
      SplitContainer_Tien_Do.SplitterDistance = 0;
    }
    private void V_SchedulerControl_KH_SCC_MouseWheel(object sender, MouseEventArgs e)
    {
      int visibleResourceIndex = SchedulerControl_KH_SCC.ActiveView.FirstVisibleResourceIndex;
      if (e.Delta > 0 && visibleResourceIndex != 0)
        checked { --SchedulerControl_KH_SCC.ActiveView.FirstVisibleResourceIndex; }
      if (e.Delta >= 0 || visibleResourceIndex == checked(SchedulerControl_KH_SCC.Storage.Resources.Count - 1))
        return;

      checked { ++SchedulerControl_KH_SCC.ActiveView.FirstVisibleResourceIndex; }
    }
    private void V_GetKieu_Xem_Loai_SC()
    {
      M_Loai_SC = "1";
      M_Kieu_Xem = "TIEN_DO";
      M_Stt_Rec_Ro = "";
    }
    private void V_LoadTabVisible()
    {
      DataSet dataSet = new DataSet(); // CP_RO_CVDV_Config
      dt_configTab = dataSet.Tables[0].Copy();
      int num = checked(dataSet.Tables[0].Rows.Count - 1);
      int index1 = 0;
      while (index1 <= num)
      {
        int index2 = checked(TabCVDV.TabPages.Count - 1);
        while (index2 >= 0)
        {
          if (TabCVDV.TabPages[index2].Name.ToString().ToUpper().Trim() == dataSet.Tables[0].Rows[index1]["Tab_Name"].ToString().ToUpper().Trim())
          {
            TabCVDV.TabPages[index2].Text =  dataSet.Tables[0].Rows[index1]["Tab_Caption"].ToString();
            if (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() != "1")
            {
              TabCVDV.TabPages.Remove(TabCVDV.TabPages[index2]);
              break;
            }
            break;
          }
          checked { index2 += -1; }
        }

        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)1)
          _TabVisible1 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)2)
          _TabVisible2 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)3)
          _TabVisible3 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)4)
          _TabVisible4 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)5)
          _TabVisible5 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)6)
          _TabVisible6 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)7)
          _TabVisible7 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)8)
          _TabVisible8 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)9)
          _TabVisible9 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)10)
          _TabVisible10 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)11)
          _TabVisible11 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        checked { ++index1; }
      }
      if (dataSet.Tables.Count > 1)
        Dt_Right = dataSet.Tables[1].Copy();

      dataSet.Dispose();
    }
    private void V_CreateTimeALl()
    {
      DataTable dataTable = CreateTime().Copy();
      if (_TabVisible3)
        Dt_Time_KH_SCC = dataTable.Copy();
      if (_TabVisible8)
        Dt_Time_Honhop = dataTable.Copy();
      if (_TabVisible9)
        Dt_Time_Dung = dataTable.Copy();
    }
    private DataTable CreateTime() => new DataTable()
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
    private void V_Load_System_KH_SC()
    {
      bool flag = false;
      Timer_Data_KH_SCC.Stop();
      Timer_Data_KH_SCC.Enabled = flag;
      CbbTime_Data_KH_SCC.Enabled = flag;

      if (Dt_Time_KH_SCC == null)
        Dt_Time_KH_SCC = CreateTime().Copy();

      CyberFunc.V_FillComBoxDefaul(CbbTime_Data_KH_SCC, Dt_Time_KH_SCC, "TG", "Ten_TG");
      V_Load_KH_SCC("1");

      if (!flag)
        Timer_Data_KH_SCC.Stop();
      else
        Timer_Data_KH_SCC.Start();
    }
    private void V_Load_System_HonHop()
    {
      //bool flag = false;
      //Timer_Data_honHop.Stop();
      //Timer_Data_honHop.Enabled = flag;
      //CbbTime_Data_HonHop.Enabled = flag;
      //V_Load_System_CVDV(ref Dt_CVDV_HonHop);
      //if (Dt_Time_Honhop == null)
      //  Dt_Time_Honhop = CreateTime().Copy();
      //V_LoadData_HonHop("1");
      //V_Fill_HonHop();
      //V_AddHander_HonHop();
      //Master_HonHopGRV.ColumnPanelRowHeight = 30;
    }
    private void V_Load_System_Dung()
    {
      //bool flag = false;
      //Timer_Data_Dung.Stop();
      //Timer_Data_Dung.Enabled = flag;
      //CbbTime_Data_Dung.Enabled = flag;
      //V_Load_System_CVDV(ref Dt_CVDV_Dung);
      //if (Dt_Time_Dung == null)
      //  Dt_Time_Dung = CreateTime().Copy();
      //V_LoadData_Dung("1");
      //V_Fill_Dung();
      //V_AddHander_Dung();
      //Master_DungGRV.ColumnPanelRowHeight = 30;
    }
    private void V_LoadHonHop_Dung_ChayTHU()
    {
      //CmdHonHop.Visible = _TabVisible8;
      //CmdDung.Visible = _TabVisible9;
      //CmdHonHop.Click -= new EventHandler(V_HonHop);
      //CmdDung.Click -= new EventHandler(V_Dung);
      //CmdHonHop.Click += new EventHandler(V_HonHop);
      //CmdDung.Click += new EventHandler(V_Dung);
      //V_SetCaptionSo_Xe(Dt_HonHop, CmdHonHop);
      //V_SetCaptionSo_Xe(Dt_Dung, CmdDung);
    }
    private void V_DrawItem(object sender, DrawItemEventArgs e)
    {
      TabPage tabPage = (sender as TabControl).SelectedTab;
      object obj = (sender as TabControl).GetTabRect(0);
      Rectangle rectangle = new Rectangle();
      Rectangle layoutRectangle = obj != null ? (Rectangle)obj : rectangle;
      SolidBrush solidBrush = new SolidBrush(System.Drawing.Color.Black);
      StringFormat format = new StringFormat();
      format.Alignment = StringAlignment.Center;
      format.LineAlignment = StringAlignment.Center;
      if (Convert.ToBoolean((int)(e.State & DrawItemState.Selected)))
      {
        Font font = new Font(TabCVDV.Font.FontFamily, (sender as Font).Size, FontStyle.Bold);
        e.Graphics.FillRectangle((Brush)new SolidBrush(Color.OrangeRed), e.Bounds);
        solidBrush = new SolidBrush(System.Drawing.Color.White);
        e.Graphics.DrawString(tabPage.Text, font, (Brush)solidBrush, (RectangleF)layoutRectangle, format);
      }
      else
        e.Graphics.DrawString(tabPage.Text, e.Font, (Brush)solidBrush, (RectangleF)layoutRectangle, format);

      solidBrush.Dispose();
    }
    #endregion

    #region "V_Load_KH_SCC"
    private void V_Load_KH_SCC(string _Load)
    {
      if (_Load == "1")
        V_GetTimeChangeLoai_SC();

      V_Visible_KH_SCC();
      TxtM_Ngay_Ct_KH_SCC.EditValue = DateTime.Today.Date;
      V_LoadDatabas_Ngam_Dinh_KH_SCC();
      V_CyberSetTime_KH_SCC();
      V_Load_DATA_KH_SCC("1", "", "");
      V_AddHander_KH_SCC();
      V_SetSchedulerControl_KH_SCC();
      V_SetRowHeight_KH_SCC();
      V_Auto_Data_KH_SCC(new object(), new EventArgs());
      V_Buoc_Nhay_KH_SCC(new object(), new EventArgs());
      V_Load_Cho_Lap_KH();
      Master_Cho_Lap_KHGRV.ColumnPanelRowHeight = 20;
      V_Lock_Xem();
      V_LoadTimeLine();
      V_AddHanderLabel_KH_SCC();
      V_GetHieghtSplitContainerKH_SC();
    }
    private void V_GetTimeChangeLoai_SC()
    {
      bool flag = false;
      Timer_Data_KH_SCC.Stop();
      Timer_Data_KH_SCC.Enabled = flag;
      CbbTime_Data_KH_SCC.Enabled = flag;
      M_Loai_KH_SCC = M_Loai_SC;
    }
    private void V_Visible_KH_SCC()
    {
      string str = "TIẾN ĐỘ SỬA CHỮA CHUNG";
      if (M_Loai_KH_SCC.Trim() == "2")
        str = "TIẾN ĐỘ SỬA ĐỒNG SƠN";
      if (M_Kieu_Xem.Trim() == "HEN")
        str = "LỊCH HẸN SỬA ";

      if (M_Kieu_Xem.Trim().Trim() == "HEN" | M_Loai_KH_SCC.Trim() == "2")
        SplitContainer2.SplitterDistance = 1;

      Tab3.Text = str;

      if (M_Kieu_Xem == "HEN")
        CmdUp_TG_GX_KH_SCC.Visible = false;
      else
        CmdUp_TG_GX_KH_SCC.Visible = true;
    }
    private void V_LoadDatabas_Ngam_Dinh_KH_SCC()
    {
      DataSet dataSet = new DataSet(); // CP_RO_CVDV_KH_SCC_Ngam_Dinh"

      Dt_ConFigColor_KH_SCC = dataSet.Tables[0].Copy();
      Dt_Set_SCC = dataSet.Tables[1].Copy();
      Dt_Buoc_Nhay_KH_SCC = dataSet.Tables[2].Copy();
      Dt_Do_Rong_KH_SCC = dataSet.Tables[3].Copy();
      DmCVDV_Loc_KH_SCC = dataSet.Tables[4].Copy();
      DmCVDV_KH_SCC = DmCVDV_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(DmCVDV_KH_SCC, "Ma_HS");
      Dv_DmCVDV_KH_SCC = new DataView(DmCVDV_KH_SCC);

      DmCVDV_KH_SCC_H = dataSet.Tables[5].Copy();
      DmKhoang_Loc_KH_SCC = dataSet.Tables[6].Copy();
      DmKhoang_KH_SCC = DmKhoang_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(DmKhoang_KH_SCC, "Ma_khoang");
      Dv_DmKhoang_KH_SCC = new DataView(DmKhoang_KH_SCC);

      DmKhoang_KH_SCC_H = dataSet.Tables[7].Copy();
      DmTo_Loc_KH_SCC = dataSet.Tables[8].Copy();
      DmTo_KH_SCC = DmTo_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(DmTo_KH_SCC, "Ma_TO");
      Dv_DmTo_KH_SCC = new DataView(DmTo_KH_SCC);

      DmTo_KH_SCC_H = dataSet.Tables[9].Copy();
      DmKTV_Loc_KH_SCC = dataSet.Tables[10].Copy();
      DmKTV_KH_SCC = DmKTV_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(DmKTV_KH_SCC, "Ma_HS");
      Dv_DmKTV_KH_SCC = new DataView(DmKTV_KH_SCC);

      DmKTV_KH_SCC_H = dataSet.Tables[11].Copy();
      Dt_Data_KTV_KH_SCC = dataSet.Tables[12].Copy();
      Dv_Data_KTV_KH_SCC = new DataView(Dt_Data_KTV_KH_SCC);
      DmCd_Loc_KH_SCC = dataSet.Tables[13].Copy();
      DmCd_KH_SCC = DmCd_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(DmCd_KH_SCC, "Ma_CD");
      Dv_DmCd_KH_SCC = new DataView(DmCd_KH_SCC);

      DmCd_KH_SCC_H = dataSet.Tables[14].Copy();
      DmLoai_Xem_Loc_KH_SCC = dataSet.Tables[15].Copy();
      DmLoai_Xem_KH_SCC = DmLoai_Xem_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(DmLoai_Xem_KH_SCC, "Loai");
      Dv_DmLoai_Xem_KH_SCC = new DataView(DmLoai_Xem_KH_SCC);

      DmMucSBD_Loc_KH_SCC = dataSet.Tables[16].Copy();
      DmMucSBD_KH_SCC = DmMucSBD_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(DmMucSBD_KH_SCC, "Muc_SBD");
      Dv_DmMucSBD_KH_SCC = new DataView(DmMucSBD_KH_SCC);

      DmMucSDS_Loc_KH_SCC = dataSet.Tables[17].Copy();
      DmMucSDS_KH_SCC = DmMucSDS_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(DmMucSDS_KH_SCC, "Muc_SDS");
      Dv_DmMucSDS_KH_SCC = new DataView(DmMucSDS_KH_SCC);

      DmTang_Loc_KH_SCC = dataSet.Tables[19].Copy();
      DmTang_KH_SCC = DmTang_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(DmTang_KH_SCC, "Tang");
      Dv_DmTang_KH_SCC = new DataView(DmTang_KH_SCC);

      DmDungSC = dataSet.Tables[19].Copy();

      if (dataSet.Tables.Count > 20)
        Dt_Khoang_H = dataSet.Tables[20].Copy();

      if (dataSet.Tables.Count > 21)
        Dt_Xe_H = dataSet.Tables[21].Copy();

      Fill_Cbb(1);

      M_StartHour = Convert.ToInt32(Dt_Set_SCC.Rows[0]["StartHour"]);
      M_FinishHour = Convert.ToInt32(Dt_Set_SCC.Rows[0]["FinishHour"]);
      M_StartMINUTE = Convert.ToInt32(Dt_Set_SCC.Rows[0]["StartMINUTE"]);
      M_FinishMINUTE = Convert.ToInt32(Dt_Set_SCC.Rows[0]["FinishMINUTE"]);
      M_Ngay_LimitInterval_Min = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_LimitInterval_Min"]);
      M_Ngay_LimitInterval_Max = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_LimitInterval_Max"]);
      M_Thu_Bay = Dt_Set_SCC.Rows[0]["Thu_Bay"].ToString().Trim();
      M_Chu_Nhat = Dt_Set_SCC.Rows[0]["Chu_Nhat"].ToString().Trim();
      SchedulerControl_KH_SCC.LimitInterval.Start = M_Ngay_LimitInterval_Min;
      SchedulerControl_KH_SCC.LimitInterval.End = M_Ngay_LimitInterval_Max;
      SchedulerControl_KH_SCC.Start = Convert.ToDateTime(Dt_Set_SCC.Rows[0]["Ngay_Ct"]);
      Dt_Xem_Gio = new DataTable()
      {
        Columns = {
          "Gio_Xem",
          "Ten",
          "Ten2",
          "Default"
        },
        Rows = {
          new object[4] { "01", "Theo giờ", "Hour", "1" },
          new object[4] { "02", "Tiến độ", "Hour", "0" }
        }
      };

      CyberFunc.V_FillComBoxDefaul(CbbGio_Xem, Dt_Xem_Gio, "Gio_Xem", "Ten");
    }
    private void Fill_Cbb(int _All)
    {
      CyberFunc.V_FillComBoxDefaul(CbbCVDV_KH_SCC, DmCVDV_Loc_KH_SCC, "Ma_Hs", "Ten_Hs", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(CbbKhoang_KH_SCC, DmKhoang_Loc_KH_SCC, "Ma_Khoang", "Ten_Khoang", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(CbbTo_KH_SCC, DmTo_Loc_KH_SCC, "Ma_To", "Ten_To", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(CbbMuc_SDS_KH_SCC, DmCd_Loc_KH_SCC, "Ma_CD", "Ten_CD", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(CbbMuc_SBD_KH_SCC, DmMucSBD_Loc_KH_SCC, "Muc_SBD", "ten_SBD", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(CbbMuc_SDS_KH_SCC, DmMucSDS_Loc_KH_SCC, "Muc_SDS", "ten_SDS", "Ngam_Dinh");
      
      if (_All != 1)
        return;
      
      CyberFunc.V_FillComBoxDefaul(CbbLoai_Xem_KH_SCC, DmLoai_Xem_Loc_KH_SCC, "Loai", "Ten_Loai", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(CbbTang_KH_SCC, DmTang_Loc_KH_SCC, "Tang", "Ten_Tang", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(CbbMa_BN_KH_SCC, Dt_Buoc_Nhay_KH_SCC, "Ma_BN", "Ten_BN", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(CbbDo_Rong_KH_SCC, Dt_Do_Rong_KH_SCC, "Ma_Width", "Ten_Width", "Ngam_Dinh");
    }
    private void V_CyberSetTime_KH_SCC()
    {
      Decimal num1 = new Decimal(M_StartHour);
      Decimal num2 = new Decimal(M_StartMINUTE);
      Decimal num3 = new Decimal(M_FinishHour);
      Decimal num4 = new Decimal(M_FinishMINUTE);

      if (SchedulerControl_KH_SCC.ActiveViewType == SchedulerViewType.Gantt)
      {
        TimeScaleCollection scales = SchedulerControl_KH_SCC.GanttView.Scales;
        scales.BeginUpdate();
        try
        {
          scales.Clear();
          TimeScaleLessThanDay scaleLessThanDay1 = new TimeScaleLessThanDay(TimeSpan.FromHours(1.0), M_StartHour, M_FinishHour, M_Ngay_LimitInterval_Min, M_Ngay_LimitInterval_Max, M_Thu_Bay, M_Chu_Nhat);
          TimeScaleLessThanDay scaleLessThanDay2 = new TimeScaleLessThanDay(TimeSpan.FromMinutes(Convert.ToDouble(CyberFunc.V_GetvalueCombox(CbbMa_BN_KH_SCC))), M_StartHour, M_FinishHour, M_Ngay_LimitInterval_Min, M_Ngay_LimitInterval_Max, M_Thu_Bay, M_Chu_Nhat);
          scales.Add((TimeScale)new TimeScaleYear());
          scales.Add((TimeScale)new TimeScaleQuarter());
          scales.Add((TimeScale)new TimeScaleMonth());
          scales.Add((TimeScale)new TimeScaleWeek());
          scales.Add((TimeScale)new CyberTimeScaleDay(M_StartHour, M_FinishHour, M_Ngay_LimitInterval_Min, M_Ngay_LimitInterval_Max));
          scales.Add((TimeScale)scaleLessThanDay1);
          scales.Add((TimeScale)scaleLessThanDay2);
        }
        finally
        {
          SchedulerControl_KH_SCC.GanttView.Scales[0].Visible = false;
          SchedulerControl_KH_SCC.GanttView.Scales[1].Visible = false;
          SchedulerControl_KH_SCC.GanttView.Scales[2].Visible = false;
          SchedulerControl_KH_SCC.GanttView.Scales[3].Visible = false;
          SchedulerControl_KH_SCC.GanttView.Scales[4].Visible = true;
          SchedulerControl_KH_SCC.GanttView.Scales[5].Visible = true;
          SchedulerControl_KH_SCC.Views.GanttView.Scales[6].DisplayFormat = "mm";
          if (CbbMa_BN_KH_SCC.SelectedValue == (object)60)
            SchedulerControl_KH_SCC.GanttView.Scales[6].Visible = false;
          else
            SchedulerControl_KH_SCC.GanttView.Scales[6].Visible = true;
          scales.EndUpdate();
        }
      }
      else
      {
        if (SchedulerControl_KH_SCC.ActiveViewType != SchedulerViewType.Day)
          return;

        SchedulerControl_KH_SCC.Views.DayView.ShowWorkTimeOnly = true;
        TimeSpan timeSpan1 = new TimeSpan(Convert.ToInt32(num1), Convert.ToInt32(num2), 0);
        TimeSpan timeSpan2 = new TimeSpan(Convert.ToInt32(num3), Convert.ToInt32(num4), 0);
        SchedulerControl_KH_SCC.Views.DayView.WorkTime.End = new TimeSpan(M_FinishHour, M_FinishMINUTE, 0);
        SchedulerControl_KH_SCC.Views.DayView.WorkTime.Start = timeSpan1;
        SchedulerControl_KH_SCC.Views.DayView.WorkTime.End = timeSpan2;
        SchedulerControl_KH_SCC.Views.DayView.TimeScale = TimeSpan.FromMinutes(Convert.ToDouble(CyberFunc.V_GetvalueCombox(CbbMa_BN_KH_SCC)));
      }
    }
    public void V_Load_DATA_KH_SCC(string status, string _Stt_Rec_Ro_Load, string _Stt_Rec_Load)
    {
      SchedulerStorage_KH_SCC.Appointments.AutoReload = false;
      SchedulerControl_KH_SCC.BeginUpdate();
      string upper = CyberFunc.V_GetvalueCombox(CbbLoai_Xem_KH_SCC).ToString().Trim().ToUpper();
      DateTime date = Convert.ToDateTime(TxtM_Ngay_Ct_KH_SCC.EditValue);

      DataSet dataSet = new DataSet(); // CP_RO_CVDV_KH_SCC_DATA
      int num = checked(dataSet.Tables.Count - 1);
      int index = 0;
      while (index <= num)
      {
        CyberFunc.SetNotNullTable(dataSet.Tables[index]);
        checked { ++index; }
      }
      if (status == "1")
      {
        LabTotal.Text = "";
        Dt_Data_KH_SCC = (DataTable)null;
        Dt_Data_Xe_KH_SCC = (DataTable)null;
        Dt_Data_Parent_KH_SCC = (DataTable)null;
        if (dataSet.Tables.Count > 0)
        {
          Dt_Data_KH_SCC = dataSet.Tables[0].Copy();
          Dv_Data_KH_SCC = new DataView(Dt_Data_KH_SCC);
        }
        if (dataSet.Tables.Count > 1)
        {
          Dt_Data_Xe_KH_SCC = dataSet.Tables[1].Copy();
          Dv_Data_Xe_KH_SCC = new DataView(Dt_Data_Xe_KH_SCC);
        }
        if (dataSet.Tables.Count > 2)
        {
          Dt_Data_Parent_KH_SCC = dataSet.Tables[2].Copy();
          Dv_Data_Parent_KH_SCC = new DataView(Dt_Data_Parent_KH_SCC);
        }
        _BackColor_Data_KH_SCC = Dt_Data_KH_SCC.Columns.Contains("BackColor");
        _BackColor2_Data_KH_SCC = Dt_Data_KH_SCC.Columns.Contains("BackColor2");
        _ForeColor_Data_KH_SCC = Dt_Data_KH_SCC.Columns.Contains("ForeColor");
        _BorderColor_Data_KH_SCC = Dt_Data_KH_SCC.Columns.Contains("BorderColor");
        _Bold_Data_KH_SCC = Dt_Data_KH_SCC.Columns.Contains("Bold");
        _Underline_KH_SCC = Dt_Data_KH_SCC.Columns.Contains("Underline");
        if (_BackColor_Data_KH_SCC)
          _BackColorField_Data_KH_SCC = Dt_Data_KH_SCC.Columns["BackColor"].ColumnName;
        if (_BackColor2_Data_KH_SCC)
          _BackColorField2_Data_KH_SCC = Dt_Data_KH_SCC.Columns["BackColor2"].ColumnName;
        if (_ForeColor_Data_KH_SCC)
          _ForeColorField_Data_KH_SCC = Dt_Data_KH_SCC.Columns["ForeColor"].ColumnName;
        if (_BorderColor_Data_KH_SCC)
          _BorderColorField_Data_KH_SCC = Dt_Data_KH_SCC.Columns["BorderColor"].ColumnName;
        if (_Bold_Data_KH_SCC)
          _BoldField_Data_KH_SCC = Dt_Data_KH_SCC.Columns["Bold"].ColumnName;
        if (_Underline_KH_SCC)
          _UnderlineField_KH_SCC = Dt_Data_KH_SCC.Columns["Underline"].ColumnName;
      }
      else if (_Stt_Rec_Ro_Load.Trim() == "" & _Stt_Rec_Load.Trim() == "")
      {
        Dt_Data_KH_SCC.Clear();
        Dt_Data_KH_SCC.Load((IDataReader)dataSet.Tables[0].CreateDataReader());
        if (dataSet.Tables.Count > 1 & Dt_Data_Xe_KH_SCC != null)
        {
          Dt_Data_Xe_KH_SCC.Clear();
          Dt_Data_Xe_KH_SCC.Load((IDataReader)dataSet.Tables[1].CreateDataReader());
        }
        if (dataSet.Tables.Count > 2 & Dt_Data_Parent_KH_SCC != null)
        {
          Dt_Data_Parent_KH_SCC.Clear();
          Dt_Data_Parent_KH_SCC.Load((IDataReader)dataSet.Tables[2].CreateDataReader());
        }
      }
      else
      {
        if (dataSet.Tables.Count > 0 & Dt_Data_KH_SCC != null)
        {
          V_Delete_KH_SCC_DATA(Dt_Data_KH_SCC, _Stt_Rec_Ro_Load, _Stt_Rec_Load);
          Dt_Data_KH_SCC.Load((IDataReader)dataSet.Tables[0].CreateDataReader());
        }
        if (dataSet.Tables.Count > 1 & Dt_Data_Xe_KH_SCC != null)
        {
          DataTable table = dataSet.Tables[1];
          V_UpdateAndInsertDataxe(ref table);
        }
      }
      dataSet.Dispose();

      V_Update_Ten3();
      V_Dang_Sua_Chua((object)"");
      SchedulerControl_KH_SCC.EndUpdate();

      V_Filter_KH_SCC(new object(), new EventArgs());
      SchedulerControl_KH_SCC.Storage.RefreshData();
      SchedulerStorage_KH_SCC.Appointments.AutoReload = true;

      if (status == "0")
        V_Lock_Xem();

      V_start_Flass(status);
    }
    private void V_AddHander_KH_SCC()
    {
      this.CbbGio_Xem.SelectedIndexChanged -= new EventHandler(this.V_Gio_Xem);
      this.LabLock.Click -= new EventHandler(this.V_Lock_Data);
      this.CmdRefresh_KH_SCC.Click -= new EventHandler(this.V_RefreshData_KH_SCC);
      this.CmdUp_TG_GX_KH_SCC.Click -= new EventHandler(this.V_UP_TG_TX_KH_SCC);
      this.SchedulerControl_KH_SCC.PopupMenuShowing -= new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(this.V_PopupMenu_KH_SCC);
      this.SchedulerControl_KH_SCC.EditAppointmentFormShowing -= new AppointmentFormEventHandler(this.V_Lap_F3F4_KH_SCC);
      this.SchedulerControl_KH_SCC.DoubleClick -= new EventHandler(this.V_Sua_Tien_Do_KH_SCC);
      this.TxtM_Ngay_Ct_KH_SCC.TextChanged -= new EventHandler(this.V_Ngay_Ct_KH_SCC);
      this.CbbLoai_Xem_KH_SCC.SelectedValueChanged -= new EventHandler(this.V_ChangeValue);
      this.ChkAuto_Data_KH_SCC.CheckedChanged -= new EventHandler(this.V_Auto_Data_KH_SCC);
      this.CbbTime_Data_KH_SCC.SelectedValueChanged -= new EventHandler(this.V_Auto_Data_KH_SCC);
      this.Timer_Data_KH_SCC.Tick -= new EventHandler(this.V_Timer_Data_KH_SCC);
      this.CbbMa_BN_KH_SCC.SelectedValueChanged -= new EventHandler(this.V_Buoc_Nhay_KH_SCC);
      this.CbbDo_Rong_KH_SCC.SelectedValueChanged -= new EventHandler(this.V_Do_Rong_KH_SCC);
      this.ChkFV_KH_SCC.Click -= new EventHandler(this.V_Filter_KH_SCC);
      this.ChkDung_KH_SCC.Click -= new EventHandler(this.V_Filter_KH_SCC);
      this.ChkSDS_KH_SCC.Click -= new EventHandler(this.V_Filter_KH_SCC);
      this.ChkCho_Rua_KH_SCC.Click -= new EventHandler(this.V_Filter_KH_SCC);
      this.ChkDang_Rua_KH_SCC.Click -= new EventHandler(this.V_Filter_KH_SCC);
      this.ChkCho_Giao_KH_SCC.Click -= new EventHandler(this.V_Filter_KH_SCC);
      this.ChkGiao_Ngay_Kh_SCC.Click -= new EventHandler(this.V_Filter_KH_SCC);
      this.ChkEM60_KH_SCC.Click -= new EventHandler(this.V_Filter_KH_SCC);
      this.ChkPM90_KH_SCC.Click -= new EventHandler(this.V_Filter_KH_SCC);
      this.ChkSCL_KH_SCC.Click -= new EventHandler(this.V_Filter_KH_SCC);
      this.ChkSBD_KH_SCC.Click -= new EventHandler(this.V_ChkSBD_KH_SCC);
      this.ChkIs_EM_KH_SCC.Click -= new EventHandler(this.V_ChkIs_EM_KH_SCC);
      this.ChkIs_GJ_KH_SCC.Click -= new EventHandler(this.V_ChkIs_GJ_KH_SCC);
      this.CbbMuc_SBD_KH_SCC.SelectedIndexChanged -= new EventHandler(this.V_Filter_KH_SCC);
      this.CbbMuc_SDS_KH_SCC.SelectedIndexChanged -= new EventHandler(this.V_Filter_KH_SCC);
      this.CbbCVDV_KH_SCC.SelectedValueChanged -= new EventHandler(this.V_Filter_KH_SCC);
      this.CbbKhoang_KH_SCC.SelectedValueChanged -= new EventHandler(this.V_Filter_KH_SCC);
      this.CbbTo_KH_SCC.SelectedValueChanged -= new EventHandler(this.V_Filter_KH_SCC);
      this.CbbCD_KH_SCC.SelectedValueChanged -= new EventHandler(this.V_Filter_KH_SCC);
      this.CbbTang_KH_SCC.SelectedValueChanged -= new EventHandler(this.V_Filter_KH_SCC);
      this.TxtMa_Xe_KH_SCC.TextChanged -= new EventHandler(this.V_Filter_KH_SCC);
      this.TxtSo_RO_KH_SCC.TextChanged -= new EventHandler(this.V_So_RO_KH_SCC);
      this.SchedulerControl_KH_SCC.AppointmentDrop -= new AppointmentDragEventHandler(this.SchedulerControl_KH_SCC_AppointmentDrop);
      this.SchedulerControl_KH_SCC.AppointmentResized -= new AppointmentResizeEventHandler(this.SchedulerControl_KH_SCC_AppointmentResized);
      this.SchedulerControl_KH_SCC.CustomDrawTimeIndicator -= new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.SchedulerControl_CustomDrawTimeIndicator);
      this.SchedulerControl_KH_SCC.CustomDrawTimeCell -= new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.V_CustomDrawTimeCell);
      this.SchedulerControl_KH_SCC.CustomDrawAppointmentBackground -= new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.SchedulerControl_CustomDrawAppointmentBackground);
      this.SchedulerControl_KH_SCC.AppointmentViewInfoCustomizing -= new AppointmentViewInfoCustomizingEventHandler(this.V_AppointmentViewInfoCustomizing);
      this.SchedulerControl_KH_SCC.InitAppointmentImages -= new AppointmentImagesEventHandler(this.SchedulerControl_InitAppointmentImages);
      this.SchedulerControl_KH_SCC.InitAppointmentImages += new AppointmentImagesEventHandler(this.SchedulerControl_InitAppointmentImages);
      this.CbbGio_Xem.SelectedIndexChanged += new EventHandler(this.V_Gio_Xem);
      this.LabLock.Click += new EventHandler(this.V_Lock_Data);
      this.CmdRefresh_KH_SCC.Click += new EventHandler(this.V_RefreshData_KH_SCC);
      this.CmdUp_TG_GX_KH_SCC.Click += new EventHandler(this.V_UP_TG_TX_KH_SCC);
      this.SchedulerControl_KH_SCC.PopupMenuShowing += new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(this.V_PopupMenu_KH_SCC);
      this.SchedulerControl_KH_SCC.EditAppointmentFormShowing += new AppointmentFormEventHandler(this.V_Lap_F3F4_KH_SCC);
      this.SchedulerControl_KH_SCC.DoubleClick += new EventHandler(this.V_Sua_Tien_Do_KH_SCC);
      this.TxtM_Ngay_Ct_KH_SCC.TextChanged += new EventHandler(this.V_Ngay_Ct_KH_SCC);
      this.CbbLoai_Xem_KH_SCC.SelectedValueChanged += new EventHandler(this.V_ChangeValue);
      this.ChkAuto_Data_KH_SCC.CheckedChanged += new EventHandler(this.V_Auto_Data_KH_SCC);
      this.CbbTime_Data_KH_SCC.SelectedValueChanged += new EventHandler(this.V_Auto_Data_KH_SCC);
      this.Timer_Data_KH_SCC.Tick += new EventHandler(this.V_Timer_Data_KH_SCC);
      this.CbbMa_BN_KH_SCC.SelectedValueChanged += new EventHandler(this.V_Buoc_Nhay_KH_SCC);
      this.CbbDo_Rong_KH_SCC.SelectedValueChanged += new EventHandler(this.V_Do_Rong_KH_SCC);
      this.ChkFV_KH_SCC.Click += new EventHandler(this.V_Filter_KH_SCC);
      this.ChkDung_KH_SCC.Click += new EventHandler(this.V_Filter_KH_SCC);
      this.ChkSDS_KH_SCC.Click += new EventHandler(this.V_Filter_KH_SCC);
      this.ChkCho_Rua_KH_SCC.Click += new EventHandler(this.V_Filter_KH_SCC);
      this.ChkDang_Rua_KH_SCC.Click += new EventHandler(this.V_Filter_KH_SCC);
      this.ChkCho_Giao_KH_SCC.Click += new EventHandler(this.V_Filter_KH_SCC);
      this.ChkGiao_Ngay_Kh_SCC.Click += new EventHandler(this.V_Filter_KH_SCC);
      this.ChkEM60_KH_SCC.Click += new EventHandler(this.V_Filter_KH_SCC);
      this.ChkPM90_KH_SCC.Click += new EventHandler(this.V_Filter_KH_SCC);
      this.ChkSCL_KH_SCC.Click += new EventHandler(this.V_Filter_KH_SCC);
      this.ChkSBD_KH_SCC.Click += new EventHandler(this.V_ChkSBD_KH_SCC);
      this.ChkIs_EM_KH_SCC.Click += new EventHandler(this.V_ChkIs_EM_KH_SCC);
      this.ChkIs_GJ_KH_SCC.Click += new EventHandler(this.V_ChkIs_GJ_KH_SCC);
      this.CbbMuc_SBD_KH_SCC.SelectedIndexChanged += new EventHandler(this.V_Filter_KH_SCC);
      this.CbbMuc_SDS_KH_SCC.SelectedIndexChanged += new EventHandler(this.V_Filter_KH_SCC);
      this.CbbCVDV_KH_SCC.SelectedValueChanged += new EventHandler(this.V_Filter_KH_SCC);
      this.CbbKhoang_KH_SCC.SelectedValueChanged += new EventHandler(this.V_Filter_KH_SCC);
      this.CbbTo_KH_SCC.SelectedValueChanged += new EventHandler(this.V_Filter_KH_SCC);
      this.CbbCD_KH_SCC.SelectedValueChanged += new EventHandler(this.V_Filter_KH_SCC);
      this.CbbTang_KH_SCC.SelectedValueChanged += new EventHandler(this.V_Filter_KH_SCC);
      this.TxtMa_Xe_KH_SCC.TextChanged += new EventHandler(this.V_Filter_KH_SCC);
      this.TxtSo_RO_KH_SCC.TextChanged += new EventHandler(this.V_So_RO_KH_SCC);
      this.SchedulerControl_KH_SCC.AppointmentDrop += new AppointmentDragEventHandler(this.SchedulerControl_KH_SCC_AppointmentDrop);
      this.SchedulerControl_KH_SCC.AppointmentResized += new AppointmentResizeEventHandler(this.SchedulerControl_KH_SCC_AppointmentResized);
      this.SchedulerControl_KH_SCC.CustomDrawTimeIndicator += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.SchedulerControl_CustomDrawTimeIndicator);
      this.SchedulerControl_KH_SCC.CustomDrawTimeCell += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.V_CustomDrawTimeCell);
      this.SchedulerControl_KH_SCC.CustomDrawAppointmentBackground += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.SchedulerControl_CustomDrawAppointmentBackground);
      this.SchedulerControl_KH_SCC.AppointmentViewInfoCustomizing += new AppointmentViewInfoCustomizingEventHandler(this.V_AppointmentViewInfoCustomizing);
      this.SchedulerControl_KH_SCC.CustomDrawDayHeader -= new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControl_CustomDrawDayHeader);
      this.SchedulerControl_KH_SCC.CustomDrawDayHeader += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControl_CustomDrawDayHeader);
      this.ResourcesTree1.CustomDrawNodeCell -= new CustomDrawNodeCellEventHandler(this.ResourcesTree1_CustomDrawNodeCell);
      this.ResourcesTree1.CustomDrawNodeCell += new CustomDrawNodeCellEventHandler(this.ResourcesTree1_CustomDrawNodeCell);
      this.TabCVDV.SelectedIndexChanged -= new EventHandler(this.TabCVDV_SelectedIndexChanged);
      this.TabCVDV.SelectedIndexChanged += new EventHandler(this.TabCVDV_SelectedIndexChanged);
      this.ChkDu_kien_giaoCVDV.CheckedChanged -= new EventHandler(this.V_Du_Kien_Giao);
      this.ChkDu_kien_giaoCVDV.CheckedChanged += new EventHandler(this.V_Du_Kien_Giao);
      this.ChkShow_All_Cd_Xe.CheckedChanged -= new EventHandler(this.V_Du_All_Xe_Cd);
      this.ChkShow_All_Cd_Xe.CheckedChanged += new EventHandler(this.V_Du_All_Xe_Cd);
      this.buttRemove_Filter.Click -= new EventHandler(this.V_Remove_Filter);
      this.buttRemove_Filter.Click += new EventHandler(this.V_Remove_Filter);
    }
    private void V_SetSchedulerControl_KH_SCC()
    {
      SchedulerControl_KH_SCC.DateNavigationBar.Visible = false;
      SchedulerControl_KH_SCC.ActiveViewType = SchedulerViewType.Gantt;
      SchedulerControl_KH_SCC.Views.GanttView.Scales[6].Width = Convert.ToInt32(Dt_Set_SCC.Rows[0]["HourWidth"]);
      SchedulerControl_KH_SCC.Views.GanttView.ResourcesPerPage = Convert.ToInt32(Dt_Set_SCC.Rows[0]["RowPage"]);
      SchedulerControl_KH_SCC.GroupType = SchedulerGroupType.Resource;

      V_SetSchedulerSetValue();
      V_SetColorAppointments();

      if (DmKhoang_KH_SCC.Columns.Contains("Color"))
        SchedulerStorage_KH_SCC.Resources.Mappings.Color = DmKhoang_KH_SCC.Columns["Color"].ColumnName.ToString().Trim();
      if (DmKhoang_KH_SCC.Columns.Contains("Image"))
        SchedulerStorage_KH_SCC.Resources.Mappings.Image = DmKhoang_KH_SCC.Columns["Image"].ColumnName.ToString().Trim();

      SchedulerStorage_KH_SCC.Appointments.DataSource = (object)Dv_Data_KH_SCC;
      SchedulerStorage_KH_SCC.Appointments.Mappings.AllDay = "AllDay";
      SchedulerStorage_KH_SCC.Appointments.Mappings.AppointmentId = Dt_Data_KH_SCC.Columns["Stt_Rec"].ColumnName;

      if (Dt_Data_KH_SCC.Columns.Contains("Dien_Giai"))
        SchedulerStorage_KH_SCC.Appointments.Mappings.Description = Dt_Data_KH_SCC.Columns["Dien_Giai"].ColumnName;

      SchedulerStorage_KH_SCC.Appointments.Mappings.Start = Dt_Data_KH_SCC.Columns["Ngay_BD"].ColumnName;
      SchedulerStorage_KH_SCC.Appointments.Mappings.End = Dt_Data_KH_SCC.Columns["Ngay_KT"].ColumnName;
      SchedulerControl_KH_SCC.Views.GanttView.AppointmentDisplayOptions.AutoAdjustForeColor = false;

      if (Dt_Data_KH_SCC.Columns.Contains("Size_Border"))
        SchedulerStorage_KH_SCC.Appointments.Mappings.Status = Dt_Data_KH_SCC.Columns["Size_Border"].ColumnName;
      if (Dt_Data_KH_SCC.Columns.Contains("PercentComplete"))
        SchedulerStorage_KH_SCC.Appointments.Mappings.PercentComplete = Dt_Data_KH_SCC.Columns["PercentComplete"].ColumnName;
      else
        SchedulerControl_KH_SCC.Views.GanttView.AppointmentDisplayOptions.PercentCompleteDisplayType = PercentCompleteDisplayType.None;
      if (Dt_Data_KH_SCC.Columns.Contains("Type"))
        SchedulerStorage_KH_SCC.Appointments.Mappings.Type = Dt_Data_KH_SCC.Columns["Type"].ColumnName;

      SchedulerControl_KH_SCC.OptionsView.ToolTipVisibility = ToolTipVisibility.Always;

      if (M_Loai_KH_SCC.Trim() == "2" & M_Kieu_Xem != "HEN")
        SchedulerControl_KH_SCC.GanttView.Appearance.Appointment.ForeColor = System.Drawing.Color.Navy;
      else
        SchedulerControl_KH_SCC.GanttView.Appearance.Appointment.ForeColor = System.Drawing.Color.White;

      SchedulerControl_KH_SCC.GanttView.Appearance.Appointment.Font = new Font(SchedulerControl_KH_SCC.DayView.Appearance.Appointment.Font.FontFamily, 10f);
      SchedulerControl_KH_SCC.Views.GanttView.AppointmentDisplayOptions.StartTimeVisibility = AppointmentTimeVisibility.Never;
      SchedulerControl_KH_SCC.Views.GanttView.AppointmentDisplayOptions.EndTimeVisibility = AppointmentTimeVisibility.Never;
      SchedulerControl_KH_SCC.Views.GanttView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Disabled;
    }
    private void V_SetRowHeight_KH_SCC()
    {
      if (!_TabVisible3)
        return;

      Decimal num = 0M;
      Decimal d1_1 = 0M;
      if (Dt_Set_SCC == null || Dt_Set_SCC.Rows.Count == 0)
        return;

      if (Dt_Set_SCC.Columns.Contains("RowHeight"))
        num = Convert.ToDecimal(Dt_Set_SCC.Rows[0]["RowHeight"]);
      if (Dt_Set_SCC.Columns.Contains("RowPage"))
        d1_1 = Convert.ToDecimal(Dt_Set_SCC.Rows[0]["RowPage"]);
      if (((ulong)-(Decimal.Compare(num, 0M) == 0 ? 1 : 0) & (ulong)Convert.ToInt64(d1_1)) > 0UL)
        return;

      Decimal d1_2 = new Decimal(checked(SchedulerControl_KH_SCC.Size.Height - 70));
      if (Decimal.Compare(num, 0M) > 0)
        d1_1 = Convert.ToDecimal(Math.Round(Decimal.Divide(d1_2, num), 0, MidpointRounding.AwayFromZero));
      if (Decimal.Compare(d1_1, 0M) <= 0)
        return;

      SchedulerControl_KH_SCC.Views.GanttView.ResourcesPerPage = Convert.ToInt32(d1_1);
    }
    private void V_Auto_Data_KH_SCC(object sender, EventArgs e)
    {
      Timer_Data_KH_SCC.Enabled = ChkAuto_Data_KH_SCC.Checked;
      CbbTime_Data_KH_SCC.Enabled = ChkAuto_Data_KH_SCC.Checked;
      Decimal d1 = CyberFunc.V_StringToNumeric(CbbTime_Data_KH_SCC);
      if (Decimal.Compare(d1, 0M) <= 0)
        d1 = 3000M;
      Timer_Data_KH_SCC.Interval = Convert.ToInt32(d1);
    }
    private void V_Buoc_Nhay_KH_SCC(object sender, EventArgs e)
    {
      V_CyberSetTime_KH_SCC();
      V_Do_Rong_KH_SCC(sender, e);
    }
    private void V_Do_Rong_KH_SCC(object sender, EventArgs e)
    {
      int index = 0;
      do
      {
        if (SchedulerControl_KH_SCC.GanttView.Scales[index].Visible)
          SchedulerControl_KH_SCC.Views.GanttView.Scales[index].Width = Convert.ToInt32(CyberFunc.V_GetvalueCombox(CbbDo_Rong_KH_SCC));
        checked { ++index; }
      }
      while (index <= 6);
    }
    private void V_Load_Cho_Lap_KH()
    {
      V_LoadData_Cho_Lap_KH("1", "");
      V_Fill_Cho_Lap_KH();
      V_Fill_Sua_Xong_KH();
      V_AddHander_Cho_Lap_KH();

      if (M_Kieu_Xem.Trim() != "HEN" & M_Loai_KH_SCC.Trim() == "1")
        V_DragDropGridview_KH_SCC();

      if (M_Kieu_Xem.Trim() == "HEN" | Dt_Sua_Xong_KH == null)
      {
        TabControl tabSuaXongMauXe = TabSua_Xong_Mau_XE;
        ref TabControl local = ref tabSuaXongMauXe;
        CyberFunc.V_HideTapPage(ref local, "TabPage_Sua_Xong");
        TabSua_Xong_Mau_XE = tabSuaXongMauXe;
      }

      T_tinh_So_Xe();
    }
    private void V_Lock_Xem()
    {
      DataSet dataSet = new DataSet(); // CP_RO_CVDV_Lock_Xem
      if (dataSet.Tables.Count == 0)
        dataSet.Dispose();
      else if (dataSet.Tables[0].Rows.Count == 0)
        dataSet.Dispose();
      else
      {
        if (dataSet.Tables[0].Columns.Contains("Caption_Lock"))
          LabLock.Text = Convert.ToString(dataSet.Tables[0].Rows[0]["Caption_Lock"]);
        if (dataSet.Tables[0].Columns.Contains("BackColor"))
          LabLock.BackColor = CyberColor.GetBackColor(Convert.ToString(dataSet.Tables[0].Rows[0]["BackColor"]));
        if (dataSet.Tables[0].Columns.Contains("ForeColor"))
          LabLock.ForeColor = CyberColor.GetForeColor(Convert.ToString(dataSet.Tables[0].Rows[0]["ForeColor"]));

        dataSet?.Dispose();
      }
    }
    private void V_LoadTimeLine()
    {
      TimeIntervalCollection visibleIntervals = SchedulerControl_KH_SCC.ActiveView.GetVisibleIntervals();
      TimeSpan timeSpan = visibleIntervals[checked(visibleIntervals.Count - 1)].End - visibleIntervals[0].Start;
      timeSpan = new TimeSpan(checked((long)Math.Round(unchecked((double)timeSpan.Ticks / 2.0))));
      SchedulerControl_KH_SCC.Start = DateTime.Now.AddTicks(checked(-timeSpan.Ticks));
    }
    private void V_AddHanderLabel_KH_SCC()
    {
      Lab_SCC_01.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_02.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_03.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_04.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_05.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_06.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_07.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_08.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_09.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_10.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_11.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_12.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_13.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_14.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_15.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_16.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_17.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_18.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_19.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_20.Paint -= new PaintEventHandler(Label_Paint_KH_SCC);

      LabTotal.Click -= new EventHandler(Label_Xem_BC_KH_SCC);

      Lab_SCC_01.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_02.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_03.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_04.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_05.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_06.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_07.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_08.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_09.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_10.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_11.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_12.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_13.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_14.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_15.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_16.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_17.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_18.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_19.Paint += new PaintEventHandler(Label_Paint_KH_SCC);
      Lab_SCC_20.Paint += new PaintEventHandler(Label_Paint_KH_SCC);

      LabTotal.Click += new EventHandler(Label_Xem_BC_KH_SCC);
    }
    private void Label_Paint_KH_SCC(object sender, PaintEventArgs e) => ResizeLabel_KH_SCC((Label)sender);
    public void Label_Xem_BC_KH_SCC(object sender, EventArgs e)
    {
      // TODO
    }
    private void ResizeLabel_KH_SCC(Label lab)
    {
      try
      {
        if (!lab.Visible)
          return;

        string str = lab.Tag.ToString();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
    private void V_GetHieghtSplitContainerKH_SC() => SplitContainerKH_SC.SplitterDistance = checked(SplitContainerKH_SC.Size.Height - 5 - Panel1.Height);
    #endregion

    #region "V_AddHander_KH_SCC"
    private void V_Gio_Xem(object sender, EventArgs e)
    {
      string Left = CyberFunc.V_GetvalueCombox(this.CbbGio_Xem);
      if (Left == "01")
        this.V_ActiView_Gantt(sender, e);

      if (Left == "02")
        return;

      this.V_ActiView_Day(sender, e);
    }
    private void V_ActiView_Gantt(object sender, EventArgs e)
    {
      this.SchedulerControl_KH_SCC.ActiveViewType = SchedulerViewType.Gantt;
      this.V_CyberSetTime_KH_SCC();
      this.SchedulerControl_KH_SCC.OptionsView.ResourceHeaders.Height = 80;
    }
    private void V_ActiView_Day(object sender, EventArgs e)
    {
      this.SchedulerControl_KH_SCC.ActiveViewType = SchedulerViewType.Day;
      this.V_CyberSetTime_KH_SCC();
      this.SchedulerControl_KH_SCC.OptionsView.ResourceHeaders.Height = 30;
    }
    private void V_Lock_Data(object sender, EventArgs e)
    {
      DataSet ds = new DataSet(); //TODO: CP_RO_CVDV_Lock_UnLock
      if (ds.Tables[0].Rows.Count == 0)
        return;

      this.V_Lock_Xem();
    }
    private void V_RefreshData_KH_SCC(object sender, EventArgs e)
    {
      this.V_Load_DATA_KH_SCC("0", "", "");
      this.V_LoadData_Cho_Lap_KH("0", "");
      this.V_Filter_KH_SCC(sender, e);
    }
    private void V_UP_TG_TX_KH_SCC(object sender, EventArgs e)
    {
      //TODO: call form
    }
    private void V_PopupMenu_KH_SCC(object sender, DevExpress.XtraScheduler.PopupMenuShowingEventArgs e)
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
      this.PopupMenuSchedulerControl.ItemLinks.Clear();

      if (this.M_Kieu_Xem != "HEN")
        this.PopupMenuSchedulerControl.ItemLinks.Add(new CyberMenuPopup(sender, rowHandle, "Tạo Kế hoạch sửa chữa", 
          new EventHandler(this.V_Tao_Tien_Do_KH_SCC), Shortcut.F4, ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), true), false);

      if (this.M_Kieu_Xem != "HEN" & this.M_Loai_KH_SCC == "2")
        this.PopupMenuSchedulerControl.ItemLinks.Add(new CyberMenuPopup(sender, rowHandle, "Tạo nhanh KHSC đồng sơn", 
          new EventHandler(this.V_Tao_KH_ALLS), Shortcut.F9, ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), true), false); // FrmCVDV_KH_SDSALL

      this.PopupMenuSchedulerControl.ItemLinks.Add(new CyberMenuPopup(sender, rowHandle, "Sửa Kế hoạch", 
        new EventHandler(this.V_Sua_Tien_Do_KH_SCC), Shortcut.F3, ImageResourceCache.Default.GetImage("images/edit/edit_16x16.png"), true), false);
      
      if (this.M_Kieu_Xem == "HEN")
        this.PopupMenuSchedulerControl.ItemLinks.Add(new CyberMenuPopup(sender, rowHandle, "Gọi xác nhận lịch hẹn", 
          new EventHandler(this.V_Hen_Call_KH_SCC), Shortcut.None, ImageResourceCache.Default.GetImage("images/edit/printernetwork_16x16.png"), true), false); // FrmCVDV_DLHen_Call

      if (this.M_Kieu_Xem != "HEN")
      {
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Chạy thử", 
            new EventHandler(this.V_KH_SCC_Chay_Thu), Shortcut.None, ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), true), true); // FrmCVDV_Chay_Thu

        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Dừng chạy thử", 
            new EventHandler(this.V_KH_SCC_Chay_Thu_Stop), Shortcut.None, ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), true), false);

        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Bắt đầu Dừng sửa chữa", 
            new EventHandler(this.V_KH_SCC_BD_Dung_SC), Shortcut.None, ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), true), true); // FrmCVDV_Dung_SC

        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Kết thúc Dừng sửa chữa", 
            new EventHandler(this.V_Data_KH_SCC_KT_Dung_SC), Shortcut.None, ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), true), false);

        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Xác nhận lệnh phát sinh", 
            new EventHandler(this.V_RO_PS), Shortcut.None, ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), true), true);

        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Q-Gate", 
            new EventHandler(this.V_KH_SCC_QGate), Shortcut.None, ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), true), true);
        
        if (this.M_Loai_KH_SCC == "2")
          this.PopupMenuSchedulerControl.ItemLinks.Add(
            new CyberMenuPopup(sender, rowHandle, "KCS công đoạn", 
              new EventHandler(this.V_KH_SCC_KCS_CD), Shortcut.None, ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), true), false);
        
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Tạo thông điệp chuyển tầng", 
            new EventHandler(this.V_Chuyen_Tang), Shortcut.None, ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), true), true);
      }

      if (this.M_Kieu_Xem == "HEN" | this.M_Loai_KH_SCC.Trim() == "1")
      {
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Tạo kế hoạch hẹn", 
            new EventHandler(this.V_Tao_Lich_Hen_KH_SCC), Shortcut.F6, ImageResourceCache.Default.GetImage("images/actions/showworktimeonly_16x16.png"), true), true);
        
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Tạo đặt chỗ", 
            new EventHandler(this.V_Tao_Dat_CHo_KH_SCC), Shortcut.F2, ImageResourceCache.Default.GetImage("images/actions/showworktimeonly_16x16.png"), true), false);
      }
      if (this.M_Kieu_Xem != "HEN")
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Chuyển lịch hẹn sang kế hoạch sửa chữa", 
            new EventHandler(this.V_Hen_To_Kh), Shortcut.None, ImageResourceCache.Default.GetImage("images/actions/refresh2_16x16.png"), true), true); // FrmCVDV_Hen_To_KH

      this.PopupMenuSchedulerControl.ItemLinks.Add(
        new CyberMenuPopup(sender, rowHandle, "Xóa kế hoạch", 
          new EventHandler(this.V_Xoa_KH_SCC), Shortcut.F8, ImageResourceCache.Default.GetImage("images/actions/deletedatasource_16x16.png"), true), true);
      
      if (this.M_Kieu_Xem != "HEN")
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Xác nhận bắt đầu sửa chữa", 
            new EventHandler(this.V_XN_BD_SCC), Shortcut.F10, ImageResourceCache.Default.GetImage("images/edit/edit_16x16.png"), true), true);

      if (this.M_Kieu_Xem != "HEN")
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Xác nhận kết thúc sửa chữa", 
            new EventHandler(this.V_XN_KT_SCC), Shortcut.F11, ImageResourceCache.Default.GetImage("images/edit/edit_16x16.png"), true), false);

      if (this.M_Kieu_Xem != "HEN")
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Xác nhận bắt đầu và kết thúc theo - KTV", 
            new EventHandler(this.V_XN_BD_KT_KTV), Shortcut.None, ImageResourceCache.Default.GetImage("images/edit/edit_16x16.png"), true), true); // FrmCVDV_XN_TGSC

      if (this.M_Kieu_Xem != "HEN")
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, 0, "Khóa: Khoang/KTV/CVDV/Tổ", 
            new EventHandler(this.V_Lock_Khoang_Data), Shortcut.None, ImageResourceCache.Default.GetImage("images/actions/managedatasource_16x16.png"), true), false); // FrmCVDV_Lock_Detail

      if (this.M_Kieu_Xem != "HEN")
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Chuyển giao xe", 
            new EventHandler(this.V_Giai_Phong), Shortcut.None, ImageResourceCache.Default.GetImage("images/edit/edit_16x16.png"), true), true);

      if (this.M_Kieu_Xem != "HEN")
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "In phiếu giao việc", 
            new EventHandler(this.V_Giao_Viec_Print), Shortcut.None, ImageResourceCache.Default.GetImage("images/actions/printernetwork_16x16.png"), true), false);

      if (this.M_Kieu_Xem != "HEN")
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, 0, "Xem lệnh", 
            new EventHandler(this.V_Preview), Shortcut.F7, ImageResourceCache.Default.GetImage("images/actions/refresh2_16x16.png"), true), true);

      this.PopupMenuSchedulerControl.ItemLinks.Add(
        new CyberMenuPopup(sender, 0, "Làm tươi dữ liệu",
          new EventHandler(this.V_RefreshData_KH_SCC), Shortcut.F5, ImageResourceCache.Default.GetImage("images/actions/refresh2_16x16.png"), true), false);

      this.PopupMenuSchedulerControl.ItemLinks.Add(
        new CyberMenuPopup(sender, 0, "Quay về giao diện ban đầu", 
          new EventHandler(this.V_Refresh_Load_Default), Shortcut.ShiftF5, ImageResourceCache.Default.GetImage("images/actions/refresh2_16x16.png"), true), true);

      this.PopupMenuSchedulerControl.ItemLinks.Add(
        new CyberMenuPopup(sender, 0, "Tra cứu lệnh sửa chữa", 
          new EventHandler(this.V_Xem_Lich_Su_SC), Shortcut.None, ImageResourceCache.Default.GetImage("images/actions/refresh2_16x16.png"), true), false); // FrmCVDV_Lich_Su_SC_Loc

      if (this.M_Kieu_Xem != "HEN")
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Cập nhật màu xe/Kiểu xe", 
            new EventHandler(this.V_Cap_Nhap_Mau_Kx_Scheduler), Shortcut.None, null, true), true); // Frm_Mau_KX

      if (this.M_Kieu_Xem != "HEN" & this.M_Loai_KH_SCC == "2")
        this.PopupMenuSchedulerControl.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Cập nhật phát sinh/Ghi chú", 
            new EventHandler(this.V_Update_Ghi_Chu_Scheduler), Shortcut.None,  null, true), true); // FrmCVDV_SCC_Note

      this.PopupMenuSchedulerControl.ItemLinks.Add(
        new CyberMenuPopup(sender, 0, "Quay ra", 
          new EventHandler(this.V_Quay_Ra), Shortcut.None, ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), true), true);
      
      if (e == null)
        return;
      
      this.PopupMenuSchedulerControl.ShowPopup(Control.MousePosition);
    }
    private void V_Lap_F3F4_KH_SCC(object sender, AppointmentFormEventArgs e) => e.Handled = true;
    private void V_Sua_Tien_Do_KH_SCC(object sender, EventArgs e)
    {
      string _Stt_Rec_Ro = "";
      string str = "";
      if (this.SchedulerControl_KH_SCC.SelectedAppointments.Count > 0)
        str = this.SchedulerControl_KH_SCC.SelectedAppointments[0].Id.ToString();
      if (str.Trim() == "" || !this.V_ChkStt_Rec(str))
        return;

      this.V_Set_Auto_Refresh(false);

      if (this.V_GetMa_Ct(str) == "PKH" & this.M_Kieu_Xem == "HEN")
        return;

      DateTime start = this.SchedulerControl_KH_SCC.SelectedInterval.Start;
      DateTime end = this.SchedulerControl_KH_SCC.SelectedInterval.End;
      string _So_Ro = "";
      string maCt = this.V_GetMa_Ct(str);
      string _ma_khoang = "";
      string _Ma_CVDV = "";
      string _Ma_To = "";
      string _Ma_Xe = "";
      string _Ma_CD = "";
      string _Ma_KTV = "";
      this.V_GetFromSetScheduler(ref start, ref end, ref _Stt_Rec_Ro, ref _So_Ro, ref _ma_khoang, ref _Ma_CVDV, ref _Ma_To, ref _Ma_Xe, ref _Ma_CD, ref _Ma_KTV);
      this.V_Tao_Sua_Tien_Do_KH_SCC("S", maCt, str, _Stt_Rec_Ro, _So_Ro, start, end, _ma_khoang, _Ma_CVDV, _Ma_To, _Ma_Xe, _Ma_CD, _Ma_KTV);
      this.V_Set_Auto_Refresh(true);
    }
    private string V_GetMa_Ct(string _Stt_Rec)
    {
      // TODO
      return "";
    }
    private void V_Ngay_Ct_KH_SCC(object sender, EventArgs e)
    {
      DataSet dataSet = new DataSet(); // TODO: CP_RO_CVDV_KH_SCC_Ngay_Ngam_Dinh
      this.Dt_Set_SCC.Clear();
      this.Dt_Set_SCC.ImportRow(dataSet.Tables[0].Rows[0]);
      dataSet.Dispose();

      this.M_StartHour = Convert.ToInt32(this.Dt_Set_SCC.Rows[0]["StartHour"]);
      this.M_FinishHour = Convert.ToInt32(this.Dt_Set_SCC.Rows[0]["FinishHour"]);
      this.M_StartMINUTE = Convert.ToInt32(this.Dt_Set_SCC.Rows[0]["StartMINUTE"]);
      this.M_FinishMINUTE = Convert.ToInt32(this.Dt_Set_SCC.Rows[0]["FinishMINUTE"]);
      this.M_Ngay_LimitInterval_Min = Convert.ToDateTime(this.Dt_Set_SCC.Rows[0]["Ngay_LimitInterval_Min"]);
      this.M_Ngay_LimitInterval_Max = Convert.ToDateTime(this.Dt_Set_SCC.Rows[0]["Ngay_LimitInterval_Max"]);
      this.M_Thu_Bay = this.Dt_Set_SCC.Rows[0]["Thu_Bay"].ToString().Trim();
      this.M_Chu_Nhat = this.Dt_Set_SCC.Rows[0]["Chu_Nhat"].ToString().Trim();
      this.SchedulerControl_KH_SCC.LimitInterval.Start = this.M_Ngay_LimitInterval_Min;
      this.SchedulerControl_KH_SCC.LimitInterval.End = this.M_Ngay_LimitInterval_Max;
      this.SchedulerControl_KH_SCC.Start = Convert.ToDateTime(this.Dt_Set_SCC.Rows[0]["Ngay_Ct"]);
      this.V_Load_DATA_KH_SCC("0", "", "");
      this.V_LoadDataMoLenhTrongNgay("");
      this.V_Lock_Xem();
      this.V_Filter_KH_SCC(sender, e);
    }
    private void V_ChangeValue(object sender, EventArgs e)
    {
      bool enableTimerKhScc = this.V_GetEnableTimer_KH_SCC();

      if (!SplashScreenManager.Default.IsSplashFormVisible)
        SplashScreenManager.ShowForm(this, typeof(frmLoading), true, true, false);

      string str = CyberFunc.V_GetvalueCombox(this.CbbLoai_Xem_KH_SCC);
      if (this.M_Loai_KH_SCC == "2")
        this.V_Load_DATA_KH_SCC("0", "", "");

      this.V_SetSchedulerSetValue();

      if (SplashScreenManager.Default.IsSplashFormVisible)
        SplashScreenManager.CloseForm(false);

      this.M_Loai_XemOld = str;

      if (!enableTimerKhScc)
        return;

      this.V_SetEnableTimer_KH_SCC();
    }
    private bool V_GetEnableTimer_KH_SCC()
    {
      bool enableTimerKhScc = false;
      if (this.Timer_Data_KH_SCC.Enabled)
        enableTimerKhScc = true;
      if (enableTimerKhScc)
        this.Timer_Data_KH_SCC.Enabled = false;

      return enableTimerKhScc;
    }
    private void V_SetEnableTimer_KH_SCC() => this.Timer_Data_KH_SCC.Enabled = true;
    private void V_Timer_Data_KH_SCC(object sender, EventArgs e)
    {
      if (!this.Timer_Data_KH_SCC.Enabled)
        return;

      this.V_Load_DATA_KH_SCC("0", "", "");
      this.V_LoadData_Cho_Lap_KH("0", "");
    }
    private void V_ChkSBD_KH_SCC(object sender, EventArgs e) => this.V_Filter_KH_SCC(sender, e);
    private void V_ChkIs_EM_KH_SCC(object sender, EventArgs e) => this.V_Filter_KH_SCC(sender, e);
    private void V_ChkIs_GJ_KH_SCC(object sender, EventArgs e)
    {
      if (this.ChkIs_GJ_KH_SCC.Checked)
        this.ChkIs_EM_KH_SCC.Checked = false;

      this.V_Filter_KH_SCC(sender, e);
    }
    private void V_So_RO_KH_SCC(object sender, EventArgs e) => this.V_Filter_KH_SCC(sender, e);
    private void SchedulerControl_KH_SCC_AppointmentDrop(object sender, AppointmentDragEventArgs e)
    {
      Appointment editedAppointment = e.EditedAppointment;
      if (CyberFunc.V_GetvalueCombox(this.CbbLoai_Xem_KH_SCC).Trim() != "05" & this.M_Loai_KH_SCC.Trim() == "2")
        e.Allow = false;
      else
      {
        bool flag = this.V_Update_Keo_Tha_KH_SCC(editedAppointment);
        e.Allow = flag;
      }
    }
    private bool V_Update_Keo_Tha_KH_SCC(Appointment _Appointment)
    {
      string str = "";
      if (this.SchedulerControl_KH_SCC.SelectedAppointments.Count > 0)
      {
        try
        {
          str = this.SchedulerControl_KH_SCC.SelectedAppointments[0].Id.ToString();
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
        }
      }
      if (str.ToString().Trim() == "" || !this.V_ChkStt_Rec(str) || (-(this.V_GetMa_Ct(str) == "PKH" & this.M_Kieu_Xem == "HEN" ? 1 : 0) & str.IndexOf("FN")) != 0 || !this.V_Chk_Righ(str, "KEO_THA"))
        return false;

      string _Stt_Rec_Ro = "";
      DateTime start = this.SchedulerControl_KH_SCC.SelectedInterval.Start;
      DateTime end = this.SchedulerControl_KH_SCC.SelectedInterval.End;
      string _So_Ro = "";
      string _ma_khoang = "";
      string _Ma_CVDV = "";
      string _Ma_To = "";
      string _Ma_Xe = "";
      string _Ma_CD = "";
      string _Ma_KTV = "";
      string _ma_khoangOld = "";
      string _Ma_CVDVOld = "";
      string _Ma_ToOld = "";
      string _Ma_XeOld = "";
      string _Ma_CDOld = "";
      string _Ma_KTVOld = "";

      this.V_GetFromSetScheduler(ref start, ref end, ref _Stt_Rec_Ro, ref _So_Ro, ref _ma_khoang, ref _Ma_CVDV, ref _Ma_To, ref _Ma_Xe, ref _Ma_CD, ref _Ma_KTV, _Appointment);
      this.V_GetFromSetSchedulerOld(ref _ma_khoangOld, ref _Ma_CVDVOld, ref _Ma_ToOld, ref _Ma_XeOld, ref _Ma_CDOld, ref _Ma_KTVOld, _Appointment);
      
      DataSet dataSet = new DataSet(); //TODO: CP_RO_CVDV_KH_SCC_Save_Keo_Tha
      bool flag = (dataSet.Tables[0].Rows.Count == 0);
      dataSet.Dispose();

      if (flag)
        this.V_PercentComplete_KH_SCC(str);
      if (flag)
        this.V_Load_DATA_KH_SCC("0", "", str);

      return flag;
    }
    private void V_GetFromSetSchedulerOld(ref string _ma_khoangOld, ref string _Ma_CVDVOld, ref string _Ma_ToOld, ref string _Ma_XeOld, ref string _Ma_CDOld, ref string _Ma_KTVOld, Appointment _Appointment = null)
    {
      Appointment selectedAppointment = this.SchedulerControl_KH_SCC.SelectedAppointments[0];
      DataRowView dataRowView = null;
      try
      {
        dataRowView = !(selectedAppointment.Type == AppointmentType.Normal | selectedAppointment.Type == AppointmentType.Pattern) ? (DataRowView)this.SchedulerControl_KH_SCC.SelectedAppointments[0].RecurrencePattern.GetSourceObject((ISchedulerStorageBase)this.SchedulerControl_KH_SCC.Storage) : (DataRowView)this.SchedulerControl_KH_SCC.SelectedAppointments[0].GetSourceObject((ISchedulerStorageBase)this.SchedulerControl_KH_SCC.Storage);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      if (dataRowView == null)
        return;

      if (this.Dt_Data_KH_SCC.Columns.Contains("ma_khoang"))
        _ma_khoangOld = dataRowView["Ma_khoang"].ToString().Trim();
      if (this.Dt_Data_KH_SCC.Columns.Contains("Ma_Hs"))
        _Ma_CVDVOld = dataRowView["Ma_Hs"].ToString().Trim();
      if (this.Dt_Data_KH_SCC.Columns.Contains("Ma_To"))
        _Ma_ToOld = dataRowView["Ma_To"].ToString().Trim();
      if (this.Dt_Data_KH_SCC.Columns.Contains("Ma_Xe"))
        _Ma_XeOld = dataRowView["Ma_Xe"].ToString().Trim();
      if (this.Dt_Data_KH_SCC.Columns.Contains("Ma_CD"))
        _Ma_CDOld = dataRowView["Ma_CD"].ToString().Trim();
      if (!this.Dt_Data_KH_SCC.Columns.Contains("Ma_KTV"))
        return;
      _Ma_KTVOld = dataRowView["Ma_KTV"].ToString().Trim();
    }
    private void V_PercentComplete_KH_SCC(string _Stt_rec = "", string _So_Ro = "")
    {
    }
    private void SchedulerControl_KH_SCC_AppointmentResized(object sender, AppointmentResizeEventArgs e)
    {
      bool flag = this.V_Update_Keo_Tha_KH_SCC(e.EditedAppointment);
      e.Allow = flag;
      e.Handled = !flag;
    }
    private void SchedulerControl_CustomDrawTimeIndicator(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
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
    private void V_CustomDrawTimeCell(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
    {
      TimeCell objectInfo1 = (TimeCell)e.ObjectInfo;
      DateTime start;
      if (objectInfo1.Resource.RowHandle == (object)0)
        objectInfo1.Appearance.BackColor = System.Drawing.Color.White;
      else
      {
        DataRowView row = (DataRowView)objectInfo1.Resource.GetRow((ISchedulerStorageBase)this.SchedulerControl_KH_SCC.Storage);
        if (row.Row.Table.Columns.Contains("backColor"))
        {
          start = objectInfo1.Interval.Start;
          if (start.Hour != this.M_FinishHour)
            objectInfo1.Appearance.BackColor = this.CyberColor.GetBackColor(Convert.ToString(row.Row["backColor"]));
        }
      }
      if ((this.SchedulerControl_KH_SCC.ActiveViewType == SchedulerViewType.Timeline || this.SchedulerControl_KH_SCC.ActiveViewType == SchedulerViewType.Gantt) && e.ObjectInfo is TimeCell)
      {
        TimeCell objectInfo2 = e.ObjectInfo as TimeCell;
        if (objectInfo2.Resource.RowHandle == (object)0)
          return;

        start = objectInfo2.Interval.Start;
        if (start.Minute == 0)
          objectInfo2.Appearance.BorderColor = System.Drawing.Color.Blue;
        start = objectInfo2.Interval.Start;
        if (start.Hour == this.M_FinishHour)
          objectInfo2.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
        start = objectInfo2.Interval.Start;
        if (start.Hour == 12)
          objectInfo2.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
      }
      e.DrawDefault();
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

        DataRow[] dataRowArray = this.Dt_Data_KH_SCC.Select("Stt_Rec = '" + str.ToString().Trim() + "'");
        if (!(this._BorderColor_Data_KH_SCC & dataRowArray.Length > 0) || dataRowArray[0][this._BorderColorField_Data_KH_SCC].ToString().Trim() == "")
          return;

        Decimal d1 = 2M;
        if (this.Dt_Data_KH_SCC.Columns.Contains("SizeBorder"))
          d1 = Convert.ToDecimal(dataRowArray[0]["SizeBorder"]);
        if (Decimal.Compare(d1, 2M) < 0)
          d1 = 2M;
        e.Handled = true;
        Rectangle bounds = e.Bounds;
        e.DrawDefault();
        e.Graphics.DrawRectangle(new Pen(this.CyberColor.GetBackColor(Convert.ToString(dataRowArray[0][this._BorderColorField_Data_KH_SCC])), Convert.ToSingle(d1)), bounds);
        e.Handled = true;
      }
      catch (Exception ex)
      {
        e.Handled = true;
        MessageBox.Show(ex.Message);
      }
    }
    private void V_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e)
    {
      if (this.Dt_Data_KH_SCC == null)
        return;

      int emSize = 0;
      string str1 = "";
      DataRow[] dataRowArray = null;
      try
      {
        str1 = e.ViewInfo.Appointment.Id.ToString().Trim();
        dataRowArray = this.Dt_Data_KH_SCC.Select("Stt_Rec = '" + str1.ToString().Trim() + "'");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      if (str1.Trim() == "" || dataRowArray == null || dataRowArray.Length == 0)
        return;

      bool flag = false;
      if (this.Dt_Data_KH_SCC.Columns.Contains("Italic"))
        flag = true;
      if (flag)
        flag = dataRowArray[0]["Italic"].ToString().Trim() == "1";
      if (!this._BackColor_Data_KH_SCC & !this._BackColor2_Data_KH_SCC & !this._ForeColor_Data_KH_SCC & !this._BorderColor_Data_KH_SCC & !this._Bold_Data_KH_SCC & !this._Underline_KH_SCC & !flag)
        return;

      try
      {
        if (dataRowArray.Length < 1)
          return;

        if (this._BackColor_Data_KH_SCC)
          e.ViewInfo.Appearance.BackColor = this.CyberColor.GetBackColor(Convert.ToString(dataRowArray[0][this._BackColorField_Data_KH_SCC]));
        if (this._BackColor2_Data_KH_SCC && dataRowArray[0][this._BackColorField2_Data_KH_SCC].ToString().Trim() == "")
          e.ViewInfo.Appearance.BackColor2 = this.CyberColor.GetBackColor(Convert.ToString(dataRowArray[0][this._BackColorField2_Data_KH_SCC]));
        if (this._ForeColor_Data_KH_SCC)
          e.ViewInfo.Appearance.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(dataRowArray[0][this._ForeColorField_Data_KH_SCC]));
        if (this._BorderColor_Data_KH_SCC)
          e.ViewInfo.Appearance.BorderColor = this.CyberColor.GetBackColor(Convert.ToString(dataRowArray[0][this._BorderColorField_Data_KH_SCC]));

        string str2 = "0";
        string str3 = "0";
        if (this._Bold_Data_KH_SCC && dataRowArray[0][this._BoldField_Data_KH_SCC].ToString().Trim() == "1")
          str2 = "1";
        if (this._Underline_KH_SCC && dataRowArray[0][this._UnderlineField_KH_SCC].ToString().Trim() == "1")
          str3 = "1";
        if (this.Dt_Data_KH_SCC.Columns.Contains("FontSize"))
          emSize = Convert.ToInt32(dataRowArray[0]["FontSize"]);
        if (emSize <= 0)
          emSize = checked((int)Math.Round((double)this.Font.Size));
        if (!(this._Bold_Data_KH_SCC | this._Underline_KH_SCC | flag))
          return;

        if (str2.Trim() == "1")
        {
          if (str3.Trim() == "1")
          {
            if (flag)
              e.ViewInfo.Appearance.Font = new Font(this.Font.FontFamily, (float)emSize, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            else
              e.ViewInfo.Appearance.Font = new Font(this.Font.FontFamily, (float)emSize, FontStyle.Bold | FontStyle.Underline);
          }
          else if (flag)
            e.ViewInfo.Appearance.Font = new Font(this.Font.FontFamily, (float)emSize, FontStyle.Bold | FontStyle.Italic);
          else
            e.ViewInfo.Appearance.Font = new Font(this.Font.FontFamily, (float)emSize, FontStyle.Bold);
        }
        else if (str3.Trim() == "1")
        {
          if (flag)
            e.ViewInfo.Appearance.Font = new Font(this.Font.FontFamily, (float)emSize, FontStyle.Italic | FontStyle.Underline);
          else
            e.ViewInfo.Appearance.Font = new Font(this.Font.FontFamily, (float)emSize, FontStyle.Underline);
        }
        else if (flag)
          e.ViewInfo.Appearance.Font = new Font(this.Font.FontFamily, (float)emSize, FontStyle.Italic);
        else
          e.ViewInfo.Appearance.Font = new Font(this.Font.FontFamily, (float)emSize, FontStyle.Regular);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
    private void SchedulerControl_InitAppointmentImages(object sender, AppointmentImagesEventArgs e)
    {
      try
      {
        if (!this.Dt_Data_KH_SCC.Columns.Contains("Uu_Tien"))
          return;

        string str1 = e.Appointment.Id.ToString().Trim();
        if (str1.Trim() == "")
          return;

        DataRow[] dataRowArray = this.Dt_Data_KH_SCC.Select("Stt_Rec = '" + str1 + "'");
        if (dataRowArray.Length == 0)
          return;

        string str2 = "0";
        string str3 = "0";
        if (this.Dt_Data_KH_SCC.Columns.Contains("Flag"))
          str2 = dataRowArray[0]["Flag"].ToString().Trim();
        if (this.Dt_Data_KH_SCC.Columns.Contains("Uu_Tien"))
          str3 = dataRowArray[0]["Uu_Tien"].ToString().Trim();
        if (!(str2.Trim() == "1" | str2.Trim() == "2" | str2.Trim() == "3" | str2.Trim() == "4"))
          return;

        AppointmentImageInfo appointmentImageInfo = new AppointmentImageInfo();
        string Left = str2;
        appointmentImageInfo.Image = (Left == "1") ? 
                                     (Left == "2") ? 
                                     (Left == "3") ? 
                                     (Left == "4") ? 
                                     ImageResourceCache.Default.GetImage("images/communication/wifi_16x16.png") :
                                     ImageResourceCache.Default.GetImage("images/communication/radio_16x16.png") :
                                     ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png") :
                                     ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png") :
                                     ImageResourceCache.Default.GetImage("images/communication/wifi_16x16.png");
        e.ImageInfoList.Add(appointmentImageInfo);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
    private void schedulerControl_CustomDrawDayHeader(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
    {
      if (this.M_Kieu_Xem.Trim().ToUpper() == "HEN" | this.M_Loai_KH_SCC.Trim() == "1")
        return;

      DateTime now = DateTime.Now;
      DateTime date = now.Date;
      now = DateTime.Now;
      DateTime t2 = now.Date;
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
        e.Cache.FillRectangle(new LinearGradientBrush(e.Bounds, Color.FromArgb(125, 181, 178), Color.FromArgb(175, 231, 228), LinearGradientMode.Vertical), rectangle);
        StringFormat stringFormat = headerCaption.TextOptions.GetStringFormat(TextOptions.DefaultOptionsCenteredWithEllipsis);
        e.Cache.DrawString(objectInfo.Caption, headerCaption.Font, (Brush)new SolidBrush(Color.Black), rectangle, stringFormat);
      }
      e.Handled = true;
    }
    private void ResourcesTree1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
    {
      if (this.M_Kieu_Xem == "HEN")
        this.ResourcesTree1.Visible = false;
      if (!this.ResourcesTree1.Visible)
        return;

      DataView dataSource = (DataView)this.SchedulerStorage_KH_SCC.Resources.DataSource;
      if (dataSource == null)
        return;

      int nodeIndex = this.ResourcesTree1.GetNodeIndex(e.Node);
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
          e.Appearance.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold | FontStyle.Underline);
        else
          e.Appearance.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
      }
      else if (flag3)
        e.Appearance.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Underline);
      else
        e.Appearance.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Regular);

      if (dataSource.Table.Columns.Contains("BackColor_Cot"))
      {
        Brush brush = (Brush)new SolidBrush(this.CyberColor.GetBackColor(Convert.ToString(dataSource[nodeIndex]["BackColor_Cot"])));
        e.Cache.FillRectangle(brush, e.Bounds);
        flag1 = true;
      }
      else if (dataSource.Table.Columns.Contains("BackColor"))
      {
        e.Appearance.BackColor = this.CyberColor.GetBackColor(Convert.ToString(dataSource[nodeIndex]["BackColor"]));
        flag1 = true;
      }
      if (dataSource.Table.Columns.Contains("ForeColor_Cot"))
      {
        Brush foreBrush = (Brush)new SolidBrush(this.CyberColor.GetForeColor(Convert.ToString(dataSource[nodeIndex]["ForeColor_Cot"])));
        e.Cache.DrawString(e.CellText, e.Appearance.Font, foreBrush, e.Bounds, e.Appearance.GetStringFormat());
        flag1 = true;
      }
      else if (dataSource.Table.Columns.Contains("ForeColor"))
        e.Appearance.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(dataSource[nodeIndex]["ForeColor"]));

      string str3 = "";
      string str4 = "";
      string str5 = "";
      string str6 = "";
      if (dataSource.Table.Columns.Contains("BackColor_Cols_H_ChangeColor"))
        str3 = dataSource[nodeIndex]["BackColor_Cols_H_ChangeColor"].ToString().Trim();
      if (dataSource.Table.Columns.Contains("BackColor2_Cols_H_ChangeColor"))
        str4 = dataSource[nodeIndex]["BackColor2_Cols_H_ChangeColor"].ToString().Trim();
      if (dataSource.Table.Columns.Contains("FieldName_Cols_H_ChangeColor"))
        str5 = dataSource[nodeIndex]["FieldName_Cols_H_ChangeColor"].ToString().Trim();
      if (dataSource.Table.Columns.Contains("ForeColor_Cols_H_ChangeColor"))
        str6 = dataSource[nodeIndex]["ForeColor_Cols_H_ChangeColor"].ToString().Trim();

      string[] strArray1 = str6.Split(';');
      string[] strArray2 = str3.Split(';');
      string[] strArray3 = str4.Split(';');
      string str7 = "";
      string str8 = "";
      string str9 = "";
      int integer = Convert.ToInt32(this.FindItemInArr(e.Column.FieldName.ToUpper(), str5.ToUpper(), ";"));
      if (integer < 0)
        return;
      try
      {
        if (strArray1.Length >= integer & strArray1.Length > 0 & strArray1.Length > integer)
          str9 = strArray1[integer];
        if (strArray2.Length >= integer & strArray2.Length > 0 & strArray1.Length > integer)
          str7 = strArray2[integer];
        if (strArray3.Length >= integer & strArray3.Length > 0 & strArray1.Length > integer)
          str8 = strArray3[integer];
        if (str9 != "")
          e.Appearance.ForeColor = this.CyberColor.GetBacColorkReports(str9);
        if (str7 != "")
          e.Appearance.BackColor2 = this.CyberColor.GetBacColorkReports(str7);
        if (str8 != "")
          return;

        e.Appearance.BackColor = this.CyberColor.GetBacColorkReports(str8);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
    private void TabCVDV_SelectedIndexChanged(object sender, EventArgs e)
    {
      string upper = this.TabCVDV.TabPages[this.TabCVDV.SelectedIndex].Name.ToString().Trim().ToUpper();
      if (upper == "TAB8")
        this.V_Refresh_HonHop((object)null, (EventArgs)null);
      else if (upper == "TAB9")
        this.V_Refresh_Dung((object)null, (EventArgs)null);
    }
    private void V_Refresh_HonHop(object sender, EventArgs e) => this.V_LoadData_HonHop("0");
    private void V_Refresh_Dung(object sender, EventArgs e) => this.V_LoadData_Dung("0");
    private void V_Du_Kien_Giao(object sender, EventArgs e) => this.V_Filter_KH_SCC(sender, e);
    private void V_Du_All_Xe_Cd(object sender, EventArgs e)
    {
      if (this.ChkShow_All_Cd_Xe.Checked)
      {
        if (this.CbbCD_KH_SCC.Items.Count > 0)
          this.CbbCD_KH_SCC.SelectedValue = (object)"";

        this.CbbCD_KH_SCC.Enabled = false;
      }
      else
        this.CbbCD_KH_SCC.Enabled = true;

      this.V_Filter_KH_SCC(sender, e);
    }
    private void V_Remove_Filter(object sender, EventArgs e)
    {
      this.TxtSo_Ro_Cho_Lap_KH.Text = "";
      this.TxtSo_RO_KH_SCC.Text = "";
      this.TxtMa_Xe_Cho_Lap_KH.Text = "";
      this.TxtMa_Xe_KH_SCC.Text = "";
      this.ChkShow_All_Cd_Xe.Checked = false;
      this.ChkDu_kien_giaoCVDV.Checked = false;
      this.Fill_Cbb(0);
      this.V_Filter_KH_SCC(sender, e);
    }
    #endregion

    #region "V_Load_DATA_KH_SCC"
    private void V_Delete_KH_SCC_DATA(DataTable _Dt, string _Stt_Rec_Ro_Load, string _Stt_Rec_Load)
    {
      if (_Dt == null)
        return;

      int num = checked(_Dt.Rows.Count - 1);
      if (_Stt_Rec_Ro_Load.Trim() == "" & _Stt_Rec_Load.Trim() == "")
      {
        _Dt.Clear();
        _Dt.AcceptChanges();
      }
      else
      {
        bool flag1 = false;
        bool flag2 = false;
        if (_Dt.Columns.Contains("Stt_Rec_Ro"))
          flag1 = true;
        if (_Dt.Columns.Contains("Stt_Rec"))
          flag2 = true;
        if (flag1 && _Stt_Rec_Ro_Load.Trim() == "")
          flag1 = false;
        if (flag2 && _Stt_Rec_Load.Trim() == "")
          flag2 = false;
        if (!flag1 & !flag2)
          return;

        int index = checked(_Dt.Rows.Count - 1);
        while (index >= 0)
        {
          if (flag1 & flag2 && _Dt.Rows[index]["Stt_Rec_RO"].ToString().Trim().Contains(_Stt_Rec_Ro_Load.Trim()) & _Dt.Rows[index]["Stt_Rec"].ToString().Trim().Contains(_Stt_Rec_Load.Trim()))
            _Dt.Rows[index].Delete();
          if (flag1 & !flag2 && _Dt.Rows[index]["Stt_Rec_RO"].ToString().Trim().Contains(_Stt_Rec_Ro_Load.Trim()))
            _Dt.Rows[index].Delete();
          if (!flag1 & flag2 && _Dt.Rows[index]["Stt_Rec"].ToString().Trim().Contains(_Stt_Rec_Load.Trim()))
            _Dt.Rows[index].Delete();
          checked { index += -1; }
        }
        _Dt.AcceptChanges();
      }
    }
    private void V_UpdateAndInsertDataxe(ref DataTable _Dt)
    {
      if (_Dt == null || Dt_Data_Xe_KH_SCC == null || !_Dt.Columns.Contains("Stt_Rec_Ro") || !Dt_Data_Xe_KH_SCC.Columns.Contains("Stt_Rec_Ro") || !Dt_Data_Xe_KH_SCC.Columns.Contains("Forecolor") || !_Dt.Columns.Contains("Forecolor"))
        return;

      SchedulerControl_KH_SCC.BeginUpdate();
      int num1 = checked(_Dt.Rows.Count - 1);
      int index1 = 0;
      while (index1 <= num1)
      {
        int num2 = checked(Dt_Data_Xe_KH_SCC.Rows.Count - 1);
        int num3 = 0;
        while (num3 <= num2)
        {
          if (_Dt.Rows[index1]["Stt_Rec_Ro"].ToString().Trim() == Dt_Data_Xe_KH_SCC.Rows[num3]["Stt_Rec_Ro"].ToString().Trim())
          {
            CyberFunc.V_UpdateRowtoRow(_Dt.Rows[index1], Dt_Data_Xe_KH_SCC, num3);
            break;
          }
          checked { ++num3; }
        }
        checked { ++index1; }
      }
      try
      {
        int num4 = checked(_Dt.Rows.Count - 1);
        int index2 = 0;
        while (index2 <= num4)
        {
          if (Dt_Data_Xe_KH_SCC.Select("Stt_Rec_RO = " + _Dt.Rows[index2]["Stt_rec_Ro"]).Length <= 0)
            Dt_Data_Xe_KH_SCC.ImportRow(_Dt.Rows[index2]);
          checked { ++index2; }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      SchedulerControl_KH_SCC.EndUpdate();
    }
    private void V_Update_Ten3()
    {
    }
    private void V_Dang_Sua_Chua(object _StrKhoang)
    {
      if (M_Kieu_Xem == "HEN" || M_Loai_KH_SCC != "1")
        return;

      DateTime date = Convert.ToDateTime(TxtM_Ngay_Ct_KH_SCC.EditValue);
      DataSet dataSet = new DataSet(); // CP_RO_CVDV_DangSC
      if (dataSet.Tables.Count == 0)
        dataSet.Dispose();
      else
        V_UpdateTbToTb(dataSet.Tables[0], DmKhoang_KH_SCC, "Ma_khoang", "Ma_khoang", true);
    }
    public void V_UpdateTbToTb(DataTable _Dt_Nguon, DataTable _Dt_Dich, string _Field_Key_Nguon, string _Field_Key_Dich, bool _OnRow = false)
    {
      if (_Dt_Dich == null | _Dt_Nguon == null | _Field_Key_Dich.Trim() == "" | _Field_Key_Nguon.Trim() == "" || !_Dt_Dich.Columns.Contains(_Field_Key_Dich) || !_Dt_Nguon.Columns.Contains(_Field_Key_Nguon) || _Dt_Dich.Rows.Count == 0 || _Dt_Nguon.Rows.Count == 0)
        return;

      _Field_Key_Dich = _Dt_Dich.Columns[_Field_Key_Dich].ColumnName;
      _Field_Key_Nguon = _Dt_Nguon.Columns[_Field_Key_Nguon].ColumnName;
      if (_OnRow)
      {
        int num1 = checked(_Dt_Dich.Rows.Count - 1);
        int index1 = 0;
        while (index1 <= num1)
        {
          _Dt_Dich.Rows[index1].BeginEdit();
          int num2 = checked(_Dt_Nguon.Columns.Count - 1);
          int index2 = 0;
          while (index2 <= num2)
          {
            string columnName = _Dt_Nguon.Columns[index2].ColumnName;
            if (columnName.Trim().ToUpper() != _Field_Key_Nguon.Trim().ToUpper() && columnName.Trim().ToUpper() != _Field_Key_Dich.Trim().ToUpper() && _Dt_Dich.Columns.Contains(columnName))
            {
              string upper = _Dt_Dich.Columns[columnName].DataType.Name.ToString().Trim().ToUpper();
              _Dt_Dich.Rows[index1][columnName] = 
                (upper != "GUID".Trim().ToUpper()) ? (upper != "STRING".Trim().ToUpper() ? (upper == "DECIMAL".Trim().ToUpper() || upper == "DOUBLE".Trim().ToUpper() ? (object)0 : 
                                                      (upper == "INT16".Trim().ToUpper() || upper == "INT32".Trim().ToUpper() || upper == "INT64".Trim().ToUpper() ? (object)0 : 
                                                      (upper != "BOOLEAN".Trim().ToUpper() ? (upper != "DATETIME".Trim().ToUpper() ? (object)"" : 
                                                      (object)new DateTime(1900, 1, 1)) 
                                                       : (object)false))) 
                                                       : (object)""
                                                     ) : (object)"F52125B8-2692-E311-81AE-001D9E479E38";
            }
            checked { ++index2; }
          }
          _Dt_Dich.Rows[index1].EndEdit();
          checked { ++index1; }
        }
      }
      _Dt_Dich.AcceptChanges();

      int num3 = checked(_Dt_Nguon.Rows.Count - 1);
      int index3 = 0;
      while (index3 <= num3)
      {
        string upper = _Dt_Nguon.Rows[index3][_Field_Key_Nguon].ToString().Trim().ToUpper();
        int num4 = checked(_Dt_Dich.Rows.Count - 1);
        int index4 = 0;
        while (index4 <= num4)
        {
          if (_Dt_Dich.Rows[index4][_Field_Key_Dich].ToString().Trim().ToUpper() == upper)
          {
            _Dt_Dich.Rows[index4].BeginEdit();
            int num5 = checked(_Dt_Nguon.Columns.Count - 1);
            int index5 = 0;
            while (index5 <= num5)
            {
              string columnName = _Dt_Nguon.Columns[index5].ColumnName;
              if (columnName.Trim().ToUpper() != _Field_Key_Nguon.Trim().ToUpper() && columnName.Trim().ToUpper() != _Field_Key_Dich.Trim().ToUpper() && _Dt_Dich.Columns.Contains(columnName))
                _Dt_Dich.Rows[index4][columnName] = _Dt_Nguon.Rows[index3][columnName];
              checked { ++index5; }
            }
            _Dt_Dich.Rows[index4].EndEdit();
          }
          checked { ++index4; }
        }
        checked { ++index3; }
      }
      _Dt_Dich.AcceptChanges();
    }
    private void V_Filter_KH_SCC(object sender, EventArgs e)
    {
      SchedulerControl_KH_SCC.BeginUpdate();
      string str1 = V_GetFilter_KH_SCC(Dt_Data_KH_SCC) + " AND " + V_GetFilter_KH_SCC_To(Dt_Data_KH_SCC, "XE");
      string str2 = V_GetFilter_KH_SCC(Dt_Data_Xe_KH_SCC) + " AND " + V_GetFilter_KH_SCC_To(Dt_Data_Xe_KH_SCC, "XE");
      string _StrFilter1 = V_GetFilterOneField(Convert.ToString(CbbKhoang_KH_SCC.SelectedValue), DmKhoang_KH_SCC, "Ma_khoang", false, false, false);
      string _StrFilter2 = V_GetFilter_KH_SCC(DmKTV_KH_SCC) + " AND " + V_GetFilter_KH_SCC_To(DmKTV_KH_SCC, "KTV");
      
      if (ChkDu_kien_giaoCVDV.Checked)
      {
        str1 = str1 + V_GetFilter_Ngay_giao(Convert.ToDateTime(TxtM_Ngay_Ct_KH_SCC.EditValue), Dt_Data_KH_SCC);
        str2 = str2 + V_GetFilter_Ngay_giao(Convert.ToDateTime(TxtM_Ngay_Ct_KH_SCC.EditValue), Dt_Data_Xe_KH_SCC);
      }

      Set_Filter(Dv_Data_KH_SCC, str1);
      Set_Filter(Dv_Data_Xe_KH_SCC, str2);

      if (ChkShow_All_Cd_Xe.Checked)
      {
        string filterKhSccCdXe1 = V_GetFilter_KH_SCC_Cd_XE(Dt_Data_KH_SCC, Dv_Data_KH_SCC);
        string filterKhSccCdXe2 = V_GetFilter_KH_SCC_Cd_XE(Dt_Data_Xe_KH_SCC, Dv_Data_Xe_KH_SCC);
        Set_Filter(Dv_Data_KH_SCC, filterKhSccCdXe1);
        Set_Filter(Dv_Data_Xe_KH_SCC, filterKhSccCdXe2);
      }

      V_Loc_Xe_Cho_Lap_KH(sender, e);
      Set_Filter(Dv_DmKhoang_KH_SCC, _StrFilter1);
      Set_Filter(Dv_DmKTV_KH_SCC, _StrFilter2);
      SchedulerControl_KH_SCC.EndUpdate();
      T_tinh_So_Xe();
    }
    private void V_start_Flass(string _Status)
    {
      Flass = 5;
      Interval = 1000;
      Stt_Flass = 0;
      BackColor_Flass = "";
      ForeColor_Flass = "";
      Show_iconNew = 0;

      DataSet dataSet = new DataSet(); // CP_RO_CVDV_FlassTab
      if (dataSet.Tables.Count == 0)
        dataSet.Dispose();
      else
      {
        int index1 = 0;
        if (dataSet.Tables.Count < index1)
        {
          if (dataSet.Tables[index1].Rows.Count > index1)
          {
            if (dataSet.Tables[index1].Columns.Contains("Interval_Timer"))
              Interval = Convert.ToInt32(dataSet.Tables[index1].Rows[0]["Interval_Timer"]);
            if (dataSet.Tables[index1].Columns.Contains("So_luotFlass"))
              Flass = Convert.ToInt32(dataSet.Tables[index1].Rows[0]["So_luotFlass"]);
            if (dataSet.Tables[index1].Columns.Contains("BackColor_FlassDefault"))
              BackColor_Flass = Convert.ToString(dataSet.Tables[index1].Rows[0]["BackColor_FlassDefault"]);
            if (dataSet.Tables[index1].Columns.Contains("ForeColor_FlassDefault"))
              ForeColor_Flass = Convert.ToString(dataSet.Tables[index1].Rows[0]["ForeColor_FlassDefault"]);
          }
        }
        int index2 = checked(index1 + 1);
        if (dataSet.Tables.Count > index2)
        {
          if (_Status == "1")
            dt_TabChange = dataSet.Tables[index2].Copy();
          else
          {
            dt_TabChange.Clear();
            int num = checked(dataSet.Tables[index2].Rows.Count - 1);
            int index3 = 0;
            while (index3 <= num)
            {
              dt_TabChange.ImportRow(dataSet.Tables[index2].Rows[index3]);
              checked { ++index3; }
            }
            dt_TabChange.AcceptChanges();
          }
        }

        dataSet.Dispose();
        Timer_FlassTab.Interval = Interval;
        Timer_FlassTab.Enabled = true;
        Timer_FlassTab.Start();
      }
    }
    #endregion

    #region "V_Filter_KH_SCC"
    private string V_GetFilter_KH_SCC(DataTable _DT_Filter)
    {
      string filterKhScc = "1=1";
      if (_DT_Filter == null)
        return filterKhScc;
      string Left1 = CyberFunc.V_GetvalueCombox(CbbCVDV_KH_SCC);
      if (_DT_Filter.Columns.Contains("Ma_Hs") & Left1 != "")
        filterKhScc = filterKhScc + " AND Ma_Hs = '" + Left1.Trim() + "'";
      string Left2 = CyberFunc.V_GetvalueCombox(CbbKhoang_KH_SCC);
      if (_DT_Filter.Columns.Contains("Ma_Khoang") & Left2 != "")
        filterKhScc = filterKhScc + " AND Ma_khoang = '" + Left2.Trim() + "'";
      string Left3 = CyberFunc.V_GetvalueCombox(CbbCD_KH_SCC);
      if (_DT_Filter.Columns.Contains("Ma_CD") & Left3 != "")
        filterKhScc = filterKhScc + " AND Ma_CD = '" + Left3.Trim() + "'";
      string Left4 = CyberFunc.V_GetvalueCombox(CbbTang_KH_SCC);
      if (_DT_Filter.Columns.Contains("Tang") & Left4 != "")
        filterKhScc = filterKhScc + " AND Tang = '" + Left4.Trim() + "'";
      string text1 = TxtMa_Xe_KH_SCC.Text;
      if (_DT_Filter.Columns.Contains("Ma_Xe") & text1 != "")
        filterKhScc = filterKhScc + " AND Ma_Xe LIKE '%" + text1.Trim() + "%'";
      string text2 = TxtSo_RO_KH_SCC.Text;
      if (_DT_Filter.Columns.Contains("So_RO") & text2 != "")
        filterKhScc = filterKhScc + " AND So_RO LIKE '%" + text2.Trim() + "%'";
      string str1 = CyberFunc.V_GetvalueCombox(CbbMuc_SBD_KH_SCC);
      if (ChkSBD_KH_SCC.Checked & str1.Trim() != "" && _DT_Filter.Columns.Contains("Muc_SBD"))
        filterKhScc = filterKhScc + " AND Muc_SBD = '" + str1.Trim() + "'";
      string str2 = CyberFunc.V_GetvalueCombox(CbbMuc_SDS_KH_SCC);
      if (ChkSDS_KH_SCC.Checked & str2.Trim() != "" && _DT_Filter.Columns.Contains("Muc_SDS"))
        filterKhScc = filterKhScc + " AND Muc_SDS = '" + str2.Trim() + "'";
      if (ChkUu_Tien.Checked & _DT_Filter.Columns.Contains("Uu_Tien"))
        filterKhScc += " AND Uu_Tien = '1'";
      if (ChkFV_KH_SCC.Checked & _DT_Filter.Columns.Contains("first_visit"))
        filterKhScc += " AND first_visit = '1'";
      if (ChkDung_KH_SCC.Checked & _DT_Filter.Columns.Contains("Dung"))
        filterKhScc += " AND Dung = '1'";
      if (ChkSDS_KH_SCC.Checked & _DT_Filter.Columns.Contains("SDS"))
        filterKhScc += " AND SDS = '1'";
      if (ChkCho_Rua_KH_SCC.Checked & _DT_Filter.Columns.Contains("Cho_Rua"))
        filterKhScc += " AND Cho_Rua = '1'";
      if (ChkDang_Rua_KH_SCC.Checked & _DT_Filter.Columns.Contains("Dang_Rua"))
        filterKhScc += " AND Dang_Rua = '1'";
      if (ChkCho_Giao_KH_SCC.Checked & _DT_Filter.Columns.Contains("Cho_Giao"))
        filterKhScc += " AND Cho_Giao = '1'";
      if (ChkGiao_Ngay_Kh_SCC.Checked & _DT_Filter.Columns.Contains("Giao_Ngay"))
        filterKhScc += " AND Giao_Ngay = '1'";
      if (ChkEM60_KH_SCC.Checked & _DT_Filter.Columns.Contains("EM60"))
        filterKhScc += " AND Em60 = '1'";
      if (ChkPM90_KH_SCC.Checked & _DT_Filter.Columns.Contains("Pm90"))
        filterKhScc += " AND Pm90 = '1'";
      if (ChkSCL_KH_SCC.Checked & _DT_Filter.Columns.Contains("SCL"))
        filterKhScc += " AND SCL = '1'";
      if (ChkIs_EM_KH_SCC.Checked & _DT_Filter.Columns.Contains("Is_Em"))
        filterKhScc += " AND Is_Em = '1'";
      if (ChkIs_GJ_KH_SCC.Checked & _DT_Filter.Columns.Contains("Is_GJ"))
        filterKhScc += " AND Is_GJ = '1'";

      return filterKhScc;
    }
    private string V_GetFilter_KH_SCC_To(DataTable _DT_Filter, string _Loai_Tb)
    {
      string filterKhSccTo = "(1=1)";
      if (_DT_Filter == null || !_DT_Filter.Columns.Contains("ma_To"))
        return filterKhSccTo;

      string str1 = CyberFunc.V_GetvalueCombox(CbbTo_KH_SCC).ToString().Trim();
      if (str1.Trim() == "")
        return filterKhSccTo;

      if (M_Loai_KH_SCC.Trim().Trim() == "1" | M_Kieu_Xem.Trim() == "HEN")
        filterKhSccTo = filterKhSccTo + " AND Ma_To = '" + str1.Trim() + "'";

      else if (_Loai_Tb.ToString().ToUpper() == "XE")
      {
        string str2 = filterKhSccTo + " AND (";
        if (_DT_Filter.Columns.Contains("ma_To"))
          str2 = str2 + "(Ma_To = '" + str1.Trim() + "')";
        if (_DT_Filter.Columns.Contains("ma_To2"))
          str2 = str2 + "OR (Ma_To2 = '" + str1.Trim() + "')";
        if (_DT_Filter.Columns.Contains("ma_To3"))
          str2 = str2 + "OR (ma_To3 = '" + str1.Trim() + "')";
        if (_DT_Filter.Columns.Contains("ma_To4"))
          str2 = str2 + "OR (ma_To4 = '" + str1.Trim() + "')";
        if (_DT_Filter.Columns.Contains("ma_To5"))
          str2 = str2 + "OR (ma_To5 = '" + str1.Trim() + "')";
        if (_DT_Filter.Columns.Contains("ma_To6"))
          str2 = str2 + "OR (ma_To6 = '" + str1.Trim() + "')";
        filterKhSccTo = str2 + ")";
      }
      return filterKhSccTo;
    }
    private string V_GetFilterOneField(string Value_Filter, DataTable _DT_Filter, string Field_Filter, bool Filter_Or, bool Filter_Like, bool Show_AND_OR)
    {
      string filterOneField1 = "";
      Value_Filter = Value_Filter.Trim();
      string str = "";
      if (!_DT_Filter.Columns.Contains(Field_Filter) | Value_Filter.Trim().Length <= 0)
        return filterOneField1;

      if (Show_AND_OR)
        str = Filter_Or ? "OR" : "AND";
      string filterOneField2;
      if (Filter_Like)
        filterOneField2 = filterOneField1 + str + "(" + Field_Filter + " Like '%" + Value_Filter + "%')";
      else
        filterOneField2 = filterOneField1 + str + "(" + Field_Filter + "='" + Value_Filter + "')";

      return filterOneField2;
    }
    private string V_GetFilter_Ngay_giao(DateTime _d, DataTable _DT_Filter)
    {
      string filterNgayGiao = "";
      if (_DT_Filter == null)
        return filterNgayGiao;

      if (!_DT_Filter.Columns.Contains("Ngay_Giao"))
        return filterNgayGiao;

      string str = string.Format(" AND Ngay_Giao >= #{0:MM/dd/yyyy HH:mm:ss}# AND Ngay_Giao <= #{1:MM/dd/yyyy HH:mm:ss}# ", new DateTime(_d.Year, _d.Month, _d.Day, 0, 0, 0), new DateTime(_d.Year, _d.Month, _d.Day, 23, 59, 59));
      if (_DT_Filter.Columns.Contains("Ngay_Giao"))
        filterNgayGiao += str;

      return filterNgayGiao;
    }
    private void Set_Filter(DataView _dv, string _StrFilter)
    {
      if (_dv == null)
        return;

      try
      {
        _dv.RowFilter = _StrFilter;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
    private string V_GetFilter_KH_SCC_Cd_XE(DataTable _DT_Filter, DataView _dv)
    {
      string filterKhSccCdXe = "(1=1) ";
      if (_DT_Filter == null || !_DT_Filter.Columns.Contains("Ma_Xe") || _dv.Count <= 0)
        return filterKhSccCdXe;

      string Left = "";
      int num = checked(_dv.Count - 1);
      int recordIndex = 0;
      while (recordIndex <= num)
      {
        DataRowView dataRowView = _dv[recordIndex];
        Left = !_dv.Table.Columns.Contains("Stt_Rec_RO") ?
          Left + (Left.Trim().Length > 0 ? " OR " : "") + "(Ma_Xe = '" + dataRowView["Ma_Xe"] + "')" :
          Left + (Left.Trim().Length > 0 ? " OR " : "") + "(Ma_Xe = '" + dataRowView["Ma_Xe"] + "' AND Stt_Rec_RO ='" + dataRowView["Stt_Rec_RO"] + "')";
        checked { ++recordIndex; }
      }
      return "(" + Left + ")";
    }
    private void V_Loc_Xe_Cho_Lap_KH(object sender, EventArgs e)
    {
      if (Dt_Cho_Lap_KH == null)
        return;

      string Left = V_GetFilter_KH_SCC(Dt_Cho_Lap_KH);
      if (TxtMa_Xe_Cho_Lap_KH.Text != "" & Dt_Cho_Lap_KH.Columns.Contains("Ma_Xe"))
        Left = Left + " AND Ma_Xe Like '*" + TxtMa_Xe_Cho_Lap_KH.Text.Trim() + "*'";
      if (TxtSo_Ro_Cho_Lap_KH.Text != "" & Dt_Cho_Lap_KH.Columns.Contains("So_Ro"))
        Left = Left + " AND So_Ro Like '*" + TxtSo_Ro_Cho_Lap_KH.Text.Trim() + "*'";
      if (ChkDu_kien_giaoCVDV.Checked)
        Left = Left + V_GetFilter_Ngay_giao(Convert.ToDateTime(TxtM_Ngay_Ct_KH_SCC.EditValue), Dt_Cho_Lap_KH);
      try
      {
        Dv_Cho_Lap_KH.RowFilter = Left;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
    private void T_tinh_So_Xe()
    {
      string str = "0";
      Lab_SCC_01.Text = str;
      Lab_SCC_02.Text = str;
      Lab_SCC_03.Text = str;
      Lab_SCC_04.Text = str;
      Lab_SCC_05.Text = str;
      Lab_SCC_06.Text = str;
      Lab_SCC_07.Text = str;
      Lab_SCC_08.Text = str;
      Lab_SCC_09.Text = str;
      Lab_SCC_10.Text = str;
      Lab_SCC_11.Text = str;
      Lab_SCC_12.Text = str;
      Lab_SCC_13.Text = str;
      Lab_SCC_14.Text = str;
      Lab_SCC_15.Text = str;
      Lab_SCC_16.Text = str;
      Lab_SCC_17.Text = str;
      Lab_SCC_18.Text = str;
      Lab_SCC_19.Text = str;
      Lab_SCC_20.Text = str;
      int num = checked(Dv_Data_KH_SCC.Count - 1);
      int recordIndex = 0;

      while (recordIndex <= num)
      {
        string Left = Dv_Data_KH_SCC[recordIndex]["Id_BackColor"].ToString().Trim();
        if (Left == "0")
          Lab_SCC_01.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_01.Text), 1M).ToString();
        else if (Left == "1")
          Lab_SCC_02.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_02.Text), 1M).ToString();
        else if (Left == "2")
          Lab_SCC_03.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_03.Text), 1M).ToString();
        else if (Left == "3")
          Lab_SCC_04.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_04.Text), 1M).ToString();
        else if (Left == "4")
          Lab_SCC_05.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_05.Text), 1M).ToString();
        else if (Left == "5")
          Lab_SCC_06.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_06.Text), 1M).ToString();
        else if (Left == "6")
          Lab_SCC_07.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_07.Text), 1M).ToString();
        else if (Left == "7")
          Lab_SCC_08.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_08.Text), 1M).ToString();
        else if (Left == "8")
          Lab_SCC_09.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_09.Text), 1M).ToString();
        else if (Left == "9")
          Lab_SCC_10.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_10.Text), 1M).ToString();
        else if (Left == "10")
          Lab_SCC_11.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_11.Text), 1M).ToString();
        else if (Left == "11")
          Lab_SCC_12.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_12.Text), 1M).ToString();
        else if (Left == "12")
          Lab_SCC_13.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_13.Text), 1M).ToString();
        else if (Left == "13")
          Lab_SCC_14.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_14.Text), 1M).ToString();
        else if (Left == "14")
          Lab_SCC_15.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_15.Text), 1M).ToString();
        else if (Left == "15")
          Lab_SCC_16.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_16.Text), 1M).ToString();
        else if (Left == "16")
          Lab_SCC_17.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_17.Text), 1M).ToString();
        else if (Left == "17")
          Lab_SCC_18.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_18.Text), 1M).ToString();
        else if (Left == "18")
          Lab_SCC_19.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_19.Text), 1M).ToString();
        else if (Left == "19")
          Lab_SCC_20.Text = Decimal.Add(Convert.ToDecimal(Lab_SCC_20.Text), 1M).ToString();
        checked { ++recordIndex; }
      }

      if (M_Kieu_Xem.Trim() == "HEN")
        LabTotal.Text = Convert.ToString(Dv_Data_KH_SCC.Count);
      else
        Tinh_toan_so_Xe_Lab();
    }
    private void Tinh_toan_so_Xe_Lab()
    {
      int num1 = -1;
      int num2 = -1;
      int num3 = -1;
      if (Dt_Mo_Lenh_Trong_Ngay != null)
        num1 = Dv_Mo_Lenh_Trong_Ngay.Count;
      if (Dt_Data_KH_SCC != null)
        num2 = V_Dem_Xe(Dv_Data_KH_SCC);
      if (Dt_Lenh_Giao_Trong_Ngay != null)
        num3 = Dv_Lenh_Giao_Trong_Ngay.Count;
      if (M_Loai_KH_SCC == "2")
        num1 = -1;

      LabTotal.Text = "";
      if (num1 != -1)
        LabTotal.Text = num1.ToString();
      if (num2 != -1)
        LabTotal.Text = LabTotal.Text + (LabTotal.Text.Length != 0 ? "/" : "") + num2.ToString();
      if (num3 == -1)
        return;

      LabTotal.Text = LabTotal.Text + (LabTotal.Text.Length != 0 ? "/" : "") + num3.ToString();
    }
    private int V_Dem_Xe(DataView _dv)
    {
      int num1 = 0;
      string arr_txt = "";
      if (_dv.Table.Columns.Contains("Ma_Xe") & _dv.Table.Columns.Contains("Stt_Rec_RO"))
      {
        num1 = 0;
        int num2 = checked(_dv.Count - 1);
        int recordIndex = 0;
        while (recordIndex <= num2)
        {
          DataRowView dataRowView = _dv[recordIndex];
          string Right = Convert.ToString(dataRowView["Stt_Rec_Ro"]).Replace("_THUCHIEN", "").Replace("_FN", "");
          if (FindItemInArr(dataRowView["Ma_Xe"].ToString() + Right, arr_txt, ";") == 0)
            checked { ++num1; }
          arr_txt = arr_txt + ";" + dataRowView["Ma_Xe"].ToString() + Right;
          checked { ++recordIndex; }
        }
      }
      else if (_dv.Table.Columns.Contains("Ma_Xe"))
      {
        num1 = 0;
        int num3 = checked(_dv.Count - 1);
        int recordIndex = 0;
        while (recordIndex <= num3)
        {
          DataRowView dataRowView = _dv[recordIndex];
          if (FindItemInArr(Convert.ToString(dataRowView["Ma_Xe"]), arr_txt, ";") == 0)
            checked { ++num1; }
          arr_txt = arr_txt + ";" + dataRowView["Ma_Xe"].ToString();
          checked { ++recordIndex; }
        }
      }
      return num1;
    }
    private int FindItemInArr(string _value, string arr_txt, string strSplit)
    {
      if (_value == "" | arr_txt == "")
        return -1;

      string[] strArray = arr_txt.Split(Convert.ToChar(strSplit));
      int num = checked(strArray.Length - 1);
      int itemInArr = 0;
      while (itemInArr <= num)
      {
        if (strArray[itemInArr].ToString().ToUpper() == _value.ToUpper() | "COL_" + strArray[itemInArr].ToString().ToUpper() == _value.ToUpper())
          return itemInArr;

        checked { ++itemInArr; }
      }
      return -1;
    }
    #endregion

    #region "V_SetSchedulerControl_KH_SCC"
    private void V_SetSchedulerSetValue()
    {
      string str = CyberFunc.V_GetvalueCombox(CbbLoai_Xem_KH_SCC);
      bool flag1 = true;
      bool flag2 = true;
      if (DmLoai_Xem_Loc_KH_SCC != null && DmLoai_Xem_Loc_KH_SCC.Columns.Contains("Loai"))
      {
        DataRow[] dataRowArray = DmLoai_Xem_Loc_KH_SCC.Select("Loai='" + str + "'");
        if (DmLoai_Xem_Loc_KH_SCC.Columns.Contains("ShowHead") && dataRowArray.Length > 0 && dataRowArray[0]["ShowHead"] == (object)0)
          flag1 = false;
        if (DmLoai_Xem_Loc_KH_SCC.Columns.Contains("Show_ResourcesTree") && dataRowArray.Length > 0 && dataRowArray[0]["Show_ResourcesTree"] == (object)0)
          flag2 = false;
      }
      ResourcesTree1.Visible = flag2;
      SchedulerControl_KH_SCC.Views.GanttView.ShowResourceHeaders = flag1;
      Decimal _Do_Rong = 0M;
      if (DmLoai_Xem_KH_SCC.Columns.Contains("Do_Rong"))
      {
        int num = checked(DmLoai_Xem_KH_SCC.Rows.Count - 1);
        int index = 0;
        while (index <= num)
        {
          if (DmLoai_Xem_KH_SCC.Rows[index]["Loai"].ToString().Trim().ToUpper() == str)
          {
            _Do_Rong = Convert.ToDecimal(DmLoai_Xem_KH_SCC.Rows[index]["Do_Rong"]);
            break;
          }
          checked { ++index; }
        }
      }

      string Left = str;
      if (Left == "01")
      {
        string _Id = !DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
        string _Caption = !(M_Loai_KH_SCC == "2" & str == "01") ? (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
        if (M_Kieu_Xem != "HEN" & M_Loai_KH_SCC == "1")
          V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, Dt_Khoang_H);
        else
          V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
      }
      else if (Left == "02")
      {
        if (DmCVDV_KH_SCC != null)
          V_SetScheduler(Dv_DmCVDV_KH_SCC, !DmCVDV_KH_SCC.Columns.Contains("Ma_Hs_Tmp") ? "Ma_Hs" : "Ma_Hs_Tmp", !DmCVDV_KH_SCC.Columns.Contains("Ten_Hs_Tmp") ? (DmCVDV_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_HS") : "Ten_Hs_Tmp", _Do_Rong);
        else
        {
          string _Id = !DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
          string _Caption = !(M_Loai_KH_SCC == "2" & str == "01") ? (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
          if (M_Kieu_Xem != "HEN" & M_Loai_KH_SCC == "1")
            V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, Dt_Khoang_H);
          else
            V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
        }
      }
      else if (Left == "03")
      {
        if (DmTo_KH_SCC != null)
          V_SetScheduler(Dv_DmTo_KH_SCC, !DmTo_KH_SCC.Columns.Contains("Ma_To_Tmp") ? "Ma_To" : "Ma_To_Tmp", !DmTo_KH_SCC.Columns.Contains("Ten_To_Tmp") ? (DmTo_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_To") : "Ten_To_Tmp", _Do_Rong);
        else
        {
          string _Id = !DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
          string _Caption = !(M_Loai_KH_SCC == "2" & str == "01") ? (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
          if (M_Kieu_Xem != "HEN" & M_Loai_KH_SCC == "1")
            V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, Dt_Khoang_H);
          else
            V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
        }
      }
      else if (Left == "04")
      {
        if (DmCd_KH_SCC != null)
          V_SetScheduler(Dv_DmCd_KH_SCC, !DmCd_KH_SCC.Columns.Contains("Ma_CD_Tmp") ? "Ma_CD" : "Ma_CD_Tmp", !DmCd_KH_SCC.Columns.Contains("Ten_CD_Tmp") ? (DmCd_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_CD") : "Ten_CD_Tmp", _Do_Rong);
        else
        {
          string _Id = !DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
          string _Caption = !(M_Loai_KH_SCC == "2" & str == "01") ? (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
          if (M_Kieu_Xem != "HEN" & M_Loai_KH_SCC == "1")
            V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, Dt_Khoang_H);
          else
            V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
        }
      }
      else if (Left == "05")
      {
        if (Dt_Data_Xe_KH_SCC != null)
        {
          string _Id = !Dt_Data_Xe_KH_SCC.Columns.Contains("Stt_rec_Ro_Tmp") ? "Stt_rec_Ro" : "Stt_rec_Ro_Tmp";
          string _Caption = !Dt_Data_Xe_KH_SCC.Columns.Contains("Ma_Xe_Tmp") ? (Dt_Data_Xe_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ma_Xe") : "Ma_Xe_Tmp";
          if (M_Kieu_Xem != "HEN" & M_Loai_KH_SCC == "2")
            V_SetScheduler(Dv_Data_Xe_KH_SCC, _Id, _Caption, _Do_Rong, Dt_Xe_H);
          else
            V_SetScheduler(Dv_Data_Xe_KH_SCC, _Id, _Caption, _Do_Rong);
        }
        else
        {
          string _Id = !DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
          string _Caption = !(M_Loai_KH_SCC == "2" & str == "01") ? (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
          if (M_Kieu_Xem != "HEN" & M_Loai_KH_SCC == "1")
            V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, Dt_Khoang_H);
          else
            V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
        }
      }
      else if (Left == "06")
      {
        if (Dt_Data_KTV_KH_SCC != null)
          V_SetScheduler(Dv_Data_KTV_KH_SCC, !Dt_Data_KTV_KH_SCC.Columns.Contains("Ma_KTV_Tmp") ? "Ma_KTV" : "Ma_KTV_Tmp", !Dt_Data_KTV_KH_SCC.Columns.Contains("Ten_KTV_Tmp") ? (Dt_Data_KTV_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_KTV") : "Ten_KTV_Tmp", _Do_Rong);
        else
        {
          string _Id = !DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
          string _Caption = !(M_Loai_KH_SCC == "2" & str == "01") ? (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
          if (M_Kieu_Xem != "HEN" & M_Loai_KH_SCC == "1")
            V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, Dt_Khoang_H);
          else
            V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
        }
      }
      else
      {
        string _Id = !DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
        string _Caption = !(M_Loai_KH_SCC == "2" & str == "01") ? (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
        if (M_Kieu_Xem != "HEN" & M_Loai_KH_SCC == "1")
          V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, Dt_Khoang_H);
        else
          V_SetScheduler(Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
      }
      V_Update_Ten3();
    }
    private void V_SetScheduler(DataView _Dv_DataSource, string _Id, string _Caption, Decimal _Do_Rong, DataTable _Dt_Head_tree = null)
    {
      if (_Dv_DataSource == null)
        return;

      V_AddResourcesTree(_Dv_DataSource, _Dt_Head_tree);

      SchedulerStorage_KH_SCC.Resources.DataSource = (object)null;
      SchedulerStorage_KH_SCC.Resources.Mappings.Id = "";
      SchedulerStorage_KH_SCC.Resources.Mappings.Caption = "";
      SchedulerStorage_KH_SCC.Resources.DataSource = (object)_Dv_DataSource;
      SchedulerStorage_KH_SCC.Resources.Mappings.Id = _Dv_DataSource.Table.Columns[_Id].ColumnName.ToString().Trim();
      SchedulerStorage_KH_SCC.Resources.Mappings.Caption = _Dv_DataSource.Table.Columns[_Caption].ColumnName.ToString().Trim();

      if (_Dv_DataSource.Table.Columns.Contains("Color"))
        SchedulerStorage_KH_SCC.Resources.Mappings.Color = _Dv_DataSource.Table.Columns["Color"].ColumnName.ToString().Trim();

      if (_Dv_DataSource.Table.Columns.Contains("Image"))
        SchedulerStorage_KH_SCC.Resources.Mappings.Image = _Dv_DataSource.Table.Columns["Image"].ColumnName.ToString().Trim();

      if (Decimal.Compare(_Do_Rong, 0M) > 0)
        SchedulerControl_KH_SCC.OptionsView.ResourceHeaders.Height = Convert.ToInt32(_Do_Rong);

      SchedulerStorage_KH_SCC.Appointments.Mappings.ResourceId = Dt_Data_KH_SCC.Columns[_Id].ColumnName;

      if (Dt_Data_KH_SCC.Columns.Contains("ten_CD") & M_Loai_KH_SCC.Trim() == "2" & M_Kieu_Xem != "HEN")
        SchedulerStorage_KH_SCC.Appointments.Mappings.Subject = Dt_Data_KH_SCC.Columns["ten_CD"].ColumnName;
      else
        SchedulerStorage_KH_SCC.Appointments.Mappings.Subject = Dt_Data_KH_SCC.Columns["Ma_Xe"].ColumnName;

      if (Dt_Data_Parent_KH_SCC == null || !(Dt_Data_Parent_KH_SCC.Columns.Contains("DependentId") & Dt_Data_Parent_KH_SCC.Columns.Contains("ParentId") & Dt_Data_Parent_KH_SCC.Columns.Contains("Type")))
        return;

      SchedulerStorage_KH_SCC.AppointmentDependencies.DataSource = (object)Dt_Data_Parent_KH_SCC;
      SchedulerStorage_KH_SCC.AppointmentDependencies.Mappings.DependentId = Dt_Data_Parent_KH_SCC.Columns["DependentId"].ColumnName;
      SchedulerStorage_KH_SCC.AppointmentDependencies.Mappings.ParentId = Dt_Data_Parent_KH_SCC.Columns["ParentId"].ColumnName;
      SchedulerStorage_KH_SCC.AppointmentDependencies.Mappings.Type = Dt_Data_Parent_KH_SCC.Columns["Type"].ColumnName;
    }
    private void V_AddResourcesTree(DataView _Dv_DataSource, DataTable _Dt_Header)
    {
      ResourcesTree1.Columns.Clear();
      if (M_Kieu_Xem == "HEN")
      {
        ResourcesTree1.Visible = false;
        SplitContainer_Tien_Do.SplitterDistance = 0;
      }
      else if (_Dv_DataSource == null | _Dt_Header == null)
      {
        SchedulerControl_KH_SCC.Views.GanttView.ShowResourceHeaders = true;
        ResourcesTree1.Visible = false;
      }
      else
      {
        ResourcesTree1.BorderStyle = SchedulerControl_KH_SCC.BorderStyle;
        int num = 10;
        int Left1 = num;
        ResourcesTree1.Visible = true;
        ResourcesTree1.Columns.Clear();
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
              repositoryItemMemoEdit.BorderStyle = BorderStyles.Default;
              column.ColumnEdit = (RepositoryItem)repositoryItemMemoEdit;
              column.OptionsColumn.AllowSort = false;
              Left1 = Left1 + Convert.ToInt32(row["Field_Width"]);
              var test = row["Field_Name"];
              column.FieldName = _Dv_DataSource.Table.Columns["Field_Name"].ColumnName; // TODO
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
              ResourcesTree1.Columns.Add((TreeListColumn)column);
            }
          }
        }
        catch(Exception ex)
        {
          MessageBox.Show("V_AddResourcesTree: " + ex.Message);
        }
        if (num == Left1)
        {
          ResourcesTree1.Visible = false;
          SplitContainer_Tien_Do.SplitterDistance = 20;
        }
        else
        {
          ResourcesTree1.Width = Left1;
          ResourcesTree1.Visible = true;
          SplitContainer_Tien_Do.SplitterDistance = Left1;
        }
      }
    }
    private void V_SetColorAppointments()
    {
      int num1 = checked(Dt_ConFigColor_KH_SCC.Rows.Count - 1);
      int num2 = 0;
      while (num2 <= num1)
      {
        SchedulerStorage_KH_SCC.Appointments.Labels[num2].Color = CyberColor.GetBackColor(Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["BackColor"]));
        SchedulerStorage_KH_SCC.Appointments.Labels[num2].DisplayName = Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["Ten_Color"]);
        SchedulerStorage_KH_SCC.Appointments.Labels[num2].MenuCaption = Convert.ToString(Dt_ConFigColor_KH_SCC.Rows[num2]["Ten_Color"]);
        V_SetColorlabel_SCC(num2, Dt_ConFigColor_KH_SCC.Rows[num2]);
        checked { ++num2; }
      }
    }
    private void V_SetColorlabel_SCC(int _i, DataRow _Dr)
    {
      if (_i > 19)
        return;

      int num = checked(_i + 1);
      bool flag = true;
      switch (num)
      {
        case 1:
          var test = _Dr["Ten_Color"];
          Lab_SCC1_01.Visible = flag;
          Lab_SCC_01.Visible = true;
          Lab_SCC1_01.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_01.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_01.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_01.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 2:
          Lab_SCC1_02.Visible = flag;
          Lab_SCC_02.Visible = true;
          Lab_SCC1_02.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_02.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_02.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_02.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 3:
          Lab_SCC1_03.Visible = flag;
          Lab_SCC_03.Visible = true;
          Lab_SCC1_03.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_03.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_03.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_03.Tag = _Dr["Ma_Color"].ToString().Trim();
          break;
        case 4:
          Lab_SCC1_04.Visible = flag;
          Lab_SCC_04.Visible = true;
          Lab_SCC1_04.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_04.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_04.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_04.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 5:
          Lab_SCC1_05.Visible = flag;
          Lab_SCC_05.Visible = true;
          Lab_SCC1_05.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_05.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_05.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_05.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 6:
          Lab_SCC1_06.Visible = flag;
          Lab_SCC_06.Visible = true;
          Lab_SCC1_06.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_06.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_06.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_06.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 7:
          Lab_SCC1_07.Visible = flag;
          Lab_SCC_07.Visible = true;
          Lab_SCC1_07.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_07.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_07.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_07.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 8:
          Lab_SCC1_08.Visible = flag;
          Lab_SCC_08.Visible = true;
          Lab_SCC1_08.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_08.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_08.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_08.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 9:
          Lab_SCC1_09.Visible = flag;
          Lab_SCC_09.Visible = true;
          Lab_SCC1_09.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_09.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_09.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_09.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 10:
          Lab_SCC1_10.Visible = flag;
          Lab_SCC_10.Visible = true;
          Lab_SCC1_10.Text = _Dr["Ten_Color"].ToString();
          break;
        case 11:
          Lab_SCC1_11.Visible = flag;
          Lab_SCC_11.Visible = true;
          Lab_SCC1_11.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_11.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_11.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_11.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 12:
          Lab_SCC1_12.Visible = flag;
          Lab_SCC_12.Visible = true;
          Lab_SCC1_12.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_12.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_12.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_12.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 13:
          Lab_SCC1_13.Visible = flag;
          Lab_SCC_13.Visible = true;
          Lab_SCC1_13.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_13.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_13.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_13.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 14:
          Lab_SCC1_14.Visible = flag;
          Lab_SCC_14.Visible = true;
          Lab_SCC1_14.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_14.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_14.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_14.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 15:
          Lab_SCC1_15.Visible = flag;
          Lab_SCC_15.Visible = true;
          Lab_SCC1_15.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_15.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_15.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_15.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 16:
          Lab_SCC1_16.Visible = flag;
          Lab_SCC_16.Visible = true;
          Lab_SCC1_16.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_16.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_16.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_16.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 17:
          Lab_SCC1_17.Visible = flag;
          Lab_SCC_17.Visible = true;
          Lab_SCC1_17.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_17.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_17.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_17.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 18:
          Lab_SCC1_18.Visible = flag;
          Lab_SCC_18.Visible = true;
          Lab_SCC1_18.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_18.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_18.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_18.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 19:
          Lab_SCC1_19.Visible = flag;
          Lab_SCC_19.Visible = true;
          Lab_SCC1_19.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_19.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_19.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_19.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 20:
          Lab_SCC1_20.Visible = flag;
          Lab_SCC_20.Visible = true;
          Lab_SCC1_20.Text = _Dr["Ten_Color"].ToString();
          Lab_SCC_20.BackColor = CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          Lab_SCC_20.ForeColor = CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          Lab_SCC_20.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
      }
    }
    #endregion

    #region "V_Load_Cho_Lap_KH"
    private void V_LoadData_Cho_Lap_KH(string status, string _Stt_rec_Ro)
    {
      DateTime date = DateTime.Now.Date;
      DataSet dataSet = new DataSet(); // TODO: CP_RO_CVDV_Cho_Lap_KH
      int num = checked(dataSet.Tables.Count - 1);
      int index = 0;
      while (index <= num)
      {
        CyberFunc.SetNotNullTable(dataSet.Tables[index]);
        checked { ++index; }
      }

      V_LoadDataMoLenhTrongNgay(_Stt_rec_Ro);

      if (status.ToUpper().Trim() == "1")
      {
        Dt_Cho_Lap_KH = dataSet.Tables[0].Copy();
        Dv_Cho_Lap_KH = new DataView(Dt_Cho_Lap_KH);
        if (dataSet.Tables.Count == 2)
        {
          Dt_Cho_Lap_KH_H = dataSet.Tables[1].Copy();
          Dv_Cho_Lap_KH_H = new DataView(Dt_Cho_Lap_KH_H);
        }
        else
        {
          Dt_Sua_Xong_KH = dataSet.Tables[1].Copy();
          Dv_Sua_Xong_KH = new DataView(Dt_Sua_Xong_KH);
          Dt_Cho_Lap_KH_H = dataSet.Tables[2].Copy();
          Dv_Cho_Lap_KH_H = new DataView(Dt_Cho_Lap_KH_H);
          Dt_Sua_Xong_KH_H = dataSet.Tables[3].Copy();
          Dv_Sua_Xong_KH_H = new DataView(Dt_Sua_Xong_KH_H);
          if (dataSet.Tables.Count >= 5)
            CyberFunc.V_SetSortView(ref Dv_Cho_Lap_KH, dataSet.Tables[4]);
          if (dataSet.Tables.Count >= 6)
            CyberFunc.V_SetSortView(ref Dv_Sua_Xong_KH, dataSet.Tables[5]);
        }
        dataSet.Dispose();
        CyberColor.V_GetColorBold2(Dt_Cho_Lap_KH, ref _Bold_Cho_Lap_KH, ref _BackColor_Cho_Lap_KH, ref _BackColor2_Cho_Lap_KH, ref _Forecolor_Cho_Lap_KH, ref _Underline_Cho_Lap_KH, ref _FieldBold_Cho_Lap_KH, ref _FieldBackColor_Cho_Lap_KH, ref _FieldBackColor2_Cho_Lap_KH, ref _FieldForecolor_Cho_Lap_KH, ref _FieldUnderline_Cho_Lap_KH);
      }
      else
      {
        if (_Stt_rec_Ro.Trim() == "")
        {
          Dt_Cho_Lap_KH.Clear();
          Dt_Cho_Lap_KH.Load((IDataReader)dataSet.Tables[0].CreateDataReader());
          if (Dt_Sua_Xong_KH != null & dataSet.Tables.Count > 1)
          {
            Dt_Sua_Xong_KH.Clear();
            Dt_Sua_Xong_KH.Load((IDataReader)dataSet.Tables[1].CreateDataReader());
          }
        }
        else
        {
          if (Dt_Cho_Lap_KH != null)
            CyberFunc.DeleteDatatable(ref Dt_Cho_Lap_KH, "Stt_rec_Ro ='" + _Stt_rec_Ro.Trim() + "'");
          if (Dt_Cho_Lap_KH != null)
            Dt_Cho_Lap_KH.Load((IDataReader)dataSet.Tables[0].CreateDataReader());
          if (Dt_Sua_Xong_KH != null)
            CyberFunc.DeleteDatatable(ref Dt_Sua_Xong_KH, "Stt_rec_Ro ='" + _Stt_rec_Ro.Trim() + "'");
          if (Dt_Sua_Xong_KH != null)
            Dt_Sua_Xong_KH.Load((IDataReader)dataSet.Tables[1].CreateDataReader());
        }
        dataSet.Dispose();
        if (Dt_Cho_Lap_KH != null)
          Dt_Cho_Lap_KH.AcceptChanges();
        if (Dt_Sua_Xong_KH != null)
          Dt_Sua_Xong_KH.AcceptChanges();
        T_tinh_So_Xe();
      }
    }
    private void V_LoadDataMoLenhTrongNgay(string _Stt_rec_Ro)
    {
      DateTime date = Convert.ToDateTime(TxtM_Ngay_Ct_KH_SCC.EditValue);
      DataSet dataSet = new DataSet(); // TODO: CP_RO_CVDV_MoLenh_Trong_Ngay
      int num = checked(dataSet.Tables.Count - 1);
      int index = 0;
      while (index <= num)
      {
        CyberFunc.SetNotNullTable(dataSet.Tables[index]);
        checked { ++index; }
      }
      Dt_Mo_Lenh_Trong_Ngay = dataSet.Tables[0].Copy();
      Dv_Mo_Lenh_Trong_Ngay = new DataView(Dt_Mo_Lenh_Trong_Ngay);
      Dt_Lenh_Giao_Trong_Ngay = dataSet.Tables[1].Copy();
      Dv_Lenh_Giao_Trong_Ngay = new DataView(Dt_Lenh_Giao_Trong_Ngay);
    }
    private void V_Fill_Cho_Lap_KH()
    {
      bool flag = false;
      int num1 = 50;
      int Left = num1;
      if (Dv_Cho_Lap_KH == null)
        flag = true;
      else
      {
        int num2 = checked(Dv_Cho_Lap_KH_H.Count - 1);
        int recordIndex = 0;
        while (recordIndex <= num2)
        {
          Left = Left + Convert.ToInt32(Dv_Cho_Lap_KH_H[recordIndex]["Field_Width"]);
          checked { ++recordIndex; }
        }
      }
      if (Left == num1)
        Left = 0;

      SplitContainer2.SplitterDistance = Left;
      Master_Cho_Lap_KH.DataSource = (object)Dv_Cho_Lap_KH;
      Master_Cho_Lap_KHGRV.GridControl = Master_Cho_Lap_KH;
      //TODO
      //Cyber.Fill.Sys cyberFill = CyberFill;
      //GridView masterChoLapKhgrv = Master_Cho_Lap_KHGRV;
      //ref GridView local = ref masterChoLapKhgrv;
      //string lan = M_LAN;
      //DataView dvChoLapKhH = Dv_Cho_Lap_KH_H;
      //DataView dvChoLapKh = Dv_Cho_Lap_KH;
      //cyberFill.V_FillReports(ref local, lan, dvChoLapKhH, dvChoLapKh);
      //Master_Cho_Lap_KHGRV = masterChoLapKhgrv;
      Master_Cho_Lap_KHGRV.Appearance.SelectedRow.BackColor = System.Drawing.Color.YellowGreen;
      Master_Cho_Lap_KHGRV.OptionsSelection.MultiSelect = false;
    }
    private void V_Fill_Sua_Xong_KH()
    {
      if (Dv_Sua_Xong_KH == null)
        return;

      Master_Sua_Xong_KH.DataSource = (object)Dv_Sua_Xong_KH;
      Master_Sua_Xong_KHGRV.GridControl = Master_Sua_Xong_KH;

      //TODO
      //Cyber.Fill.Sys cyberFill = CyberFill;
      //GridView masterSuaXongKhgrv = Master_Sua_Xong_KHGRV;
      //ref GridView local = ref masterSuaXongKhgrv;
      //string lan = M_LAN;
      //DataView dvSuaXongKhH = Dv_Sua_Xong_KH_H;
      //DataView dvSuaXongKh = Dv_Sua_Xong_KH;
      //cyberFill.V_FillReports(ref local, lan, dvSuaXongKhH, dvSuaXongKh);
      //Master_Sua_Xong_KHGRV = masterSuaXongKhgrv;
      Master_Sua_Xong_KHGRV.Appearance.SelectedRow.BackColor = System.Drawing.Color.YellowGreen;
      Master_Sua_Xong_KHGRV.OptionsSelection.MultiSelect = false;
    }
    private void V_AddHander_Cho_Lap_KH()
    {
      Master_Cho_Lap_KHGRV.PopupMenuShowing -= new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(Master_Cho_Lap_KHGRV_PopupMenuShowing);
      Master_Cho_Lap_KHGRV.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(Master_Cho_Lap_KHGRV_PopupMenuShowing);
      Master_Sua_Xong_KHGRV.PopupMenuShowing -= new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(Master_Sua_Xong_KHGRVPopupMenuShowing);
      Master_Sua_Xong_KHGRV.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(Master_Sua_Xong_KHGRVPopupMenuShowing);
      Master_Cho_Lap_KHGRV.RowCellStyle -= new RowCellStyleEventHandler(Master_Cho_Lap_KHGRV_RowCellStyle);
      Master_Cho_Lap_KHGRV.RowCellStyle += new RowCellStyleEventHandler(Master_Cho_Lap_KHGRV_RowCellStyle);
      Master_Sua_Xong_KHGRV.RowCellStyle -= new RowCellStyleEventHandler(Master_Sua_Xong_KHGRV_RowCellStyle);
      Master_Sua_Xong_KHGRV.RowCellStyle += new RowCellStyleEventHandler(Master_Sua_Xong_KHGRV_RowCellStyle);
      TxtSo_Ro_Cho_Lap_KH.TextChanged -= new EventHandler(V_Loc_Xe_Cho_Lap_KH);
      TxtSo_Ro_Cho_Lap_KH.TextChanged += new EventHandler(V_Loc_Xe_Cho_Lap_KH);
      TxtMa_Xe_Cho_Lap_KH.TextChanged -= new EventHandler(V_Loc_Xe_Cho_Lap_KH);
      TxtMa_Xe_Cho_Lap_KH.TextChanged += new EventHandler(V_Loc_Xe_Cho_Lap_KH);
    }
    private void V_DragDropGridview_KH_SCC()
    {
      _keotha2Grid = new GridviewDragDrop(Master_Cho_Lap_KH, (Control)SchedulerControl_KH_SCC);
      SchedulerControl_KH_SCC.DragDrop -= new DragEventHandler(Master_Cho_Lap_KH_DragDrop);
      SchedulerControl_KH_SCC.DragDrop += new DragEventHandler(Master_Cho_Lap_KH_DragDrop);
    }
    private void Master_Cho_Lap_KH_DragDrop(object sender, DragEventArgs e)
    {
      SchedulerControl schedulerControl2 = (SchedulerControl)sender;
      if (!(e.Data.GetData(typeof(DataRow)) is DataRow data))
        return;

      Point client = schedulerControl2.PointToClient(new Point(e.X, e.Y));
      SchedulerHitInfo schedulerHitInfo = SchedulerControl_KH_SCC.ActiveView.ViewInfo.CalcHitInfo(client, true);
      if (schedulerHitInfo.HitTest == SchedulerHitTest.Cell)
      {
        SelectableIntervalViewInfo viewInfo = schedulerHitInfo.ViewInfo;
        string _Stt_Rec_Ro = Convert.ToString(data["Stt_Rec_Ro"]);
        string str1 = Convert.ToString(viewInfo.Resource.Id);
        DateTime start = SchedulerControl_KH_SCC.SelectedInterval.Start;
        DateTime end = SchedulerControl_KH_SCC.SelectedInterval.End;
        string _Stt_Rec_Hen;
        try
        {
          string str2 = Convert.ToString((SchedulerControl_KH_SCC.ActiveView.CalcHitInfo(client, false).ViewInfo as AppointmentViewInfo).Appointment.Id);
          if (str2.ToUpper().Trim() == "DevExpress.XtraScheduler.EmptyResourceId".ToUpper().Trim())
            str2 = "";

          _Stt_Rec_Hen = str2.Replace("_THUCHIEN", "");
        }
        catch (Exception ex)
        {
          _Stt_Rec_Hen = "";
          MessageBox.Show(ex.Message);
        }
        if (_Stt_Rec_Hen.Trim() == "")
        {
          if (!V_Hen_To_KH_Drap_Drop(_Stt_Rec_Ro, _Stt_Rec_Hen))
            V_Tao_DragDrop_KH_SCC(_Stt_Rec_Ro, str1, start, end);
        }
        else
          V_Tao_DragDrop_KH_SCC(_Stt_Rec_Ro, str1, start, end);
      }
    }
    private bool V_Hen_To_KH_Drap_Drop(string _Stt_Rec_Ro, string _Stt_Rec_Hen) => _Stt_Rec_Hen.Contains(M_Ma_CT_DLH.Trim()) && V_Hen_To_Kh(_Stt_Rec_Hen, _Stt_Rec_Ro);
    private void V_Hen_To_Kh(object sender, EventArgs e)
    {
      string str1 = "";
      if (this.SchedulerControl_KH_SCC.SelectedAppointments.Count > 0)
        str1 = this.SchedulerControl_KH_SCC.SelectedAppointments[0].Id.ToString();
      if (str1.Trim() == "")
        return;

      string str2 = str1.Replace("_THUCHIEN", "");
      if (!str2.Contains(this.M_Ma_CT_DLH.Trim()))
        return;

      this.V_Hen_To_Kh(str2, "");
    }
    private bool V_Hen_To_Kh(string _Stt_rec_hen, string _Stt_Rec_Ro)
    {
      bool kh1 = false;
      if (_Stt_rec_hen.Trim() == "")
        return kh1;

      _Stt_rec_hen = _Stt_rec_hen.Replace("_THUCHIEN", "");
      if (!_Stt_rec_hen.Contains(M_Ma_CT_DLH.Trim()))
        return kh1;

      string kh2 = ""; //TODO: open form (FrmCVDV_Hen_To_KH);
      if (kh2.Trim() == "")
        return kh1;

      DataSet dataSet = new DataSet(); //TODO: CP_RO_CVDV_Hen_To_KH
      if (dataSet.Tables[0].Rows.Count == 0)
      {
        dataSet.Dispose();
        return kh1;
      }
      int num = checked(Dt_Data_KH_SCC.Rows.Count - 1);
      SchedulerControl_KH_SCC.BeginUpdate();
      int index = num;
      while (index >= 0)
      {
        if (Dt_Data_KH_SCC.Rows[index]["Stt_Rec"].ToString().Trim().ToUpper() == _Stt_rec_hen.ToUpper().Trim())
        {
          Dt_Data_KH_SCC.Rows[index].Delete();
          break;
        }
        checked { index += -1; }
      }
      Dt_Data_KH_SCC.AcceptChanges();
      SchedulerControl_KH_SCC.EndUpdate();

      string _Stt_Rec_Load = dataSet.Tables[0].Rows[0]["Stt_Rec_Load"].ToString();
      dataSet.Dispose();

      V_Load_DATA_KH_SCC("0", "", _Stt_Rec_Load);

      return kh1;
    }
    private void V_Tao_DragDrop_KH_SCC(string _Stt_Rec_Ro, string _Value, DateTime _Ngay_BD, DateTime _Ngay_KT)
    {
      string str1 = "";
      string str2 = "";
      string str3 = "";
      string str4 = "";
      string str5 = "";
      string maCtPkh = M_Ma_CT_PKH;
      string str6 = "";

      string Left = CyberFunc.V_GetvalueCombox(CbbLoai_Xem_KH_SCC);
      if (Left == "01")
        str1 = _Value;
      else if (Left == "02")
        str2 = _Value;
      else if (Left == "03")
        str3 = _Value;
      else if (Left == "04")
        str5 = _Value;
      else if (Left == "05")
        _Stt_Rec_Ro = _Value;
      else if (Left == "06")
        str6 = _Value;
      else
        str1 = _Value;

      DateTime date = Convert.ToDateTime(TxtM_Ngay_Ct_KH_SCC.EditValue);
      DataSet dataSet = new DataSet(); //TODO: CP_RO_CVDV_KH_SCC_Save_DragDrop
      if (dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0)
        return;

      int num = checked(dataSet.Tables.Count - 1);
      int index = 0;
      while (index <= num)
      {
        CyberFunc.SetNotNullTable(dataSet.Tables[index]);
        checked { ++index; }
      }
      if (!dataSet.Tables[0].Columns.Contains("Status") | !dataSet.Tables[0].Columns.Contains("Msg") | !dataSet.Tables[0].Columns.Contains("Note"))
        return;

      if (dataSet.Tables[0].Rows.Count == 0)
        dataSet.Dispose();
      else
      {
        if (!dataSet.Tables[0].Columns.Contains("Stt_Rec"))
          return;

        string _Stt_Rec_Load = dataSet.Tables[0].Rows[0]["Stt_Rec"].ToString().Trim();
        if (_Stt_Rec_Load.Trim() == "")
          return;

        V_Load_DATA_KH_SCC("0", "", _Stt_Rec_Load);
        dataSet.Dispose();
      }
    }
    #endregion

    #region "V_AddHander_Cho_Lap_KH"
    private void Master_Cho_Lap_KHGRV_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
    {
      int rowHandle = e != null ? e.HitInfo.RowHandle : -1;
      PopupMenu.ItemLinks.Clear();

      if (M_Kieu_Xem != "HEN")
        PopupMenu.ItemLinks.Add(
          new CyberMenuPopup(sender, 0, "Tạo Kế hoạch sửa chữa", 
            new EventHandler(V_Tao_Tien_Do_Cho_Lap_KH), Shortcut.F4,
            ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), true), false);

      if (M_Kieu_Xem != "HEN" & M_Loai_KH_SCC.Trim() == "2")
        PopupMenu.ItemLinks.Add(
          new CyberMenuPopup(sender, 0, "Tạo nhanh kế hoạch sửa chữa đồng sơn", 
            new EventHandler(V_Tao_Tien_Do_Cho_Lap_KHALL), Shortcut.None,
            ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), true), false);

      if (M_Kieu_Xem != "HEN")
        PopupMenu.ItemLinks.Add(
          new CyberMenuPopup(sender, 0, "Kết thúc kế hoạch Dừng", 
            new EventHandler(V_KH_SCC_KT_Dung_SC), Shortcut.None,
            ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), true), false);

      if (M_Kieu_Xem != "HEN")
        PopupMenu.ItemLinks.Add(
          new CyberMenuPopup(sender, 0, "Sửa kế hoạch Dừng", 
            (EventHandler)((a0, a1) => V_KH_SCC_Edit_Dung_SC()), Shortcut.None,
            ImageResourceCache.Default.GetImage("images/edit/edit_16x16.png"), true), false);

      if (M_Kieu_Xem != "HEN")
        PopupMenu.ItemLinks.Add(
          new CyberMenuPopup(sender, 0, "Xem Lenh", 
          new EventHandler(V_Preview_Cho_Lap_KH), Shortcut.F7,
          ImageResourceCache.Default.GetImage("images/print/preview_16x16.png"), true), false);

      PopupMenu.ItemLinks.Add(
        new CyberMenuPopup(sender, 0, "Làm tươi dữ liệu", 
          new EventHandler(V_Refresh_Cho_Lap_KH), Shortcut.F5,
          ImageResourceCache.Default.GetImage("images/actions/refresh2_16x16.png"), true), false);

      PopupMenu.ItemLinks.Add(
        new CyberMenuPopup(sender, 0, "Tải dữ liệu", 
          new EventHandler(V_ExportExcel_Cho_Lap_Kh), Shortcut.F11, 
          null, true), false);

      PopupMenu.ItemLinks.Add(
        new CyberMenuPopup(sender, rowHandle, "Quay ra", 
          new EventHandler(V_Quay_Ra), 
          ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), true), true);

      PopupMenu.ShowPopup(Control.MousePosition);

      if (e == null)
        return;

      PopupMenu.ShowPopup(Control.MousePosition);
    }
    private void Master_Sua_Xong_KHGRVPopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
    {
      int rowHandle = e != null ? e.HitInfo.RowHandle : -1;
      PopupMenu.ItemLinks.Clear();

      if (M_Kieu_Xem != "HEN")
        PopupMenu.ItemLinks.Add(
          new CyberMenuPopup(sender, 0, "Đặt vị trí xe", 
            new EventHandler(V_Vi_Tri_Xe), Shortcut.F4,
            ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), true), true);
      
      if (M_Kieu_Xem != "HEN")
        PopupMenu.ItemLinks.Add(
          new CyberMenuPopup(sender, 0, "Xem vị trí xe", 
            new EventHandler(V_Vi_Tri_Xe_Load), Shortcut.F10, 
            null, true), false);
      
      if (M_Kieu_Xem != "HEN")
        PopupMenu.ItemLinks.Add(
          new CyberMenuPopup(sender, 0, "Xem Lenh", 
            new EventHandler(V_Preview_Sua_Xong_KH), Shortcut.F7,
            ImageResourceCache.Default.GetImage("images/print/preview_16x16.png"), true), true);
      
      PopupMenu.ItemLinks.Add(
        new CyberMenuPopup(sender, 0, "Làm tươi dữ liệu", 
          new EventHandler(V_Refresh_Cho_Lap_KH), Shortcut.F5,
          ImageResourceCache.Default.GetImage("images/actions/refresh2_16x16.png"), true), true);
      
      PopupMenu.ItemLinks.Add(
        new CyberMenuPopup(sender, rowHandle, "Quay ra", 
          new EventHandler(V_Quay_Ra),
          ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), true), true);
      
      PopupMenu.ShowPopup(Control.MousePosition);
      
      if (e == null)
        return;

      PopupMenu.ShowPopup(Control.MousePosition);
    }
    private void Master_Cho_Lap_KHGRV_RowCellStyle(object sender, RowCellStyleEventArgs e)
    {
      if (Dv_Cho_Lap_KH == null)
        return;

      GRV_RowCellStyle2(sender, e, Master_Cho_Lap_KHGRV, _Bold_Cho_Lap_KH, _BackColor_Cho_Lap_KH, _BackColor2_Cho_Lap_KH, _Forecolor_Cho_Lap_KH, _Underline_Cho_Lap_KH, _FieldBold_Cho_Lap_KH, _FieldBackColor_Cho_Lap_KH, _FieldBackColor2_Cho_Lap_KH, _FieldForecolor_Cho_Lap_KH, _FieldUnderline_Cho_Lap_KH);
    }
    private void Master_Sua_Xong_KHGRV_RowCellStyle(object sender, RowCellStyleEventArgs e)
    {
      if (Dv_Sua_Xong_KH == null)
        return;

      GRV_RowCellStyle2(sender, e, Master_Sua_Xong_KHGRV, _Bold_Sua_Xong_KH, _BackColor_Sua_Xong_KH, _BackColor2_Sua_Xong_KH, _Forecolor_Sua_Xong_KH, _Underline_Sua_Xong_KH, _FieldBold_Sua_Xong_KH, _FieldBackColor_Sua_Xong_KH, _FieldBackColor2_Sua_Xong_KH, _FieldForecolor_Sua_Xong_KH, _FieldUnderline_Sua_Xong_KH);
    }
    private void GRV_RowCellStyle2(object sender, RowCellStyleEventArgs e, GridView _GRV, bool _Bold, bool _BackColor, bool _BackColor2, bool _Forecolor, bool _UnderLine, string _FieldBold, string _FieldBackColor, string _FieldBackColor2, string _FieldForecolor, string _FieldUnderline)
    {
      GridView view = sender as GridView;
      if (!view.IsCellSelected(e.RowHandle, e.Column))
      {
        string str1 = "";
        string str2 = "";
        bool flag1 = false;
        bool flag2 = false;

        if (_UnderLine & _FieldUnderline != "")
          str1 = _GRV.GetRowCellDisplayText(e.RowHandle, _FieldUnderline).ToString().Trim();
        if (str1.Trim() == "1")
          flag1 = true;
        if (_FieldBold != "")
          str2 = _GRV.GetRowCellDisplayText(e.RowHandle, _FieldBold).ToString().Trim();
        if (str2.Trim() == "1")
          flag2 = true;

        e.Appearance.Font = !flag2 ? (!flag1 ? new Font(Font.FontFamily, Font.Size, FontStyle.Regular) : new Font(Font.FontFamily, Font.Size, FontStyle.Underline)) : (!flag1 ? new Font(Font.FontFamily, Font.Size, FontStyle.Bold) : new Font(Font.FontFamily, Font.Size, FontStyle.Bold | FontStyle.Underline));
        if (_BackColor)
        {
          string ColorName = _GRV.GetRowCellDisplayText(e.RowHandle, _FieldBackColor).ToString().Trim();
          e.Appearance.BackColor = CyberColor.GetBacColorkReports(ColorName);
        }
        if (_BackColor2)
        {
          string ColorName = _GRV.GetRowCellDisplayText(e.RowHandle, _FieldBackColor2).ToString().Trim();
          if (ColorName.Trim() != "")
            e.Appearance.BackColor2 = CyberColor.GetBacColorkReports(ColorName);
        }
        if (!_Forecolor)
          return;

        string ColorName1 = _GRV.GetRowCellDisplayText(e.RowHandle, _FieldForecolor).ToString().Trim();
        e.Appearance.ForeColor = CyberColor.GetForeColor(ColorName1);
      }
      else
        e.Appearance.BackColor = Color.Silver;
    }
    #endregion

    #region "Master_Cho_Lap_KHGRV_PopupMenuShowing"
    private void V_Tao_Tien_Do_Cho_Lap_KH(object sender, EventArgs e)
    {
      int dataSourceRowIndex = Master_Cho_Lap_KHGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0 || !Dt_Cho_Lap_KH.Columns.Contains("Stt_Rec_Ro") | !Dt_Cho_Lap_KH.Columns.Contains("So_Ro"))
        return;

      V_Set_Auto_Refresh(false);

      string _Stt_rec = "";
      string _Stt_rec_RO = "";
      string _So_Ro = "";
      string _Ma_Xe = "";
      string _ma_khoang = "";
      string _Ma_CVDV = "";
      string _Ma_To = "";
      string _Ma_CD = "";
      string _Ma_KTV = "";

      if (Dt_Cho_Lap_KH.Columns.Contains("Stt_Rec_Ro"))
        _Stt_rec_RO = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["Stt_Rec_Ro"]);
      if (Dt_Cho_Lap_KH.Columns.Contains("So_Ro"))
        _So_Ro = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["So_Ro"]);
      if (Dt_Cho_Lap_KH.Columns.Contains("Ma_Xe"))
        _Ma_Xe = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["Ma_Xe"]);
      if (Dt_Cho_Lap_KH.Columns.Contains("_Ma_CVDV"))
        _Ma_Xe = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["Ma_HS"]);

      DateTime _Ngay_BD = SchedulerControl_KH_SCC.SelectedInterval.Start;
      DateTime _Ngay_KT = SchedulerControl_KH_SCC.SelectedInterval.End;
      if (Dt_Cho_Lap_KH.Columns.Contains("Ngay_BD0"))
        _Ngay_BD = Convert.ToDateTime(Dv_Cho_Lap_KH[dataSourceRowIndex]["Ngay_BD0"]);
      if (Dt_Cho_Lap_KH.Columns.Contains("Ngay_KT0"))
        _Ngay_KT = Convert.ToDateTime(Dv_Cho_Lap_KH[dataSourceRowIndex]["Ngay_KT0"]);

      V_Tao_Sua_Tien_Do_KH_SCC("M", M_Ma_CT_PKH, _Stt_rec, _Stt_rec_RO, _So_Ro, _Ngay_BD, _Ngay_KT, _ma_khoang, _Ma_CVDV, _Ma_To, _Ma_Xe, _Ma_CD, _Ma_KTV);
      V_Set_Auto_Refresh(true);
    }
    private void V_Tao_Tien_Do_Cho_Lap_KHALL(object sender, EventArgs e)
    {
      int dataSourceRowIndex = Master_Cho_Lap_KHGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0 || !Dt_Cho_Lap_KH.Columns.Contains("Stt_Rec_Ro") | !Dt_Cho_Lap_KH.Columns.Contains("So_Ro"))
        return;

      V_Set_Auto_Refresh(false);

      string _Stt_rec = "";
      string _Stt_rec_RO = "";
      string _So_Ro = "";
      string _Ma_Xe = "";
      string _ma_khoang = "";
      string _Ma_CVDV = "";
      string _Ma_To = "";
      string _Ma_CD = "";
      string _Ma_KTV = "";
      if (Dt_Cho_Lap_KH.Columns.Contains("Stt_Rec_Ro"))
        _Stt_rec_RO = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["Stt_Rec_Ro"]);
      if (Dt_Cho_Lap_KH.Columns.Contains("So_Ro"))
        _So_Ro = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["So_Ro"]);
      if (Dt_Cho_Lap_KH.Columns.Contains("Ma_Xe"))
        _Ma_Xe = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["Ma_Xe"]);
      if (Dt_Cho_Lap_KH.Columns.Contains("_Ma_CVDV"))
        _Ma_Xe = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["Ma_HS"]);

      DateTime _Ngay_BD = SchedulerControl_KH_SCC.SelectedInterval.Start;
      DateTime _Ngay_KT = SchedulerControl_KH_SCC.SelectedInterval.End;
      if (Dt_Cho_Lap_KH.Columns.Contains("Ngay_BD0"))
        _Ngay_BD = Convert.ToDateTime(Dv_Cho_Lap_KH[dataSourceRowIndex]["Ngay_BD0"]);
      if (Dt_Cho_Lap_KH.Columns.Contains("Ngay_KT0"))
        _Ngay_KT = Convert.ToDateTime(Dv_Cho_Lap_KH[dataSourceRowIndex]["Ngay_KT0"]);

      V_Tao_Moi_SDSALL("M", M_Ma_CT_PKH, _Stt_rec, _Stt_rec_RO, _So_Ro, _Ngay_BD, _Ngay_KT, _ma_khoang, _Ma_CVDV, _Ma_To, _Ma_Xe, _Ma_CD, _Ma_KTV);
      V_Set_Auto_Refresh(true);
    }
    private void V_KH_SCC_KT_Dung_SC(object sender, EventArgs e)
    {
      int dataSourceRowIndex = Master_Cho_Lap_KHGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0)
        return;

      string str1 = "";
      string str2 = "";
      string _So_Ro = "";
      string _Ma_Xe = "";
      if (Dt_Cho_Lap_KH.Columns.Contains("Stt_Rec_Ro"))
        str2 = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["Stt_Rec_Ro"]);
      if (Dt_Cho_Lap_KH.Columns.Contains("So_Ro"))
        _So_Ro = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["So_Ro"]);
      if (Dt_Cho_Lap_KH.Columns.Contains("Ma_Xe"))
        _Ma_Xe = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["Ma_Xe"]);

      DataSet ds = new DataSet(); //TODO: CP_RO_CVDV_DungSC_Save_KT
      if (ds.Tables[0].Rows.Count == 0)
        return;

      V_Load_DATA_KH_SCC("0", "", str1);
      V_Tao_Tien_Do_KH_SCC_Dung_SC((object)str2);
    }
    private void V_KH_SCC_Edit_Dung_SC()
    {
      int dataSourceRowIndex = Master_Cho_Lap_KHGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0 || !Dt_Cho_Lap_KH.Columns.Contains("Stt_Rec_Ro") | !Dt_Cho_Lap_KH.Columns.Contains("So_Ro"))
        return;

      string str1 = "";
      string str2 = "";
      string str3 = "";
      string str4 = "";
      if (Dt_Cho_Lap_KH.Columns.Contains("Stt_Rec_Ro"))
        str2 = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["Stt_Rec_Ro"]);
      if (Dt_Cho_Lap_KH.Columns.Contains("So_Ro"))
        str3 = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["So_Ro"]);
      if (Dt_Cho_Lap_KH.Columns.Contains("Ma_Xe"))
        str4 = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["Ma_Xe"]);

      DataSet dataSet = new DataSet(); //TODO: CP_RO_CVDV_DungSC_GetStt_Rec_KH
      if (dataSet.Tables.Count == 0)
        dataSet.Dispose();
      else if (dataSet.Tables[0].Rows.Count == 0)
        dataSet.Dispose();
      else
      {
        if (dataSet.Tables[0].Columns.Contains("Stt_Rec_Dung_SC"))
          str1 = Convert.ToString(dataSet.Tables[0].Rows[0]["Stt_Rec_Dung_SC"]);
        dataSet.Dispose();

        DataSet ds = new DataSet(); //TODO: show form
        if (str1 == "" || dataSet.Tables[0].Rows.Count == 0)
          return;

        V_Load_DATA_KH_SCC("0", "", str1);
      }
    }
    private void V_Preview_Cho_Lap_KH(object sender, EventArgs e)
    {
      int dataSourceRowIndex = Master_Cho_Lap_KHGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0 || !Dt_Cho_Lap_KH.Columns.Contains("Stt_Rec_Ro"))
        return;

      string _Stt_Rec = "";
      if (Dt_Cho_Lap_KH.Columns.Contains("Stt_Rec_Ro"))
        _Stt_Rec = Convert.ToString(Dv_Cho_Lap_KH[dataSourceRowIndex]["Stt_Rec_Ro"]);
      V_Preview(_Stt_Rec);
    }
    private void V_Preview(object sender, EventArgs e)
    {
      string _Stt_Rec = "";
      if (this.SchedulerControl_KH_SCC.SelectedAppointments.Count > 0)
        _Stt_Rec = this.SchedulerControl_KH_SCC.SelectedAppointments[0].Id.ToString();
      if (_Stt_Rec.Trim() == "")
        return;

      this.V_Preview(_Stt_Rec);
    }
    private void V_Preview(string _Stt_Rec)
    {
      if (_Stt_Rec.Trim() == "")
        return;
      // TODO: show form
    }
    private void V_Refresh_Cho_Lap_KH(object sender, EventArgs e) => V_LoadData_Cho_Lap_KH("0", "");
    private void V_ExportExcel_Cho_Lap_Kh(object sender, EventArgs e)
    {
    }
    private void V_Quay_Ra(object sender, EventArgs e)
    {
      // Save_OK = false;
      Close();
    }
    private void V_Tao_Sua_Tien_Do_KH_SCC( string _Mode, string _ma_Ct, string _Stt_rec, string _Stt_rec_RO, string _So_Ro, DateTime _Ngay_BD, DateTime _Ngay_KT, string _ma_khoang, string _Ma_CVDV, string _Ma_To, string _Ma_Xe, string _Ma_CD, string _Ma_KTV)
    {
      if (!V_ChkStt_Rec(_Stt_rec) || _ma_Ct.Trim() == "" || _Mode == "S" & !V_Chk_Righ(_Stt_rec, "SUA"))
        return;

      DataTable dataTable = (DataTable)null;
      string upper = _ma_Ct.ToString().Trim().ToUpper();
      if (upper == M_Ma_CT_PKH.ToString().Trim().ToUpper())
        dataTable = new DataTable(); // TODO
      else if (upper == M_Ma_CT_DLH.ToString().Trim().ToUpper())
        dataTable = new DataTable(); // TODO
      else if (upper == M_Ma_CT_PDC.ToString().Trim().ToUpper())
        dataTable = new DataTable(); // TODO

      if (dataTable == null || dataTable.Rows.Count == 0 || dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("Stt_Rec_Ro_Load") | !dataTable.Columns.Contains("Stt_Rec_Load"))
        return;

      string str1 = dataTable.Rows[0]["Stt_Rec_Ro_Load"].ToString().Trim();
      string str2 = dataTable.Rows[0]["Stt_Rec_Load"].ToString().Trim();

      V_Load_DATA_KH_SCC("0", str1, str2);

      //if (_ma_Ct.ToString().Trim().ToUpper() == M_Ma_CT_DLH.ToUpper().Trim() & Dt_Hen != null)
      //  V_LoadData_Hen("0", str2); // TODO

      if (_ma_Ct != M_Ma_CT_PKH.ToUpper().Trim() || M_Kieu_Xem == "HEN" || _ma_Ct.ToString().Trim().ToUpper() != M_Ma_CT_PKH)
        return;

      V_LoadData_Cho_Lap_KH("0", str1);
    }
    private bool V_ChkStt_Rec(string _Stt_rec) => (-(_Stt_rec.Trim().Substring(_Stt_rec.Trim().Length - 9, 9) == "_THUCHIEN" ? 1 : 0) | _Stt_rec.IndexOf("_FN")) == 0;
    private bool V_Chk_Righ(string _Stt_Rec, string _Loai)
    {
      bool flag = true;
      if (Dt_Right == null || Dt_Right.Rows.Count == 0 || Dt_Data_KH_SCC == null || _Stt_Rec.Trim() == "")
        return true;

      bool existsField1 = V_GetExistsField(Dt_Right, "Is_Admin");
      V_GetExistsField(Dt_Right, "Is_CS");
      V_GetExistsField(Dt_Right, "Is_CVDV");
      bool existsField2 = V_GetExistsField(Dt_Right, "Is_Controler");
      V_GetExistsField(Dt_Right, "Is_KTV");
      V_GetExistsField(Dt_Right, "Is_SCC");
      V_GetExistsField(Dt_Right, "Is_SDS");
      V_GetExistsField(Dt_Right, "Is_Hen");
      V_GetExistsField(Dt_Right, "Is_XN_SCC");
      V_GetExistsField(Dt_Right, "Is_XN_SDS");
      if (existsField1 || existsField2)
        return true;

      string Right = "";
      if (Dt_Right.Columns.Contains("Ma_HS"))
        Right = Dt_Right.Rows[0]["Ma_Hs"].ToString().Trim().ToUpper();
      _Stt_Rec = _Stt_Rec.Trim().Replace("_THUCHIEN", "");
      DataRow[] dataRowArray = Dt_Data_KH_SCC.Select("Stt_Rec = '" + _Stt_Rec.Trim() + "'");
      if (dataRowArray.Length == 0)
        return true;

      if (dataRowArray[0]["Ma_Hs"].ToString().Trim().ToUpper() == Right)
      {
        MessageBox.Show("Bạn không được phân quyền thay đổi lịch hẹn hoặc kế hoạch của User khác!");
        flag = false;
      }
      return flag;
    }
    public bool V_GetExistsField(DataTable _Dt_Right, string _Fieldname) => _Dt_Right.Columns.Contains(_Fieldname) && _Dt_Right.Rows[0][_Fieldname].ToString().Trim() == "1";
    private void V_Tao_Moi_SDSALL(string _Mode, string _ma_Ct, string _Stt_rec, string _Stt_rec_RO, string _So_Ro, DateTime _Ngay_BD, DateTime _Ngay_KT, string _ma_khoang, string _Ma_CVDV, string _Ma_To, string _Ma_Xe, string _Ma_CD, string _Ma_KTV)
    {
      if (!V_ChkStt_Rec(_Stt_rec) || _ma_Ct.Trim() == "")
        return;

      DataTable dataTable = new DataTable(); //TODO: open form (FrmCVDV_KH_SDSALL)
      if (dataTable == null || dataTable.Rows.Count == 0 || dataTable.Rows.Count == 0 || !dataTable.Columns.Contains("Stt_Rec_Ro_Load") | !dataTable.Columns.Contains("Stt_Rec_Load"))
        return;

      V_Load_DATA_KH_SCC("0", dataTable.Rows[0]["Stt_Rec_Ro_Load"].ToString().Trim(), dataTable.Rows[0]["Stt_Rec_Load"].ToString().Trim());
      if (_ma_Ct != M_Ma_CT_PKH.ToUpper().Trim() || M_Kieu_Xem == "HEN" || Dt_Cho_Lap_KH == null || !Dt_Cho_Lap_KH.Columns.Contains("Stt_Rec_Ro"))
        return;

      int num = checked(dataTable.Rows.Count - 1);
      int index1 = 0;
      while (index1 <= num)
      {
        int index2 = checked(Dt_Cho_Lap_KH.Rows.Count - 1);
        while (index2 >= 0)
        {
          if (Dt_Cho_Lap_KH.Rows[index2]["Stt_Rec_Ro"].ToString().Trim().ToUpper() == dataTable.Rows[index1]["Stt_Rec_Ro_Load"].ToString().ToUpper().Trim())
            Dt_Cho_Lap_KH.Rows[index2].Delete();

          checked { index2 += -1; }
        }
        Dt_Cho_Lap_KH.AcceptChanges();
        checked { ++index1; }
      }
    }
    private void V_Tao_Tien_Do_KH_SCC_Dung_SC(object _pStt_Rec_Ro)
    {
      if (!FormGlobals.Message_Confirm("Bạn có muốn tạo kế hoạch tiếp tục cho xe vừa được kết thúc dừng không?", false))
        return;

      string _Stt_Rec_Ro = "";
      string _Stt_rec = "";
      DateTime start = SchedulerControl_KH_SCC.SelectedInterval.Start;
      DateTime end = SchedulerControl_KH_SCC.SelectedInterval.End;
      string _So_Ro = "";
      string _ma_khoang = "";
      string _Ma_CVDV = "";
      string _Ma_To = "";
      string _Ma_Xe = "";
      string _Ma_CD = "";
      string _Ma_KTV = "";

      V_GetFromSetScheduler(ref start, ref end, ref _Stt_Rec_Ro, ref _So_Ro, ref _ma_khoang, ref _Ma_CVDV, ref _Ma_To, ref _Ma_Xe, ref _Ma_CD, ref _Ma_KTV);

      _Stt_Rec_Ro = Convert.ToString(_pStt_Rec_Ro);
      V_Tao_Sua_Tien_Do_KH_SCC("M", M_Ma_CT_PKH, _Stt_rec, _Stt_Rec_Ro, _So_Ro, start, end, _ma_khoang, _Ma_CVDV, _Ma_To, _Ma_Xe, _Ma_CD, _Ma_KTV);
    }
    private void V_GetFromSetScheduler(ref DateTime _Ngay_BD, ref DateTime _Ngay_KT, ref string _Stt_Rec_Ro, ref string _So_Ro, ref string _ma_khoang, ref string _Ma_CVDV, ref string _Ma_To, ref string _Ma_Xe, ref string _Ma_CD, ref string _Ma_KTV, Appointment _Appointment = null)
    {
      string str1 = CyberFunc.V_GetvalueCombox(CbbLoai_Xem_KH_SCC);
      _Ngay_BD = DateTime.Now.Date;
      _Ngay_KT = DateTime.Now.Date;
      _Stt_Rec_Ro = "";
      _So_Ro = "";
      _ma_khoang = "";
      _Ma_CVDV = "";
      _Ma_To = "";
      _Ma_Xe = "";
      _Ma_CD = "";
      _Ma_KTV = "";
      if (_Appointment == null)
      {
        _Ngay_BD = SchedulerControl_KH_SCC.SelectedInterval.Start;
        _Ngay_KT = SchedulerControl_KH_SCC.SelectedInterval.End;
      }
      else
      {
        _Ngay_BD = _Appointment.Start;
        _Ngay_KT = _Appointment.End;
      }
      string str2 = GetvalueSelectedResource(_Appointment);
      if (str2.ToUpper().Trim() == "DevExpress.XtraScheduler.EmptyResourceId".ToUpper().Trim())
        str2 = "";
      string str3 = str2.Replace("_THUCHIEN", "");
      string Left = str1;
      if (Left == "01")
        _ma_khoang = str3;
      else if (Left == "02")
        _Ma_CVDV = str3;
      else if (Left == "03")
        _Ma_To = str3;
      else if (Left == "04")
        _Ma_CD = str3;
      else if (Left == "05")
        _Stt_Rec_Ro = str3;
      else if (Left == "06")
        _Ma_KTV = str3;
      else
        _ma_khoang = str3;
    }
    private string GetvalueSelectedResource(Appointment _Appointment = null)
    {
      string str = "";
      try
      {
        str = _Appointment != null ? _Appointment.ResourceId.ToString() : SchedulerControl_KH_SCC.SelectedResource.Id.ToString().Trim().ToUpper().Trim();
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
    #endregion

    #region "Master_Sua_Xong_KHGRVPopupMenuShowing"
    private void V_Vi_Tri_Xe(object sender, EventArgs e)
    {
      if (!Dt_Sua_Xong_KH.Columns.Contains("Ma_Xe"))
        return;

      int dataSourceRowIndex = Master_Sua_Xong_KHGRV.GetFocusedDataSourceRowIndex();
      string _Ma_Xe = "";
      if (dataSourceRowIndex >= 0)
        _Ma_Xe = Convert.ToString(Dv_Sua_Xong_KH[dataSourceRowIndex]["Ma_Xe"]);

      DataTable Dt_Source = new DataTable(); //TODO: show form
      if (Dt_Source == null || Dt_Source.Rows.Count == 0)
        return;

      string str = Dt_Source.Rows[0]["Ma_Xe"].ToString().Trim();
      if (!Dt_Source.Columns.Contains("Ma_Xe") | !Dt_Source.Columns.Contains("Ma_Do"))
        return;

      if (Dt_Sua_Xong_KH.Rows.Count == 0) // TODO
        return;

      Dt_Sua_Xong_KH.AcceptChanges();
    }
    private void V_Vi_Tri_Xe_Load(object sender, EventArgs e)
    {
      if (!Dt_Sua_Xong_KH.Columns.Contains("Ma_Xe"))
        return;

      int dataSourceRowIndex = Master_Sua_Xong_KHGRV.GetFocusedDataSourceRowIndex();
      string _Ma_Xe = "";
      if (dataSourceRowIndex >= 0)
        _Ma_Xe = Convert.ToString(Dv_Sua_Xong_KH[dataSourceRowIndex]["Ma_Xe"]);

      V_Vi_Tri_Xe(_Ma_Xe);
    }
    private void V_Vi_Tri_Xe(string _Ma_Xe)
    {
    }
    private void V_Preview_Sua_Xong_KH(object sender, EventArgs e)
    {
      int dataSourceRowIndex = Master_Sua_Xong_KHGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0 || !Dt_Sua_Xong_KH.Columns.Contains("Stt_Rec_Ro"))
        return;

      string _Stt_Rec = "";
      if (Dt_Sua_Xong_KH.Columns.Contains("Stt_Rec_Ro"))
        _Stt_Rec = Convert.ToString(Dv_Sua_Xong_KH[dataSourceRowIndex]["Stt_Rec_Ro"]);

      V_Preview(_Stt_Rec);
    }
    #endregion

    #region "V_PopupMenu_KH_SCC"
    private void V_Tao_Tien_Do_KH_SCC(object sender, EventArgs e)
    {
      string _Stt_Rec_Ro = "";
      string _Stt_rec = "";
      DateTime start = this.SchedulerControl_KH_SCC.SelectedInterval.Start;
      DateTime end = this.SchedulerControl_KH_SCC.SelectedInterval.End;
      string _So_Ro = "";
      string _ma_khoang = "";
      string _Ma_CVDV = "";
      string _Ma_To = "";
      string _Ma_Xe = "";
      string _Ma_CD = "";
      string _Ma_KTV = "";
      this.V_GetFromSetScheduler(ref start, ref end, ref _Stt_Rec_Ro, ref _So_Ro, ref _ma_khoang, ref _Ma_CVDV, ref _Ma_To, ref _Ma_Xe, ref _Ma_CD, ref _Ma_KTV);
      if (_Stt_Rec_Ro == "" & this.M_Stt_Rec_Ro != "")
        _Stt_Rec_Ro = this.M_Stt_Rec_Ro;

      this.V_Tao_Sua_Tien_Do_KH_SCC("M", this.M_Ma_CT_PKH, _Stt_rec, _Stt_Rec_Ro, _So_Ro, start, end, _ma_khoang, _Ma_CVDV, _Ma_To, _Ma_Xe, _Ma_CD, _Ma_KTV);
    }
    private void V_Tao_KH_ALLS(object sender, EventArgs e)
    {
      string _Stt_Rec_Ro = "";
      string _Stt_rec = "";
      DateTime start = this.SchedulerControl_KH_SCC.SelectedInterval.Start;
      DateTime end = this.SchedulerControl_KH_SCC.SelectedInterval.End;
      string _So_Ro = "";
      string _ma_khoang = "";
      string _Ma_CVDV = "";
      string _Ma_To = "";
      string _Ma_Xe = "";
      string _Ma_CD = "";
      string maCtPkh = this.M_Ma_CT_PKH;
      string _Ma_KTV = "";

      this.V_GetFromSetScheduler(ref start, ref end, ref _Stt_Rec_Ro, ref _So_Ro, ref _ma_khoang, ref _Ma_CVDV, ref _Ma_To, ref _Ma_Xe, ref _Ma_CD, ref _Ma_KTV);
      
      if (maCtPkh.Trim() == "")
        return;

      this.V_Tao_Moi_SDSALL("M", this.M_Ma_CT_PKH, _Stt_rec, _Stt_Rec_Ro, _So_Ro, start, end, _ma_khoang, _Ma_CVDV, _Ma_To, _Ma_Xe, _Ma_CD, _Ma_KTV);
    }
    private void V_Hen_Call_KH_SCC(object sender, EventArgs e)
    {
      //TODO: open form (FrmCVDV_DLHen_Call)
    }
    private void V_KH_SCC_Chay_Thu(object sender, EventArgs e)
    {
      //TODO: open form (FrmCVDV_Chay_Thu)
    }
    private void V_KH_SCC_Chay_Thu_Stop(object sender, EventArgs e)
    {
      //TODO: CP_RO_CVDV_CHAY_THU_STOP
    }
    private void V_KH_SCC_BD_Dung_SC(object sender, EventArgs e)
    {
      string _Stt_rec = "";
      if (this.SchedulerControl_KH_SCC.SelectedAppointments.Count > 0)
        _Stt_rec = this.SchedulerControl_KH_SCC.SelectedAppointments[0].Id.ToString();
      if (_Stt_rec.Trim() == "" || !this.V_ChkStt_Rec(_Stt_rec))
        return;

      this.V_Set_Auto_Refresh(false);

      string str = _Stt_rec.Replace("_THUCHIEN", "");

      DataSet ds = new DataSet(); // TODO: open form (FrmCVDV_Dung_SC)
      bool flag = (ds.Tables[0].Rows.Count > 0);

      this.V_Set_Auto_Refresh(true);

      if (!flag)
        return;

      this.V_Load_DATA_KH_SCC("0", "", str);
    }
    private void V_Data_KH_SCC_KT_Dung_SC(object sender, EventArgs e)
    {
      string str1 = "";
      string str2 = "";
      string _So_Ro = "";
      string _Ma_Xe = "";
      if (this.SchedulerControl_KH_SCC.SelectedAppointments.Count > 0)
        str1 = this.SchedulerControl_KH_SCC.SelectedAppointments[0].Id.ToString();
      string str3 = str1.Replace("_THUCHIEN", "");
      if (str3.Trim() == "" || !this.V_ChkStt_Rec(str3))
        return;

      DataRow[] dataRowArray = this.Dt_Data_KH_SCC.Select("Stt_Rec = '" + str3.ToString().Trim() + "'");
      if (dataRowArray.Length <= 0)
        return;

      if (this.Dt_Data_KH_SCC.Columns.Contains("Stt_Rec_Ro"))
        str2 = Convert.ToString(dataRowArray[0]["Stt_Rec_Ro"]);
      if (this.Dt_Data_KH_SCC.Columns.Contains("So_Ro"))
        _So_Ro = Convert.ToString(dataRowArray[0]["So_Ro"]);
      if (this.Dt_Data_KH_SCC.Columns.Contains("Ma_Xe"))
        _Ma_Xe = Convert.ToString(dataRowArray[0]["Ma_Xe"]);

      DataSet ds = new DataSet(); //TODO: CP_RO_CVDV_DungSC_Save_KT
      if (!(ds.Tables[0].Rows.Count > 0))
        return;

      this.V_Load_DATA_KH_SCC("0", "", str3);
      this.V_Tao_Tien_Do_KH_SCC_Dung_SC((object)str2);
    }
    private void V_RO_PS(object sender, EventArgs e)
    {
      //TODO: open form
    }
    private void V_KH_SCC_QGate(object sender, EventArgs e)
    {
      string _Stt_rec = "";
      if (this.SchedulerControl_KH_SCC.SelectedAppointments.Count > 0)
        _Stt_rec = this.SchedulerControl_KH_SCC.SelectedAppointments[0].Id.ToString();
      if (_Stt_rec.Trim() == "" || !this.V_ChkStt_Rec(_Stt_rec))
        return;

      string str = _Stt_rec.Replace("_THUCHIEN", "");
      DataSet ds = new DataSet(); // TODO: open form (FrmCVDV_QGate)
      if (ds.Tables[0] == null)
        return;

      this.V_Load_DATA_KH_SCC("0", "", str);
    }
    private void V_KH_SCC_KCS_CD(object sender, EventArgs e)
    {
      string _Stt_rec = "";
      if (this.SchedulerControl_KH_SCC.SelectedAppointments.Count > 0)
        _Stt_rec = this.SchedulerControl_KH_SCC.SelectedAppointments[0].Id.ToString();
      if (_Stt_rec.Trim() == "" || !this.V_ChkStt_Rec(_Stt_rec))
        return;

      string str = _Stt_rec.Replace("_THUCHIEN", "");
      DataSet ds = new DataSet(); // TODO: open form (FrmCVDV_KCS_CD)
      if (ds.Tables[0] == null)
        return;

      this.V_Load_DATA_KH_SCC("0", "", str);
    }
    private void V_Chuyen_Tang(object sender, EventArgs e)
    {
      //TODO: open form (FrmChuyentang)
    }
    private void V_Tao_Lich_Hen_KH_SCC(object sender, EventArgs e)
    {
      string _Stt_Rec_Ro = "";
      string _Stt_rec = "";
      DateTime start = this.SchedulerControl_KH_SCC.SelectedInterval.Start;
      DateTime end = this.SchedulerControl_KH_SCC.SelectedInterval.End;
      string _So_Ro = "";
      string _ma_khoang = "";
      string _Ma_CVDV = "";
      string _Ma_To = "";
      string _Ma_Xe = "";
      string _Ma_CD = "";
      string _Ma_KTV = "";

      this.V_GetFromSetScheduler(ref start, ref end, ref _Stt_Rec_Ro, ref _So_Ro, ref _ma_khoang, ref _Ma_CVDV, ref _Ma_To, ref _Ma_Xe, ref _Ma_CD, ref _Ma_KTV);
      this.V_Tao_Sua_Tien_Do_KH_SCC("M", this.M_Ma_CT_DLH, _Stt_rec, _Stt_Rec_Ro, _So_Ro, start, end, _ma_khoang, _Ma_CVDV, _Ma_To, _Ma_Xe, _Ma_CD, _Ma_KTV);
    }
    private void V_Tao_Dat_CHo_KH_SCC(object sender, EventArgs e)
    {
      string _Stt_Rec_Ro = "";
      string _Stt_rec = "";
      DateTime start = this.SchedulerControl_KH_SCC.SelectedInterval.Start;
      DateTime end = this.SchedulerControl_KH_SCC.SelectedInterval.End;
      string _So_Ro = "";
      string _ma_khoang = "";
      string _Ma_CVDV = "";
      string _Ma_To = "";
      string _Ma_Xe = "";
      string _Ma_CD = "";
      string _Ma_KTV = "";

      this.V_GetFromSetScheduler(ref start, ref end, ref _Stt_Rec_Ro, ref _So_Ro, ref _ma_khoang, ref _Ma_CVDV, ref _Ma_To, ref _Ma_Xe, ref _Ma_CD, ref _Ma_KTV);
      this.V_Tao_Sua_Tien_Do_KH_SCC("M", this.M_Ma_CT_PDC, _Stt_rec, _Stt_Rec_Ro, _So_Ro, start, end, _ma_khoang, _Ma_CVDV, _Ma_To, _Ma_Xe, _Ma_CD, _Ma_KTV);
    }
    private void V_Xoa_KH_SCC(object sender, EventArgs e)
    {
      string _Stt_rec = "";
      if (this.SchedulerControl_KH_SCC.SelectedAppointments.Count > 0)
        _Stt_rec = this.SchedulerControl_KH_SCC.SelectedAppointments[0].Id.ToString();
      if (_Stt_rec.Trim() == "" || !this.V_ChkStt_Rec(_Stt_rec))
        return;

      DataSet dataSet = new DataSet(); // TODO: CP_RO_CVDV_KH_SCC_Delete
      if (dataSet.Tables[0] == null)
        dataSet.Dispose();
      else
      {
        int recordIndex = checked(this.Dv_Data_KH_SCC.Count - 1);
        while (recordIndex >= 0)
        {
          if (this.Dv_Data_KH_SCC[recordIndex]["Stt_Rec"].ToString().Trim().ToUpper() == _Stt_rec.Trim().ToString().ToUpper())
          {
            this.Dv_Data_KH_SCC[recordIndex].Delete();
            break;
          }
          checked { recordIndex += -1; }
        }
        this.Dt_Data_KH_SCC.AcceptChanges();
        dataSet.Dispose();
      }
    }
    private void V_XN_BD_SCC(object sender, EventArgs e)
    {
      string str = "";
      if (this.SchedulerControl_KH_SCC.SelectedAppointments.Count > 0)
        str = this.SchedulerControl_KH_SCC.SelectedAppointments[0].Id.ToString();
      
      if (str.Trim() == "" || !this.V_ChkStt_Rec(str) || !FormGlobals.Message_Confirm("Bạn có xác nhận bắt đầu không?", false))
        return;

      DataSet dataSet = new DataSet(); // TODO: CP_SysExecute
      string _StrKTV = "";
      int num1 = checked(dataSet.Tables[0].Rows.Count - 1);
      int index = 0;
      while (index <= num1)
      {
        _StrKTV = _StrKTV + ";INSERT DMKTVCYBER SELECT N'" + dataSet.Tables[0].Rows[index]["ma_HS"].ToString().Trim() + "'";
        checked { ++index; }
      }
      dataSet.Dispose();

      if (_StrKTV.Trim() == "")
        MessageBox.Show("Không tồn tại KTV");
      else
      {
        DataSet ds = new DataSet(); // TODO: CP_RO_CVDV_KH_SCC_XN_BD_KT
        if (ds.Tables[0] == null)
          return;

        this.V_Load_DATA_KH_SCC("0", "", str);
      }
    }
    private void V_XN_KT_SCC(object sender, EventArgs e)
    {
      string str = "";
      if (this.SchedulerControl_KH_SCC.SelectedAppointments.Count > 0)
        str = this.SchedulerControl_KH_SCC.SelectedAppointments[0].Id.ToString();
      
      if (str.Trim() == "" || !this.V_ChkStt_Rec(str) || !FormGlobals.Message_Confirm("Bạn có xác nhận kết thúc không?", false))
        return;

      DataSet dataSet = new DataSet(); // TODO: CP_SysExecute
      string _StrKTV = "";
      int num1 = checked(dataSet.Tables[0].Rows.Count - 1);
      int index = 0;
      while (index <= num1)
      {
        _StrKTV = _StrKTV + ";INSERT DMKTVCYBER SELECT N'" + dataSet.Tables[0].Rows[index]["ma_HS"].ToString().Trim() + "'";
        checked { ++index; }
      }
      dataSet.Dispose();

      if (_StrKTV.Trim() == "")
        MessageBox.Show("Không tồn tại KTV");
      else
      {
        DataSet ds = new DataSet(); // TODO: CP_RO_CVDV_KH_SCC_XN_BD_KT
        if (ds.Tables[0] == null)
          return;

        this.V_Load_DATA_KH_SCC("0", "", str);
      }
    }
    private void V_XN_BD_KT_KTV(object sender, EventArgs e)
    {
      string str = "";
      if (this.SchedulerControl_KH_SCC.SelectedAppointments.Count > 0)
        str = this.SchedulerControl_KH_SCC.SelectedAppointments[0].Id.ToString();
      if (str.Trim() == "" || !this.V_ChkStt_Rec(str))
        return;

      // TODO: open form (FrmCVDV_XN_TGSC)
    }
    private void V_Lock_Khoang_Data(object sender, EventArgs e)
    {
      //TODO: open form (FrmCVDV_Lock_Detail)
    }
    private void V_Refresh_Load_Default(object sender, EventArgs e)
    {
      CyberFunc.V_FillComBoxDefaul(this.CbbGio_Xem, this.Dt_Xem_Gio, "Gio_Xem", "Ten");
      this.V_Gio_Xem(sender, e);
    }
    #endregion

    private void V_Set_Auto_Refresh(bool _b)
    {
      if (!ChkAuto_Data_KH_SCC.Checked)
        _b = false;
      if (_b)
        Timer_Data_hen.Start();
      else
        Timer_Data_hen.Stop();
    }
  }
}