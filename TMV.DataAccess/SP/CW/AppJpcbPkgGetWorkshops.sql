CREATE OR ALTER PROCEDURE AppJpcbPkgGetWorkshops
	@p_TenantId int,
	@p_Type varchar(25)
AS
BEGIN
	set nocount on;

	select w.Id Id_khoang, w.ColorCode Color, w.WorkshopCode Ma_khoang, coalesce(w.WorkshopName, w.WorkshopCode, 'RX') Ten_khoang
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
END
GO
