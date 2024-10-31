using System.Data.SqlClient;

internal class Program
{
    public const string SQL_CONNECTION_STRING = "Server=192.168.1.102,1433;Database=UserManagement;User Id=dev;Password=P@ssw0rd;TrustServerCertificate=True;";
    
    private static void Main(string[] args)
    {
        using (SqlConnection connection = new SqlConnection(SQL_CONNECTION_STRING))
        {
            
        }
    }
}