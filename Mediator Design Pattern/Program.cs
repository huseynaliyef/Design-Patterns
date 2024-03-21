var cab1 = new Cab("Jhon", 15, true);
var cab2 = new Cab("Florid", 15, true);

var passanger1 = new Passanger("Mark", "New york, Street213", 11);
var passanger2 = new Passanger("Kate", "New york, Street225", 13);


var callCenter = new CallCenter();
callCenter.RegisterCab(cab1);
callCenter.RegisterCab(cab2);

callCenter.BookCap(passanger1);
callCenter.BookCap(passanger2);


public interface ICab
{
    string Name { get; }
    int Location {  get; }
    bool IsFree {  get; }

    void AssignPassanger(IPassenger passanger);
}

public class Cab : ICab
{

    public Cab(string name, int location, bool isfree)
    {
        Name = name;
        Location = location;
        IsFree = isfree;
    }

    public string Name { get; set; }
    public int Location { get; set; }
    public bool IsFree { get; set; }

    public void AssignPassanger(IPassenger passanger)
    {
        Console.WriteLine($"Mr.{Name}! {passanger.Name} is your passenger. Passanger address: {passanger.Address}");
    }
}


public interface IPassenger
{
    string Name {  get; }
    string Address {  get; }
    int Location { get; }

    void CabAccepting(ICab cab);
}

public class Passanger : IPassenger
{
    public Passanger(string name, string address, int location)
    {
        Name = name;
        Address = address;
        Location = location;
    }

    public string Name { get; set; }

    public string Address { get; set; }

    public int Location { get; set; }

    public void CabAccepting(ICab cab)
    {
        Console.WriteLine($"Mr.{Name} Your Cab Driver is {cab.Name}. Good Luck!");
    }
}


public interface ICallCenter
{
    void RegisterCab(ICab cab);
    void BookCap(IPassenger passenger);
}

public class CallCenter : ICallCenter
{
    private readonly Dictionary<string, ICab> cabs;

    public CallCenter()
    {
        cabs = new Dictionary<string, ICab>();
    }

    public void BookCap(IPassenger passenger)
    {
        
        foreach (Cab cab in cabs.Values.Where(x => x.IsFree))
        {
            if(IsNearCab(cab.Location, passenger.Location))
            {
                cab.AssignPassanger(passenger);
                passenger.CabAccepting(cab);
                cab.IsFree = false;
                break;
            }
        }
    }

    public void RegisterCab(ICab cab)
    {
        if(!cabs.ContainsKey(cab.Name))
            cabs.Add(cab.Name, cab);
    }

    public bool IsNearCab(int CabLocation, int PassengerLocation) => Math.Abs(CabLocation - PassengerLocation) <= 5; 
}