using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using TMV.Common;

namespace TMV.DataAccess
{
  public class SqlConnect
  {
    // Fields
    private static string _ConnectionString;
    private static string _ErrDescription;
    private static Dictionary<int, SqlTransaction> m_lstTransaction = new Dictionary<int, SqlTransaction>();
    private static Random m_rndTransaction = new Random(1);

    // Methods
    public static int BeginTransaction(string sKey)
    {
      sKey = "ConnectSQL";
      SqlConnection connection = new SqlConnection(GetConnectionString(sKey));
      connection.Open();
      SqlTransaction transaction = connection.BeginTransaction();
      int key = m_rndTransaction.Next();
      m_lstTransaction.Add(key, transaction);
      return key;
    }
    public static bool CommitTransaction(int _TransactionID)
    {
      bool flag;
      try
      {
        SqlTransaction transactionFromID = GetTransactionFromID(_TransactionID);
        transactionFromID.Commit();

        if (transactionFromID.Connection != null)
          transactionFromID.Connection.Close();

        transactionFromID.Dispose();
        m_lstTransaction.Remove(_TransactionID);
        flag = true;
      }
      catch (Exception ex)
      {
        _ErrDescription = ex.Message;
        flag = false;
        return flag;
      }
      return flag;
    }
    public static object GetConnectInfo(int _TransactionID)
    {
      if (!m_lstTransaction.ContainsKey(_TransactionID))
        return ConnectionString;

      return m_lstTransaction[_TransactionID];
    }
    public static string GetConnectionString(string sKey)
    {
      return ConfigurationManager.AppSettings[sKey];
    }
    private static SqlTransaction GetTransactionFromID(int transactionID)
    {
      if (!m_lstTransaction.ContainsKey(transactionID))
        throw new Exception("Invalid transaction ID");

      return m_lstTransaction[transactionID];
    }
    public static bool RollbackTransaction(int _TransactionID)
    {
      bool flag;
      try
      {
        SqlTransaction transactionFromID = GetTransactionFromID(_TransactionID);
        transactionFromID.Rollback();

        if (transactionFromID.Connection != null)
          transactionFromID.Connection.Close();

        transactionFromID.Dispose();
        m_lstTransaction.Remove(_TransactionID);
        flag = true;
      }
      catch (Exception ex)
      {
        _ErrDescription = ex.Message;
        flag = false;
        return flag;
      }
      return flag;
    }

    // Properties
    public static string ConnectionString
    {
      get
      {
        if (!string.IsNullOrEmpty(_ConnectionString))
          return _ConnectionString;

        string conn = ConfigurationManager.AppSettings["ConnectSQL"];
        //string encodedConn = AppSecurity.Base64Encode("Server=(local);Database=tmss_v1;User Id=sa;Password=Abc!23$5;"); // U2VydmVyPShsb2NhbCk7RGF0YWJhc2U9dG1zc192MTtVc2VyIElkPXNhO1Bhc3N3b3JkPUFiYyEyMyQ1Ow==
        //string encodedConn = AppSecurity.Base64Encode("Server=tcp:14.225.20.45,1433;Database=tmss_dev;User Id=tmss_dev;Password=BQ*g6Fty^oI6adyyeo%W27bNl$D!%8iD;"); // U2VydmVyPXRjcDoxNC4yMjUuMjAuNDUsMTQzMztEYXRhYmFzZT10bXNzX2RldjtVc2VyIElkPXRtc3NfZGV2O1Bhc3N3b3JkPUJRKmc2RnR5Xm9JNmFkeXllbyVXMjdiTmwkRCElOGlEOw==
        //string encodedConn = AppSecurity.Base64Encode("Server=tcp:14.225.20.46,1433;Database=tmss_test_20210808;User Id=testenv;Password=hhwk2mpChhhX9ww8KNeDcckWwkPdUr9HU3wz99vSsDdDHUVXz3pCSyF2xWR75rRF;"); // U2VydmVyPXRjcDoxNC4yMjUuMjAuNDYsMTQzMztEYXRhYmFzZT10bXNzX3Rlc3RfMjAyMTA4MDg7VXNlciBJZD10ZXN0ZW52O1Bhc3N3b3JkPWhod2sybXBDaGhoWDl3dzhLTmVEY2NrV3drUGRVcjlIVTN3ejk5dlNzRGRESFVWWHozcENTeUYyeFdSNzVyUkY7
        string decodedConn = AppSecurity.Base64Decode(conn);
        return decodedConn;
      }
      set
      {
        _ConnectionString = value;
      }
    }
    public static string ErrDescription
    {
      get
      {
        return _ErrDescription;
      }
      set
      {
        _ErrDescription = value;
      }
    }
  }
}