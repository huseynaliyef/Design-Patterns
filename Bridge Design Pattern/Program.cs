
ILanguage languageEn = new English();
ILanguage languageAz = new Azerbaijan();

IWebPage homepgEn = new Home(languageEn);
homepgEn.GetPageInfo();
IWebPage contactpgEn = new Contact(languageEn);
contactpgEn.GetPageInfo();

IWebPage homepgAz = new Home(languageAz);
homepgAz.GetPageInfo();
IWebPage contactpgAz = new Contact(languageAz);
contactpgAz.GetPageInfo();



interface ILanguage
{
    string GetLanguage();
}

class English : ILanguage
{
    public string GetLanguage()
    {
        return $"{GetType().Name} language";
    }
}

class Azerbaijan : ILanguage
{
    public string GetLanguage()
    {
        return $"{GetType().Name} language";
    }
}



interface IWebPage
{
    void GetPageInfo();
}

class Home : IWebPage
{
    private ILanguage _language;
    public Home(ILanguage language)
    {

        _language = language;

    }
    public void GetPageInfo()
    {
        Console.WriteLine($"{GetType().Name} page is {_language.GetLanguage()}");
    }
}

class Contact : IWebPage
{
    private ILanguage _language;

    public Contact(ILanguage language)
    {
        _language= language;
    }

    public void GetPageInfo()
    {
        Console.WriteLine($"{GetType().Name} page is {_language.GetLanguage()}");
    }
}