using System;

namespace TMV.ObjectInfo.JPCB
{
  public class JpcbLogInfo
  {
    public DateTime LogCreatedTime { get; set; }
    public JbcbLogCode LogCode { get; set; }
    public string LogMsg { get; set; }
    public string LogNote { get; set; }
  }
}