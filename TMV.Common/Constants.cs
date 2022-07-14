namespace TMV.Common
{
  public class Constants
  {
    #region "Constructor"
    private static Constants _instance;
    private static object _syncLock = new object();
    protected Constants()
    {
    }
    public static Constants Instance()
    {
      if (_instance == null)
      {
        lock (_syncLock)
        {
          if (_instance == null)
            _instance = new Constants();
        }
      }
      return _instance;
    }
    protected void Dispose()
    {
      _instance = null;
    }
    #endregion

    #region "Message"
    public string MESSAGE_COPY_SELECT_REQUIRE = "You have to select row to copy.";
    public string MESSAGE_DELETE_CONFIRM = "Are you sure to delete selected row?";
    public string MESSAGE_DELETE_SELECT_REQUIRE = "You have to select row to delete.";
    public string MESSAGE_DELETE_SUCCESS = "Data deleted";
    public string MESSAGE_DUPLICATED_RECORD = "Record duplicated.";
    public string MESSAGE_EDIT_SELECT_REQUIRE = "You have to select row to edit.";
    public string MESSAGE_EXPORT_OPEN_EXCEL_FILE_CONFIRM = "Exported successfully. Do you want to open the file?";
    public string MESSAGE_NO_DATA_FOUND = "No data found";
    public string MESSAGE_PERIOD_CLOSED = "You are not allowed to change data in closed period.";
    public string MESSAGE_SAVE_CONFIRM = "Do you want to save data?";
    public string MESSAGE_SAVE_SUCCESS = "Data saved";
    #endregion

    #region "Auth"
    public string AppAuthPkgTableListField = "AppAuthPkgTableListField";
    public string AppAuthPkgTableGetFieldValue = "AppAuthPkgTableGetFieldValue";
    public string AppAuthPkgTableGetErrorMessage = "AppAuthPkgTableGetErrorMessage";
    public string AppAuthPkgGetById = "AppAuthPkgGetById";
    public string AppAuthPkgUserChangePassword = "AppAuthPkgUserChangePassword";
    public string AppAuthPkgGetByTenant = "AppAuthPkgGetByTenant";
    public string AppAuthPkgGetByTenantAndUser = "AppAuthPkgGetByTenantAndUser";
    public string AppAuthPkgUpdateFailedLogin = "AppAuthPkgUpdateFailedLogin";
    #endregion

    #region "Common"
    public string AppJpcbPkgGetConfigsDefault = "AppJpcbPkgGetConfigsDefault";
    public string AppJpcbPkgGetWorkingTime = "AppJpcbPkgGetWorkingTime";
    public string AppJpcbPkgGetWorkshops = "AppJpcbPkgGetWorkshops";
    public string AppJpcbPkgCalcWorkingTime = "AppJpcbPkgCalcWorkingTime";
    #endregion

    #region "CW"
    public string AppJpcbPkgCWGetConfigs = "AppJpcbPkgCWGetConfigs";
    public string AppJpcbPkgCWGetData = "AppJpcbPkgCWGetData";
    public string AppJpcbPkgCWStartFinish = "AppJpcbPkgCWStartFinish";
    public string AppJpcbPkgCWGetDetail = "AppJpcbPkgCWGetDetail";
    public string AppJpcbPkgCWAddOrUpdate = "AppJpcbPkgCWAddOrUpdate";
    public string AppJpcbPkgCWDeletePlan = "AppJpcbPkgCWDeletePlan";
    public string AppJpcbPkgCWGoback = "AppJpcbPkgCWGoback";
    #endregion

    #region "JP"
    public string AppJpcbPkgJPVisibleTabs = "AppJpcbPkgJPVisibleTabs";
    public string AppJpcbPkgJPGetConfigs = "AppJpcbPkgJPGetConfigs";
    public string AppJpcbPkgJPGetData = "AppJpcbPkgJPGetData";
    public string AppJpcbPkgJPCholapKHSuaxong = "AppJpcbPkgJPCholapKHSuaxong";
    public string AppJpcbPkgJPMolenhGiaoxe = "AppJpcbPkgJPMolenhGiaoxe";
    public string AppJpcbPkgJPDangSuaChua = "AppJpcbPkgJPDangSuaChua";
    public string AppJpcbPkgJPXeDung = "AppJpcbPkgJPXeDung";
    public string AppJpcbPkgJPUpdateKeothaResize = "AppJpcbPkgJPUpdateKeothaResize";
    public string AppJpcbPkgJPConfirmPlan = "AppJpcbPkgJPConfirmPlan";
    public string AppJpcbPkgJPClonePlan = "AppJpcbPkgJPClonePlan";
    public string AppJpcbPkgJPCancelPlan = "AppJpcbPkgJPCancelPlan";
    public string AppJpcbPkgJPCancelPlanProgress = "AppJpcbPkgJPCancelPlanProgress";
    public string AppJpcbPkgJPCheckPlans = "AppJpcbPkgJPCheckPlans";
    #endregion
  }
}