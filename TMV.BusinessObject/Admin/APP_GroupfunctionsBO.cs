using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.DataAccess.Admin;

namespace TMV.BusinessObject.Admin
{
  public class APP_GroupfunctionsBO
  {
    #region "Constructor"
    private static APP_GroupfunctionsBO _instance;
    private static object _syncLock = new object();

    protected APP_GroupfunctionsBO()
    {
    }

    public static APP_GroupfunctionsBO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_GroupfunctionsBO();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public void Delete(decimal FORM_FUNCTION_ID, decimal GROUP_ID)
    {
      APP_GroupfunctionsDAO.Instance().Delete(FORM_FUNCTION_ID, GROUP_ID);
    }

    public DataSet GetAll()
    {
      return APP_GroupfunctionsDAO.Instance().GetAll();
    }

    public DataSet GetByGroup(decimal GROUP_ID)
    {
      return APP_GroupfunctionsDAO.Instance().GetByGroup(GROUP_ID);
    }

    public APP_GroupfunctionsInfo GetById(decimal FORM_FUNCTION_ID, decimal GROUP_ID)
    {
      return APP_GroupfunctionsDAO.Instance().GetById(FORM_FUNCTION_ID, GROUP_ID);
    }

    public void Insert(APP_GroupfunctionsInfo objInfo)
    {
      APP_GroupfunctionsDAO.Instance().Insert(objInfo);
    }

    public void Update(string Function_List, decimal GROUP_ID)
    {
      APP_GroupfunctionsDAO.Instance().Update(Function_List, GROUP_ID);
    }
  }
}