using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMV.UI.RP.GJ
{
  public partial class frmGJ : DevExpress.XtraEditors.XtraForm
  {
    public frmGJ()
    {
      InitializeComponent();
    }

    private void CmdDong_Lai_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void CmdThu_Nho_Click(object sender, EventArgs e)
    {
      WindowState = FormWindowState.Minimized;
    }
  }
}