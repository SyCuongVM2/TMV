using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.Common;

namespace TMV.DataAccess.Admin
{
  public class APP_GroupfunctionsDAO
  {
    #region "Constructor"
    private static APP_GroupfunctionsDAO _instance;
    private static object _syncLock = new object();

    protected APP_GroupfunctionsDAO()
    {
    }

    public static APP_GroupfunctionsDAO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_GroupfunctionsDAO();
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
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_GROUPFUNCTIONS_PKG_APP_GROUPFUNCTIONS_DELETE, new object[] {
                FORM_FUNCTION_ID,
                GROUP_ID
            });
    }

    public DataSet GetAll()
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_GROUPFUNCTIONS_PKG_APP_GROUPFUNCTIONS_GETALL, new object[0]);
    }

    public DataSet GetByGroup(decimal GROUP_ID)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_GROUPFUNCTIONS_PKG_APP_GROUPFUNCTIONS_GETBYGROUP, new object[] {
                Globals.DB_GetNull(GROUP_ID)
            });
    }

    public APP_GroupfunctionsInfo GetById(decimal FORM_FUNCTION_ID, decimal GROUP_ID)
    {
      return (APP_GroupfunctionsInfo)CBO.FillObject(SqlDataAccess.ExecuteReader(SqlConnect.ConnectionString, Constants.Instance().APP_GROUPFUNCTIONS_PKG_APP_GROUPFUNCTIONS_GETBYID, new object[] { FORM_FUNCTION_ID, GROUP_ID }), typeof(APP_GroupfunctionsInfo));
    }

    public void Insert(APP_GroupfunctionsInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_GROUPFUNCTIONS_PKG_APP_GROUPFUNCTIONS_INSERT, new object[] {
                Globals.DB_GetNull(objInfo.GROUP_ID)
            });
    }

    public void Update(string Function_List, decimal GROUP_ID)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_GROUPFUNCTIONS_PKG_APP_GROUPFUNCTIONS_UPDATE, new object[] {
                Globals.DB_GetNull(Function_List),
                Globals.DB_GetNull(GROUP_ID)
            });
    }
  }
}