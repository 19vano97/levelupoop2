using Microsoft.Identity.Client;
using TestSQLConnection.DBContext;
using TestSQLConnection.Entity;

internal class Program
{
    private static void Main(string[] args)
    {
        // using (var context = new AccountDBContext())
        // {
        //     var newAccount = new Account
        //     {
        //         Id = Guid.NewGuid().ToString(),
        //         Email = "test2@yopmail.com",
        //         FirstName = "Chel",
        //         LastName = "Gyt",
        //         PasswordHash = "wesdrfi2o34i4321",
        //         EmailConfirm = 1,
        //         CreateDate = DateTime.Now,
        //         ModifyDate = DateTime.Now
        //     };

        //     var lastIdAccountDetails = context.accountDetails
        //                                 .OrderByDescending(ad => ad.CreateDate)
        //                                 .Select(ad => ad.Id)
        //                                 .FirstOrDefault();
            
        //     lastIdAccountDetails++;

        //     var newAccountDetails = new AccountDetails
        //     {
        //         Id = lastIdAccountDetails,
        //         AccountId = newAccount.Id,
        //         CountryId = 2,
        //         WebFormId = 1,
        //         CreateDate = DateTime.Now,
        //         ModifyDate = DateTime.Now
        //     };

        //     context.Add(newAccount);
        //     context.Add(newAccountDetails);
        //     context.SaveChanges();
        // }

        using (var context = new AccountDBContext())
        {
            var account =  context.accountDetails
                            .Join(context.accounts, 
                                adId => adId.AccountId,
                                accId => accId.Id,
                                (adId, accId) => new {adId, accId})
                            .Join(context.countries,
                                adCountryI => adCountryI.adId.CountryId,
                                countryId => countryId.Id,
                                (adCountryI, countryId) => new 
                                {
                                    AccountId = adCountryI.accId.Id,
                                    AccountEmail = adCountryI.accId.Email,
                                    AccountFirstName = adCountryI.accId.FirstName,
                                    AccountLastName = adCountryI.accId.LastName,
                                    AccountCountry = countryId.Name
                                })
                            .ToList();
            
            foreach (var item in account)
            {
                System.Console.Write(item.AccountId);
                System.Console.Write(" | ");
                System.Console.Write(item.AccountEmail);
                System.Console.Write(" | ");
                System.Console.Write(item.AccountCountry);
                System.Console.WriteLine();
            }
        }
    }
}