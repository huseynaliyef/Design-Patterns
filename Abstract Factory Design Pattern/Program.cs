IGameFactory pc = new PcGameFactory();
IRacingGame racing = pc.CreateRacingGame();
IShooterGame shoot = pc.CreateShootGame();
racing.play();
shoot.play();

IGameFactory playstation = new PlayStationFactory();
IRacingGame racingpl = playstation.CreateRacingGame();
IShooterGame shootpl = playstation.CreateShootGame();
racingpl.play();
shootpl.play();


public interface IShooterGame
{
    void play();
}

public interface IRacingGame
{
    void play();
}

public interface IGameFactory
{
    IShooterGame CreateShootGame();
    IRacingGame CreateRacingGame();
}

public class PcShotterGame : IShooterGame
{
    public void play()
    {
        Console.WriteLine("Pc Shooter Game.");
    }
}
public class PlayStationShotterGame : IShooterGame
{
    public void play()
    {
        Console.WriteLine("Playstation Shooter Game.");
    }
}

public class PcRacingGame : IRacingGame
{
    public void play()
    {
        Console.WriteLine("Pc Racing Game.");
    }
}
public class PlayStationRacingGame : IRacingGame
{
    public void play()
    {
        Console.WriteLine("PlayStation Racing Game.");
    }
}

public class PcGameFactory : IGameFactory
{
    public IRacingGame CreateRacingGame()
    {
        return new PcRacingGame();
    }

    public IShooterGame CreateShootGame()
    {
        return new PcShotterGame();
    }
}

public class PlayStationFactory : IGameFactory
{
    public IRacingGame CreateRacingGame()
    {
        return new PlayStationRacingGame();
    }

    public IShooterGame CreateShootGame()
    {
        return new PlayStationShotterGame();
    }
}

