CREATE OR ALTER PROCEDURE AppJpcbPkgCWGoback
	@p_TenantId int,
	@p_UserId bigint,
	@p_Type varchar(2),
	@p_Id bigint
AS
BEGIN
	BEGIN TRY
    BEGIN TRANSACTION

			if @p_Type = 'AP'
				begin
					print 'Actual -> Plan'

					-- 1: Delete Actual
					update SrvPrgActual
					   set IsDeleted = 1,
						     DeletionTime = getdate(),
								 DeleterUserId = @p_UserId
					 where Id = @p_Id
					   and TenantId = @p_TenantId
						 and ActualState = 1 

					-- 2: Update Plan
					update SrvPrgPlan
					   set ActualId = null
					 where ActualId = @p_Id
					   and TenantId = @p_TenantId

					-- 3: Display message
					select 'SUCCESS' as Status_Code, 
						     'Update Actual to Plan for ' + cast(@p_Id as varchar) as Status_Message, 
								 getdate() as Status_Time, 
								 'AppJpcbPkgCWGoback' as Status_Note
				end
			else
			  begin
					print 'Finish Actual -> Start Actual'

					-- 1: update actual
					update SrvPrgActual
					   set ActualToTime = null,
						     ActualState = 1,
								 ActualCalcTime = null,
								 LastModifierUserId = @p_UserId,
								 LastModificationTime = getdate()
					 where Id = @p_Id
					   and TenantId = @p_TenantId

					-- 5: display message
					select 'SUCCESS' as Status_Code, 
						     'Update finish to start for actual ' + cast(@p_Id as varchar) as Status_Message, 
								 getdate() as Status_Time, 
								 'AppJpcbPkgCWGoback' as Status_Note
				end

    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
		select 'FAILURE' as Status_Code, 
					 ERROR_MESSAGE() as Status_Message, 
					 getdate() as Status_Time, 
					 'AppJpcbPkgCWGoback' as Status_Note

    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
		IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION
		
  END CATCH
END
