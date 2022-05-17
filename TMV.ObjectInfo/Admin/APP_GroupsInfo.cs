namespace TMV.ObjectInfo.Admin
{
  public class APP_GroupsInfo
  {
    public decimal DISABLEAFTERFAILED { get; set; }
    public decimal GROUP_ID { get; set; }
    public string GROUP_TEXT { get; set; }
    public decimal NOPASSWORDHISTORY { get; set; }
    public decimal PASSWORDCHANGEAFTER { get; set; }
    public decimal SENDEMAIL { get; set; }

    public APP_GroupsInfo()
    {
    }

    public APP_GroupsInfo(decimal GROUP_ID, string GROUP_TEXT)
    {
      this.GROUP_ID = GROUP_ID;
      this.GROUP_TEXT = GROUP_TEXT;
    }
  }
}