using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _20241027TestWebAPI.Models;

[Table ("AccountDetails")]
public class AccountDetails
{
    public virtual int? Id {get; set;}
    public virtual Guid? AccountId {get; set;}
    public virtual int CountryId {get; set;}
    public virtual int WebFormId {get; set;}
    public virtual Accounts account {get; set;}
    public virtual Country country {get; set;}
    public virtual WebForms webForm {get; set;}
    public virtual DateTime CreateDate {get; set;}
    public virtual DateTime ModifyDate {get; set;}

    // public AccountDetails(int id, Guid accountId, int countryId, int webFormId)
    // {
    //     Id = id;
    //     AccountId = accountId;
    //     CountryId = countryId;
    //     WebFormId = webFormId;
    //     account = new Accounts(AccountId);
    //     country = new Country(CountryId);
    //     webForm = new WebForms(WebFormId);
    // }
}
