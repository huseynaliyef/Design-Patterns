
using System.Linq.Expressions;

IComponent truckGame = new Component();


ComponentReadyDecorator truckReadyDecorator = new ComponentReadyDecorator(truckGame);
Console.WriteLine(truckReadyDecorator.Operation());


ComponentStopDecorator truckStopDecorator = new ComponentStopDecorator(truckGame);
Console.WriteLine(truckStopDecorator.Operation());
Console.WriteLine(truckStopDecorator.Stop());




interface IComponent
{
    string Operation();
}

class Component : IComponent
{
    public string Operation()
    {
        return "Starting game..";
    }
}


class ComponentReadyDecorator : IComponent
{
    private IComponent _component;

    public ComponentReadyDecorator(IComponent component)
    {
        _component = component;
    }

    public string Operation()
    {
        string s = "Are you ready ? ";
        return s + _component.Operation();
    }
}

class ComponentStopDecorator : IComponent
{
    private IComponent _component;

    public ComponentStopDecorator(IComponent component)
    {
        _component = component;
    }

    public string Stop()
    {
        return "the game is stopping";
    }

    public string Operation()
    {
        string s = " After 3 minutes the game will stop";
        return _component.Operation() + s;
    }
}


