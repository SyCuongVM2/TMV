using System;
using System.Data;
using System.Windows.Forms;
using TMV.UI.JPCB.Common;

namespace TMV.UI.JPCB.CW
{
  public partial class frmCWPlan : DevExpress.XtraEditors.XtraForm
  {
    private CyberFuncs CyberFunc = new CyberFuncs();
    private int M_Tg_SC = 5;
    private string M_Loai_SC = "1";
    private string M_Mode = "M";
    private string M_Stt_rec = "";
    private string M_ma_khoang = "";
    private DateTime M_Ngay_BD;
    private DateTime M_Ngay_KT;

    public DataTable Dt_Return;
    private DataTable Dt_Khoang;

    public frmCWPlan()
    {
      InitializeComponent();
    }

    private void frmCWPlan_Load(object sender, EventArgs e)
    {
      this.V_LoadData();
      this.V_SetDefault();
      this.V_AddHandler();
      this.Text = this.M_Mode.Trim() == "M" ? "Tạo mới/Mew" : "Sửa KH/Edit";
      this.V_Dat_Them();
      this.V_Chk_Dat_Them(new object(), new EventArgs());
    }

    private void V_LoadData()
    {
      this.Dt_Khoang = new DataTable(); // TODO
      CyberFunc.V_FillComBoxDefaul(this.CbbMa_khoang, this.Dt_Khoang, "Ma_khoang", "Ten_Khoang");
      if (this.CyberFunc.V_GetvalueCombox(this.CbbMa_khoang).ToString().Trim() == "" & this.M_Mode == "M")
      {
        try
        {
          this.CbbMa_khoang.SelectedValue = (object)this.Dt_Khoang.Rows[0]["Ma_khoang"].ToString().Trim();
        }
        catch (Exception ex)
        {
          MessageBox.Show("V_LoadData: " + ex.Message);
        }
      }
      
      if (this.TxtTG_SC.Value <= 0)
        this.TxtTG_SC.Value = this.M_Tg_SC;

      DateTime date = Convert.ToDateTime(this.TxtNgay_BD.EditValue);
      if (this.TxtTG_SC.Value > 0)
        this.TxtNgay_KT.EditValue = DateTime.Today; // TODO
    }
    private void V_SetDefault()
    {
      this.TxtNgay_BD_RO.Enabled = false;
      this.TxtNgay_KT_RO.Enabled = false;
      this.TxtNgay_henKT_RO.Enabled = false;
      this.TxtSo_Ro.Enabled = (M_Mode.Trim() == "M");
      this.TxtMa_Xe.Enabled = (M_Mode.Trim() == "M");
      this.ChkDat_them.Enabled = (M_Mode.Trim() == "M");

      if (M_Mode.Trim() == "M")
      {
        this.TxtMa_Xe.Focus();
        this.TxtLoai_SC.Text = this.M_Loai_SC;
      }
      else
        this.TxtTG_SC.Focus();

      this.TxtNgay_KT.Enabled = false;
    }
    private void V_AddHandler()
    {
      this.TxtTG_SC.Leave += new EventHandler(this.V_TG_SC);
      this.TxtNgay_BD.Leave += new EventHandler(this.V_Ngay_BD);
      this.TxtNgay_KT.Leave += new EventHandler(this.V_Ngay_KT);
      this.TxtSo_Ro.Leave += new EventHandler(this.L_So_Ro);
      this.ChkDat_them.CheckedChanged += new EventHandler(this.V_Dat_Them);
      this.LabMa_Xe.Click += new EventHandler(this.V_Ma_Xe_Click);
      this.ChkDat_them.CheckedChanged += new EventHandler(this.V_Chk_Dat_Them);
      this.btnSave.Click += new EventHandler(this.V_Nhan);
      this.btnClose.Click += new EventHandler(V_Close);
    }
    private void V_Dat_Them()
    {
      this.TxtSo_Ro.ReadOnly = this.ChkDat_them.Checked;
      this.TxtMa_Xe.ReadOnly = !this.ChkDat_them.Checked;
    }
    private void V_GetInfor()
    {
      string text1 = this.TxtSo_Ro.Text;
      string text2 = this.TxtMa_Xe.Text;
      string str = this.ChkDat_them.Checked ? "1" : "0";
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
          this.TxtNgay_BD_RO.EditValue = dataSet.Tables[0].Rows[0]["Ngay_Bd_RO"];
        if (dataSet.Tables[0].Columns.Contains("Ngay_KT_Ro"))
          this.TxtNgay_KT_RO.EditValue = dataSet.Tables[0].Rows[0]["Ngay_KT_RO"];
        if (dataSet.Tables[0].Columns.Contains("Ngay_henKT_Ro"))
          this.TxtNgay_henKT_RO.EditValue = dataSet.Tables[0].Rows[0]["Ngay_henKT_RO"];
        if (dataSet.Tables[0].Columns.Contains("Ma_Xe"))
          this.TxtMa_Xe.Text = dataSet.Tables[0].Rows[0]["Ma_Xe"].ToString().Trim();
        if (dataSet.Tables[0].Columns.Contains("So_RO"))
          this.TxtMa_Xe.Text = dataSet.Tables[0].Rows[0]["So_RO"].ToString().Trim();
        if (dataSet.Tables[0].Columns.Contains("Ma_Ct"))
          this.TxtMa_Xe.Text = dataSet.Tables[0].Rows[0]["Ma_Ct"].ToString().Trim();
        if (dataSet.Tables[0].Columns.Contains("Stt_Rec"))
          this.TxtMa_Xe.Text = dataSet.Tables[0].Rows[0]["Stt_Rec"].ToString().Trim();
        if (!dataSet.Tables[0].Columns.Contains("Dat_Them"))
          return;

        this.ChkDat_them.Checked = dataSet.Tables[0].Rows[0]["Dat_Them"].ToString() == "1";
      }
    }

