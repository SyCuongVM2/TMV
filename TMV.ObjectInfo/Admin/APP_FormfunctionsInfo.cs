namespace TMV.ObjectInfo.Admin
{
  public class APP_FormfunctionsInfo
  {
    public decimal FORM_FUNCTION_ID { get; set; }
    public string FORM_FUNCTION_TEXT { get; set; }
    public decimal FORM_ID { get; set; }

    public APP_FormfunctionsInfo()
    {
    }

    public APP_FormfunctionsInfo(decimal FORM_FUNCTION_ID, decimal FORM_ID, string FORM_FUNCTION_TEXT)
    {
      this.FORM_FUNCTION_ID = FORM_FUNCTION_ID;
      this.FORM_ID = FORM_ID;
      this.FORM_FUNCTION_TEXT = FORM_FUNCTION_TEXT;
    }
  }
}