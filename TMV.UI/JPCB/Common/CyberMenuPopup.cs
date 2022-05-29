using DevExpress.Portable.Input;
using DevExpress.Services;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraScheduler;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TMV.UI.JPCB.Common
{
  public class CyberMenuPopup : BarButtonItem
  {
    private EventHandler V_kh;

    public CyberMenuPopup(
      object view,
      int rowHandle,
      string Title,
      EventHandler handel,
      Image img = null,
      bool _Enabled = true,
      bool _Group = false)
    {
      Caption = Title;
      Glyph = img;
      Enabled = _Enabled;
      V_kh = handel;
      ItemClick += new ItemClickEventHandler(CyberLeave);
      Name = Name;
    }

    public CyberMenuPopup(
      object view,
      int rowHandle,
      string Title,
      EventHandler handel,
      Shortcut _ShortCut,
      Image img = null,
      bool _Enabled = true,
      DefaultBoolean _ShowShortCut = DefaultBoolean.False)
    {
      Caption = Title;
      Glyph = img;
      Enabled = _Enabled;
      ShortCut = _ShortCut;
      V_kh = handel;
      ItemClick += new ItemClickEventHandler(CyberLeave);
      Name = Name;
    }

    private void CyberLeave(object sender, EventArgs e)
    {
      if (V_kh == null)
        return;
      V_kh(sender, e);
    }
  }

  public class CyberBarSubMenuPopup : BarSubItem
  {
    public CyberBarSubMenuPopup(
      object view,
      int rowHandle,
      string Title,
      EventHandler handel,
      Image img = null,
      bool _Enabled = true,
      bool _Group = false)
    {
      this.Caption = Title;
      this.Glyph = img;
      this.Enabled = _Enabled;
      this.Name = this.Name;
    }

    public class CustomMouseHandlerService : DevExpress.Services.MouseHandlerServiceWrapper
    {
      private System.IServiceProvider provider;

      public CustomMouseHandlerService(System.IServiceProvider provider, IMouseHandlerService service)
        : base(service)
      {
        this.provider = provider;
      }

      public override void OnMouseWheel(PortableMouseEventArgs e)
      {
        if (this.provider is SchedulerControl provider && provider.ActiveViewType == SchedulerViewType.Gantt)
          return;
        base.OnMouseWheel(e);
      }
    }
  }
}