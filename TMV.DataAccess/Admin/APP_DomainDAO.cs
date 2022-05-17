using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.Common;

namespace TMV.DataAccess.Admin
{
  public class APP_DomainDAO
  {
    #region "Constructor"
    private static APP_DomainDAO _instance;
    private static object _syncLock = new object();

    protected APP_DomainDAO()
    {
    }

    public static APP_DomainDAO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_DomainDAO();
        }
      }
      return _instance;
    }

    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    public void Delete(string DOMAIN_CODE, string ITEM_CODE)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_DOMAIN_PKG_APP_MASTER_DOMAIN_DELETE, new object[] { DOMAIN_CODE, ITEM_CODE });
    }

    public DataSet GetAll()
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_DOMAIN_PKG_APP_MASTER_DOMAIN_GETALL, new object[0]);
    }

    public DataTable GetByDomain(string domain)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_DOMAIN_PKG_APP_MASTER_DOMAIN_GETBYDOMAIN, new object[] {
                Globals.DB_GetNull(domain)
            }).Tables[0];
    }

    public DataTable GetByDomainAndItem(string domain, string item_code)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_DOMAIN_PKG_APP_MASTER_DOMAIN_GETBYITEM, new object[] {
                Globals.DB_GetNull(domain),
                Globals.DB_GetNull(item_code)
            }).Tables[0];
    }

    public APP_DomainInfo GetById(string DOMAIN_CODE, string ITEM_CODE)
    {
      return (APP_DomainInfo)CBO.FillObject(SqlDataAccess.ExecuteReader(SqlConnect.ConnectionString, Constants.Instance().APP_DOMAIN_PKG_APP_MASTER_DOMAIN_GETBYID, new object[] { DOMAIN_CODE, ITEM_CODE }), typeof(APP_DomainInfo));
    }

    public DataTable Insert(APP_DomainInfo objInfo)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_DOMAIN_PKG_APP_MASTER_DOMAIN_INSERT, new object[] {
                Globals.DB_GetNull(objInfo.DOMAIN_CODE),
                Globals.DB_GetNull(objInfo.ITEM_CODE),
                Globals.DB_GetNull(objInfo.ITEM_VALUE),
                Globals.DB_GetNull(objInfo.ITEM_ORDER),
                Globals.DB_GetNull(objInfo.DESCRIPTION)
            }).Tables[0];
    }

    public DataSet Search(string domain, string itemcode, string itemvalue)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, Constants.Instance().APP_DOMAIN_PKG_APP_MASTER_DOMAIN_SEARCH, new object[] {
                Globals.DB_GetNull(domain),
                Globals.DB_GetNull(itemcode),
                Globals.DB_GetNull(itemvalue)
            });
    }

    public void Update(APP_DomainInfo objInfo)
    {
      SqlDataAccess.ExecuteNonQuery(SqlConnect.ConnectionString, Constants.Instance().APP_DOMAIN_PKG_APP_MASTER_DOMAIN_UPDATE, new object[] {
                Globals.DB_GetNull(objInfo.DOMAIN_CODE),
                Globals.DB_GetNull(objInfo.ITEM_CODE),
                Globals.DB_GetNull(objInfo.ITEM_VALUE),
                Globals.DB_GetNull(objInfo.ITEM_ORDER),
                Globals.DB_GetNull(objInfo.DESCRIPTION)
            });
    }

    string APP_MASTER_DOMAIN_PKG_GETBYLINEANDUSERID = "APP_MASTER_DOMAIN_PKG_GETBYLINEANDUSERID";
    public DataTable GetByLineAndUserID(string pLine, int pUserID)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString,
              APP_MASTER_DOMAIN_PKG_GETBYLINEANDUSERID,
              new object[]{
                    Globals.DB_GetNull(pLine),
                    Globals.DB_GetNull(pUserID)
      }).Tables[0];
    }
  }
}