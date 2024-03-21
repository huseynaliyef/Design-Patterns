Game game = new Game();
game.X();
game.Y();
game.A();
game.B();

game.LosingBall();
game.X();
game.Y();
game.A();
game.B();

public interface GameConsoleState
{
    public void Triangle();
    public void Circle();
    public void X();
    public void Square();
}

public class AttackState : GameConsoleState
{
    public void Circle()
    {
        Console.WriteLine("Orta pas verilir..");
    }

    public void Square()
    {
        Console.WriteLine("Uzun pas verilir..");
    }

    public void Triangle()
    {
        Console.WriteLine("Ara pası verilir..");
    }

    public void X()
    {
        Console.WriteLine("Qısa pas verilir..");
    }
}


public class DefenseState : GameConsoleState
{
    public void Circle()
    {
        Console.WriteLine("Reqibe müdaxile edilir...");
    }

    public void Square()
    {
        Console.WriteLine("Topu uzaqlaşdır...");
    }

    public void Triangle()
    {
        Console.WriteLine("Qapıçı topu tutur...");
    }

    public void X()
    {
        Console.WriteLine("Topun üzerine qaç...");
    }
}

public class Game
{
    public GameConsoleState ConsoleState;
    public Game()
    {
        ConsoleState = new AttackState();
        Console.WriteLine("Oyun başladı.");
    }

    public void Y()
    {
        ConsoleState.Triangle();
    }

    public void B()
    {
        ConsoleState.Circle();
    }

    public void A()
    {
        ConsoleState.X();
    }

    public void X()
    {
        ConsoleState.Square();
    }

    public void LosingBall()
    {
        ConsoleState = new DefenseState();
        Console.WriteLine("Top Reqibe keçdi.");
    }

    public void GettingBall()
    {
        ConsoleState = new AttackState();
        Console.WriteLine("Top Reqibe keçdi.");
    }

}