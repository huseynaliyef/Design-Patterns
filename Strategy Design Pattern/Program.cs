
var payment = new Payment();
payment.SetPaymentStrategy(new KapitalBank());
payment.SetPaymentStrategy(new ABB());
payment.SetPaymentStrategy(new AccessBank());
payment.ApplayPayment();



public class Payment
{
    private IPaymentStrategy _paymentStrategy;

    public Payment(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public Payment()
    {
        
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public bool ApplayPayment()
    {
        return _paymentStrategy.Pay();
    }
}


public interface IPaymentStrategy
{
    public bool Pay();
}

public class KapitalBank : IPaymentStrategy
{
    public bool Pay()
    {
        Console.WriteLine("Payment was made via Kapital Bank");
        return true;
    }
}

public class ABB : IPaymentStrategy
{
    public bool Pay()
    {
        Console.WriteLine("Payment was made via ABB");
        return true;
    }
}

public class AccessBank : IPaymentStrategy
{
    public bool Pay()
    {
        Console.WriteLine("Payment was made via Access Bank");
        return true;
    }
}