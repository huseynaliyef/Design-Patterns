for(int i = 0; i < 10; i++)
{
    Thread thread = new Thread(() =>
    {
        MyClass obj = MyClass.CreateInstance();
    });
    thread.Start();
}

public class MyClass
{
    private static MyClass instance;
    private MyClass(){}
    static object obj = new object();

    public static MyClass CreateInstance()
    {
        lock (obj)
        {
            if (instance == null)
            {
                instance = new MyClass();
                Console.WriteLine("New Instance");
                return instance;
            }
            else
            {
                Console.WriteLine("Exist Instance");
                return instance;
            }
        }
    }
}
