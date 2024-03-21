
BaseClass obj1 = new NewClass1();
obj1.TemplateMethod();

BaseClass obj2 = new NewClass2();
obj2.TemplateMethod();


public abstract class BaseClass
{
    public void TemplateMethod()
    {
        Operation1();
        Operation2();
    }

    public abstract void Operation1();
    public abstract void Operation2();
}

public class NewClass1 : BaseClass
{
    public override void Operation1()
    {
        Console.WriteLine($"{GetType().Name}: Operation1 method");
    }

    public override void Operation2()
    {
        Console.WriteLine($"{GetType().Name}: Operation2 method");
    }
}

public class NewClass2 : BaseClass
{
    public override void Operation1()
    {
        Console.WriteLine($"{GetType().Name}: Operation1 method");
    }

    public override void Operation2()
    {
        Console.WriteLine($"{GetType().Name}: Operation2 method");
    }
}
