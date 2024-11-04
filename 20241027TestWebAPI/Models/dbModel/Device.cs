using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _20241027TestWebAPI.Models.dbModel;

[Table("dbo.Device")]
public class Device
{
    public virtual int Id {get; set;}
    public virtual string Name {get; set;}
    public virtual DateTime CreateDate {get; set;}
    public virtual DateTime ModifyDate {get; set;}
    public virtual Session session {get; set;}
}
