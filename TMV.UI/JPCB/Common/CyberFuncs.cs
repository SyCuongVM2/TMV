using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TMV.UI.JPCB.Common
{
  public class CyberFuncs
  {
    private CyberColor CyberColor = new CyberColor();
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
    public void V_UpdateValuetoTable(DataTable _Dt_Dich, string _Field_Key_Dich, string _Field_Dich, string _Value_Dich, string _Value_Key_Dich)
    {
      if (_Dt_Dich == null || !_Dt_Dich.Columns.Contains(_Field_Key_Dich) || !_Dt_Dich.Columns.Contains(_Field_Dich))
        return;

      _Field_Key_Dich = _Dt_Dich.Columns[_Field_Key_Dich].ColumnName;
      _Field_Dich = _Dt_Dich.Columns[_Field_Dich].ColumnName;
      int num = checked(_Dt_Dich.Rows.Count - 1);
      int index = 0;
      while (index <= num)
      {
        if (_Dt_Dich.Rows[index][_Field_Key_Dich].ToString().Trim() == _Value_Key_Dich.Trim())
        {
          _Dt_Dich.Rows[index].BeginEdit();
          _Dt_Dich.Rows[index][_Field_Dich] = (object)_Value_Dich;
          _Dt_Dich.Rows[index].EndEdit();
        }
        checked { ++index; }
      }
      _Dt_Dich.AcceptChanges();
    }
    public bool V_UpdateValuetoRowTable(DataTable _Dt_Dich, string[] _Field_Key_Dich, string[] Para_condition_Key, string[] _Value_Key_Dich, string[] _Field_Dich, string[] Para_Add_UPDATE, string[] Split_Add_UPDATE, DataTable Dt_Source, int IRow, bool Del_With_Add, string Field_Getstt)
    {
      if (_Dt_Dich == null || IRow > _Dt_Dich.Rows.Count || V_Check_ExitColumns(_Dt_Dich, _Field_Key_Dich) || V_Check_ExitColumns(_Dt_Dich, _Field_Dich) || V_Check_ExitColumns(Dt_Source, _Field_Dich))
        return false;

      string filterExpression = V_get_Key_Value_key(_Field_Key_Dich, Para_condition_Key, _Value_Key_Dich);
      if (filterExpression.Trim().Length == 0)
        return false;

      DataRow[] dataRowArray = _Dt_Dich.Select(filterExpression);
      int index = 0;
      while (index < dataRowArray.Length)
      {
        DataRow dr = dataRowArray[index];
        dr.BeginEdit();
        if (!V_Set_Item_Dr(dr, _Field_Dich, Para_Add_UPDATE, Split_Add_UPDATE, Dt_Source.Rows[IRow], Del_With_Add, Field_Getstt))
          return false;

        dr.EndEdit();
        checked { ++index; }
      }
      _Dt_Dich.AcceptChanges();
      return true;
    }
    public void V_FillReports(ref GridView GRVMaster, DataView Dvhead, DataView DvMater)
    {
      string str1 = "";
      string str2 = "";
      string str3 = "";
      string str4 = "";
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      bool flag5 = false;
      DefaultBoolean defaultBoolean = DefaultBoolean.True;

      GRVMaster.CustomDrawRowIndicator -= new RowIndicatorCustomDrawEventHandler(MasterGRV_CustomDrawRowIndicator);
      GRVMaster.KeyDown -= new KeyEventHandler(MasterGRV_KeyDown);
      GRVMaster.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(MasterGRV_CustomDrawRowIndicator);
      GRVMaster.KeyDown += new KeyEventHandler(MasterGRV_KeyDown);
      GRVMaster.IndicatorWidth = DvMater.Count < 1000 ? 30 : 45;
      GRVMaster.ColumnPanelRowHeight = 40;
      GRVMaster.AppearancePrint.HeaderPanel.BackColor = CyberColor.GetBackColorPrintGrid();
      GRVMaster.AppearancePrint.HeaderPanel.ForeColor = CyberColor.GetForeColorPrintGrid();
      GRVMaster.AppearancePrint.HeaderPanel.TextOptions.WordWrap = WordWrap.Wrap;
      GRVMaster.Appearance.Row.Font = new Font("Tahoma", Convert.ToSingle(9M), FontStyle.Regular);
      GRVMaster.Appearance.ViewCaption.Font = new Font("Tahoma", Convert.ToSingle(9M), FontStyle.Regular);
      GRVMaster.RowHeight = 28;
      GRVMaster.GridControl.LookAndFeel.Style = LookAndFeelStyle.Flat;
      GRVMaster.Appearance.HorzLine.BackColor = Color.FromArgb(170, 170, 170);
      GRVMaster.Appearance.VertLine.BackColor = Color.FromArgb(170, 170, 170);
      GRVMaster.Columns.Clear();

      int num2 = checked(Dvhead.Count - 1);
      int recordIndex = 0;
      while (recordIndex <= num2)
      {
        string Field_Head1 = Convert.ToString(Dvhead[recordIndex]["Field_Head1"]);
        string Field_Head2 = Convert.ToString(Dvhead[recordIndex]["Field_Head2"]);
        if (Field_Head2.ToString() == "")
          Field_Head2 = Field_Head1;

        string Field_name = Convert.ToString(Dvhead[recordIndex]["Field_Name"]);
        string Field_Type = Convert.ToString(Dvhead[recordIndex]["Field_Type"]);
        int integer = Convert.ToInt32(Dvhead[recordIndex]["Field_Width"]);
        string Field_ReadOnly = Convert.ToString(Dvhead[recordIndex]["Field_ReOnly"]);
        string Field_Format = Convert.ToString(Dvhead[recordIndex]["Format"]);
        if (Dvhead.Table.Columns.Contains("BackColor"))
          str1 = Convert.ToString(Dvhead[recordIndex]["BackColor"]);
        if (Dvhead.Table.Columns.Contains("BackColor2"))
          str2 = Convert.ToString(Dvhead[recordIndex]["BackColor2"]);
        if (Dvhead.Table.Columns.Contains("ForeColor"))
          str3 = Convert.ToString(Dvhead[recordIndex]["ForeColor"]);
        if (Dvhead.Table.Columns.Contains("UnderLine"))
          str4 = Convert.ToString(Dvhead[recordIndex]["UnderLine"]);
        if (Dvhead.Table.Columns.Contains("ExportExcel"))
          defaultBoolean = (Dvhead[recordIndex]["ExportExcel"] == (object)1) ? DefaultBoolean.True : DefaultBoolean.False;
        
        GridColumn column = GetColumn(Field_name, Field_Type, Field_Head1, Field_Head2, integer, Field_ReadOnly, Field_Format, DvMater);
        if (column != null)
        {
          GRVMaster.Columns.Add(column);
          column.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
          column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
          column.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
          column.AppearanceHeader.ForeColor = Color.Navy;
          column.OptionsColumn.Printable = defaultBoolean;
          column.AppearanceHeader.Font = new Font("Tahoma", Convert.ToSingle(9M), FontStyle.Regular);
          column.AppearanceCell.Options.UseForeColor = true;
          column.AppearanceCell.ForeColor = Color.Navy;
          column.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;

          if (str1 != "")
            column.AppearanceCell.BackColor = CyberColor.GetBacColorkReports(str1);
          if (str1 != "")
            column.AppearanceCell.BackColor2 = CyberColor.GetBacColorkReports(str2);
          if (str3 != "")
            column.AppearanceCell.ForeColor = CyberColor.GetForeColorReports(str3);

          if (Field_name.ToString().Trim().ToUpper() == "Bold".Trim().ToUpper())
            flag1 = true;
          if (Field_name.ToString().Trim().ToUpper() == "BackColor".Trim().ToUpper())
            flag2 = true;
          if (Field_name.ToString().Trim().ToUpper() == "BackColor2".Trim().ToUpper())
            flag3 = true;
          if (Field_name.ToString().Trim().ToUpper() == "ForeColor".Trim().ToUpper())
            flag4 = true;
          if (Field_name.ToString().Trim().ToUpper() == "Underline".Trim().ToUpper())
            flag5 = true;
        }
        checked { ++recordIndex; }
      }

      if (!flag1)
        V_AddColumnRowStype("Bold", GRVMaster, DvMater);
      if (!flag2)
        V_AddColumnRowStype("BackColor", GRVMaster, DvMater);
      if (!flag3)
        V_AddColumnRowStype("BackColor2", GRVMaster, DvMater);
      if (!flag4)
        V_AddColumnRowStype("ForeColor", GRVMaster, DvMater);
      if (flag5)
        return;

      V_AddColumnRowStype("Underline", GRVMaster, DvMater);
    }

    private GridColumn GetColumn(string Field_name, string Field_Type, string Field_Head1, string Field_Head2, int Field_Width, string Field_ReadOnly, string Field_Format, DataView DvMaster)
    {
      GridColumn gridColumn = new GridColumn();
      Field_name = Field_name.Trim();
      GridColumn column = null;

      if (!DvMaster.Table.Columns.Contains(Field_name))
        column = (GridColumn)null;
      else
      {
        Field_name = DvMaster.Table.Columns[Field_name].ColumnName.Trim();
        string name = DvMaster.Table.Columns[Field_name].DataType.Name;
        gridColumn.Name = "Col_".Trim().ToUpper() + Field_name.Trim().ToUpper();
        gridColumn.Width = Field_Width <= 20 ? 100 : Field_Width;

        string upper = Field_Type.Trim().ToUpper();
        switch(upper)
        {
          case "TB":
            RepositoryItemButtonEdit repositoryItemButtonEdit = new RepositoryItemButtonEdit();
            repositoryItemButtonEdit.TextEditStyle = TextEditStyles.DisableTextEditor;
            repositoryItemButtonEdit.Tag = "TB";
            gridColumn.ColumnEdit = repositoryItemButtonEdit;
            gridColumn.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gridColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            break;
          case "DT":
            RepositoryItemDateEdit repositoryItemDateEdit = new RepositoryItemDateEdit();
            repositoryItemDateEdit.NullDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            repositoryItemDateEdit.NullText = string.Empty;
            repositoryItemDateEdit.NullDateCalendarValue = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            repositoryItemDateEdit.MinValue = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            repositoryItemDateEdit.MaxValue = new DateTime(2050, 1, 1, 0, 0, 0, 0);
            repositoryItemDateEdit.Mask.UseMaskAsDisplayFormat = true;
            repositoryItemDateEdit.Mask.EditMask = "dd/MM/yyyy HH:mm";
            repositoryItemDateEdit.Mask.IgnoreMaskBlank = false;
            repositoryItemDateEdit.AllowNullInput = DefaultBoolean.False;
            repositoryItemDateEdit.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
            repositoryItemDateEdit.Tag = "DT";
            gridColumn.ColumnEdit = repositoryItemDateEdit;
            gridColumn.DisplayFormat.FormatType = FormatType.DateTime;
            gridColumn.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            break;
          case "CM":
            RepositoryItemTextEdit repositoryItemTextEdit = new RepositoryItemTextEdit();
            repositoryItemTextEdit.Tag = "CM";
            repositoryItemTextEdit.AllowHtmlDraw = DefaultBoolean.True;
            gridColumn.ColumnEdit = repositoryItemTextEdit;
            break;
          case "D":
            RepositoryItemDateEdit repositoryItemDateEdit2 = new RepositoryItemDateEdit();
            repositoryItemDateEdit2.NullDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            repositoryItemDateEdit2.NullText = string.Empty;
            repositoryItemDateEdit2.Tag = "D";
            repositoryItemDateEdit2.ExportMode = ExportMode.DisplayText;
            gridColumn.ColumnEdit = repositoryItemDateEdit2;
            gridColumn.DisplayFormat.FormatType = FormatType.DateTime;
            gridColumn.DisplayFormat.FormatString = "dd/MM/yyyy";
            break;
          case "C":
            RepositoryItemTextEdit repositoryItemTextEdit2 = new RepositoryItemTextEdit();
            repositoryItemTextEdit2.Tag = "C";
            gridColumn.ColumnEdit = repositoryItemTextEdit2;
            break;
          case "B":
            RepositoryItemCheckEdit repositoryItemCheckEdit = new RepositoryItemCheckEdit();
            repositoryItemCheckEdit.AutoHeight = false;
            repositoryItemCheckEdit.Name = "RepositoryItemCheckEdit" + name;
            repositoryItemCheckEdit.AllowGrayed = false;
            if (name.Trim().ToUpper() != "BOOLEAN".Trim().ToUpper())
            {
              repositoryItemCheckEdit.ValueChecked = Convert.ChangeType((object)"1", System.Type.GetType("System." + name));
              repositoryItemCheckEdit.ValueUnchecked = Convert.ChangeType((object)"0", System.Type.GetType("System." + name));
            }
            else
            {
              repositoryItemCheckEdit.ValueChecked = true;
              repositoryItemCheckEdit.ValueUnchecked = false;
            }
            repositoryItemCheckEdit.NullStyle = StyleIndeterminate.Unchecked;
            repositoryItemCheckEdit.Tag = "B";
            gridColumn.ColumnEdit = repositoryItemCheckEdit;
            break;
          case "IMG":
            RepositoryItemPictureEdit repositoryItemPictureEdit = new RepositoryItemPictureEdit();
            repositoryItemPictureEdit.ReadOnly = true;
            repositoryItemPictureEdit.Tag = "IMG";
            repositoryItemPictureEdit.SizeMode = PictureSizeMode.Zoom;
            gridColumn.ColumnEdit = repositoryItemPictureEdit;
            gridColumn.OptionsColumn.AllowEdit = false;
            break;
          case "L":
            RepositoryItemHyperLinkEdit itemHyperLinkEdit = new RepositoryItemHyperLinkEdit();
            itemHyperLinkEdit.SingleClick = true;
            itemHyperLinkEdit.ReadOnly = true;
            itemHyperLinkEdit.Tag = "L";
            gridColumn.ColumnEdit = itemHyperLinkEdit;
            gridColumn.OptionsColumn.AllowEdit = false;
            break;
          case "N":
            Field_Format = (Field_Format.Trim() != "") ? Field_Format.Trim() : "### ### ### ### ### ### ###";
            bool flag = false;
            RepositoryItemTextEdit repositoryItemTextEdit3 = new RepositoryItemTextEdit();
            repositoryItemTextEdit3.NullText = "0";
            repositoryItemTextEdit3.NullValuePrompt = "0";
            repositoryItemTextEdit3.NullValuePromptShowForEmptyValue = true;
            repositoryItemTextEdit3.Mask.IgnoreMaskBlank = false;
            repositoryItemTextEdit3.AllowNullInput = DefaultBoolean.False;
            if (Field_Format.Contains("n"))
            {
              repositoryItemTextEdit3.Mask.Culture = CultureInfo.GetCultureInfo("vi-VN");
              Field_Format = Field_Format.Replace("n", "");
              flag = true;
            }
            repositoryItemTextEdit3.Mask.EditMask = Field_Format;
            repositoryItemTextEdit3.Mask.MaskType = MaskType.Numeric;
            repositoryItemTextEdit3.Mask.UseMaskAsDisplayFormat = true;
            repositoryItemTextEdit3.Tag = "N";
            gridColumn.ColumnEdit = repositoryItemTextEdit3;
            gridColumn.DisplayFormat.FormatType = FormatType.Numeric;
            if (flag)
              gridColumn.DisplayFormat.Format = CultureInfo.GetCultureInfo("vi-VN");
            gridColumn.DisplayFormat.FormatString = Field_Format;
            break;
          case "P":
            RepositoryItemProgressBar repositoryItemProgressBar = new RepositoryItemProgressBar();
            repositoryItemProgressBar.Maximum = 100;
            repositoryItemProgressBar.Minimum = 0;
            repositoryItemProgressBar.ShowTitle = true;
            repositoryItemProgressBar.PercentView = true;
            repositoryItemProgressBar.LookAndFeel.UseDefaultLookAndFeel = false;
            repositoryItemProgressBar.LookAndFeel.SkinName = "Office 2013";
            gridColumn.ColumnEdit = repositoryItemProgressBar;
            break;
        }
        gridColumn.FieldName = Field_name;
        gridColumn.Caption = Field_Head1.Trim();
        gridColumn.Tag = Field_Head2.Trim();
        gridColumn.OptionsColumn.ReadOnly = (Field_ReadOnly == "1");
        gridColumn.Visible = true;
        column = gridColumn;
      }
      return column;
    }
    private void MasterGRV_KeyDown(object sender, KeyEventArgs e)
    {
      GridView view = sender as GridView;
      if (!e.Control || e.KeyCode != Keys.C && e.KeyCode != Keys.Insert || view.IsEditing)
        return;

      Clipboard.SetDataObject(GetSelectedValues(view));
      e.Handled = true;
    }
    private string GetSelectedValues(GridView view)
    {
      if (view.SelectedRowsCount == 0)
        return "";

      string selectedValues = "";
      int selectedRowsCount = view.SelectedRowsCount;
      int FalsePart1 = 9999;
      int FalsePart2 = -1;
      int selectedRow1 = view.GetSelectedRows()[0];
      int selectedRow2 = view.GetSelectedRows()[checked(view.SelectedRowsCount - 1)];
      int num1;
      if (view.OptionsSelection.MultiSelect & view.OptionsSelection.MultiSelectMode == GridMultiSelectMode.CellSelect)
      {
        int num2 = checked(selectedRowsCount - 1);
        int index = 0;
        while (index <= num2)
        {
          int selectedRow3 = view.GetSelectedRows()[index];
          int visibleIndex1 = view.GetSelectedCells(selectedRow3)[0].VisibleIndex;
          int visibleIndex2 = view.GetSelectedCells(selectedRow3)[checked(view.GetSelectedCells(selectedRow3).Length - 1)].VisibleIndex;
          FalsePart1 = FalsePart1 > visibleIndex1 ? visibleIndex1 : FalsePart1;
          FalsePart2 = FalsePart2 < visibleIndex2 ? visibleIndex2 : FalsePart2;
          checked { ++index; }
        }
        num1 = 1;
      }
      else if (!view.OptionsSelection.MultiSelect & view.OptionsSelection.MultiSelectMode == GridMultiSelectMode.CellSelect & view.OptionsSelection.EnableAppearanceFocusedCell)
      {
        FalsePart1 = view.FocusedColumn.VisibleIndex;
        FalsePart2 = view.FocusedColumn.VisibleIndex;
        num1 = 2;
      }
      else
      {
        FalsePart1 = 0;
        FalsePart2 = checked(view.VisibleColumns.Count - 1);
        num1 = 3;
      }
      int num3 = selectedRow1;
      int num4 = selectedRow2;
      int num5 = num3;
      while (num5 <= num4)
      {
        int num6 = FalsePart1;
        int num7 = FalsePart2;
        int num8 = num6;
        while (num8 <= num7)
        {
          if (num1 == 1)
          {
            if (view.IsCellSelected(num5, view.VisibleColumns[num8]))
              selectedValues += V_strReturn(view, num5, num8);
          }
          else
            selectedValues += V_strReturn(view, num5, num8);
          if (num8 != FalsePart2)
            selectedValues += "\t";
          checked { ++num8; }
        }
        if (num5 != selectedRow2)
          selectedValues += "\r\n";

        checked { ++num5; }
      }
      return selectedValues;
    }
    private string V_strReturn(GridView view, int Row, int Column)
    {
      string str;
      try
      {
        str = (view.Columns[Column].ColumnEdit.Tag != (object)"N") ? view.GetRowCellDisplayText(Row, view.VisibleColumns[Column]) : Convert.ToString(view.GetRowCellValue(Row, view.VisibleColumns[Column]));
      }
      catch
      {
        str = view.GetRowCellDisplayText(Row, view.VisibleColumns[Column]);
      }
      return str;
    }
    private void MasterGRV_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
    {
      if (e.RowHandle < 0)
        return;

      e.Info.DisplayText = Convert.ToString(checked(e.RowHandle + 1));
    }
    private void V_AddColumnRowStype(string Field_Name, GridView GRVMaster, DataView DvMater)
    {
      if (!DvMater.Table.Columns.Contains(Field_Name))
        return;

      Field_Name = DvMater.Table.Columns[Field_Name].ColumnName.Trim();
      GRVMaster.Columns.Add(new GridColumn()
      {
        Name = "Col_".Trim().ToUpper() + Field_Name.Trim().ToUpper(),
        Caption = Field_Name.Trim(),
        Tag = (object)Field_Name.Trim(),
        FieldName = Field_Name,
        OptionsColumn = {
          AllowEdit = false
        },
        Visible = false
      });
    }
    private bool V_Check_ExitColumns(DataTable _Dt, string[] _Field_Key_Dich)
    {
      int num = checked(_Field_Key_Dich.Length - 1);
      int index = 0;
      while (index <= num)
      {
        if (!_Dt.Columns.Contains(_Field_Key_Dich[index].ToString()))
          return false;

        checked { ++index; }
      }
      return true;
    }
    private string V_get_Key_Value_key(string[] _Field_Key, string[] Para_condition_Key, string[] _Value_Key)
    {
      string Left = "";
      if (_Field_Key.Length != Para_condition_Key.Length | _Field_Key.Length != _Value_Key.Length | Para_condition_Key.Length != _Value_Key.Length)
        Left = "";

      int num = checked(_Field_Key.Length - 1);
      int index = 0;
      while (index <= num)
      {
        Left = Left + (Left.Trim().Length > 0 ? (" " + Para_condition_Key[index] + " ") : "") + _Field_Key[index].ToString() + "='" + _Value_Key[index].ToString() + "'";
        checked { ++index; }
      }
      return Left;
    }
    private bool V_Set_Item_Dr(DataRow dr, string[] _Field_Dich, string[] Para_Add_UPDATE, string[] Split_Add_UPDATE, DataRow Dr_Source, bool Del_With_Add, string Field_Getstt)
    {
      if (_Field_Dich.Length != Para_Add_UPDATE.Length | _Field_Dich.Length != Split_Add_UPDATE.Length | Para_Add_UPDATE.Length != Split_Add_UPDATE.Length)
        return false;

      dr.BeginEdit();
      int item_notGet = -1;
      int num = checked(_Field_Dich.Length - 1);
      int index = 0;
      while (index <= num)
      {
        if (Del_With_Add & _Field_Dich[index].ToString().ToUpper() == Field_Getstt.ToUpper())
          item_notGet = FindItemInArr(Dr_Source[_Field_Dich[index].ToString()].ToString(), Convert.ToString(dr[_Field_Dich[index].ToString()]), Split_Add_UPDATE[index].ToString());
        
        string upper = Para_Add_UPDATE[index].ToString().Trim().ToUpper();
        if (upper == "ADD")
        {
          if (Del_With_Add)
            dr[_Field_Dich[index].ToString()] = GetStringInArrNotItem(Convert.ToString(dr[_Field_Dich[index].ToString()]), Split_Add_UPDATE[index].ToString(), item_notGet);

          dr[_Field_Dich[index].ToString()] = (dr[_Field_Dich[index].ToString()].ToString() + Split_Add_UPDATE[index].ToString() + Dr_Source[_Field_Dich[index].ToString()].ToString());
        }
        else if (upper == "UPDATE")
          dr[_Field_Dich[index].ToString()] = Dr_Source[_Field_Dich[index].ToString()].ToString();

        checked { ++index; }
      }
      dr.EndEdit();
      return true;
    }
    private string GetStringInArrNotItem(string arr_txt, string strSplit, int item_notGet)
    {
      if (arr_txt == "")
        return "";

      string[] strArray = arr_txt.Split(Convert.ToChar(strSplit));
      string Left = "";
      int num = checked(strArray.Length - 1);
      int index = 0;
      while (index <= num)
      {
        if (index != item_notGet)
          Left = Left + ((index == 0 & item_notGet != 0 | item_notGet == 0 & index == 1) ? "" : strSplit) + strArray[index].ToString().ToUpper();

        checked { ++index; }
      }
      return Left;
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
  }
}