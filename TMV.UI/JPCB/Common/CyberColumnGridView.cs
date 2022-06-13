using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;

namespace TMV.UI.JPCB.Common
{
  public class CyberColumnGridView
  {
    public GridColumn Column;
    public RepositoryItem EditColumn;
    private bool _Visible;
    private bool _ReadOnly;
    private EventHandler _CyberLeave;
    private EventHandler _CyberValiting;
    private GridView View;

    public CyberColumnGridView()
    {
      Column = new GridColumn();
      EditColumn = new RepositoryItem();
      View = new GridView();
    }
    public bool Visible
    {
      get => _Visible;
      set
      {
        _Visible = value;
        V_SetColumnVisble(_Visible);
      }
    }
    public bool ColumnReadOnly
    {
      get => _ReadOnly;
      set
      {
        _ReadOnly = value;
        V_SetColumnReadOnly(_ReadOnly);
      }
    }
    public void GetColumn(GridView GridView, string Field_Name)
    {
      Column = new GridColumn();
      int num = checked(GridView.Columns.Count - 1);
      int index = 0;
      while (index <= num)
      {
        if (GridView.Columns[index].Visible && GridView.Columns[index].FieldName.ToString().Trim().ToUpper() == Field_Name.ToUpper().Trim())
        {
          Column = GridView.Columns[index];
          EditColumn = Column.ColumnEdit;
          break;
        }
        checked { ++index; }
      }
      View = GridView;
    }
    private void V_SetColumnVisble(bool Visible)
    {
      if (Column == null)
        return;

      GridColumn column = Column;
      if (column == null)
        return;

      if (!Visible)
        column.Visible = Visible;
      else
      {
        int index = checked(column.View.VisibleColumns.Count - 1);
        while (index >= 0)
        {
          if (!column.View.VisibleColumns[index].Tag.Equals(column.Tag))
          {
            column.VisibleIndex = checked(index + 1);
            break;
          }
          checked { index += -1; }
        }
        column.Visible = Visible;
      }
    }
    private void V_SetColumnReadOnly(bool _ReadOnly1)
    {
      if (Column == null)
        return;

      Column.OptionsColumn.ReadOnly = _ReadOnly1;
    }
    private void V_CyberValiting(object sender, KeyEventArgs e) => _CyberValiting(sender, e);
    private void V_CyberLeave(object sender, EventArgs e) => _CyberLeave(sender, e);
  }
}