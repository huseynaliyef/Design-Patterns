
IStore car1 = new Car { CarModel = "Mercedes", CarName = "Maybach", Price = 250000 };
IStore car2 = new Car { CarModel = "BMW", CarName = "I7", Price = 500000 };


IStore bike1 = new Bike { BikeModel = "Yamaha", BikeName = "FZS-FI", Price = 18000 };
IStore bike2 = new Bike { BikeModel = "Bajaj", BikeName = "Pulsar 150", Price = 22000 };

car1.Visit(new PriceVisitor());
car2.Visit(new PriceVisitor());
bike1.Visit(new PriceVisitor());
bike2.Visit(new PriceVisitor());


car1.Visit(new WeightVisitor());
car2.Visit(new WeightVisitor());
bike1.Visit(new WeightVisitor());
bike2.Visit(new WeightVisitor());

public interface IStore
{
    public void Visit(IVisitor visitor);
}


public class Car : IStore
{
    public string CarName { get; set; }
    public int Price { get; set; }
    public string CarModel { get; set; }

    public void Visit(IVisitor visitor)
    {
        visitor.Accept(this);
    }
}
public class Bike : IStore
{
    public string BikeName { get; set; }
    public int Price { get; set; }
    public string BikeModel { get; set; }

    public void Visit(IVisitor visitor)
    {
        visitor.Accept(this);
    }
}

public interface IVisitor
{
    public void Accept(Car car);
    public void Accept(Bike bike);
}

public class PriceVisitor : IVisitor
{
    private int CarDiscount = 5;
    private int BikeDescount = 2;
    public void Accept(Car car)
    {
        var DicountPrice = car.Price - (car.Price / 100) * CarDiscount;
        Console.WriteLine($"{car.CarName} real price is : {car.Price}. Didcount price is : {DicountPrice}");
    }

    public void Accept(Bike bike)
    {
        var DicountPrice = bike.Price - (bike.Price / 100) * BikeDescount;
        Console.WriteLine($"{bike.BikeName} real price is : {bike.Price}. Didcount price is : {DicountPrice}");
    }
}

public class WeightVisitor : IVisitor
{
    public void Accept(Car car)
    {
        switch (car.CarModel)
        {
            case "Mercedes":
                Console.WriteLine($"Weight of {car.CarModel} {car.CarName} is 2000 KG");
                break;
            case "BMW":
                Console.WriteLine($"Weight of {car.CarModel} {car.CarName} is 1800 KG");
                break;
            default:
                Console.WriteLine("Undefined!");
                break;
        }
    }

    public void Accept(Bike bike)
    {
        switch (bike.BikeModel)
        {
            case "Yamaha":
                Console.WriteLine($"Weight of {bike.BikeModel} {bike.BikeName} is 70 KG");
                break;
            case "Bajaj":
                Console.WriteLine($"Weight of {bike.BikeModel} {bike.BikeName} is 50 KG");
                break;
            default:
                Console.WriteLine("Undefined!");
                break;
        }
    }
}