public class Timer
{
    private int tickCount;
    private int interval;

    public event TimeChangedEventHandler TimeChanged;

    public Timer(int tickCount, int interval)
    {
        this.tickCount = tickCount;
        this.interval = interval;
    }

    public int TickCount
    {
        get
        {
            return tickCount;
        }
    }

    public int Interval
    {
        get
        {
            return interval;
        }
    }

    protected void OnTimeChanged(int tick)
    {
        if (TimeChanged != null)
        {
            TimeChangedEventArgs args = new TimeChangedEventArgs(tick);
            TimeChanged(this, args);
        }
    }

    public void Run()
    {
        int tick = tickCount;
        while (tick > 0)
        {
            System.Threading.Thread.Sleep(interval);
            tick--;
            OnTimeChanged(tick);
        }
    }
}
