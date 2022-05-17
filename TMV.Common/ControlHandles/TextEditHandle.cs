using System;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraEditors;

namespace TMV.Common.ControlHandles
{
  public class TextEditHandle
  {
    private TextEdit objTextEdit;
    private string m_sDataType;
    private object m_objMaxValue;
    private object m_objMinValue;
    private bool m_bClearError;
    private bool m_bMouseOver;
    private const string CS_FLOAT_TYPE = "NUMBER,DOUBLE,FLOAT,DECIMAL,MONEY";
    private const string CS_INT_TYPE = "LONG,BIGINT,INT,INTEGER,SHORT,SMALLINT,";
    private const string CS_DATE_TYPE = "DATE,DATETIME,DATESHORT,TIME,";
    private const string CS_STRING_TYPE = "NVARCHAR2,VARCHAR2,VARCHAR,NVARCHAR,CHAR,NCLOB,TEXT,NTEXT";
    private string m_sAll_Data_Type = CS_FLOAT_TYPE + CS_INT_TYPE + CS_DATE_TYPE + CS_STRING_TYPE;
    private string m_sNumber_Data_Type = CS_FLOAT_TYPE + CS_INT_TYPE;

    protected TextEditHandle()
    {
      objTextEdit.Enter += new EventHandler(objTextEdit_Enter);
      objTextEdit.KeyPress += new KeyPressEventHandler(TextEdit_KeyPress);
      objTextEdit.MouseEnter += new EventHandler(objTextEdit_MouseEnter);
      objTextEdit.MouseLeave += new EventHandler(objTextEdit_MouseLeave);
      objTextEdit.TextChanged += new EventHandler(objTextEdit_TextChanged);
      objTextEdit.Validating += new CancelEventHandler(objTextEdit_Validating);
    }

    public TextEditHandle(TextEdit te, string DataType, object MinValue, object MaxValue)
    {
      objTextEdit = te;
      m_objMaxValue = MaxValue;
      m_objMinValue = MinValue;

      if (DataType != null)
      {
        m_sDataType = DataType.ToUpper();
        switch (m_sDataType.ToUpper())
        {
          case "NUMBER":
          case "FLOAT":
          case "DOUBLE":
          case "DECIMAL":
          case "MONEY":
            {
              te.Properties.MaxLength = double.MaxValue.ToString().Length;
              te.RightToLeft = RightToLeft.Yes;
              if (m_objMaxValue == null)
                m_objMaxValue = Double.MaxValue;

              if (m_objMinValue == null)
                m_objMinValue = Double.MinValue;
              break;
            }
          case "INT":
          case "INTEGER":
            {
              te.Properties.MaxLength = int.MaxValue.ToString().Length;
              te.RightToLeft = RightToLeft.Yes;
              if (m_objMaxValue == null)
                m_objMaxValue = int.MaxValue;

              if (m_objMinValue == null)
                m_objMinValue = int.MinValue;
              break;
            }
          case "INT64":
          case "LONG":
          case "BIGINT":
            {
              te.Properties.MaxLength = long.MaxValue.ToString().Length;
              te.RightToLeft = RightToLeft.Yes;
              if (m_objMaxValue == null)
                m_objMaxValue = long.MaxValue;

              if (m_objMinValue == null)
                m_objMinValue = long.MinValue;
              break;
            }
          case "INT16":
          case "SHORT":
          case "SMALLINT":
            {
              te.Properties.MaxLength = short.MaxValue.ToString().Length;
              te.RightToLeft = RightToLeft.Yes;
              if (m_objMaxValue == null)
                m_objMaxValue = short.MaxValue;

              if (m_objMinValue == null)
                m_objMinValue = short.MinValue;
              break;
            }
          case "DATE":
          case "DATETIME":
            te.Properties.MaxLength = 10;
            break;
          case "DATESHORT":
            te.Properties.MaxLength = 10;
            break;
          case "TIME":
            te.Properties.MaxLength = 5;
            break;
          case "TEXT":
          case "NTEXT":
            te.Properties.MaxLength = 2000;
            break;
          default:
            if (m_sAll_Data_Type.IndexOf(DataType.ToUpper() + ",") == -1)
              throw new Exception("Invalid data type: " + DataType);
            break;
        }
      }
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
        return objTextEdit.Name;
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

    private void objTextEdit_Enter(object sender, EventArgs e)
    {
      try
      {
        if (!objTextEdit.Properties.ReadOnly)
        {
          switch (m_sDataType.ToUpper())
          {
            case "DATE":
            case "DATETIME":
              if (Globals.IsDate(objTextEdit.Text))
                objTextEdit.Text = Convert.ToDateTime(objTextEdit.Text).ToString(Globals.CS_EDIT_DATE_FORMAT);
              break;
          }
          objTextEdit.SelectAll();
          if (!m_bMouseOver)
            SetToolTip(true);
        }
      }
      catch (Exception ex)
      {
        FormGlobals.Message_Error(ex);
      }
    }

    private void TextEdit_KeyPress(object sender, KeyPressEventArgs e)
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
              if (objTextEdit.Properties.AutoHeight)
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
      ToolTip objToolTip = FormGlobals.Form_GetToolTip(objTextEdit.FindForm());
      objToolTip.ToolTipTitle = "";
      objToolTip.Show(sTip, objTextEdit, 1000);
    }

