using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.DataAccess.Admin;

namespace TMV.BusinessObject.Admin
{
  public class APP_GroupsBO
  {
    #region "Constructor"
    private static APP_GroupsBO _instance;
    private static object _syncLock = new object();

    protected APP_GroupsBO()
    {
    }

    public static APP_GroupsBO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_GroupsBO();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public void Delete(decimal GROUP_ID)
    {
      APP_GroupsDAO.Instance().Delete(GROUP_ID);
    }

    public DataSet GetAll()
    {
      return APP_GroupsDAO.Instance().GetAll();
    }

    public APP_GroupsInfo GetById(decimal GROUP_ID)
    {
      return APP_GroupsDAO.Instance().GetById(GROUP_ID);
    }

    public void Insert(APP_GroupsInfo objInfo)
    {
      APP_GroupsDAO.Instance().Insert(objInfo);
    }

    public void Update(APP_GroupsInfo objInfo)
    {
      APP_GroupsDAO.Instance().Update(objInfo);
    }

    public DataTable GETBYUSERID(decimal pUserID)
    {
      return APP_GroupsDAO.Instance().GETBYUSERID(pUserID);
    }
  }
}