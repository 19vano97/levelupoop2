using System;
using _20241027TestWebAPI.Models.dbModel;

namespace _20241027TestWebAPI.Models;

public class Session
{
    public virtual Guid Id {get; set;}
    public virtual Guid AccountId {get; set;}
    public virtual int ClientId {get; set;}
    public virtual int DeviceId {get; set;}
    public virtual Accounts account {get; set;}
    public virtual Device device {get; set;}
    public virtual Client client {get; set;}
}
