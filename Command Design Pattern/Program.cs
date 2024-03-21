
int sumResult = Claculator.Operate(new SumCommand(), 10, 2);
int substractResult = Claculator.Operate(new SubStractCommand(), 10, 2);
int multiplyResult = Claculator.Operate(new MultiPlyCommand(), 10, 2);
int divideResult = Claculator.Operate(new DivideCommand(), 10, 2);
int powerResult = Claculator.Operate(new PowerCommand(), 10, 2);

Console.WriteLine(sumResult);
Console.WriteLine(substractResult);
Console.WriteLine(multiplyResult);
Console.WriteLine(divideResult);
Console.WriteLine(powerResult);

interface ICommand
{
    int Operation(int num1, int num2);
}

class SumCommand : ICommand
{
    public int Operation(int num1, int num2)
    {
        return num1 + num2;
    }
}

class SubStractCommand : ICommand
{
    public int Operation(int num1, int num2)
    {
        return num1 - num2;
    }
}

class MultiPlyCommand : ICommand
{
    public int Operation(int num1, int num2)
    {
        return num1 * num2;
    }
}

class DivideCommand : ICommand
{
    public int Operation(int num1, int num2)
    {
        return num1 / num2;
    }
}

class PowerCommand : ICommand
{
    public int Operation(int num1, int num2)
    {
        return Convert.ToInt32(Math.Pow(num1, num2));
    }
}


class Claculator
{
    public static int Operate(ICommand command, int num1, int num2)
    {
        return command.Operation(num1, num2);
    }
}