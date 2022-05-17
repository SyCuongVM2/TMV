using System;
using System.Collections.Generic;
using GemBox.Spreadsheet;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace TMV.Common
{
  public class CEcxelLib
  {
    public static void SetLicenseSpreadsheet()
    {
      SpreadsheetInfo.SetLicense(Commons.Instance().getKeyValueByKeyName("LicenseSpreadsheet"));
    }

    public static string FormatDoubleToStringTime(double pNumber)
    {
      return DateTime.FromOADate(pNumber).ToString().Substring(11, 5);
    }

    public static DataTable ReadExcelFile(string pFile, string pSheet, int headerIndex, int startColumn, int startRow, string[] arr)
    {
      DataTable table = new DataTable();
      try
      {
        SetLicenseSpreadsheet();
        ExcelFile ef = new ExcelFile();
        if (pFile.ToUpper().EndsWith(".XLSX"))
          ef = ExcelFile.Load(pFile, LoadOptions.XlsxDefault);
        else
          ef = ExcelFile.Load(pFile, LoadOptions.XlsDefault);
        ExcelWorksheet v_worksheet = ef.Worksheets[pSheet];
        int i = startColumn;

        while (v_worksheet.Cells[headerIndex, i].Value != null)
        {
          foreach (string col in arr)
          {
            if (v_worksheet.Cells[headerIndex, i].Value.ToString().ToUpper() == col.ToUpper())
              table.Columns.Add(v_worksheet.Cells[headerIndex, i].Value.ToString());
          }
          i++;
        }

        DataRow newRow;
        int j = startRow;
        while (v_worksheet.Cells[j, startColumn].Value != null)
        {
          newRow = table.NewRow();
          for (int k = 0; k <= table.Columns.Count - 1; k++)
          {
            newRow[v_worksheet.Cells[headerIndex, k + startColumn].Value.ToString()] = v_worksheet.Cells[j, startColumn + k].Value.ToString();
          }
          table.Rows.Add(newRow);
          j += 1;
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
      return table;
    }

    public static List<ObjImportExcel> saveListCSV(string fileName, List<ObjImportExcel> listData)
    {
      try
      {
        SetLicenseSpreadsheet();
        List<ObjImportExcel> LObjImportExcel = listData;
        foreach (ObjImportExcel clearObjImportExcel in LObjImportExcel)
        {
          clearObjImportExcel.SheetPath = String.Empty;
        }

        ExcelFile excel = new ExcelFile();
        string file = string.Empty;
        string excelFileName = fileName.Substring(fileName.LastIndexOf(Convert.ToChar(@"\"))).Trim().Replace(" ", string.Empty);
        string currentLocation = Application.ExecutablePath;
        currentLocation = currentLocation.Replace(currentLocation.Substring(currentLocation.LastIndexOf(@"\")), string.Empty);
        if (!Directory.Exists(currentLocation + "\\" + "Temp"))
          Directory.CreateDirectory(currentLocation + "\\" + "Temp");
        string pathSave = currentLocation + "\\" + "Temp";

        if (fileName.ToUpper().EndsWith(".XLSX"))
          excel = ExcelFile.Load(fileName, LoadOptions.XlsxDefault);
        else
          excel = ExcelFile.Load(fileName, LoadOptions.XlsDefault);

        excelFileName = excelFileName.Substring(0, excelFileName.Length - 4);
        foreach (ExcelWorksheet ws in excel.Worksheets)
        {
          if (ws.Rows.Count > 0)
          {
            foreach (ObjImportExcel imp in LObjImportExcel)
            {
              if (ws.Name == LObjImportExcel[0].SheetName.ToString())
              {
                excel.Worksheets.ActiveWorksheet = ws;
                file = String.Format("{0}{1}_{2}.csv", pathSave.Trim(), excelFileName, ws.Name.Trim().Replace(" ", String.Empty));
                imp.SheetPath = file;
                if (File.Exists(file) == true)
                  File.Delete(file);

                excel.Save(file, SaveOptions.CsvDefault);
              }
            }
          }
        }
        return LObjImportExcel;
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
        return null;
      }
    }
  }
}