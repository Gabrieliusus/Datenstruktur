using Common;

namespace Einfache_Liste;

public class SinglyLinkedList<T>
{
    private Node<T>? _head;
    public Node<T>? Head => _head;

    // optional: für den Test
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
}
