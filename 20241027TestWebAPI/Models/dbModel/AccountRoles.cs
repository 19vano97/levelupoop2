using System;

namespace _20241027TestWebAPI.Models;

public class AccountRoles
{
    public virtual int Id {get; set;}
    public virtual Guid AccountId {get; set;}
    public virtual int RoleId {get; set;}
    public virtual DateTime CreateDate {get; set;}
    public virtual DateTime ModifyDate {get; set;}
    public virtual Accounts account {get; set;}
    public virtual Role role {get; set;}
}
