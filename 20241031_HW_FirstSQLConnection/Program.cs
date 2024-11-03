using System.Data.SqlClient;
using System.Security.AccessControl;
using _20241031_HW_FirstSQLConnection;

internal class Program
{    
    private static void Main(string[] args)
    {
        string ip = "192.168.1.101";
        int port = 1433;
        string dbName = "UserManagement";
        string userId = "dev";
        string password = "P@ssw0rd";
        bool trustCert = true;

        SQLConnectionToUm con = new SQLConnectionToUm(ip, port, dbName, userId, password, trustCert);
        con.OpenConnection();

        AccountController a1 = new AccountController(con);

        a1.ChooseEmail();
        a1.GetAccountDetails();
        a1.GetLoggedIn(4, 3);
        a1.UpdateDetails(lastName: "UpdatedLastName");
        a1.GetLoggedOut();

        UI.ShowAccountDetails(a1);

        con.CloseConnection();
    }
}