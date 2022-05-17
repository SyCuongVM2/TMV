using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

namespace TMV.Common.ControlHandles
{
  public class ComboBoxHandle : NativeWindow
  {
    private ComboBox objComboBox = new ComboBox();

    protected ComboBoxHandle()
    {
      objComboBox.Enter += new EventHandler(objComboBox_Enter);
      objComboBox.Validated += new EventHandler(objComboBox_Validated);
      objComboBox.KeyPress += new KeyPressEventHandler(objComboBox_KeyPress);
      objComboBox.SelectedIndexChanged += new EventHandler(objComboBox_SelectedIndexChanged);
      objComboBox.TextUpdate += new EventHandler(objComboBox_TextUpdate);
      objComboBox.Validating += new CancelEventHandler(objComboBox_Validating);
    }

    public ComboBoxHandle(ComboBox tb)
    {
      objComboBox = tb;
      objComboBox.DropDownStyle = ComboBoxStyle.DropDown;
    }

    private void objComboBox_Enter(object sender, EventArgs e)
    {
      try
      {
        if (!objComboBox.DroppedDown)
          objComboBox.DroppedDown = true;
      }
      catch (Exception exp)
      {
        FormGlobals.Message_Error(exp);
      }
    }

    private void objComboBox_Validated(object sender, EventArgs e)
    {
      try
      {
        if (objComboBox.Enabled)
        {
          long iIndex = objComboBox.FindString(objComboBox.Text);
          if (iIndex >= 0L)
            objComboBox.SelectedIndex = (int)iIndex;
          else if (objComboBox.Items.Count > 0)
            objComboBox.SelectedIndex = 0;
          else
            objComboBox.Text = "";
        }
      }
      catch (Exception exp)
      {
        FormGlobals.Message_Error(exp);
      }
    }

    private void objComboBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (Convert.ToString(e.KeyChar) == "\r")
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
    }

    private void objComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (objComboBox.Parent.Controls.ContainsKey(objComboBox.Name + "_View"))
        {
          TextBox ctlView = (TextBox)objComboBox.Parent.Controls[objComboBox.Name + "_View"];
          ctlView.Text = objComboBox.Text;
        }
      }
      catch (Exception exp)
      {
        FormGlobals.Message_Error(exp);
      }
    }

    private void objComboBox_TextUpdate(object sender, EventArgs e)
    {
      try
      {
        DataView dtView;
        if (objComboBox.ContainsFocus)
        {
          if (objComboBox.DataSource is DataTable)
            dtView = ((DataTable)objComboBox.DataSource).DefaultView;
          else if (objComboBox.DataSource is DataView)
            dtView = (DataView)objComboBox.DataSource;
          else
            return;
          dtView.RowFilter = "Sort_Field LIKE '" + objComboBox.Text + "%'";
        }
      }
      catch (Exception exp)
      {
        FormGlobals.Message_Error(exp);
      }
    }

    private void objComboBox_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        DataView dtView;
        if (objComboBox.DataSource is DataTable)
          dtView = ((DataTable)objComboBox.DataSource).DefaultView;
        else if (objComboBox.DataSource is DataView)
          dtView = (DataView)objComboBox.DataSource;
        else
          return;

        string sOldText = objComboBox.Text;
        dtView.RowFilter = "";
        objComboBox.Text = sOldText;
      }
      catch (Exception exp)
      {
        FormGlobals.Message_Error(exp);
      }
    }
  }
}