using System;
using System.ComponentModel;
using System.Data;

namespace TMV.UI.RP.Common
{
  public class SchedulingDataSet : DataSet
  {
    public SchedulingDataSet()
    {
      DataTable appointments = new DataTable("Appointments");
      DataTable resources = new DataTable("Resources");

      appointments.Columns.Add("ID", typeof(Int32));
      appointments.Columns.Add("Subject", typeof(string));
      appointments.Columns.Add("StartTime", typeof(DateTime));
      appointments.Columns.Add("EndTime", typeof(DateTime));
      appointments.Columns.Add("Description", typeof(string));
      appointments.Columns.Add("Location", typeof(string));
      appointments.Columns.Add("Label", typeof(Int32));
      appointments.Columns.Add("Status", typeof(Int32));
      appointments.Columns.Add("AllDay", typeof(Boolean));
      appointments.Columns.Add("ReminderInfo", typeof(string));
      appointments.Columns.Add("RecurrenceInfo", typeof(string));
      appointments.Columns.Add("EventType", typeof(Int32));
      appointments.Columns.Add("ResourceId", typeof(string));
      appointments.Constraints.Add("IDPK", appointments.Columns["ID"], true);
      appointments.Columns["ID"].AutoIncrement = true;

      resources.Columns.Add("ID", typeof(Int32));
      resources.Columns.Add("Caption", typeof(string));
      resources.Constraints.Add("IDPK", resources.Columns["ID"], true);

      Tables.AddRange(new DataTable[] { appointments, resources });
    }
    public static SchedulingDataSet CreateData()
    {
      SchedulingDataSet ds = new SchedulingDataSet();
      DataTable appointments = ds.Tables["Appointments"];
      DataTable resources = ds.Tables["Resources"];

      appointments.Rows.Add(new object[] { 0, "Test1", DateTime.Today.AddHours(2), DateTime.Today.AddHours(3), "", "", 0, 2, false, "", "", 0, "<ResourceIds><ResourceId Type=\"System.Int32\" Value=\"0\" /></ResourceIds>" });
      appointments.Rows.Add(new object[] { 1, "Test2", DateTime.Today.AddHours(4), DateTime.Today.AddHours(5), "", "", 0, 2, false, "", "", 0, "<ResourceIds><ResourceId Type=\"System.Int32\" Value=\"1\" /></ResourceIds>" });
      appointments.Rows.Add(new object[] { 2, "Test3", DateTime.Today.AddHours(4), DateTime.Today.AddHours(5), "", "", 0, 2, false, "", "", 0, "<ResourceIds><ResourceId Type=\"System.Int32\" Value=\"3\" /></ResourceIds>" });

      resources.Rows.Add(new object[] { 1, "Resource2" });
      resources.Rows.Add(new object[] { 3, "Resource3" });

      return ds;
    }

    #region Disable Serialization for Tables and Relations
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataTableCollection Tables
    {
      get { return base.Tables; }
    }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataRelationCollection Relations
    {
      get { return base.Relations; }
    }
    #endregion Disable Serialization for Tables and Relations
  }

