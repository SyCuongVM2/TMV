using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.DataAccess.Admin;

namespace TMV.BusinessObject.Admin
{
  public class APP_FormfunctionsBO
  {
    #region "Constructor"
    private static APP_FormfunctionsBO _instance;
    private static object _syncLock = new object();

    protected APP_FormfunctionsBO()
    {
    }

    public static APP_FormfunctionsBO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_FormfunctionsBO();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public void Delete(decimal FORM_FUNCTION_ID)
    {
      APP_FormfunctionsDAO.Instance().Delete(FORM_FUNCTION_ID);
    }

    public DataSet GetAll()
    {
      return APP_FormfunctionsDAO.Instance().GetAll();
    }

    public APP_FormfunctionsInfo GetById(decimal FORM_FUNCTION_ID)
    {
      return APP_FormfunctionsDAO.Instance().GetById(FORM_FUNCTION_ID);
    }

    public DataSet GetTree()
    {
      return APP_FormfunctionsDAO.Instance().GetTree();
    }

    public void Insert(APP_FormfunctionsInfo objInfo)
    {
      APP_FormfunctionsDAO.Instance().Insert(objInfo);
    }

    public void InsertUpdateItem(string sMenuName, string sMenuText, string sParentForm, string sFormName, string sFormText, decimal FunctionID, string sFunctionText, string sButtonNameList, string sButtonTextList)
    {
      APP_FormfunctionsDAO.Instance().InsertUpdateItem(sMenuName, sMenuText, sParentForm, sFormName, sFormText, FunctionID, sFunctionText, sButtonNameList, sButtonTextList);
    }

    public void Update(APP_FormfunctionsInfo objInfo)
    {
      APP_FormfunctionsDAO.Instance().Update(objInfo);
    }
  }
}