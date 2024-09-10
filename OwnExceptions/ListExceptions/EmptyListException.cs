using System;

namespace _ListException;

public class EmptyListExceptions : System.Exception
{
    public EmptyListExceptions() {}
    public EmptyListExceptions(string message) : base(message) {}
    public EmptyListExceptions(string message, System.Exception inner) : base(message, inner) {}
    public EmptyListExceptions(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
}