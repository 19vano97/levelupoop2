using System;
using System.Collections.Generic;
using System.Data.Entity;
using TestSQLConnection.DBContext;
using TestSQLConnection.Entity;

namespace TestSQLConnection;

public class User
{
    private Guid? _id;
    private string? _email;
    private string _firstName;
    private string _lastName;
    private string _passwordHash;
    private int _emailConfirm;
    private string _country;
    private string _webform;
    private DateTime _createDate;
    private DateTime _modifyDate;

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

    #region Get/Set
        
        public Guid Id
        {
            get => (Guid)_id;
            set => _id = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public string PasswordHash
        {
            get => _passwordHash;
            set => _passwordHash = value;
        }

        public int EmailConfirm
        {
            get => _emailConfirm;
            set => _emailConfirm = value;
        }

        public string Country
        {
            get => _country;
            set => _country = value;
        }

        public string WebForm
        {
            get => _webform;
            set => _webform = value;
        }

        public DateTime CreateDate
        {
            get => _createDate;
            set => _createDate = value;
        }

        public DateTime ModifyDate
        {
            get => _modifyDate;
            set => _modifyDate = value;
        }

    #endregion

    public User(string email)
    {
        GetAccountByEmail(email);
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

            _id = context.accounts.Where(a => a.Email == _email).Select(a => a.Id).FirstOrDefault();
        }
    }

    private void GetAccountByEmail(string email)
    {
        if (!DoesEmailExist(email))
        {
            return;
        }

        _email = email;

        using (var context = new AccountDBContext())
        {
            var account = context.accounts
                            .Include(a => a.accountDetails)
                            .Include(c => c.accountDetails.country)
                            .Include(w => w.accountDetails.webForm)
                            .Where(a => a.Email == _email).First();
          
            _id = account.Id;
            _firstName = account.FirstName;
            _lastName = account.LastName;
            _passwordHash = account.PasswordHash;
            _emailConfirm = account.EmailConfirm;
            _createDate = account.CreateDate;
            _modifyDate = account.ModifyDate;
            _country = account.accountDetails?.country?.Name;
            _webform = account.accountDetails?.webForm?.Name;
        }
    }

    private bool DoesEmailExist(string email)
    {
        using (var context = new AccountDBContext())
        {
            var account = context.accounts.FirstOrDefault(a => a.Email == email);
            
            if (account == null)
            {
                return false;
            }
        }

        return true;
    }

    public void LoginToDesktop(string device, string client)
    {
        using (var context = new AccountDBContext())
        {
            var deviceName = context.devices.FirstOrDefault(d => d.Name == device);
            
            if (deviceName == null)
            {
                deviceName = new Device
                {
                    Name = device,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                };

                context.Add(deviceName);
                context.SaveChanges();

                deviceName = context.devices.FirstOrDefault(d => d.Name == device);
            }            

            var clientName = context.clients.FirstOrDefault(c => c.Name == client);
            
            if (clientName == null)
            {
                return;
            }

            var newSession = new Session
            {
                AccountId = _id,
                ClientId = (int)clientName.Id,
                DeviceId = (int)deviceName.Id,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now
            };

            context.Add(newSession);
            context.SaveChanges();
        }
    }

}
