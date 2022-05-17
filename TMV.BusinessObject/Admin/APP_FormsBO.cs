using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.DataAccess.Admin;

namespace TMV.BusinessObject.Admin
{
  public class APP_FormsBO
  {
    #region "Constructor"
    private static APP_FormsBO _instance;
    private static object _syncLock = new object();

    protected APP_FormsBO()
    {
    }

    public static APP_FormsBO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_FormsBO();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public void Delete(decimal FORM_ID)
    {
      APP_FormsDAO.Instance().Delete(FORM_ID);
    }

    public DataSet GetAll()
    {
      return APP_FormsDAO.Instance().GetAll();
    }

    public APP_FormsInfo GetById(decimal FORM_ID)
    {
      return APP_FormsDAO.Instance().GetById(FORM_ID);
    }

    public DataSet GetByMenuForm(string Menu_Name, string Form_Name)
    {
      return APP_FormsDAO.Instance().GetByMenuForm(Menu_Name, Form_Name);
    }

    public void Insert(APP_FormsInfo objInfo)
    {
      APP_FormsDAO.Instance().Insert(objInfo);
    }

    public void Update(APP_FormsInfo objInfo)
    {
      APP_FormsDAO.Instance().Update(objInfo);
    }
  }
}