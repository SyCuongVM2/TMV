using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.Common;

namespace TMV.DataAccess.Admin
{
  public class APP_FormbuttonsDAO
  {
    #region "Constructor"
    private static APP_FormbuttonsDAO _instance;
    private static object _syncLock = new object();

    protected APP_FormbuttonsDAO()
    {
    }

    public static APP_FormbuttonsDAO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_FormbuttonsDAO();
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
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_FORMBUTTONS_PKG_APP_FORMBUTTONS_DELETE, new object[] { FORM_BUTTON_ID });
    }

    public DataSet GetAll()
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_FORMBUTTONS_PKG_APP_FORMBUTTONS_GETALL, new object[0]);
    }

    public APP_FormbuttonsInfo GetById(decimal FORM_BUTTON_ID)
    {
      return (APP_FormbuttonsInfo)CBO.FillObject(SqlDataAccess.ExecuteReader(SqlConnect.ConnectionString, Constants.Instance().APP_FORMBUTTONS_PKG_APP_FORMBUTTONS_GETBYID, new object[] { FORM_BUTTON_ID }), typeof(APP_FormbuttonsInfo));
    }

    public void Insert(APP_FormbuttonsInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_FORMBUTTONS_PKG_APP_FORMBUTTONS_INSERT, new object[] {
                Globals.DB_GetNull(objInfo.FUNCTION_ID),
                Globals.DB_GetNull(objInfo.FORM_ID),
                Globals.DB_GetNull(objInfo.BUTTON_NAME),
                Globals.DB_GetNull(objInfo.BUTTON_TEXT)
            });
    }

    public void Update(APP_FormbuttonsInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_FORMBUTTONS_PKG_APP_FORMBUTTONS_UPDATE, new object[] {
                Globals.DB_GetNull(objInfo.FORM_BUTTON_ID),
                Globals.DB_GetNull(objInfo.FUNCTION_ID),
                Globals.DB_GetNull(objInfo.FORM_ID),
                Globals.DB_GetNull(objInfo.BUTTON_NAME),
                Globals.DB_GetNull(objInfo.BUTTON_TEXT)
            });
    }
  }
}