using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using TMV.Common.Forms;

namespace TMV.Common.ControlHandles
{
  public class DataGridHandle
  {
    private bool _AllowFilter;
    private bool _AutoRequired;
    private bool _ConfirmDelete;
    private bool _KeepMergeHeader;
    private DataGridView m_objGrid;
    private TextBox m_txtCellEdit;
    private ContextMenuStrip mnuContext;
    private bool _MultiDelete;
    private bool _PasteClipboard;
    private int _RowSelectCount;
    private string _sPrimaryKey;
    private bool m_bIsLoading;
    private MethodInvoker m_DbClickMethod;
    private Dictionary<string, string> m_dicFilterColumn;
    private Dictionary<string, string> m_dicMappingColumn;
    private Dictionary<string, string> m_dicMappingValue;
    private List<int> m_dicMergeColIndex;
    private Dictionary<int, MergeColumnHeaderInfo> m_dicMergeInfo;
    private List<string> m_dicRequiredColumn;
    private int m_iOrder;
    private DataTable m_SourceTable;

    public delegate void After_PasteCellDataEventHandler(object sender, DataGridViewCellEventArgs e);
    public delegate void After_PasteRowDataEventHandler(object sender, DataGridViewCellEventArgs e);
    public delegate void Progress_PasteRowDataEventHandler(int iRowPos, int iRowCount);
    public delegate void Verify_PasteRowDataEventHandler(DataRow drData, ref bool bPassed);

    public event After_PasteCellDataEventHandler After_PasteCellData;
    public event After_PasteRowDataEventHandler After_PasteRowData;
    public event Progress_PasteRowDataEventHandler Progress_PasteRowData;
    public event Verify_PasteRowDataEventHandler Verify_PasteRowData;

    private struct MergeColumnHeaderInfo
    {
      public string FromName;
      public int FromIndex;
      public int ToIndex;
      public string Caption;
      public int Width;
      public bool Cover;
    }

    public bool ClipboardPaste
    {
      get
      {
        if (_PasteClipboard)
        {
          _PasteClipboard = false;
          return true;
        }
        return false;
      }
    }

    public bool AutoRequired
    {
      get
      {
        return _AutoRequired;
      }
      set
      {
        _AutoRequired = value;
        if (_AutoRequired)
          m_dicRequiredColumn = null;
      }
    }

    public bool AllowFilter
    {
      get
      {
        return _AllowFilter;
      }
      set
      {
        _AllowFilter = value;
      }
    }

    public bool KeepMergeHeader
    {
      get
      {
        return _KeepMergeHeader;
      }
      set
      {
        _KeepMergeHeader = value;
        if (_KeepMergeHeader)
        {
          int iHeight = m_objGrid.ColumnHeadersHeight;
          m_objGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
          m_objGrid.ColumnHeadersHeight = iHeight + 18;
        }
      }
    }

    public DataGridHandle(DataGridView objGrid, string sPrimaryKey)
    {
      _sPrimaryKey = null;
      _sPrimaryKey = sPrimaryKey;
      m_objGrid = objGrid;
      m_objGrid.AlternatingRowsDefaultCellStyle.BackColor = FormGlobals.App_GetColor("#eeeeee");
      m_objGrid.ShowCellErrors = true;
      m_objGrid.ShowRowErrors = true;
      m_objGrid.RowHeadersWidth = 45;
      m_objGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      if (m_objGrid.ColumnHeadersHeight == 18)
      {
        m_objGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        m_objGrid.ColumnHeadersHeight = 36;
      }
      if (!m_objGrid.ReadOnly)
      {
        m_txtCellEdit = new TextBox();
        m_txtCellEdit.TextAlign = HorizontalAlignment.Right;
        m_txtCellEdit.Visible = false;
        m_objGrid.Parent.Controls.Add(m_txtCellEdit);
        m_dicMergeInfo = new Dictionary<int, MergeColumnHeaderInfo>();
        m_dicMergeColIndex = new List<int>();
        if (_AllowFilter)
        {
          mnuContext = new ContextMenuStrip();
          mnuContext.Items.Add(new ToolStripMenuItem("Edit Filter ...", null, new EventHandler(ctxMenu_Click), "Filter_Edit"));
          mnuContext.Items.Add(new ToolStripMenuItem("Clear Filter", null, new EventHandler(ctxMenu_Click), "Filter_Clear"));
          m_objGrid.TopLeftHeaderCell.ContextMenuStrip = mnuContext;
        }
      }
    }

    public void SetPrimaryKey(string sColName)
    {
      _sPrimaryKey = sColName;
    }

    public object GetKeyValue()
    {
      if ((m_objGrid.CurrentRow == null) || m_objGrid.CurrentRow.IsNewRow)
      {
        return null;
      }
      return Globals.DB_GetValue(((DataRowView)m_objGrid.CurrentRow.DataBoundItem)[_sPrimaryKey], null);
    }

    public object GetRowValue(string sFieldName)
    {
      if ((m_objGrid.CurrentRow == null) || m_objGrid.CurrentRow.IsNewRow)
      {
        return null;
      }
      return Globals.DB_GetValue(((DataRowView)m_objGrid.CurrentRow.DataBoundItem)[sFieldName], null);
    }

    public void ResetMergeColumn()
    {
      if (m_dicMergeInfo != null)
      {
        m_dicMergeInfo = new Dictionary<int, MergeColumnHeaderInfo>();
        m_dicMergeColIndex = new List<int>();
      }
    }

    public void SetMappingColumn(IDataReader dr, string sDataCol, string sOriginCol)
    {
      m_dicMappingColumn = new Dictionary<string, string>();
      while (dr.Read())
      {
        m_dicMappingColumn.Add(Convert.ToString(dr[sDataCol]), Convert.ToString(dr[sOriginCol]));
      }
      Globals.Reader_Close(dr);
    }

    public Dictionary<string, string> MappingColumn
    {
      get
      {
        return m_dicMappingColumn;
      }
      set
      {
        m_dicMappingColumn = value;
      }
    }

    public void SetMappingValue(IDataReader dr, string sDataCol, string sOriginCol)
    {
      m_dicMappingValue = new Dictionary<string, string>();
      while (dr.Read())
      {
        m_dicMappingValue.Add(Convert.ToString(dr[sDataCol]), Convert.ToString(dr[sOriginCol]));
      }
      Globals.Reader_Close(dr);
    }

    public void SetDblClick(MethodInvoker DbClickMethod)
    {
      m_DbClickMethod = DbClickMethod;
    }

