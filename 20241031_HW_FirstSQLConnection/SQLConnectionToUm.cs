using System;
using System.Data;
using System.Data.SqlClient;

namespace _20241031_HW_FirstSQLConnection;

public sealed class SQLConnectionToUm
{
    //private const string _SQL_CONNECTION_STRING = "Server=192.168.1.102,1433;Database=UserManagement;User Id=dev;Password=P@ssw0rd;TrustServerCertificate=True;";
    private SqlConnectionStringBuilder _con;
    private SqlConnection _connection;
    // private string _ip = "192.168.1.102";
    // private int _port = 1433;
    // private string _dbName = "UserManagement";
    // private string _userId = "dev";
    // private string _password = "P@ssw0rd";
    // private bool _trustCert = true;

    // public SQLConnectionToUm()
    // {
    //     _con = new SqlConnectionStringBuilder();
    //     _con.DataSource = string.Format("{0},{1}", _ip, _port);
    //     _con.InitialCatalog = _dbName;
    //     _con.UserID = _userId;
    //     _con.Password = _password;
    //     _con.TrustServerCertificate = _trustCert;
    // }

    public SQLConnectionToUm(string ip, int port, string dbName, string userId, string password, bool trustCert)
    {
        _con = new SqlConnectionStringBuilder();
        _con.DataSource = string.Format("{0},{1}", ip, port);
        _con.InitialCatalog = dbName;
        _con.UserID = userId;
        _con.Password = password;
        _con.TrustServerCertificate = trustCert;
    }

    public SQLConnectionToUm(SqlConnectionStringBuilder con)
    {
        _con = con;
    }

    public void OpenConnection()
    {
        _connection = new SqlConnection(_con.ToString());
        _connection.Open();
    }

    public void CloseConnection()
    {
        _connection.Dispose();
    }

    // public bool ExecuteSqlCommand(string sqlCommand)
    // {
    //     using (SqlConnection connection = new SqlConnection(_con.ToString()))
    //     {
    //         bool res = true;
    //         connection.Open();

    //         try
    //         {
    //             SqlCommand command = new SqlCommand(sqlCommand, connection);
    //             command.ExecuteNonQuery();                
    //         }
    //         catch (SqlException)
    //         {
    //             System.Console.WriteLine("smth went wrong");
    //             res = false;
    //         }

    //         connection.Close();

    //         return res;
    //     }
    // }

    public bool ExecuteSqlCommand(string sqlCommand)
    {
        
            bool res = true;

            try
            {
                SqlCommand command = new SqlCommand(sqlCommand, _connection);
                command.ExecuteNonQuery();                
            }
            catch (SqlException)
            {
                System.Console.WriteLine("smth went wrong");
                res = false;
            }

            return res;
        
    }

    public object[] ExecuteSqlCommandSelect(string sqlCommand)
    {
        object[] obj = null;

        try
        {
            SqlCommand command = new SqlCommand(sqlCommand, _connection);
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                int index = dataReader.FieldCount;
                obj = new object[index];
                int indexFor = 0;
                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        indexFor++;
                        Array.Resize(ref obj, indexFor);
                        obj[indexFor - 1] = dataReader[i];
                    }
                }
            }

            dataReader.DisposeAsync();
        }
        catch (SqlException)
        {
            System.Console.WriteLine("smth went wrong");
        }

        return obj;
        
    }
}
