
BoxFactory boxfactory = new BoxFactory();

Box box1 = boxfactory.Get(Color.Red);
Box box2 = boxfactory.Get(Color.Red);
Box box3 = boxfactory.Get(Color.Red);
Box box4 = boxfactory.Get(Color.Yellow);
Box box5 = boxfactory.Get(Color.Yellow);


box1.Draw(10,20);
box2.Draw(43,24);
box3.Draw(65,44);
box4.Draw(53,78);
box5.Draw(82,36);

enum Color
{
    Red,
    Yellow
}

abstract class Box
{
    public int Height;
    public int Width;
    public Color color;

    public abstract void Draw(int XLoaction, int YLocation);
}

class RedBox : Box
{
    public RedBox(int height, int width)
    {
        this.Height = height;
        this.Width = width;
        this.color = Color.Red;
    }

    public override void Draw(int XLoaction, int YLocation)
    {
        Console.WriteLine($"{color} box is {XLoaction} : {YLocation} Location.");
    }
}

class YellowBox : Box
{
    public YellowBox(int height, int width)
    {
        this.Height = height;
        this.Width = width;
        this.color = Color.Yellow;
    }


    public override void Draw(int XLoaction, int YLocation)
    {
        Console.WriteLine($"{color} box is {XLoaction} : {YLocation} Location.");
    }
}

class BoxFactory
{
    private Dictionary<Color, Box> _boxes;

    public BoxFactory()
    {
        _boxes = new Dictionary<Color, Box>();
    }


    public Box Get(Color color)
    {
        if (_boxes.ContainsKey(color))
        {
            return _boxes[color];
        }

        Box newBox = null;

        if (color == Color.Red)
        {
            newBox = new RedBox(20,20);
        } 
        else if (color == Color.Yellow)
        {
            newBox = new YellowBox(20,20);
        }

        _boxes.Add(color, newBox);

        return newBox;
    }

}