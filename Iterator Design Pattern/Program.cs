int[] array = { 1, 2, 3, 4, 5 };
ArrayCollection<int> collection = new ArrayCollection<int>(array);
ArrayIterator<int> iterator = (ArrayIterator<int>)collection.CreateIterator();
while (iterator.Hasnext())
{
    Console.WriteLine(iterator.Next());
}

List<string> namse = new List<string> { "Jhon", "Parker", "Mike" };
ListCollection<string> listCollection = new ListCollection<string>(namse);
ListIterator<string> listIterator = (ListIterator<string>)listCollection.CreateIterator();
while (listIterator.Hasnext())
{
    Console.WriteLine(listIterator.Next());
}


public interface IIterator<T>
{
    T Next();
    bool Hasnext();
}

public interface IIteratorCollection<T>
{
    IIterator<T> CreateIterator();
}

public class ArrayCollection<T> : IIteratorCollection<T>
{
    private T[] _array;

    public ArrayCollection(T[] array)
    {
        _array = array;
    }

    public IIterator<T> CreateIterator()
    {
        return new ArrayIterator<T>(this);
    }

    public T GetItem(int index)
    {
        return _array[index];
    }

    public int Count => _array.Length;
}

public class ArrayIterator<T> : IIterator<T>
{
    private ArrayCollection<T> _arrayCollection;
    private int index;

    public ArrayIterator(ArrayCollection<T> arrayCollection)
    {
        _arrayCollection = arrayCollection;
    }

    public T Next()
    {
        T item = _arrayCollection.GetItem(index);
        index++;
        return item;
    }

    public bool Hasnext()
    {
        return index < _arrayCollection.Count;
    }

}

public class ListCollection<T> : IIteratorCollection<T>
{
    private List<T> _list;
    public ListCollection(List<T> list)
    {
        _list = list;
    }

    public IIterator<T> CreateIterator()
    {
        return new ListIterator<T>(this);
    }

    public T GetItem(int index)
    {
        return _list[index];
    }

    public int Count => _list.Count;
}

public class ListIterator<T> : IIterator<T>
{
    private ListCollection<T> _list;
    private int index;
    public ListIterator(ListCollection<T> list)
    {
        _list = list;
        this.index = 0;

    }
    public bool Hasnext()
    {
        return index < _list.Count;
    }

    public T Next()
    {
        var item = _list.GetItem(index);
        index++;
        return item;
    }
}