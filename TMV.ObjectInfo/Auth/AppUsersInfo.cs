using System;

namespace TMV.ObjectInfo.Auth
{
  public class AppUsersInfo
  {
    public DateTime CreationTime { get; set; }
    public decimal CreatorUserId { get; set; }
    public DateTime LastModificationTime { get; set; }
    public decimal LastModifierUserId { get; set; }
    public decimal Id { get; set; }
    public int TenantId { get; set; }
    public int TitleId { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string UserCode { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public int NumLoginFailed { get; set; }
    public string EmailAddress { get; set; }
    public string TenantCode { get; set; }
    public string TenantAbbr { get; set; }
    public string TenantName { get; set; }
    public string TitleCode { get; set; }
    public string TitleName { get; set; }

    public AppUsersInfo()
    {
    }

    public AppUsersInfo(decimal User_Id, string Dealer_Code, string User_Name, string Full_Name, string User_Password)
    {
      Id = User_Id;
      TenantCode = Dealer_Code;
      UserName = User_Name;
      Name = Full_Name;
      Password = User_Password;
    }
  }
}