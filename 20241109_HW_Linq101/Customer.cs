using System;
using System.Collections;

namespace _20241109_HW_Linq101;

public class Customer : IEnumerable
{
    public int id;
    public string firstName;
    public string lastName;
    public DateTime createDate;

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
