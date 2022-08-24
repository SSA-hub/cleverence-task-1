namespace MyServer;

public static class Server
{
    private static int _count;
    private static readonly ReaderWriterLockSlim Locker= new();

    public static void AddToCount(int value)
    {
        Interlocked.Add(ref _count, value);
    }

    public static int GetCount()
    {
        Locker.EnterReadLock();
        try
        {
            return _count;
        }
        finally
        {
            Locker.ExitReadLock();
        }
    }
}