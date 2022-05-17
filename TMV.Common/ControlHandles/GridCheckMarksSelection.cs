using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.Data;

namespace TMV.Common.ControlHandles
{
  public class GridCheckMarksSelection
  {
    private GridColumn column;
    private RepositoryItemCheckEdit edit;
    protected ArrayList selection;
    protected GridView ViewValue;

    public GridCheckMarksSelection()
    {
      selection = new ArrayList();
    }

    public GridCheckMarksSelection(GridView view)
        : this()
    {
      View = view;
    }

    protected virtual void Attach(GridView view)
    {
      if (view != null)
      {
        selection.Clear();
        ViewValue = view;
        edit = (RepositoryItemCheckEdit)view.GridControl.RepositoryItems.Add("CheckEdit");
        edit.EditValueChanged += new EventHandler(Edit_EditValueChanged);
        column = view.Columns.Add();
        column.OptionsColumn.AllowSort = DefaultBoolean.False;
        column.VisibleIndex = int.MaxValue;
        column.FieldName = "CheckMarkSelection";
        column.Caption = "Mark";
        column.OptionsColumn.ShowCaption = false;
        column.UnboundType = UnboundColumnType.Boolean;
        column.ColumnEdit = edit;
        view.Click += new EventHandler(View_Click);
        view.CustomDrawColumnHeader += new ColumnHeaderCustomDrawEventHandler(View_CustomDrawColumnHeader);
        view.CustomDrawGroupRow += new RowObjectCustomDrawEventHandler(View_CustomDrawGroupRow);
        view.CustomUnboundColumnData += new CustomColumnDataEventHandler(view_CustomUnboundColumnData);
        view.RowStyle += new RowStyleEventHandler(view_RowStyle);
      }
    }

    protected virtual void Detach()
    {
      if (View != null)
      {
        if (column != null)
          column.Dispose();
        if (edit != null)
        {
          View.GridControl.RepositoryItems.Remove(edit);
          edit.Dispose();
        }
        ViewValue.Click -= new EventHandler(View_Click);
        ViewValue.CustomDrawColumnHeader -= new ColumnHeaderCustomDrawEventHandler(View_CustomDrawColumnHeader);
        ViewValue.CustomDrawGroupRow -= new RowObjectCustomDrawEventHandler(View_CustomDrawGroupRow);
        ViewValue.CustomUnboundColumnData -= new CustomColumnDataEventHandler(view_CustomUnboundColumnData);
        ViewValue.RowStyle -= new RowStyleEventHandler(view_RowStyle);
        View = null;
      }
    }

    protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked, bool Grayed)
    {
      CheckEditViewInfo info = (CheckEditViewInfo)edit.CreateViewInfo();
      CheckEditPainter painter = (CheckEditPainter)edit.CreatePainter();
      if (Grayed)
        info.EditValue = edit.ValueGrayed;
      else
        info.EditValue = Checked;

      info.Bounds = r;
      info.CalcViewInfo(g);
      ControlGraphicsInfoArgs args = new ControlGraphicsInfoArgs(info, new GraphicsCache(g), r);
      painter.Draw(args);
      args.Cache.Dispose();
    }

    private void View_Click(object sender, EventArgs e)
    {
      Point pt = View.GridControl.PointToClient(Control.MousePosition);
      GridHitInfo info = View.CalcHitInfo(pt);
      if (info.InColumn & (info.Column == column))
      {
        if (SelectedCount == View.DataRowCount)
          ClearSelection();
        else
          SelectAll();
      }
      if ((info.InRow & View.IsGroupRow(info.RowHandle)) & (info.HitTest != GridHitTest.RowGroupButton))
      {
        bool selected = IsGroupRowSelected(info.RowHandle);
        SelectGroup(info.RowHandle, !selected);
      }
    }

    private void View_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
    {
      if (e.Column == column)
      {
        e.Info.InnerElements.Clear();
        e.Painter.DrawObject(e.Info);
        bool gray = (SelectedCount > 0) & (SelectedCount < View.DataRowCount);
        DrawCheckBox(e.Graphics, e.Bounds, SelectedCount == View.DataRowCount, gray);
        e.Handled = true;
      }
    }

    private void View_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
    {
      GridGroupRowInfo info = (GridGroupRowInfo)e.Info;
      info.GroupText = "         " + info.GroupText.TrimStart(new char[0]);
      e.Info.Paint.FillRectangle(e.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds);
      e.Painter.DrawObject(e.Info);
      Rectangle r = info.ButtonBounds;
      r.Offset(r.Width * 2, 0);
      int g = GroupRowSelectionStatus(e.RowHandle);
      DrawCheckBox(e.Graphics, r, g > 0, g < 0);
      e.Handled = true;
    }

