namespace TMV.ObjectInfo.Admin
{
  public class APP_DomainInfo
  {
    public string DOMAIN_CODE { get; set; }
    public string ITEM_CODE { get; set; }
    public string ITEM_ORDER { get; set; }
    public string ITEM_VALUE { get; set; }
    public string DESCRIPTION { get; set; }

    public APP_DomainInfo()
    {
    }

    public APP_DomainInfo(string DOMAIN_CODE, string ITEM_CODE, string ITEM_VALUE, string ITEM_ORDER, string DESCRIPTION)
    {
      this.DOMAIN_CODE = DOMAIN_CODE;
      this.ITEM_CODE = ITEM_CODE;
      this.ITEM_VALUE = ITEM_VALUE;
      this.ITEM_ORDER = ITEM_ORDER;
      this.DESCRIPTION = DESCRIPTION;
    }
  }
}