using System;
using System.Data;
using System.Windows.Forms;

namespace TMV.UI.JPCB.Common
{
  public class CyberFuncs
  {
    public void V_FillComBoxDefaul(ComboBox ComBoxName, DataTable Dt, string FieldValue, string FieldDispLay, string FieldDefault = "Default")
    {
      if (Dt == null)
        return;

      ComBoxName.DataSource = Dt;
      ComBoxName.DisplayMember = Dt.Columns[FieldDispLay].ColumnName;
      ComBoxName.ValueMember = Dt.Columns[FieldValue].ColumnName;
      if (!Dt.Columns.Contains(FieldDefault))
      {
        if (Dt.Rows.Count == 0)
          return;
        string str = Dt.Rows[0][Dt.Columns[FieldValue].ColumnName].ToString();
        ComBoxName.SelectedValue = str;
      }
      else
      {
        int num = checked(Dt.Rows.Count - 1);
        int index = 0;
        while (index <= num)
        {
          if (Dt.Rows[index][Dt.Columns[FieldDefault].ColumnName].ToString().Trim().ToUpper() == "1" ||
              Dt.Rows[index][Dt.Columns[FieldDefault].ColumnName].ToString().Trim().ToUpper() == "TRUE")
          {
            string str = Dt.Rows[index][Dt.Columns[FieldValue].ColumnName].ToString();
            ComBoxName.SelectedValue = str;
            break;
          }
          checked { ++index; }
        }
      }
    }
    public decimal V_StringToNumeric(ComboBox _Cbb)
    {
      decimal numeric = 0M;
      string str = V_GetvalueCombox(_Cbb);
      if (str.Trim() == "")
        str = "0";
      try
      {
        numeric = Convert.ToDecimal(str);
      }
      catch (Exception ex)
      {
        MessageBox.Show("V_StringToNumeric: " + ex.Message);
      }
      return numeric;
    }
    public string V_GetvalueCombox(ComboBox _Cbb)
    {
      string str = "";
      try
      {
        str = _Cbb.SelectedValue.ToString().Trim();
      }
      catch (Exception ex)
      {
        MessageBox.Show("V_GetvalueCombox: " + ex.Message);
      }
      return str;
    }
    public void V_DeleteRowEmpty(DataTable _Dt, string _Fieldname)
    {
      if (_Dt == null)
        return;

      _Fieldname = _Fieldname.Trim();
      if (!_Dt.Columns.Contains(_Fieldname))
        return;

      _Fieldname = _Dt.Columns[_Fieldname].ColumnName;
      int index = checked(_Dt.Rows.Count - 1);
      while (index >= 0)
      {
        if (_Dt.Rows[index][_Fieldname].ToString().Trim() == "")
          _Dt.Rows[index].Delete();
        checked { index += -1; }
      }
      _Dt.AcceptChanges();
    }
    public void SetNotNullTable(DataTable tb)
    {
      int num1 = checked(tb.Rows.Count - 1);
      int index = 0;
      while (index <= num1)
      {
        tb.Rows[index].BeginEdit();
        int num2 = checked(tb.Columns.Count - 1);
        int num3 = 0;
        while (num3 <= num2)
        {
          if (tb.Rows[index][num3] == null)
          {
            string upper = tb.Columns[num3].DataType.Name.Trim().ToUpper();
            if (upper == "STRING")
              tb.Rows[index][num3] = "";
            else if (upper == "DATETIME")
              tb.Rows[index][num3] = new DateTime(1900, 1, 1);
            else if (upper == "DECIMAL")
              tb.Rows[index][num3] = 0;
            else if (upper == "DOUBLE")
              tb.Rows[index][num3] = (object)0;
            else if (upper == "BOOLEAN")
              tb.Rows[index][num3] = "1";
          }
          checked { ++num3; }
        }
        tb.Rows[index].EndEdit();
        checked { ++index; }
      }
      tb.AcceptChanges();
    }
    public void V_SetSortView(ref DataView _Dv, DataTable _Dt)
    {
      string sortView = V_GetSortView(_Dv, _Dt);
      if (sortView.Trim() == "")
        return;

      _Dv.Sort = sortView;
    }
    public string V_GetSortView(DataView _Dv, DataTable _Dt)
    {
      if (_Dv == null | _Dt == null || !_Dt.Columns.Contains("FieldSort"))
        return "";
      string sortView = "";
      int num = checked(_Dt.Rows.Count - 1);
      int index = 0;
      while (index <= num)
      {
        string name = _Dt.Rows[index]["FieldSort"].ToString().Trim();
        string Left = (!_Dt.Columns.Contains("Is_DESC") ? "0" : _Dt.Rows[index]["Is_DESC"].ToString().Trim()).Trim();
        if (_Dv.Table.Columns.Contains(name))
        {
          string columnName = _Dv.Table.Columns[name].ColumnName;
          if (Left == "1")
            columnName += " DESC";
          sortView = sortView.Trim() != "" ? sortView + "," + columnName : columnName;
        }
        checked { ++index; }
      }
      return sortView;
    }
    public void V_HideTapPage(ref TabControl _Tab, string _pageName)
    {
      if (_Tab == null || _pageName == "")
        return;
      _pageName = _pageName.Trim().ToUpper();
      int index = checked(_Tab.TabPages.Count - 1);
      while (index >= 0)
      {
        if (_Tab.TabPages[index].Name.Trim().ToUpper() == _pageName)
        {
          _Tab.TabPages.Remove(_Tab.TabPages[index]);
          break;
        }
        checked { index += -1; }
      }
    }
    public void V_UpdateRowtoRow(DataRow _Dr, DataTable _Dt, int _Irow)
    {
      if (_Dr == null || _Dt == null || _Irow < 0)
        return;

      int num1 = checked(_Dr.Table.Columns.Count - 1);
      _Dt.Rows[_Irow].BeginEdit();
      int num2 = num1;
      int index = 0;
      while (index <= num2)
      {
        string columnName = _Dr.Table.Columns[index].ColumnName;
        if (_Dt.Columns.Contains(columnName))
          _Dt.Rows[_Irow][columnName] = _Dr[columnName];
        checked { ++index; }
      }
      _Dt.Rows[_Irow].EndEdit();
    }
    public void DeleteDatatable(ref DataTable _dt, string _key = "")
    {
      if (_key.Trim() == "" | _key.Trim().Replace(" ", "") == "1=1")
      {
        _dt.Clear();
        _dt.AcceptChanges();
      }
      else
      {
        int num = checked(_dt.Rows.Count - 1);
        DataRow[] dataRowArray = _dt.Select(_key);
        int index = 0;
        while (index < dataRowArray.Length)
        {
          DataRow row = dataRowArray[index];
          _dt.Rows.Remove(row);
          checked { ++index; }
        }
        _dt.AcceptChanges();
      }
    }
  }
}