  public class CP_RO_CW_ConFig : DataSet
  {
    public CP_RO_CW_ConFig()
    {
      DataTable Dt_ConFigColor_KH_SCC = new DataTable("Dt_ConFigColor_KH_SCC");
      DataTable Dt_Set_SCC = new DataTable("Dt_Set_SCC");
      DataTable Dt_Buoc_Nhay_KH_SCC = new DataTable("Dt_Buoc_Nhay_KH_SCC");
      DataTable Dt_Do_Rong_KH_SCC = new DataTable("Dt_Do_Rong_KH_SCC");
      DataTable DmKhoang_Loc_KH_SCC = new DataTable("DmKhoang_Loc_KH_SCC");
      DataTable DmCVDV_Loc_KH_SCC = new DataTable("DmCVDV_Loc_KH_SCC");
      DataTable Dt_Kieu_Xem = new DataTable("Dt_Kieu_Xem");

      Dt_ConFigColor_KH_SCC.Columns.Add("ID", typeof(Int32));
      Dt_ConFigColor_KH_SCC.Columns.Add("BackColor", typeof(string));
      Dt_ConFigColor_KH_SCC.Columns.Add("Ten_Color", typeof(string));

      Dt_Set_SCC.Columns.Add("ID", typeof(Int32));
      Dt_Set_SCC.Columns.Add("StartHour", typeof(Int32));
      Dt_Set_SCC.Columns.Add("FinishHour", typeof(Int32));
      Dt_Set_SCC.Columns.Add("StartMINUTE", typeof(Int32));
      Dt_Set_SCC.Columns.Add("FinishMINUTE", typeof(Int32));
      Dt_Set_SCC.Columns.Add("Ngay_LimitInterval_Min", typeof(DateTime));
      Dt_Set_SCC.Columns.Add("Ngay_LimitInterval_Max", typeof(DateTime));
      Dt_Set_SCC.Columns.Add("Ngay_Ct", typeof(DateTime));
      Dt_Set_SCC.Columns.Add("Thu_Bay", typeof(string));
      Dt_Set_SCC.Columns.Add("Chu_Nhat", typeof(string));
      Dt_Set_SCC.Columns.Add("HourWidth", typeof(Int32));
      Dt_Set_SCC.Columns.Add("RowPage", typeof(Int32));
      Dt_Set_SCC.Columns.Add("RowHeight", typeof(Int32));
      Dt_Set_SCC.Columns.Add("H_Sang1", typeof(Int32));
      Dt_Set_SCC.Columns.Add("M_Sang1", typeof(Int32));
      Dt_Set_SCC.Columns.Add("H_Sang2", typeof(Int32));
      Dt_Set_SCC.Columns.Add("M_Sang2", typeof(Int32));
      Dt_Set_SCC.Columns.Add("Ngay_Sang1", typeof(DateTime));
      Dt_Set_SCC.Columns.Add("Ngay_Sang2", typeof(DateTime));
      Dt_Set_SCC.Columns.Add("H_Chieu1", typeof(Int32));
      Dt_Set_SCC.Columns.Add("M_Chieu1", typeof(Int32));
      Dt_Set_SCC.Columns.Add("H_Chieu2", typeof(Int32));
      Dt_Set_SCC.Columns.Add("M_Chieu2", typeof(Int32));
      Dt_Set_SCC.Columns.Add("Ngay_Chieu1", typeof(DateTime));
      Dt_Set_SCC.Columns.Add("Ngay_Chieu2", typeof(DateTime));

      Dt_Buoc_Nhay_KH_SCC.Columns.Add("ID", typeof(Int32));
      Dt_Buoc_Nhay_KH_SCC.Columns.Add("Ma_BN", typeof(string));
      Dt_Buoc_Nhay_KH_SCC.Columns.Add("Ten_BN", typeof(string));
      Dt_Buoc_Nhay_KH_SCC.Columns.Add("Ngam_Dinh", typeof(string));

      Dt_Do_Rong_KH_SCC.Columns.Add("ID", typeof(Int32));
      Dt_Do_Rong_KH_SCC.Columns.Add("Ma_Width", typeof(string));
      Dt_Do_Rong_KH_SCC.Columns.Add("Ten_Width", typeof(string));
      Dt_Do_Rong_KH_SCC.Columns.Add("Ngam_Dinh", typeof(string));

      DmKhoang_Loc_KH_SCC.Columns.Add("ID", typeof(Int32));
      DmKhoang_Loc_KH_SCC.Columns.Add("Color", typeof(string));
      DmKhoang_Loc_KH_SCC.Columns.Add("Image", typeof(string));
      DmKhoang_Loc_KH_SCC.Columns.Add("Ma_khoang", typeof(string));
      DmKhoang_Loc_KH_SCC.Columns.Add("Ten_khoang", typeof(string));

      DmCVDV_Loc_KH_SCC.Columns.Add("ID", typeof(Int32));
      DmCVDV_Loc_KH_SCC.Columns.Add("Ma_Hs", typeof(string));
      DmCVDV_Loc_KH_SCC.Columns.Add("Ten_Hs", typeof(string));
      DmCVDV_Loc_KH_SCC.Columns.Add("Ngam_Dinh", typeof(string));

      Dt_Kieu_Xem.Columns.Add("ID", typeof(Int32));
      Dt_Kieu_Xem.Columns.Add("Kieu_Xem", typeof(string));
      Dt_Kieu_Xem.Columns.Add("Ten_Kieu", typeof(string));
      Dt_Kieu_Xem.Columns.Add("Ngam_Dinh", typeof(string));
      Dt_Kieu_Xem.Columns.Add("ShowHead", typeof(Int32));

      Tables.AddRange(new DataTable[] { Dt_ConFigColor_KH_SCC, Dt_Set_SCC, Dt_Buoc_Nhay_KH_SCC, Dt_Do_Rong_KH_SCC, DmKhoang_Loc_KH_SCC, DmCVDV_Loc_KH_SCC, Dt_Kieu_Xem });
    }
    public static CP_RO_CW_ConFig CreateData()
    {
      CP_RO_CW_ConFig ds = new CP_RO_CW_ConFig();
      DataTable Dt_ConFigColor_KH_SCC = ds.Tables["Dt_ConFigColor_KH_SCC"];
      DataTable Dt_Set_SCC = ds.Tables["Dt_Set_SCC"];
      DataTable Dt_Buoc_Nhay_KH_SCC = ds.Tables["Dt_Buoc_Nhay_KH_SCC"];
      DataTable Dt_Do_Rong_KH_SCC = ds.Tables["Dt_Do_Rong_KH_SCC"];
      DataTable DmKhoang_Loc_KH_SCC = ds.Tables["DmKhoang_Loc_KH_SCC"];
      DataTable DmCVDV_Loc_KH_SCC = ds.Tables["DmCVDV_Loc_KH_SCC"];
      DataTable Dt_Kieu_Xem = ds.Tables["Dt_Kieu_Xem"];

      Dt_ConFigColor_KH_SCC.Rows.Add(new object[] { 1, "19, 230, 255", "Red" });

      Dt_Set_SCC.Rows.Add(new object[] {
        1, 8, 17, 0, 0, DateTime.Today, DateTime.Today, DateTime.Today, "0", "1", 20, 2, 50,
        8, 0, 12, 0, DateTime.Today, DateTime.Today, 
        13, 0, 17, 0, DateTime.Today, DateTime.Today
      });

      Dt_Buoc_Nhay_KH_SCC.Rows.Add(new object[] { 1, "5", "5 Phút", "0" });
      Dt_Buoc_Nhay_KH_SCC.Rows.Add(new object[] { 2, "8", "8 Phút", "1" });
      Dt_Buoc_Nhay_KH_SCC.Rows.Add(new object[] { 3, "10", "10 Phút", "0" });
      Dt_Buoc_Nhay_KH_SCC.Rows.Add(new object[] { 4, "15", "15 Phút", "0" });
      Dt_Buoc_Nhay_KH_SCC.Rows.Add(new object[] { 5, "20", "20 Phút", "0" });
      Dt_Buoc_Nhay_KH_SCC.Rows.Add(new object[] { 6, "30", "30 Phút", "0" });
      Dt_Buoc_Nhay_KH_SCC.Rows.Add(new object[] { 7, "60", "60 Phút", "0" });

      Dt_Do_Rong_KH_SCC.Rows.Add(new object[] { 1, "10", "10", "1" });
      Dt_Do_Rong_KH_SCC.Rows.Add(new object[] { 2, "15", "15", "0" });
      Dt_Do_Rong_KH_SCC.Rows.Add(new object[] { 3, "20", "20", "0" });
      Dt_Do_Rong_KH_SCC.Rows.Add(new object[] { 4, "25", "25", "0" });
      Dt_Do_Rong_KH_SCC.Rows.Add(new object[] { 5, "30", "30", "0" });
      Dt_Do_Rong_KH_SCC.Rows.Add(new object[] { 6, "40", "40", "0" });
      Dt_Do_Rong_KH_SCC.Rows.Add(new object[] { 7, "50", "50", "0" });
      Dt_Do_Rong_KH_SCC.Rows.Add(new object[] { 8, "60", "60", "0" });
      Dt_Do_Rong_KH_SCC.Rows.Add(new object[] { 9, "70", "70", "0" });
      Dt_Do_Rong_KH_SCC.Rows.Add(new object[] { 10, "80", "80", "0" });
      Dt_Do_Rong_KH_SCC.Rows.Add(new object[] { 11, "100", "100", "0" });
      Dt_Do_Rong_KH_SCC.Rows.Add(new object[] { 12, "150", "150", "0" });

      DmKhoang_Loc_KH_SCC.Rows.Add(new object[] { 1, "10, 123, 255", "", "1T1", "Khoang rửa xe ướt 1T1" });
      DmKhoang_Loc_KH_SCC.Rows.Add(new object[] { 2, "14, 15, 200", "", "2T1", "Khoang rửa xe ướt 2T1" });

      DmCVDV_Loc_KH_SCC.Rows.Add(new object[] { 0, "", "Chọn CVDV", "1" });
      DmCVDV_Loc_KH_SCC.Rows.Add(new object[] { 1, "100010", "Bùi Ngọc Khánh", "0" });
      DmCVDV_Loc_KH_SCC.Rows.Add(new object[] { 2, "100020", "Nguyễn Tiến Thắng", "0" });
      DmCVDV_Loc_KH_SCC.Rows.Add(new object[] { 3, "100040", "Trần Duy Tiến", "0" });
      DmCVDV_Loc_KH_SCC.Rows.Add(new object[] { 4, "100050", "Vũ Văn Phong", "0" });
      DmCVDV_Loc_KH_SCC.Rows.Add(new object[] { 5, "100070", "Ngô Văn Nam", "0" });
      DmCVDV_Loc_KH_SCC.Rows.Add(new object[] { 6, "100090", "Công Tuấn Dương", "0" });

      Dt_Kieu_Xem.Rows.Add(new object[] { 1, "01", "Khoang", "1", 1 });
      Dt_Kieu_Xem.Rows.Add(new object[] { 2, "02", "BKS", "0", 0 });

      return ds;
    }
  }

