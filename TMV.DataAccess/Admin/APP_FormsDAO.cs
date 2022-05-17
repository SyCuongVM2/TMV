using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.Common;

namespace TMV.DataAccess.Admin
{
  public class APP_FormsDAO
  {
    #region "Constructor"
    private static APP_FormsDAO _instance;
    private static object _syncLock = new object();

    protected APP_FormsDAO()
    {
    }

    public static APP_FormsDAO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_FormsDAO();
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
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_FORMS_PKG_APP_FORMS_DELETE, new object[] { FORM_ID });
    }

    public DataSet GetAll()
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_FORMS_PKG_APP_FORMS_GETALL, new object[0]);
    }

    public APP_FormsInfo GetById(decimal FORM_ID)
    {
      return (APP_FormsInfo)CBO.FillObject(SqlDataAccess.ExecuteReader(SqlConnect.ConnectionString, Constants.Instance().APP_FORMS_PKG_APP_FORMS_GETBYID, new object[] { FORM_ID }), typeof(APP_FormsInfo));
    }

    public DataSet GetByMenuForm(string MENU_NAME, string FORM_NAME)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_FORMS_PKG_APP_FORMS_GETBYMENUFORM, new object[] {
                Globals.DB_GetNull(MENU_NAME),
                Globals.DB_GetNull(FORM_NAME)
            });
    }

    public void Insert(APP_FormsInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_FORMS_PKG_APP_FORMS_INSERT, new object[] {
                Globals.DB_GetNull(objInfo.FORM_NAME),
                Globals.DB_GetNull(objInfo.FORM_TEXT),
                Globals.DB_GetNull(objInfo.PARENT_NAME),
                Globals.DB_GetNull(objInfo.MENU_NAME),
                Globals.DB_GetNull(objInfo.MENU_TEXT)
            });
    }

    public void Update(APP_FormsInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_FORMS_PKG_APP_FORMS_UPDATE, new object[] {
                Globals.DB_GetNull(objInfo.FORM_ID),
                Globals.DB_GetNull(objInfo.FORM_NAME),
                Globals.DB_GetNull(objInfo.FORM_TEXT),
                Globals.DB_GetNull(objInfo.PARENT_NAME),
                Globals.DB_GetNull(objInfo.MENU_NAME),
                Globals.DB_GetNull(objInfo.MENU_TEXT)
            });
    }
  }
}