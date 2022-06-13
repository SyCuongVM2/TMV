CREATE OR ALTER PROCEDURE [AppAuthPkgUserChangePassword]
	@p_UserId nvarchar(50),
	@p_Password nvarchar(200)
AS
BEGIN
	set nocount on;

	update AbpUsers
	   set [Password] = @p_Password,
	       LastModificationTime = getdate(),
		   LastModifierUserId = @p_UserId
	 where Id = @p_UserId
END