    public void MergeColumnHeader(string sMergeHeader, int iFromColIndex, int iColMerge)
    {
      int iW = -3;
      int iX = GetPosX(iFromColIndex);
      for (int i = 0; i <= iColMerge - 1; i++)
      {
        iW += m_objGrid.Columns[iFromColIndex + i].Width;
        m_dicMergeColIndex.Add(iFromColIndex + i);
        m_objGrid.Columns[iFromColIndex + i].Resizable = DataGridViewTriState.False;
        if (_KeepMergeHeader)
          m_objGrid.Columns[iFromColIndex + i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
      }
      MergeColumnHeaderInfo objInfo = new MergeColumnHeaderInfo
      {
        FromName = m_objGrid.Columns[iFromColIndex].Name,
        FromIndex = iFromColIndex,
        ToIndex = (iFromColIndex + iColMerge) - 1,
        Caption = sMergeHeader,
        Width = iW,
        Cover = false
      };
      m_dicMergeInfo.Add(objInfo.FromIndex, objInfo);
    }

    private int GetPosX(int iFromColIndex)
    {
      if (m_objGrid.Visible)
        return (m_objGrid.GetColumnDisplayRectangle(iFromColIndex, true).X + m_objGrid.Left);
      else
      {
        int iX = m_objGrid.RowHeadersWidth + 2;
        for (int i = 0; i < iFromColIndex - 1; i--)
        {
          if (m_objGrid.Columns[i].Visible)
            iX += m_objGrid.Columns[i].Width;
        }
        return (iX + m_objGrid.Left);
      }
    }

    public void MergeColumnHeader(string sMergeHeader, string sFromColName, int iColMerge)
    {
      if (!m_objGrid.Columns.Contains(sFromColName))
        throw new Exception(string.Format("MergeColumnHeader: Column name '{0}' not found in data grid column", sFromColName));

      int iIndex = m_objGrid.Columns[sFromColName].Index;
      MergeColumnHeader(sMergeHeader, iIndex, iColMerge);
    }

    public void Filter_AppendColumn(string sColummName, string sCaption)
    {
      if (m_dicFilterColumn == null)
        m_dicFilterColumn = new Dictionary<string, string>();
      if (m_dicFilterColumn.ContainsKey(sColummName))
        m_dicFilterColumn[sColummName] = sCaption;
      else
        m_dicFilterColumn.Add(sColummName, sCaption);
    }

    public void Filter_Reset()
    {
      if (m_dicFilterColumn != null)
        m_dicFilterColumn.Clear();
    }

    private void m_objGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      try
      {
        m_objGrid.CurrentCell.Tag = "Edit";
        m_objGrid.CurrentRow.Tag = "Edit";
      }
      catch
      {
      }
    }

    private void m_objGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      try
      {
        m_objGrid.CurrentCell.Tag = null;
      }
      catch
      {
      }
    }

