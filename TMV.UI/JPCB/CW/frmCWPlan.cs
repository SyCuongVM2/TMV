using System;
using System.Data;
using System.Windows.Forms;
using TMV.Common;
using TMV.Common.Forms;
using TMV.UI.JPCB.Common;

namespace TMV.UI.JPCB.CW
{
  public partial class frmCWPlan : DevExpress.XtraEditors.XtraForm
  {
    private CyberFuncs CyberFunc = new CyberFuncs();
    private int M_Tg_SC = 5;
    private string M_Loai_SC = "1";
    private string M_Mode = "M";
    public DataTable Dt_Return;
    private DataTable Dt_Khoang;

    public frmCWPlan()
    {
      InitializeComponent();
    }

    public bool ShowForm(string mode, string stt_rec, string _Ma_khoang, DateTime start, DateTime end, int BN)
    {
      frmProgress.Instance().Thread = new MethodInvoker(V_LoadData);
      frmProgress.Instance().Show_Progress();
      return (ShowDialog() == DialogResult.OK);
    }
    private void frmCWPlan_Load(object sender, EventArgs e)
    {
      V_LoadData();
      V_SetDefault();
      V_AddHandler();
      Text = M_Mode.Trim() == "M" ? "Tạo mới/New" : "Sửa KH/Edit";
      V_Dat_Them();
      V_Chk_Dat_Them(new object(), new EventArgs());
    }

    private void V_LoadData()
    {
      Dt_Khoang = new DataTable(); // TODO
      CyberFunc.V_FillComBoxDefaul(CbbMa_khoang, Dt_Khoang, "Ma_khoang", "Ten_Khoang");
      if (CyberFunc.V_GetvalueCombox(CbbMa_khoang).ToString().Trim() == "" & M_Mode == "M")
      {
        try
        {
          CbbMa_khoang.SelectedValue = (object)Dt_Khoang.Rows[0]["Ma_khoang"].ToString().Trim();
        }
        catch (Exception ex)
        {
          MessageBox.Show("V_LoadData: " + ex.Message);
        }
      }

      if (TxtTG_SC.Value <= 0)
        TxtTG_SC.Value = M_Tg_SC;

      DateTime date = Convert.ToDateTime(TxtNgay_BD.EditValue);
      if (TxtTG_SC.Value > 0)
        TxtNgay_KT.EditValue = DateTime.Today; // TODO
    }
    private void V_SetDefault()
    {
      TxtNgay_BD_RO.Enabled = false;
      TxtNgay_KT_RO.Enabled = false;
      TxtNgay_henKT_RO.Enabled = false;
      TxtSo_Ro.Enabled = (M_Mode.Trim() == "M");
      TxtMa_Xe.Enabled = (M_Mode.Trim() == "M");
      ChkDat_them.Enabled = (M_Mode.Trim() == "M");

      if (M_Mode.Trim() == "M")
      {
        TxtMa_Xe.Focus();
        TxtLoai_SC.Text = M_Loai_SC;
      }
      else
        TxtTG_SC.Focus();

      TxtNgay_KT.Enabled = false;
    }
    private void V_AddHandler()
    {
      TxtTG_SC.Leave += new EventHandler(V_TG_SC);
      TxtNgay_BD.Leave += new EventHandler(V_Ngay_BD);
      TxtNgay_KT.Leave += new EventHandler(V_Ngay_KT);
      TxtSo_Ro.Leave += new EventHandler(L_So_Ro);
      ChkDat_them.CheckedChanged += new EventHandler(V_Dat_Them);
      ChkDat_them.CheckedChanged += new EventHandler(V_Chk_Dat_Them);
      btnSave.Click += new EventHandler(V_Nhan);
      btnClose.Click += new EventHandler(V_Close);
    }
    private void V_Dat_Them()
    {
      TxtSo_Ro.ReadOnly = ChkDat_them.Checked;
      TxtMa_Xe.ReadOnly = !ChkDat_them.Checked;
    }
    private void V_GetInfor()
    {
      string text1 = TxtSo_Ro.Text;
      string text2 = TxtMa_Xe.Text;
      string str = ChkDat_them.Checked ? "1" : "0";
      if (text1.Trim() == "" & text2.Trim() == "")
        return;

      DataSet dataSet = new DataSet(); // TODO
      if (dataSet.Tables.Count == 0)
        dataSet.Dispose();
      else if (dataSet.Tables[0].Rows.Count == 0)
        dataSet.Dispose();
      else
      {
        if (dataSet.Tables[0].Columns.Contains("Ngay_BD_Ro"))
          TxtNgay_BD_RO.EditValue = dataSet.Tables[0].Rows[0]["Ngay_Bd_RO"];
        if (dataSet.Tables[0].Columns.Contains("Ngay_KT_Ro"))
          TxtNgay_KT_RO.EditValue = dataSet.Tables[0].Rows[0]["Ngay_KT_RO"];
        if (dataSet.Tables[0].Columns.Contains("Ngay_henKT_Ro"))
          TxtNgay_henKT_RO.EditValue = dataSet.Tables[0].Rows[0]["Ngay_henKT_RO"];
        if (dataSet.Tables[0].Columns.Contains("Ma_Xe"))
          TxtMa_Xe.Text = dataSet.Tables[0].Rows[0]["Ma_Xe"].ToString().Trim();
        if (dataSet.Tables[0].Columns.Contains("So_RO"))
          TxtMa_Xe.Text = dataSet.Tables[0].Rows[0]["So_RO"].ToString().Trim();
        if (dataSet.Tables[0].Columns.Contains("Ma_Ct"))
          TxtMa_Xe.Text = dataSet.Tables[0].Rows[0]["Ma_Ct"].ToString().Trim();
        if (dataSet.Tables[0].Columns.Contains("Stt_Rec"))
          TxtMa_Xe.Text = dataSet.Tables[0].Rows[0]["Stt_Rec"].ToString().Trim();
        if (!dataSet.Tables[0].Columns.Contains("Dat_Them"))
          return;

        ChkDat_them.Checked = dataSet.Tables[0].Rows[0]["Dat_Them"].ToString() == "1";
      }
    }