    private void view_RowStyle(object sender, RowStyleEventArgs e)
    {
      if (IsRowSelected(e.RowHandle))
      {
        e.Appearance.BackColor = SystemColors.Highlight;
        e.Appearance.ForeColor = SystemColors.HighlightText;
      }
    }

    public GridView View
    {
      get
      {
        return ViewValue;
      }
      set
      {
        if (ViewValue != value)
        {
          Detach();
          Attach(value);
        }
      }
    }

    public GridColumn CheckMarkColumn
    {
      get
      {
        return column;
      }
    }

    public int SelectedCount
    {
      get
      {
        return selection.Count;
      }
    }

    public object GetSelectedRow(int index)
    {
      return selection[index];
    }

    public int GetSelectedIndex(object row)
    {
      return selection.IndexOf(row);
    }

    public void ClearSelection()
    {
      for (int i = 0; i <= View.DataRowCount - 1; i++)
      {
        View.SetRowCellValue(i, column, false);
      }
      Invalidate();
    }

    private void Invalidate()
    {
      View.BeginUpdate();
      View.EndUpdate();
    }

    public void SelectAll()
    {
      for (int i = 0; i <= View.DataRowCount - 1; i++)
      {
        View.SetRowCellValue(i, column, true);
      }
      Invalidate();
    }

    public void SelectGroup(int rowHandle, bool select)
    {
      if (!(IsGroupRowSelected(rowHandle) & select))
      {
        for (int i = 0; i <= View.GetChildRowCount(rowHandle) - 1; i++)
        {
          int childRowHandle = View.GetChildRowHandle(rowHandle, i);
          if (View.IsGroupRow(childRowHandle))
            SelectGroup(childRowHandle, select);
          else
            SelectRow(childRowHandle, select, false);
        }
        Invalidate();
      }
    }

    public void SelectRow(int rowHandle, bool select)
    {
      SelectRow(rowHandle, select, true);
    }

    private void SelectRow(int rowHandle, bool select, bool invalidate)
    {
      if (IsRowSelected(rowHandle) != select)
      {
        if (select)
          View.SetRowCellValue(rowHandle, column, true);
        else
          View.SetRowCellValue(rowHandle, column, false);

        if (invalidate)
          Invalidate();
      }
    }

    public int GroupRowSelectionStatus(int rowHandle)
    {
      int count = 0;
      for (int i = 0; i <= View.GetChildRowCount(rowHandle) - 1; i++)
      {
        int row = View.GetChildRowHandle(rowHandle, i);
        if (View.IsGroupRow(row))
        {
          int g = GroupRowSelectionStatus(row);
          if (g < 0)
            return g;
          if (g > 0)
            count++;
        }
        else if (IsRowSelected(row))
          count++;
      }
      if (count == 0)
        return 0;
      if (count == View.GetChildRowCount(rowHandle))
        return 1;

      return -1;
    }

    public bool IsGroupRowSelected(int rowHandle)
    {
      for (int i = 0; i <= View.GetChildRowCount(rowHandle) - 1; i++)
      {
        int row = View.GetChildRowHandle(rowHandle, i);
        if (View.IsGroupRow(row))
        {
          if (!IsGroupRowSelected(row))
            return false;
        }
        else if (!IsRowSelected(row))
          return false;
      }
      return true;
    }

    public bool IsRowSelected(int rowHandle)
    {
      if (View.IsGroupRow(rowHandle))
        return IsGroupRowSelected(rowHandle);

      object row = View.GetRow(rowHandle);
      return (GetSelectedIndex(row) != -1);
    }

    private void view_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
    {
      if (e.Column == CheckMarkColumn)
      {
        if (e.IsGetData)
          e.Value = IsRowSelected(e.ListSourceRowIndex);
        else
        {
          bool select = Convert.ToBoolean(e.Value);
          if (IsRowSelected(e.ListSourceRowIndex) != select)
          {
            object row = View.GetRow(e.ListSourceRowIndex);
            if (select)
              selection.Add(row);
            else
              selection.Remove(row);

            Invalidate();
          }
        }
      }
    }

    private void Edit_EditValueChanged(object sender, EventArgs e)
    {
      View.PostEditor();
    }
  }
}