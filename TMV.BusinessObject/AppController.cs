using System.Data;
using TMV.DataAccess;

namespace TMV.BusinessObject
{
  public class AppController
  {
    #region "Constructor"
    private static AppController _instance;
    private static object _syncLock = new object();

    protected AppController()
    {
    }

    public static AppController Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new AppController();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public DataTable Table_ListField(string sTableName)
    {
      return AppHandler.Instance().Table_ListField(sTableName);
    }
    public object Table_GetFieldValue(string sTableName, string sFieldName, int iPKValue)
    {
      return AppHandler.Instance().Table_GetFieldValue(sTableName, sFieldName, iPKValue);
    }
    public DataTable DataErrorMessage_Get(string sErrType, string sErrObject)
    {
      return AppHandler.Instance().DataErrorMessage_Get(sErrType, sErrObject);
    }
  }
}