  public class CP_RO_CW_Data : DataSet
  {
    public CP_RO_CW_Data()
    {
      DataTable Dt_Cho_Rua = new DataTable("Dt_Cho_Rua");
      DataTable Dt_Data = new DataTable("Dt_Data");
      DataTable Dt_Dang_Rua = new DataTable("Dt_Dang_Rua");
      DataTable Dt_Rua_Xong = new DataTable("Dt_Rua_Xong");
      DataTable Dt_Data_Xe = new DataTable("Dt_Data_Xe");
      DataTable Dt_Cho_Rua_H = new DataTable("Dt_Cho_Rua_H");
      DataTable Dt_Dang_Rua_H = new DataTable("Dt_Dang_Rua_H");
      DataTable Dt_Rua_Xong_H = new DataTable("Dt_Rua_Xong_H");

      Dt_Data.Columns.Add("ID", typeof(Int32));
      Dt_Data.Columns.Add("Stt", typeof(string));
      Dt_Data.Columns.Add("Stt_Rec", typeof(string));
      Dt_Data.Columns.Add("AllDay", typeof(string));
      Dt_Data.Columns.Add("Border", typeof(string));
      Dt_Data.Columns.Add("BorderColor", typeof(string));
      Dt_Data.Columns.Add("SizeBorder", typeof(string));
      Dt_Data.Columns.Add("Size_Border", typeof(string));
      Dt_Data.Columns.Add("Ma_Xe", typeof(string));
      Dt_Data.Columns.Add("ma_khoang", typeof(string));
      //Dt_Data.Columns.Add("Dien_Giai", typeof(string));
      Dt_Data.Columns.Add("Ngay_BD", typeof(DateTime));
      Dt_Data.Columns.Add("Ngay_KT", typeof(DateTime));
      Dt_Data.Columns.Add("Type", typeof(string));
      //Dt_Data.Columns.Add("Tootip", typeof(string));
      Dt_Data.Columns.Add("Ma_Hs", typeof(string));
      Dt_Data.Columns.Add("So_RO", typeof(string));
      Dt_Data.Columns.Add("Uu_Tien", typeof(string));
      Dt_Data.Columns.Add("Flag", typeof(string));
      Dt_Data.Columns.Add("Backcolor", typeof(string));

      Dt_Cho_Rua.Columns.Add("ID", typeof(Int32));
      Dt_Cho_Rua.Columns.Add("Stt", typeof(string));
      Dt_Cho_Rua.Columns.Add("Stt_Rec", typeof(string));
      Dt_Cho_Rua.Columns.Add("Ma_Ct", typeof(string)); // !HDK,HDP,HDM 
      Dt_Cho_Rua.Columns.Add("Ma_Xe", typeof(string));
      Dt_Cho_Rua.Columns.Add("Ma_Hs", typeof(string));
      Dt_Cho_Rua.Columns.Add("So_RO", typeof(string));

      Dt_Dang_Rua.Columns.Add("ID", typeof(Int32));
      Dt_Dang_Rua.Columns.Add("Stt", typeof(string));
      Dt_Dang_Rua.Columns.Add("Stt_Rec", typeof(string));
      Dt_Dang_Rua.Columns.Add("Ma_Ct", typeof(string)); // !HDK,HDP,HDM 
      Dt_Dang_Rua.Columns.Add("Ma_Xe", typeof(string));
      Dt_Dang_Rua.Columns.Add("Ma_Hs", typeof(string));
      Dt_Dang_Rua.Columns.Add("So_RO", typeof(string));

      Dt_Rua_Xong.Columns.Add("ID", typeof(Int32));
      Dt_Rua_Xong.Columns.Add("Stt", typeof(string));
      Dt_Rua_Xong.Columns.Add("Stt_Rec", typeof(string));
      Dt_Rua_Xong.Columns.Add("Ma_Ct", typeof(string)); // !HDK,HDP,HDM 
      Dt_Rua_Xong.Columns.Add("Ma_Xe", typeof(string));
      Dt_Rua_Xong.Columns.Add("Ma_Hs", typeof(string));
      Dt_Rua_Xong.Columns.Add("So_RO", typeof(string));

      Dt_Data_Xe.Columns.Add("ID", typeof(Int32));
      Dt_Data_Xe.Columns.Add("Stt", typeof(string));
      Dt_Data_Xe.Columns.Add("Stt_Rec", typeof(string));
      Dt_Data_Xe.Columns.Add("Bold", typeof(string));
      Dt_Data_Xe.Columns.Add("Backcolor", typeof(string));
      Dt_Data_Xe.Columns.Add("Backcolor2", typeof(string));
      Dt_Data_Xe.Columns.Add("Forecolor", typeof(string));
      Dt_Data_Xe.Columns.Add("Ma_Hs", typeof(string));
      Dt_Data_Xe.Columns.Add("So_RO", typeof(string));

      Tables.AddRange(new DataTable[] { Dt_Cho_Rua, Dt_Data, Dt_Dang_Rua, Dt_Rua_Xong, Dt_Data_Xe, Dt_Cho_Rua_H, Dt_Dang_Rua_H, Dt_Rua_Xong_H });
    }
    public static CP_RO_CW_Data CreateData()
    {
      CP_RO_CW_Data ds = new CP_RO_CW_Data();
      DataTable Dt_Data = ds.Tables["Dt_Data"];
      DataTable Dt_Cho_Rua = ds.Tables["Dt_Cho_Rua"];
      DataTable Dt_Dang_Rua = ds.Tables["Dt_Dang_Rua"];
      DataTable Dt_Rua_Xong = ds.Tables["Dt_Rua_Xong"];

      Dt_Data.Rows.Add(new object[] { 
        1, "1", "1", false, null, "12, 23, 78", 0, 1, "29A12345", "1T1", DateTime.Now.Date.Add(new TimeSpan(10, 0, 0)),
        DateTime.Now.Date.Add(new TimeSpan(10, 10, 0)), null, "100010", "S2022052501", null, null, "0,255,128" });
      Dt_Data.Rows.Add(new object[] {
        2, "2", "2", false, null, null, 1, 0, "29A67890", "1T1", DateTime.Now.Date.Add(new TimeSpan(10, 13, 0)),
        DateTime.Now.Date.Add(new TimeSpan(10, 23, 0)), null, "100020", "S2022052502", "1", "2", "0,255,128" });
      Dt_Data.Rows.Add(new object[] {
        3, "3", "3", false, null, null, 1, 1, "29A54321", "2T1", DateTime.Now.Date.Add(new TimeSpan(11, 45, 0)),
        DateTime.Now.Date.Add(new TimeSpan(11, 55, 0)), null, "100010", "S2022052503", "1", "3", "0,255,128" });
      Dt_Data.Rows.Add(new object[] {
        4, "4", "4", false, null, "12, 23, 78", 0, 1, "29A54321", "2T1", DateTime.Now.Date.Add(new TimeSpan(13, 0, 0)),
        DateTime.Now.Date.Add(new TimeSpan(13, 10, 0)), null, "100040", "S2022052504", null, null, "0,255,128" });
      Dt_Data.Rows.Add(new object[] {
        5, "5", "5", false, null, "12, 23, 78", 0, 1, "30H11111", "1T1", DateTime.Now.Date.Add(new TimeSpan(13, 5, 0)),
        DateTime.Now.Date.Add(new TimeSpan(13, 15, 0)), null, "100050", "S2022052505", "1", "1", "0,128,255" });
      Dt_Data.Rows.Add(new object[] {
        6, "6", "6", false, null, "12, 23, 78", 0, 1, "29H22222", "2T1", DateTime.Now.Date.Add(new TimeSpan(13, 15, 0)),
        DateTime.Now.Date.Add(new TimeSpan(13, 23, 0)), null, "100010", "S2022052506", null, null, "0,128,255" });

      Dt_Cho_Rua.Rows.Add(new object[] { 1, "1", "1", "HDK", "29A12345", "100010", "S2022052501" });
      Dt_Cho_Rua.Rows.Add(new object[] { 2, "2", "2", "HDP", "29A67890", "100020", "S2022052502" });
      Dt_Cho_Rua.Rows.Add(new object[] { 3, "3", "3", "HDM", "29A54321", "100010", "S2022052503" });
      Dt_Cho_Rua.Rows.Add(new object[] { 4, "4", "4", "HDK", "29A45678", "100040", "S2022052504" });

      Dt_Dang_Rua.Rows.Add(new object[] { 1, "1", "1", "HDK", "30H11111", "100050", "S2022052505" });
      Dt_Dang_Rua.Rows.Add(new object[] { 2, "2", "2", "HDP", "29H22222", "100010", "S2022052506" });

      Dt_Rua_Xong.Rows.Add(new object[] { 1, "1", "1", "HDK", "30H55555", "100010", "S2022052509" });
      Dt_Rua_Xong.Rows.Add(new object[] { 2, "2", "2", "HDP", "29H66666", "100070", "S2022052510" });
      Dt_Rua_Xong.Rows.Add(new object[] { 3, "3", "3", "HDM", "30M77777", "100020", "S2022052511" });
      Dt_Rua_Xong.Rows.Add(new object[] { 4, "4", "4", "HDK", "30H88888", "100090", "S2022052512" });

      return ds;
    }
  }

