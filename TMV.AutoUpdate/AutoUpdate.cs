using System;
using System.IO;
using System.Net;
using System.Data;
using TMV.DataAccess;
using System.Collections;
using TMV.Common.Forms;
using System.Windows.Forms;

namespace TMV.AutoUpdate
{
  public class AutoUpdate
  {
    private static string m_RemotePath = string.Empty;
    private static string m_UpdateFileName = "AutoUpdate.csv";
    private static string m_ErrorMessage = "Tự động nâng cấp phiên bản xảy ra lỗi. Chương trình sẽ tiếp tục chạy với phiên bản cũ";
    private const string m_ErrorConnectTimeOut = "Không tìm được máy chủ";
    private const string m_BeginUpdate = "Bắt đầu quá trình Update";
    private const string m_EndUpdate = "Kết thúc quá trình Update";
    private const string m_NotUpdate = "Không có phiên bản mới, ngừng quá trình Update";
    private static bool Ret = false;

    public static string RemotePath
    {
      get { return m_RemotePath; }
      set { m_RemotePath = value; }
    }

    public static string UpdateFileName
    {
      get { return m_UpdateFileName; }
      set { m_UpdateFileName = value; }
    }

    public static string ErrorMessage
    {
      get { return m_ErrorMessage; }
      set { m_ErrorMessage = value; }
    }

    public static bool UpdateFiles(string p_RemotePath)
    {
      //Read Remote Host path param
      GetRemotePath();

      if (p_RemotePath.Length == 0)
        p_RemotePath = m_RemotePath;
      else
        m_RemotePath = p_RemotePath;

      if (p_RemotePath == null || p_RemotePath.Length == 0)
        return false;

      frmProgress.Instance().Thread = new MethodInvoker(UpdateFile);
      frmProgress.Instance().Show_Progress("Tìm kiếm phiên bản cập nhật", "Kết thúc quá trình cập nhật");

      return Ret;
    }

