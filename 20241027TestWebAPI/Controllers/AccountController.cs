using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using _20241027TestWebAPI.Data;
using _20241027TestWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _20241027TestWebAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountDbContext _context;

        public AccountController(AccountDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accounts>>> GetAccounts()
        {
            var getAccounts = _context.Accounts.Select(a => a.Email).ToList();

            return Ok(getAccounts);
        }

        [HttpGet("details/{email}")]
        public async Task<ActionResult<IEnumerable<Accounts>>> GetAccountDetailsAsync(string email)
        {
            var accountDetails = new AccountDetails();
            var accountDetailsId = new SqlParameter("@AccountDetailsId", SqlDbType.Int) { Direction = ParameterDirection.Output };
            var accountId = new SqlParameter("@AccountId", SqlDbType.UniqueIdentifier) { Direction = ParameterDirection.Output };
            var emailParam = new SqlParameter("@Email", email);
            var firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };
            var lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };
            var emailConfirmParam = new SqlParameter("@EmailConfirm", SqlDbType.Int) { Direction = ParameterDirection.Output };
            var countryParam = new SqlParameter("@Country", SqlDbType.Int) { Direction = ParameterDirection.Output };
            var webFormParam = new SqlParameter("@WebForm", SqlDbType.Int) { Direction = ParameterDirection.Output };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.GetAccountDetails @Email, @AccountDetails OUTPUT, @AccountId OUTPUT, @FirstName OUTPUT, @LastName OUTPUT, @EmailConfirm OUTPUT, @Country OUTPUT, @WebForm OUTPUT",
                emailParam, accountDetailsId, accountId, firstNameParam, lastNameParam, emailConfirmParam, countryParam, webFormParam);

            accountDetails.AccountId = (Guid)accountId.Value;
            accountDetails.Id = (int)accountDetailsId.Value;
            accountDetails.account.FirstName = (string)firstNameParam.Value;
            accountDetails.account.LastName = (string)lastNameParam.Value;
            accountDetails.account.EmailConfirm = (int)emailConfirmParam.Value;
            accountDetails.CountryId = (int)countryParam.Value;
            accountDetails.WebFormId = (int)webFormParam.Value;

            // var accountDetails = new AccountDetails((int)accountDetailsId.Value, (Guid)accountId.Value, (int)countryParam.Value, (int)webFormParam.Value);
            // accountDetails.account.FirstName = (string)firstNameParam.Value;
            // accountDetails.account.LastName = (string)lastNameParam.Value;

            // TODO: needs to avoid SPs. Remove it

            return Ok(accountDetails);
        }
    }
}
