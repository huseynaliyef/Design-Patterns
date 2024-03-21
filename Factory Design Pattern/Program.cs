FactoryVehicle factory = new FactoryVehicle();

IVehicle car = factory.CreateVehicle("Car");
car.Manifature();

IVehicle bike = factory.CreateVehicle("Bike");
bike.Manifature();

IVehicle truck = factory.CreateVehicle("Truck");
truck.Manifature();



public interface IVehicle
{
    void Manifature();
}

public class Car : IVehicle
{
    public void Manifature()
    {
        Console.WriteLine("Car is being manifactured.");
    }
}

public class Bike : IVehicle
{
    public void Manifature()
    {
        Console.WriteLine("Bike is being manifactured.");
    }
}

public class Truck : IVehicle
{
    public void Manifature()
    {
        Console.WriteLine("Truck is being manifactured.");
    }
}


public class FactoryVehicle
{
    public IVehicle CreateVehicle(string type)
    {
        switch (type)
        {
            case "Car":
                return new Car();
            case "Bike":
                return new Bike();
            case "Truck":
                return new Truck();
            default:
                throw new ArgumentException("Invalid Type Vehicle: " + type);
        }
    }
}