  public class CP_RO_CW_Ngay_Ngam_Dinh : DataSet
  {
    public CP_RO_CW_Ngay_Ngam_Dinh()
    {
      DataTable Dt_Set_SCC = new DataTable("Dt_Set_SCC");
      Dt_Set_SCC.Columns.Add("ID", typeof(Int32));
      Dt_Set_SCC.Columns.Add("StartHour", typeof(Int32));
      Dt_Set_SCC.Columns.Add("FinishHour", typeof(Int32));
      Dt_Set_SCC.Columns.Add("StartMINUTE", typeof(Int32));
      Dt_Set_SCC.Columns.Add("FinishMINUTE", typeof(Int32));
      Dt_Set_SCC.Columns.Add("Ngay_LimitInterval_Min", typeof(DateTime));
      Dt_Set_SCC.Columns.Add("Ngay_LimitInterval_Max", typeof(DateTime));
      Dt_Set_SCC.Columns.Add("Ngay_Ct", typeof(DateTime));
      Dt_Set_SCC.Columns.Add("Thu_Bay", typeof(string));
      Dt_Set_SCC.Columns.Add("Chu_Nhat", typeof(string));
      Dt_Set_SCC.Columns.Add("HourWidth", typeof(Int32));
      Dt_Set_SCC.Columns.Add("RowPage", typeof(Int32));

      Tables.AddRange(new DataTable[] { Dt_Set_SCC });
    }
    public static CP_RO_CW_Ngay_Ngam_Dinh CreateData()
    {
      CP_RO_CW_Ngay_Ngam_Dinh ds = new CP_RO_CW_Ngay_Ngam_Dinh();
      DataTable dt = ds.Tables["Dt_Set_SCC"];

      dt.Rows.Add(new object[] { 1, 8, 17, 0, 0, DateTime.Today, DateTime.Today.AddMonths(12), DateTime.Today.AddDays(30), "0", "1", 20, 2 });
      return ds;
    }
  }

