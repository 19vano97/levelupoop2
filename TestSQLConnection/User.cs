using System;
using TestSQLConnection.DBContext;
using TestSQLConnection.Entity;

namespace TestSQLConnection;

public class User
{
    private string? _id {get; set;}
    private string? _email {get; set;}
    private string _firstName {get; set;}
    private string _lastName {get; set;}
    private string _passwordHash {get; set;}
    private int _emailConfirm {get; set;}
    private string _country {get; set;}
    private string _webform {get; set;}
    private DateTime _createDate {get; set;}
    private DateTime _modifyDate {get; set;}

    public User(string email, string FirstName, string LastName, string PasswordHash, string Country, string WebForm)
    {
        _email = email;
        _firstName = FirstName;
        _lastName = LastName;
        _passwordHash = PasswordHash;
        _emailConfirm = 0;
        _country = Country;
        _webform = WebForm;
        _createDate = DateTime.Now;
        _modifyDate = DateTime.Now;

        CreateUserInDb();
    }

    private void CreateUserInDb()
    {
        using (var context = new AccountDBContext())
        {

            var getCountryId = context.countries
                                .Where(c => c.Name == _country)
                                .FirstOrDefault();
            
            var getWebformId = context.webForms
                                .Where(w => w.Name == _webform)
                                .FirstOrDefault();

            var newAccount = new Account
            {
                Email = _email,
                FirstName = _firstName,
                LastName = _lastName,
                PasswordHash = _passwordHash,
                EmailConfirm = _emailConfirm,
                accountDetails = new AccountDetails
                {
                    AccountId = context.accounts.Where(a => a.Email == _email).Select(a => a.Id).FirstOrDefault(),
                    CountryId = (int)getCountryId.Id,
                    WebFormId = (int)getWebformId.Id,
                    country = getCountryId!,
                    webForm = getWebformId!,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                },
                CreateDate = _createDate,
                ModifyDate = _modifyDate
            };

            context.Add(newAccount);
            context.SaveChanges();
        }
    }

    public void UpdateEmail(string email)
    {
        
    }

}
