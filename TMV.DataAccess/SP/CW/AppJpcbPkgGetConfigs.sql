CREATE OR ALTER PROCEDURE [AppJpcbPkgGetConfigs]
	@p_TenantId int,
	@p_Type varchar(25)
AS
BEGIN
    set nocount on;

	select datepart(hour, WkAmFrom) StartHour, datepart(hour, WkPmTo) FinishHour,
	       datepart(minute, WkAmFrom) StartMinute, datepart(minute, WkPmTo) FinishMinute,
		   getdate() Ngay_LimitInterval_Min, getdate() Ngay_LimitInterval_Max, getdate() Ngay_Ct,
		   0 Thu_Bay, 1 Chu_Nhat, 50 HourWidth, 2 RowPage, 50 RowHeight,
		   datepart(hour, WkAmFrom) H_Sang1, datepart(minute, WkAmFrom) M_Sang1,
		   datepart(hour, WkAmTo) H_Sang2, datepart(minute, WkAmTo) M_Sang2,
		   getdate() Ngay_Sang1, getdate() Ngay_Sang2,
		   datepart(hour, WkPmFrom) H_Chieu1, datepart(minute, WkPmFrom) M_Chieu1,
		   datepart(hour, WkPmTo) H_Chieu2, datepart(minute, WkPmTo) M_Chieu2,
		   getdate() Ngay_Chieu1, getdate() Ngay_Chieu2
	  from MstSrvDlrConfig 
	 where cast(EffDateFrom as date) <= cast(getdate() as date)
	   and cast(EffDateTo as date) >= cast(getdate() as date)
	   and TenantId = @p_TenantId

	select w.Id, w.ColorCode Color, w.WorkshopCode Ma_khoang, coalesce(w.WorkshopDesc, w.WorkshopCode, 'RX') Ten_khoang
	  from MstSrvWorkshop w
	  join MstSrvWorkshopType t on t.Id = w.WorkshopTypeId
	 where w.TenantId = @p_TenantId
	   and w.IsActive = 1
	   and 
	    case 
		  when @p_Type = 'CW' and (t.WorkshopTypeCode = 'CLEAN_LOC') then 1
		  when @p_Type = 'GJ' and (t.WorkshopTypeCode = 'GJ' or t.WorkshopTypeCode = 'EM') then 1
		  when @p_Type = 'BP' and (t.WorkshopTypeCode = 'BP' or t.WorkshopTypeCode = 'PAINT_ROOM') then 1
		  else 0
		end = 1
  order by w.Ordering

	 select u.Id, u.UserName Ma_Hs, u.Name Ten_Hs, 0 Ngam_Dinh
	   from AbpUsers u
	   join MstSrvTitle t on t.Id = u.TitleId
	  where u.TenantId = @p_TenantId
	    and t.TitleCode = 'SA' -- CVDV
END
