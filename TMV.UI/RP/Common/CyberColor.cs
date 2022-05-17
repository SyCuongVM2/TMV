using System;
using System.Drawing;

namespace TMV.UI.RP.Common
{
  public class CyberColor
  {
    public Color GetBackColorDefault() => Color.White;
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
            color = System.Drawing.Color.FromName(ColorName);
          }
          catch
          {
          }
        }
        backColor = color;
      }
      return backColor;
    }
  }
}