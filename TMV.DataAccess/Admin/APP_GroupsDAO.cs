using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.Common;

namespace TMV.DataAccess.Admin
{
  public class APP_GroupsDAO
  {
    #region "Constructor"
    private static APP_GroupsDAO _instance;
    private static object _syncLock = new object();

    protected APP_GroupsDAO()
    {
    }

    public static APP_GroupsDAO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_GroupsDAO();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public void Delete(decimal GROUP_ID)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_GROUPS_PKG_APP_GROUPS_DELETE, new object[] { GROUP_ID });
    }

    public DataSet GetAll()
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_GROUPS_PKG_APP_GROUPS_GETALL, new object[0]);
    }

    public APP_GroupsInfo GetById(decimal GROUP_ID)
    {
      return (APP_GroupsInfo)CBO.FillObject(SqlDataAccess.ExecuteReader(SqlConnect.ConnectionString, Constants.Instance().APP_GROUPS_PKG_APP_GROUPS_GETBYID, new object[] { GROUP_ID }), typeof(APP_GroupsInfo));
    }

    public void Insert(APP_GroupsInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_GROUPS_PKG_APP_GROUPS_INSERT, new object[] {
                Globals.DB_GetNull(objInfo.GROUP_TEXT),
                Globals.DB_GetNull(objInfo.DISABLEAFTERFAILED),
                Globals.DB_GetNull(objInfo.PASSWORDCHANGEAFTER),
                Globals.DB_GetNull(objInfo.SENDEMAIL),
                Globals.DB_GetNull(objInfo.NOPASSWORDHISTORY)
            });
    }

    public void Update(APP_GroupsInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_GROUPS_PKG_APP_GROUPS_UPDATE, new object[] {
                Globals.DB_GetNull(objInfo.GROUP_ID),
                Globals.DB_GetNull(objInfo.GROUP_TEXT),
                Globals.DB_GetNull(objInfo.DISABLEAFTERFAILED),
                Globals.DB_GetNull(objInfo.PASSWORDCHANGEAFTER),
                Globals.DB_GetNull(objInfo.SENDEMAIL),
                Globals.DB_GetNull(objInfo.NOPASSWORDHISTORY)
            });
    }

    string APP_GROUPS_PKG_GETBYUSERID = "APP_GROUPS_PKG_GETBYUSERID";
    public DataTable GETBYUSERID(decimal pUserID)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString,
          APP_GROUPS_PKG_GETBYUSERID,
          new object[]{
                    Globals.DB_GetNull(pUserID)
          }).Tables[0];
    }
  }
}