CREATE OR ALTER PROCEDURE [AppJpcbPkgGetCWData]
	@p_TenantId int,
	@p_Type int,
	@p_Date datetime,
	@p_CVDV bigint,
	@p_BKS  nvarchar(25),
	@p_RoNO nvarchar(50)
AS
BEGIN
    set nocount on;

	-- Get Working time: for display sang, chieu, ca ngay
	select *
	  from MstSrvDlrConfig 
	 where cast(EffDateFrom as date) <= cast(getdate() as date)
	   and cast(EffDateTo as date) >= cast(getdate() as date)
	   and TenantId = @p_TenantId

	select row_number() over (order by Id) stt, id stt_rec
	  from SrvPrgPlan p
	 where p.TenantId = @p_TenantId
	   and p.ROType = @p_Type
	   and cast(p.PlanFromTime as date) = cast(@p_Date as date)
END