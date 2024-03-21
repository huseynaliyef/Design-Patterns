using System.Text;

Car CarOriginal = new Car("BMW", "F30", 2016, new List<string> { "Manual", "1415 – 1820 kg", "248hp" });
Console.WriteLine(CarOriginal.ToString());

Car CarClone = (Car)CarOriginal.Clone();
Console.WriteLine(CarClone.ToString());

public interface Prototype
{
    public object Clone();
}

public class Car : Prototype
{

    public string Model { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public List<string> Options { get; set; }

    public Car(string model, string name, int year, List<string> options)
    {
        Model = model;
        Name = name;
        Year = year;
        Options = options;
    }

    public override string ToString()
    {
        StringBuilder options = new StringBuilder();
        foreach (var option in Options)
        {
            options.Append("[" + option + ']');
        }
        return $"Model: {Model}  Name: {Name}  Year: {Year}  Options: {options}";
    }
    public object Clone()
    {
        return new Car(Model, Name, Year, new List<string>(Options));
    }

}