    private void objTextEdit_MouseEnter(object sender, EventArgs e)
    {
      m_bMouseOver = true;
      SetToolTip(false);
    }

    private void SetToolTip(bool bShow)
    {
      if (!objTextEdit.Properties.ReadOnly && objTextEdit.Enabled)
      {
        ToolTip objToolTip = FormGlobals.Form_GetToolTip(objTextEdit.FindForm());
        objToolTip.Active = false;
        objToolTip.Hide(objTextEdit);
        string sText = string.Format("Input Length: {0}/{1}\r", objTextEdit.Text.Length, objTextEdit.Properties.MaxLength);
        if (FormGlobals.Control_GetRequire(objTextEdit))
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

        objToolTip.SetToolTip(objTextEdit, sText);
        objToolTip.Active = true;
        if (bShow)
          objToolTip.Show(sText, objTextEdit, objToolTip.AutoPopDelay);
      }
    }

    private void objTextEdit_MouseLeave(object sender, EventArgs e)
    {
      m_bMouseOver = false;
    }

    private void objTextEdit_TextChanged(object sender, EventArgs e)
    {
      FormGlobals.Control_SetError(objTextEdit, "");
    }

    private void objTextEdit_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        if (!objTextEdit.Properties.ReadOnly)
        {
          string sValue = objTextEdit.Text.Trim();
          bool bWrong = false;
          string sMessage = null;
          if (sValue.Length > 0)
          {
            if (CS_STRING_TYPE.IndexOf(m_sDataType.ToUpper() + ",") > -1)
            {
              if (FormGlobals.Control_GetError(objTextEdit) != "")
                return;

              objTextEdit.Text = sValue;
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
                object temp = iValue;
                Globals.Object_SetValue(sValue, ref temp);
                objTextEdit.Text = Convert.ToString(temp);
                iValue = Convert.ToInt64(temp);
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
                objTextEdit.Text = mDate.ToString(Globals.CS_DISPLAY_DATE_FORMAT);

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
                objTextEdit.Text = DateTime.Parse(sValue).ToString("HH:mm");

              sMessage = "Please input Time value";
            }
            if (!((m_objMinValue == null) & (m_objMaxValue == null)))
            {
              object sCheckRange = CheckRange(sValue, m_sDataType);
              if (!bWrong)
                bWrong = (sCheckRange.ToString() != "");

              sMessage += sCheckRange;
            }
            if (m_bClearError & bWrong)
            {
              objTextEdit.Text = "";
              return;
            }
          }
          if (bWrong)
            e.Cancel = true;
          else
          {
            sMessage = "";
            if (m_objMinValue is TextEdit)
              FormGlobals.Control_SetError((Control)m_objMinValue, "");

            if (m_objMaxValue is TextEdit)
              FormGlobals.Control_SetError((Control)m_objMaxValue, "");

            if (m_sNumber_Data_Type.Contains(m_sDataType))
            {
              decimal mValue = 0;
              object temp = mValue;
              Globals.Object_SetValue(objTextEdit.Text, ref temp);
              objTextEdit.Text = Globals.Object_GetDisplayValue(temp, "");
              mValue = Convert.ToDecimal(temp);
            }
          }
          FormGlobals.Control_SetError(objTextEdit, sMessage);
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

      switch (sDataType.ToUpper())
      {
        case "NUMBER":
        case "FLOAT":
        case "DOUBLE":
        case "LONG":
        case "BIGINT":
        case "INT":
        case "INTEGER":
        case "SHORT":
        case "SMALLINT":
        case "INT64":
        case "INT32":
        case "INT16":
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
                bReturn = bReturn && (DateTime.Parse(sValue) <= DateTime.Parse(MaxValue.ToString()));

              if (!Null.IsNull(MinValue))
                bReturn = bReturn && (DateTime.Parse(sValue) >= DateTime.Parse(MinValue.ToString()));
            }
            else
              bReturn = false;

            break;
          }
        case "DATE":
        case "DATETIME":
          {
            DateTime MaxValue = new DateTime();
            DateTime MinValue = new DateTime();
            object tempMax = MaxValue;
            Globals.Object_SetValue(m_objMaxValue, ref tempMax);
            MaxValue = Convert.ToDateTime(tempMax);
            if (DateTime.Compare(MaxValue, Null.NullDate) == 0)
            {
              GetValue(true, ref tempMax);
              MaxValue = Convert.ToDateTime(tempMax);
            }
            object tempMin = MinValue;
            Globals.Object_SetValue(m_objMinValue, ref tempMin);
            MinValue = Convert.ToDateTime(tempMin);

            if (MinValue > Null.NullDate)
            {
              GetValue(false, ref tempMin);
              MinValue = Convert.ToDateTime(tempMin);
            }

            if (MinValue > Null.NullDate)
              MinValue = Null.MIN_DATE;

            if (MaxValue > Null.NullDate)
              MaxValue = Null.MAX_DATE;

            if (MaxValue > Null.NullDate)
              sMaxValue = MaxValue.ToString(Globals.CS_DISPLAY_DATE_FORMAT);

            if (DateTime.Compare(MinValue, Null.NullDate) > 0)
              sMinValue = MinValue.ToString(Globals.CS_DISPLAY_DATE_FORMAT);

            if (Globals.IsDate(sValue))
            {
              if (DateTime.Compare(MaxValue, Null.NullDate) > 0)
                bReturn = bReturn && (DateTime.Parse(sValue) <= MaxValue);

              if (DateTime.Compare(MinValue, Null.NullDate) > 0)
                bReturn = bReturn && (DateTime.Parse(sValue) >= MinValue);
            }
            else
              bReturn = false;
            break;
          }
        case "TIME":
          {
            DateTime MaxValue = new DateTime();
            DateTime MinValue = new DateTime();
            object tempMax = MaxValue;
            Globals.Object_SetValue(m_objMaxValue, ref tempMax);
            MaxValue = Convert.ToDateTime(tempMax);
            object tempMin = MinValue;
            Globals.Object_SetValue(m_objMinValue, ref tempMin);
            MinValue = Convert.ToDateTime(tempMin);

            if (MinValue == Null.NullDate)
              MinValue = DateTime.Parse("00:00");

            if (MaxValue > Null.NullDate)
              sMaxValue = MaxValue.ToString("HH:mm");

            if (MinValue > Null.NullDate)
              sMinValue = MinValue.ToString("HH:mm");

            if (Globals.IsDate(sValue))
            {
              if (MaxValue > Null.NullDate)
                bReturn = bReturn && (DateTime.Parse(sValue) <= MaxValue);

              if (MinValue > Null.NullDate)
                bReturn &= bReturn && (DateTime.Parse(sValue) >= MinValue);
            }
            else
              bReturn = false;
            break;
          }
      }

