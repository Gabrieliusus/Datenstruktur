using Common;

namespace Einfache_Liste;

public class SinglyLinkedList<T>
{
    private Node<T>? _head;
    public Node<T>? Head => _head;

    public Node<T>? GetLastNode()
    {
        var cur = _head;
        if (cur is null) return null;
        while (cur.Next is not null) cur = cur.Next;
        return cur;
    }
    public void Insert(T value)
    {
        var n = new Node<T>(value) { Next = _head };
        _head = n;
    }

    public void InsertAtEnd(T value)
    {
        var n = new Node<T>(value);
        if (_head is null)
        {
            _head = n;
            return;
        }

        var cur = _head;
        while (cur.Next is not null) cur = cur.Next;
        cur.Next = n;
    }

    public Node<T>? Search(Func<T, bool> predicate)
    {
        var cur = _head;
        while (cur is not null)
        {
            if (predicate(cur.Data)) return cur;
            cur = cur.Next;
        }
        return null;
    }

    public IEnumerable<T> ToEnumerable()
    {
        var cur = _head;
        while (cur is not null)
        {
            yield return cur.Data;
            cur = cur.Next;
        }
    }
    public void InsertBefore(T elementAfter, T elementToInsert)
    {
        if (_head is null) return;

        if (EqualityComparer<T>.Default.Equals(_head.Data, elementAfter))
        {
            var n = new Node<T>(elementToInsert) { Next = _head };
            _head = n;
            return;
        }

        var cur = _head;
        while (cur.Next is not null)
        {
            if (EqualityComparer<T>.Default.Equals(cur.Next.Data, elementAfter))
            {
                var n = new Node<T>(elementToInsert) { Next = cur.Next };
                cur.Next = n;
                return;
            }
            cur = cur.Next;
        }
    }
    public void InsertAfter(T elementBefore, T elementToInsert)
    {
        if (_head is null) return;

        var cur = _head;
        while (cur is not null)
        {
            if (EqualityComparer<T>.Default.Equals(cur.Data, elementBefore))
            {
                var n = new Node<T>(elementToInsert) { Next = cur.Next };
                cur.Next = n;
                return;
            }
            cur = cur.Next;
        }
    }

    public int PosOfElement(int element)
    {
        int number = 0;

        List<int> list = new List<int>();
       
        while (list.Count == 11) 
        { 
            list.Add(number);
            number++;
        }

        if (list.Contains(element))
        {
            int leck = list.IndexOf(element);
            return leck;
        }
        return 0;
    }
}
