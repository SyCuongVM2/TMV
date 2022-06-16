CREATE TYPE DealerConfigDTO AS TABLE
(
	Id   int, 
	wkAMFrom datetime,
	wkAMTo datetime,
	wkPMFrom datetime,
	wkPMTo datetime,
	restAMFrom datetime,
	restAMTo datetime,
	restPMFrom datetime,
	restPMTo datetime
)

CREATE TYPE DealerCalendarDTO AS TABLE
(
	Id   int, 
	startTime datetime,
	endTime datetime,
	isHoliday int
)

CREATE OR ALTER FUNCTION setDateToDateTime
(
	@p_date datetime,
	@p_dateTime datetime
)
RETURNS datetime
AS
BEGIN
	return dateadd(minute, datepart(minute, @p_dateTime), (dateadd(hour, datepart(hour, @p_dateTime), cast(cast(@p_date as date) as datetime))))
END
GO

CREATE PROCEDURE AppJpcbPkgGetWorkingTime
	@p_TenantId int,
	@p_FromTime datetime,
	@p_ToTime datetime
AS
BEGIN
	select wkAMFrom, wkAMTo, wkPMFrom, wkPMTo, restAMFrom, restAMTo, restPMFrom, restPMTo
	  from MstSrvDlrConfig
	 where TenantId = @p_TenantId
	   and cast(EffDateFrom as date) <= cast(@p_FromTime as date)
		 and cast(EffDateTo as date) >= cast(@p_FromTime as date)

	select ValueDate
	  from MstSrvDlrCalendar
	 where TenantId = @p_TenantId
	   and cast(ValueDate as date) >= cast(@p_FromTime as date)
		 and cast(ValueDate as date) <= cast(@p_ToTime as date)
END
GO