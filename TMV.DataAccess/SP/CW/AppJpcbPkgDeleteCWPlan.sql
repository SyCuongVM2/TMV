CREATE OR ALTER PROCEDURE AppJpcbPkgDeleteCWPlan
	@p_TenantId int,
	@p_Id bigint
AS
BEGIN
	BEGIN TRY
    BEGIN TRANSACTION

			delete from SrvPrgPlan where TenantId = @p_TenantId and Id = @p_Id

			select 'SUCCESS' as Status_Code, 
						'Delete Plan CW ' + cast(@p_Id as varchar) as Status_Message, 
						getdate() as Status_Time, 
						'AppJpcbPkgDeleteCWPlan' as Status_Note

    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
		select 'FAILURE' as Status_Code, 
					 ERROR_MESSAGE() as Status_Message, 
					 getdate() as Status_Time, 
					 'AppJpcbPkgDeleteCWPlan' as Status_Note

    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
		IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION
		
  END CATCH
END
