using System;
using System.Data;
using System.Windows.Forms;
using TMV.Common.ControlHandles;

namespace TMV.Common.Forms
{
  public partial class frmGridFilter : Form
  {
    private DataTable m_DataTable;
    private string sCondition;

    public frmGridFilter()
    {
      InitializeComponent();
    }

    public bool Show_Form(DataTable dt)
    {
      string sFilter = dt.DefaultView.RowFilter;
      DataTable dtCondition = new DataTable();
      dtCondition.Columns.Add("Column_Name", typeof(string));
      dtCondition.Columns.Add("Column_Criteria", typeof(string));
      dtCondition.Columns[1].AllowDBNull = false;
      if (!string.IsNullOrEmpty(sFilter))
      {
        string[] sLenght = sFilter.Replace(" AND ", "\t").Split(new char[] { '\t' });
        //foreach (string sCondition in sFilter.Replace(" AND ", "\t").Split(new char[] { '\t' }))
        for (int k = 0; k < sLenght.Length; k++)
        {
          //sCondition = sCondition.Trim();
          sLenght[k] = sLenght[k].Trim();
          sCondition = sLenght[k];
          DataRow dr = dtCondition.NewRow();
          int i = grdTableSetting.Rows.Add();
          int iPos = sCondition.IndexOf(" ");
          string sFieldName = sCondition.Substring(0, iPos);
          string sCriteria = sCondition.Substring(iPos + 1);
          if (sCriteria.StartsWith("="))
            sCriteria = sCriteria.Substring(1);

          if (sCriteria.StartsWith("'") && sCriteria.EndsWith("'"))
          {
            sCriteria = sCriteria.Substring(1);
            sCriteria = sCriteria.Substring(0, sCriteria.Length - 1);
          }
          dr["Column_Name"] = sFieldName;
          dr["Column_Criteria"] = sCriteria;
          dtCondition.Rows.Add(dr);
        }
      }
      DataGridHandle dh = new DataGridHandle(grdTableSetting, "")
      {
        AutoRequired = true
      };
      grdTableSetting.Columns[0].DataPropertyName = "Column_Name";
      grdTableSetting.Columns[1].DataPropertyName = "Column_Criteria";
      grdTableSetting.AutoGenerateColumns = false;
      grdTableSetting.DataSource = dtCondition;
      m_DataTable = dt;
      return (ShowDialog() == DialogResult.OK);
    }

    private void cmdOK_Click(object sender, EventArgs e)
    {
      try
      {
        sCondition = "";
        foreach (DataGridViewRow row in grdTableSetting.Rows)
        {
          if (!row.IsNewRow)
          {
            if (!string.IsNullOrEmpty(sCondition))
              sCondition = sCondition + " AND ";
            else
              sCondition = sCondition + "";

            string sFieldName = Convert.ToString(row.Cells["Column_Name"].Value);
            string sCriteria = Convert.ToString(row.Cells["Column_Criteria"].Value).Trim();
            if ((((!sCriteria.StartsWith("=") && !sCriteria.StartsWith("IN", StringComparison.CurrentCultureIgnoreCase)) &&
                (!sCriteria.StartsWith("LIKE", StringComparison.CurrentCultureIgnoreCase) &&
                !sCriteria.StartsWith(">", StringComparison.CurrentCultureIgnoreCase))) &&
                ((!sCriteria.StartsWith("<", StringComparison.CurrentCultureIgnoreCase) &&
                !sCriteria.StartsWith("BETWEEN", StringComparison.CurrentCultureIgnoreCase)) &&
                (!sCriteria.StartsWith(">=", StringComparison.CurrentCultureIgnoreCase) &&
                !sCriteria.StartsWith("<=", StringComparison.CurrentCultureIgnoreCase)))) &&
                !sCriteria.StartsWith("<>", StringComparison.CurrentCultureIgnoreCase))
            {
              if (!(sCriteria.StartsWith("'") & sCriteria.EndsWith("'")))
                sCriteria = "='" + sCriteria + "'";
              else
                sCriteria = "=" + sCriteria;
            }
            sCondition = sCondition + sFieldName + " " + sCriteria;
          }
        }

        try
        {
          m_DataTable.DefaultView.RowFilter = sCondition;
        }
        catch
        {
          FormGlobals.Message_Information("Invalid condition, please check condition syntax");
          return;
        }
        Tag = sCondition;
        DialogResult = DialogResult.OK;
        Hide();
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
    private void cmdCancel_Click(object sender, EventArgs e)
    {
      Hide();
    }
  }
}
