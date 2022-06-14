CREATE OR ALTER PROCEDURE AppJpcbPkgStartFinishCW
	@p_UserId bigint,
	@p_Type varchar(1),
	@p_Id bigint
AS
BEGIN
	BEGIN TRY
    BEGIN TRANSACTION

			if @p_Type = 'S'
				begin
					 print 'Start CW'

					 declare @v_New_Actual_Id bigint

				   -- 1: Insert into Actual
					 insert into SrvPrgActual(WaitId, AppointmentId, CustomerVisitId, ROId, ROType, VehicleId, CustomerId, WorkshopId, QCLevel, 
					                          IsCustomerWait, IsCarWash, IsTakeParts, IsPriority,
																		ActualFromTime, ActualState, 
																		CreatorUserId, CreationTime)
														 select WaitId, AppointmentId, CustomerVisitId, ROId, ROType, VehicleId, CustomerId, WorkshopId, QCLevel, 
					                          IsCustomerWait, IsCarWash, IsTakeParts, IsPriority,
																		getdate(), 1,
																		@p_UserId, getdate()
														   from SrvPrgPlan
														  where Id = @p_Id

					 -- 2: Get new actual Id
					 select @v_New_Actual_Id = scope_identity() -- Lay Id vua insert

					 -- 3: Update new actual Id to Plan
					 update SrvPrgPlan
					    set ActualId = @v_New_Actual_Id,
							    LastModifierUserId = @p_UserId,
									LastModificationTime = getdate()
						where Id = @p_Id

						-- 4: display message
						select 'SUCCESS' as Status_Code, 
						       'Insert new actual ' & @v_New_Actual_Id as Status_Message, 
									 getdate() as Status_Time, 
									 'AppJpcbPkgStartFinishCW' as Status_Note
				end
			else 
				begin
					print 'Finish CW'

					-- 1: update finish to actual
					update SrvPrgActual
					   set ActualToTime = getdate(),
						     ActualState = 4,
								 LastModifierUserId = @p_UserId,
								 LastModificationTime = getdate()
					 where Id = @p_Id

					-- 4: display message
					select 'SUCCESS' as Status_Code, 
						     'Update finish to actual ' & @p_Id as Status_Message, 
								 getdate() as Status_Time, 
								 'AppJpcbPkgStartFinishCW' as Status_Note
				end

    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
		select 'FAILURE' as Status_Code, 
					 ERROR_MESSAGE() as Status_Message, 
					 getdate() as Status_Time, 
					 'AppJpcbPkgStartFinishCW' as Status_Note

    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
		IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION
		
  END CATCH
END
GO