    private void m_objGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      try
      {
        if ((((!m_objGrid.ReadOnly && (e.Button == MouseButtons.Right)) && ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))) && ((m_objGrid.Columns[e.ColumnIndex].ValueType != null) && "Int32,Int64,Int16,Decimal,String".Contains(m_objGrid.Columns[e.ColumnIndex].ValueType.Name))) && (m_objGrid.SelectedRows.Count <= 0))
        {
          DataGridViewCell mCell = m_objGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
          if ((mCell.Selected && !mCell.ReadOnly) && ((mCell is DataGridViewTextBoxCell) || ((mCell is DataGridViewComboBoxCell) & (m_objGrid.Columns[e.ColumnIndex].ValueType.Name == "String"))))
          {
            Rectangle r = m_objGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            m_txtCellEdit.Parent = m_objGrid.Parent;
            m_txtCellEdit.Location = new Point(r.X + m_objGrid.Left, r.Y + m_objGrid.Top);
            m_txtCellEdit.Size = new Size(r.Width, r.Height);
            m_txtCellEdit.Text = Globals.Object_GetDisplayValue(mCell.Value, "");

            if (mCell.OwningColumn is DataGridViewTextBoxColumn)
              m_txtCellEdit.MaxLength = ((DataGridViewTextBoxColumn)mCell.OwningColumn).MaxInputLength;
            else
              m_txtCellEdit.MaxLength = 0;

            m_txtCellEdit.Tag = m_objGrid.Columns[e.ColumnIndex].ValueType.Name;
            if (m_txtCellEdit.Tag.ToString() == "String")
              m_txtCellEdit.TextAlign = HorizontalAlignment.Left;
            else
              m_txtCellEdit.TextAlign = HorizontalAlignment.Right;

            m_txtCellEdit.Visible = true;
            m_txtCellEdit.BringToFront();
            m_txtCellEdit.Focus();
            m_txtCellEdit.SelectAll();
            m_objGrid.Enabled = false;
          }
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex, "DataGridHanle.CellMouseClick");
      }
    }

    private void m_objGrid_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
    {
      try
      {
        if (((!m_bIsLoading && (m_objGrid.SelectionMode == DataGridViewSelectionMode.CellSelect)) && ((e.StateChanged == DataGridViewElementStates.Selected) && e.Cell.Selected)) && (m_objGrid.SelectedCells.Count > 1))
        {
          if (m_objGrid.SelectedCells.Count == 2)
          {
            if (m_objGrid.SelectedCells[0].ColumnIndex != m_objGrid.SelectedCells[1].ColumnIndex)
              e.Cell.Selected = false;
          }
          else if (m_objGrid.SelectedCells[2].ColumnIndex == m_objGrid.SelectedCells[1].ColumnIndex)
          {
            if (e.Cell.ColumnIndex != m_objGrid.SelectedCells[2].ColumnIndex)
              e.Cell.Selected = false;
          }
          else
            e.Cell.Selected = false;
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void m_objGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
      try
      {
        DataTable mDataSource;
        if ((m_objGrid.EditingControl != null) && (m_objGrid.CurrentCell.Tag != null))
        {
          if (!(m_objGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn))
          {
            switch (m_objGrid.CurrentCell.ValueType.Name)
            {
              case "DateTime":
                {
                  DateTime mDate = new DateTime();
                  string sValue = m_objGrid.EditingControl.Text;
                  if (m_objGrid.CurrentCell.OwningColumn.HeaderCell.Tag.ToString() == "DateShort")
                  {
                    m_objGrid.CancelEdit();
                    ValidateDateShort(sValue, e.ColumnIndex, e.RowIndex);
                    break;
                  }
                  Globals.Date_FixString(ref sValue, false);
                  if (Globals.Date_TryParseEx(sValue, ref mDate))
                  {
                    m_objGrid.EditingControl.Text = mDate.ToString(Globals.CS_DISPLAY_DATE_FORMAT);
                    m_objGrid.CurrentCell.Value = mDate;
                    break;
                  }
                  m_objGrid.EditingControl.Text = "";
                  m_objGrid.CurrentCell.Value = DBNull.Value;
                  break;
                }
              case "Double":
              case "Decimal":
              case "Integer":
              case "Long":
              case "Int32":
              case "Int64":
              case "Int16":
                {
                  string sText = m_objGrid.EditingControl.Text;
                  if (sText.Length > 0)
                  {
                    string sFormula = null;
                    decimal iValue = new decimal();
                    if (sText.StartsWith("="))
                    {
                      sFormula = sText.Substring(1);
                      if (Globals.CS_DECIMAL_SYMBOL != ".")
                        sFormula = sFormula.Replace(Globals.CS_DECIMAL_SYMBOL, ".");

                      iValue = Formula_Evaluate(sFormula);
                      if (Null.IsNull(iValue))
                        m_objGrid.CancelEdit();
                      else
                      {
                        m_objGrid.CurrentCell.Value = iValue;
                        m_objGrid.EditingControl.Text = Convert.ToString(m_objGrid.CurrentCell.Value);
                      }
                    }
                    else if (Formula_Prepare(sText, ref sFormula, ref iValue) && (sFormula != ""))
                    {
                      Formula_Calculate(m_objGrid.CurrentCell, sFormula, iValue);
                      m_objGrid.EditingControl.Text = Convert.ToString(m_objGrid.CurrentCell.Value);
                    }
                  }
                  if (m_objGrid.CurrentCell.OwningColumn.HeaderCell.Tag.ToString() == "DateShort")
                  {
                    sText = m_objGrid.EditingControl.Text;
                    m_objGrid.CancelEdit();
                    ValidateDateShort(sText, e.ColumnIndex, e.RowIndex);
                  }
                  break;
                }
            }
            mDataSource = (DataTable)m_objGrid.DataSource;
            string sColumnName = m_objGrid.Columns[e.ColumnIndex].DataPropertyName;
            if (mDataSource.Columns.Contains(sColumnName) && (mDataSource.Columns[sColumnName].DefaultValue != null))
            {
              m_objGrid.CurrentCell.Value = mDataSource.Columns[sColumnName].DefaultValue;
              m_objGrid.EditingControl.Text = Globals.DB_GetString(mDataSource.Columns[sColumnName].DefaultValue, "");
            }
            else
            {
              m_objGrid.CurrentCell.Value = DBNull.Value;
              m_objGrid.EditingControl.Text = "";
            }
          }
          else if (m_objGrid.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
          {
            ComboBox objComboBox = (ComboBox)m_objGrid.EditingControl;
            long iIndex = objComboBox.FindString(Convert.ToString(e.FormattedValue));
            if (iIndex >= 0L)
              objComboBox.SelectedIndex = (int)iIndex;
            else if (objComboBox.Items.Count > 0)
              objComboBox.SelectedIndex = 0;
          }
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex, "DataGridHandle.CellValidating");
      }
    }

    private void ValidateDateShort(string sValue, int iColumnIndex, int iRowIndex)
    {
      string sColName = m_objGrid.Columns[iColumnIndex].Name;
      object temp = null;
      if (!sColName.Contains("_YEAR"))
      {
        bool bShortDate = (sValue.Length < 6) || System.Text.RegularExpressions.Regex.IsMatch(sValue, "##-??");
        Globals.Date_FixString(ref sValue, false);
        if (Globals.IsDate(sValue))
        {
          DateTime mDate = new DateTime();
          temp = mDate;
          Globals.Object_SetValue(sValue, ref temp);
          mDate = Convert.ToDateTime(mDate);
          sValue = mDate.ToString("dd-MMM");
          sColName = m_objGrid.Columns[iColumnIndex].Name + "_YEAR";
          if (!bShortDate)
          {
            if (m_objGrid.Columns.Contains(sColName))
              m_objGrid.Rows[iRowIndex].Cells[sColName].Value = mDate.Year;
          }
          else if (m_objGrid.EditingControl.Text != "29-FEB")
          {
            string sYear = null;
            if (m_objGrid.Columns.Contains(sColName))
              sYear = Globals.DB_GetString(m_objGrid.Rows[iRowIndex].Cells[sColName].Value, "");

            if (string.IsNullOrEmpty(sYear))
              sYear = "1999";

            temp = mDate;
            Globals.Object_SetValue(sValue + "-" + sYear, ref temp);
            mDate = Convert.ToDateTime(mDate);
          }
          m_objGrid.Rows[iRowIndex].Cells[iColumnIndex].Value = mDate;
        }
        else
        {
          m_objGrid.Rows[iRowIndex].Cells[iColumnIndex].Value = DBNull.Value;
        }
      }
      else
      {
        DateTime mDate = new DateTime();
        temp = mDate;
        sColName = sColName.Replace("_YEAR", "");
        string sText = Convert.ToString(m_objGrid.Rows[iRowIndex].Cells[sColName].EditedFormattedValue);
        Globals.Object_SetValue(sText + "-" + sValue, ref temp);
        mDate = Convert.ToDateTime(mDate);
        if (Null.IsNull(mDate))
        {
          m_objGrid.Rows[iRowIndex].Cells[sColName].Value = DBNull.Value;
          Globals.Object_SetValue(sText + "-1999", ref temp);
          mDate = Convert.ToDateTime(mDate);
        }
        else
          m_objGrid.Rows[iRowIndex].Cells[iColumnIndex].Value = mDate.Year;

        m_objGrid.Rows[iRowIndex].Cells[sColName].Value = mDate;
      }
    }

    private void m_objGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      try
      {
        m_bIsLoading = true;
        m_objGrid.ClearSelection();

        foreach (DataGridViewRow mRow in m_objGrid.Rows)
        {
          if (!mRow.IsNewRow)
            mRow.Cells[e.ColumnIndex].Selected = true;
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
      finally
      {
        m_bIsLoading = false;
      }
    }

    private void m_objGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      try
      {
        string sMsg;
        if (e.Exception != null)
          sMsg = e.Exception.Message;
        else
          return;

        if ((e.Context & DataGridViewDataErrorContexts.Commit) > 0)
        {
          if (!m_objGrid.CurrentRow.IsNewRow)
          {
            if (Regex.IsMatch(sMsg, "Column '.*' does not allow nulls."))
            {
              int iPos = sMsg.IndexOf("'") + 1;
              string sColumn = sMsg.Substring(iPos, sMsg.IndexOf("'", (int)(iPos + 1)) - iPos);
              if (!m_objGrid.Columns.Contains(sColumn))
              {
                e.ThrowException = true;
                return;
              }
              int iColIndex = m_objGrid.Columns[sColumn].Index;
              if (m_objGrid.CurrentRow.Cells[iColIndex].Visible)
                m_objGrid.CurrentCell = m_objGrid.CurrentRow.Cells[iColIndex];

              string sColHeader = m_objGrid.Columns[iColIndex].HeaderText;
              if (string.IsNullOrEmpty(sColHeader))
                sColHeader = m_objGrid.Columns[iColIndex].ToolTipText;

              sMsg = Regex.Replace(sMsg, "(Column ').*(' does not allow nulls.)", "$1 " + sColHeader + " $2");
            }
            else if (sMsg == "Input string was not in a correct format.")
            {
              string sDataType;
              switch (m_objGrid.Columns[e.ColumnIndex].ValueType.Name)
              {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Integer":
                case "Long":
                case "Short":
                  sDataType = "Integer";
                  break;
                case "Float":
                case "Double":
                case "Single":
                  sDataType = "Numeric";
                  break;
                case "Date":
                case "DateTime":
                  sDataType = "Date";
                  break;
                default:
                  sDataType = m_objGrid.Columns[e.ColumnIndex].ValueType.Name;
                  break;
              }
              sMsg = "Please input " + sDataType + " data type";
            }
            else if (sMsg.IndexOf("The string was not recognized as a valid DateTime") > -1)
              sMsg = "Please input Date data type";

            else if (sMsg.Contains("unique"))
            {
              int iPos = sMsg.IndexOf("'") + 1;
              string sColumn = sMsg.Substring(iPos, sMsg.IndexOf("'", (int)(iPos + 1)) - iPos);
              if (!m_objGrid.Columns.Contains(sColumn))
                return;

              int iColIndex = m_objGrid.Columns[sColumn].Index;
              if (m_objGrid.CurrentRow.Cells[iColIndex].Visible)
                m_objGrid.CurrentCell = m_objGrid.CurrentRow.Cells[iColIndex];

              string sColHeader = m_objGrid.Columns[iColIndex].HeaderText;
              if (string.IsNullOrEmpty(sColHeader))
                sColHeader = m_objGrid.Columns[iColIndex].ToolTipText;

              sMsg = "Please input unique value for column '" + sColHeader + "'";
            }
            else if (sMsg == "DataGridViewComboBoxCell value is not valid.")
              sMsg = "Cell value not contains in list";

            FormGlobals.Message_Information(sMsg);
            e.Cancel = true;
          }
          e.ThrowException = false;
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void m_objGrid_DataSourceChanged(object sender, EventArgs e)
    {
      try
      {
        if (m_objGrid.DataSource is DataTable)
          m_SourceTable = (DataTable)m_objGrid.DataSource;
        else if (m_objGrid.DataSource is DataView)
          m_SourceTable = ((DataView)m_objGrid.DataSource).Table;
        else
        {
          m_SourceTable = null;
          return;
        }

        if (_AutoRequired)
        {
          foreach (DataColumn mColumn in m_SourceTable.Columns)
          {
            if (!mColumn.AllowDBNull && !m_objGrid.Columns.Contains(mColumn.ColumnName))
              mColumn.AllowDBNull = true;
          }
          return;
        }

        if (m_dicRequiredColumn == null)
        {
          m_dicRequiredColumn = new List<string>();

          foreach (DataColumn mColumn in m_SourceTable.Columns)
          {
            if (!mColumn.AllowDBNull)
            {
              m_dicRequiredColumn.Add(mColumn.ColumnName.ToUpper());
              mColumn.AllowDBNull = true;
            }
          }
        }
        foreach (DataGridViewRow mRow in m_objGrid.Rows)
        {
          mRow.Cells[0].Selected = true;
          int i = 1;
          if (i > 5)
            break;
        }
        m_objGrid.ClearSelection();
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex, "DataGridHandle.DataSourceChange");
      }
    }

    private void m_objGrid_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if ((e.Control & (e.KeyCode == Keys.C)) | (e.Control & (e.KeyCode == Keys.Insert)))
        {
          if (m_objGrid.ClipboardCopyMode != DataGridViewClipboardCopyMode.Disable)
            m_objGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;

          FormGlobals.App_ShowProgress(new MethodInvoker(CopyToClipboard), "Copy data to clipboard");
          e.Handled = true;
        }
        else if ((e.Control & (e.KeyCode == Keys.V)) | (e.Shift & (e.KeyCode == Keys.Insert)))
        {
          if (!m_objGrid.ReadOnly)
          {
            FormGlobals.App_ShowProgress(new MethodInvoker(PasteFromClipboard), "Paste data to clipboard");
            e.Handled = true;
          }
        }
        else if ((e.KeyCode == Keys.Delete) && (!m_objGrid.ReadOnly && (m_objGrid.SelectedRows.Count <= 0)))
        {
          foreach (DataGridViewCell mCell in m_objGrid.SelectedCells)
          {
            if (((((m_SourceTable != null) && m_SourceTable.Columns.Contains(mCell.OwningColumn.DataPropertyName)) && (!m_SourceTable.Columns[mCell.OwningColumn.DataPropertyName].AllowDBNull || (m_SourceTable.Columns[mCell.OwningColumn.DataPropertyName].DefaultValue != System.DBNull.Value))) ? 1 : 0) == 0)
            {
              mCell.Value = DBNull.Value;
              RaEvent_CellEdit(mCell);
            }
          }
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex, "DataGridHandle.PreviewKeyDown");
      }
    }

    private void PasteFromClipboard()
    {
      string sTemp = Clipboard.GetText();
      if (!string.IsNullOrEmpty(sTemp) && !m_objGrid.ReadOnly)
        PasteTextData(sTemp, true);
    }

    private void PasteTextData4Cell(string[] arrRows)
    {
      int iCellIndex = 0;
      int iRowIndex = 0;
      if (arrRows.Length != m_objGrid.SelectedCells.Count)
      {
      }
      int iLastIndex = m_objGrid.SelectedCells.Count - 1;
      bool bReverse = m_objGrid.SelectedCells[0].RowIndex > m_objGrid.SelectedCells[iLastIndex].RowIndex;
      if (iLastIndex == 0)
      {
        iRowIndex = m_objGrid.SelectedCells[0].RowIndex;
        iCellIndex = m_objGrid.SelectedCells[0].ColumnIndex;
      }
      for (int i = 0; i <= arrRows.Length - 1; i++)
      {
        int iIndex;
        DataGridViewCell mCell;
        if ((i >= m_objGrid.SelectedCells.Count) && (iLastIndex > 0))
          break;

        if (bReverse)
          iIndex = iLastIndex - i;
        else
          iIndex = i;

        if (iLastIndex > 0)
          mCell = m_objGrid.SelectedCells[iIndex];
        else
        {
          if ((iRowIndex + i) == m_objGrid.Rows.Count)
            break;

          mCell = m_objGrid.Rows[iRowIndex + i].Cells[iCellIndex];
        }
        if (((mCell.ReadOnly || mCell.OwningRow.IsNewRow) ? 1 : 0) == 0)
        {
          mCell.Value = Globals.Object_SetValueEx(arrRows[i], mCell.ValueType.Name, true);
          RaEvent_CellEdit(mCell);
        }
      }
    }

    public void PasteTextData(string sTextData, bool bFromClipboard)
    {
      _PasteClipboard = bFromClipboard;
      sTextData = sTextData.Replace("\r\n", "\n");
      string[] arrRows = sTextData.Split(new char[] { '\n' });
      string[] arrHeader = arrRows[0].Split(new char[] { '\t' });

      if (arrHeader.Length == 1)
        PasteTextData4Cell(arrRows);
      else if ((!bFromClipboard || m_objGrid.CurrentRow.IsNewRow) && (arrRows.Length != 1))
      {
        DataTable mDataSource;
        DataRow mRow;
        if ((m_dicMappingColumn != null) && (m_dicMappingColumn.Count > 0))
        {
          for (int i = 0; i <= arrHeader.Length - 1; i++)
          {
            if (m_dicMappingColumn.ContainsKey(arrHeader[i]))
              arrHeader[i] = m_dicMappingColumn[arrHeader[i]];
          }
        }
        if (m_objGrid.DataSource is DataTable)
          mDataSource = (DataTable)m_objGrid.DataSource;
        else
          mDataSource = ((DataView)m_objGrid.DataSource).Table;

        DataTable mDataTemp = mDataSource.Clone();
        for (int i = 1; i <= arrRows.Length - 1; i++)
        {
          string[] arrFields = arrRows[i].Split(new char[] { '\t' });
          mRow = mDataTemp.NewRow();
          if (arrFields.Length == arrHeader.Length)
          {
            for (int j = 0; j <= arrFields.Length - 1; j++)
            {
              string sFieldName = arrHeader[j];
              if (mDataTemp.Columns.Contains(sFieldName))
              {
                if (sFieldName.ToUpper() == _sPrimaryKey.ToUpper())
                  mRow[sFieldName] = DBNull.Value;
                else if (m_objGrid.Columns.Contains(sFieldName) && m_objGrid.Columns[sFieldName].ReadOnly)
                  mRow[sFieldName] = mDataSource.Columns[sFieldName].DefaultValue;
                else if (arrFields[j].Length == 0)
                {
                  if (mDataSource.Columns[sFieldName].AllowDBNull || (mDataSource.Columns[sFieldName].DefaultValue == null))
                    mRow[sFieldName] = DBNull.Value;
                  else
                    mRow[sFieldName] = mDataSource.Columns[sFieldName].DefaultValue;
                }
                else
                {
                  if ((m_dicMappingValue != null) && m_dicMappingValue.ContainsKey(arrFields[j]))
                    arrFields[j] = m_dicMappingValue[arrFields[j]];

                  mRow[sFieldName] = arrFields[j];
                }
              }
            }
            try
            {
              mDataTemp.Rows.Add(mRow);
              bool bPassed = true;
              Verify_PasteRowData(mRow, ref bPassed);

              if (!bPassed)
                mDataTemp.Rows.Remove(mRow);
            }
            catch
            {
              DialogResult rs = FormGlobals.Message_YesNoCancel("Some error occur when paste rows data.\rClick Yes to continue with others rows.\rClick No to stop with current rows.\rClick Cancel to cancel paste data.");
              if (rs == DialogResult.Yes)
              {
                if (rs == DialogResult.No)
                  break;
                return;
              }
            }
          }
        }
        int iRowCount = mDataTemp.Rows.Count;
        if (iRowCount > 0)
        {
          int iRowPos = 0;
          string sOldFilter = mDataSource.DefaultView.RowFilter;
          mDataSource.DefaultView.RowFilter = "";

          foreach (DataRow mRow1 in mDataTemp.Rows)
          {
            iRowPos++;
            Progress_PasteRowData(iRowPos, iRowCount);
            mDataSource.ImportRow(mRow1);
            if (bFromClipboard)
              After_PasteRowData(m_objGrid, new DataGridViewCellEventArgs(-1, m_objGrid.NewRowIndex - 2));
            else
              After_PasteRowData(m_objGrid, new DataGridViewCellEventArgs(-1, m_objGrid.NewRowIndex - 1));
          }

          if ((iRowCount > 0) && bFromClipboard)
            m_objGrid.Rows.Remove(m_objGrid.CurrentRow);

          mDataSource.DefaultView.RowFilter = sOldFilter;
        }
        mDataTemp.Dispose();
      }
    }

    private void CopyToClipboard()
    {
      DataTable mDataSource;
      string sTemp = null;

      if (m_objGrid.SelectedRows.Count == 0)
      {
        if (m_objGrid.SelectedCells.Count != 0)
        {
          int iLastIndex = m_objGrid.SelectedCells.Count - 1;
          bool bReverse = m_objGrid.SelectedCells[0].RowIndex > m_objGrid.SelectedCells[iLastIndex].RowIndex;
          for (int i = 0; i <= iLastIndex; i++)
          {
            int iIndex;
            if (bReverse)
              iIndex = iLastIndex - i;
            else
              iIndex = i;

            if (i == 0)
              sTemp = Globals.DB_GetString(m_objGrid.SelectedCells[iIndex].Value, "");
            else
              sTemp = sTemp + "\r\n" + Globals.DB_GetString(m_objGrid.SelectedCells[iIndex].Value, "");
          }
          Clipboard.SetText(sTemp);
        }
        return;
      }
      if (m_objGrid.ClipboardCopyMode != DataGridViewClipboardCopyMode.Disable)
        m_objGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;

      if (m_objGrid.DataSource is DataTable)
        mDataSource = (DataTable)m_objGrid.DataSource;
      else
        mDataSource = ((DataView)m_objGrid.DataSource).Table;

      DataRowView dtRow = null;
      string sRow = null;

      foreach (DataColumn mCol in mDataSource.Columns)
      {
        if (((mCol.ColumnName == _sPrimaryKey) || (mCol.ColumnName != mCol.Caption)) || (m_objGrid.Columns.Contains(mCol.ColumnName) && !m_objGrid.Columns[mCol.ColumnName].Visible))
          mCol.AllowDBNull = true;
        else
        {
          if (!string.IsNullOrEmpty(sRow))
            sRow = sRow + "\t";

          sRow = sRow + mCol.ColumnName;
        }
      }

      string[] arrColumns = sRow.Split(new char[] { '\t' });
      sTemp = sRow;
      for (int i = 0; i < m_objGrid.SelectedRows.Count - 1; i--)
      {
        DataGridViewRow mRow = m_objGrid.SelectedRows[i];
        if (!mRow.IsNewRow && (mRow.DataBoundItem != null))
        {
          dtRow = (DataRowView)mRow.DataBoundItem;
          sRow = null;
          foreach (string sColumn in arrColumns)
          {
            if (sRow != null)
              sRow = sRow + "\t";

            sRow = sRow + Globals.DB_GetString(dtRow[sColumn], "");
          }
          sTemp = sTemp + "\r\n" + sRow;
        }
      }
      Clipboard.SetText(sTemp);
    }

    private void m_objGrid_Paint(object sender, PaintEventArgs e)
    {
      foreach (MergeColumnHeaderInfo objInfo in m_dicMergeInfo.Values)
      {
        PaintMergeHeader(objInfo, -1);
      }
    }

    private void m_objGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if ((e.RowIndex == -1) && (e.ColumnIndex > -1))
      {
        if (!m_dicMergeColIndex.Contains(e.ColumnIndex))
        {
          e.PaintBackground(e.CellBounds, true);
          e.PaintContent(e.CellBounds);
          e.Handled = true;
        }
        else
        {
          e.PaintBackground(e.CellBounds, true);
          e.Handled = true;
          if (m_dicMergeInfo.ContainsKey(e.ColumnIndex))
            PaintMergeHeader(m_dicMergeInfo[e.ColumnIndex], -1);

          if (_KeepMergeHeader)
            e.PaintContent(e.CellBounds);
        }
      }
    }

    private void m_objGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
    {
      try
      {
        if (m_objGrid.Visible)
        {
          foreach (MergeColumnHeaderInfo objInfo in m_dicMergeInfo.Values)
          {
            MergeColumnHeaderInfo temp = objInfo;
            if ((((e.Column.DisplayIndex < temp.FromIndex) || (e.Column.DisplayIndex > temp.ToIndex)) ? 1 : 0) == 0)
            {
              temp.Width = GetColWidth(objInfo.FromIndex, objInfo.ToIndex);
              PaintMergeHeader(temp, -1);
            }
          }
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private int GetColWidth(int iFromColIndex, int iToColIndex)
    {
      int iW = 0;
      for (int i = iFromColIndex; i <= iToColIndex; i++)
      {
        iW += m_objGrid.Columns[i].Width;
      }
      return iW;
    }

    private void PaintMergeHeader(MergeColumnHeaderInfo objInfo, int iShiftIndex)
    {
      Graphics objGraphics;
      Rectangle r1 = m_objGrid.GetCellDisplayRectangle(objInfo.FromIndex, -1, true);
      int w2 = objInfo.Width;
      r1.X++;
      r1.Y += 2;
      r1.Width = w2 - 2;
      r1.Height -= 4;
      StringFormat format = new StringFormat
      {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center
      };
      if (iShiftIndex > -1)
      {
        Rectangle r2 = m_objGrid.GetCellDisplayRectangle(iShiftIndex, -1, true);
        if (!objInfo.Cover)
        {
          r2.Height = (int)Math.Round((double)((((double)r2.Height) / 2.0) + 2.0));
        }
        r2.Y += 2;
        r2.Width = GetColWidth(iShiftIndex, objInfo.ToIndex) - 4;
        objGraphics = m_objGrid.CreateGraphics();
        objGraphics.FillRectangle(new SolidBrush(m_objGrid.ColumnHeadersDefaultCellStyle.BackColor), r2);
        r2.Width = r1.Width;
        objGraphics.DrawString(objInfo.Caption, m_objGrid.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(m_objGrid.ColumnHeadersDefaultCellStyle.ForeColor), r2, format);
        objGraphics.Dispose();
      }
      else
      {
        objGraphics = m_objGrid.CreateGraphics();
        if (!objInfo.Cover)
        {
          Pen pen1;
          Pen pen2;
          r1.Height = (int)Math.Round((double)((((double)r1.Height) / 2.0) + 0.0));
          if (FormGlobals.App_GetTheme() == "WindowsClassic")
          {
            pen1 = Pens.Gray;
            pen2 = Pens.WhiteSmoke;
          }
          else
          {
            pen1 = Pens.LightGray;
            pen2 = Pens.White;
          }
          objGraphics.DrawLine(pen1, r1.Left, r1.Height + 3, (r1.Left + w2) - 2, r1.Height + 3);
          objGraphics.DrawLine(pen2, r1.Left, r1.Height + 4, (r1.Left + w2) - 2, r1.Height + 4);
        }
        objGraphics.FillRectangle(new SolidBrush(m_objGrid.ColumnHeadersDefaultCellStyle.BackColor), r1);
        objGraphics.DrawString(objInfo.Caption, m_objGrid.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(m_objGrid.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
        objGraphics.Dispose();
      }
    }

    private void m_objGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      try
      {
        m_objGrid.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        m_objGrid.Rows[e.RowIndex].Selected = true;
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void m_objGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
      try
      {
        if ((!_AutoRequired && (m_dicRequiredColumn != null)) && (m_SourceTable != null))
        {
          foreach (string mColumnName in m_dicRequiredColumn)
          {
            if (((m_objGrid.Rows[e.RowIndex].DataBoundItem != null) &&
                (m_SourceTable.Columns[mColumnName].DefaultValue != null)) &&
                (!(m_SourceTable.Columns[mColumnName].DefaultValue == DBNull.Value) &&
                m_objGrid.Rows[e.RowIndex].DataBoundItem == DBNull.Value))
            {
              //((DataGridView)m_objGrid).Rows[e.RowIndex].DataBoundItem = m_SourceTable.Columns[mColumnName].DefaultValue;
            }
          }
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void m_objGrid_RowValidated(object sender, DataGridViewCellEventArgs e)
    {
      if (m_objGrid.CurrentRow != null)
        m_objGrid.CurrentRow.Tag = null;
    }

    private void m_objGrid_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
    {
      try
      {
        if ((m_objGrid.CurrentRow.Tag != null) && !m_bIsLoading)
          ValidateRow(e.RowIndex);
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    public void ValidateRow(int iRowIndex)
    {
      DataRow dr = null;
      if (m_objGrid.Rows[iRowIndex].DataBoundItem is DataRowView)
        dr = ((DataRowView)m_objGrid.CurrentRow.DataBoundItem).Row;
      if (dr != null)
        dr.RowError = "";

      m_objGrid.Rows[iRowIndex].ErrorText = "";
      if (!m_objGrid.Rows[iRowIndex].IsNewRow)
      {
        foreach (DataGridViewCell mCell in m_objGrid.Rows[iRowIndex].Cells)
        {
          string sDataColName = m_objGrid.Columns[mCell.ColumnIndex].DataPropertyName;
          if (mCell is DataGridViewCheckBoxCell)
          {
            if (mCell.Value == System.DBNull.Value)
              mCell.Value = "0";
          }
          else if ((mCell is DataGridViewComboBoxCell) && (!(mCell.Value == System.DBNull.Value) && (mCell.Value.ToString() == mCell.EditedFormattedValue.ToString())))
          {
            if ((dr != null) && (sDataColName != ""))
              dr.SetColumnError(sDataColName, "");
            else
              mCell.ErrorText = "";
          }
          else
          {
            if ((m_dicRequiredColumn != null) && m_dicRequiredColumn.Contains(mCell.OwningColumn.DataPropertyName.ToUpper()))
            {
              if (Globals.DB_GetString(mCell.Value, "") == "")
              {
                if (string.IsNullOrEmpty(mCell.ErrorText))
                {
                  if ((dr != null) && (sDataColName != ""))
                    dr.SetColumnError(sDataColName, "Required value");
                  else
                    mCell.ErrorText = "Required value";
                }
              }
              else if (mCell.ErrorText == "Required value")
              {
                if ((dr != null) && (sDataColName != ""))
                  dr.SetColumnError(sDataColName, "");
                else
                  mCell.ErrorText = "";
              }
            }
            if (mCell.ErrorText != "")
            {
              string sHead = mCell.OwningColumn.HeaderText;
              if (mCell.OwningColumn.Tag != null)
                sHead = Convert.ToString(mCell.OwningColumn.Tag);
              if (string.IsNullOrEmpty(sHead))
                sHead = mCell.OwningColumn.ToolTipText;

              if (string.IsNullOrEmpty(m_objGrid.Rows[iRowIndex].ErrorText))
              {
                if (dr != null)
                  dr.RowError += "Error in Cell(s): '" + sHead + "'";
                else
                  m_objGrid.Rows[iRowIndex].ErrorText += "Error in Cell(s): '" + sHead + "'";
              }
              else if (dr != null)
                dr.RowError += ", '" + sHead + "'";
              else
                m_objGrid.Rows[iRowIndex].ErrorText += ", '" + sHead + "'";
            }
          }
        }
      }
    }

    private void m_objGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
    {
      int iCount = m_objGrid.SelectedRows.Count;
      if (m_objGrid.SelectedRows.Contains(m_objGrid.Rows[m_objGrid.NewRowIndex]))
        iCount--;
      if ((iCount > 1) || _MultiDelete)
      {
        if (!_MultiDelete)
        {
          _MultiDelete = true;
          _ConfirmDelete = FormGlobals.Message_Delete("current selected rows", "");
          _RowSelectCount = iCount;
        }
        e.Cancel = !_ConfirmDelete;
        _RowSelectCount--;
        if (_RowSelectCount == 0)
          _MultiDelete = false;
      }
      else
        e.Cancel = !FormGlobals.Message_Delete("current row", "");
    }

    private void m_txtCellEdit_Leave(object sender, EventArgs e)
    {
      try
      {
        m_txtCellEdit.Visible = false;
        m_objGrid.Enabled = true;
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void m_txtCellEdit_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Return)
        {
          e.IsInputKey = false;
          string sText = m_txtCellEdit.Text;
          if (m_txtCellEdit.Tag.ToString() == "String")
            ProcessMultiCellEdit(m_txtCellEdit.Text);
          else
          {
            if (sText.Length == 0)
            {
              ProcessMultiCellEdit("");
              return;
            }
            string sFormula = null;
            decimal iValue = new decimal();
            if (Formula_Prepare(sText, ref sFormula, ref iValue))
              ProcessMultiCellEdit(sFormula, iValue);
            else
              FormGlobals.Message_Information("Invalid formula or value for multi cell edit.\rFormula support is  + - * / and r (round) or o (auto order).\rPlease contact system administrator for more information.");
          }
        }
        else if ((e.KeyCode != Keys.Escape) & (e.KeyCode != Keys.Tab))
        {
          return;
        }
        m_txtCellEdit.Visible = false;
        m_objGrid.Enabled = true;
        m_objGrid.Focus();
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void ProcessMultiCellEdit(string sFormula, decimal iValue)
    {
      if ((sFormula == "/") && (decimal.Compare(iValue, decimal.Zero) == 0))
        return;

      if (sFormula == "o")
        m_iOrder = 0;

      for (int i = 0; i < m_objGrid.SelectedCells.Count - 1; i--)
      {
        DataGridViewCell mCell = m_objGrid.SelectedCells[i];
        if (((mCell.ReadOnly || mCell.OwningRow.IsNewRow) ? 1 : 0) == 0)
        {
          mCell.Tag = "Edit";
          Formula_Calculate(mCell, sFormula, iValue);
          RaEvent_CellEdit(mCell);
        }
      }
    }

    private void RaEvent_CellEdit(DataGridViewCell mCell)
    {
      if (mCell.OwningColumn.HeaderCell.Tag.ToString() == "DateShort")
      {
        ValidateDateShort(Globals.DB_GetString(mCell.Value, ""), mCell.ColumnIndex, mCell.RowIndex);
      }
      m_objGrid.Rows[mCell.RowIndex].Tag = "Edit";
      After_PasteCellData(m_objGrid, new DataGridViewCellEventArgs(mCell.ColumnIndex, mCell.RowIndex));
    }

    private void ProcessMultiCellEdit(string sValue)
    {
      foreach (DataGridViewCell mCell in m_objGrid.SelectedCells)
      {
        if (!mCell.ReadOnly && !mCell.OwningRow.IsNewRow)
        {
          mCell.Tag = "Edit";
          if (string.IsNullOrEmpty(sValue))
            mCell.Value = DBNull.Value;
          else
            mCell.Value = sValue;

          RaEvent_CellEdit(mCell);
        }
      }
    }

    private void Formula_Calculate(DataGridViewCell mCell, string sFormula, decimal iValue)
    {
      switch (sFormula)
      {
        case "+":
          mCell.Value = Convert.ToDecimal(Globals.DB_GetValue(mCell.Value, 0)) + iValue;
          break;
        case "-":
          mCell.Value = Convert.ToDecimal(Globals.DB_GetValue(mCell.Value, 0)) - iValue;
          break;
        case "/":
          mCell.Value = Convert.ToDecimal(Globals.DB_GetValue(mCell.Value, 0)) / iValue;
          break;
        case "*":
          mCell.Value = Convert.ToDecimal(Globals.DB_GetValue(mCell.Value, 0)) * iValue;
          break;
        case "r":
          {
            decimal tmp = Convert.ToDecimal(Globals.DB_GetValue(mCell.Value, 0));
            tmp = tmp / iValue;
            tmp = Decimal.Round(tmp, 0);
            tmp = tmp * iValue;
            mCell.Value = tmp;
            break;
          }
        case "rh":
          {
            decimal tmp = Convert.ToDecimal(Globals.DB_GetValue(mCell.Value, 0));
            tmp = tmp / (iValue / Convert.ToDecimal(0.5));
            tmp = Decimal.Round(tmp, 0) * (iValue / Convert.ToDecimal(0.5));
            if (tmp < Convert.ToDecimal(Globals.DB_GetValue(mCell.Value, 0)))
              tmp += iValue;

            mCell.Value = tmp;
            break;
          }
        case "o":
          m_iOrder++;
          mCell.Value = iValue + m_iOrder;
          break;
        default:
          mCell.Value = iValue;
          break;
      }
    }

    private bool Formula_Prepare(string sText, ref string sFormula, ref decimal iValue)
    {
      bool bHasPercent = false;
      if (sText.Length == 0)
        return false;

      string sValue = null;
      sFormula = Convert.ToString(sText[0]);
      sFormula = sFormula.ToLower();
      if (!"+-/*ro".Contains(sFormula))
      {
        sValue = sText;
        sFormula = "";
      }
      else
      {
        if (Convert.ToString(sText[sText.Length - 1]) == "%")
        {
          bHasPercent = true;
          sValue = sText.Substring(1, sText.Length - 2);
        }
        else
          sValue = sText.Substring(1);

        if ((sFormula == "o") && (sValue == ""))
          sValue = "0";
      }
      if (!Globals.IsNumeric(sValue))
        return false;

      if (bHasPercent)
      {
        if (sFormula == "-")
        {
          sFormula = "*";
          iValue = 1 - (Decimal.Parse(sValue) / 100);
        }
        else if (sFormula == "+")
        {
          sFormula = "*";
          iValue = 1 + (Decimal.Parse(sValue) / 100);
        }
        else
          iValue = (Decimal.Parse(sValue) / 100);
      }
      else
      {
        iValue = decimal.Parse(sValue);
        if (sFormula == "r")
        {
          if ("5,50,500,5000,".Contains(sValue + ","))
            sFormula = "rh";
          else if (!"1,10,100,1000,".Contains(sValue + ","))
            return false;
        }
      }
      return true;
    }

    private decimal Formula_Evaluate(string sExp)
    {
      decimal Formula_Evaluate;
      try
      {
        DataTable table = new DataTable();
        table.Columns.Add("expression", string.Empty.GetType(), sExp);
        DataRow row = table.NewRow();
        table.Rows.Add(row);
        Formula_Evaluate = decimal.Parse(Convert.ToString(row["expression"]));
      }
      catch
      {
        Formula_Evaluate = Null.NullDecimal;
        return Formula_Evaluate;
      }
      return Formula_Evaluate;
    }

    private void ctxMenu_Click(object sender, EventArgs e)
    {
      switch (((ToolStripItem)sender).Name)
      {
        case "Filter_Edit":
          if (m_dicFilterColumn != null)
          {
            foreach (DataRow dr in m_SourceTable.GetErrors())
            {
              if (dr.RowState != DataRowState.Deleted)
              {
                FormGlobals.Message_Information("Please correct all rows error before filter data");
                break;
              }
            }
            frmGridFilter f = new frmGridFilter();
            f.Column_Name.DisplayMember = "DisplayField";
            f.Column_Name.ValueMember = "ValueField";
            foreach (string sKey in m_dicFilterColumn.Keys)
            {
              ListBoxItem itm = new ListBoxItem(sKey, m_dicFilterColumn[sKey]);
              f.Column_Name.Items.Add(itm);
            }
            DataTable dt = m_SourceTable.Clone();
            dt.DefaultView.RowFilter = m_SourceTable.DefaultView.RowFilter;
            if (f.Show_Form(dt))
            {
              frmProgress.Instance().ThreadSub = new frmProgress.SubInvoker(Filter_Apply);
              frmProgress.Instance().ThreadInputObject = f.Tag;
            }
            f.Close();
          }
          break;

        case "Filter_Clear":
          frmProgress.Instance().ThreadSub = new frmProgress.SubInvoker(Filter_Apply);
          frmProgress.Instance().ThreadInputObject = "";
          break;
      }
    }

    private void Filter_Apply(object sFilter)
    {
      if (sFilter == null)
        sFilter = "";

      if ((m_objGrid.CurrentRow != null) && m_objGrid.CurrentRow.IsNewRow)
        m_objGrid.CancelEdit();

      m_SourceTable.DefaultView.RowFilter = Convert.ToString(sFilter);
      if (m_objGrid.CurrentRow != null)
        m_objGrid.InvalidateRow(m_objGrid.CurrentRow.Index);

      m_objGrid.Refresh();
      if (m_SourceTable.DefaultView.RowFilter == "")
        m_objGrid.TopLeftHeaderCell.Style.BackColor = new Color();
      else
        m_objGrid.TopLeftHeaderCell.Style.BackColor = Color.LightGoldenrodYellow;
    }

    private void m_objGrid_ReadOnlyChanged(object sender, EventArgs e)
    {
      if (m_objGrid.ReadOnly)
        m_objGrid.TopLeftHeaderCell.ContextMenuStrip = null;
      else
        m_objGrid.TopLeftHeaderCell.ContextMenuStrip = mnuContext;
    }

    private void m_objGrid_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
    {
      DataGridViewCell mCell = m_objGrid[e.ColumnIndex, e.RowIndex];
      if (mCell.OwningRow.DataBoundItem is DataRowView)
        ((DataRowView)mCell.OwningRow.DataBoundItem).Row.SetColumnError(mCell.OwningColumn.DataPropertyName, mCell.ErrorText);
    }

    private void m_objGrid_RowErrorTextChanged(object sender, DataGridViewRowEventArgs e)
    {
      if (e.Row.DataBoundItem is DataRowView)
        ((DataRowView)e.Row.DataBoundItem).Row.RowError = e.Row.ErrorText;
    }

    private void m_objGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      if (e.Control is ComboBox)
        ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
    }

    private void m_objGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      try
      {
        if (m_DbClickMethod != null)
        {
          m_DbClickMethod();
          if (m_objGrid.ReadOnly)
            m_objGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }
  }
}