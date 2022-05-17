using System;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraEditors;

namespace TMV.Common.ControlHandles
{
  public class LookUpEditHandle : NativeWindow
  {
    private LookUpEdit objLookUpEdit;

    private LookUpEditHandle()
    {
      objLookUpEdit.KeyPress += new KeyPressEventHandler(objLookUpEdit_KeyPress);
      objLookUpEdit.Validating += new CancelEventHandler(objLookUpEdit_Validating);
    }

    public LookUpEditHandle(LookUpEdit lue)
    {
      objLookUpEdit = lue;
    }

    private void objLookUpEdit_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (Convert.ToString(e.KeyChar) == "\r")
      {
        e.Handled = true;
        SendKeys.Send("{TAB}");
      }
    }

    private void objLookUpEdit_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        objLookUpEdit.DataBindings.Clear();
      }
      catch (Exception exp)
      {
        FormGlobals.Message_Error(exp);
      }
    }
  }
}