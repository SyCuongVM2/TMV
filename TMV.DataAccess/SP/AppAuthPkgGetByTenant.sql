CREATE OR ALTER PROCEDURE [AppAuthPkgGetByTenant]
	@p_TenantName NVARCHAR(40)
AS
BEGIN
	select * 
	  from AbpTenants 
	 where upper(TenancyName) = upper(@p_TenantName)
END