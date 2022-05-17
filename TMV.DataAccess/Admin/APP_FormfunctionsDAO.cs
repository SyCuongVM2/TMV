using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.Common;

namespace TMV.DataAccess.Admin
{
  public class APP_FormfunctionsDAO
  {
    #region "Constructor"
    private static APP_FormfunctionsDAO _instance;
    private static object _syncLock = new object();

    protected APP_FormfunctionsDAO()
    {
    }

    public static APP_FormfunctionsDAO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_FormfunctionsDAO();
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
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_FORMFUNCTIONS_PKG_APP_FORMFUNCTIONS_DELETE, new object[] { FORM_FUNCTION_ID });
    }

    public DataSet GetAll()
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_FORMFUNCTIONS_PKG_APP_FORMFUNCTIONS_GETALL, new object[0]);
    }

    public APP_FormfunctionsInfo GetById(decimal FORM_FUNCTION_ID)
    {
      return (APP_FormfunctionsInfo)CBO.FillObject(SqlDataAccess.ExecuteReader(SqlConnect.ConnectionString, Constants.Instance().APP_FORMFUNCTIONS_PKG_APP_FORMFUNCTIONS_GETBYID, new object[] { FORM_FUNCTION_ID }), typeof(APP_FormfunctionsInfo));
    }

    public DataSet GetTree()
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_FORMFUNCTIONS_PKG_APP_FORMFUNCTIONS_GETTREE, new object[0]);
    }

    public void Insert(APP_FormfunctionsInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_FORMFUNCTIONS_PKG_APP_FORMFUNCTIONS_INSERT, new object[] {
                Globals.DB_GetNull(objInfo.FORM_ID),
                Globals.DB_GetNull(objInfo.FORM_FUNCTION_TEXT)
            });
    }

    public void InsertUpdateItem(string sMenuName, string sMenuText, string sParentForm, string sFormName, string sFormText, decimal FunctionID, string sFunctionText, string sButtonNameList, string sButtonTextList)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_FORMFUNCTIONS_PKG_APP_FORMFUNCTIONS_EDITITEM, new object[] {
                Globals.DB_GetNull(sMenuName),
                Globals.DB_GetNull(sMenuText),
                Globals.DB_GetNull(sParentForm),
                Globals.DB_GetNull(sFormName),
                Globals.DB_GetNull(sFormText),
                Globals.DB_GetNull(FunctionID),
                Globals.DB_GetNull(sFunctionText),
                Globals.DB_GetNull(sButtonNameList),
                Globals.DB_GetNull(sButtonTextList)
            });
    }

    public void Update(APP_FormfunctionsInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_FORMFUNCTIONS_PKG_APP_FORMFUNCTIONS_UPDATE, new object[] {
                Globals.DB_GetNull(objInfo.FORM_FUNCTION_ID),
                Globals.DB_GetNull(objInfo.FORM_ID),
                Globals.DB_GetNull(objInfo.FORM_FUNCTION_TEXT)
            });
    }
  }
}