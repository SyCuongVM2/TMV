using DevExpress.XtraGrid.Views.Grid;
using System.Data;

namespace TMV.Common.ControlHandles
{
  public class DataGridControlHandle
  {
    public object GetKeyValue(GridView grv, object keyvalue)
    {
      DataRow row = grv.GetDataRow(grv.FocusedRowHandle);
      if (row == null)
      {
        return null;
      }
      keyvalue = row["ImporterID"];
      return keyvalue;
    }
  }
}