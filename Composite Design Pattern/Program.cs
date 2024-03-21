
ProductCalalog items = new ProductCalalog("Eşyalar");
ProductCalalog phones = new ProductCalalog("Telefonlar");
ProductCalalog iphone = new ProductCalalog("Iphone telefonlar");
ProductCalalog samsung = new ProductCalalog("Samsung telefonlar");


Product iphone5s = new Product("Iphone 5s");
Product iphoneXs = new Product("Iphone XS");
Product samsungA51 = new Product("Samsung A51");
Product samsungS23 = new Product("Samsung S23");

items.components.Add(phones);

phones.components.Add(iphone);
phones.components.Add(samsung);

iphone.components.Add(iphone5s);
iphone.components.Add(iphoneXs);

samsung.components.Add(samsungA51);
samsung.components.Add(samsungS23);

items.Operation("");

interface ICatalocCompanent
{
    void Operation(string prefix);
}

class Product : ICatalocCompanent
{
    private string _name;

    public Product(string name)
    {
        _name = name;
    }
    public void Operation(string prefix)
    {
        Console.WriteLine( prefix + _name);
    }
}

class ProductCalalog : ICatalocCompanent
{
    private string _name;
    public List<ICatalocCompanent> components = new List<ICatalocCompanent>();

    public ProductCalalog(string name)
    {
        _name = name;
    }

    public void Operation(string prefix)
    {
        Console.WriteLine(prefix + _name);
        foreach(var component in components)
        {
            component.Operation(prefix + " ");
        }
    }
}