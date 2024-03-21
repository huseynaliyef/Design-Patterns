TransferTransactionBank transfer = new TransferTransactionBank() 
{ SentCardNumber = "4169738842340683", ReceivedCardNumber = "4168754521032135", Amount = 25};

XmlBankApiAdapter api = new XmlBankApiAdapter();
var data = api.ExecuteTransaction(transfer);
Console.WriteLine("Result: {0}", data);





interface IBankApi
{
    bool ExecuteTransaction(TransferTransactionBank transfer);
}


public class XmlBankApiAdapter
{
    private readonly XmlBankApi bankapi;
    public XmlBankApiAdapter()
    {
        bankapi = new XmlBankApi();
    }

    public bool ExecuteTransaction(TransferTransactionBank transfer)
    {
        return bankapi.ExecuteTransaction(transfer);
    }
}

public class JsonBankApiAdapter
{
    private readonly JsonBankApi bankapi;
    public JsonBankApiAdapter()
    {
        bankapi = new JsonBankApi();
    }
    public bool ExecuteTransaction(TransferTransactionBank transfer)
    {
        return bankapi.ExecuteTransaction(transfer);
    }
}


public class XmlBankApi : IBankApi
{
    public bool ExecuteTransaction(TransferTransactionBank transfer)
    {
        var xml = $"""
                        <Transaction>
                            <FromCard>{transfer.SentCardNumber}</FromCard>
                            <ToCard>{transfer.ReceivedCardNumber}</ToCard>
                            <Amount>{transfer.Amount:C2}</Amount>
                        </Transaction>
                    """;

        Console.WriteLine($"{GetType().Name} Worked");
        Console.WriteLine(xml);
        return true;
    }
}


public class JsonBankApi : IBankApi
{
    public bool ExecuteTransaction(TransferTransactionBank transfer)
    {
        var json = $$"""
                        {
                            ""FromCard"": ""{{transfer.SentCardNumber}}"",
                            ""ToCard"": ""{{transfer.ReceivedCardNumber}}"",
                            ""Amount"": ""{{transfer.Amount:C2}}""
                        }
                   """;

        Console.WriteLine($"{GetType().Name} worked");
        Console.WriteLine(json);
        return true;
    }
}


public class TransferTransactionBank
{
    public string SentCardNumber { get; set; }
    public string ReceivedCardNumber {  get; set; }
    public decimal Amount {  get; set; }
}