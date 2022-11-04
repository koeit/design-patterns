namespace Singleton;

public class Single
{
    private static Single? _instance;

    // protected member can be accessed within it's class and from instances of derived class
    protected Single()
    {
    }

    public static Single Instance()
    {
        // is not thread safe
        if (_instance == null)
        {
            _instance = new Single();
        }

        return _instance;
    }
}
public class SingleThreadSafe
{
    private static SingleThreadSafe? _instance;
    private static readonly object Locker = new object();
    
    protected SingleThreadSafe()
    {
    }
    
    public static SingleThreadSafe Instance()
    {
        lock (Locker)
        {
            if (_instance == null)
            {
                _instance = new SingleThreadSafe();
            }
        }

        return _instance;
    }
}

internal static class Program
{
    private static void Main()
    {
        var s1 = SingleThreadSafe.Instance();
        var s2 = SingleThreadSafe.Instance();
        
        // check same instance
        if (s1 == s2)
        {
            Console.WriteLine("Objects are the same instance");
        }
        
        Console.ReadKey();
    }
}