namespace ConcurrentDS;

public class ConcurrentCounter
{
    private int _counter = 0;
    private readonly Lock _locker = new Lock();

    public void Increment()
    {
        lock (_locker)
        {
            _counter++;
        }
    }

    public int GetCount()
    {
        lock (_locker)
        {
            return _counter;
        }
    }
}