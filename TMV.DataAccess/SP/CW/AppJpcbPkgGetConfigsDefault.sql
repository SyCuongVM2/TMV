CREATE OR ALTER PROCEDURE [AppJpcbPkgGetConfigsDefault]
	@p_TenantId int,
	@p_Date datetime
AS
BEGIN
    set nocount on;

	select datepart(hour, WkAmFrom) StartHour, datepart(hour, WkPmTo) FinishHour,
	       datepart(minute, WkAmFrom) StartMinute, datepart(minute, WkPmTo) FinishMinute,
		   @p_Date Ngay_LimitInterval_Min, @p_Date Ngay_LimitInterval_Max, @p_Date Ngay_Ct,
		   0 Thu_Bay, 1 Chu_Nhat, 50 HourWidth, 3 RowPage, 50 RowHeight,
		   datepart(hour, WkAmFrom) H_Sang1, datepart(minute, WkAmFrom) M_Sang1,
		   datepart(hour, WkAmTo) H_Sang2, datepart(minute, WkAmTo) M_Sang2,
		   @p_Date Ngay_Sang1, @p_Date Ngay_Sang2,
		   datepart(hour, WkPmFrom) H_Chieu1, datepart(minute, WkPmFrom) M_Chieu1,
		   datepart(hour, WkPmTo) H_Chieu2, datepart(minute, WkPmTo) M_Chieu2,
		   @p_Date Ngay_Chieu1, @p_Date Ngay_Chieu2
	  from MstSrvDlrConfig 
	 where cast(EffDateFrom as date) <= cast(@p_Date as date)
	   and cast(EffDateTo as date) >= cast(@p_Date as date)
	   and TenantId = @p_TenantId
END
