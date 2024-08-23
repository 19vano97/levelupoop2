using System;

namespace _20240823_Lesson_Publisher;

public delegate void NewIterationDelegate(int iteration);

public delegate void NewIterationDelegateEventArgs(object sender, NewiterationEventArgs args);
