using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace TMV.Common
{
  public class Commons
  {
    #region "Constructor"

    private static Commons _instance;
    private static System.Object _syncLock = new System.Object();

    protected Commons()
    {
    }

    protected void Dispose()
    {
      _instance = null;
    }

    public static Commons Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new Commons();
        }
      }
      return _instance;
    }

    #endregion

    #region "Commons"

    public string getKeyValueByKeyName(string keyNameSetting)
    {
      return ConfigurationManager.AppSettings[keyNameSetting];
    }

    public bool StringIsNumber(string s)
    {
      for (int i = 0; i <= s.Length; i++)
      {
        if ((Char.IsDigit(s, i)) && (s[i] != ' '))
          return false;
      }
      return true;
    }

    public static DataTable CreateDataTable(int rows, int columns)
    {
      DataTable skeleton = new DataTable();
      for (int i = 0; i <= rows - 1; i++)
      {
        skeleton.Rows.Add();
      }
      for (int k = 0; k <= columns - 1; k++)
      {
        skeleton.Columns.Add();
      }
      return skeleton;
    }

    #endregion
  }

  public class Import_Excel
  {
    public string ColumnName { get; set; }
    public int DataType { get; set; }
    public int IndexColumn { get; set; }
    public bool isRequired { get; set; }
  }

  public class DB_Import_Excel
  {
    public string FileExcelPath { get; set; }
    public List<Import_Excel> ImpExcels { get; set; }
    public int StartRow { get; set; }
  }

  public class ObjImportExcel
  {
    public DB_Import_Excel DataTableImportExcel { get; set; }
    public string SheetName { get; set; }
    public string SheetPath { get; set; }
  }
}