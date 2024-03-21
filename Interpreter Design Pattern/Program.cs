Context context = new Context();
context.Input = Console.ReadLine();

Expression expression1 = new TerminalExpression();
Expression expression2 = new NonTerminalExpression();

expression1.Interpret(context);
expression2.Interpret(context);

class Context
{
    public string Input { get; set; }
}

interface Expression
{
    void Interpret(Context context);
}

class NonTerminalExpression : Expression
{
    public void Interpret(Context context)
    {
        Console.WriteLine("NonTerminal expression interpreted with context: " + context.Input);
    }
}


class TerminalExpression : Expression
{
    public void Interpret(Context context)
    {
        Console.WriteLine("terminal expression interpreted with context: " + context.Input);
    }
}




//Context c = new Context { Input = "HhSs" };
//RunExpression(c);
//Console.WriteLine($"Total Cost: {c.TotalCost}");

//static List<Expression> CreateExpressiontree(string input)
//{
//    List<Expression> result = new List<Expression>();

//    foreach(var item in input)
//    {
//        if (item == 'S' || item == 's')
//            result.Add(new SoftExpression());
//        else if(item == 'H' || item == 'h')
//        {
//            result.Add(new HrExpression());
//        }
//        else if(item == 'Y' || item == 'y')
//        {
//            result.Add(new Salesexpression());
//        }
//    }
//    return result;
//}

//static void RunExpression(Context context)
//{
//    var list = CreateExpressiontree(context.Input.Trim());
//    foreach (var elemet in list)
//    {
//        elemet.Interpret(context);
//    }
//}


//public class Context
//{
//    public string Input { get; set; }
//    public int TotalCost {  get; set; }
//}
//public interface Expression
//{
//    public void Interpret(Context context);
//}

//public class SoftExpression : Expression
//{
//    public void Interpret(Context context)
//    {
//        context.TotalCost += 50;
//    }
//}

//public class HrExpression : Expression
//{
//    public void Interpret(Context context)
//    {
//        context.TotalCost += 40;
//    }
//}

//public class Salesexpression : Expression
//{
//    public void Interpret(Context context)
//    {
//        context.TotalCost += 30;
//    }
//}

