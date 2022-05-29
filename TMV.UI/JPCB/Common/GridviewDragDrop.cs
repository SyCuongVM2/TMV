using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TMV.UI.JPCB.Common
{
  public class GridviewDragDrop
  {
    private GridHitInfo downHitInfo;
    private GridControl _GridDrag;
    private Control _CtrDrop;
    private GridView _GrvDrag;
    public bool _ActiDraDrop;

    public GridviewDragDrop()
    {
      downHitInfo = null;
      _GridDrag = new GridControl();
      _CtrDrop = new Control();
      _GrvDrag = new GridView();
      _ActiDraDrop = false;
    }

    public GridviewDragDrop(GridControl Grid_keo, Control Cotrol_Tha)
    {
      downHitInfo = null;
      _GridDrag = new GridControl();
      _CtrDrop = new Control();
      _GrvDrag = new GridView();
      _ActiDraDrop = false;
      _GridDrag = Grid_keo;
      _CtrDrop = Cotrol_Tha;
      _CtrDrop = (Cotrol_Tha == null) ? Grid_keo : Cotrol_Tha;
      _GridDrag.AllowDrop = true;
      _GrvDrag = _GridDrag.MainView as GridView;
      V_Addhandler();
    }

    private void V_Addhandler()
    {
      _GrvDrag.MouseMove += new MouseEventHandler(view_MouseMove);
      _GrvDrag.MouseDown += new MouseEventHandler(view_MouseDown);
      _CtrDrop.DragOver += new DragEventHandler(grid_DragOver);
    }

    private void view_MouseDown(object sender, MouseEventArgs e)
    {
      _ActiDraDrop = false;
      GridView gridView = sender as GridView;
      downHitInfo = null;
      GridHitInfo gridHitInfo = gridView.CalcHitInfo(new Point(e.X, e.Y));
      if (Control.ModifierKeys != Keys.None || e.Button != MouseButtons.Left || gridHitInfo.RowHandle < 0)
        return;

      downHitInfo = gridHitInfo;
      _ActiDraDrop = true;
    }

    private void view_MouseMove(object sender, MouseEventArgs e)
    {
      GridView gridView = sender as GridView;
      if (e.Button != MouseButtons.Left || downHitInfo == null)
        return;

      Size dragSize = SystemInformation.DragSize;
      Rectangle rectangle = new Rectangle();
      ref Rectangle local1 = ref rectangle;
      Point point = new Point(checked((int)Math.Round(unchecked((double)downHitInfo.HitPoint.X - (double)dragSize.Width / 2.0))), checked((int)Math.Round(unchecked((double)downHitInfo.HitPoint.Y - (double)dragSize.Height / 2.0))));
      Point location = point;
      Size size = dragSize;
      local1 = new Rectangle(location, size);
      ref Rectangle local2 = ref rectangle;
      point = new Point(e.X, e.Y);
      Point pt = point;
      if (local2.Contains(pt))
        return;

      DataRow dataRow = gridView.GetDataRow(downHitInfo.RowHandle);
      int num = (int)gridView.GridControl.DoDragDrop((object)dataRow, DragDropEffects.Move);
      downHitInfo = null;
      DXMouseEventArgs.GetMouseArgs(e).Handled = true;
    }

    private void grid_DragOver(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Move;
  }
}