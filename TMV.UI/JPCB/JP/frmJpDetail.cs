using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TMV.BusinessObject.JPCB;
using TMV.Common;
using TMV.Common.Forms;
using TMV.UI.JPCB.Common;

namespace TMV.UI.JPCB.JP
{
  public partial class frmJpDetail : DevExpress.XtraEditors.XtraForm
  {
    #region "variables"
    private CyberColor CyberColor = new CyberColor();
    private CyberFuncs CyberFunc = new CyberFuncs();
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
    private DataTable Dt_To;
    private DataTable Dt_Cd;
    private DataTable Dt_khoang;
    private DataTable Dt_KTV;
    private DataTable Dt_khoangH;
    private DataTable Dt_KTVH;
    private DataView Dv_khoang;
    private DataView Dv_KTV;
    private DataView Dv_khoangH;
    private DataView Dv_KTVH;
    private DataTable Dt_VT;
    private DataTable Dt_CV;
    private DataTable Dt_VTH;
    private DataTable Dt_CVH;
    private DataView Dv_VT;
    private DataView Dv_CV;
    private DataView Dv_VTH;
    private DataView Dv_CVH;
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

    public DataSet DsLoad { get; set; }
    public decimal ROId { get; set; }
    public decimal EventId { get; set; }
    public string EventType { get; set; }
    public string TType { get; set; }

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
      barWSUser.Caption = Globals.LoginUserName + " (" + Globals.LoginFullName + ")";
      barWSDealer.Caption = Globals.LoginDealerName + " (" + Globals.LoginDealerAbbr + " - " + Globals.LoginDealerCode + ")";

