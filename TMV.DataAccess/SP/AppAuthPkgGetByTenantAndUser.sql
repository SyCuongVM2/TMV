CREATE PROCEDURE [AppAuthPkgGetByTenantAndUser]
	@p_TenantName nvarchar(50),
	@p_UserName nvarchar(50)
AS
BEGIN
	set nocount on;

	select u.CreationTime, u.CreatorUserId, u.LastModificationTime, u.LastModifierUserId, u.Id, TenantId, TitleId, 
	       [Password], UserName, UserCode, u.[Name], u.IsActive, u.IsDeleted, NumLoginFailed, EmailAddress,
		     t.TenantCode, t.TenancyName TenantAbbr, t.TenantNameVN TenantName
	   from AbpUsers u
left join AbpTenants t on u.TenantId = t.Id
	  where 
	   case 
	     when ((u.TenantId is null) and (upper(@p_TenantName) = 'TMV') and (upper(u.UserName) = upper(@p_UserName))) then 1
		 when ((upper(t.TenancyName) = upper(@p_TenantName)) and (upper(u.UserName) = upper(@p_UserName))) then 1
	     else 0
	   end = 1
END