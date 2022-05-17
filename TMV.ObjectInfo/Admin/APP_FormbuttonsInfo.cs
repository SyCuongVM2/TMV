namespace TMV.ObjectInfo.Admin
{
  public class APP_FormbuttonsInfo
  {
    public string BUTTON_NAME { get; set; }
    public string BUTTON_TEXT { get; set; }
    public decimal FORM_BUTTON_ID { get; set; }
    public decimal FORM_ID { get; set; }
    public decimal FUNCTION_ID { get; set; }

    public APP_FormbuttonsInfo()
    {
    }

    public APP_FormbuttonsInfo(decimal FORM_BUTTON_ID, decimal FUNCTION_ID, decimal FORM_ID, string BUTTON_NAME, string BUTTON_TEXT)
    {
      this.FORM_BUTTON_ID = FORM_BUTTON_ID;
      this.FUNCTION_ID = FUNCTION_ID;
      this.FORM_ID = FORM_ID;
      this.BUTTON_NAME = BUTTON_NAME;
      this.BUTTON_TEXT = BUTTON_TEXT;
    }
  }
}