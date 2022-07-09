using System;
using System.Data;
using TMV.DataAccess.JPCB;

namespace TMV.BusinessObject.JPCB
{
  public class JpcbJpBO
  {
    #region "Constructor"
    private static JpcbJpBO _instance;
    private static object _syncLock = new object();

    protected JpcbJpBO()
    {
    }
    public static JpcbJpBO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new JpcbJpBO();
        }
      }
      return _instance;
    }
    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public DataSet JPVisibleTabs(int tenantId, decimal userId)
    {
      return JpcbJpDAO.Instance().JPVisibleTabs(tenantId, userId);
    }
    public DataSet GetJPConfig(int tenantId, string type)
    {
      return JpcbJpDAO.Instance().GetJPConfig(tenantId, type);
    }
    public DataSet GetConfigDefault(int tenantId, DateTime date)
    {
      return JpcbJpDAO.Instance().GetConfigDefault(tenantId, date);
    }
    public DataSet GetJPData(int tenantId, string type, DateTime dateView)
    {
      return JpcbJpDAO.Instance().GetJPData(
        tenantId,
        (type == "GJ") ? 2 : 1,
        dateView
      );
    }
    public DataSet GetJPCholapKHSuaxong(int tenantId, string type, DateTime dateView)
    {
      return JpcbJpDAO.Instance().GetJPCholapKHSuaxong(
        tenantId,
        (type == "GJ") ? 2 : 1,
        dateView
      );
    }
    public DataSet GetJPMolenhGiaoxe(int tenantId, string type, DateTime dateView)
    {
      return JpcbJpDAO.Instance().GetJPMolenhGiaoxe(
        tenantId,
        (type == "GJ") ? 2 : 1,
        dateView
      );
    }
    public DataSet GetJPDangSuaChua(int tenantId, string type, DateTime dateView)
    {
      return JpcbJpDAO.Instance().GetJPDangSuaChua(
        tenantId,
        (type == "GJ") ? 2 : 1,
        dateView
      );
    }
    public DataSet GetJPXeDung(int tenantId, string type, DateTime dateView)
    {
      return JpcbJpDAO.Instance().GetJPXeDung(
        tenantId,
        (type == "GJ") ? 2 : 1,
        dateView
      );
    }
    public DataSet UpdateKeothaResize(decimal userId, int tenantId, string roType, decimal id, string table,
                                      DateTime from, DateTime to, int workshop)
    {
      return JpcbJpDAO.Instance().UpdateKeothaResize(
        userId,
        tenantId,
        roType,
        id,
        table,
        from,
        to,
        workshop
      );
    }
  }
}