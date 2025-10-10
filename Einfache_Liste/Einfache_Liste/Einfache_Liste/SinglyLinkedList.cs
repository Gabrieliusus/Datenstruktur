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
        while (cur.Next != null) cur = cur.Next;
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
        while (cur.Next != null) cur = cur.Next;
        cur.Next = n;
    }

    public Node<T>? Search(Func<T, bool> predicate)
    {
        var cur = _head;
        while (cur != null)
        {
            if (predicate(cur.Data)) return cur;
            cur = cur.Next;
        }
        return null;
    }

    public IEnumerable<T> ToEnumerable()
    {
        var cur = _head;
        while (cur != null)
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
        while (cur.Next != null)
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
        while (cur != null)
        {
            if (EqualityComparer<T>.Default.Equals(cur.Data, elementBefore))
            {
                cur.Next = new Node<T>(elementToInsert) { Next = cur.Next }; ;
                return;
            }
            cur = cur.Next;
        }
    }


    public int PosOfElement(T element)
    {
        int index = 0;  

        var cur = _head;

        if (element is null)
        {
            return -1;
        }

        while (cur != null) 
        { 
            if (element.Equals(cur.Data))
            {
                return index;
            }
            cur = cur.Next;
            index++;
        }
        
        return -1;
    }
}
