using System;
using System.Data;
using System.Windows.Forms;
using TMV.Common.Forms;
using TMV.UI.JPCB.Common;

namespace TMV.UI.JPCB.JP
{
  public partial class frmJpDetail : DevExpress.XtraEditors.XtraForm
  {
    #region "variables"
    private CyberColor CyberColor = new CyberColor();
    private DataSet M_DsLoad;
    private string M_Mode = "M";
    private string M_Ma_Ct = "PKH";
    private string M_Kieu_Xem = "TD";
    private string M_Loai_SC = "1";
    private DateTime M_Ngay_BD;
    private DateTime M_Ngay_KT;
    private string M_Ma_CVDV = "";
    private string M_Ma_khoang = "";
    private string M_Ma_To = "";
    private string M_Ma_Xe = "";
    private string M_Ma_CD = "";
    private string M_Ma_KTV = "";
    private CyberColumnGridView EditTime_KTV = new CyberColumnGridView();
    private CyberColumnGridView EditNgay_BD = new CyberColumnGridView();
    private CyberColumnGridView EditNgay_KT = new CyberColumnGridView();
    private CyberColumnGridView EditNgay_BD_TH = new CyberColumnGridView();
    private CyberColumnGridView EditNgay_KT_TH = new CyberColumnGridView();
    private CyberColumnGridView EditkhoangTAG = new CyberColumnGridView();
    private CyberColumnGridView EditKhoangXem_Hen = new CyberColumnGridView();
    private CyberColumnGridView EditKTVTag = new CyberColumnGridView();
    private CyberColumnGridView EditKTVChinh_Phu = new CyberColumnGridView();
    private CyberColumnGridView EditKTVXem_Hen = new CyberColumnGridView();
    private CyberColumnGridView EditKTVXN_BD = new CyberColumnGridView();
    private CyberColumnGridView EditKTVXN_KT = new CyberColumnGridView();
    private CyberColumnGridView EditCVTag = new CyberColumnGridView();
    private CyberColumnGridView EditVTTag = new CyberColumnGridView();
    private CyberColumnGridView EditCVIs_GO = new CyberColumnGridView();
    private CyberColumnGridView EditCVIs_SON = new CyberColumnGridView();
    private CyberColumnGridView EditCVMa_Ktv1 = new CyberColumnGridView();
    private CyberColumnGridView EditCVMa_Ktv2 = new CyberColumnGridView();
    private CyberColumnGridView EditCVTen_Ktv1 = new CyberColumnGridView();
    private CyberColumnGridView EditCVTen_KTV2 = new CyberColumnGridView();
    private DataTable Dt_ConFigColor_KH_SCC;
    private DataTable Dt_Set_SCC;
    private DataTable Dt_Buoc_Nhay_KH_SCC;
    private DataTable Dt_Do_Rong_KH_SCC;
    private DataTable Dt_To;
    private DataTable Dt_Cd;
    private DataTable Dt_khoang;
    private DataTable Dt_CVDV;
    private DataTable Dt_KTV;
    private DataTable Dt_khoangChon;
    private DataTable Dt_ToH;
    private DataTable Dt_CdH;
    private DataTable Dt_khoangH;
    private DataTable Dt_CVDVH;
    private DataTable Dt_KTVH;
    private DataTable Dt_khoangChonH;
    private DataTable Dt_DmMucSDS;
    private DataTable Dt_DmMucSBD;
    private DataTable Dt_Dung;
    private DataTable Dt_QG1;
    private DataTable Dt_KCSCD;
    private DataView Dv_To;
    private DataView Dv_Cd;
    private DataView Dv_khoang;
    private DataView Dv_CVDV;
    private DataView Dv_KTV;
    private DataView Dv_khoangChon;
    private DataView Dv_ToH;
    private DataView Dv_CdH;
    private DataView Dv_khoangH;
    private DataView Dv_CVDVH;
    private DataView Dv_KTVH;
    private DataView Dv_khoangChonH;
    private DataTable Dt_VT;
    private DataTable Dt_CV;
    private DataTable Dt_VTH;
    private DataTable Dt_CVH;
    private DataView Dv_VT;
    private DataView Dv_CV;
    private DataView Dv_VTH;
    private DataView Dv_CVH;
    private DataSet DsLookup;
    private DataRow DrReturn;
    private bool _Bold_khoang = false;
    private bool _BackColor_Khoang = false;
    private bool _BackColor2_Khoang = false;
    private bool _Forecolor_Khoang = false;
    private string _FieldBold_Khoang = "";
    private string _FieldBackColor_Khoang = "";
    private string _FieldBackColor2_Khoang = "";
    private string _FieldForecolor_Khoang = "";
    private bool _Bold_KTV = false;
    private bool _BackColor_KTV = false;
    private bool _BackColor2_KTV = false;
    private bool _Forecolor_KTV = false;
    private string _FieldBold_KTV = "";
    private string _FieldBackColor_KTV = "";
    private string _FieldBackColor2_KTV = "";
    private string _FieldForecolor_KTV = "";
    private bool _Bold_CV = false;
    private bool _BackColor_CV = false;
    private bool _BackColor2_CV = false;
    private bool _Forecolor_CV = false;
    private string _FieldBold_CV = "";
    private string _FieldBackColor_CV = "";
    private string _FieldBackColor2_CV = "";
    private string _FieldForecolor_CV = "";
    private bool _Bold_VT = false;
    private bool _BackColor_VT = false;
    private bool _BackColor2_VT = false;
    private bool _Forecolor_VT = false;
    private string _FieldBold_VT = "";
    private string _FieldBackColor_VT = "";
    private string _FieldBackColor2_VT = "";
    private string _FieldForecolor_VT = "";
    private ObjectDragDrop _keothatrongGrid = new ObjectDragDrop();
    private ObjectDragDrop _keotha2Grid = new ObjectDragDrop();
    #endregion

