CREATE OR ALTER PROCEDURE [AppJpcbPkgGetCWData]
	@p_TenantId int,
	@p_RO_Type int,
	@p_DayView_Type varchar(2),
	@p_Date datetime
AS
BEGIN
    set nocount on;

	-- 128, 255, 255 : green
	-- 255, 153, 255 : pink
	-- 0, 128, 254: blue
	-- 128, 128, 128: hieu suat

	declare @v_CW_Time int
	declare @v_WkAmFrom_H int
	declare @v_WkAmFrom_M int
	declare @v_WkAmTo_H int
	declare @v_WkAmTo_M int
	declare @v_WkPmFrom_H int
	declare @v_WkPmFrom_M int
	declare @v_WkPmTo_H int
	declare @v_WkPmTo_M int

	declare @v_Count int
	declare @v_Stt int
	declare @v_Stt_Rec bigint
	declare @v_T_Type varchar(1) 
	declare @v_Ma_Xe nvarchar(100) 
	declare @v_So_RO nvarchar(100) 
	declare @v_Ma_Hs nvarchar(150) 
	declare @v_Ma_Hs_Id bigint
	declare @v_Ngay_BD datetime
	declare @v_Ngay_KT datetime
	declare @v_Giao_Xe_Full datetime 
	declare @v_Giao_Xe varchar(5)
	declare @v_Ma_Khoang nvarchar(150) 
	declare @v_Khoang_Code nvarchar(150) 
	declare @v_Parking_Loc nvarchar(150) 
	declare @v_Backcolor nvarchar(150) 
	declare @v_Border int
	declare @v_Border_Color nvarchar(150) 
	declare @v_Size_Border int
	declare @v_Status int
	declare @v_Status_Desc nvarchar(200) 
	declare @v_Uu_Tien int 
	declare @v_KH_Doi int 
	declare @v_Flag int
	declare @v_Type int
	declare @v_Is_Completed int

	-- Get dlr config
	select @v_CW_Time = coalesce(m.WashTime, 10),
	       @v_WkAmFrom_H = datepart(hour, WkAmFrom),
		   @v_WkAmFrom_M = datepart(minute, WkAmFrom),
		   @v_WkAmTo_H = datepart(hour, WkAmTo),
		   @v_WkAmTo_M = datepart(minute, WkAmTo),
		   @v_WkPmFrom_H = datepart(hour, WkPmFrom),
		   @v_WkPmFrom_M = datepart(minute, WkPmFrom),
		   @v_WkPmTo_H = datepart(hour, WkPmTo),
		   @v_WkPmTo_M = datepart(minute, WkPmTo)
	  from MstSrvDlrConfig m
	 where cast(EffDateFrom as date) <= cast(@p_Date as date)
	   and cast(EffDateTo as date) >= cast(@p_Date as date)
	   and TenantId = @p_TenantId

	declare @v_Data_Table table
						(
						   Stt int, Stt_Rec bigint, T_Type varchar(1), Ma_Xe nvarchar(100), So_RO nvarchar(100), Ma_Hs nvarchar(150), Ma_Hs_Id bigint,
						   Ngay_BD datetime, Ngay_KT datetime,
						   Giao_Xe_Full datetime, Giao_Xe varchar(5), Ma_Khoang nvarchar(150), Khoang_Code nvarchar(150), Parking_Loc nvarchar(150), 
						   Backcolor nvarchar(150), Border int, Border_Color nvarchar(150), Size_Border int,
						   A_Status int, Status_Desc nvarchar(200), Uu_Tien int, KH_Doi int, Flag int, A_Type int, Is_Completed int, DataTable varchar(50)
                        )
	declare @v_Dt_Data_Xe table
						(
						   Stt int, Stt_Rec nvarchar(150), Ma_Khoang nvarchar(150), Ma_Xe nvarchar(100), So_RO nvarchar(100), Ma_Hs nvarchar(150), Ma_Hs_Id bigint, Giao_Xe varchar(5),
						   BackColorHead nvarchar(150), BackColor2Head nvarchar(150), Italic int, FontSize int, UnDerLine int, Flag int, DataTable varchar(50)
                        )

	declare cursor_data cursor for
		select row_number() over (order by p.Id) Stt, p.Id Stt_Rec, 'P' T_Type,
			   v.RegisterNo Ma_Xe, r.RepairOrderNo So_RO, u.[Name] Ma_Hs, u.Id Ma_Hs_Id,
			   p.PlanFromTime Ngay_BD, p.PlanToTime Ngay_KT, 
			   r.CarDeliveryDate Giao_Xe_Full, convert(varchar(5), r.CarDeliveryDate, 108) Giao_Xe,
			   coalesce(ws.WorkshopName, ws.WorkshopCode, 'RX') Ma_Khoang, ws.WorkshopCode Khoang_Code, '' Parking_Loc,
			   (case
				  when (datediff(m, getdate(), r.CarDeliveryDate) <= 0) then '255, 153, 255' -- pink
				  else '128, 255, 255'  -- YellowGreen
				end) Backcolor, 
			   0 Border, '128, 128, 128' Border_Color, 0 Size_Border, 
			   0 A_Status, '' Status_Desc,
			   p.IsPriority Uu_Tien, p.IsCustomerWait KH_Doi, 3 Flag, 0 A_Type, 0 Is_Completed
		  from SrvPrgPlan p
		  join SrvQuoRepairOrder r on r.Id = p.ROId
		  join SrvQuoVehicle v on v.Id = p.VehicleId
		  join MstSrvWorkshop ws on ws.Id = p.WorkshopId
		  join AbpUsers u on u.Id = r.CreatorUserId
		 where p.TenantId = @p_TenantId
		   and p.ROType = @p_RO_Type
		   and p.ActualId is null
		   and 
		    (case
			    when @p_DayView_Type = '01' and (cast(p.PlanFromTime as date) = cast(@p_Date as date)) then 1
				when @p_DayView_Type = '02' and 
				    (
					   p.PlanFromTime >= dateadd(hh, @v_WkAmFrom_H, dateadd(mi, @v_WkAmFrom_M, dateadd(ss, 00, DATEDIFF(dd, 0, @p_Date))))
					) and
					(
					   p.PlanFromTime <= dateadd(hh, @v_WkAmTo_H, dateadd(mi, @v_WkAmTo_M, dateadd(ss, 00, DATEDIFF(dd, 0, @p_Date))))
					) then 1
				when @p_DayView_Type = '03' and 
				    (
					   p.PlanFromTime >= dateadd(hh, @v_WkPmFrom_H, dateadd(mi, @v_WkPmFrom_M, dateadd(ss, 00, DATEDIFF(dd, 0, @p_Date))))
					) and
					(
					   p.PlanFromTime <= dateadd(hh, @v_WkPmTo_H, dateadd(mi, @v_WkPmTo_M, dateadd(ss, 00, DATEDIFF(dd, 0, @p_Date))))
					) then 1
		     end = 1)
	union
	    select row_number() over (order by a.Id) Stt, a.Id Stt_Rec, 'A' T_Type,
			   v.RegisterNo Ma_Xe, r.RepairOrderNo So_RO, u.[Name] Ma_Hs, u.Id Ma_Hs_Id,
			   a.ActualFromTime Ngay_BD, coalesce(a.ActualToTime, dateadd(minute, @v_CW_Time, a.ActualFromTime)) Ngay_KT, 
			   r.CarDeliveryDate Giao_Xe_Full, convert(varchar(5), r.CarDeliveryDate, 108) Giao_Xe,
			   coalesce(ws.WorkshopName, ws.WorkshopCode, 'RX') Ma_Khoang, ws.WorkshopCode Khoang_Code, '' Parking_Loc,
			   (case
				  when (datediff(m, getdate(), r.CarDeliveryDate) <= 0) then '255, 153, 255'  -- pink
				  else '0, 128, 254'  -- Blue
				end) Backcolor, 
			   1 Border, '23, 56, 2' Border_Color, 1 Size_Border,
			   0 A_Status, '' Status_Desc, 
			   a.IsPriority Uu_Tien, a.IsCustomerWait KH_Doi, 0 Flag, 0 A_Type, 
			   (case 
			     when a.ActualState = 4 then 1
				 else 0
			   end) Is_Completed
		  from SrvPrgActual a
		  join SrvQuoRepairOrder r on r.Id = a.ROId
		  join SrvQuoVehicle v on v.Id = a.VehicleId
		  join MstSrvWorkshop ws on ws.Id = a.WorkshopId
		  join AbpUsers u on u.Id = r.CreatorUserId
		 where a.TenantId = @p_TenantId
		   and a.ROType = @p_RO_Type
		   and 
		     (case
			    when @p_DayView_Type = '01' and (cast(a.ActualFromTime as date) = cast(@p_Date as date)) then 1
				when @p_DayView_Type = '02' and 
				    (
					   a.ActualFromTime >= dateadd(hh, @v_WkAmFrom_H, dateadd(mi, @v_WkAmFrom_M, dateadd(ss, 00, DATEDIFF(dd, 0, @p_Date))))
					) and
					(
					   a.ActualFromTime <= dateadd(hh, @v_WkAmTo_H, dateadd(mi, @v_WkAmTo_M, dateadd(ss, 00, DATEDIFF(dd, 0, @p_Date))))
					) then 1
				when @p_DayView_Type = '03' and 
				    (
					   a.ActualFromTime >= dateadd(hh, @v_WkPmFrom_H, dateadd(mi, @v_WkPmFrom_M, dateadd(ss, 00, DATEDIFF(dd, 0, @p_Date))))
					) and
					(
					   a.ActualFromTime <= dateadd(hh, @v_WkPmTo_H, dateadd(mi, @v_WkPmTo_M, dateadd(ss, 00, DATEDIFF(dd, 0, @p_Date))))
					) then 1
		     end = 1)

	open cursor_data
	fetch next from cursor_data into 
		@v_Stt, @v_Stt_Rec, @v_T_Type, @v_Ma_Xe, @v_So_RO, @v_Ma_Hs, @v_Ma_Hs_Id, @v_Ngay_BD, @v_Ngay_KT, @v_Giao_Xe_Full, @v_Giao_Xe, @v_Ma_Khoang, @v_Khoang_Code,
		@v_Parking_Loc, @v_Backcolor, @v_Border, @v_Border_Color, @v_Size_Border, @v_Status, @v_Status_Desc, @v_Uu_Tien, @v_KH_Doi, @v_Flag, @v_Type, @v_Is_Completed
	while @@FETCH_STATUS = 0
		begin
			if (@v_Is_Completed = 0)
				begin
					select @v_Count = count(1)
					  from @v_Dt_Data_Xe
					 where Ma_Xe = @v_Ma_Xe
					if @v_Count = 0
						begin
							insert into @v_Dt_Data_Xe(Stt, Stt_Rec, Ma_Khoang, Ma_Xe, So_RO, Ma_Hs, Ma_Hs_Id, Giao_Xe,
													  BackColorHead, BackColor2Head, Italic, FontSize, UnDerLine, Flag, DataTable)
												values(@v_Stt, @v_Khoang_Code, @v_Khoang_Code, @v_Ma_Xe, @v_So_RO, @v_Ma_Hs, @v_Ma_Hs_Id, @v_Giao_Xe, 
													  '', '', 0, 9, 0, 0, 'Dt_Data_Xe')
						end 

					insert into @v_Data_Table(
							Stt, Stt_Rec, T_Type, Ma_Xe, So_RO, Ma_Hs, Ma_Hs_Id, Ngay_BD, Ngay_KT, Giao_Xe_Full, Giao_Xe, Ma_Khoang, Khoang_Code,
							Parking_Loc, Backcolor, Border, Border_Color, Size_Border, A_Status, Status_Desc, Uu_Tien, KH_Doi, Flag, A_Type, Is_Completed, DataTable)
					values(@v_Stt, @v_Stt_Rec, @v_T_Type, @v_Ma_Xe, @v_So_RO, @v_Ma_Hs, @v_Ma_Hs_Id, @v_Ngay_BD, @v_Ngay_KT, @v_Giao_Xe_Full, @v_Giao_Xe, @v_Ma_Khoang, @v_Khoang_Code,
							@v_Parking_Loc, @v_Backcolor, @v_Border, @v_Border_Color, @v_Size_Border, @v_Status, @v_Status_Desc, @v_Uu_Tien, @v_KH_Doi, @v_Flag, @v_Type, @v_Is_Completed, 'Dt_Data')
				end

			if (@v_T_Type = 'P')
			  begin
				insert into @v_Data_Table(
						   Stt, Stt_Rec, T_Type, Ma_Xe, So_RO, Ma_Hs, Ma_Hs_Id, Ngay_BD, Ngay_KT, Giao_Xe_Full, Giao_Xe, Ma_Khoang, Khoang_Code,
						   Parking_Loc, Backcolor, Border, Border_Color, Size_Border, A_Status, Status_Desc, Uu_Tien, KH_Doi, Flag, A_Type, Is_Completed, DataTable)
					 values(@v_Stt, @v_Stt_Rec, @v_T_Type, @v_Ma_Xe, @v_So_RO, @v_Ma_Hs, @v_Ma_Hs_Id, @v_Ngay_BD, @v_Ngay_KT, @v_Giao_Xe_Full, @v_Giao_Xe, @v_Ma_Khoang, @v_Khoang_Code,
					        @v_Parking_Loc, @v_Backcolor, @v_Border, @v_Border_Color, @v_Size_Border, @v_Status, @v_Status_Desc, @v_Uu_Tien, @v_KH_Doi, @v_Flag, @v_Type, @v_Is_Completed, 'Dt_Cho_Rua')
			  end
			else if (@v_T_Type = 'A')
			  begin
			    if (@v_Is_Completed = 1)
					begin
						insert into @v_Data_Table(
									   Stt, Stt_Rec, T_Type, Ma_Xe, So_RO, Ma_Hs, Ma_Hs_Id, Ngay_BD, Ngay_KT, Giao_Xe_Full, Giao_Xe, Ma_Khoang, Khoang_Code,
									   Parking_Loc, Backcolor, Border, Border_Color, Size_Border, A_Status, Status_Desc, Uu_Tien, KH_Doi, Flag, A_Type, Is_Completed, DataTable)
								 values(@v_Stt, @v_Stt_Rec, @v_T_Type, @v_Ma_Xe, @v_So_RO, @v_Ma_Hs, @v_Ma_Hs_Id, @v_Ngay_BD, @v_Ngay_KT, @v_Giao_Xe_Full, @v_Giao_Xe, @v_Ma_Khoang, @v_Khoang_Code, 
										@v_Parking_Loc, @v_Backcolor, @v_Border, @v_Border_Color, @v_Size_Border, @v_Status, @v_Status_Desc, @v_Uu_Tien, @v_KH_Doi, @v_Flag, @v_Type, @v_Is_Completed, 'Dt_Rua_Xong')
					end 
				else 
					begin
						insert into @v_Data_Table(
								   Stt, Stt_Rec, T_Type, Ma_Xe, So_RO, Ma_Hs, Ma_Hs_Id, Ngay_BD, Ngay_KT, Giao_Xe_Full, Giao_Xe, Ma_Khoang, Khoang_Code,
								   Parking_Loc, Backcolor, Border, Border_Color, Size_Border, A_Status, Status_Desc, Uu_Tien, KH_Doi, Flag, A_Type, Is_Completed, DataTable)
							 values(@v_Stt, @v_Stt_Rec, @v_T_Type, @v_Ma_Xe, @v_So_RO, @v_Ma_Hs, @v_Ma_Hs_Id, @v_Ngay_BD, @v_Ngay_KT, @v_Giao_Xe_Full, @v_Giao_Xe, @v_Ma_Khoang, @v_Khoang_Code,
									@v_Parking_Loc, @v_Backcolor, @v_Border, @v_Border_Color, @v_Size_Border, @v_Status, @v_Status_Desc, @v_Uu_Tien, @v_KH_Doi, @v_Flag, @v_Type, @v_Is_Completed, 'Dt_Dang_Rua')
					end
			  end

			fetch next from cursor_data into
				@v_Stt, @v_Stt_Rec, @v_T_Type, @v_Ma_Xe, @v_So_RO, @v_Ma_Hs, @v_Ma_Hs_Id, @v_Ngay_BD, @v_Ngay_KT, @v_Giao_Xe_Full, @v_Giao_Xe, @v_Ma_Khoang, @v_Khoang_Code,
		        @v_Parking_Loc, @v_Backcolor, @v_Border, @v_Border_Color, @v_Size_Border, @v_Status, @v_Status_Desc, @v_Uu_Tien, @v_KH_Doi, @v_Flag, @v_Type, @v_Is_Completed
		end
	close cursor_data
	deallocate cursor_data

	select *
	  from @v_Data_Table where DataTable = 'Dt_Cho_Rua'
	select *
	  from @v_Data_Table where DataTable = 'Dt_Data'
	select *
	  from @v_Data_Table where DataTable = 'Dt_Dang_Rua'
	select *
	  from @v_Data_Table where DataTable = 'Dt_Rua_Xong'
	select *
	  from @v_Dt_Data_Xe
END