using System.Data.SqlClient;
using _20241031_HW_FirstSQLConnection;

internal class Program
{    
    private static void Main(string[] args)
    {
        AccountController a1 = new AccountController();

        a1.ChooseEmail();
        a1.GetAccountDetails();
        a1.GetLoggedIn(4, 3);

        UI.ShowAccountDetails(a1);
    }
}