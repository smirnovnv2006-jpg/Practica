using System.Collections;
using System.Security.Cryptography.X509Certificates;

public class SmartStack<T> : IEnumerable<T>
{
    private T[] _items;
    private int _count;
    public SmartStack()
    {
        _items = new T[4];
        _count = 0;
    }
    public SmartStack(int capacity)
    {
        if (capacity < 0) throw new ArgumentException("Capacity не может быть отрицательным");
        _items = new T[capacity];
        _count = 0;
    }

    public SmartStack(IEnumerable<T> collection)
    {
        int count = 0;
        foreach(var item in collection)
        {
            count++;
        }
        _items = new T[count];
        int index = 0;
        foreach (var item in collection)
        {
            _items[index] = item;
            index++;
        }
        _count = count;
    }

    public void Push(T value)
    {
        if (_count == _items.Length)
        {
            T[] newItems = new T[_items.Length * 2];
            for (int i = 0; i < _count; i++)
                newItems[i] = _items[i];
            _items = newItems;
        }
        _items[_count] = value;
        _count++;
    }

    public void PushRange(IEnumerable<T> items)
    {
        foreach (var item in items)
            Push(item);
    }

    public T Pop()
    {
        if (_count == 0)
            throw new InvalidOperationException("Стек пуст");
        _count--;
        return _items[_count];
    }

    public T Peek()
    {
        if (_count == 0)
            throw new InvalidOperationException("Стек пуст");
        return _items[_count-1];
    }

    public bool Contains(T item)
    {
        for(int i = 0; i < _count; i++)
        {
            if (Equals(item, _items[i]))
                return true;
        }
        return false;
    }

    public int Count => _count;
    public int Capacity => _items.Length;

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = _count - 1; i >= 0; i--)  // от вершины к основанию
            yield return _items[i];
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));
            return _items[_count - 1 - index];
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var stack = new SmartStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine($"Count: {stack.Count}, Capacity: {stack.Capacity}");
        Console.WriteLine($"Peek: {stack.Peek()}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"stack[0] (вершина): {stack[0]}");

        Console.WriteLine("Обход:");
        foreach (var item in stack)
            Console.WriteLine(item);

        Console.WriteLine($"Contains(2): {stack.Contains(2)}");
        Console.WriteLine($"Contains(5): {stack.Contains(5)}");

        stack.PushRange(new[] { 10, 20 });
        Console.WriteLine($"После PushRange Count: {stack.Count}");

        try { new SmartStack<int>().Pop(); }
        catch (InvalidOperationException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}