    public static void UpdateFile()
    {
      const string ToDeleteExtension = ".ToDelete";
      const string ToDelete = "*.ToDelete";
      string RemoteUrl = RemotePath + "/";
      WebClient MyWebClient = new WebClient();

      try
      {
        //try to delete old files if exist
        string[] filePaths = Directory.GetFiles(Application.StartupPath, ToDelete);
        foreach (string filePath in filePaths)
        {
          try
          {
            File.Delete(filePath);
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }

        string versionServer = string.Empty;

        //get the update file content in server
        string serverContent = MyWebClient.DownloadString(RemoteUrl + UpdateFileName);

        //get version app 
        string[] tempServerContent = serverContent.Split(new char[] { ';' });
        if (tempServerContent.Length > 1)
        {
          versionServer = tempServerContent[0].ToString().Trim();
          serverContent = tempServerContent[1].ToString().Trim();
        }

        Hashtable h_server = putFileListInHashtable(serverContent);

        //get the update file content at client
        string clientContent = GetFileContents(string.Format("{0}\\{1}", Application.StartupPath, UpdateFileName));

        string[] tempClientContent = clientContent.Split(new char[] { ';' });
        if (tempClientContent.Length > 1)
        {
          //versionClient = tempClientContent(0).ToString.Trim
          clientContent = tempClientContent[1].ToString().Trim();
        }

        Hashtable h_client = putFileListInHashtable(clientContent);

        //Them 1 bien dem de thay vao khi update qua nhanh nen co 2 file cung chung TempFileName
        int i = 1;

        //Process the autoupdate
        bool isToUpgrade = false;
        //Use For Each loop over the Hashtable.
        foreach (DictionaryEntry sElement in h_server)
        {
          //if the name is correct and it is a new version
          string TempFileName = string.Format("{0}\\{1}", Application.StartupPath, System.DateTime.Now.TimeOfDay.Milliseconds);
          string FileName = string.Format("{0}\\{1}", Application.StartupPath, sElement.Key.ToString().Trim());
          //Dim FileExists As Boolean = File.Exists(FileName)

          if (h_client.ContainsKey(sElement.Key))
          {
            if (Convert.ToInt64(GetVersion(sElement.Value.ToString())) > Convert.ToInt64(GetVersion(h_client[sElement.Key].ToString())))
            {
              //download the new file
              MyWebClient.DownloadFile(RemoteUrl + sElement.Key, TempFileName);
              //rename the existent file to be deleted in the future

              if (File.Exists(FileName))
              {
                if (File.Exists(TempFileName + ToDeleteExtension))
                {
                  File.Move(FileName, string.Format("{0}add{1}{2}", TempFileName, i, ToDeleteExtension));
                  i += 1;
                }
                else
                  File.Move(FileName, TempFileName + ToDeleteExtension);
              }

              //File.Move(FileName, TempFileName & ToDeleteExtension)
              //rename the downloaded file to the real name
              File.Move(TempFileName, FileName);
              isToUpgrade = true;
            }
          }
          else
          {
            //check folder is exists or not, if not create new folder
            string newFolder = Path.GetDirectoryName(FileName);
            if ((!Directory.Exists(newFolder)))
              System.IO.Directory.CreateDirectory(newFolder);

            //download the new file
            MyWebClient.DownloadFile(RemoteUrl + sElement.Key, FileName);

            //WriteLog(LogLevel.INFO, "AddNew: " & FileName)
            isToUpgrade = true;
          }
        }

        if (isToUpgrade)
        {
          string UpdateTempFileName = string.Format("{0}\\{1}", Application.StartupPath, System.DateTime.Now.TimeOfDay.Milliseconds);
          //download new AutoUpdate.csv file
          MyWebClient.DownloadFile(RemoteUrl + m_UpdateFileName, UpdateTempFileName);
          //rename the existent file to be deleted in the future
          File.Move(m_UpdateFileName, UpdateTempFileName + ToDeleteExtension);
          //rename the downloaded file to the real name
          File.Move(UpdateTempFileName, m_UpdateFileName);

          //call the new version
          string command = string.Join(" ", Environment.GetCommandLineArgs());
          System.Diagnostics.Process.Start(Application.ExecutablePath, command);
          Ret = true;
        }
      }
      catch (Exception ex)
      {
        Ret = false;
        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private static string GetVersion(string Version)
    {
      string[] x = Version.Split(new char[] { '.' });
      return string.Format("{0:00000}{1:00000}{2:00000}{3:00000}", Convert.ToInt32(x[0]), Convert.ToInt32(x[1]), Convert.ToInt32(x[2]), Convert.ToInt32(x[3]));
    }

    public static string GetFileContents(string FullPath)
    {
      string strContents = string.Empty;
      StreamReader objReader;
      try
      {
        objReader = new StreamReader(FullPath);
        strContents = objReader.ReadToEnd();
        objReader.Close();
        return strContents;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return strContents;
    }

    public static Hashtable putFileListInHashtable(string contentFile)
    {
      string content;
      string[] info;
      Hashtable h_Table = new Hashtable();
      try
      {
        content = contentFile.Replace((char)Keys.LineFeed, ' ');
        string[] FileList = content.Split(new char[] { (char)Keys.Return });
        content = string.Empty;
        // Remove all comments and blank lines
        foreach (string file1 in FileList)
        {
          string file = file1;
          if (file.IndexOf("'") != -1)
            file = file.Substring(0, file.IndexOf("'") - 1);

          if (file.Trim().Length > 0)
          {
            if (content.Length > 0)
              content += (char)Keys.Return;
            content += file.Trim();
          }
        }
        // rebuild the file list
        FileList = content.Split(new char[] { (char)Keys.Return });

        //Put file name and version into Hashtable
        foreach (string file in FileList)
        {
          info = file.Split(new char[] { ',' });
          h_Table.Add(info[0], info[1]);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return h_Table;
    }

    public static void GetRemotePath()
    {
      try
      {
        const string sql = "select item_value from app_master_domain where upper(domain_code) = upper('AUTO_UPDATE')";
        DataTable dt = GetDataFromSQL(sql);

        if (dt == null)
          AutoUpdate.RemotePath = string.Empty;
        else
          AutoUpdate.RemotePath = checkNull(dt.Rows[0][0]);

      }
      catch (Exception ex)
      {
        AutoUpdate.RemotePath = string.Empty;
        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public static DataTable GetDataFromSQL(string _SQL)
    {
      return SqlDataAccess.ExecuteDataset(SqlConnect.ConnectionString, CommandType.Text, _SQL).Tables[0];
    }

    static string checkNull(object variable)
    {
      if (variable is System.DBNull)
        return (string.Empty);
      else
        return (variable.ToString());
    }
  }
}