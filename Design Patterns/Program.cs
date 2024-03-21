using System;
using System.Threading;

namespace Design_Patterns
{
    public class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(() =>
                {
                    MyClass o = MyClass.CrateSigltonInstance();
                });
                thread.Start();
            }
        }
    }

    public class MyClass
    {
        private static MyClass obj;
        private MyClass() { }

        static object o = new object();

        public static MyClass CrateSigltonInstance()
        {
            lock (o)
            {
                if(obj == null)
                {
                    obj = new MyClass();
                    Console.WriteLine("Created new instance.");
                }
                else
                    Console.WriteLine("Exist instance.");

                return obj;

            }
        }

    }


}
