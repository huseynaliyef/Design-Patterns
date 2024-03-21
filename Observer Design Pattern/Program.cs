IObserver observer1 = new Observer("Huseyn");
Product productIphone = new Product("Iphone 16", 5600);


IObserver observer2 = new Observer("Mark");
Product productSamsung = new Product("Samsung S24", 5690);


Amazon amazon = new Amazon();
amazon.Subscribe(observer1, productIphone);
amazon.Subscribe(observer2, productSamsung);


amazon.NotifyForProduct("Iphone 16");


public class Product
{
    public string Name { get; set; }
    public Decimal Price { get; set; }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
}

public interface IObserver
{
    public void StockUpdate(Product product);
}


public class Observer : IObserver 
{
    public string Name { get; set;}
    public Observer(string name)
    {
        Name = name;
    }

    public void StockUpdate(Product product)
    {
        Console.WriteLine($"{Name}, {product.Name} in Amazon! Just {product.Price:c}");
    }

}

public class Amazon
{
    private Dictionary<IObserver, Product> list = new Dictionary<IObserver, Product>();


    public void Subscribe(IObserver observer, Product product)
    {
        list.Add(observer, product);
    }

    public void UnSubscribe(IObserver observer)
    {
        list.Remove(observer);
    }

    public void NotifyForProduct(string productName)
    {
        foreach(var p in list)
        {
            if(p.Value.Name == productName)
            {
                p.Key.StockUpdate(p.Value);
            }
        }
    }

    public void NotifyAll()
    {
        foreach(var p in list)
        {
            p.Key.StockUpdate(p.Value);
        }
    }
}