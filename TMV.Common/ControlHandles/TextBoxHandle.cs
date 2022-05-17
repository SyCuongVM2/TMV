using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace TMV.Common.ControlHandles
{
  public class TextBoxHandle
  {
    private const string CS_DATE_TYPE = "DATE,DATETIME,DATESHORT,TIME,";
    private const string CS_FLOAT_TYPE = "NUMBER,DOUBLE,FLOAT,DECIMAL,MONEY";
    private const string CS_INT_TYPE = "LONG,BIGINT,INT,INTEGER,SHORT,SMALLINT,";
    private const string CS_STRING_TYPE = "NVARCHAR2,VARCHAR2,VARCHAR,NVARCHAR,CHAR,NCLOB,TEXT,NTEXT";
    private bool m_bClearError;
    private bool m_bMouseOver;
    private object m_objMaxValue;
    private object m_objMinValue;
    private string m_sAll_Data_Type = CS_FLOAT_TYPE + CS_INT_TYPE + CS_DATE_TYPE + CS_STRING_TYPE;
    private string m_sDataType;
    private string m_sNumber_Data_Type = CS_FLOAT_TYPE + CS_INT_TYPE;
    private TextBox objTextBox;

    protected TextBoxHandle()
    {
      objTextBox.Validating += new CancelEventHandler(TextBox_Validating);
      objTextBox.TextChanged += new EventHandler(objTextBox_TextChanged);
      objTextBox.MouseLeave += new EventHandler(objTextBox_MouseLeave);
      objTextBox.MouseEnter += new EventHandler(objTextBox_MouseEnter);
      objTextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
      objTextBox.Enter += new EventHandler(objTextBox_Enter);
    }

    public TextBoxHandle(TextBox tb, string DataType, object MinValue, object MaxValue)
    {
      objTextBox = tb;
      m_sDataType = DataType.ToUpper();
      m_objMaxValue = MaxValue;
      m_objMinValue = MinValue;

      if ((((m_sDataType == "NUMBER") || (m_sDataType == "FLOAT")) || ((m_sDataType == "DOUBLE") || (m_sDataType == "DECIMAL"))) || (m_sDataType == "MONEY"))
      {
        tb.MaxLength = double.MaxValue.ToString().Length;
        tb.TextAlign = HorizontalAlignment.Right;
        if (m_objMaxValue == null)
          m_objMaxValue = double.MaxValue;
        if (m_objMinValue == null)
          m_objMinValue = double.MinValue;
      }
      else if ((m_sDataType == "INT") || (m_sDataType == "INTEGER"))
      {
        tb.MaxLength = int.MaxValue.ToString().Length;
        tb.TextAlign = HorizontalAlignment.Right;
        if (m_objMaxValue == null)
          m_objMaxValue = int.MaxValue;
        if (m_objMinValue == null)
          m_objMinValue = int.MinValue;
      }
      else if (((m_sDataType == "INT64") || (m_sDataType == "LONG")) || (m_sDataType == "BIGINT"))
      {
        tb.TextAlign = HorizontalAlignment.Right;
        if (m_objMaxValue == null)
          m_objMaxValue = long.MaxValue;
        if (m_objMinValue == null)
          m_objMinValue = long.MinValue;
      }
      else if (((m_sDataType == "INT16") || (m_sDataType == "SHORT")) || (m_sDataType == "SMALLINT"))
      {
        tb.MaxLength = short.MaxValue.ToString().Length;
        tb.TextAlign = HorizontalAlignment.Right;
        if (m_objMaxValue == null)
          m_objMaxValue = short.MaxValue;
        if (m_objMinValue == null)
          m_objMinValue = short.MinValue;
      }
      else if ((m_sDataType == "DATE") || (m_sDataType == "DATETIME"))
      {
        tb.MaxLength = 10;
        tb.CharacterCasing = CharacterCasing.Upper;
      }
      else if (m_sDataType == "DATESHORT")
      {
        tb.MaxLength = 10;
        tb.CharacterCasing = CharacterCasing.Upper;
      }
      else if (m_sDataType == "TIME")
        tb.MaxLength = 5;
      else if ((m_sDataType == "TEXT") || (m_sDataType == "NTEXT"))
        tb.MaxLength = 2000;
      else if (m_sAll_Data_Type.IndexOf(DataType + ",") == -1)
        throw new Exception("Invalid data type: " + DataType);
    }

    private void objTextBox_Enter(object sender, EventArgs e)
    {
      try
      {
        if (!objTextBox.ReadOnly)
        {
          switch (m_sDataType.ToUpper())
          {
            case "DATE":
            case "DATETIME":
              if (Globals.IsDate(objTextBox.Text))
                objTextBox.Text = Convert.ToDateTime(objTextBox.Text).ToString(Globals.CS_EDIT_DATE_FORMAT);

              break;
          }
          objTextBox.SelectAll();
          if (!m_bMouseOver)
            SetToolTip(true);
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      try
      {
        if (!e.Handled)
        {
          bool bHandled = false;
          switch (Globals.Asc(e.KeyChar))
          {
            case 8:
              break;

            case 13:
              if (objTextBox.Multiline)
                break;

              e.Handled = true;
              SendKeys.SendWait("{TAB}");
              return;

            default:
              {
                string sValidChar = "0123456789";
                if (CS_FLOAT_TYPE.Contains(m_sDataType.ToUpper()))
                  sValidChar = sValidChar + Globals.CS_DIGIT_GROUP_SYMBOL + Globals.CS_DECIMAL_SYMBOL;
                else if (CS_INT_TYPE.Contains(m_sDataType.ToUpper()))
                  sValidChar = sValidChar + Globals.CS_DIGIT_GROUP_SYMBOL;
                else if (m_sDataType.ToUpper().Contains("DATE"))
                  sValidChar = "";
                else if (m_sDataType.ToUpper() == "TIME")
                  sValidChar = sValidChar + ":";
                else
                  sValidChar = "";

                if (sValidChar != "")
                  bHandled = sValidChar.IndexOf(e.KeyChar) < 0;

                if (bHandled)
                  ShowTip("Invalid character input: " + Convert.ToString(e.KeyChar));

                break;
              }
          }
          e.Handled = bHandled;
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void ShowTip(string sTip)
    {
      ToolTip objToolTip = FormGlobals.Form_GetToolTip(objTextBox.FindForm());
      objToolTip.ToolTipTitle = "";
      objToolTip.Show(sTip, objTextBox, 1000);
    }

    private void objTextBox_MouseEnter(object sender, EventArgs e)
    {
      m_bMouseOver = true;
      SetToolTip(false);
    }

    private void SetToolTip(bool bShow)
    {
      if (!objTextBox.ReadOnly && objTextBox.Enabled)
      {
        ToolTip objToolTip = FormGlobals.Form_GetToolTip(objTextBox.FindForm());
        objToolTip.Active = false;
        objToolTip.Hide(objTextBox);
        string sText = string.Format("Input Length: {0}/{1}\r", objTextBox.Text.Length, objTextBox.MaxLength);
        if (FormGlobals.Control_GetRequire(objTextBox))
        {
          sText = sText + "Require: Yes";
          objToolTip.ToolTipIcon = ToolTipIcon.Warning;
        }
        else
        {
          sText = sText + "Require: No";
          objToolTip.ToolTipIcon = ToolTipIcon.Info;
        }
        if (CS_FLOAT_TYPE.Contains(m_sDataType))
          objToolTip.ToolTipTitle = "Data type: Number";
        else if (CS_INT_TYPE.Contains(m_sDataType))
          objToolTip.ToolTipTitle = "Data type: Integer";
        else if (CS_DATE_TYPE.Contains(m_sDataType))
          objToolTip.ToolTipTitle = "Data type: Date";
        else
          objToolTip.ToolTipTitle = "Data type: String";

        objToolTip.SetToolTip(objTextBox, sText);
        objToolTip.Active = true;
        if (bShow)
          objToolTip.Show(sText, objTextBox, objToolTip.AutoPopDelay);
      }
    }

    private void objTextBox_MouseLeave(object sender, EventArgs e)
    {
      m_bMouseOver = false;
    }

    private void objTextBox_TextChanged(object sender, EventArgs e)
    {
      FormGlobals.Control_SetError(objTextBox, "");
    }

    private void GetValue(bool isMaxValue, ref object mValue)
    {
      object objValue;
      if (isMaxValue)
        objValue = m_objMaxValue;
      else
        objValue = m_objMinValue;

      if (objValue is TextBox)
      {
        TextBox tmpObject = (TextBox)objValue;
        while (tmpObject is TextBox)
        {
          if (!(tmpObject.Tag is FormGlobals.FormControlExt))
            break;

          FormGlobals.FormControlExt tmp = (FormGlobals.FormControlExt)tmpObject.Tag;
          TextBoxHandle mHandle = (TextBoxHandle)tmp.HandleObject;
          if (isMaxValue)
            tmpObject = (TextBox)mHandle.MaxValue;
          else
            tmpObject = (TextBox)mHandle.MinValue;

          Globals.Object_SetValue(tmpObject, ref mValue);
          if (!Null.IsNull(mValue))
            break;
        }
      }
    }

    private void TextBox_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        if (!objTextBox.ReadOnly)
        {
          string sValue = objTextBox.Text.Trim();
          bool bWrong = false;
          string sMessage = null;
          if (sValue.Length > 0)
          {
            if (CS_STRING_TYPE.IndexOf(m_sDataType.ToUpper() + ",") > -1)
            {
              if (FormGlobals.Control_GetError(objTextBox) != "")
                return;

              objTextBox.Text = sValue;
            }
            if (CS_FLOAT_TYPE.Contains(m_sDataType))
            {
              bWrong = !Globals.IsNumeric(sValue);
              sMessage = "Please input numeric value";
            }
            else if (CS_INT_TYPE.Contains(m_sDataType))
            {
              bWrong = !Globals.IsNumeric(sValue);
              if (!bWrong)
              {
                long iValue = 0;
                object obj = iValue;
                Globals.Object_SetValue(sValue, ref obj);
                objTextBox.Text = Convert.ToString(iValue);
              }
              sMessage = "Please input Integer value";
            }
            else if ("DATE;DATETIME".Contains(m_sDataType))
            {
              DateTime mDate = new DateTime();
              Globals.Date_FixString(ref sValue, false);
              if (!Globals.Date_TryParseEx(sValue, ref mDate))
                bWrong = true;
              else
                objTextBox.Text = mDate.ToString(Globals.CS_DISPLAY_DATE_FORMAT);

              sMessage = "Please input Date value";
            }
            else
            {
              if (m_sDataType != "TIME")
                return;

              if (!Globals.IsDate(sValue))
              {
                if (System.Text.RegularExpressions.Regex.IsMatch(sValue, "####"))
                  sValue = sValue.Substring(0, 2) + ":" + sValue.Substring(2, 2);
                else if (System.Text.RegularExpressions.Regex.IsMatch(sValue, "###"))
                  sValue = sValue.Substring(0, 1) + ":" + sValue.Substring(1, 2);
                else if (System.Text.RegularExpressions.Regex.IsMatch(sValue, "##"))
                  sValue = sValue + ":00";
              }
              if (!Globals.IsDate(sValue))
                bWrong = true;
              else
                objTextBox.Text = DateTime.Parse(sValue).ToString("HH:mm");

              sMessage = "Please input Time value";
            }
            if (!((m_objMinValue == null) & (m_objMaxValue == null)))
            {
              object sCheckRange = CheckRange(sValue, m_sDataType);
              if (!bWrong)
                bWrong = (sCheckRange.ToString() != "");

              sMessage += sCheckRange.ToString();
            }
            if (m_bClearError & bWrong)
            {
              objTextBox.Text = "";
              return;
            }
          }
          if (bWrong)
            e.Cancel = true;
          else
          {
            sMessage = "";
            if (m_objMinValue is TextBox)
              FormGlobals.Control_SetError((Control)m_objMinValue, "");

            if (m_objMaxValue is TextBox)
              FormGlobals.Control_SetError((Control)m_objMaxValue, "");

            if (m_sNumber_Data_Type.Contains(m_sDataType))
            {
              decimal mValue = 0;
              object obj = mValue;
              Globals.Object_SetValue(objTextBox.Text, ref obj);
              mValue = Convert.ToDecimal(mValue);
              objTextBox.Text = Globals.Object_GetDisplayValue(mValue, "");
            }
          }
          FormGlobals.Control_SetError(objTextBox, sMessage);
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private object CheckRange(string sValue, string sDataType)
    {
      bool bReturn = true;
      string sMinValue = null;
      string sMaxValue = null;

      if (((((sDataType.ToUpper() == "NUMBER") || (sDataType.ToUpper() == "FLOAT")) || ((sDataType.ToUpper() == "DOUBLE") || (sDataType.ToUpper() == "LONG"))) || (((sDataType.ToUpper() == "BIGINT") || (sDataType.ToUpper() == "INT")) || ((sDataType.ToUpper() == "INTEGER") || (sDataType.ToUpper() == "SHORT")))) || (((sDataType.ToUpper() == "SMALLINT") || (sDataType.ToUpper() == "INT64")) || ((sDataType.ToUpper() == "INT32") || (sDataType.ToUpper() == "INT16"))))
      {
        object MaxValue = null;
        object MinValue = null;
        object mValue = null;
        switch (sDataType.ToUpper())
        {
          case "NUMBER":
          case "FLOAT":
          case "DOUBLE":
            MaxValue = Convert.ToDouble(MaxValue);
            MinValue = Convert.ToDouble(MinValue);
            mValue = Convert.ToDouble(mValue);
            break;

          case "LONG":
          case "BIGINT":
          case "INT64":
            MaxValue = Convert.ToInt64(MaxValue);
            MinValue = Convert.ToInt64(MinValue);
            mValue = Convert.ToInt64(mValue);
            break;

          case "INT":
          case "INTEGER":
          case "INT32":
            MaxValue = Convert.ToInt32(MaxValue);
            MinValue = Convert.ToInt32(MinValue);
            mValue = Convert.ToInt32(mValue);
            break;

          case "SHORT":
          case "SMALLINT":
          case "INT16":
            MaxValue = Convert.ToInt16(MaxValue);
            MinValue = Convert.ToInt16(MinValue);
            mValue = Convert.ToInt16(mValue);
            break;
        }
        Globals.Object_SetValue(m_objMaxValue, ref MaxValue);
        Globals.Object_SetValue(m_objMinValue, ref MinValue);
        if (!Null.IsNull(MaxValue))
          sMaxValue = MaxValue.ToString();

        if (!Null.IsNull(MinValue))
          sMinValue = MinValue.ToString();

        if (Globals.IsNumeric(sValue))
        {
          Globals.Object_SetValue(sValue, ref mValue);
          if (!Null.IsNull(MaxValue))
            bReturn &= DateTime.Parse(mValue.ToString()) <= DateTime.Parse(MaxValue.ToString());
          if (!Null.IsNull(MinValue))
            bReturn &= DateTime.Parse(mValue.ToString()) >= DateTime.Parse(MinValue.ToString());
        }
        else
          bReturn = false;
      }
      else
      {
        if ((sDataType.ToUpper() == "DATE") || (sDataType.ToUpper() == "DATETIME"))
        {
          DateTime MaxValue = new DateTime();
          DateTime MinValue = new DateTime();
          object obj = MaxValue;
          Globals.Object_SetValue(m_objMaxValue, ref obj);
          MaxValue = Convert.ToDateTime(obj);
          if (MaxValue == Null.NullDate)
          {
            GetValue(true, ref obj);
            MaxValue = Convert.ToDateTime(obj);
          }
          obj = MinValue;
          Globals.Object_SetValue(m_objMinValue, ref obj);
          MinValue = Convert.ToDateTime(obj);
          if (MinValue == Null.NullDate)
          {
            obj = MinValue;
            GetValue(false, ref obj);
            MinValue = Convert.ToDateTime(obj);
          }
          if (MinValue == Null.NullDate)
            MinValue = Null.MIN_DATE;
          if (MaxValue == Null.NullDate)
            MaxValue = Null.MAX_DATE;
          if (MaxValue == Null.NullDate)
            sMaxValue = MaxValue.ToString(Globals.CS_DISPLAY_DATE_FORMAT);
          if (MinValue == Null.NullDate)
            sMinValue = MinValue.ToString(Globals.CS_DISPLAY_DATE_FORMAT);
          if (Globals.IsDate(sValue))
          {
            if (MaxValue > Null.NullDate)
              bReturn &= DateTime.Parse(sValue) <= MaxValue;
            if (MinValue > Null.NullDate)
              bReturn &= DateTime.Parse(sValue) >= MinValue;
          }
          else
            bReturn = false;
        }
        else if (sDataType.ToUpper() == "TIME")
        {
          DateTime MaxValue = new DateTime();
          DateTime MinValue = new DateTime();
          object obj = MaxValue;
          Globals.Object_SetValue(m_objMaxValue, ref obj);
          MaxValue = Convert.ToDateTime(obj);
          obj = MinValue;
          Globals.Object_SetValue(m_objMinValue, ref obj);
          MinValue = Convert.ToDateTime(obj);
          if (MinValue == Null.NullDate)
            MinValue = DateTime.Parse("00:00");
          if (MaxValue > Null.NullDate)
            sMaxValue = MaxValue.ToString("HH:mm");
          if (MinValue > Null.NullDate)
            sMinValue = MinValue.ToString("HH:mm");
          if (Globals.IsDate(sValue))
          {
            if (MaxValue > Null.NullDate)
              bReturn &= DateTime.Parse(sValue) <= MaxValue;
            if (MinValue > Null.NullDate)
              bReturn &= DateTime.Parse(sValue) >= MinValue;
          }
          else
            bReturn = false;
        }
      }
      string sMessage = "";
      if (!bReturn)
      {
        if ((sMinValue != "") & (sMaxValue != ""))
          return (" from " + sMinValue + " to " + sMaxValue);

        if (sMinValue != "")
          return (" greater than or equal " + sMinValue);

        if (sMaxValue != "")
          sMessage = " less than or equal " + sMaxValue;
      }
      return sMessage;
    }

    public bool AutoClearError
    {
      get
      {
        return m_bClearError;
      }
      set
      {
        m_bClearError = value;
      }
    }

    public string ControlName
    {
      get
      {
        return objTextBox.Name;
      }
    }

    public string DataType
    {
      get
      {
        return m_sDataType;
      }
      set
      {
        if (m_sAll_Data_Type.IndexOf(value.ToUpper() + ",") == -1)
          throw new Exception("Invalid data type");

        m_sDataType = value.ToUpper();
      }
    }

    public object MaxValue
    {
      get
      {
        return m_objMaxValue;
      }
      set
      {
        m_objMaxValue = value;
      }
    }

    public object MinValue
    {
      get
      {
        return m_objMinValue;
      }
      set
      {
        m_objMinValue = value;
      }
    }
  }
}