      V_LoadNgamDinh();
      V_Load();
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
      DataSet dataSet = JpcbJpBO.Instance().DetailDefault(Globals.LoginDlrId, "GJ"); // TODO:
      if (dataSet != null)
      {
        // Công đoạn cbb
        Dt_Cd = dataSet.Tables[0].Copy();
        CyberFunc.V_FillComBoxDefaul(CbbMa_CD, Dt_Cd, "Ma_Cd", "Ten_Cd", "Ngam_Dinh");

        // Tổ sửa chữa cbb
        Dt_To = dataSet.Tables[1].Copy();
        CyberFunc.V_FillComBoxDefaul(CbbMa_To, Dt_To, "Ma_To", "Ten_To", "Ngam_Dinh");

        // Khoang grid
        Dt_khoang = dataSet.Tables[2].Copy();
        Dt_khoangH = dataSet.Tables[3].Copy();
        Dv_khoang = new DataView(Dt_khoang);
        Dv_khoangH = new DataView(Dt_khoangH);
        GridView masterKhoangGrv = masterKhoangGRV;
        DataView dvKhoangH = Dv_khoangH;
        DataView dvKhoang = Dv_khoang;
        CyberFunc.V_FillReports(ref masterKhoangGrv, dvKhoangH, dvKhoang);
        masterKhoangGRV = masterKhoangGrv;
        masterKhoang.DataSource = Dv_khoang;

        // KTV grid
        Dt_KTV = dataSet.Tables[4].Copy();
        Dt_KTVH = dataSet.Tables[5].Copy();
        Dv_KTV = new DataView(Dt_KTV);
        Dv_KTVH = new DataView(Dt_KTVH);
        GridView masterKtvgrv = masterKTVGRV;
        DataView dvKtvh = Dv_KTVH;
        DataView dvKtv = Dv_KTV;
        CyberFunc.V_FillReports(ref masterKtvgrv, dvKtvh, dvKtv);
        masterKTVGRV = masterKtvgrv;
        masterKTV.DataSource = Dv_KTV;
      }
    }
    private void V_Load()
    {
      TxtMa_Xe.Enabled = M_Mode == "M";
      TxtSo_Ro.Enabled = M_Mode == "M";

      DataSet dataSet = JpcbJpBO.Instance().Detail(Globals.LoginDlrId, EventId, TType); // TODO:
      if (dataSet != null)
      {
        V_LoadVTCV("1");
      }
    }
    private void V_Ma_TO(object sender, EventArgs e)
    {

    }
    private void V_UpdateKTV_XN(string _Stt_Rec, string _Ma_Hs)
    {

    }
    private void V_SetKhoang()
    {
      int num = checked(Dv_khoang.Count - 1);
      int recordIndex = 0;
      while (recordIndex <= num)
      {
        if (TxtMa_KHoang.Text.ToString().Trim() == Dv_khoang[recordIndex]["Ma_Khoang"].ToString().Trim())
        {
          Dv_khoang[recordIndex].BeginEdit();
          Dv_khoang[recordIndex]["Tag"] = "1";
          Dv_khoang[recordIndex].EndEdit();
          break;
        }
        checked { ++recordIndex; }
      }
      masterKhoangGRV.UpdateCurrentRow();
    }
    private void V_AddHander()
    {
      CyberColumnGridView cyberColumnGridView1 = new CyberColumnGridView();
      CyberColumnGridView cyberColumnGridView2 = new CyberColumnGridView();
      CyberColumnGridView cyberColumnGridView3 = new CyberColumnGridView();
      CyberColumnGridView cyberColumnGridView4 = new CyberColumnGridView();
      CyberColumnGridView cyberColumnGridView5 = new CyberColumnGridView();
      EditkhoangTAG.GetColumn(masterKhoangGRV, "TAG");
      EditKTVTag.GetColumn(masterKTVGRV, "TAG");
      EditKTVChinh_Phu.GetColumn(masterKTVGRV, "Chinh_Phu");
      cyberColumnGridView1.GetColumn(masterKTVGRV, "Time_KTV");
      cyberColumnGridView2.GetColumn(masterKTVGRV, "Ngay_DB");
      cyberColumnGridView3.GetColumn(masterKTVGRV, "Ngay_KT");
      cyberColumnGridView4.GetColumn(masterKTVGRV, "Ngay_DB_TH");
      cyberColumnGridView5.GetColumn(masterKTVGRV, "Ngay_KT_TH");
      EditCVTag.GetColumn(MasterCVGRV, "TAG");
      EditCVMa_Ktv1.GetColumn(MasterCVGRV, "Ma_KTV1");
      EditCVMa_Ktv2.GetColumn(MasterCVGRV, "Ma_KTV2");
      EditCVTen_Ktv1.GetColumn(MasterCVGRV, "Ten_KTV1");
      EditCVTen_KTV2.GetColumn(MasterCVGRV, "Ten_KTV2");
      EditCVIs_GO.GetColumn(MasterCVGRV, "IS_GO");
      EditCVIs_SON.GetColumn(MasterCVGRV, "IS_SON");
      EditVTTag.GetColumn(MasterVtGRV, "TAG");
      EditKhoangXem_Hen.GetColumn(masterKhoangGRV, "Xem_Hen");
      EditKTVXem_Hen.GetColumn(masterKTVGRV, "Xem_Hen");
      EditKTVXN_BD.GetColumn(masterKTVGRV, "XN_BD");
      EditKTVXN_KT.GetColumn(masterKTVGRV, "XN_KT");
      CmdSave.Click += new EventHandler(V_Nhan);

      if (cyberColumnGridView1.Column != null)
        cyberColumnGridView1.EditColumn.EditValueChanged += new EventHandler(V_CLICK_Time_KTV);
      if (cyberColumnGridView2.Column != null)
        cyberColumnGridView2.EditColumn.Leave += new EventHandler(V_CLICK_Ngay_BD);
      if (cyberColumnGridView3.Column != null)
        cyberColumnGridView3.EditColumn.Leave += new EventHandler(V_CLICK_Ngay_KT);
      if (EditKTVTag.Column != null)
        EditKTVTag.EditColumn.EditValueChanged += new EventHandler(V_CLICK_KTV_tag);
      if (EditKTVChinh_Phu.Column != null)
        EditKTVTag.EditColumn.EditValueChanged += new EventHandler(V_CLICK_KTVChinh_Phu);
      if (EditKTVXN_BD.Column != null)
        EditKTVXN_BD.EditColumn.Click += new EventHandler(V_Xac_nhan_BD);
      if (EditKTVXN_KT.Column != null)
        EditKTVXN_KT.EditColumn.Click += new EventHandler(V_Xac_nhan_KT);
      if (EditkhoangTAG.Column != null)
        EditkhoangTAG.EditColumn.Click += new EventHandler(V_CLICK_Khoang_Tag);

      masterKTVGRV.PopupMenuShowing += new PopupMenuShowingEventHandler(masterKTVGRV_PopupMenuShowing);
      masterKhoangGRV.PopupMenuShowing += new PopupMenuShowingEventHandler(masterKhoangGRV_PopupMenuShowing);
      MasterCVGRV.PopupMenuShowing += new PopupMenuShowingEventHandler(masterCVGRV_PopupMenuShowing);
      masterKhoangGRV.RowCellStyle += new RowCellStyleEventHandler(Master_khoangGRV_RowCellStyle);
      masterKTVGRV.RowCellStyle += new RowCellStyleEventHandler(Master_KTVGRV_RowCellStyle);
      MasterCVGRV.RowCellStyle += new RowCellStyleEventHandler(Master_CVGRV_RowCellStyle);
      MasterVtGRV.RowCellStyle += new RowCellStyleEventHandler(Master_VTGRV_RowCellStyle);
      CbbMa_To.SelectedIndexChanged += new EventHandler(V_Ma_TO);
      CmdXem_LSSC.Click += new EventHandler(V_Lich_Su_SC);
      CmdXem_Giao_Xe.Click += new EventHandler(V_Xem_Giao_Xe);
      CmdGoi_Y_Khoang.Click += new EventHandler(V_Goi_Y_Khoang);
    }
    private void V_DragDropGridview()
    {
      _keothatrongGrid = new ObjectDragDrop(MasterCV, null);
      _keotha2Grid = new ObjectDragDrop(masterKTV, MasterCV);
      MasterCV.DragDrop += new DragEventHandler(Master_DragDrop);
    }
    private void V_Sub_SetColorCV()
    {
      int num = checked(Dt_CV.Rows.Count - 1);
      int index = 0;
      while (index <= num)
      {
        Dt_CV.Rows[index].BeginEdit();
        if (Dt_CV.Columns.Contains("Tag") & Dt_CV.Columns.Contains("Bold"))
        {
          if (Dt_CV.Rows[index]["Tag"].ToString().Trim() == "1")
          {
            Dt_CV.Rows[index]["Bold"] = "1";
            if (Dt_CV.Columns.Contains("backColor"))
              Dt_CV.Rows[index]["backColor"] = "Pink";
          }
          else if (Dt_CV.Columns.Contains("backColor"))
            Dt_CV.Rows[index]["backColor"] = "";
        }
        Dt_CV.Rows[index].EndEdit();
        Dt_CV.Rows[index].BeginEdit();
        if (Dt_CV.Columns.Contains("BackColor") & Dt_CV.Columns.Contains("Ma_KTV1"))
        {
          if (Dt_CV.Rows[index]["Ma_KTV1"].ToString().Trim() != "")
          {
            if (Dt_CV.Rows[index]["Tag"].ToString().Trim() != "1")
              Dt_CV.Rows[index]["BackColor"] = "YELLOW";
          }
          else if (Dt_CV.Rows[index]["Tag"].ToString().Trim() != "1")
            Dt_CV.Rows[index]["BackColor"] = "";
        }
        Dt_CV.Rows[index].EndEdit();
        checked { ++index; }
      }
      Dt_CV.AcceptChanges();
    }
    private void V_UpdateKhoang_KTV(string _ma_khoang)
    {

    }
    private void V_UpdateKTV_CV_All(int _Irow)
    {
      if (M_Loai_SC.Trim() != "1")
        return;

      int num = checked(Dv_CV.Count - 1);
      int recordIndex = 0;
      while (recordIndex <= num)
      {
        Dv_CV[recordIndex].BeginEdit();
        Dv_CV[recordIndex]["Tag"] = 1;
        Dv_CV[recordIndex]["Ma_KTV1"] = Dv_KTV[0]["Ma_Hs"].ToString();
        Dv_CV[recordIndex]["Ten_KTV1"] = Dv_KTV[0]["Ten_HS"].ToString();
        Dv_CV[recordIndex].EndEdit();
        MasterCVGRV.UpdateCurrentRow();
        checked { ++recordIndex; }
      }
      Dt_CV.AcceptChanges();
    }
    private void V_LoadVTCV(string status)
    {
      DataSet dataSet = JpcbJpBO.Instance().DetailJobsParts(ROId); // CP_RO_CVDV_KH_SCC_Load_VTCV
      if (dataSet != null)
      {
        int num1 = checked(dataSet.Tables.Count - 1);
        int index1 = 0;
        while (index1 <= num1)
        {
          CyberFunc.SetNotNullTable(dataSet.Tables[index1]);
          checked { ++index1; }
        }
        if (status.ToUpper().Trim() == "1")
        {
          Dt_CV = dataSet.Tables[0].Copy();
          Dt_VT = dataSet.Tables[1].Copy();
          Dt_CVH = dataSet.Tables[2].Copy();
          Dt_VTH = dataSet.Tables[3].Copy();
          Dv_CV = new DataView(Dt_CV);
          Dv_VT = new DataView(Dt_VT);
          Dv_CVH = new DataView(Dt_CVH);
          Dv_VTH = new DataView(Dt_VTH);
          dataSet.Dispose();

          MasterCV.DataSource = Dt_CV;
          GridView masterCvgrv = MasterCVGRV;
          DataView dvCvh = Dv_CVH;
          DataView dvCv = Dv_CV;
          CyberFunc.V_FillReports(ref masterCvgrv, dvCvh, dvCv);
          MasterCVGRV = masterCvgrv;

          MasterVt.DataSource = Dt_VT;
          GridView masterVtGrv = MasterVtGRV;
          DataView dvVth = Dv_VTH;
          DataView dvVt = Dv_VT;
          CyberFunc.V_FillReports(ref masterVtGrv, dvVth, dvVt);
          MasterVtGRV = masterVtGrv;
        }
        else
        {
          Dt_CV.Clear();
          int num2 = checked(dataSet.Tables[0].Rows.Count - 1);
          int index2 = 0;
          while (index2 <= num2)
          {
            Dt_CV.ImportRow(dataSet.Tables[0].Rows[index2]);
            checked { ++index2; }
          }
          Dt_CV.AcceptChanges();
          Dt_VT.Clear();
          int num3 = checked(dataSet.Tables[1].Rows.Count - 1);
          int index3 = 0;
          while (index3 <= num3)
          {
            Dt_VT.ImportRow(dataSet.Tables[1].Rows[index3]);
            checked { ++index3; }
          }
          Dt_VT.AcceptChanges();
          dataSet.Dispose();
        }
      }
    }
    private void Master_DragDrop(object sender, DragEventArgs e)
    {
      GridControl gridControl = sender as GridControl;
      GridView mainView = gridControl.MainView as GridView;
      if (!(e.Data.GetData(typeof(DataRow)) is DataRow data))
        return;

      GridHitInfo gridHitInfo = mainView.CalcHitInfo(gridControl.PointToClient(new Point(e.X, e.Y)));
      int rowHandle = gridHitInfo.RowHandle;
      if (rowHandle < 0)
        return;

      string str1 = "";
      try
      {
        str1 = gridHitInfo.Column.FieldName.ToUpper().Trim();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }

      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = true;
      if (EditCVMa_Ktv1 != null)
        flag1 = true;
      if (flag1 && EditCVMa_Ktv2 != null)
        flag2 = true;
      if (!flag1)
        return;

      if ((str1.Trim().ToUpper() == "MA_KTV2" | str1.Trim().ToUpper() == "TEN_KTV2") & str1.Trim() != "")
        flag3 = false;
      if (!flag2)
        flag3 = true;

      Dv_CV[rowHandle]["Stt_rec_RO"].ToString().Trim();
      Dv_CV[rowHandle]["Stt_rec_RO"].ToString().Trim();
      string str2 = data["ma_Hs"].ToString().Trim();
      string str3 = data["Ten_Hs"].ToString().Trim();
      if (data["Tag"].ToString().Trim().Trim().Trim() != "1")
        return;

      Dv_CV.BeginInit();
      if (flag1 & flag2)
      {
        if (flag3)
        {
          Dv_CV[rowHandle]["Ma_KTV1"] = str2;
          Dv_CV[rowHandle]["ten_KTV1"] = str3;
        }
        else
        {
          Dv_CV[rowHandle]["Ma_KTV2"] = str2;
          Dv_CV[rowHandle]["ten_KTV2"] = str3;
        }
      }
      else
      {
        Dv_CV[rowHandle]["Ma_KTV1"] = str2;
        Dv_CV[rowHandle]["ten_KTV1"] = str3;
      }
      Dv_CV.EndInit();
      Dt_CV.AcceptChanges();

      int num = checked(Dt_CV.Rows.Count - 1);
      int index = 0;
      while (index <= num)
      {
        if (flag3)
        {
          if (Dt_CV.Rows[index]["Ma_KTV1"].ToString().Trim() == "")
          {
            Dt_CV.Rows[index]["Ma_KTV1"] = str2;
            Dt_CV.Rows[index]["Ten_KTV1"] = str3;
          }
        }
        else if (Dt_CV.Rows[index]["Ma_KTV2"].ToString().Trim() == "")
        {
          Dt_CV.Rows[index]["Ma_KTV2"] = str2;
          Dt_CV.Rows[index]["Ten_KTV2"] = str3;
        }
        checked { ++index; }
      }

      Dt_CV.AcceptChanges();
      V_Sub_SetColorCV();
      _keothatrongGrid._ActiDraDrop = false;
      _keotha2Grid._ActiDraDrop = false;
    }
    #endregion

