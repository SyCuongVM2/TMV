using System;
using System.Data;
using System.Windows.Forms;
using TMV.BusinessObject.JPCB;
using TMV.Common;
using TMV.Common.Forms;
using TMV.UI.JPCB.Common;

namespace TMV.UI.JPCB.CW
{
  public partial class frmCWPlan : DevExpress.XtraEditors.XtraForm
  {
    #region "variables"
    private CyberFuncs CyberFunc = new CyberFuncs();
    private CalcTime calcTime = new CalcTime();
    private string M_Loai_SC = "1";
    public DataTable Dt_Return;
    private DataTable Dt_Khoang;

    public frmCWPlan()
    {
      InitializeComponent();
    }
    #endregion

    public string Mode { get; set; }
    public decimal Id { get; set; }
    public int IdKhoang { get; set; }
    public string MaKhoang { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int BuocNhay { get; set; }

    public bool ShowForm()
    {
      frmProgress.Instance().Thread = new MethodInvoker(InitForm);
      frmProgress.Instance().Show_Progress();
      return (ShowDialog() == DialogResult.OK);
    }
    private void InitForm()
    {
      if (Mode.Trim() == "M")
      {
        Text = "Tạo mới/New";
        V_SetDefault();
      }
      else
      {
        Text = "Sửa KH/Edit";
        V_LoadData();
      }
      V_AddHandler();
    }
    private void V_LoadData()
    {
      try
      {
        DataSet ds = JpcbCwBO.Instance().GetCWDetail(Globals.LoginDlrId, Id);
        if (ds.Tables != null & ds.Tables.Count > 0)
        {
          DateTime? date_kt_ro;
          DateTime? date_hen_kt_ro;
          Dt_Khoang = ds.Tables[0];
          Dt_Return = ds.Tables[1];
          CyberFunc.V_FillComBoxDefaul(CbbMa_khoang, Dt_Khoang, "Id_khoang", "Ma_khoang");
          CbbMa_khoang.SelectedValue = IdKhoang;

          ChkDat_them.Enabled = false;
          ChkDat_them.Checked = false;

          TxtMa_Xe.Text = Dt_Return.Rows[0]["Ma_Xe"].ToString().Trim();
          TxtMa_Xe.Enabled = false;
          TxtTG_SC.Value = BuocNhay;
          TxtNgay_BD.EditValue = StartTime;
          TxtNgay_KT.EditValue = EndTime;

          TxtNgay_BD_RO.EditValue = Convert.ToDateTime(Dt_Return.Rows[0]["Ngay_BD_Ro"].ToString().Trim());
          TxtNgay_BD_RO.Enabled = false;
          if (Dt_Return.Rows[0]["Ngay_KT_Ro"].ToString() != "")
            date_kt_ro = Convert.ToDateTime(Dt_Return.Rows[0]["Ngay_KT_Ro"].ToString().Trim());
          else
            date_kt_ro = null;
          TxtNgay_KT_RO.EditValue = date_kt_ro;
          TxtNgay_KT_RO.Enabled = false;
          if (Dt_Return.Rows[0]["Ngay_henKT_Ro"].ToString() != "")
            date_hen_kt_ro = Convert.ToDateTime(Dt_Return.Rows[0]["Ngay_henKT_Ro"].ToString().Trim());
          else
            date_hen_kt_ro = null;
          TxtNgay_henKT_RO.EditValue = date_hen_kt_ro;
          TxtNgay_henKT_RO.Enabled = false;

          TxtSo_Ro.Text = Dt_Return.Rows[0]["So_RO"].ToString().Trim();
          TxtSo_Ro.Enabled = false;
          TxtLoai_SC.Text = M_Loai_SC;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("V_LoadData: " + ex.Message);
      }
    }
    private void V_SetDefault()
    {
      DataSet ds = JpcbCwBO.Instance().GetCWWorkshops(Globals.LoginDlrId, "CW");
      if (ds.Tables != null)
      {
        Dt_Khoang = ds.Tables[0];
        CyberFunc.V_FillComBoxDefaul(CbbMa_khoang, Dt_Khoang, "Id_khoang", "Ma_khoang");
        CbbMa_khoang.SelectedValue = IdKhoang;
      }

      ChkDat_them.Enabled = false;
      ChkDat_them.Checked = true;

      TxtMa_Xe.Focus();
      TxtTG_SC.Value = BuocNhay;
      TxtNgay_BD.EditValue = StartTime;
      var val = calcTime.CalcCloneRepairTime(Convert.ToInt32(TxtTG_SC.Value), StartTime);
      TxtNgay_KT.EditValue = val.EndPlanTime;

      TxtNgay_BD_RO.Visible = false;
      lblNgay_BD_RO.Visible = false;
      TxtNgay_KT_RO.Visible = false;
      lblNgay_KT_RO.Visible = false;
      TxtNgay_henKT_RO.Visible = false;
      lblNgay_henKT_RO.Visible = false;
      TxtSo_Ro.Visible = false;
      lblSo_RO.Visible = false;
      TxtLoai_SC.Text = M_Loai_SC;
    }
    private void V_AddHandler()
    {
      TxtTG_SC.Leave += new EventHandler(V_TG_SC);
      TxtNgay_BD.Leave += new EventHandler(V_Ngay_BD);
      TxtNgay_KT.Leave += new EventHandler(V_Ngay_KT);
      btnSave.Click += new EventHandler(V_Nhan);
      btnClose.Click += new EventHandler(V_Close);
    }

    private void V_Ngay_BD(object sender, EventArgs e)
    {
      DateTime date1 = Convert.ToDateTime(TxtNgay_BD.EditValue);
      if (TxtTG_SC.Value > 0)
      {
        var val = calcTime.CalcCloneRepairTime(Convert.ToInt32(TxtTG_SC.Value), date1);
        TxtNgay_KT.EditValue = val.EndPlanTime;
      }

      DateTime date2 = Convert.ToDateTime(TxtNgay_KT.EditValue);
      DataSet ds = JpcbCwBO.Instance().CalcWorkingTime(Globals.LoginDlrId, date1, date2);
      if (ds.Tables != null & ds.Tables.Count > 0)
        TxtTG_SC.Value = Convert.ToInt32(ds.Tables[0].Rows[0]["TG_SC"]);
    }
    private void V_Ngay_KT(object sender, EventArgs e)
    {
      DataSet ds = JpcbCwBO.Instance().CalcWorkingTime(Globals.LoginDlrId, Convert.ToDateTime(TxtNgay_BD.EditValue), Convert.ToDateTime(TxtNgay_KT.EditValue));
      if (ds.Tables != null & ds.Tables.Count > 0)
        TxtTG_SC.Value = Convert.ToInt32(ds.Tables[0].Rows[0]["TG_SC"]);
    }
    private void V_TG_SC(object sender, EventArgs e)
    {
      DateTime date = Convert.ToDateTime(TxtNgay_BD.EditValue);

      if (TxtTG_SC.Value <= 0)
        TxtTG_SC.Value = 8;
      if (!(TxtTG_SC.Value == 8 | TxtTG_SC.Value == 10 | TxtTG_SC.Value == 15 | TxtTG_SC.Value == 20 | TxtTG_SC.Value == 25 | TxtTG_SC.Value == 30))
        TxtTG_SC.Value = 8;

      var val = calcTime.CalcCloneRepairTime(Convert.ToInt32(TxtTG_SC.Value), date);
      TxtNgay_KT.EditValue = val.EndPlanTime;
    }
    private void V_Nhan(object sender, EventArgs e)
    {
      if (Mode.Trim() == "M")
      {
        TxtMa_Xe.Text = CyberFunc.V_FormatBien_So(TxtMa_Xe.Text, true);
        if (TxtMa_Xe.Text.Trim() != "")
        {
          FormGlobals.Message_Warning_Error("Please input valid Register No!");
          return;
        }
        if (Convert.ToDateTime(TxtNgay_BD.EditValue) <= Convert.ToDateTime(TxtNgay_KT.EditValue))
        {
          FormGlobals.Message_Warning_Error("From Time cannot <= To Time!");
          return;
        }

        DataSet ds = JpcbCwBO.Instance().AddOrUpdateCW(Globals.LoginUserID, Globals.LoginDlrId, "N",
                                                       CyberFunc.V_FormatBien_So(TxtMa_Xe.Text, true),
                                                       IdKhoang,
                                                       Convert.ToDateTime(TxtNgay_BD.EditValue),
                                                       Convert.ToDateTime(TxtNgay_KT.EditValue),
                                                       Convert.ToInt32(TxtTG_SC.Value),
                                                       0
        );
        if (ds.Tables != null && ds.Tables[0].Rows[0]["Status_Code"].ToString() == "SUCCESS")
          Close();
      }
      else
      {
        DataSet ds = JpcbCwBO.Instance().AddOrUpdateCW(Globals.LoginUserID, Globals.LoginDlrId, "U",
                                                       CyberFunc.V_FormatBien_So(TxtMa_Xe.Text, true),
                                                       IdKhoang,
                                                       Convert.ToDateTime(TxtNgay_BD.EditValue),
                                                       Convert.ToDateTime(TxtNgay_KT.EditValue),
                                                       Convert.ToInt32(TxtTG_SC.Value),
                                                       Id);
        if (ds.Tables != null && ds.Tables[0].Rows[0]["Status_Code"].ToString() == "SUCCESS")
          Close();
      }
    }
    private void V_Close(object sender, EventArgs e)
    {
      Close();
    }
  }
}