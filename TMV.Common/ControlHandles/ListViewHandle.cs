using System;
using System.Collections;
using System.Windows.Forms;
using System.Text;
using System.Data;

namespace TMV.Common.ControlHandles
{
  public class ListViewColumnSorter : IComparer
  {
    #region "ListViewColumnSorter"

    private int ColumnToSort = 0;
    private SortOrder OrderOfSort = SortOrder.None;

    public ListViewColumnSorter()
    {
      ColumnToSort = 0;
      OrderOfSort = SortOrder.None;
    }

    public SortOrder Order
    {
      get
      {
        return OrderOfSort;
      }
      set
      {
        OrderOfSort = value;
      }
    }

    public int SortColumn
    {
      get
      {
        return ColumnToSort;
      }
      set
      {
        ColumnToSort = value;
      }
    }

    public int Compare(object x, object y)
    {
      int compareResult = 0;
      ListViewItem listviewX = (ListViewItem)x;
      ListViewItem listviewY = (ListViewItem)y;
      string sDataType = ((ListViewHeader)listviewX.ListView.Columns[ColumnToSort].Tag).DataType;
      if ((listviewX.SubItems.Count > ColumnToSort) && (listviewY.SubItems.Count > ColumnToSort))
      {
        object sValueX = listviewX.SubItems[ColumnToSort].Tag;
        object sValueY = listviewY.SubItems[ColumnToSort].Tag;
        if (sDataType == "DATE")
          compareResult = DateTime.Compare(DateTime.Parse(Convert.ToString(sValueX)), DateTime.Parse(Convert.ToString(sValueY)));
        else if (sDataType == "NUMBER")
          compareResult = decimal.Compare(decimal.Parse(Convert.ToString(sValueX)), decimal.Parse(Convert.ToString(sValueY)));
        else
          compareResult = string.Compare(Convert.ToString(sValueX), Convert.ToString(sValueY), true);
      }
      else
        return 0;

      if (OrderOfSort == SortOrder.Ascending)
        return compareResult;

      if (OrderOfSort == SortOrder.Descending)
        return (0 - compareResult);

      return 0;
    }
    #endregion
  }

  public class ListViewHeader
  {
    #region "ListViewHeader"

    public string DataFormat;
    public string DataType;
    public string DisplayField;
    public string StatusArray;
    public string StatusColor;
    public string ValueField;

    public ListViewHeader(string _DisplayField)
    {
      DisplayField = _DisplayField;
      ValueField = _DisplayField;
    }

    public ListViewHeader(string _DisplayField, string _DataFormat)
    {
      DisplayField = _DisplayField;
      ValueField = _DisplayField;
      DataFormat = _DataFormat;
    }

    public ListViewHeader(string _DisplayField, string _ValueField, string _StatusArray, string _StatusColor)
    {
      DisplayField = _DisplayField;
      ValueField = _ValueField;
      StatusArray = _StatusArray;
      StatusColor = _StatusColor;
    }

    public ListViewHeader(string _DisplayField, string _ValueField, string _DataFormat, string _StatusArray, string _StatusColor)
    {
      DisplayField = _DisplayField;
      ValueField = _ValueField;
      StatusArray = _StatusArray;
      StatusColor = _StatusColor;
    }

    #endregion
  }

  public class ListViewHandle
  {
    #region "ListViewHandle"

    private bool _AllowCopy;
    private bool _AllowSort;
    private ListView objListView;
    private ListViewColumnSorter lvwColumnSorter;

    public bool AllowCopy
    {
      get
      {
        return _AllowCopy;
      }
      set
      {
        _AllowCopy = value;
      }
    }

    public bool AllowSort
    {
      get
      {
        return _AllowSort;
      }
      set
      {
        _AllowSort = value;
      }
    }

    public ListViewHandle(ListView lv, bool bAllowSort, bool bAllowCopy)
    {
      objListView.ColumnClick += new ColumnClickEventHandler(objListView_ColumnClick);
      _AllowSort = bAllowSort;
      _AllowCopy = bAllowCopy;
      objListView = lv;
      if (_AllowSort)
      {
        lvwColumnSorter = new ListViewColumnSorter();
        objListView.ListViewItemSorter = lvwColumnSorter;
      }
    }

    private void objListView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      try
      {
        if (_AllowSort)
        {
          if (e.Column == lvwColumnSorter.SortColumn)
          {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
              lvwColumnSorter.Order = SortOrder.Descending;
            else
              lvwColumnSorter.Order = SortOrder.Ascending;
          }
          else
          {
            lvwColumnSorter.SortColumn = e.Column;
            lvwColumnSorter.Order = SortOrder.Ascending;
          }
          objListView.Sort();
        }
      }
      catch
      {
      }
    }

    public void ResetSort()
    {
      if (lvwColumnSorter != null)
      {
        lvwColumnSorter.SortColumn = 0;
        lvwColumnSorter.Order = SortOrder.None;
      }
    }

