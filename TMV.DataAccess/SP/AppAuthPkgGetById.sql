CREATE PROCEDURE [AppAuthPkgGetById]
	@p_UserId INT
AS
BEGIN
	set nocount on;

	 select u.CreationTime, u.CreatorUserId, u.LastModificationTime, u.LastModifierUserId, u.Id, TenantId, TitleId, 
	        [Password], UserName, UserCode, u.[Name], u.IsActive, u.IsDeleted, NumLoginFailed, EmailAddress,
		      t.TenantCode, t.TenancyName TenantAbbr, t.TenancyName TenantName, m.TitleCode, m.TitleName
	   from AbpUsers u
left join AbpTenants t on u.TenantId = t.Id
left join MstSrvTitle m on u.TitleId = m.Id
	  where u.Id = @p_UserId;
END