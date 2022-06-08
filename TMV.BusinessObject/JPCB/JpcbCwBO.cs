using System.Data;
using TMV.DataAccess.JPCB;

namespace TMV.BusinessObject.JPCB
{
  public class JpcbCwBO
  {
    #region "Constructor"
    private static JpcbCwBO _instance;
    private static object _syncLock = new object();

    protected JpcbCwBO()
    {
    }
    public static JpcbCwBO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new JpcbCwBO();
        }
      }
      return _instance;
    }
    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public DataSet GetCWConfig(int tenantId, string type)
    {
      return JpcbCwDAO.Instance().GetCWConfig(tenantId, type); // CW, GJ, BP
    }
  }
}