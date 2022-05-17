namespace TMV.ObjectInfo.Admin
{
  public class APP_FormsInfo
  {
    public decimal FORM_ID { get; set; }
    public string FORM_NAME { get; set; }
    public string FORM_TEXT { get; set; }
    public string MENU_NAME { get; set; }
    public string MENU_TEXT { get; set; }
    public string PARENT_NAME { get; set; }

    public APP_FormsInfo()
    {
    }

    public APP_FormsInfo(decimal FORM_ID, string FORM_NAME, string FORM_TEXT, string PARENT_NAME, string MENU_NAME, string MENU_TEXT)
    {
      this.FORM_ID = FORM_ID;
      this.FORM_NAME = FORM_NAME;
      this.FORM_TEXT = FORM_TEXT;
      this.PARENT_NAME = PARENT_NAME;
      this.MENU_NAME = MENU_NAME;
      this.MENU_TEXT = MENU_TEXT;
    }
  }
}