  public class CP_RO_CW_Execute : DataSet
  {
    public CP_RO_CW_Execute()
    {
      DataTable Dt = new DataTable("CP_RO_CW_Execute");
      Dt.Columns.Add("ID", typeof(Int32));
      Dt.Columns.Add("Status", typeof(string));
      Dt.Columns.Add("Msg", typeof(string));
      Dt.Columns.Add("Note", typeof(string));

      Tables.AddRange(new DataTable[] { Dt });
    }
    public static CP_RO_CW_Execute CreateData()
    {
      CP_RO_CW_Execute ds = new CP_RO_CW_Execute();
      DataTable dt = ds.Tables["CP_RO_CW_Execute"];

      dt.Rows.Add(new object[] { 1, "Y", "Y", "CuongVM test cyber data" });

      return ds;
    }
  }

  public class CP_RO_CW_Tinh_Hieu_suat : DataSet
  {
    public CP_RO_CW_Tinh_Hieu_suat()
    {
      DataTable Dt = new DataTable("CP_RO_CW_Tinh_Hieu_suat");
      Dt.Columns.Add("ID", typeof(Int32));
      Dt.Columns.Add("VISIBLE", typeof(string));
      Dt.Columns.Add("Hieusuat", typeof(string));
      Dt.Columns.Add("BackColor", typeof(string));
      Dt.Columns.Add("ForeColor", typeof(string));

      Tables.AddRange(new DataTable[] { Dt });
    }
    public static CP_RO_CW_Tinh_Hieu_suat CreateData()
    {
      CP_RO_CW_Tinh_Hieu_suat ds = new CP_RO_CW_Tinh_Hieu_suat();
      DataTable dt = ds.Tables["CP_RO_CW_Tinh_Hieu_suat"];

      dt.Rows.Add(new object[] { 1, "1", "90", "231, 24, 162", "89, 39, 20" });

      return ds;
    }
  }
}