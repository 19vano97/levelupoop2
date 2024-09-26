using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestSQLConnection.Entity;

[Table ("Account")]
public class Account
{
    public string? Id {get; set;}
    public string? Email {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string PasswordHash {get; set;}
    public int EmailConfirm {get; set;}
    public DateTime CreateDate {get; set;}
    public DateTime ModifyDate {get; set;}
}

[Table ("AccountDetails")]
public class AccountDetails
{
    public int? Id {get; set;}
    public string? AccountId {get; set;}
    public int CountryId {get; set;}
    public int WebFormId {get; set;}
    public DateTime CreateDate {get; set;}
    public DateTime ModifyDate {get; set;}
}

[Table ("Country")]
public class Country
{
    public int? Id {get; set;}
    public string? Name {get; set;}
    public DateTime CreateDate {get; set;}
    public DateTime ModifyDate {get; set;}
}

[Table ("WebForm")]
public class WebForm
{
    public int? Id {get; set;}
    public string? Name {get; set;}
    public DateTime CreateDate {get; set;}
    public DateTime ModifyDate {get; set;}
}