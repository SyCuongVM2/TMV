namespace TMV.ObjectInfo.Admin
{
  public class APP_GroupfunctionsInfo
  {
    public decimal FORM_FUNCTION_ID { get; set; }
    public decimal GROUP_ID { get; set; }

    public APP_GroupfunctionsInfo()
    {
    }

    public APP_GroupfunctionsInfo(decimal FORM_FUNCTION_ID, decimal GROUP_ID)
    {
      this.FORM_FUNCTION_ID = FORM_FUNCTION_ID;
      this.GROUP_ID = GROUP_ID;
    }
  }
}