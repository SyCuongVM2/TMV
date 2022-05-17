using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.Common;

namespace TMV.DataAccess.Admin
{
  public class APP_UsergroupDAO
  {
    #region "Constructor"
    private static APP_UsergroupDAO _instance;
    private static object _syncLock = new object();

    protected APP_UsergroupDAO()
    {
    }

    public static APP_UsergroupDAO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_UsergroupDAO();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public void Delete(decimal USER_ID, decimal GROUP_ID)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_USERGROUP_PKG_APP_USERGROUP_DELETE, new object[] { USER_ID, GROUP_ID });
    }

    public DataSet GetAll()
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_USERGROUP_PKG_APP_USERGROUP_GETALL, new object[0]);
    }

    public DataSet GetByGroup(decimal GROUP_ID)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_USERGROUP_PKG_APP_USERGROUP_GETBYGROUP, new object[] {
                Globals.DB_GetNull(GROUP_ID)
            });
    }

    public APP_UsergroupInfo GetById(decimal USER_ID, decimal GROUP_ID)
    {
      return (APP_UsergroupInfo)CBO.FillObject(SqlDataAccess.ExecuteReader(SqlConnect.ConnectionString, Constants.Instance().APP_USERGROUP_PKG_APP_USERGROUP_GETBYID, new object[] { USER_ID, GROUP_ID }), typeof(APP_UsergroupInfo));
    }

    public DataSet GetByUser(decimal USER_ID)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_USERGROUP_PKG_APP_USERGROUP_GETBYUSER, new object[] { USER_ID });
    }

    public void Insert(APP_UsergroupInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_USERGROUP_PKG_APP_USERGROUP_INSERT, new object[] {
                Globals.DB_GetNull(objInfo.GROUP_ID)
            });
    }

    public void Update(decimal USER_ID, string Group_String)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_USERGROUP_PKG_APP_USERGROUP_UPDATE, new object[] {
                Globals.DB_GetNull(USER_ID),
                Globals.DB_GetNull(Group_String)
            });
    }
  }
}