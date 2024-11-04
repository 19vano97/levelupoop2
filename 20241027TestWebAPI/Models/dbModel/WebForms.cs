using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _20241027TestWebAPI.Models;

[Table ("WebForm")]
public class WebForms
{
    public virtual int? Id {get; set;}
    public virtual string? Name {get; set;}
    public virtual AccountDetails accountDetails {get; set;}
    public virtual DateTime CreateDate {get; set;}
    public virtual DateTime ModifyDate {get; set;}
}