    public frmJpDetail()
    {
      InitializeComponent();
    }
    public bool ShowForm()
    {
      frmProgress.Instance().Thread = new MethodInvoker(InitForm);
      frmProgress.Instance().Show_Progress();
      return (ShowDialog() == DialogResult.OK);
    }
    private void InitForm()
    {
      Text = (M_Mode != "M") ? "Tạo mới kế hoạch" : "Sửa kế hoạch";
      V_LoadNgamDinh();
      V_Load();
      V_Ma_TO(new object(), new EventArgs());
      V_UpdateKTV_XN(TxtStt_Rec.Text, "");
      V_SetKhoang();
      CyberColor.V_GetColorBold(Dt_khoang, ref _Bold_khoang, ref _BackColor_Khoang, ref _BackColor2_Khoang, ref _Forecolor_Khoang, 
                                           ref _FieldBold_Khoang, ref _FieldBackColor_Khoang, ref _FieldBackColor2_Khoang, ref _FieldForecolor_Khoang);
      CyberColor.V_GetColorBold(Dt_KTV, ref _Bold_KTV, ref _BackColor_KTV, ref _BackColor2_KTV, ref _Forecolor_KTV, ref _FieldBold_KTV,
                                        ref _FieldBackColor_KTV, ref _FieldBackColor2_KTV, ref _FieldForecolor_KTV);
      CyberColor.V_GetColorBold(Dt_CV, ref _Bold_CV, ref _BackColor_CV, ref _BackColor2_CV, ref _Forecolor_CV, ref _FieldBold_CV, 
                                       ref _FieldBackColor_CV, ref _FieldBackColor2_CV, ref _FieldForecolor_CV);
      CyberColor.V_GetColorBold(Dt_VT, ref _Bold_VT, ref _BackColor_VT, ref _BackColor2_VT, ref _Forecolor_VT, ref _FieldBold_VT, 
                                       ref _FieldBackColor_VT, ref _FieldBackColor2_VT, ref _FieldForecolor_VT);
      V_AddHander();
      masterKhoangGRV.ColumnPanelRowHeight = 30;
      masterKTVGRV.ColumnPanelRowHeight = 30;
      MasterCVGRV.ColumnPanelRowHeight = 30;
      MasterVtGRV.ColumnPanelRowHeight = 30;
      V_DragDropGridview();
      V_Sub_SetColorCV();
      V_UpdateKhoang_KTV(TxtMa_KHoang.Text.Trim());
      V_UpdateKTV_CV_All(0);
    }

    #region "Load"
    private void V_LoadNgamDinh()
    {

    }
    private void V_Load()
    {

    }
    private void V_Ma_TO(object sender, EventArgs e)
    {

    }
    private void V_UpdateKTV_XN(string _Stt_Rec, string _Ma_Hs)
    {

    }
    private void V_SetKhoang()
    {

    }
    private void V_AddHander()
    {

    }
    private void V_DragDropGridview()
    {

    }
    private void V_Sub_SetColorCV()
    {

    }
    private void V_UpdateKhoang_KTV(string _ma_khoang)
    {

    }
    private void V_UpdateKTV_CV_All(int _Irow)
    {

    }
    #endregion
  }
}