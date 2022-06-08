CREATE PROCEDURE [AppAuthPkgUpdateFailedLogin]
	@p_TenantId int,
	@p_UserName nvarchar(50),
	@p_NumLoginFailed int
AS
BEGIN
	set nocount on;

	update AbpUsers
	   set NumLoginFailed = @p_NumLoginFailed
	 where TenantId = @p_TenantId
	   and upper(UserName) = upper(@p_UserName)
END