CREATE OR ALTER PROCEDURE AppJpcbPkgGetCWDetail
	@p_TenantId int,
	@p_Id bigint
AS
BEGIN
	set nocount on

	select w.Id Id_khoang, w.ColorCode Color, w.WorkshopCode Ma_khoang, coalesce(w.WorkshopName, w.WorkshopCode, 'RX') Ten_khoang
	  from MstSrvWorkshop w
	  join MstSrvWorkshopType t on t.Id = w.WorkshopTypeId
	 where w.TenantId = @p_TenantId
	   and w.IsActive = 1
	   and t.WorkshopTypeCode = 'CLEAN_LOC'
   order by w.Ordering

	 select row_number() over (order by p.Id) Stt, p.Id Stt_Rec,
				  p.WorkshopId Id_khoang, w.WorkshopCode Ma_khoang, p.PlanFromTime, p.PlanToTime,
				  r.OpenRoDate Ngay_BD_Ro, r.CloseRoDate Ngay_KT_Ro, r.CarDeliveryDate Ngay_henKT_Ro, 
				  r.RepairOrderNo So_RO, r.RegisterNo Ma_Xe
		 from SrvPrgPlan p
		 join MstSrvWorkshop w on p.WorkshopId = w.Id
left join SrvQuoRepairOrder r on p.ROId = r.Id
		where p.Id = @p_Id
			and p.TenantId = @p_TenantId
			and p.ROType = 3 -- CW
END