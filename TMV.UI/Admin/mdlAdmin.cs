using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace TMV.UI.Admin
{
  internal sealed class mdlAdmin
  {
    internal static void SetUserRole(XtraForm oForm)
    {
    }
    private static void Form_KeyDown(object sender, KeyEventArgs e)
    {
      if ((e.KeyCode == Keys.F2) && (sender is XtraForm))
      {
      }
    }
    private static void SetUserButton(Control oControl, string ButtonList)
    {
      if (oControl is SimpleButton)
      {
        if (ButtonList.IndexOf("|" + oControl.Name + "|") >= 0)
          oControl.Enabled = true;
        else
          oControl.Enabled = false;
      }
      else if ((((oControl is PanelControl) || (oControl is GroupControl)) || (oControl is XtraTabControl)) || (oControl is XtraTabPage))
      {
        foreach (Control ctrl in oControl.Controls)
        {
          SetUserButton(ctrl, ButtonList);
        }
      }
    }
    private static void SetStatusButton(Control oControl, bool bEnabledStatus)
    {
      if (oControl is SimpleButton)
        oControl.Enabled = bEnabledStatus;
      else if ((((oControl is PanelControl) || (oControl is GroupControl)) || (oControl is XtraTabControl)) || (oControl is XtraTabPage))
      {
        foreach (Control ctrl in oControl.Controls)
        {
          SetStatusButton(ctrl, bEnabledStatus);
        }
      }
    }
    internal static string DataTable2String(DataTable dt, string splitChar, int col)
    {
      string sRet = "";
      if (dt != null)
      {
        foreach (DataRow dr in dt.Rows)
        {
          if (sRet == "")
            sRet = splitChar + dr[col].ToString() + splitChar;
          else
            sRet = sRet + dr[col].ToString() + splitChar;
        }
      }
      return sRet;
    }
    internal static string DataTable2String(DataView dv, string splitChar, int col)
    {
      string sRet = "";
      if (dv != null)
      {
        for (int i = 0; i <= dv.Count - 1; i++)
        {
          if (sRet == "")
            sRet = splitChar + dv[i][col].ToString() + splitChar;
          else
            sRet = sRet + dv[i][col].ToString() + splitChar;
        }
      }
      return sRet;
    }
    public static void WriteSetting(string key, string value)
    {
      XmlDocument doc = loadConfigDocument();
      XmlNode node = doc.SelectSingleNode("//appSettings");
      if (node == null)
        throw new InvalidOperationException("appSettings section not found in config file.");

      try
      {
        XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
        if (elem != null)
          elem.SetAttribute("value", value);
        else
        {
          elem = doc.CreateElement("add");
          elem.SetAttribute("key", key);
          elem.SetAttribute("value", value);
          node.AppendChild(elem);
        }
        doc.Save(getConfigFilePath());
      }
      catch
      {
        throw;
      }
    }
    private static XmlDocument loadConfigDocument()
    {
      XmlDocument doc = null;
      XmlDocument loadConfigDocument;
      try
      {
        doc = new XmlDocument();
        doc.Load(getConfigFilePath());
        loadConfigDocument = doc;
      }
      catch (System.IO.FileNotFoundException ex)
      {
        throw new Exception("No configuration file found.", ex);
      }
      return loadConfigDocument;
    }
    private static string getConfigFilePath()
    {
      return (System.Reflection.Assembly.GetExecutingAssembly().Location + ".config");
    }
  }
}