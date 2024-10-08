using Microsoft.Identity.Client;
using TestSQLConnection;
using TestSQLConnection.DBContext;
using TestSQLConnection.Entity;

internal class Program
{
    private static void Main(string[] args)
    {
        User u1 = new User(
            "test5@yopmail.com",
            "Zen",
            "Chu",
            "sdfjiopsfo43233",
            "Peru",
            "localhost"
        );

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