public class Singleton
{
    private static Singleton _instance;
    private Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

    public void DisplayMessage()
    {
        Console.WriteLine("Singleton instance is displaying a message.");
    }
}
public class ThreadSafeSingleton
{
    private static readonly object lockObject = new object();
    private static ThreadSafeSingleton _instance;

    private ThreadSafeSingleton()
    {
    }
    public static ThreadSafeSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new ThreadSafeSingleton();
                    }
                }
            }
            return _instance;
        }
    }
    public void DisplayMessage()
    {
        Console.WriteLine("Thread-safe Singleton instance is displaying a message.");
    }
}

class Program
{
    static void Main()
    {
        Singleton singletonInstance1 = Singleton.Instance;
        Singleton singletonInstance2 = Singleton.Instance;
        singletonInstance1.DisplayMessage();
        singletonInstance2.DisplayMessage();
        ThreadSafeSingleton singletonInstance3 = ThreadSafeSingleton.Instance;
        ThreadSafeSingleton singletonInstance4 = ThreadSafeSingleton.Instance;
        singletonInstance3.DisplayMessage();
        singletonInstance4.DisplayMessage();

    }
}