CREATE OR ALTER PROCEDURE AppJpcbPkgStartFinishCW
	@p_UserId bigint,
	@p_TenantId int,
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
																		ActualFromTime, 
																		ActualState, PlanId, TenantId,
																		CreatorUserId, CreationTime, IsDeleted)
														 select WaitId, AppointmentId, CustomerVisitId, ROId, ROType, VehicleId, CustomerId, WorkshopId, QCLevel, 
					                          IsCustomerWait, IsCarWash, IsTakeParts, IsPriority,
																		(case 
																			when PlanFromTime < getdate() then PlanFromTime
																			else getdate()
																		end), 
																		1, @p_Id, @p_TenantId,
																		@p_UserId, getdate(), 0
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
						       'Insert new actual ' + cast(@v_New_Actual_Id as varchar) as Status_Message, 
									 getdate() as Status_Time, 
									 'AppJpcbPkgStartFinishCW' as Status_Note
				end
			else 
				begin
					print 'Finish CW'

					declare @v_PlanId bigint
					declare @v_ActualFromTime datetime
					declare @v_PlanToTime datetime
					declare @v_FinishTime datetime

					-- 1: get info from actual
					select @v_PlanId = PlanId,
					       @v_ActualFromTime = ActualFromTime
					  from SrvPrgActual
					 where Id = @p_Id
					 
					-- 2: get plan time
					select @v_PlanToTime = PlanToTime
					  from SrvPrgPlan 
					 where Id = @v_PlanId
					if (@v_PlanToTime is not null)
						begin
							if (@v_PlanToTime < getdate())
								if (@v_ActualFromTime > @v_PlanToTime and @v_ActualFromTime < getdate())
									set @v_FinishTime = getdate()
								else 
									set @v_FinishTime = @v_PlanToTime
							else
								set @v_FinishTime = getdate()
						end

					-- 1: update finish to actual
					update SrvPrgActual
					   set ActualToTime = @v_FinishTime,
						     ActualState = 4,
								 LastModifierUserId = @p_UserId,
								 LastModificationTime = getdate()
					 where Id = @p_Id

					-- 4: display message
					select 'SUCCESS' as Status_Code, 
						     'Update finish to actual ' + cast(@p_Id as varchar) as Status_Message, 
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