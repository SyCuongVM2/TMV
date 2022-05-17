using System;
using System.Threading;
using System.Windows.Forms;

namespace TMV.Common.Forms
{
  public partial class frmProgress : Form
  {
    #region "constructor"
    private static frmProgress _instance;
    private static object _syncLock = new object();

    public static frmProgress Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
          {
            _instance = new frmProgress();
            _instance.Tag = "MAIN_INIT";
          }
        }
      }
      return _instance;
    }

    protected new void Dispose()
    {
      _instance.Dispose();
      _instance = null;
      base.Dispose();
    }

    public frmProgress()
    {
      InitializeComponent();
    }
    #endregion

    public delegate object FunctionInvoker(object sInput);
    public delegate void SubInvoker(object sInput);

    private FunctionInvoker _ThreadFunction;
    private SubInvoker _ThreadSub;
    private MethodInvoker _ThreadMethod;

    public object ThreadInputObject;
    private object _ThreadOutputObject;
    private Thread m_objThread;
    private string m_sTextDescription;
    private string m_sTextFinish;
    private Exception m_TheardException;
    private string m_sErrorRaTPPS;

    public FunctionInvoker ThreadFunction
    {
      set
      {
        _ThreadFunction = value;
        _ThreadSub = null;
        _ThreadMethod = null;
        _ThreadOutputObject = null;
      }
    }
    public SubInvoker ThreadSub
    {
      set
      {
        _ThreadSub = value;
        _ThreadFunction = null;
        _ThreadMethod = null;
      }
    }
    public MethodInvoker Thread
    {
      set
      {
        _ThreadMethod = value;
        _ThreadSub = null;
        _ThreadFunction = null;
      }
    }
    public bool IsAbort
    {
      get
      {
        return Convert.ToBoolean(AppDomain.CurrentDomain.GetData("Progress_Abort"));
      }
    }
    public object Show_Progress(string sStart, string sFinish)
    {
      m_sTextFinish = sFinish;
      return Show_Progress(sStart, false);
    }
    public object Show_Progress()
    {
      m_sTextFinish = "";
      return Show_Progress("Loading ...", false);
    }
    public object Show_Progress(string sStart)
    {
      m_sTextFinish = "";
      return Show_Progress(sStart, false);
    }
    public object Show_Progress(string sStart, bool bAllowCancel)
    {
      if (((_ThreadMethod == null) & (_ThreadSub == null)) & (_ThreadFunction == null))
      {
        throw new Exception("No method or function assigned");
      }
      try
      {
        Init_Circle(LoadingCircle);
        if (m_objThread != null)
          m_objThread.Abort();

        m_objThread = new Thread(new ThreadStart(Show_Circle));
        if (string.IsNullOrEmpty(sStart))
          sStart = "Loading ...";
        else if (!sStart.EndsWith("..."))
          sStart += " ...";

        m_sTextDescription = sStart;
        SetDescription();
        cmdCancel.Visible = bAllowCancel;
        m_TheardException = null;

        if (!bAllowCancel)
          Width = 240;

        Tag = "MAIN_PRORESS";
        TopMost = false;
        Timer_Event.Enabled = false;
        ShowDialog();
        if (m_objThread.ThreadState == ThreadState.Running)
        {
          AppDomain.CurrentDomain.SetData("Progress_Stop", true);
          while (m_objThread.ThreadState != ThreadState.Stopped)
          {
            System.Threading.Thread.Sleep(50);
          }
          m_objThread.Abort();
          m_objThread = null;
        }
        if (m_TheardException != null)
          throw m_TheardException;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        m_TheardException = null;
        Hide();
      }
      return _ThreadOutputObject;
    }
    private void Init_Circle(FAMP.LoadingCircle lc)
    {
      lc.StylePreset = FAMP.LoadingCircle.StylePresets.Custom;
      lc.OuterCircleRadius = 12;
      lc.InnerCircleRadius = 9;
      lc.NumberSpoke = 12;
      lc.SpokeThickness = 4;
      lc.RotationSpeed = 150;
      lc.Active = false;
    }
    public void SetDescriptionText(string sDescription)
    {
      m_sTextDescription = sDescription;
      SetDescription();
    }
    private void SetDescription()
    {
      lbDescription.Text = m_sTextDescription;
      AppDomain.CurrentDomain.SetData("Progress_Desc", m_sTextDescription);
    }
    public void SetFinishText(string sFinish, int iDelay)
    {
      m_sTextDescription = sFinish;
      SetDescription();
      System.Threading.Thread.Sleep(iDelay);
    }
    private void Dummy_Function()
    {
      try
      {
        if (_ThreadMethod != null)
          _ThreadMethod.Invoke();
        else if (_ThreadSub != null)
          _ThreadSub.Invoke(ThreadInputObject);
        else if (_ThreadFunction != null)
          _ThreadOutputObject = _ThreadFunction.Invoke(ThreadInputObject);
      }
      catch (Exception ex)
      {
        m_TheardException = ex;
      }
    }
    private void Show_Circle()
    {
      frmProgress f = new frmProgress();
      try
      {
        m_sErrorRaTPPS = "Init Child";
        Init_Circle(f.LoadingCircle);
        f.LoadingCircle.Active = true;
        f.Timer_Event.Interval = 75;
        f.Timer_Event.Enabled = true;
        f.lbDescription.Text = m_sTextDescription;
        f.Tag = "CHILD";
        f.Width = Width;
        f.TopMost = TopMost;
        f.cmdCancel.Visible = cmdCancel.Visible;
        f.cmdCancel.TabStop = false;
        m_sErrorRaTPPS = "Show Child";
        f.ShowDialog();
      }
      catch
      {
      }
      finally
      {
        f.LoadingCircle.Active = false;
        f.Timer_Event.Enabled = false;
        f.Close();
      }
    }

    private void frmProgress_Activated(object sender, EventArgs e)
    {
      try
      {
        if (Tag.ToString() == "MAIN_PRORESS")
        {
          if (m_objThread == null)
            Close();
          else
          {
            AppDomain.CurrentDomain.SetData("Progress_Abort", false);
            AppDomain.CurrentDomain.SetData("Progress_Stop", false);
            m_sErrorRaTPPS = "Thread start";
            m_objThread.Start();
            Application.DoEvents();
            m_sErrorRaTPPS = "Process Function";
            Dummy_Function();
            if (m_sTextFinish != "")
            {
              SetFinishText(m_sTextFinish, 500);
              m_sTextFinish = "";
            }
            Close();
          }
        }
        else
          Application.DoEvents();
      }
      catch (Exception ex)
      {
        m_TheardException = ex;
      }
    }
    private void Timer_Event_Tick(object sender, EventArgs e)
    {
      bool bStop = false;
      try
      {
        if (Tag.ToString() == "CHILD")
        {
          lbDescription.Text = Convert.ToString(AppDomain.CurrentDomain.GetData("Progress_Desc"));
          if (Convert.ToBoolean(AppDomain.CurrentDomain.GetData("Progress_Stop")))
            Hide();
        }
        else if (Tag.ToString() == "MAIN_PROGRESS")
          bStop = Convert.ToBoolean(AppDomain.CurrentDomain.GetData("Progress_Abort"));
      }
      catch
      {
      }
    }
    private void cmdCancel_Click(object sender, EventArgs e)
    {
      SetDescriptionText("Cancelling ...");
      AppDomain.CurrentDomain.SetData("Progress_Abort", true);
      cmdCancel.Enabled = false;
    }
  }
}