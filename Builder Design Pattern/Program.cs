
Console.Write("Enter FullName: ");
var fName = Console.ReadLine();

Console.Write("Enter Age: ");
var age = int.Parse(Console.ReadLine());

Console.Write("Enter Email: ");
var email = Console.ReadLine();

IEmployeeBuilder builder = new EmployeeBuilder();
var emp = builder.SetFullName(fName).SetAge(age).SetEmail(email).Build();
Console.WriteLine(emp.ToString());

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"First Name: {FirstName}  Last Name: {LastName}  Age: {Age}  Email: {Email}";
    }
}

public interface IEmployeeBuilder
{
    IEmployeeBuilder SetFullName(string fullName);
    IEmployeeBuilder SetAge(int age);
    IEmployeeBuilder SetEmail(string email);

    Employee Build();
}

public class EmployeeBuilder : IEmployeeBuilder
{
    private Employee _employee;
    public EmployeeBuilder()
    {
        _employee = new Employee();
    }

    public IEmployeeBuilder SetAge(int age)
    {
        _employee.Age = age;
        return this;
    }

    public IEmployeeBuilder SetEmail(string email)
    {
        _employee.Email = email;
        return this;
    }

    public IEmployeeBuilder SetFullName(string fullName)
    {
        _employee.FirstName = fullName.Split(new[] { ' ', '_', '.', '-' })[0];
        _employee.LastName = fullName.Split(new[] { ' ', '_', '.', '-' })[1];
        return this;
    }
    public Employee Build() => _employee;
}