    private void V_Ngay_BD(object sender, EventArgs e)
    {
      DateTime date1 = Convert.ToDateTime(this.TxtNgay_BD.EditValue);
      if (this.TxtTG_SC.Value > 0)
        this.TxtNgay_KT.EditValue = DateTime.Now; // TODO

      DateTime date2 = Convert.ToDateTime(this.TxtNgay_KT.EditValue);
      this.TxtTG_SC.Value = 0; // TODO
    }
    private void V_Ngay_KT(object sender, EventArgs e)
    {
      this.TxtTG_SC.Value = 0; // TODO
    }
    private void V_Chk_Dat_Them(object sender, EventArgs e)
    {
      this.LabSo_RO.Visible = !this.ChkDat_them.Checked;
      this.TxtSo_Ro.Visible = !this.ChkDat_them.Checked;
    }
    private void L_So_Ro(object sender, EventArgs e)
    {
      this.M_Mode = this.M_Mode.Trim();
      if (!(this.M_Mode == "M" | this.M_Mode == "S" || this.TxtSo_Ro.Text.Trim() == ""))
        return;

      this.TxtSo_Ro.Text = ""; // TODO
      this.V_GetInfor();
    }
    private void V_Dat_Them(object sender, EventArgs e)
    {
      this.V_Dat_Them();
      this.V_GetInfor();
    }
    private void V_TG_SC(object sender, EventArgs e)
    {
      DateTime date = Convert.ToDateTime(this.TxtNgay_BD.EditValue);


      if (this.TxtTG_SC.Value <= 0)
        this.TxtTG_SC.Value = 5;
      if (!(this.TxtTG_SC.Value == 5 | this.TxtTG_SC.Value == 10 | this.TxtTG_SC.Value == 15 | this.TxtTG_SC.Value == 20 | this.TxtTG_SC.Value == 25 | this.TxtTG_SC.Value == 30))
        this.TxtTG_SC.Value = 5;

      this.TxtNgay_KT.EditValue = DateTime.Today; // TODO
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