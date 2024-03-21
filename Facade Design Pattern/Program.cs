
Applications appliactions = new Applications();
appliactions.StandartApplicationsDownload();

appliactions.SocialMediaAppliactionsDownload();



class Calculator
{
    public void Download()
    {
        Console.WriteLine("Calculator Downloading..");
    }
}

class Calendar
{
    public void Download()
    {
        Console.WriteLine("Calendar Downloading..");
    }
}

class Paint
{
    public void Download()
    {
        Console.WriteLine("Paint Downloading..");
    }
}


class Instagram
{
    public void Download()
    {
        Console.WriteLine("Instagram Downloading..");
    }
}

class Whatsapp
{
    public void Download()
    {
        Console.WriteLine("Whatsapp Downloading..");
    }
}

class Twitter
{
    public void Download()
    {
        Console.WriteLine("Twitter Downloading..");
    }
}


class Applications
{
    private Calculator _calculator;
    private Calendar _calendar;
    private Paint _paint;
    private Instagram _instagram;
    private Whatsapp _whatsapp;
    private Twitter _twitter;

    public Applications()
    {
        _calculator = new Calculator();
        _calendar = new Calendar();
        _paint = new Paint();
        _instagram = new Instagram();
        _whatsapp = new Whatsapp();
        _twitter = new Twitter();
    }

    public void StandartApplicationsDownload()
    {
        Console.WriteLine("---Standart Applications---");
        _calculator.Download();
        _calendar.Download();
        _paint.Download();
    }

    public void SocialMediaAppliactionsDownload()
    {
        Console.WriteLine("---Social Media Appliactions---");
        _instagram.Download();
        _whatsapp.Download();
        _twitter.Download();
    }

}