    #region "V_AddHander"
    private void V_Nhan(object sender, EventArgs e)
    {

    }
    private void V_CLICK_Time_KTV(object sender, EventArgs e)
    {
      masterKTVGRV.PostEditor();
      masterKTVGRV.UpdateCurrentRow();
      int dataSourceRowIndex = masterKhoangGRV.GetFocusedDataSourceRowIndex();
      masterKTVGRV.UpdateCurrentRow();
      if (dataSourceRowIndex >= 0)
        V_Update_Nggay_BD_Ngay_KT(dataSourceRowIndex);
      masterKTVGRV.UpdateCurrentRow();
    }
    private void V_Update_Nggay_BD_Ngay_KT(int iRow)
    {

    }
    private void V_CLICK_Ngay_BD(object sender, EventArgs e)
    {
      masterKTVGRV.PostEditor();
      masterKTVGRV.UpdateCurrentRow();
      int dataSourceRowIndex = masterKhoangGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex >= 0)
        V_Update_Nggay_BD_Ngay_KT(dataSourceRowIndex);
      masterKTVGRV.UpdateCurrentRow();
    }
    private void V_CLICK_Ngay_KT(object sender, EventArgs e)
    {
      masterKTVGRV.PostEditor();
      masterKTVGRV.UpdateCurrentRow();
      int dataSourceRowIndex = masterKhoangGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex >= 0)
        V_Update_Nggay_BD_Ngay_KT(dataSourceRowIndex);
      masterKTVGRV.UpdateCurrentRow();
    }
    private void V_CLICK_KTV_tag(object sender, EventArgs e)
    {
      masterKTVGRV.PostEditor();
      masterKTVGRV.UpdateCurrentRow();
      int dataSourceRowIndex = masterKTVGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex >= 0)
        V_Update_Nggay_BD_Ngay_KT(dataSourceRowIndex);
      masterKTVGRV.UpdateCurrentRow();
      V_UpdateKTV_CV(dataSourceRowIndex);
    }
    private void V_UpdateKTV_CV(int _Irow)
    {
      int num1 = checked(Dv_KTV.Count - 1);
      int recordIndex1 = 0;
      while (recordIndex1 <= num1)
      {
        if (Dv_KTV[recordIndex1]["tag"].ToString() == "1" & Dv_KTV[recordIndex1]["Chinh_Phu"].ToString() == "1")
        {
          int num2 = checked(Dv_CV.Count - 1);
          int recordIndex2 = 0;
          while (recordIndex2 <= num2)
          {
            if (Dv_CV[recordIndex2]["Tag"].ToString().Trim() == "1" & Dv_CV[recordIndex2]["Ma_KTV1"].ToString() == "")
            {
              Dv_CV[recordIndex2].BeginEdit();
              Dv_CV[recordIndex2]["Ma_KTV1"] = (object)Dv_KTV[recordIndex1]["Ma_Hs"].ToString();
              Dv_CV[recordIndex2]["Ten_KTV1"] = (object)Dv_KTV[recordIndex1]["Ten_HS"].ToString();
              Dv_CV[recordIndex2].EndEdit();
            }
            MasterCVGRV.UpdateCurrentRow();
            checked { ++recordIndex2; }
          }
          break;
        }
        checked { ++recordIndex1; }
      }
      Dt_CV.AcceptChanges();
    }
    private void V_CLICK_KTVChinh_Phu(object sender, EventArgs e)
    {
      masterKTVGRV.PostEditor();
      masterKTVGRV.UpdateCurrentRow();
      int dataSourceRowIndex = masterKTVGRV.GetFocusedDataSourceRowIndex();
      masterKTVGRV.UpdateCurrentRow();
      V_UpdateKTV_CV(dataSourceRowIndex);
    }
    private void V_Xac_nhan_BD(object sender, EventArgs e)
    {
      if (M_Mode == "M")
        return;

      int dataSourceRowIndex = masterKTVGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0 || Dv_KTV[dataSourceRowIndex]["XN_BD"].ToString().Trim() != "" && 
          !FormGlobals.Message_Confirm("Bạn có xác nhận bắt đầu không?", false) || 
          Dv_KTV[dataSourceRowIndex]["Tag"].ToString().Trim() != "1")
        return;

      string _Ma_Hs = Dv_KTV[dataSourceRowIndex]["ma_HS"].ToString().Trim();
      if (_Ma_Hs.Trim() == "")
        return;

      string _StrKTV = "INSERT DMKTVCYBER SELECT N'" + _Ma_Hs + "'";
      string _Loai_XN = "BD";
      string text2 = TxtStt_Rec.Text;

      V_Thuc_Hien_XN(TxtStt_Rec.Text, _Ma_Hs);
    }
    private void V_Thuc_Hien_XN(string _Stt_Rec, string _Ma_Hs)
    {
      DataSet dataSet = new DataSet(); // CP_RO_CVDV_KH_SCC_Load_XN
      int num1 = checked(dataSet.Tables.Count - 1);
      int index1 = 0;
      while (index1 <= num1)
      {
        CyberFunc.SetNotNullTable(dataSet.Tables[index1]);
        checked { ++index1; }
      }
      if (dataSet.Tables.Count == 0)
        return;

      if (dataSet.Tables.Count >= 2)
        Dv_KTV.RowFilter = "1=1";

      int num2 = checked(dataSet.Tables[0].Rows.Count - 1);
      int index2 = 0;
      while (index2 <= num2)
      {
        int num3 = checked(Dv_KTV.Count - 1);
        int num4 = 0;
        while (num4 <= num3)
        {
          if (dataSet.Tables[0].Rows[index2]["Ma_Hs"].ToString().Trim() == Dv_KTV[num4]["Ma_Hs"].ToString().Trim())
          {
            CyberFunc.V_UpdateRowtoRow(dataSet.Tables[0].Rows[index2], Dv_KTV, num4);
            break;
          }
          checked { ++num4; }
        }
        checked { ++index2; }
      }
      string str = "1=1";
      string Left = CyberFunc.V_GetvalueCombox(CbbMa_To);
      if (Left != "")
        str = "Ma_To = '" + Left + "'";
      Dv_KTV.RowFilter = str;
      Dt_KTV.AcceptChanges();
      masterKTVGRV.UpdateCurrentRow();
    }
    private void V_Xac_nhan_KT(object sender, EventArgs e)
    {
      if (M_Mode == "M")
        return;

      int dataSourceRowIndex = masterKTVGRV.GetFocusedDataSourceRowIndex();
      if (dataSourceRowIndex < 0 || Dv_KTV[dataSourceRowIndex]["XN_KT"].ToString().Trim() != "" && 
          !FormGlobals.Message_Confirm("Bạn có xác nhận kết thúc không?", false) || 
          Dv_KTV[dataSourceRowIndex]["Tag"].ToString().Trim() != "1")
        return;

      string _Ma_Hs = Dv_KTV[dataSourceRowIndex]["ma_HS"].ToString().Trim();
      if (_Ma_Hs.Trim() == "")
        return;

      string _StrKTV = "INSERT DMKTVCYBER SELECT N'" + _Ma_Hs + "'";
      string _Loai_XN = "KT";
      string text2 = TxtStt_Rec.Text;

      V_Thuc_Hien_XN(TxtStt_Rec.Text, _Ma_Hs);
    }
    private void V_CLICK_Khoang_Tag(object sender, EventArgs e)
    {
      masterKhoangGRV.PostEditor();
      int dataSourceRowIndex = masterKhoangGRV.GetFocusedDataSourceRowIndex();
      string _Strkhoang = "";
      int num1 = checked(Dv_khoang.Count - 1);
      int num2 = 0;
      while (num2 <= num1)
      {
        Dv_khoang[num2].BeginEdit();
        if (num2 != dataSourceRowIndex)
        {
          Dv_khoang[num2]["TAG"] = (object)"0";
          if (Dt_khoang.Columns.Contains("BackColor"))
            Dv_khoang[num2]["BackColor"] = (object)"";
          if (Dt_khoang.Columns.Contains("BackColor2"))
            Dv_khoang[num2]["BackColor2"] = (object)"";
          if (Dt_khoang.Columns.Contains("ForeColor"))
            Dv_khoang[num2]["ForeColor"] = (object)"";
        }
        else
        {
          if (Dt_khoang.Columns.Contains("BackColor"))
            Dv_khoang[num2]["backColor"] = (object)"Pink";
          _Strkhoang = "INSERT Dmkhoang SELECT N'" + Dt_khoang.Rows[num2]["ma_khoang"].ToString() + "'";
        }
        Dv_khoang[num2].EndEdit();
        checked { ++num2; }
      }
      Dt_khoang.AcceptChanges();
      masterKhoangGRV.UpdateCurrentRow();
      if (_Strkhoang.Trim() != "" & dataSourceRowIndex >= 0)
      {
        DataRow _Dr = V_Goi_Y_Khoang(_Strkhoang);
        if (_Dr == null || !_Dr.Table.Columns.Contains("Ma_khoang") ||  _Dr["Ma_khoang"].ToString().Trim().Trim() == "")
          return;

        CyberFunc.V_UpdateRowtoRow(_Dr, Dt_khoang, dataSourceRowIndex);
        masterKhoangGRV.UpdateCurrentRow();
      }
      V_UpdateKhoang_KTV(Dv_khoang[dataSourceRowIndex]["Ma_khoang"].ToString().Trim());
      V_UpdateKTV_CV(-1);
    }
    private DataRow V_Goi_Y_Khoang(string _Strkhoang)
    {
      string text1 = TxtMa_Xe.Text;
      string text2 = TxtSo_Ro.Text;
      string text3 = TxtStt_Rec.Text;

      if (_Strkhoang == "")
      {
        FormGlobals.Message_Warning("Bạn chưa chọn khoang để thực hiện");
        return (DataRow)null;
      }

      DataSet dataSet = new DataSet();
      int num1 = checked(dataSet.Tables.Count - 1);
      int index1 = 0;
      while (index1 <= num1)
      {
        CyberFunc.SetNotNullTable(dataSet.Tables[index1]);
        checked { ++index1; }
      }
      int index2 = checked(dataSet.Tables.Count - 1);
      if (index2 < 1)
      {
        dataSet.Dispose();
        return (DataRow)null;
      }
      if (dataSet.Tables[0].Rows.Count == 0)
        return (DataRow)null;

      DataRow row = dataSet.Tables[0].Copy().Rows[0];
      dataSet.Dispose();
      return row;
    }
    private void V_Lich_Su_SC(object sender, EventArgs e)
    {

    }
    private void V_Xem_Giao_Xe(object sender, EventArgs e)
    {

    }
    private void V_Goi_Y_Khoang(object sender, EventArgs e)
    {
      string str1 = "";
      DataRow[] dataRowArray = Dt_khoang.Select("tag ='1'");
      bool flag = false;
      if (dataRowArray.Length < 1)
      {
        flag = true;
        int num = checked(Dt_khoang.Rows.Count - 1);
        int index = 0;
        while (index <= num)
        {
          Dt_khoang.Rows[index].BeginEdit();
          Dt_khoang.Rows[index]["Tag"] = (object)"0";
          Dt_khoang.Rows[index].EndEdit();
          checked { ++index; }
        }
      }
      Dt_khoang.AcceptChanges();
      int num1 = checked(Dt_khoang.Rows.Count - 1);
      int index1 = 0;
      while (index1 <= num1)
      {
        if (Dt_khoang.Rows[index1]["tag"].ToString() == "1" | flag)
          str1 = str1 + ";INSERT Dmkhoang SELECT N'" + Dt_khoang.Rows[index1]["ma_khoang"].ToString() + "'";
        checked { ++index1; }
      }
      if (str1 == "")
      {
        FormGlobals.Message_Warning("Bạn chưa chọn khoang để thực hiện");
      }
      else
      {
        DataRow _Dr = V_Goi_Y_Khoang(str1);
        if (_Dr == null || !_Dr.Table.Columns.Contains("Ma_khoang"))
          return;

        string str2 = _Dr["Ma_khoang"].ToString().Trim();
        if (str2.Trim() == "")
          return;

        int num3 = checked(Dt_khoang.Rows.Count - 1);
        int num4 = 0;
        while (num4 <= num3)
        {
          Dt_khoang.Rows[num4].BeginEdit();
          if (Dt_khoang.Rows[num4]["Ma_khoang"].ToString().Trim() != str2.Trim().ToUpper())
          {
            Dt_khoang.Rows[num4]["Tag"] = (object)"0";
          }
          else
          {
            CyberFunc.V_UpdateRowtoRow(_Dr, Dt_khoang, num4);
            Dt_khoang.Rows[num4]["Tag"] = (object)"1";
          }
          Dt_khoang.Rows[num4].EndEdit();
          checked { ++num4; }
        }
      }
    }
    private void masterKTVGRV_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
    {
      int rowHandle = e != null ? e.HitInfo.RowHandle : -1;
      PopupMenuMasterGrid.ItemLinks.Clear();

      PopupMenuMasterGrid.ItemLinks.Add(
        new CyberMenuPopup(sender, rowHandle, "Chọn tất", 
        new EventHandler(V_SelectKTVAll), Shortcut.CtrlA), true);

      PopupMenuMasterGrid.ItemLinks.Add(
        new CyberMenuPopup(sender, rowHandle, "Gỡ chọn", 
        new EventHandler(V_RemoveKTVAll), Shortcut.CtrlU), false);
      
      if (EditKTVXN_BD != null)
        PopupMenuMasterGrid.ItemLinks.Add(
          new CyberMenuPopup(sender, rowHandle, "Xác nhận bắt đầu tất cả các KTV", 
          new EventHandler(V_Xac_nhan_BDAll), Shortcut.CtrlB), true);
     
      if (EditKTVXN_BD != null)
        PopupMenuMasterGrid.ItemLinks.Add(
          new CyberMenuPopup((GridView)sender, rowHandle, "Xác nhận kết thúc tất cả các KTV", 
          new EventHandler(V_Xac_nhan_KTAll), Shortcut.CtrlK), false);
      
      if (e == null)
        return;

      PopupMenuMasterGrid.ShowPopup(MousePosition);
    }
    private void masterKhoangGRV_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
    {
      int rowHandle = e != null ? e.HitInfo.RowHandle : -1;
      PopupMenuMasterGrid.ItemLinks.Clear();

      PopupMenuMasterGrid.ItemLinks.Add(
        new CyberMenuPopup(sender, rowHandle, "Chọn tất", 
        new EventHandler(V_SelectkhoangAll), Shortcut.CtrlA), true);
      PopupMenuMasterGrid.ItemLinks.Add(
        new CyberMenuPopup(sender, rowHandle, "Gỡ chọn", 
        new EventHandler(V_RemovekhoangAll), Shortcut.CtrlU), false);
      
      if (e == null)
        return;

      PopupMenuMasterGrid.ShowPopup(Control.MousePosition);
    }
    private void masterCVGRV_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
    {
      int rowHandle = e != null ? e.HitInfo.RowHandle : -1;
      PopupMenuMasterGrid.ItemLinks.Clear();

      PopupMenuMasterGrid.ItemLinks.Add(
        new CyberMenuPopup(sender, rowHandle, "Chọn tất", 
        new EventHandler(V_SelectCVAll), Shortcut.CtrlA), true);
      PopupMenuMasterGrid.ItemLinks.Add(
        new CyberMenuPopup(sender, rowHandle, "Gỡ chọn", 
        new EventHandler(V_RemoveCVAll), Shortcut.CtrlU), false);
      
      if (e == null)
        return;

      PopupMenuMasterGrid.ShowPopup(Control.MousePosition);
    }
    private void Master_khoangGRV_RowCellStyle(object sender, RowCellStyleEventArgs e) => GRV_RowCellStyle(sender, e, masterKhoangGRV, _Bold_khoang, _BackColor_Khoang, _BackColor2_Khoang, _Forecolor_Khoang, _FieldBold_Khoang, _FieldBackColor_Khoang, _FieldBackColor2_Khoang, _FieldForecolor_Khoang);
    private void Master_KTVGRV_RowCellStyle(object sender, RowCellStyleEventArgs e) => GRV_RowCellStyle(sender, e, masterKTVGRV, _Bold_KTV, _BackColor_KTV, _BackColor2_KTV, _Forecolor_KTV, _FieldBold_KTV, _FieldBackColor_KTV, _FieldBackColor2_KTV, _FieldForecolor_KTV);
    private void Master_CVGRV_RowCellStyle(object sender, RowCellStyleEventArgs e) => GRV_RowCellStyle(sender, e, MasterCVGRV, _Bold_CV, _BackColor_CV, _BackColor2_CV, _Forecolor_CV, _FieldBold_CV, _FieldBackColor_CV, _FieldBackColor2_CV, _FieldForecolor_CV);
    private void Master_VTGRV_RowCellStyle(object sender, RowCellStyleEventArgs e) => GRV_RowCellStyle(sender, e, MasterVtGRV, _Bold_VT, _BackColor_VT, _BackColor2_VT, _Forecolor_VT, _FieldBold_VT, _FieldBackColor_VT, _FieldBackColor2_VT, _FieldForecolor_VT);
    private void GRV_RowCellStyle(object sender, RowCellStyleEventArgs e, GridView _GRV, bool _Bold, bool _BackColor, bool _BackColor2, bool _Forecolor, string _FieldBold, string _FieldBackColor, string _FieldBackColor2, string _FieldForecolor)
    {
      GridView view = sender as GridView;
      if (!view.IsCellSelected(e.RowHandle, e.Column))
      {
        if (_Bold && _GRV.GetRowCellDisplayText(e.RowHandle, _FieldBold).ToString().Trim() == "1")
          e.Appearance.Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
        if (_BackColor)
        {
          string ColorName = _GRV.GetRowCellDisplayText(e.RowHandle, _FieldBackColor).ToString().Trim();
          e.Appearance.BackColor = CyberColor.GetBacColorkReports(ColorName);
        }
        if (_BackColor2)
        {
          string ColorName = _GRV.GetRowCellDisplayText(e.RowHandle, _FieldBackColor2).ToString().Trim();
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

    #region "PopupMenu"
    private void V_SelectKTVAll(object sender, EventArgs e)
    {
      int num = checked(Dv_KTV.Count - 1);
      int recordIndex = 0;
      while (recordIndex <= num)
      {
        if (Dt_KTV.Columns.Contains("Tag"))
        {
          Dv_KTV[recordIndex].BeginEdit();
          Dv_KTV[recordIndex]["Tag"] = (object)"1";
          Dv_KTV[recordIndex].EndEdit();
          masterKTVGRV.UpdateCurrentRow();
        }
        checked { ++recordIndex; }
      }
      Dt_KTV.AcceptChanges();
      masterKTVGRV.UpdateCurrentRow();
    }
    private void V_RemoveKTVAll(object sender, EventArgs e)
    {
      int num = checked(Dv_KTV.Count - 1);
      int recordIndex = 0;
      while (recordIndex <= num)
      {
        if (Dt_KTV.Columns.Contains("Tag"))
        {
          Dv_KTV[recordIndex].BeginEdit();
          Dv_KTV[recordIndex]["Tag"] = (object)"0";
          Dv_KTV[recordIndex].EndEdit();
          masterKTVGRV.UpdateCurrentRow();
        }
        checked { ++recordIndex; }
      }
      Dt_KTV.AcceptChanges();
      masterKTVGRV.UpdateCurrentRow();
    }
    private void V_Xac_nhan_BDAll(object sender, EventArgs e)
    {
      if (M_Mode == "M" || !FormGlobals.Message_Confirm("Bạn có xác nhận bắt đầu không?", false))
        return;

      string _StrKTV = "";
      int num = checked(Dv_KTV.Count - 1);
      int recordIndex = 0;
      while (recordIndex <= num)
      {
        if (Dv_KTV[recordIndex]["tag"].ToString().Trim() == "1")
          _StrKTV = _StrKTV + ";INSERT DMKTVCYBER SELECT N'" + Dv_KTV[recordIndex]["ma_HS"].ToString().Trim() + "'";
        checked { ++recordIndex; }
      }
      if (_StrKTV.Trim() == "")
        return;

      string _Loai_XN = "BD";
      string text2 = TxtStt_Rec.Text;

      V_Thuc_Hien_XN(TxtStt_Rec.Text, "");
    }
    private void V_Xac_nhan_KTAll(object sender, EventArgs e)
    {
      if (!FormGlobals.Message_Confirm("Bạn có xác nhận kết thúc không?", false))
        return;

      string _StrKTV = "";
      int num = checked(Dv_KTV.Count - 1);
      int recordIndex = 0;
      while (recordIndex <= num)
      {
        if (Dv_KTV[recordIndex]["tag"].ToString().Trim() == "1")
          _StrKTV = _StrKTV + ";INSERT DMKTVCYBER SELECT N'" + Dv_KTV[recordIndex]["ma_HS"].ToString().Trim() + "'";
        checked { ++recordIndex; }
      }
      if (_StrKTV.Trim() == "")
        return;

      string _Loai_XN = "KT";
      string text2 = TxtStt_Rec.Text;

      V_Thuc_Hien_XN(TxtStt_Rec.Text, "");
    }
    private void V_SelectkhoangAll(object sender, EventArgs e)
    {
      int num = checked(Dv_khoang.Count - 1);
      int recordIndex = 0;
      while (recordIndex <= num)
      {
        if (Dt_khoang.Columns.Contains("Tag"))
        {
          Dv_khoang[recordIndex].BeginEdit();
          Dv_khoang[recordIndex]["Tag"] = (object)"1";
          Dv_khoang[recordIndex].EndEdit();
          masterKhoangGRV.UpdateCurrentRow();
        }
        checked { ++recordIndex; }
      }
      Dt_khoang.AcceptChanges();
      masterKhoangGRV.UpdateCurrentRow();
    }
    private void V_RemovekhoangAll(object sender, EventArgs e)
    {
      int num = checked(Dv_khoang.Count - 1);
      int recordIndex = 0;
      while (recordIndex <= num)
      {
        if (Dt_khoang.Columns.Contains("Tag"))
        {
          Dv_khoang[recordIndex].BeginEdit();
          Dv_khoang[recordIndex]["Tag"] = (object)"0";
          Dv_khoang[recordIndex].EndEdit();
          masterKhoangGRV.UpdateCurrentRow();
        }
        checked { ++recordIndex; }
      }
      Dt_khoang.AcceptChanges();
      masterKhoangGRV.UpdateCurrentRow();
    }
    private void V_SelectCVAll(object sender, EventArgs e)
    {
      int num = checked(Dv_CV.Count - 1);
      int recordIndex = 0;
      while (recordIndex <= num)
      {
        if (Dt_CV.Columns.Contains("Tag"))
        {
          Dv_CV[recordIndex].BeginEdit();
          Dv_CV[recordIndex]["Tag"] = "1";
          Dv_CV[recordIndex].EndEdit();
          MasterCVGRV.UpdateCurrentRow();
        }
        checked { ++recordIndex; }
      }
      Dt_CV.AcceptChanges();
      MasterCVGRV.UpdateCurrentRow();
    }
    private void V_RemoveCVAll(object sender, EventArgs e)
    {
      int num = checked(Dv_CV.Count - 1);
      int recordIndex = 0;
      while (recordIndex <= num)
      {
        if (Dt_CV.Columns.Contains("Tag"))
        {
          Dv_CV[recordIndex].BeginEdit();
          Dv_CV[recordIndex]["Tag"] = "0";
          Dv_CV[recordIndex].EndEdit();
          MasterCVGRV.UpdateCurrentRow();
        }
        checked { ++recordIndex; }
      }
      Dt_CV.AcceptChanges();
      MasterCVGRV.UpdateCurrentRow();
    }
    #endregion
  }
}