      string sMessage = "";
      if (!bReturn)
      {
        if ((sMinValue != "") & (sMaxValue != ""))
          return (" from " + sMinValue + " to " + sMaxValue);

        if (sMinValue != "")
          return (" greate than or equal " + sMinValue);

        if (sMaxValue != "")
          sMessage = " less than or equal " + sMaxValue;
      }
      return sMessage;
    }

    private void GetValue(bool isMaxValue, ref object mValue)
    {
      object objValue;

      if (isMaxValue)
        objValue = m_objMaxValue;
      else
        objValue = m_objMinValue;

      if (objValue is TextEdit)
      {
        TextEdit tmpObject = (TextEdit)objValue;
        while (tmpObject is TextEdit)
        {
          if (!(tmpObject.Tag is FormGlobals.FormControlExt))
            break;

          FormGlobals.FormControlExt obj = (FormGlobals.FormControlExt)tmpObject.Tag;
          TextEditHandle mHandle = (TextEditHandle)obj.HandleObject;
          if (isMaxValue)
            tmpObject = (TextEdit)mHandle.MaxValue;
          else
            tmpObject = (TextEdit)mHandle.MinValue;

          Globals.Object_SetValue(tmpObject, ref mValue);
          if (!Null.IsNull(mValue))
            break;
        }
      }
    }
  }
}
