
while (true)
{
    Console.WriteLine("1) Pul çıxarmaq.");
    Console.WriteLine("2) Çıxmaq.");

    int key = int.Parse(Console.ReadLine());
    if(key == 1)
    {
        Console.Write("User Name daxil edin: ");
        string username = Console.ReadLine();
        Console.Write("Password daxil edin: ");
        string password = Console.ReadLine();
        IBank bank = new ProxyBank(username, password);
        Console.Write("Mebleği daxil edin: ");
        int amount = int.Parse(Console.ReadLine());
        bank.WithdrawMoney(amount);
    }
    if(key == 2)
    {
        break;
    }
}


interface IBank
{
    bool WithdrawMoney(int amount);
}

class Bank : IBank
{
    private int _wallet;
    public Bank(int wallet)
    {
        _wallet = wallet;
    }
    public bool WithdrawMoney(int amount)
    {
        if(amount > _wallet)
        {
            Console.WriteLine($"Balansınızda kifayet qeder mebleğ yoxdur. Çatışmayan mebleğ: {amount - _wallet}");
            return false;
        }
        else if(amount == _wallet)
        {
            Console.WriteLine("Balansınızdakı Bütün mebleği çekdiniz.");
        }
        else
        {
            _wallet = _wallet - amount;
            Console.WriteLine($"Balansınızdan {amount} AZN çıxartdınız."); 
        }
        return true;
    }
}

class ProxyBank : IBank
{
    private Bank _bank;
    private bool login;

    private readonly string username;
    private readonly string password;
    public ProxyBank(string UserName, string Password, Bank bank)
    {
        username = UserName;
        password = Password;
    }

    public bool SignIn()
    {
        if(username == "huseyn" && password == "1234")
        {
            _bank = new Bank(100);
            login = true;
            return true;
        }
        else
        {
            login = false;
            return false;
        }
    }


    public bool WithdrawMoney(int amount)
    {
        SignIn();
        if (login)
        {
            _bank.WithdrawMoney(amount);
            return true;
        }
        else
        {
            Console.WriteLine("Failed Operation!");
            return false;
        }

    }
}