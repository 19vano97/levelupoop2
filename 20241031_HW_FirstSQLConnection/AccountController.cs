using System;
using System.Data.SqlClient;

namespace _20241031_HW_FirstSQLConnection;

public class AccountController
{
    private Guid _id;
    private string _email;
    private string _firstName;
    private string _lastName;
    private bool _emailConfirm;
    private string _country;
    private Guid _sessionId;
    private SQLConnectionToUm _con;

    #region Get
        public Guid AccountId
        {
            get => _id;
        }
    
        public string Email
        {
            get => _email;
        }
    
        public string FirstName
        {
            get => _firstName;
        }
    
        public string LastName
        {
            get => _lastName;
        }
    
        public bool EmailConfirm
        {
            get => _emailConfirm;
        }
    
        public string Country
        {
            get => _country;
        }
    
        public Guid SessionId
        {
            get => _sessionId;
        }
    #endregion
    
    public AccountController(SQLConnectionToUm con)
    {
        _con = con;
    }

    public void ChooseEmail()
    {
        string sqlCommand = "select Email from dbo.Account";
        object[] emails = _con.ExecuteSqlCommandSelect(sqlCommand);

        int pos = UI.EnterPositionFromCL(emails);

        _email = (string)emails[pos];
    }

    public void GetAccountDetails()
    {
        string sqlCommand = string.Format("SELECT a.Id, a.FirstName, a.LastName, a.EmailConfirm, c.Name FROM dbo.Account a JOIN dbo.AccountDetails ad on ad.AccountId = a.Id JOIN dbo.Country c on c.Id = ad.CountryId WHERE a.Email = '{0}'", _email);
        object[] accountDet = _con.ExecuteSqlCommandSelect(sqlCommand);

        _id = (Guid)accountDet[0];
        _firstName = (string)accountDet[1];
        _lastName = (string)accountDet[2];
        _emailConfirm = Convert.ToBoolean(Convert.ToInt32((int)accountDet[3]));
        _country = (string)accountDet[4];

        System.Console.WriteLine("account details passed");
    }

    public void GetLoggedIn(int clientId, int deviceId)
    {
        string insertSession = string.Format("INSERT INTO dbo.Session ([AccountId], [ClientId], [DeviceId]) VALUES ('{0}', {1}, {2})", _id, clientId, deviceId);

        _con.ExecuteSqlCommand(insertSession);

        string getSession = string.Format("SELECT Id FROM dbo.Session WHERE AccountId = '{0}'", _id);
        object[] getSessionObj = _con.ExecuteSqlCommandSelect(getSession);

        _sessionId = (Guid)getSessionObj[0];
    }

    public void UpdateDetails(string firstName = null, string lastName = null, string email = null)
    {
        if (firstName != null)
        {
            string fistNameUpdate = string.Format("UPDATE dbo.Account SET [FirstName] = '{0}' WHERE Id = '{1}'", firstName, _id);
            _con.ExecuteSqlCommand(fistNameUpdate);
            _firstName = firstName;
        }

        if (lastName != null)
        {
            string lastNameUpdate = string.Format("UPDATE dbo.Account SET [LastName] = '{0}' WHERE Id = '{1}'", lastName, _id);
            _con.ExecuteSqlCommand(lastNameUpdate);
            _lastName = lastName;
        }

        if (email != null)
        {
            string emailUpdate = string.Format("UPDATE dbo.Account SET [Email] = '{0}' WHERE Id = '{1}'", email, _id);
            _con.ExecuteSqlCommand(emailUpdate);
            _email = email;
        }
    }

    public void GetLoggedOut()
    {
        // string logoutSQL = string.Format("DELETE FROM dbo.Session  WHERE Id = '{0}'", _sessionId);
        // _con.ExecuteSqlCommand(logoutSQL);

        SqlCommand deleteSession = new SqlCommand("dbo.GetLoggedOut", _con.Connection);
        deleteSession.CommandType = System.Data.CommandType.StoredProcedure;

        deleteSession.Parameters.Add("@SessionId", System.Data.SqlDbType.UniqueIdentifier).Value = _sessionId;
        deleteSession.ExecuteNonQuery();

        _sessionId = Guid.Empty;
    }

    
}
