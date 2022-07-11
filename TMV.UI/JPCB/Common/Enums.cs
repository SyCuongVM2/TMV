namespace TMV.UI.JPCB.Common
{
  public enum ROType : byte
  {
    DS = 1,  // Đồng sơn
    SCC = 2, // Sửa chữa chung
    RX = 3   // Rửa xe
  }

  public enum RPState : byte
  {
    Finished = 0,         // Đã thực hiện
    InProgress = 1,       // Đang thực hiện
    StopAtWS = 2,         // Dừng trong khoang
    StopOutside = 3,      // Dừng ngoài khoang
    Completed = 4,        // Hoàn thành
    Waiting = 5,          // Xe chờ
    AutoQuotation = 6,    // Auto báo giá
    ManualQuotation = 7,  // Manual báo giá
    AutoAppointment = 8,  // Auto phiếu hẹn
    ManualAppoinment = 9, // Manual phiếu hẹn
    Wait2Plan = 10        // Drag from waiting list to plan
  }
}