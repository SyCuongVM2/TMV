using System;
using System.Data;
using System.Drawing;

namespace TMV.UI.JPCB.Common
{
  public class CyberColor
  {
    public Color GetBackColorDefault() => Color.White;
    public Color GetForeColorDefault() => Color.Navy;
    public Color GetBackColorReportsDefault() => Color.White;
    public Color GetForeColorReportsDefault() => Color.Navy;

    public Color GetBackColorPrintGrid()
    {
      return Color.FromArgb(192, 255, 192);
    }
    public Color GetForeColorPrintGrid() => Color.Navy;
    public Color GetBackColor(string ColorName)
    {
      Color color = GetBackColorDefault();
      Color backColor;

      if (ColorName == "")
        backColor = GetBackColorDefault();
      else
      {
        if (ColorName.Contains(","))
        {
          try
          {
            string str1 = ColorName.Trim().Split(',')[0];
            string str2 = ColorName.Trim().Split(',')[1];
            string str3 = ColorName.Trim().Split(',')[2];
            color = Color.FromArgb(Convert.ToInt32(str1), Convert.ToInt32(str2), Convert.ToInt32(str3));
          }
          catch
          {
          }
        }
        else
        {
          try
          {
            color = Color.FromName(ColorName);
          }
          catch
          {
          }
        }
        backColor = color;
      }
      return backColor;
    }
    public Color GetForeColor(string ColorName)
    {
      Color color = GetForeColorDefault();
      Color foreColor;
      if (ColorName == "")
        foreColor = GetForeColorDefault();
      else
      {
        if (ColorName.Contains(","))
        {
          try
          {
            string str1 = ColorName.Trim().Split(',')[0];
            string str2 = ColorName.Trim().Split(',')[1];
            string str3 = ColorName.Trim().Split(',')[2];
            color = Color.FromArgb((int)Convert.ToByte(str1), (int)Convert.ToByte(str2), (int)Convert.ToByte(str3));
          }
          catch
          {
          }
        }
        else
        {
          try
          {
            color = Color.FromName(ColorName);
          }
          catch
          {
          }
        }
        foreColor = color;
      }
      return foreColor;
    }
    public Color GetBacColorkReports(string ColorName)
    {
      Color color = GetBackColorReportsDefault();
      Color bacColorkReports;

      if (ColorName == "")
        bacColorkReports = GetBackColorReportsDefault();
      else
      {
        if (ColorName.Contains(","))
        {
          try
          {
            string str1 = ColorName.Trim().Split(',')[0];
            string str2 = ColorName.Trim().Split(',')[1];
            string str3 = ColorName.Trim().Split(',')[2];
            color = Color.FromArgb((int)Convert.ToByte(str1), (int)Convert.ToByte(str2), (int)Convert.ToByte(str3));
          }
          catch
          {
          }
        }
        else
        {
          try
          {
            color = Color.FromName(ColorName);
          }
          catch
          {
          }
        }
        bacColorkReports = color;
      }
      return bacColorkReports;
    }
    public Color GetForeColorReports(string ColorName)
    {
      Color color = GetForeColorReportsDefault();
      Color foreColorReports;

      if (ColorName == "")
        foreColorReports = GetForeColorReportsDefault();
      else
      {
        if (ColorName.Contains(","))
        {
          try
          {
            string str1 = ColorName.Trim().Split(',')[0];
            string str2 = ColorName.Trim().Split(',')[1];
            string str3 = ColorName.Trim().Split(',')[2];
            color = Color.FromArgb((int)Convert.ToByte(str1), (int)Convert.ToByte(str2), (int)Convert.ToByte(str3));
          }
          catch
          {
          }
        }
        else
        {
          try
          {
            color = Color.FromName(ColorName);
          }
          catch
          {
          }
        }
        foreColorReports = color;
      }
      return foreColorReports;
    }
    public void V_GetColorBold(DataTable _Dt, ref bool _Bold, ref bool _BackColor, ref bool _BackColor2, ref bool _ForeColor, ref string _FieldBold, ref string _FieldBackColor, ref string _FieldBackColor2, ref string _FieldForeColor)
    {
      if (_Dt == null)
        return;
      if (_Dt.Columns.Contains("Bold"))
      {
        _Bold = true;
        _FieldBold = _Dt.Columns["Bold"].ColumnName;
      }
      if (_Dt.Columns.Contains("Backcolor"))
      {
        _BackColor = true;
        _FieldBackColor = _Dt.Columns["Backcolor"].ColumnName;
      }
      if (_Dt.Columns.Contains("Backcolor2"))
      {
        _BackColor2 = true;
        _FieldBackColor2 = _Dt.Columns["Backcolor2"].ColumnName;
      }
      if (!_Dt.Columns.Contains("Forecolor"))
        return;
      _ForeColor = true;
      _FieldForeColor = _Dt.Columns["Forecolor"].ColumnName;
    }
    public void V_GetColorBold2(DataTable _Dt, ref bool _Bold, ref bool _BackColor, ref bool _BackColor2, ref bool _ForeColor, ref bool _Underline, ref string _FieldBold, ref string _FieldBackColor, ref string _FieldBackColor2, ref string _FieldForeColor, ref string _FieldUnderLine)
    {
      if (_Dt == null)
        return;

      if (_Dt.Columns.Contains("Bold"))
      {
        _Bold = true;
        _FieldBold = _Dt.Columns["Bold"].ColumnName;
      }

      if (_Dt.Columns.Contains("Backcolor"))
      {
        _BackColor = true;
        _FieldBackColor = _Dt.Columns["Backcolor"].ColumnName;
      }

      if (_Dt.Columns.Contains("Backcolor2"))
      {
        _BackColor2 = true;
        _FieldBackColor2 = _Dt.Columns["Backcolor2"].ColumnName;
      }

      if (_Dt.Columns.Contains("Forecolor"))
      {
        _ForeColor = true;
        _FieldForeColor = _Dt.Columns["Forecolor"].ColumnName;
      }

      if (!_Dt.Columns.Contains("UnderLine"))
        return;

      _Underline = true;
      _FieldUnderLine = _Dt.Columns["UnderLine"].ColumnName;
    }
  }
}