    #endregion
  }

  public class ListViewCommon
  {
    #region "ListViewCommon"

    private static ListViewCommon _instance;
    private static System.Object _syncLock = new System.Object();

    protected ListViewCommon()
    {
    }

    protected void Dispose()
    {
      _instance = null;
    }

    public static ListViewCommon Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new ListViewCommon();
        }
      }
      return _instance;
    }

    public ListViewItem.ListViewSubItem GetSubItem(ListViewItem lvItem, string sColumnName)
    {
      if (lvItem.SubItems.ContainsKey(sColumnName))
        return lvItem.SubItems[sColumnName];

      for (int i = 0; i <= lvItem.ListView.Columns.Count - 1; i++)
      {
        ColumnHeader clm = lvItem.ListView.Columns[i];
        if (string.IsNullOrEmpty(clm.Name))
          clm.Name = Convert.ToString(clm.Tag);

        if (sColumnName.ToUpper() == clm.Tag.ToString().ToUpper())
        {
          if (i > (lvItem.SubItems.Count - 1))
          {
            for (int j = lvItem.SubItems.Count; j <= i; j++)
            {
              lvItem.SubItems.Add("");
            }
          }
          return lvItem.SubItems[i];
        }
      }
      return null;
    }

    public string GetSubItemText(ListViewItem lvItem, string sColumnName)
    {
      if (lvItem.SubItems.ContainsKey(sColumnName))
        return lvItem.SubItems[sColumnName].Text;

      for (int i = 0; i <= lvItem.ListView.Columns.Count - 1; i++)
      {
        ColumnHeader clm = lvItem.ListView.Columns[i];
        if (string.IsNullOrEmpty(clm.Name))
          clm.Name = Convert.ToString(clm.Tag);

        if (sColumnName.ToUpper() == clm.Tag.ToString().ToUpper())
          return lvItem.SubItems[i].Text;
      }
      return "";
    }

    public string ListView_CopyData(ListView objListView, bool bIncludeGroup)
    {
      string sGroupName = null;
      string sTemp = null;
      bool bUseGroup = objListView.ShowGroups && bIncludeGroup;
      StringBuilder sBuilder = new StringBuilder();

      foreach (ColumnHeader lvColumn in objListView.Columns)
      {
        if (string.IsNullOrEmpty(sTemp))
          sTemp = lvColumn.Text;
        else
          sTemp = sTemp + "\t" + lvColumn.Text;
      }

      sBuilder.Append(sTemp);

      foreach (ListViewItem lvItem in objListView.Items)
      {
        if ((bUseGroup && (objListView.Groups.Count > 0)) && ((lvItem.Group != null) && (sGroupName != lvItem.Group.Name)))
        {
          sGroupName = lvItem.Group.Name;
          sBuilder.Append("\r\n" + lvItem.Group.Header);
        }
        sTemp = "";
        for (int i = 0; i <= lvItem.SubItems.Count - 1; i++)
        {
          if (string.IsNullOrEmpty(sTemp))
            sTemp = lvItem.SubItems[i].Text;
          else
            sTemp = sTemp + "\t" + lvItem.SubItems[i].Text;
        }
        sBuilder.Append("\r\n" + sTemp);
      }
      return sBuilder.ToString();
    }

    public long ListView_MoveAll(ListView lstSource, ListView lstDest)
    {
      long iReturn = lstSource.Items.Count;
      if (iReturn > 0L)
      {
        lstSource.BeginUpdate();
        lstDest.BeginUpdate();

        foreach (ListViewItem itm in lstSource.Items)
        {
          lstSource.Items.Remove(itm);
          itm.Selected = false;
          lstDest.Items.Add(itm);
        }
        lstSource.EndUpdate();
        lstDest.EndUpdate();
      }
      return iReturn;
    }

    public long ListView_MoveSelect(ListView lstSource, ListView lstDest)
    {
      long iReturn = lstSource.SelectedItems.Count;
      if (iReturn > 0L)
      {
        lstSource.BeginUpdate();
        lstDest.BeginUpdate();

        foreach (ListViewItem itm in lstSource.SelectedItems)
        {
          lstSource.Items.Remove(itm);
          itm.Selected = false;
          lstDest.Items.Add(itm);
        }
        lstSource.EndUpdate();
        lstDest.EndUpdate();
      }
      return iReturn;
    }

    public ListViewItem ListView_AddItem(ListView objListView, object objData, string sPK_Field)
    {
      ListViewItem lvItem = null;
      string sColumnName = null;
      string sValue = null;

      foreach (ColumnHeader clm in objListView.Columns)
      {
        sColumnName = Convert.ToString(clm.Tag);
        if (objData is IDataReader)
          sValue = Globals.DB_GetString(((IDataReader)objData)[sColumnName], "");
        else
          sValue = Globals.Object_GetDisplayValue(Globals.Object_GetPropertyValue(objData, sColumnName), "");

        if (lvItem == null)
          lvItem = objListView.Items.Add(sValue);
        else
          lvItem.SubItems.Add(sValue);
      }

      if (!string.IsNullOrEmpty(sPK_Field))
      {
        if (objData is IDataReader)
          lvItem.Name = ((IDataReader)objData)[sPK_Field].ToString();
        else
          lvItem.Name = Globals.Object_GetDisplayValue(Globals.Object_GetPropertyValue(objData, sPK_Field), "");
      }
      if (!(objData is IDataReader))
        lvItem.Tag = objData;

      return lvItem;
    }

    public void ListView_UpdateItem(ListViewItem lvItem, object objData, string sPK_Field)
    {
      string sColumnName = null;
      string sValue = null;
      int i = 0;

      foreach (ColumnHeader clm in lvItem.ListView.Columns)
      {
        sColumnName = Convert.ToString(clm.Tag);
        sValue = Globals.Object_GetDisplayValue(Globals.Object_GetPropertyValue(objData, sColumnName), "");
        lvItem.SubItems[i].Text = sValue;
        i++;
      }
      if (!string.IsNullOrEmpty(sPK_Field))
        lvItem.Name = Globals.Object_GetDisplayValue(Globals.Object_GetPropertyValue(objData, sPK_Field), "");

      lvItem.Tag = objData;
    }

    public void ListView_DataBind(ListView objListView, ListViewGroup objGroup, DataTable objDataTable, string sPK_Field)
    {
      ListView_DataBind(objListView, objGroup, objDataTable.DefaultView, sPK_Field);
    }

    public void ListView_DataBind(ListView objListView, ListViewGroup objGroup, ArrayList arrObject, string sPK_Field)
    {
      objListView.BeginUpdate();
      try
      {
        objListView.Items.Clear();
        foreach (object objData in arrObject)
        {
          ListViewItem lvItem = null;
          foreach (ColumnHeader clm in objListView.Columns)
          {
            string sValue;
            string sColumnName = Convert.ToString(clm.Tag);
            if (sColumnName == "@STT")
              sValue = Convert.ToString((int)(objListView.Items.Count + 1));
            else
              sValue = Globals.Object_GetDisplayValue(Globals.Object_GetPropertyValue(objData, sColumnName), "");
            if (lvItem == null)
            {
              lvItem = objListView.Items.Add(sValue);
              lvItem.Tag = objData;
              if (!string.IsNullOrEmpty(sPK_Field))
                lvItem.Name = Globals.Object_GetDisplayValue(Globals.Object_GetPropertyValue(objData, sPK_Field), "");

              lvItem.Group = objGroup;
            }
            else
              lvItem.SubItems.Add(sValue);
          }
        }
      }
      finally
      {
        objListView.EndUpdate();
      }
    }

    public void ListView_DataBind(ListView objListView, ListViewGroup objGroup, DataView objDataView, string sPK_Field)
    {
      try
      {
        objListView.BeginUpdate();
        objListView.Items.Clear();
        for (int i = 0; i <= objDataView.Count - 1; i++)
        {
          ListViewItem lvItem = null;
          foreach (ColumnHeader clm in objListView.Columns)
          {
            string sValue;
            ListViewHeader clmHeader = (ListViewHeader)clm.Tag;
            string sColumnName = clmHeader.DisplayField;
            if (sColumnName == "@STT")
              sValue = Convert.ToString((int)(objListView.Items.Count + 1));
            else
              sValue = Globals.Object_GetDisplayValue(objDataView[i][sColumnName], "");

            if (lvItem == null)
            {
              lvItem = objListView.Items.Add(sValue);
              if (!string.IsNullOrEmpty(sPK_Field))
              {
                lvItem.Tag = objDataView[i][sPK_Field];
                lvItem.Name = Convert.ToString(objDataView[i][sPK_Field]);
              }
              lvItem.Group = objGroup;
            }
            else
              lvItem.SubItems.Add(sValue);
          }
        }
      }
      finally
      {
        objListView.EndUpdate();
      }
    }

    public void ListView_DataBind(ListView objListView, ListViewGroup objGroup, IDataReader objReader, string sPK_Field)
    {
      try
      {
        objListView.BeginUpdate();
        objListView.Items.Clear();
        while (objReader.Read())
        {
          ListViewItem lvItem = null;
          foreach (ColumnHeader clm in objListView.Columns)
          {
            string sValue;
            ListViewHeader clmHeader = (ListViewHeader)clm.Tag;
            string sColumnName = clmHeader.DisplayField;
            if (sColumnName == "@STT")
              sValue = Convert.ToString((int)(objListView.Items.Count + 1));
            else
              sValue = Globals.Object_GetDisplayValue(objReader[sColumnName], "");

            if (lvItem == null)
            {
              lvItem = objListView.Items.Add(sValue);
              if (!string.IsNullOrEmpty(sPK_Field))
              {
                lvItem.Tag = objReader[sPK_Field];
                lvItem.Name = Convert.ToString(objReader[sPK_Field]);
                if (objGroup != null)
                  lvItem.Group = objGroup;
              }
            }
            else
              lvItem.SubItems.Add(sValue).Tag = Globals.DB_GetValue(objReader[clmHeader.ValueField], null);
          }
        }
      }
      finally
      {
        Globals.Reader_Close(objReader);
        objListView.EndUpdate();
      }
    }
    #endregion
  }
}