CREATE OR ALTER FUNCTION CalcWorkingTime
(
	@p_Tenant_Id int,
	@p_FromTime datetime,
	@p_ToTime datetime
)
RETURNS int
AS
BEGIN
	if (@p_FromTime is null or @p_ToTime is null or @p_FromTime >= @p_ToTime)
    return 0

	declare @v_Count int
	declare @v_Count_Calendar int
	declare @v_MinutesDiff int = 0
	declare @v_StartDateAsDate datetime = cast(@p_FromTime as date)
  declare @v_EndDateAsDate datetime = cast(@p_ToTime as date)

  declare @v_FullDays int = 0
  declare @v_Holidays int = 0
  declare @v_MinWorking int = 0

	declare @v_wk_AM_From datetime
  declare @v_wk_AM_To datetime
  declare @v_wk_PM_From datetime
  declare @v_wk_PM_To datetime
  declare @v_rest_AM_From datetime
  declare @v_rest_AM_To datetime
  declare @v_rest_PM_From datetime
  declare @v_rest_PM_To datetime

	select @v_Count = count(1)
	  from MstSrvDlrConfig
	 where TenantId = @p_Tenant_Id
	   and cast(EffDateFrom as date) <= cast(@p_FromTime as date)
	   and cast(EffDateTo as date) >= cast(@p_ToTime as date)
	if (@v_Count > 0)
		begin
			select @v_wk_AM_From = WkAmFrom,
						 @v_wk_AM_To = WkAmTo,
						 @v_wk_PM_From = WkPmFrom,
						 @v_wk_PM_To = WkPmTo,
						 @v_rest_AM_From = RestAmFrom,
						 @v_rest_AM_To = RestAmTo,
						 @v_rest_PM_From = RestPmFrom,
						 @v_rest_PM_To = RestPmTo
				from MstSrvDlrConfig
			 where TenantId = @p_Tenant_Id
	       and cast(EffDateFrom as date) <= cast(@p_FromTime as date)
	       and cast(EffDateTo as date) >= cast(@p_ToTime as date)

			if (@v_StartDateAsDate = @v_EndDateAsDate)
				begin
					
					-- we are in the same day so let's calculate just for the same day difference in minutes
					set @v_MinutesDiff = datediff(minute, @p_FromTime, @p_ToTime)

					-- if start early
					if (cast(@p_FromTime as time) < cast(@v_wk_AM_From as time))
						set @v_MinutesDiff = @v_MinutesDiff + datediff(minute, cast(@p_FromTime as time), cast(@v_wk_AM_From as time));

					-- AM break time, if any
					if (@v_rest_AM_From is not null and @v_rest_AM_To is not null)
						begin 
							if (cast(@p_FromTime as time) <= cast(@v_rest_AM_From as time) and cast(@p_ToTime as time) >= cast(@v_rest_AM_To as time))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_rest_AM_From as time), cast(@v_rest_AM_To as time));
						end

					-- Lunch time
					if (@v_wk_AM_To is not null and cast(@p_FromTime as time) <= cast(@v_wk_AM_To as time) and cast(@p_ToTime as time) >= cast(@v_wk_AM_To as time))
						set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_wk_AM_To as time), cast(@v_wk_PM_From as time));

					-- PM break time, if any
					if (@v_rest_PM_From is not null and @v_rest_PM_To is not null)
						begin 
							if (cast(@p_FromTime as time) <= cast(@v_rest_PM_From as time) and cast(@p_ToTime as time) >= cast(@v_rest_PM_To as time))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_rest_PM_From as time), cast(@v_rest_PM_To as time));
						end

					-- if finish late
					if (cast(@p_ToTime as time) > cast(@v_wk_PM_To as time))
						set @v_MinutesDiff = @v_MinutesDiff + datediff(minute, cast(@v_wk_PM_To as time), cast(@p_ToTime as time));
				end
			else
				begin
					-- take difference from start to the end of the day
					if (@p_FromTime < dateadd(minute, datepart(hour, @v_wk_PM_To) * 60 + datepart(minute, @v_wk_PM_To), @v_StartDateAsDate)) --since we work till @WK_PM_TO
						set @v_MinutesDiff = datediff(minute, @p_FromTime, dateadd(minute, datepart(hour, @v_wk_PM_To) * 60 + datepart(minute, @v_wk_PM_To), @v_StartDateAsDate))

					-- LET'S TAKE AWAY ANY BREAKS OR LUNCHES OUT --
          -- AM break time, if any
					if (@v_rest_AM_From is not null and @v_rest_AM_To is not null)
						begin
							if (@p_FromTime < dateadd(minute, datepart(hour, @v_rest_AM_From) * 60 + datepart(minute, @v_rest_AM_From), @v_StartDateAsDate))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_rest_AM_From as time), cast(@v_rest_AM_To as time))
						end

					-- Lunch time
					if (@v_wk_AM_To is not null and @v_wk_PM_From is not null)
						begin
							if (@p_FromTime < dateadd(minute, datepart(hour, @v_wk_AM_To) * 60 + datepart(minute, @v_wk_AM_To), @v_StartDateAsDate))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_wk_AM_To as time), cast(@v_wk_PM_From as time))
						end

					-- PM break time, if any
					if (@v_rest_PM_From is not null and @v_rest_PM_To is not null)
						begin
							if (@p_FromTime < dateadd(minute, datepart(hour, @v_rest_PM_From) * 60 + datepart(minute, @v_rest_PM_From), @v_StartDateAsDate))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_rest_PM_From as time), cast(@v_rest_PM_To as time))
						end

					-- let's get the number of whole days between the 2 specified dates
					while (@v_StartDateAsDate < dateadd(day, -1, @v_EndDateAsDate))
						begin
							select @v_Count_Calendar = count(1)
							  from MstSrvDlrCalendar
							 where TenantId = @p_Tenant_Id
							if @v_Count_Calendar > 0
								begin
									declare @v_temp int
									select @v_temp = count(1)
									  from MstSrvDlrCalendar
									 where TenantId = @p_Tenant_Id
									   and ValueDate = @v_StartDateAsDate
									if (@v_temp = 0)
										set @v_FullDays = @v_FullDays + 1
								end
							else 
								set @v_FullDays = @v_FullDays + 1

							set @v_StartDateAsDate = dateadd(day, 1, @v_StartDateAsDate)
						end

					-- important reset the start date
					set @v_StartDateAsDate = cast(@p_FromTime as date)

					-- Calculate total working time in minutes per day --
					set @v_MinWorking = datediff(minute, cast(@v_wk_AM_From as time), cast(@v_wk_PM_To as time))
					-- AM Break
					if (@v_rest_AM_From is not null and @v_rest_AM_To is not null)
						set @v_MinWorking = @v_MinWorking - datediff(minute, cast(@v_rest_AM_From as time), cast(@v_rest_AM_To as time))
					-- Lunch
					if (@v_wk_AM_To is not null and @v_wk_PM_From is not null)
						set @v_MinWorking = @v_MinWorking - datediff(minute, cast(@v_wk_AM_To as time), cast(@v_wk_PM_From as time))
					-- PM Break
					if (@v_rest_PM_From is not null and @v_rest_PM_To is not null)
						set @v_MinWorking = @v_MinWorking - datediff(minute, cast(@v_rest_PM_From as time), cast(@v_rest_PM_To as time))

					select @v_Holidays = count(1)
					  from MstSrvDlrCalendar
					 where TenantId = @p_Tenant_Id
					   and ValueDate >= @v_StartDateAsDate
						 and ValueDate <= @v_EndDateAsDate
					set @v_MinutesDiff = @v_MinutesDiff + ((@v_FullDays - @v_Holidays) * @v_MinWorking)

					-- finally get the last day of the transaction
					if (@p_ToTime > dateadd(minute, datepart(hour, @v_wk_AM_From) * 60 + datepart(minute, @v_wk_AM_From), @v_EndDateAsDate))
						set @v_MinutesDiff = @v_MinutesDiff + datediff(minute, dateadd(minute, datepart(hour, @v_wk_AM_From) * 60 + datepart(minute, @v_wk_AM_From), @v_EndDateAsDate), @p_ToTime)

					-- take away any breaks or lunches out
					if (@v_rest_AM_From is not null and @v_rest_AM_To is not null)
						begin
							if (@p_ToTime >= dateadd(minute, datepart(hour, @v_rest_AM_From) * 60 + datepart(minute, @v_rest_AM_From), @v_EndDateAsDate))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_rest_AM_From as time), cast(@v_rest_AM_To as time))
						end
					if (@v_wk_AM_To is not null and @v_wk_PM_From is not null)
						begin
							if (@p_ToTime >= dateadd(minute, datepart(hour, @v_wk_AM_To) * 60 + datepart(minute, @v_wk_AM_To), @v_EndDateAsDate))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_wk_AM_To as time), cast(@v_wk_PM_From as time))
						end
					if (@v_rest_PM_From is not null and @v_rest_PM_To is not null)
						begin
							if (@p_ToTime >= dateadd(minute, datepart(hour, @v_rest_PM_From) * 60 + datepart(minute, @v_rest_PM_From), @v_EndDateAsDate))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_rest_PM_From as time), cast(@v_rest_PM_To as time))
						end
				end
		end

	return @v_MinutesDiff

