using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestSQLConnection.Entity;

[Table ("Account")]
public class Account
{
    public virtual Guid? Id {get; set;}
    public virtual string? Email {get; set;}
    public virtual string FirstName {get; set;}
    public virtual string LastName {get; set;}
    public virtual string PasswordHash {get; set;}
    public virtual int EmailConfirm {get; set;}
    public virtual AccountDetails accountDetails {get; set;}
    public virtual DateTime CreateDate {get; set;}
    public virtual DateTime ModifyDate {get; set;}
}

[Table ("AccountDetails")]
public class AccountDetails
{
    public virtual int? Id {get; set;}
    public virtual Guid? AccountId {get; set;}
    public virtual int CountryId {get; set;}
    public virtual int WebFormId {get; set;}
    public virtual Account account {get; set;}
    public virtual Country country {get; set;}
    public virtual WebForm webForm {get; set;}
    public virtual DateTime CreateDate {get; set;}
    public virtual DateTime ModifyDate {get; set;}
}

[Table ("Country")]
public class Country
{
    public virtual int? Id {get; set;}
    public virtual string? Name {get; set;}
    public virtual AccountDetails accountDetails {get; set;}
    public virtual DateTime CreateDate {get; set;}
    public virtual DateTime ModifyDate {get; set;}
}

[Table ("WebForm")]
public class WebForm
{
    public virtual int? Id {get; set;}
    public virtual string? Name {get; set;}
    public virtual AccountDetails accountDetails {get; set;}
    public virtual DateTime CreateDate {get; set;}
    public virtual DateTime ModifyDate {get; set;}
}