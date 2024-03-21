MemoryClass memory = new MemoryClass();
NotePad notepad = new NotePad();
NotePadMemento memento = null;

while (true)
{

    Console.WriteLine("1) Add Note");
    Console.WriteLine("2) Undo");
    Console.WriteLine("3) Print");

    int select = int.Parse(Console.ReadLine());
    try
    {
        if (select == 1)
        {
            memento = notepad.Save();
            memory.InsertMemory(memento);
            Console.Write("Note: ");
            string note = Console.ReadLine();
            notepad.Insert(note);

        }
        else if (select == 2)
        {
            notepad.Undo(memory.GetLastItem());
        }
        else if (select == 3)
        {
            notepad.Print();
        }
        else
        {
            Console.WriteLine("Select Right Key!");
        }
    }
    catch(ArgumentNullException ex)
    {
        Console.WriteLine(ex.ParamName);
    }
}

public class NotePad
{
    public string Note { get; set; }

    public NotePad()
    {
        Note = "";
    }

    public NotePad(string note)
    {
        Note = note;
    }

    public void Insert(string note)
    {
        Note = Note + note;
    }

    public NotePadMemento Save()
    {
        return new NotePadMemento(Note);
    }

    public void Undo(NotePadMemento memento)
    {
        Note = memento.Note;
    }
    
    public void Print()
    {
        Console.WriteLine(Note);
    }

}

public class NotePadMemento
{
    public string Note { get; set; }

    public NotePadMemento()
    {
        Note = "";
    }

    public NotePadMemento(string note)
    {
        Note = note;
    }

}

public class MemoryClass
{
    private List<NotePadMemento> list;

    public MemoryClass()
    {
        list = new List<NotePadMemento>();
    }

    public void InsertMemory(NotePadMemento memento)
    {
        list.Add(memento);
    }

    public NotePadMemento GetLastItem()
    {
        if (list.Count == 0)
            throw new ArgumentNullException("List is Empty!!!");

        var item = list[list.Count - 1];
        list.Remove(item);
        return item;
    }

}