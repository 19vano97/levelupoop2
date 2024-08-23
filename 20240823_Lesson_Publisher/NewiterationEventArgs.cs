using System;

namespace _20240823_Lesson_Publisher;

public class NewiterationEventArgs : EventArgs
{
    public int iteration {get; private set;}
    
    public NewiterationEventArgs(int i)
    {
        iteration = i;
    }
}
