using System;
using _20241226_HW_Threading.Handlers;
using _20241226_HW_Threading.Interfaces;
using _20241226_HW_Threading.Publisher;

namespace _20241226_HW_Threading.Model;

public abstract class SortDoubleArray
{
    protected double[] _doubles;
    protected DateTime _startTime;
    protected DateTime _endTime;
    protected EventHandler<IterationDateTimeEventArgs> _startTimeEvent;
    protected EventHandler<IterationDateTimeEventArgs> _endTimeEvent;
    protected EventHandler<DifferenceInTimeEventArgs> _differenceInTime;
    protected MessageTimeHandler _messageTimeDisplayed;
    protected EventHandler<IterationEventArgs> _iterationEvent;
    protected IterationHandler _iterationDisplayed;
    protected ILogger _logger;

    public SortDoubleArray(double[] doubles, ILogger logger)
    {
        _doubles = (double[])doubles.Clone();
        _messageTimeDisplayed = new MessageTimeHandler(new Views.UI());
        _logger = logger;
        _iterationDisplayed = new IterationHandler(_logger);
        _messageTimeDisplayed.Subscribe(this);
        _iterationDisplayed.Subscribe(this);
    }

    public SortDoubleArray(double[] doubles)
    {
        _doubles = (double[])doubles.Clone();
        _messageTimeDisplayed = new MessageTimeHandler(new Views.UI());
        _messageTimeDisplayed.Subscribe(this);
    }

    public DateTime StartTime
    {
        get => _startTime;
    }

    public DateTime EndTime
    {
        get => _endTime;
    }

    public event EventHandler<IterationDateTimeEventArgs> StartTimePublisher
    {
        add => _startTimeEvent += value;
        remove => _startTimeEvent -= value;
    }

    public event EventHandler<IterationDateTimeEventArgs> EndTimePublisher
    {
        add => _endTimeEvent += value;
        remove => _endTimeEvent -= value;
    }

    public event EventHandler<DifferenceInTimeEventArgs> DifferenceInTime
    {
        add => _differenceInTime += value;
        remove => _differenceInTime -= value;
    }

    public event EventHandler<IterationEventArgs> IterationEvent
    {
        add => _iterationEvent += value;
        remove => _iterationEvent -= value;
    }

    public virtual void Run()
    {
        _startTime = DateTime.Now;
        //_startTimeEvent?.Invoke(this, new IterationDateTimeEventArgs(_startTime));

        Sort();

        _endTime = DateTime.Now;
        //_endTimeEvent?.Invoke(this, new IterationDateTimeEventArgs(_endTime));

        _differenceInTime?.Invoke(this, new DifferenceInTimeEventArgs(_startTime, _endTime));
    }

    protected abstract void Sort();
}
