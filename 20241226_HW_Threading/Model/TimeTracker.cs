using System;
using _20241226_HW_Threading.Handlers;
using _20241226_HW_Threading.Publisher;

namespace _20241226_HW_Threading.Model;

public class TimeTracker
{
    public EventHandler<IterationDateTimeEventArgs> startTimeEvent;
    public EventHandler<IterationDateTimeEventArgs> endTimeEvent;
    public MessageTimeHandler messageTimeDisplayed;

    public TimeTracker()
    {
       messageTimeDisplayed = new MessageTimeHandler(new Views.UI());
       messageTimeDisplayed.Subscribe(this);
    }

    public void On()
    {
        startTimeEvent?.Invoke(this, new IterationDateTimeEventArgs(DateTime.Now));
    }

    public void Off()
    {
        endTimeEvent?.Invoke(this, new IterationDateTimeEventArgs(DateTime.Now));
    }
}
