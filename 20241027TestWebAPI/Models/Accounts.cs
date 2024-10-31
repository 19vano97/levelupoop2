using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _20241027TestWebAPI.Models;

[Table ("Account")]
public class Accounts
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

    public Accounts(Guid? id)
    {
        Id = id;
    }
}
