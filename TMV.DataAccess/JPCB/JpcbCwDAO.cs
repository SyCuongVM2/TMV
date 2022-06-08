using System.Data;
using TMV.Common;

namespace TMV.DataAccess.JPCB
{
  public class JpcbCwDAO
  {
    #region "Constructor"
    private static JpcbCwDAO _instance;
    private static object _syncLock = new object();

    protected JpcbCwDAO()
    {
    }
    public static JpcbCwDAO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new JpcbCwDAO();
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
      return SqlDataAccess.ExecuteDataset(
        SqlConnect.ConnectionString,
        Constants.Instance().AppJpcbPkgGetConfigs,
        new object[] {
          Globals.DB_GetNull(tenantId),
          Globals.DB_GetNull(type) // CW, GJ, BP
        }
      );
    }
  }
}