END
GO


CREATE OR ALTER PROCEDURE CalcWorkingTime
(
	@p_Tenant_Id int,
	@p_FromTime datetime,
	@p_ToTime datetime
)
AS
BEGIN
	declare @v_Count int
	declare @v_Count_Calendar int
	declare @v_MinutesDiff int = 0
	declare @v_StartDateAsDate datetime = cast(@p_FromTime as date)
  declare @v_EndDateAsDate datetime = cast(@p_ToTime as date)

  declare @v_FullDays int = 0
  declare @v_Holidays int = 0
  declare @v_MinWorking int = 0

	declare @v_wk_AM_From datetime
  declare @v_wk_AM_To datetime
  declare @v_wk_PM_From datetime
  declare @v_wk_PM_To datetime
  declare @v_rest_AM_From datetime
  declare @v_rest_AM_To datetime
  declare @v_rest_PM_From datetime
  declare @v_rest_PM_To datetime

	select @v_Count = count(1)
	  from MstSrvDlrConfig
	 where TenantId = @p_Tenant_Id
	   and cast(EffDateFrom as date) <= cast(@p_FromTime as date)
	   and cast(EffDateTo as date) >= cast(@p_ToTime as date)
	if (@v_Count > 0)
		begin
			select @v_wk_AM_From = WkAmFrom,
						 @v_wk_AM_To = WkAmTo,
						 @v_wk_PM_From = WkPmFrom,
						 @v_wk_PM_To = WkPmTo,
						 @v_rest_AM_From = RestAmFrom,
						 @v_rest_AM_To = RestAmTo,
						 @v_rest_PM_From = RestPmFrom,
						 @v_rest_PM_To = RestPmTo
				from MstSrvDlrConfig
			 where TenantId = @p_Tenant_Id
	       and cast(EffDateFrom as date) <= cast(@p_FromTime as date)
	       and cast(EffDateTo as date) >= cast(@p_ToTime as date)

			if (@v_StartDateAsDate = @v_EndDateAsDate)
				begin
					
					-- we are in the same day so let's calculate just for the same day difference in minutes
					set @v_MinutesDiff = datediff(minute, @p_FromTime, @p_ToTime)

					-- if start early
					if (cast(@p_FromTime as time) < cast(@v_wk_AM_From as time))
						set @v_MinutesDiff = @v_MinutesDiff + datediff(minute, cast(@p_FromTime as time), cast(@v_wk_AM_From as time));

					-- AM break time, if any
					if (@v_rest_AM_From is not null and @v_rest_AM_To is not null)
						begin 
							if (cast(@p_FromTime as time) <= cast(@v_rest_AM_From as time) and cast(@p_ToTime as time) >= cast(@v_rest_AM_To as time))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_rest_AM_From as time), cast(@v_rest_AM_To as time));
						end

					-- Lunch time
					if (@v_wk_AM_To is not null and cast(@p_FromTime as time) <= cast(@v_wk_AM_To as time) and cast(@p_ToTime as time) >= cast(@v_wk_AM_To as time))
						set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_wk_AM_To as time), cast(@v_wk_PM_From as time));

					-- PM break time, if any
					if (@v_rest_PM_From is not null and @v_rest_PM_To is not null)
						begin 
							if (cast(@p_FromTime as time) <= cast(@v_rest_PM_From as time) and cast(@p_ToTime as time) >= cast(@v_rest_PM_To as time))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_rest_PM_From as time), cast(@v_rest_PM_To as time));
						end

					-- if finish late
					if (cast(@p_ToTime as time) > cast(@v_wk_PM_To as time))
						set @v_MinutesDiff = @v_MinutesDiff + datediff(minute, cast(@v_wk_PM_To as time), cast(@p_ToTime as time));
				end
			else
				begin
					-- take difference from start to the end of the day
					if (@p_FromTime < dateadd(minute, datepart(hour, @v_wk_PM_To) * 60 + datepart(minute, @v_wk_PM_To), @v_StartDateAsDate)) --since we work till @WK_PM_TO
						set @v_MinutesDiff = datediff(minute, @p_FromTime, dateadd(minute, datepart(hour, @v_wk_PM_To) * 60 + datepart(minute, @v_wk_PM_To), @v_StartDateAsDate))

					-- LET'S TAKE AWAY ANY BREAKS OR LUNCHES OUT --
          -- AM break time, if any
					if (@v_rest_AM_From is not null and @v_rest_AM_To is not null)
						begin
							if (@p_FromTime < dateadd(minute, datepart(hour, @v_rest_AM_From) * 60 + datepart(minute, @v_rest_AM_From), @v_StartDateAsDate))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_rest_AM_From as time), cast(@v_rest_AM_To as time))
						end

					-- Lunch time
					if (@v_wk_AM_To is not null and @v_wk_PM_From is not null)
						begin
							if (@p_FromTime < dateadd(minute, datepart(hour, @v_wk_AM_To) * 60 + datepart(minute, @v_wk_AM_To), @v_StartDateAsDate))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_wk_AM_To as time), cast(@v_wk_PM_From as time))
						end

					-- PM break time, if any
					if (@v_rest_PM_From is not null and @v_rest_PM_To is not null)
						begin
							if (@p_FromTime < dateadd(minute, datepart(hour, @v_rest_PM_From) * 60 + datepart(minute, @v_rest_PM_From), @v_StartDateAsDate))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_rest_PM_From as time), cast(@v_rest_PM_To as time))
						end

					-- let's get the number of whole days between the 2 specified dates
					while (@v_StartDateAsDate < dateadd(day, -1, @v_EndDateAsDate))
						begin
							select @v_Count_Calendar = count(1)
							  from MstSrvDlrCalendar
							 where TenantId = @p_Tenant_Id
							if @v_Count_Calendar > 0
								begin
									declare @v_temp int
									select @v_temp = count(1)
									  from MstSrvDlrCalendar
									 where TenantId = @p_Tenant_Id
									   and ValueDate = @v_StartDateAsDate
									if (@v_temp = 0)
										set @v_FullDays = @v_FullDays + 1
								end
							else 
								set @v_FullDays = @v_FullDays + 1

							set @v_StartDateAsDate = dateadd(day, 1, @v_StartDateAsDate)
						end

					-- important reset the start date
					set @v_StartDateAsDate = cast(@p_FromTime as date)

					-- Calculate total working time in minutes per day --
					set @v_MinWorking = datediff(minute, cast(@v_wk_AM_From as time), cast(@v_wk_PM_To as time))
					-- AM Break
					if (@v_rest_AM_From is not null and @v_rest_AM_To is not null)
						set @v_MinWorking = @v_MinWorking - datediff(minute, cast(@v_rest_AM_From as time), cast(@v_rest_AM_To as time))
					-- Lunch
					if (@v_wk_AM_To is not null and @v_wk_PM_From is not null)
						set @v_MinWorking = @v_MinWorking - datediff(minute, cast(@v_wk_AM_To as time), cast(@v_wk_PM_From as time))
					-- PM Break
					if (@v_rest_PM_From is not null and @v_rest_PM_To is not null)
						set @v_MinWorking = @v_MinWorking - datediff(minute, cast(@v_rest_PM_From as time), cast(@v_rest_PM_To as time))

					select @v_Holidays = count(1)
					  from MstSrvDlrCalendar
					 where TenantId = @p_Tenant_Id
					   and ValueDate >= @v_StartDateAsDate
						 and ValueDate <= @v_EndDateAsDate
					set @v_MinutesDiff = @v_MinutesDiff + ((@v_FullDays - @v_Holidays) * @v_MinWorking)

					-- finally get the last day of the transaction
					if (@p_ToTime > dateadd(minute, datepart(hour, @v_wk_AM_From) * 60 + datepart(minute, @v_wk_AM_From), @v_EndDateAsDate))
						set @v_MinutesDiff = @v_MinutesDiff + datediff(minute, dateadd(minute, datepart(hour, @v_wk_AM_From) * 60 + datepart(minute, @v_wk_AM_From), @v_EndDateAsDate), @p_ToTime)

					-- take away any breaks or lunches out
					if (@v_rest_AM_From is not null and @v_rest_AM_To is not null)
						begin
							if (@p_ToTime >= dateadd(minute, datepart(hour, @v_rest_AM_From) * 60 + datepart(minute, @v_rest_AM_From), @v_EndDateAsDate))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_rest_AM_From as time), cast(@v_rest_AM_To as time))
						end
					if (@v_wk_AM_To is not null and @v_wk_PM_From is not null)
						begin
							if (@p_ToTime >= dateadd(minute, datepart(hour, @v_wk_AM_To) * 60 + datepart(minute, @v_wk_AM_To), @v_EndDateAsDate))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_wk_AM_To as time), cast(@v_wk_PM_From as time))
						end
					if (@v_rest_PM_From is not null and @v_rest_PM_To is not null)
						begin
							if (@p_ToTime >= dateadd(minute, datepart(hour, @v_rest_PM_From) * 60 + datepart(minute, @v_rest_PM_From), @v_EndDateAsDate))
								set @v_MinutesDiff = @v_MinutesDiff - datediff(minute, cast(@v_rest_PM_From as time), cast(@v_rest_PM_To as time))
						end
				end
		end

	select @v_MinutesDiff
END
GO
