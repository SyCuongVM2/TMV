CREATE OR ALTER PROCEDURE AppJpcbPkgGetHolidays
	@p_TenantId int,
	@p_FromTime datetime,
	@p_ToTime datetime
AS
BEGIN
	select ValueDate
	  from MstSrvDlrCalendar
	 where TenantId = @p_TenantId
	   and cast(ValueDate as date) >= cast(@p_FromTime as date)
		 and cast(ValueDate as date) <= cast(@p_ToTime as date)
END