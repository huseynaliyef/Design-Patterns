
Request request = new Request
{
    Token = new Token
    {
        Value = "adkj3jk4i234msdofoIIrR086",
        Roles = new[] { "Member" },
        IsExpired = false

    },
    Order = new Order
    {
        Id = 1,
        Price = 34,
        InStock = true
    }
};

AuthenticationHandler authenticationhandler = new AuthenticationHandler();
AuthorizationHandler authorizationHandler = new AuthorizationHandler();
ValidationHandler validationhandler = new ValidationHandler();
ControllerHandler controllerhandler = new ControllerHandler();

authenticationhandler.SetHandler(authorizationHandler);
authorizationHandler.SetHandler(validationhandler);
validationhandler.SetHandler(controllerhandler);

var response = authenticationhandler.ProcessRequest(request);
if (response.Success)
{
    Console.ForegroundColor = ConsoleColor.Green;
}
else
    Console.ForegroundColor= ConsoleColor.Red;

Console.WriteLine(response.Message);



public class Request
{
    public Token Token { get; set; }
    public Order Order { get; set; }
}

public class Token
{
    public string Value { get; set; }
    public string[] Roles { get; set; }
    public bool IsExpired {  get; set; }
}

public class Order
{
    public int Id { get; set; }
    public int Price { get; set; }
    public bool InStock { get; set; }
}

public class Response
{
    public bool Success { get; set; }
    public string Message { get; set; }
}



public abstract class Handler
{
    public Handler handler;
    public void SetHandler(Handler handler)
    {
        this.handler = handler;
    }
    public abstract Response ProcessRequest(Request request);
}

public class AuthenticationHandler : Handler
{
    public override Response ProcessRequest(Request request)
    {
        if(request.Token.Value == null || request.Token.IsExpired)
        {
            return new Response
            {
                Success = false,
                Message = "The user could not be verified."
            };
        }else
            return this.handler.ProcessRequest(request);
    }
}

public class AuthorizationHandler : Handler
{
    public override Response ProcessRequest(Request request)
    {
        if (!request.Token.Roles.Contains("Member"))
        {
            return new Response
            {
                Success = false,
                Message = "User authorization could not be verified"
            };
        }
        else
            return this.handler.ProcessRequest(request);
    }
}

public class ValidationHandler : Handler
{
    public override Response ProcessRequest(Request request)
    {
        if (!request.Order.InStock)
        {
            return new Response
            {
                Success = false,
                Message = "Order could not be created, stock is insufficient"
            };
        }
        else
            return this.handler.ProcessRequest(request);
    }
}

public class ControllerHandler : Handler
{
    public override Response ProcessRequest(Request request)
    {
        return new Response
        {
            Success = true,
            Message = "Order created successfully"
        };
    }
}