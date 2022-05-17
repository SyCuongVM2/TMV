using System.Data;
using TMV.ObjectInfo.Admin;
using TMV.DataAccess.Admin;

namespace TMV.BusinessObject.Admin
{
  public class APP_DomainBO
  {
    #region "Constructor"
    private static APP_DomainBO _instance;
    private static object _syncLock = new object();

    protected APP_DomainBO()
    {
    }

    public static APP_DomainBO Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new APP_DomainBO();
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
      APP_DomainDAO.Instance().Delete(DOMAIN_CODE, ITEM_CODE);
    }

    public DataSet GetAll()
    {
      return APP_DomainDAO.Instance().GetAll();
    }

    public DataTable GetByDomain(string domain)
    {
      return APP_DomainDAO.Instance().GetByDomain(domain);
    }

    public DataTable GetByDomainAndItem(string domain, string item_code)
    {
      return APP_DomainDAO.Instance().GetByDomainAndItem(domain, item_code);
    }

    public APP_DomainInfo GetById(string DOMAIN_CODE, string ITEM_CODE)
    {
      return APP_DomainDAO.Instance().GetById(DOMAIN_CODE, ITEM_CODE);
    }

    public DataTable Insert(APP_DomainInfo objInfo)
    {
      return APP_DomainDAO.Instance().Insert(objInfo);
    }

    public DataSet Search(string domain, string itemcode, string itemvalue)
    {
      return APP_DomainDAO.Instance().Search(domain, itemcode, itemvalue);
    }

    public void Update(APP_DomainInfo objInfo)
    {
      APP_DomainDAO.Instance().Update(objInfo);
    }

    public DataTable GetByLineAndUserID(string pLine, int pUserID)
    {
      return APP_DomainDAO.Instance().GetByLineAndUserID(pLine, pUserID);
    }
  }
}