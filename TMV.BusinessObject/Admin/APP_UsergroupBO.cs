using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.DataAccess.Admin;

namespace TMV.BusinessObject.Admin
{
  public class APP_UsergroupBO
  {
    #region "Constructor"
    private static APP_UsergroupBO _instance;
    private static object _syncLock = new object();

    protected APP_UsergroupBO()
    {
    }

    public static APP_UsergroupBO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_UsergroupBO();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public void Delete(decimal USER_ID, decimal GROUP_ID)
    {
      APP_UsergroupDAO.Instance().Delete(USER_ID, GROUP_ID);
    }

    public DataSet GetAll()
    {
      return APP_UsergroupDAO.Instance().GetAll();
    }

    public DataSet GetByGroup(decimal GROUP_ID)
    {
      return APP_UsergroupDAO.Instance().GetByGroup(GROUP_ID);
    }

    public APP_UsergroupInfo GetById(decimal USER_ID, decimal GROUP_ID)
    {
      return APP_UsergroupDAO.Instance().GetById(USER_ID, GROUP_ID);
    }

    public DataSet GetByUser(decimal USER_ID)
    {
      return APP_UsergroupDAO.Instance().GetByUser(USER_ID);
    }

    public void Insert(APP_UsergroupInfo objInfo)
    {
      APP_UsergroupDAO.Instance().Insert(objInfo);
    }

    public void Update(decimal UserID, string GroupString)
    {
      APP_UsergroupDAO.Instance().Update(UserID, GroupString);
    }
  }
}