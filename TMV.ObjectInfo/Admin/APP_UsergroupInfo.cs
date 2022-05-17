namespace TMV.ObjectInfo.Admin
{
  public class APP_UsergroupInfo
  {
    public decimal GROUP_ID { get; set; }
    public decimal USER_ID { get; set; }

    public APP_UsergroupInfo()
    {
    }

    public APP_UsergroupInfo(decimal USER_ID, decimal GROUP_ID)
    {
      this.USER_ID = USER_ID;
      this.GROUP_ID = GROUP_ID;
    }
  }
}