using DevExpress.Services;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
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
      this.Text = "BẢNG THEO DÕI SỬA CHỮA";
      this.V_SetTree();
      IMouseHandlerService service = (IMouseHandlerService)this.SchedulerControl_KH_SCC.GetService(typeof(IMouseHandlerService));
      if (service != null)
      {
        CyberBarSubMenuPopup.CustomMouseHandlerService serviceInstance = new CyberBarSubMenuPopup.CustomMouseHandlerService((System.IServiceProvider)this.SchedulerControl_KH_SCC, service);
        this.SchedulerControl_KH_SCC.RemoveService(typeof(IMouseHandlerService));
        this.SchedulerControl_KH_SCC.AddService(typeof(IMouseHandlerService), (object)serviceInstance);
      }
      this.SchedulerControl_KH_SCC.MouseWheel += new MouseEventHandler(this.V_SchedulerControl_KH_SCC_MouseWheel);
      this.V_GetKieu_Xem_Loai_SC();
      this.LabLock.Visible = (this.M_Kieu_Xem.Trim().ToUpper() != "HEN");
      this.TxtM_Ngay_Ct_KH_SCC.EditValue = DateTime.Today.Date;

      this.V_LoadTabVisible();
      this.V_CreateTimeALl();

      if (this._TabVisible3)
        this.V_Load_System_KH_SC();
      if (this._TabVisible8)
        this.V_Load_System_HonHop();
      if (this._TabVisible9)
        this.V_Load_System_Dung();

      this.V_LoadHonHop_Dung_ChayTHU();

      this.TabCVDV.DrawMode = TabDrawMode.OwnerDrawFixed;
      this.TabCVDV.Padding = new Point(20, 6);
      this.TabCVDV.DrawItem += new DrawItemEventHandler(this.V_DrawItem);
    }

    #region "frmCW_Load"
    private void V_SetTree()
    {
      this.ResourcesTree1.VertScrollVisibility = ScrollVisibility.Never;
      this.ResourcesTree1.OptionsView.ShowIndicator = false;
      this.ResourcesTree1.OptionsView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
      this.ResourcesTree1.TreeLineStyle = LineStyle.None;
      this.ResourcesTree1.TreeLevelWidth = 0;
      this.ResourcesTree1.OptionsView.ShowHorzLines = true;
      this.ResourcesTree1.Visible = false;
      this.ResourcesTree1.OptionsSelection.MultiSelect = true;
      this.SplitContainer_Tien_Do.SplitterDistance = 0;
    }
    private void V_SchedulerControl_KH_SCC_MouseWheel(object sender, MouseEventArgs e)
    {
      int visibleResourceIndex = this.SchedulerControl_KH_SCC.ActiveView.FirstVisibleResourceIndex;
      if (e.Delta > 0 && visibleResourceIndex != 0)
        checked { --this.SchedulerControl_KH_SCC.ActiveView.FirstVisibleResourceIndex; }
      if (e.Delta >= 0 || visibleResourceIndex == checked(this.SchedulerControl_KH_SCC.Storage.Resources.Count - 1))
        return;

      checked { ++this.SchedulerControl_KH_SCC.ActiveView.FirstVisibleResourceIndex; }
    }
    private void V_GetKieu_Xem_Loai_SC()
    {
      this.M_Loai_SC = "1";
      this.M_Kieu_Xem = "TIEN_DO";
      this.M_Stt_Rec_Ro = "";
    }
    private void V_LoadTabVisible()
    {
      DataSet dataSet = new DataSet(); // CP_RO_CVDV_Config
      this.dt_configTab = dataSet.Tables[0].Copy();
      int num = checked(dataSet.Tables[0].Rows.Count - 1);
      int index1 = 0;
      while (index1 <= num)
      {
        int index2 = checked(this.TabCVDV.TabPages.Count - 1);
        while (index2 >= 0)
        {
          if (this.TabCVDV.TabPages[index2].Name.ToString().ToUpper().Trim() == dataSet.Tables[0].Rows[index1]["Tab_Name"].ToString().ToUpper().Trim())
          {
            this.TabCVDV.TabPages[index2].Text =  dataSet.Tables[0].Rows[index1]["Tab_Caption"].ToString();
            if (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() != "1")
            {
              this.TabCVDV.TabPages.Remove(this.TabCVDV.TabPages[index2]);
              break;
            }
            break;
          }
          checked { index2 += -1; }
        }

        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)1)
          this._TabVisible1 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)2)
          this._TabVisible2 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)3)
          this._TabVisible3 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)4)
          this._TabVisible4 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)5)
          this._TabVisible5 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)6)
          this._TabVisible6 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)7)
          this._TabVisible7 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)8)
          this._TabVisible8 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)9)
          this._TabVisible9 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)10)
          this._TabVisible10 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        if (dataSet.Tables[0].Rows[index1]["Stt"] == (object)11)
          this._TabVisible11 = (dataSet.Tables[0].Rows[index1]["Is_Visible"].ToString().Trim() == "1");
        checked { ++index1; }
      }
      if (dataSet.Tables.Count > 1)
        this.Dt_Right = dataSet.Tables[1].Copy();

      dataSet.Dispose();
    }
    private void V_CreateTimeALl()
    {
      DataTable dataTable = this.CreateTime().Copy();
      if (this._TabVisible3)
        this.Dt_Time_KH_SCC = dataTable.Copy();
      if (this._TabVisible8)
        this.Dt_Time_Honhop = dataTable.Copy();
      if (this._TabVisible9)
        this.Dt_Time_Dung = dataTable.Copy();
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
      this.Timer_Data_KH_SCC.Stop();
      this.Timer_Data_KH_SCC.Enabled = flag;
      this.CbbTime_Data_KH_SCC.Enabled = flag;

      if (this.Dt_Time_KH_SCC == null)
        this.Dt_Time_KH_SCC = this.CreateTime().Copy();

      CyberFunc.V_FillComBoxDefaul(this.CbbTime_Data_KH_SCC, this.Dt_Time_KH_SCC, "TG", "Ten_TG");
      this.V_Load_KH_SCC("1");

      if (!flag)
        this.Timer_Data_KH_SCC.Stop();
      else
        this.Timer_Data_KH_SCC.Start();
    }
    private void V_Load_System_HonHop()
    {
      //bool flag = false;
      //this.Timer_Data_honHop.Stop();
      //this.Timer_Data_honHop.Enabled = flag;
      //this.CbbTime_Data_HonHop.Enabled = flag;
      //this.V_Load_System_CVDV(ref this.Dt_CVDV_HonHop);
      //if (this.Dt_Time_Honhop == null)
      //  this.Dt_Time_Honhop = this.CreateTime().Copy();
      //this.V_LoadData_HonHop("1");
      //this.V_Fill_HonHop();
      //this.V_AddHander_HonHop();
      //this.Master_HonHopGRV.ColumnPanelRowHeight = 30;
    }
    private void V_Load_System_Dung()
    {
      //bool flag = false;
      //this.Timer_Data_Dung.Stop();
      //this.Timer_Data_Dung.Enabled = flag;
      //this.CbbTime_Data_Dung.Enabled = flag;
      //this.V_Load_System_CVDV(ref this.Dt_CVDV_Dung);
      //if (this.Dt_Time_Dung == null)
      //  this.Dt_Time_Dung = this.CreateTime().Copy();
      //this.V_LoadData_Dung("1");
      //this.V_Fill_Dung();
      //this.V_AddHander_Dung();
      //this.Master_DungGRV.ColumnPanelRowHeight = 30;
    }
    private void V_LoadHonHop_Dung_ChayTHU()
    {
      //this.CmdHonHop.Visible = this._TabVisible8;
      //this.CmdDung.Visible = this._TabVisible9;
      //this.CmdHonHop.Click -= new EventHandler(this.V_HonHop);
      //this.CmdDung.Click -= new EventHandler(this.V_Dung);
      //this.CmdHonHop.Click += new EventHandler(this.V_HonHop);
      //this.CmdDung.Click += new EventHandler(this.V_Dung);
      //this.V_SetCaptionSo_Xe(this.Dt_HonHop, this.CmdHonHop);
      //this.V_SetCaptionSo_Xe(this.Dt_Dung, this.CmdDung);
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
        Font font = new Font(this.TabCVDV.Font.FontFamily, (sender as Font).Size, FontStyle.Bold);
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
        this.V_GetTimeChangeLoai_SC();

      this.V_Visible_KH_SCC();
      this.TxtM_Ngay_Ct_KH_SCC.EditValue = DateTime.Today.Date;
      this.V_LoadDatabas_Ngam_Dinh_KH_SCC();
      this.V_CyberSetTime_KH_SCC();
      this.V_Load_DATA_KH_SCC("1", "", "");
      this.V_AddHander_KH_SCC();
      this.V_SetSchedulerControl_KH_SCC();
      this.V_SetRowHeight_KH_SCC();
      this.V_Auto_Data_KH_SCC(new object(), new EventArgs());
      this.V_Buoc_Nhay_KH_SCC(new object(), new EventArgs());
      this.V_Load_Cho_Lap_KH();
      this.Master_Cho_Lap_KHGRV.ColumnPanelRowHeight = 20;
      this.V_Lock_Xem();
      this.V_LoadTimeLine();
      this.V_AddHanderLabel_KH_SCC();
      this.V_GetHieghtSplitContainerKH_SC();
    }
    private void V_GetTimeChangeLoai_SC()
    {
      bool flag = false;
      this.Timer_Data_KH_SCC.Stop();
      this.Timer_Data_KH_SCC.Enabled = flag;
      this.CbbTime_Data_KH_SCC.Enabled = flag;
      this.M_Loai_KH_SCC = this.M_Loai_SC;
    }
    private void V_Visible_KH_SCC()
    {
      string str = "TIẾN ĐỘ SỬA CHỮA CHUNG";
      if (this.M_Loai_KH_SCC.Trim() == "2")
        str = "TIẾN ĐỘ SỬA ĐỒNG SƠN";
      if (this.M_Kieu_Xem.Trim().Trim() == "HEN")
        str = "LỊCH HẸN SỬA ";

      if (this.M_Kieu_Xem.Trim().Trim() == "HEN" | this.M_Loai_KH_SCC.Trim() == "2")
        this.SplitContainer2.SplitterDistance = 1;

      this.Tab3.Text = str;

      if (this.M_Kieu_Xem == "HEN")
        this.CmdUp_TG_GX_KH_SCC.Visible = false;
      else
        this.CmdUp_TG_GX_KH_SCC.Visible = true;
    }
    private void V_LoadDatabas_Ngam_Dinh_KH_SCC()
    {
      DataSet dataSet = new DataSet(); // CP_RO_CVDV_KH_SCC_Ngam_Dinh"

      this.Dt_ConFigColor_KH_SCC = dataSet.Tables[0].Copy();
      this.Dt_Set_SCC = dataSet.Tables[1].Copy();
      this.Dt_Buoc_Nhay_KH_SCC = dataSet.Tables[2].Copy();
      this.Dt_Do_Rong_KH_SCC = dataSet.Tables[3].Copy();
      this.DmCVDV_Loc_KH_SCC = dataSet.Tables[4].Copy();
      this.DmCVDV_KH_SCC = this.DmCVDV_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(this.DmCVDV_KH_SCC, "Ma_HS");
      this.Dv_DmCVDV_KH_SCC = new DataView(this.DmCVDV_KH_SCC);

      this.DmCVDV_KH_SCC_H = dataSet.Tables[5].Copy();
      this.DmKhoang_Loc_KH_SCC = dataSet.Tables[6].Copy();
      this.DmKhoang_KH_SCC = this.DmKhoang_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(this.DmKhoang_KH_SCC, "Ma_khoang");
      this.Dv_DmKhoang_KH_SCC = new DataView(this.DmKhoang_KH_SCC);

      this.DmKhoang_KH_SCC_H = dataSet.Tables[7].Copy();
      this.DmTo_Loc_KH_SCC = dataSet.Tables[8].Copy();
      this.DmTo_KH_SCC = this.DmTo_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(this.DmTo_KH_SCC, "Ma_TO");
      this.Dv_DmTo_KH_SCC = new DataView(this.DmTo_KH_SCC);

      this.DmTo_KH_SCC_H = dataSet.Tables[9].Copy();
      this.DmKTV_Loc_KH_SCC = dataSet.Tables[10].Copy();
      this.DmKTV_KH_SCC = this.DmKTV_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(this.DmKTV_KH_SCC, "Ma_HS");
      this.Dv_DmKTV_KH_SCC = new DataView(this.DmKTV_KH_SCC);

      this.DmKTV_KH_SCC_H = dataSet.Tables[11].Copy();
      this.Dt_Data_KTV_KH_SCC = dataSet.Tables[12].Copy();
      this.Dv_Data_KTV_KH_SCC = new DataView(this.Dt_Data_KTV_KH_SCC);
      this.DmCd_Loc_KH_SCC = dataSet.Tables[13].Copy();
      this.DmCd_KH_SCC = this.DmCd_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(this.DmCd_KH_SCC, "Ma_CD");
      this.Dv_DmCd_KH_SCC = new DataView(this.DmCd_KH_SCC);

      this.DmCd_KH_SCC_H = dataSet.Tables[14].Copy();
      this.DmLoai_Xem_Loc_KH_SCC = dataSet.Tables[15].Copy();
      this.DmLoai_Xem_KH_SCC = this.DmLoai_Xem_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(this.DmLoai_Xem_KH_SCC, "Loai");
      this.Dv_DmLoai_Xem_KH_SCC = new DataView(this.DmLoai_Xem_KH_SCC);

      this.DmMucSBD_Loc_KH_SCC = dataSet.Tables[16].Copy();
      this.DmMucSBD_KH_SCC = this.DmMucSBD_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(this.DmMucSBD_KH_SCC, "Muc_SBD");
      this.Dv_DmMucSBD_KH_SCC = new DataView(this.DmMucSBD_KH_SCC);

      this.DmMucSDS_Loc_KH_SCC = dataSet.Tables[17].Copy();
      this.DmMucSDS_KH_SCC = this.DmMucSDS_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(this.DmMucSDS_KH_SCC, "Muc_SDS");
      this.Dv_DmMucSDS_KH_SCC = new DataView(this.DmMucSDS_KH_SCC);

      this.DmTang_Loc_KH_SCC = dataSet.Tables[19].Copy();
      this.DmTang_KH_SCC = this.DmTang_Loc_KH_SCC.Copy();
      CyberFunc.V_DeleteRowEmpty(this.DmTang_KH_SCC, "Tang");
      this.Dv_DmTang_KH_SCC = new DataView(this.DmTang_KH_SCC);

      this.DmDungSC = dataSet.Tables[19].Copy();

      if (dataSet.Tables.Count > 20)
        this.Dt_Khoang_H = dataSet.Tables[20].Copy();

      if (dataSet.Tables.Count > 21)
        this.Dt_Xe_H = dataSet.Tables[21].Copy();

      this.Fill_Cbb(1);

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
      this.Dt_Xem_Gio = new DataTable()
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

      CyberFunc.V_FillComBoxDefaul(this.CbbGio_Xem, this.Dt_Xem_Gio, "Gio_Xem", "Ten");
    }
    private void Fill_Cbb(int _All)
    {
      CyberFunc.V_FillComBoxDefaul(this.CbbCVDV_KH_SCC, this.DmCVDV_Loc_KH_SCC, "Ma_Hs", "Ten_Hs", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(this.CbbKhoang_KH_SCC, this.DmKhoang_Loc_KH_SCC, "Ma_Khoang", "Ten_Khoang", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(this.CbbTo_KH_SCC, this.DmTo_Loc_KH_SCC, "Ma_To", "Ten_To", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(this.CbbMuc_SDS_KH_SCC, this.DmCd_Loc_KH_SCC, "Ma_CD", "Ten_CD", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(this.CbbMuc_SBD_KH_SCC, this.DmMucSBD_Loc_KH_SCC, "Muc_SBD", "ten_SBD", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(this.CbbMuc_SDS_KH_SCC, this.DmMucSDS_Loc_KH_SCC, "Muc_SDS", "ten_SDS", "Ngam_Dinh");
      
      if (_All != 1)
        return;
      
      CyberFunc.V_FillComBoxDefaul(this.CbbLoai_Xem_KH_SCC, this.DmLoai_Xem_Loc_KH_SCC, "Loai", "Ten_Loai", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(this.CbbTang_KH_SCC, this.DmTang_Loc_KH_SCC, "Tang", "Ten_Tang", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(this.CbbMa_BN_KH_SCC, this.Dt_Buoc_Nhay_KH_SCC, "Ma_BN", "Ten_BN", "Ngam_Dinh");
      CyberFunc.V_FillComBoxDefaul(this.CbbDo_Rong_KH_SCC, this.Dt_Do_Rong_KH_SCC, "Ma_Width", "Ten_Width", "Ngam_Dinh");
    }
    private void V_CyberSetTime_KH_SCC()
    {
      Decimal num1 = new Decimal(this.M_StartHour);
      Decimal num2 = new Decimal(this.M_StartMINUTE);
      Decimal num3 = new Decimal(this.M_FinishHour);
      Decimal num4 = new Decimal(this.M_FinishMINUTE);

      if (this.SchedulerControl_KH_SCC.ActiveViewType == SchedulerViewType.Gantt)
      {
        TimeScaleCollection scales = this.SchedulerControl_KH_SCC.GanttView.Scales;
        scales.BeginUpdate();
        try
        {
          scales.Clear();
          TimeScaleLessThanDay scaleLessThanDay1 = new TimeScaleLessThanDay(TimeSpan.FromHours(1.0), this.M_StartHour, this.M_FinishHour, this.M_Ngay_LimitInterval_Min, this.M_Ngay_LimitInterval_Max, this.M_Thu_Bay, this.M_Chu_Nhat);
          TimeScaleLessThanDay scaleLessThanDay2 = new TimeScaleLessThanDay(TimeSpan.FromMinutes(Convert.ToDouble(CyberFunc.V_GetvalueCombox(this.CbbMa_BN_KH_SCC))), this.M_StartHour, this.M_FinishHour, this.M_Ngay_LimitInterval_Min, this.M_Ngay_LimitInterval_Max, this.M_Thu_Bay, this.M_Chu_Nhat);
          scales.Add((TimeScale)new TimeScaleYear());
          scales.Add((TimeScale)new TimeScaleQuarter());
          scales.Add((TimeScale)new TimeScaleMonth());
          scales.Add((TimeScale)new TimeScaleWeek());
          scales.Add((TimeScale)new CyberTimeScaleDay(this.M_StartHour, this.M_FinishHour, this.M_Ngay_LimitInterval_Min, this.M_Ngay_LimitInterval_Max));
          scales.Add((TimeScale)scaleLessThanDay1);
          scales.Add((TimeScale)scaleLessThanDay2);
        }
        finally
        {
          this.SchedulerControl_KH_SCC.GanttView.Scales[0].Visible = false;
          this.SchedulerControl_KH_SCC.GanttView.Scales[1].Visible = false;
          this.SchedulerControl_KH_SCC.GanttView.Scales[2].Visible = false;
          this.SchedulerControl_KH_SCC.GanttView.Scales[3].Visible = false;
          this.SchedulerControl_KH_SCC.GanttView.Scales[4].Visible = true;
          this.SchedulerControl_KH_SCC.GanttView.Scales[5].Visible = true;
          this.SchedulerControl_KH_SCC.Views.GanttView.Scales[6].DisplayFormat = "mm";
          if (this.CbbMa_BN_KH_SCC.SelectedValue == (object)60)
            this.SchedulerControl_KH_SCC.GanttView.Scales[6].Visible = false;
          else
            this.SchedulerControl_KH_SCC.GanttView.Scales[6].Visible = true;
          scales.EndUpdate();
        }
      }
      else
      {
        if (this.SchedulerControl_KH_SCC.ActiveViewType != SchedulerViewType.Day)
          return;

        this.SchedulerControl_KH_SCC.Views.DayView.ShowWorkTimeOnly = true;
        TimeSpan timeSpan1 = new TimeSpan(Convert.ToInt32(num1), Convert.ToInt32(num2), 0);
        TimeSpan timeSpan2 = new TimeSpan(Convert.ToInt32(num3), Convert.ToInt32(num4), 0);
        this.SchedulerControl_KH_SCC.Views.DayView.WorkTime.End = new TimeSpan(this.M_FinishHour, this.M_FinishMINUTE, 0);
        this.SchedulerControl_KH_SCC.Views.DayView.WorkTime.Start = timeSpan1;
        this.SchedulerControl_KH_SCC.Views.DayView.WorkTime.End = timeSpan2;
        this.SchedulerControl_KH_SCC.Views.DayView.TimeScale = TimeSpan.FromMinutes(Convert.ToDouble(CyberFunc.V_GetvalueCombox(this.CbbMa_BN_KH_SCC)));
      }
    }
    public void V_Load_DATA_KH_SCC(string status, string _Stt_Rec_Ro_Load, string _Stt_Rec_Load)
    {
      this.SchedulerStorage_KH_SCC.Appointments.AutoReload = false;
      this.SchedulerControl_KH_SCC.BeginUpdate();
      string upper = CyberFunc.V_GetvalueCombox(this.CbbLoai_Xem_KH_SCC).ToString().Trim().ToUpper();
      DateTime date = Convert.ToDateTime(this.TxtM_Ngay_Ct_KH_SCC.EditValue);

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
        this.LabTotal.Text = "";
        this.Dt_Data_KH_SCC = (DataTable)null;
        this.Dt_Data_Xe_KH_SCC = (DataTable)null;
        this.Dt_Data_Parent_KH_SCC = (DataTable)null;
        if (dataSet.Tables.Count > 0)
        {
          this.Dt_Data_KH_SCC = dataSet.Tables[0].Copy();
          this.Dv_Data_KH_SCC = new DataView(this.Dt_Data_KH_SCC);
        }
        if (dataSet.Tables.Count > 1)
        {
          this.Dt_Data_Xe_KH_SCC = dataSet.Tables[1].Copy();
          this.Dv_Data_Xe_KH_SCC = new DataView(this.Dt_Data_Xe_KH_SCC);
        }
        if (dataSet.Tables.Count > 2)
        {
          this.Dt_Data_Parent_KH_SCC = dataSet.Tables[2].Copy();
          this.Dv_Data_Parent_KH_SCC = new DataView(this.Dt_Data_Parent_KH_SCC);
        }
        this._BackColor_Data_KH_SCC = this.Dt_Data_KH_SCC.Columns.Contains("BackColor");
        this._BackColor2_Data_KH_SCC = this.Dt_Data_KH_SCC.Columns.Contains("BackColor2");
        this._ForeColor_Data_KH_SCC = this.Dt_Data_KH_SCC.Columns.Contains("ForeColor");
        this._BorderColor_Data_KH_SCC = this.Dt_Data_KH_SCC.Columns.Contains("BorderColor");
        this._Bold_Data_KH_SCC = this.Dt_Data_KH_SCC.Columns.Contains("Bold");
        this._Underline_KH_SCC = this.Dt_Data_KH_SCC.Columns.Contains("Underline");
        if (this._BackColor_Data_KH_SCC)
          this._BackColorField_Data_KH_SCC = this.Dt_Data_KH_SCC.Columns["BackColor"].ColumnName;
        if (this._BackColor2_Data_KH_SCC)
          this._BackColorField2_Data_KH_SCC = this.Dt_Data_KH_SCC.Columns["BackColor2"].ColumnName;
        if (this._ForeColor_Data_KH_SCC)
          this._ForeColorField_Data_KH_SCC = this.Dt_Data_KH_SCC.Columns["ForeColor"].ColumnName;
        if (this._BorderColor_Data_KH_SCC)
          this._BorderColorField_Data_KH_SCC = this.Dt_Data_KH_SCC.Columns["BorderColor"].ColumnName;
        if (this._Bold_Data_KH_SCC)
          this._BoldField_Data_KH_SCC = this.Dt_Data_KH_SCC.Columns["Bold"].ColumnName;
        if (this._Underline_KH_SCC)
          this._UnderlineField_KH_SCC = this.Dt_Data_KH_SCC.Columns["Underline"].ColumnName;
      }
      else if (_Stt_Rec_Ro_Load.Trim() == "" & _Stt_Rec_Load.Trim() == "")
      {
        this.Dt_Data_KH_SCC.Clear();
        this.Dt_Data_KH_SCC.Load((IDataReader)dataSet.Tables[0].CreateDataReader());
        if (dataSet.Tables.Count > 1 & this.Dt_Data_Xe_KH_SCC != null)
        {
          this.Dt_Data_Xe_KH_SCC.Clear();
          this.Dt_Data_Xe_KH_SCC.Load((IDataReader)dataSet.Tables[1].CreateDataReader());
        }
        if (dataSet.Tables.Count > 2 & this.Dt_Data_Parent_KH_SCC != null)
        {
          this.Dt_Data_Parent_KH_SCC.Clear();
          this.Dt_Data_Parent_KH_SCC.Load((IDataReader)dataSet.Tables[2].CreateDataReader());
        }
      }
      else
      {
        if (dataSet.Tables.Count > 0 & this.Dt_Data_KH_SCC != null)
        {
          this.V_Delete_KH_SCC_DATA(this.Dt_Data_KH_SCC, _Stt_Rec_Ro_Load, _Stt_Rec_Load);
          this.Dt_Data_KH_SCC.Load((IDataReader)dataSet.Tables[0].CreateDataReader());
        }
        if (dataSet.Tables.Count > 1 & this.Dt_Data_Xe_KH_SCC != null)
        {
          DataTable table = dataSet.Tables[1];
          this.V_UpdateAndInsertDataxe(ref table);
        }
      }
      dataSet.Dispose();

      this.V_Update_Ten3();
      this.V_Dang_Sua_Chua((object)"");
      this.SchedulerControl_KH_SCC.EndUpdate();

      this.V_Filter_KH_SCC(new object(), new EventArgs());
      this.SchedulerControl_KH_SCC.Storage.RefreshData();
      this.SchedulerStorage_KH_SCC.Appointments.AutoReload = true;

      if (status == "0")
        this.V_Lock_Xem();

      this.V_start_Flass(status);
    }
    private void V_AddHander_KH_SCC()
    {

    }
    private void V_SetSchedulerControl_KH_SCC()
    {
      this.SchedulerControl_KH_SCC.DateNavigationBar.Visible = false;
      this.SchedulerControl_KH_SCC.ActiveViewType = SchedulerViewType.Gantt;
      this.SchedulerControl_KH_SCC.Views.GanttView.Scales[6].Width = Convert.ToInt32(this.Dt_Set_SCC.Rows[0]["HourWidth"]);
      this.SchedulerControl_KH_SCC.Views.GanttView.ResourcesPerPage = Convert.ToInt32(this.Dt_Set_SCC.Rows[0]["RowPage"]);
      this.SchedulerControl_KH_SCC.GroupType = SchedulerGroupType.Resource;

      this.V_SetSchedulerSetValue();
      this.V_SetColorAppointments();

      if (this.DmKhoang_KH_SCC.Columns.Contains("Color"))
        this.SchedulerStorage_KH_SCC.Resources.Mappings.Color = this.DmKhoang_KH_SCC.Columns["Color"].ColumnName.ToString().Trim();
      if (this.DmKhoang_KH_SCC.Columns.Contains("Image"))
        this.SchedulerStorage_KH_SCC.Resources.Mappings.Image = this.DmKhoang_KH_SCC.Columns["Image"].ColumnName.ToString().Trim();

      this.SchedulerStorage_KH_SCC.Appointments.DataSource = (object)this.Dv_Data_KH_SCC;
      this.SchedulerStorage_KH_SCC.Appointments.Mappings.AllDay = "AllDay";
      this.SchedulerStorage_KH_SCC.Appointments.Mappings.AppointmentId = this.Dt_Data_KH_SCC.Columns["Stt_Rec"].ColumnName;

      if (this.Dt_Data_KH_SCC.Columns.Contains("Dien_Giai"))
        this.SchedulerStorage_KH_SCC.Appointments.Mappings.Description = this.Dt_Data_KH_SCC.Columns["Dien_Giai"].ColumnName;

      this.SchedulerStorage_KH_SCC.Appointments.Mappings.Start = this.Dt_Data_KH_SCC.Columns["Ngay_BD"].ColumnName;
      this.SchedulerStorage_KH_SCC.Appointments.Mappings.End = this.Dt_Data_KH_SCC.Columns["Ngay_KT"].ColumnName;
      this.SchedulerControl_KH_SCC.Views.GanttView.AppointmentDisplayOptions.AutoAdjustForeColor = false;

      if (this.Dt_Data_KH_SCC.Columns.Contains("Size_Border"))
        this.SchedulerStorage_KH_SCC.Appointments.Mappings.Status = this.Dt_Data_KH_SCC.Columns["Size_Border"].ColumnName;
      if (this.Dt_Data_KH_SCC.Columns.Contains("PercentComplete"))
        this.SchedulerStorage_KH_SCC.Appointments.Mappings.PercentComplete = this.Dt_Data_KH_SCC.Columns["PercentComplete"].ColumnName;
      else
        this.SchedulerControl_KH_SCC.Views.GanttView.AppointmentDisplayOptions.PercentCompleteDisplayType = PercentCompleteDisplayType.None;
      if (this.Dt_Data_KH_SCC.Columns.Contains("Type"))
        this.SchedulerStorage_KH_SCC.Appointments.Mappings.Type = this.Dt_Data_KH_SCC.Columns["Type"].ColumnName;

      this.SchedulerControl_KH_SCC.OptionsView.ToolTipVisibility = ToolTipVisibility.Always;

      if (this.M_Loai_KH_SCC.Trim() == "2" & this.M_Kieu_Xem != "HEN")
        this.SchedulerControl_KH_SCC.GanttView.Appearance.Appointment.ForeColor = System.Drawing.Color.Navy;
      else
        this.SchedulerControl_KH_SCC.GanttView.Appearance.Appointment.ForeColor = System.Drawing.Color.White;

      this.SchedulerControl_KH_SCC.GanttView.Appearance.Appointment.Font = new Font(this.SchedulerControl_KH_SCC.DayView.Appearance.Appointment.Font.FontFamily, 10f);
      this.SchedulerControl_KH_SCC.Views.GanttView.AppointmentDisplayOptions.StartTimeVisibility = AppointmentTimeVisibility.Never;
      this.SchedulerControl_KH_SCC.Views.GanttView.AppointmentDisplayOptions.EndTimeVisibility = AppointmentTimeVisibility.Never;
      this.SchedulerControl_KH_SCC.Views.GanttView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Disabled;
    }
    private void V_SetRowHeight_KH_SCC()
    {
      if (!this._TabVisible3)
        return;

      Decimal num = 0M;
      Decimal d1_1 = 0M;
      if (this.Dt_Set_SCC == null || this.Dt_Set_SCC.Rows.Count == 0)
        return;

      if (this.Dt_Set_SCC.Columns.Contains("RowHeight"))
        num = Convert.ToDecimal(this.Dt_Set_SCC.Rows[0]["RowHeight"]);
      if (this.Dt_Set_SCC.Columns.Contains("RowPage"))
        d1_1 = Convert.ToDecimal(this.Dt_Set_SCC.Rows[0]["RowPage"]);
      if (((ulong)-(Decimal.Compare(num, 0M) == 0 ? 1 : 0) & (ulong)Convert.ToInt64(d1_1)) > 0UL)
        return;

      Decimal d1_2 = new Decimal(checked(this.SchedulerControl_KH_SCC.Size.Height - 70));
      if (Decimal.Compare(num, 0M) > 0)
        d1_1 = Convert.ToDecimal(Math.Round(Decimal.Divide(d1_2, num), 0, MidpointRounding.AwayFromZero));
      if (Decimal.Compare(d1_1, 0M) <= 0)
        return;

      this.SchedulerControl_KH_SCC.Views.GanttView.ResourcesPerPage = Convert.ToInt32(d1_1);
    }
    private void V_Auto_Data_KH_SCC(object sender, EventArgs e)
    {
      this.Timer_Data_KH_SCC.Enabled = this.ChkAuto_Data_KH_SCC.Checked;
      this.CbbTime_Data_KH_SCC.Enabled = this.ChkAuto_Data_KH_SCC.Checked;
      Decimal d1 = CyberFunc.V_StringToNumeric(this.CbbTime_Data_KH_SCC);
      if (Decimal.Compare(d1, 0M) <= 0)
        d1 = 3000M;
      this.Timer_Data_KH_SCC.Interval = Convert.ToInt32(d1);
    }
    private void V_Buoc_Nhay_KH_SCC(object sender, EventArgs e)
    {
      this.V_CyberSetTime_KH_SCC();
      this.V_Do_Rong_KH_SCC(sender, e);
    }
    private void V_Do_Rong_KH_SCC(object sender, EventArgs e)
    {
      int index = 0;
      do
      {
        if (this.SchedulerControl_KH_SCC.GanttView.Scales[index].Visible)
          this.SchedulerControl_KH_SCC.Views.GanttView.Scales[index].Width = Convert.ToInt32(CyberFunc.V_GetvalueCombox(this.CbbDo_Rong_KH_SCC));
        checked { ++index; }
      }
      while (index <= 6);
    }
    private void V_Load_Cho_Lap_KH()
    {
      this.V_LoadData_Cho_Lap_KH("1", "");
      this.V_Fill_Cho_Lap_KH();
      this.V_Fill_Sua_Xong_KH();
      this.V_AddHander_Cho_Lap_KH();

      if (this.M_Kieu_Xem.Trim() != "HEN" & this.M_Loai_KH_SCC.Trim() == "1")
        this.V_DragDropGridview_KH_SCC();

      if (this.M_Kieu_Xem.Trim() == "HEN" | this.Dt_Sua_Xong_KH == null)
      {
        TabControl tabSuaXongMauXe = this.TabSua_Xong_Mau_XE;
        ref TabControl local = ref tabSuaXongMauXe;
        CyberFunc.V_HideTapPage(ref local, "TabPage_Sua_Xong");
        this.TabSua_Xong_Mau_XE = tabSuaXongMauXe;
      }

      this.T_tinh_So_Xe();
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
          this.LabLock.Text = Convert.ToString(dataSet.Tables[0].Rows[0]["Caption_Lock"]);
        if (dataSet.Tables[0].Columns.Contains("BackColor"))
          this.LabLock.BackColor = this.CyberColor.GetBackColor(Convert.ToString(dataSet.Tables[0].Rows[0]["BackColor"]));
        if (dataSet.Tables[0].Columns.Contains("ForeColor"))
          this.LabLock.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(dataSet.Tables[0].Rows[0]["ForeColor"]));

        dataSet?.Dispose();
      }
    }
    private void V_LoadTimeLine()
    {
      TimeIntervalCollection visibleIntervals = this.SchedulerControl_KH_SCC.ActiveView.GetVisibleIntervals();
      TimeSpan timeSpan = visibleIntervals[checked(visibleIntervals.Count - 1)].End - visibleIntervals[0].Start;
      timeSpan = new TimeSpan(checked((long)Math.Round(unchecked((double)timeSpan.Ticks / 2.0))));
      this.SchedulerControl_KH_SCC.Start = DateTime.Now.AddTicks(checked(-timeSpan.Ticks));
    }
    private void V_AddHanderLabel_KH_SCC()
    {
      this.Lab_SCC_01.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_02.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_03.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_04.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_05.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_06.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_07.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_08.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_09.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_10.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_11.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_12.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_13.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_14.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_15.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_16.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_17.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_18.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_19.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_20.Paint -= new PaintEventHandler(this.Label_Paint_KH_SCC);

      this.LabTotal.Click -= new EventHandler(this.Label_Xem_BC_KH_SCC);

      this.Lab_SCC_01.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_02.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_03.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_04.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_05.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_06.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_07.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_08.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_09.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_10.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_11.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_12.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_13.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_14.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_15.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_16.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_17.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_18.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_19.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);
      this.Lab_SCC_20.Paint += new PaintEventHandler(this.Label_Paint_KH_SCC);

      this.LabTotal.Click += new EventHandler(this.Label_Xem_BC_KH_SCC);
    }
    private void Label_Paint_KH_SCC(object sender, PaintEventArgs e) => this.ResizeLabel_KH_SCC((Label)sender);
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
    private void V_GetHieghtSplitContainerKH_SC() => this.SplitContainerKH_SC.SplitterDistance = checked(this.SplitContainerKH_SC.Size.Height - 5 - this.Panel1.Height);
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
      if (_Dt == null || this.Dt_Data_Xe_KH_SCC == null || !_Dt.Columns.Contains("Stt_Rec_Ro") || !this.Dt_Data_Xe_KH_SCC.Columns.Contains("Stt_Rec_Ro") || !this.Dt_Data_Xe_KH_SCC.Columns.Contains("Forecolor") || !_Dt.Columns.Contains("Forecolor"))
        return;

      this.SchedulerControl_KH_SCC.BeginUpdate();
      int num1 = checked(_Dt.Rows.Count - 1);
      int index1 = 0;
      while (index1 <= num1)
      {
        int num2 = checked(this.Dt_Data_Xe_KH_SCC.Rows.Count - 1);
        int num3 = 0;
        while (num3 <= num2)
        {
          if (_Dt.Rows[index1]["Stt_Rec_Ro"].ToString().Trim() == this.Dt_Data_Xe_KH_SCC.Rows[num3]["Stt_Rec_Ro"].ToString().Trim())
          {
            CyberFunc.V_UpdateRowtoRow(_Dt.Rows[index1], this.Dt_Data_Xe_KH_SCC, num3);
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
          if (this.Dt_Data_Xe_KH_SCC.Select("Stt_Rec_RO = " + _Dt.Rows[index2]["Stt_rec_Ro"]).Length <= 0)
            this.Dt_Data_Xe_KH_SCC.ImportRow(_Dt.Rows[index2]);
          checked { ++index2; }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      this.SchedulerControl_KH_SCC.EndUpdate();
    }
    private void V_Update_Ten3()
    {
    }
    private void V_Dang_Sua_Chua(object _StrKhoang)
    {
      if (this.M_Kieu_Xem == "HEN" || this.M_Loai_KH_SCC != "1")
        return;

      DateTime date = Convert.ToDateTime(this.TxtM_Ngay_Ct_KH_SCC.EditValue);
      DataSet dataSet = new DataSet(); // CP_RO_CVDV_DangSC
      if (dataSet.Tables.Count == 0)
        dataSet.Dispose();
      else
        this.V_UpdateTbToTb(dataSet.Tables[0], this.DmKhoang_KH_SCC, "Ma_khoang", "Ma_khoang", true);
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
      this.SchedulerControl_KH_SCC.BeginUpdate();
      string str1 = this.V_GetFilter_KH_SCC(this.Dt_Data_KH_SCC) + " AND " + this.V_GetFilter_KH_SCC_To(this.Dt_Data_KH_SCC, "XE");
      string str2 = this.V_GetFilter_KH_SCC(this.Dt_Data_Xe_KH_SCC) + " AND " + this.V_GetFilter_KH_SCC_To(this.Dt_Data_Xe_KH_SCC, "XE");
      string _StrFilter1 = this.V_GetFilterOneField(Convert.ToString(this.CbbKhoang_KH_SCC.SelectedValue), this.DmKhoang_KH_SCC, "Ma_khoang", false, false, false);
      string _StrFilter2 = this.V_GetFilter_KH_SCC(this.DmKTV_KH_SCC) + " AND " + this.V_GetFilter_KH_SCC_To(this.DmKTV_KH_SCC, "KTV");
      
      if (this.ChkDu_kien_giaoCVDV.Checked)
      {
        str1 = str1 + this.V_GetFilter_Ngay_giao(Convert.ToDateTime(this.TxtM_Ngay_Ct_KH_SCC.EditValue), this.Dt_Data_KH_SCC);
        str2 = str2 + this.V_GetFilter_Ngay_giao(Convert.ToDateTime(this.TxtM_Ngay_Ct_KH_SCC.EditValue), this.Dt_Data_Xe_KH_SCC);
      }

      this.Set_Filter(this.Dv_Data_KH_SCC, str1);
      this.Set_Filter(this.Dv_Data_Xe_KH_SCC, str2);

      if (this.ChkShow_All_Cd_Xe.Checked)
      {
        string filterKhSccCdXe1 = this.V_GetFilter_KH_SCC_Cd_XE(this.Dt_Data_KH_SCC, this.Dv_Data_KH_SCC);
        string filterKhSccCdXe2 = this.V_GetFilter_KH_SCC_Cd_XE(this.Dt_Data_Xe_KH_SCC, this.Dv_Data_Xe_KH_SCC);
        this.Set_Filter(this.Dv_Data_KH_SCC, filterKhSccCdXe1);
        this.Set_Filter(this.Dv_Data_Xe_KH_SCC, filterKhSccCdXe2);
      }

      this.V_Loc_Xe_Cho_Lap_KH(sender, e);
      this.Set_Filter(this.Dv_DmKhoang_KH_SCC, _StrFilter1);
      this.Set_Filter(this.Dv_DmKTV_KH_SCC, _StrFilter2);
      this.SchedulerControl_KH_SCC.EndUpdate();
      this.T_tinh_So_Xe();
    }
    private void V_start_Flass(string _Status)
    {
      this.Flass = 5;
      this.Interval = 1000;
      this.Stt_Flass = 0;
      this.BackColor_Flass = "";
      this.ForeColor_Flass = "";
      this.Show_iconNew = 0;

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
              this.Interval = Convert.ToInt32(dataSet.Tables[index1].Rows[0]["Interval_Timer"]);
            if (dataSet.Tables[index1].Columns.Contains("So_luotFlass"))
              this.Flass = Convert.ToInt32(dataSet.Tables[index1].Rows[0]["So_luotFlass"]);
            if (dataSet.Tables[index1].Columns.Contains("BackColor_FlassDefault"))
              this.BackColor_Flass = Convert.ToString(dataSet.Tables[index1].Rows[0]["BackColor_FlassDefault"]);
            if (dataSet.Tables[index1].Columns.Contains("ForeColor_FlassDefault"))
              this.ForeColor_Flass = Convert.ToString(dataSet.Tables[index1].Rows[0]["ForeColor_FlassDefault"]);
          }
        }
        int index2 = checked(index1 + 1);
        if (dataSet.Tables.Count > index2)
        {
          if (_Status == "1")
            this.dt_TabChange = dataSet.Tables[index2].Copy();
          else
          {
            this.dt_TabChange.Clear();
            int num = checked(dataSet.Tables[index2].Rows.Count - 1);
            int index3 = 0;
            while (index3 <= num)
            {
              this.dt_TabChange.ImportRow(dataSet.Tables[index2].Rows[index3]);
              checked { ++index3; }
            }
            this.dt_TabChange.AcceptChanges();
          }
        }

        dataSet.Dispose();
        this.Timer_FlassTab.Interval = this.Interval;
        this.Timer_FlassTab.Enabled = true;
        this.Timer_FlassTab.Start();
      }
    }
    #endregion

    #region "V_Filter_KH_SCC"
    private string V_GetFilter_KH_SCC(DataTable _DT_Filter)
    {
      string filterKhScc = "1=1";
      if (_DT_Filter == null)
        return filterKhScc;
      string Left1 = CyberFunc.V_GetvalueCombox(this.CbbCVDV_KH_SCC);
      if (_DT_Filter.Columns.Contains("Ma_Hs") & Left1 != "")
        filterKhScc = filterKhScc + " AND Ma_Hs = '" + Left1.Trim() + "'";
      string Left2 = CyberFunc.V_GetvalueCombox(this.CbbKhoang_KH_SCC);
      if (_DT_Filter.Columns.Contains("Ma_Khoang") & Left2 != "")
        filterKhScc = filterKhScc + " AND Ma_khoang = '" + Left2.Trim() + "'";
      string Left3 = CyberFunc.V_GetvalueCombox(this.CbbCD_KH_SCC);
      if (_DT_Filter.Columns.Contains("Ma_CD") & Left3 != "")
        filterKhScc = filterKhScc + " AND Ma_CD = '" + Left3.Trim() + "'";
      string Left4 = CyberFunc.V_GetvalueCombox(this.CbbTang_KH_SCC);
      if (_DT_Filter.Columns.Contains("Tang") & Left4 != "")
        filterKhScc = filterKhScc + " AND Tang = '" + Left4.Trim() + "'";
      string text1 = this.TxtMa_Xe_KH_SCC.Text;
      if (_DT_Filter.Columns.Contains("Ma_Xe") & text1 != "")
        filterKhScc = filterKhScc + " AND Ma_Xe LIKE '%" + text1.Trim() + "%'";
      string text2 = this.TxtSo_RO_KH_SCC.Text;
      if (_DT_Filter.Columns.Contains("So_RO") & text2 != "")
        filterKhScc = filterKhScc + " AND So_RO LIKE '%" + text2.Trim() + "%'";
      string str1 = CyberFunc.V_GetvalueCombox(this.CbbMuc_SBD_KH_SCC);
      if (this.ChkSBD_KH_SCC.Checked & str1.Trim() != "" && _DT_Filter.Columns.Contains("Muc_SBD"))
        filterKhScc = filterKhScc + " AND Muc_SBD = '" + str1.Trim() + "'";
      string str2 = CyberFunc.V_GetvalueCombox(this.CbbMuc_SDS_KH_SCC);
      if (this.ChkSDS_KH_SCC.Checked & str2.Trim() != "" && _DT_Filter.Columns.Contains("Muc_SDS"))
        filterKhScc = filterKhScc + " AND Muc_SDS = '" + str2.Trim() + "'";
      if (this.ChkUu_Tien.Checked & _DT_Filter.Columns.Contains("Uu_Tien"))
        filterKhScc += " AND Uu_Tien = '1'";
      if (this.ChkFV_KH_SCC.Checked & _DT_Filter.Columns.Contains("first_visit"))
        filterKhScc += " AND first_visit = '1'";
      if (this.ChkDung_KH_SCC.Checked & _DT_Filter.Columns.Contains("Dung"))
        filterKhScc += " AND Dung = '1'";
      if (this.ChkSDS_KH_SCC.Checked & _DT_Filter.Columns.Contains("SDS"))
        filterKhScc += " AND SDS = '1'";
      if (this.ChkCho_Rua_KH_SCC.Checked & _DT_Filter.Columns.Contains("Cho_Rua"))
        filterKhScc += " AND Cho_Rua = '1'";
      if (this.ChkDang_Rua_KH_SCC.Checked & _DT_Filter.Columns.Contains("Dang_Rua"))
        filterKhScc += " AND Dang_Rua = '1'";
      if (this.ChkCho_Giao_KH_SCC.Checked & _DT_Filter.Columns.Contains("Cho_Giao"))
        filterKhScc += " AND Cho_Giao = '1'";
      if (this.ChkGiao_Ngay_Kh_SCC.Checked & _DT_Filter.Columns.Contains("Giao_Ngay"))
        filterKhScc += " AND Giao_Ngay = '1'";
      if (this.ChkEM60_KH_SCC.Checked & _DT_Filter.Columns.Contains("EM60"))
        filterKhScc += " AND Em60 = '1'";
      if (this.ChkPM90_KH_SCC.Checked & _DT_Filter.Columns.Contains("Pm90"))
        filterKhScc += " AND Pm90 = '1'";
      if (this.ChkSCL_KH_SCC.Checked & _DT_Filter.Columns.Contains("SCL"))
        filterKhScc += " AND SCL = '1'";
      if (this.ChkIs_EM_KH_SCC.Checked & _DT_Filter.Columns.Contains("Is_Em"))
        filterKhScc += " AND Is_Em = '1'";
      if (this.ChkIs_GJ_KH_SCC.Checked & _DT_Filter.Columns.Contains("Is_GJ"))
        filterKhScc += " AND Is_GJ = '1'";

      return filterKhScc;
    }
    private string V_GetFilter_KH_SCC_To(DataTable _DT_Filter, string _Loai_Tb)
    {
      string filterKhSccTo = "(1=1)";
      if (_DT_Filter == null || !_DT_Filter.Columns.Contains("ma_To"))
        return filterKhSccTo;

      string str1 = CyberFunc.V_GetvalueCombox(this.CbbTo_KH_SCC).ToString().Trim();
      if (str1.Trim() == "")
        return filterKhSccTo;

      if (this.M_Loai_KH_SCC.Trim().Trim() == "1" | this.M_Kieu_Xem.Trim() == "HEN")
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
      if (this.Dt_Cho_Lap_KH == null)
        return;

      string Left = this.V_GetFilter_KH_SCC(this.Dt_Cho_Lap_KH);
      if (this.TxtMa_Xe_Cho_Lap_KH.Text != "" & this.Dt_Cho_Lap_KH.Columns.Contains("Ma_Xe"))
        Left = Left + " AND Ma_Xe Like '*" + this.TxtMa_Xe_Cho_Lap_KH.Text.Trim() + "*'";
      if (this.TxtSo_Ro_Cho_Lap_KH.Text != "" & this.Dt_Cho_Lap_KH.Columns.Contains("So_Ro"))
        Left = Left + " AND So_Ro Like '*" + this.TxtSo_Ro_Cho_Lap_KH.Text.Trim() + "*'";
      if (this.ChkDu_kien_giaoCVDV.Checked)
        Left = Left + this.V_GetFilter_Ngay_giao(Convert.ToDateTime(this.TxtM_Ngay_Ct_KH_SCC.EditValue), this.Dt_Cho_Lap_KH);
      try
      {
        this.Dv_Cho_Lap_KH.RowFilter = Left;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
    private void T_tinh_So_Xe()
    {
      string str = "0";
      this.Lab_SCC_01.Text = str;
      this.Lab_SCC_02.Text = str;
      this.Lab_SCC_03.Text = str;
      this.Lab_SCC_04.Text = str;
      this.Lab_SCC_05.Text = str;
      this.Lab_SCC_06.Text = str;
      this.Lab_SCC_07.Text = str;
      this.Lab_SCC_08.Text = str;
      this.Lab_SCC_09.Text = str;
      this.Lab_SCC_10.Text = str;
      this.Lab_SCC_11.Text = str;
      this.Lab_SCC_12.Text = str;
      this.Lab_SCC_13.Text = str;
      this.Lab_SCC_14.Text = str;
      this.Lab_SCC_15.Text = str;
      this.Lab_SCC_16.Text = str;
      this.Lab_SCC_17.Text = str;
      this.Lab_SCC_18.Text = str;
      this.Lab_SCC_19.Text = str;
      this.Lab_SCC_20.Text = str;
      int num = checked(this.Dv_Data_KH_SCC.Count - 1);
      int recordIndex = 0;

      while (recordIndex <= num)
      {
        string Left = this.Dv_Data_KH_SCC[recordIndex]["Id_BackColor"].ToString().Trim();
        if (Left == "0")
          this.Lab_SCC_01.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_01.Text), 1M).ToString();
        else if (Left == "1")
          this.Lab_SCC_02.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_02.Text), 1M).ToString();
        else if (Left == "2")
          this.Lab_SCC_03.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_03.Text), 1M).ToString();
        else if (Left == "3")
          this.Lab_SCC_04.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_04.Text), 1M).ToString();
        else if (Left == "4")
          this.Lab_SCC_05.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_05.Text), 1M).ToString();
        else if (Left == "5")
          this.Lab_SCC_06.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_06.Text), 1M).ToString();
        else if (Left == "6")
          this.Lab_SCC_07.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_07.Text), 1M).ToString();
        else if (Left == "7")
          this.Lab_SCC_08.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_08.Text), 1M).ToString();
        else if (Left == "8")
          this.Lab_SCC_09.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_09.Text), 1M).ToString();
        else if (Left == "9")
          this.Lab_SCC_10.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_10.Text), 1M).ToString();
        else if (Left == "10")
          this.Lab_SCC_11.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_11.Text), 1M).ToString();
        else if (Left == "11")
          this.Lab_SCC_12.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_12.Text), 1M).ToString();
        else if (Left == "12")
          this.Lab_SCC_13.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_13.Text), 1M).ToString();
        else if (Left == "13")
          this.Lab_SCC_14.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_14.Text), 1M).ToString();
        else if (Left == "14")
          this.Lab_SCC_15.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_15.Text), 1M).ToString();
        else if (Left == "15")
          this.Lab_SCC_16.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_16.Text), 1M).ToString();
        else if (Left == "16")
          this.Lab_SCC_17.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_17.Text), 1M).ToString();
        else if (Left == "17")
          this.Lab_SCC_18.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_18.Text), 1M).ToString();
        else if (Left == "18")
          this.Lab_SCC_19.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_19.Text), 1M).ToString();
        else if (Left == "19")
          this.Lab_SCC_20.Text = Decimal.Add(Convert.ToDecimal(this.Lab_SCC_20.Text), 1M).ToString();
        checked { ++recordIndex; }
      }

      if (this.M_Kieu_Xem.Trim() == "HEN")
        this.LabTotal.Text = Convert.ToString(this.Dv_Data_KH_SCC.Count);
      else
        this.Tinh_toan_so_Xe_Lab();
    }
    private void Tinh_toan_so_Xe_Lab()
    {
      int num1 = -1;
      int num2 = -1;
      int num3 = -1;
      if (this.Dt_Mo_Lenh_Trong_Ngay != null)
        num1 = this.Dv_Mo_Lenh_Trong_Ngay.Count;
      if (this.Dt_Data_KH_SCC != null)
        num2 = this.V_Dem_Xe(this.Dv_Data_KH_SCC);
      if (this.Dt_Lenh_Giao_Trong_Ngay != null)
        num3 = this.Dv_Lenh_Giao_Trong_Ngay.Count;
      if (this.M_Loai_KH_SCC == "2")
        num1 = -1;

      this.LabTotal.Text = "";
      if (num1 != -1)
        this.LabTotal.Text = num1.ToString();
      if (num2 != -1)
        this.LabTotal.Text = this.LabTotal.Text + (this.LabTotal.Text.Length != 0 ? "/" : "") + num2.ToString();
      if (num3 == -1)
        return;

      this.LabTotal.Text = this.LabTotal.Text + (this.LabTotal.Text.Length != 0 ? "/" : "") + num3.ToString();
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
          if (this.FindItemInArr(dataRowView["Ma_Xe"].ToString() + Right, arr_txt, ";") == 0)
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
          if (this.FindItemInArr(Convert.ToString(dataRowView["Ma_Xe"]), arr_txt, ";") == 0)
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

    #region "V_AddHander_KH_SCC"
    #endregion

    #region "V_SetSchedulerControl_KH_SCC"
    private void V_SetSchedulerSetValue()
    {
      string str = CyberFunc.V_GetvalueCombox(this.CbbLoai_Xem_KH_SCC);
      bool flag1 = true;
      bool flag2 = true;
      if (this.DmLoai_Xem_Loc_KH_SCC != null && this.DmLoai_Xem_Loc_KH_SCC.Columns.Contains("Loai"))
      {
        DataRow[] dataRowArray = this.DmLoai_Xem_Loc_KH_SCC.Select("Loai='" + str + "'");
        if (this.DmLoai_Xem_Loc_KH_SCC.Columns.Contains("ShowHead") && dataRowArray.Length > 0 && dataRowArray[0]["ShowHead"] == (object)0)
          flag1 = false;
        if (this.DmLoai_Xem_Loc_KH_SCC.Columns.Contains("Show_ResourcesTree") && dataRowArray.Length > 0 && dataRowArray[0]["Show_ResourcesTree"] == (object)0)
          flag2 = false;
      }
      this.ResourcesTree1.Visible = flag2;
      this.SchedulerControl_KH_SCC.Views.GanttView.ShowResourceHeaders = flag1;
      Decimal _Do_Rong = 0M;
      if (this.DmLoai_Xem_KH_SCC.Columns.Contains("Do_Rong"))
      {
        int num = checked(this.DmLoai_Xem_KH_SCC.Rows.Count - 1);
        int index = 0;
        while (index <= num)
        {
          if (this.DmLoai_Xem_KH_SCC.Rows[index]["Loai"].ToString().Trim().ToUpper() == str)
          {
            _Do_Rong = Convert.ToDecimal(this.DmLoai_Xem_KH_SCC.Rows[index]["Do_Rong"]);
            break;
          }
          checked { ++index; }
        }
      }

      string Left = str;
      if (Left == "01")
      {
        string _Id = !this.DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
        string _Caption = !(this.M_Loai_KH_SCC == "2" & str == "01") ? (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
        if (this.M_Kieu_Xem != "HEN" & this.M_Loai_KH_SCC == "1")
          this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, this.Dt_Khoang_H);
        else
          this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
      }
      else if (Left == "02")
      {
        if (this.DmCVDV_KH_SCC != null)
          this.V_SetScheduler(this.Dv_DmCVDV_KH_SCC, !this.DmCVDV_KH_SCC.Columns.Contains("Ma_Hs_Tmp") ? "Ma_Hs" : "Ma_Hs_Tmp", !this.DmCVDV_KH_SCC.Columns.Contains("Ten_Hs_Tmp") ? (this.DmCVDV_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_HS") : "Ten_Hs_Tmp", _Do_Rong);
        else
        {
          string _Id = !this.DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
          string _Caption = !(this.M_Loai_KH_SCC == "2" & str == "01") ? (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
          if (this.M_Kieu_Xem != "HEN" & this.M_Loai_KH_SCC == "1")
            this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, this.Dt_Khoang_H);
          else
            this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
        }
      }
      else if (Left == "03")
      {
        if (this.DmTo_KH_SCC != null)
          this.V_SetScheduler(this.Dv_DmTo_KH_SCC, !this.DmTo_KH_SCC.Columns.Contains("Ma_To_Tmp") ? "Ma_To" : "Ma_To_Tmp", !this.DmTo_KH_SCC.Columns.Contains("Ten_To_Tmp") ? (this.DmTo_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_To") : "Ten_To_Tmp", _Do_Rong);
        else
        {
          string _Id = !this.DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
          string _Caption = !(this.M_Loai_KH_SCC == "2" & str == "01") ? (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
          if (this.M_Kieu_Xem != "HEN" & this.M_Loai_KH_SCC == "1")
            this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, this.Dt_Khoang_H);
          else
            this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
        }
      }
      else if (Left == "04")
      {
        if (this.DmCd_KH_SCC != null)
          this.V_SetScheduler(this.Dv_DmCd_KH_SCC, !this.DmCd_KH_SCC.Columns.Contains("Ma_CD_Tmp") ? "Ma_CD" : "Ma_CD_Tmp", !this.DmCd_KH_SCC.Columns.Contains("Ten_CD_Tmp") ? (this.DmCd_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_CD") : "Ten_CD_Tmp", _Do_Rong);
        else
        {
          string _Id = !this.DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
          string _Caption = !(this.M_Loai_KH_SCC == "2" & str == "01") ? (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
          if (this.M_Kieu_Xem != "HEN" & this.M_Loai_KH_SCC == "1")
            this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, this.Dt_Khoang_H);
          else
            this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
        }
      }
      else if (Left == "05")
      {
        if (this.Dt_Data_Xe_KH_SCC != null)
        {
          string _Id = !this.Dt_Data_Xe_KH_SCC.Columns.Contains("Stt_rec_Ro_Tmp") ? "Stt_rec_Ro" : "Stt_rec_Ro_Tmp";
          string _Caption = !this.Dt_Data_Xe_KH_SCC.Columns.Contains("Ma_Xe_Tmp") ? (this.Dt_Data_Xe_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ma_Xe") : "Ma_Xe_Tmp";
          if (this.M_Kieu_Xem != "HEN" & this.M_Loai_KH_SCC == "2")
            this.V_SetScheduler(this.Dv_Data_Xe_KH_SCC, _Id, _Caption, _Do_Rong, this.Dt_Xe_H);
          else
            this.V_SetScheduler(this.Dv_Data_Xe_KH_SCC, _Id, _Caption, _Do_Rong);
        }
        else
        {
          string _Id = !this.DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
          string _Caption = !(this.M_Loai_KH_SCC == "2" & str == "01") ? (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
          if (this.M_Kieu_Xem != "HEN" & this.M_Loai_KH_SCC == "1")
            this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, this.Dt_Khoang_H);
          else
            this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
        }
      }
      else if (Left == "06")
      {
        if (this.Dt_Data_KTV_KH_SCC != null)
          this.V_SetScheduler(this.Dv_Data_KTV_KH_SCC, !this.Dt_Data_KTV_KH_SCC.Columns.Contains("Ma_KTV_Tmp") ? "Ma_KTV" : "Ma_KTV_Tmp", !this.Dt_Data_KTV_KH_SCC.Columns.Contains("Ten_KTV_Tmp") ? (this.Dt_Data_KTV_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_KTV") : "Ten_KTV_Tmp", _Do_Rong);
        else
        {
          string _Id = !this.DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
          string _Caption = !(this.M_Loai_KH_SCC == "2" & str == "01") ? (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
          if (this.M_Kieu_Xem != "HEN" & this.M_Loai_KH_SCC == "1")
            this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, this.Dt_Khoang_H);
          else
            this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
        }
      }
      else
      {
        string _Id = !this.DmKhoang_KH_SCC.Columns.Contains("Ma_Khoang_Tmp") ? "Ma_Khoang" : "Ma_Khoang_Tmp";
        string _Caption = !(this.M_Loai_KH_SCC == "2" & str == "01") ? (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten3") ? "Ten3" : "Ten_khoang") : "Ten_Khoang_Tmp") : (!this.DmKhoang_KH_SCC.Columns.Contains("Ten_Khoang_Tmp") ? (this.DmKhoang_KH_SCC.Columns.Contains("Ten_khoang") ? "Ten_khoang2" : "Ten_khoang") : "Ten_Khoang_Tmp");
        if (this.M_Kieu_Xem != "HEN" & this.M_Loai_KH_SCC == "1")
          this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong, this.Dt_Khoang_H);
        else
          this.V_SetScheduler(this.Dv_DmKhoang_KH_SCC, _Id, _Caption, _Do_Rong);
      }
      this.V_Update_Ten3();
    }
    private void V_SetScheduler(DataView _Dv_DataSource, string _Id, string _Caption, Decimal _Do_Rong, DataTable _Dt_Head_tree = null)
    {
      if (_Dv_DataSource == null)
        return;

      this.V_AddResourcesTree(_Dv_DataSource, _Dt_Head_tree);

      this.SchedulerStorage_KH_SCC.Resources.DataSource = (object)null;
      this.SchedulerStorage_KH_SCC.Resources.Mappings.Id = "";
      this.SchedulerStorage_KH_SCC.Resources.Mappings.Caption = "";
      this.SchedulerStorage_KH_SCC.Resources.DataSource = (object)_Dv_DataSource;
      this.SchedulerStorage_KH_SCC.Resources.Mappings.Id = _Dv_DataSource.Table.Columns[_Id].ColumnName.ToString().Trim();
      this.SchedulerStorage_KH_SCC.Resources.Mappings.Caption = _Dv_DataSource.Table.Columns[_Caption].ColumnName.ToString().Trim();

      if (_Dv_DataSource.Table.Columns.Contains("Color"))
        this.SchedulerStorage_KH_SCC.Resources.Mappings.Color = _Dv_DataSource.Table.Columns["Color"].ColumnName.ToString().Trim();

      if (_Dv_DataSource.Table.Columns.Contains("Image"))
        this.SchedulerStorage_KH_SCC.Resources.Mappings.Image = _Dv_DataSource.Table.Columns["Image"].ColumnName.ToString().Trim();

      if (Decimal.Compare(_Do_Rong, 0M) > 0)
        this.SchedulerControl_KH_SCC.OptionsView.ResourceHeaders.Height = Convert.ToInt32(_Do_Rong);

      this.SchedulerStorage_KH_SCC.Appointments.Mappings.ResourceId = this.Dt_Data_KH_SCC.Columns[_Id].ColumnName;

      if (this.Dt_Data_KH_SCC.Columns.Contains("ten_CD") & this.M_Loai_KH_SCC.Trim() == "2" & this.M_Kieu_Xem != "HEN")
        this.SchedulerStorage_KH_SCC.Appointments.Mappings.Subject = this.Dt_Data_KH_SCC.Columns["ten_CD"].ColumnName;
      else
        this.SchedulerStorage_KH_SCC.Appointments.Mappings.Subject = this.Dt_Data_KH_SCC.Columns["Ma_Xe"].ColumnName;

      if (this.Dt_Data_Parent_KH_SCC == null || !(this.Dt_Data_Parent_KH_SCC.Columns.Contains("DependentId") & this.Dt_Data_Parent_KH_SCC.Columns.Contains("ParentId") & this.Dt_Data_Parent_KH_SCC.Columns.Contains("Type")))
        return;

      this.SchedulerStorage_KH_SCC.AppointmentDependencies.DataSource = (object)this.Dt_Data_Parent_KH_SCC;
      this.SchedulerStorage_KH_SCC.AppointmentDependencies.Mappings.DependentId = this.Dt_Data_Parent_KH_SCC.Columns["DependentId"].ColumnName;
      this.SchedulerStorage_KH_SCC.AppointmentDependencies.Mappings.ParentId = this.Dt_Data_Parent_KH_SCC.Columns["ParentId"].ColumnName;
      this.SchedulerStorage_KH_SCC.AppointmentDependencies.Mappings.Type = this.Dt_Data_Parent_KH_SCC.Columns["Type"].ColumnName;
    }
    private void V_AddResourcesTree(DataView _Dv_DataSource, DataTable _Dt_Header)
    {
      this.ResourcesTree1.Columns.Clear();
      if (this.M_Kieu_Xem == "HEN")
      {
        this.ResourcesTree1.Visible = false;
        this.SplitContainer_Tien_Do.SplitterDistance = 0;
      }
      else if (_Dv_DataSource == null | _Dt_Header == null)
      {
        this.SchedulerControl_KH_SCC.Views.GanttView.ShowResourceHeaders = true;
        this.ResourcesTree1.Visible = false;
      }
      else
      {
        this.ResourcesTree1.BorderStyle = this.SchedulerControl_KH_SCC.BorderStyle;
        int num = 10;
        int Left1 = num;
        this.ResourcesTree1.Visible = true;
        this.ResourcesTree1.Columns.Clear();
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
              this.ResourcesTree1.Columns.Add((TreeListColumn)column);
            }
          }
        }
        catch(Exception ex)
        {
          MessageBox.Show("V_AddResourcesTree: " + ex.Message);
        }
        if (num == Left1)
        {
          this.ResourcesTree1.Visible = false;
          this.SplitContainer_Tien_Do.SplitterDistance = 20;
        }
        else
        {
          this.ResourcesTree1.Width = Left1;
          this.ResourcesTree1.Visible = true;
          this.SplitContainer_Tien_Do.SplitterDistance = Left1;
        }
      }
    }
    private void V_SetColorAppointments()
    {
      int num1 = checked(this.Dt_ConFigColor_KH_SCC.Rows.Count - 1);
      int num2 = 0;
      while (num2 <= num1)
      {
        this.SchedulerStorage_KH_SCC.Appointments.Labels[num2].Color = this.CyberColor.GetBackColor(Convert.ToString(this.Dt_ConFigColor_KH_SCC.Rows[num2]["BackColor"]));
        this.SchedulerStorage_KH_SCC.Appointments.Labels[num2].DisplayName = Convert.ToString(this.Dt_ConFigColor_KH_SCC.Rows[num2]["Ten_Color"]);
        this.SchedulerStorage_KH_SCC.Appointments.Labels[num2].MenuCaption = Convert.ToString(this.Dt_ConFigColor_KH_SCC.Rows[num2]["Ten_Color"]);
        this.V_SetColorlabel_SCC(num2, this.Dt_ConFigColor_KH_SCC.Rows[num2]);
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
          this.Lab_SCC1_01.Visible = flag;
          this.Lab_SCC_01.Visible = true;
          this.Lab_SCC1_01.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_01.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_01.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_01.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 2:
          this.Lab_SCC1_02.Visible = flag;
          this.Lab_SCC_02.Visible = true;
          this.Lab_SCC1_02.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_02.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_02.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_02.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 3:
          this.Lab_SCC1_03.Visible = flag;
          this.Lab_SCC_03.Visible = true;
          this.Lab_SCC1_03.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_03.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_03.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_03.Tag = _Dr["Ma_Color"].ToString().Trim();
          break;
        case 4:
          this.Lab_SCC1_04.Visible = flag;
          this.Lab_SCC_04.Visible = true;
          this.Lab_SCC1_04.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_04.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_04.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_04.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 5:
          this.Lab_SCC1_05.Visible = flag;
          this.Lab_SCC_05.Visible = true;
          this.Lab_SCC1_05.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_05.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_05.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_05.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 6:
          this.Lab_SCC1_06.Visible = flag;
          this.Lab_SCC_06.Visible = true;
          this.Lab_SCC1_06.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_06.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_06.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_06.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 7:
          this.Lab_SCC1_07.Visible = flag;
          this.Lab_SCC_07.Visible = true;
          this.Lab_SCC1_07.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_07.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_07.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_07.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 8:
          this.Lab_SCC1_08.Visible = flag;
          this.Lab_SCC_08.Visible = true;
          this.Lab_SCC1_08.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_08.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_08.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_08.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 9:
          this.Lab_SCC1_09.Visible = flag;
          this.Lab_SCC_09.Visible = true;
          this.Lab_SCC1_09.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_09.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_09.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_09.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 10:
          this.Lab_SCC1_10.Visible = flag;
          this.Lab_SCC_10.Visible = true;
          this.Lab_SCC1_10.Text = _Dr["Ten_Color"].ToString();
          break;
        case 11:
          this.Lab_SCC1_11.Visible = flag;
          this.Lab_SCC_11.Visible = true;
          this.Lab_SCC1_11.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_11.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_11.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_11.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 12:
          this.Lab_SCC1_12.Visible = flag;
          this.Lab_SCC_12.Visible = true;
          this.Lab_SCC1_12.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_12.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_12.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_12.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 13:
          this.Lab_SCC1_13.Visible = flag;
          this.Lab_SCC_13.Visible = true;
          this.Lab_SCC1_13.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_13.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_13.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_13.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 14:
          this.Lab_SCC1_14.Visible = flag;
          this.Lab_SCC_14.Visible = true;
          this.Lab_SCC1_14.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_14.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_14.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_14.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 15:
          this.Lab_SCC1_15.Visible = flag;
          this.Lab_SCC_15.Visible = true;
          this.Lab_SCC1_15.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_15.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_15.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_15.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 16:
          this.Lab_SCC1_16.Visible = flag;
          this.Lab_SCC_16.Visible = true;
          this.Lab_SCC1_16.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_16.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_16.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_16.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 17:
          this.Lab_SCC1_17.Visible = flag;
          this.Lab_SCC_17.Visible = true;
          this.Lab_SCC1_17.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_17.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_17.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_17.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 18:
          this.Lab_SCC1_18.Visible = flag;
          this.Lab_SCC_18.Visible = true;
          this.Lab_SCC1_18.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_18.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_18.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_18.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 19:
          this.Lab_SCC1_19.Visible = flag;
          this.Lab_SCC_19.Visible = true;
          this.Lab_SCC1_19.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_19.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_19.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_19.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
        case 20:
          this.Lab_SCC1_20.Visible = flag;
          this.Lab_SCC_20.Visible = true;
          this.Lab_SCC1_20.Text = _Dr["Ten_Color"].ToString();
          this.Lab_SCC_20.BackColor = this.CyberColor.GetBackColor(Convert.ToString(_Dr["BackColor"]));
          this.Lab_SCC_20.ForeColor = this.CyberColor.GetForeColor(Convert.ToString(_Dr["ForeColor"]));
          this.Lab_SCC_20.Tag = (object)_Dr["Ma_Color"].ToString().Trim();
          break;
      }
    }
    #endregion

    #region "V_Load_Cho_Lap_KH"
    #endregion
  }
}