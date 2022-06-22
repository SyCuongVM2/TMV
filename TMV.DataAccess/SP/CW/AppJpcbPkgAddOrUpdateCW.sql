CREATE OR ALTER PROCEDURE AppJpcbPkgAddOrUpdateCW
	@p_UserId bigint,
	@p_TenantId int,
	@p_Type varchar(1), -- N: New, U: Update
	@p_RegisterNo nvarchar(50),
	@p_WorkshopId int,
	@p_PlanFromTime datetime,
	@p_PlanToTime datetime,
	@p_PlanCalcTime int,
	@p_Id bigint = null
AS
BEGIN
	BEGIN TRY
    BEGIN TRANSACTION

			if @p_Type = 'N'
				begin
					 print 'Add New Plan CW'

					 declare @v_New_Plan_Id bigint

				   -- 1: Insert into Actual
					 insert into SrvPrgPlan(ROType, WorkshopId,
																	PlanFromTime, PlanToTime, PlanCalcTime, PlanState,
																	TenantId,	CreatorUserId, CreationTime, IsDeleted)
											     values(3, @p_WorkshopId,
													        @p_PlanFromTime, @p_PlanToTime, @p_PlanCalcTime, 5,
																	@p_TenantId, @p_UserId, getdate(), 0)

					 -- 2: Get new actual Id
					 select @v_New_Plan_Id = scope_identity() -- Lay Id vua insert

						-- 4: display message
						select 'SUCCESS' as Status_Code, 
						       'Add New Plan CW ' + cast(@v_New_Plan_Id as varchar) as Status_Message, 
									 getdate() as Status_Time, 
									 'AppJpcbPkgAddOrUpdateCW' as Status_Note
				end
			else 
				begin
					print 'Update Plan CW'

					declare @v_calc_time int = [dbo].[CalcWorkingTime](@p_TenantId, @p_PlanFromTime, @p_PlanToTime)

					-- 1: update plan
					update SrvPrgPlan
					   set PlanFromTime = @p_PlanFromTime,
						     PlanToTime = @p_PlanToTime,
								 PlanCalcTime = (
									case 
										when @p_PlanCalcTime != @v_calc_time then @v_calc_time
										else @p_PlanCalcTime
									end
								 ),
								 WorkshopId = @p_WorkshopId,
								 LastModifierUserId = @p_UserId,
								 LastModificationTime = getdate()
					 where Id = @p_Id

					-- 2: display message
					select 'SUCCESS' as Status_Code, 
						     'Update Plan CW ' + cast(@p_Id as varchar) as Status_Message, 
								 getdate() as Status_Time, 
								 'AppJpcbPkgAddOrUpdateCW' as Status_Note
				end

    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
		select 'FAILURE' as Status_Code, 
					 ERROR_MESSAGE() as Status_Message, 
					 getdate() as Status_Time, 
					 'AppJpcbPkgAddOrUpdateCW' as Status_Note

    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
		IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION
		
  END CATCH
END