    private void V_Ngay_BD(object sender, EventArgs e)
    {
      DateTime date1 = Convert.ToDateTime(TxtNgay_BD.EditValue);
      if (TxtTG_SC.Value > 0)
        TxtNgay_KT.EditValue = DateTime.Now; // TODO

      DateTime date2 = Convert.ToDateTime(TxtNgay_KT.EditValue);
      TxtTG_SC.Value = 0; // TODO
    }
    private void V_Ngay_KT(object sender, EventArgs e)
    {
      TxtTG_SC.Value = 0; // TODO
    }
    private void V_Chk_Dat_Them(object sender, EventArgs e)
    {
      LabSo_RO.Visible = !ChkDat_them.Checked;
      TxtSo_Ro.Visible = !ChkDat_them.Checked;
    }
    private void L_So_Ro(object sender, EventArgs e)
    {
      M_Mode = M_Mode.Trim();
      if (!(M_Mode == "M" | M_Mode == "S" || TxtSo_Ro.Text.Trim() == ""))
        return;

      TxtSo_Ro.Text = ""; // TODO
      V_GetInfor();
    }
    private void V_Dat_Them(object sender, EventArgs e)
    {
      V_Dat_Them();
      V_GetInfor();
    }
    private void V_TG_SC(object sender, EventArgs e)
    {
      DateTime date = Convert.ToDateTime(TxtNgay_BD.EditValue);

      if (TxtTG_SC.Value <= 0)
        TxtTG_SC.Value = 5;
      if (!(TxtTG_SC.Value == 5 | TxtTG_SC.Value == 10 | TxtTG_SC.Value == 15 | TxtTG_SC.Value == 20 | TxtTG_SC.Value == 25 | TxtTG_SC.Value == 30))
        TxtTG_SC.Value = 5;

      TxtNgay_KT.EditValue = DateTime.Today; // TODO
    }
    private void V_Nhan(object sender, EventArgs e)
    {

    }
    private void V_Close(object sender, EventArgs e)
    {
      Close();
    }
  }
}