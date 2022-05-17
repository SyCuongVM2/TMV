using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.DataAccess.Admin;

namespace TMV.BusinessObject.Admin
{
  public class APP_FormbuttonsBO
  {
    #region "Constructor"
    private static APP_FormbuttonsBO _instance;
    private static object _syncLock = new object();

    protected APP_FormbuttonsBO()
    {
    }

    public static APP_FormbuttonsBO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_FormbuttonsBO();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public void Delete(decimal FORM_BUTTON_ID)
    {
      APP_FormbuttonsDAO.Instance().Delete(FORM_BUTTON_ID);
    }

    public DataSet GetAll()
    {
      return APP_FormbuttonsDAO.Instance().GetAll();
    }

    public APP_FormbuttonsInfo GetById(decimal FORM_BUTTON_ID)
    {
      return APP_FormbuttonsDAO.Instance().GetById(FORM_BUTTON_ID);
    }

    public void Insert(APP_FormbuttonsInfo objInfo)
    {
      APP_FormbuttonsDAO.Instance().Insert(objInfo);
    }

    public void Update(APP_FormbuttonsInfo objInfo)
    {
      APP_FormbuttonsDAO.Instance().Update(objInfo);
    }
  }
}