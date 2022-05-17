using System.Data;
using System.Collections;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace TMV.Common
{
  public class CLookUpEdit
  {
    public static void LoadToLookUp(ref LookUpEdit ctr, DataTable dt, string DisplayField, string ValueField, string HeaderName, bool HasAll, string AllText)
    {
      LookUpColumnInfo[] ColumnInfo = new LookUpColumnInfo[] { new LookUpColumnInfo(DisplayField, HeaderName) };
      if (HasAll)
      {
        DataRow dr = dt.NewRow();
        dr[ValueField] = -1;
        dr[DisplayField] = AllText;
        dt.Rows.InsertAt(dr, 0);
      }
      ctr.Properties.Columns.Clear();
      ctr.Properties.Columns.AddRange(ColumnInfo);
      ctr.Properties.DataSource = dt;
      ctr.Properties.DisplayMember = DisplayField;
      ctr.Properties.ValueMember = ValueField;
      ctr.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
      ctr.Properties.SearchMode = SearchMode.AutoComplete;
      ctr.Properties.AutoSearchColumnIndex = 0;
      if (dt.Rows.Count > 0)
        ctr.EditValue = dt.Rows[0][ctr.Properties.ValueMember];
    }

    public static void LoadToLookUp(ref LookUpEdit ctr, object ls, string DisplayField, string ValueField, object obj)
    {
      LookUpColumnInfo[] ColumnInfo = new LookUpColumnInfo[] { new LookUpColumnInfo(DisplayField, "Giá trị") };
      ArrayList obj1 = new ArrayList();
      ls = obj1;
      if (obj != null)
      {
        obj1.Insert(0, obj);
      }
      ctr.Properties.Columns.Clear();
      ctr.Properties.Columns.AddRange(ColumnInfo);
      ctr.Properties.DataSource = ls;
      ctr.Properties.DisplayMember = DisplayField;
      ctr.Properties.ValueMember = ValueField;
      ctr.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
      ctr.Properties.SearchMode = SearchMode.AutoComplete;
      ctr.Properties.AutoSearchColumnIndex = 0;
    }
  }
}