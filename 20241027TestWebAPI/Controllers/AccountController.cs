using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using _20241027TestWebAPI.Data;
using _20241027TestWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var accountDetails = _context.AccountDetails.Include(a => a.account)
                                                        .Include(c => c.country)
                                                        .Include(w => w.webForm)
                                                        .Where(ad => ad.account.Email == email)
                                                        .Select(ad => new {ad.account.Id, 
                                                            ad.account.FirstName, 
                                                            ad.account.LastName,
                                                            ad.account.EmailConfirm,
                                                            ad.country.Name,
                                                            ad.account.CreateDate}).ToList();

            return Ok(accountDetails);
        }

        [HttpPost("login")]
        public async Task<ActionResult> PostAsync([FromBody] LoginModel login)
        {
            var doesUserExist = _context.Accounts.Where(a => a.Email == login.email && a.PasswordHash == login.password).FirstOrDefault();
            
            if (doesUserExist == null)
            {
                return BadRequest();
            }
        
            return Ok();
        }
    }
}
