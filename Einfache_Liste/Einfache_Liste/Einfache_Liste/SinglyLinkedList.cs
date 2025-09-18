using System;                
using System.Collections.Generic;
using Common;

namespace Einfache_Liste;

public class SinglyLinkedList
{
    private Node? _head;
    public Node? Head => _head;

    public void Insert(Person value)
    {
        var n = new Node(value) { Next = _head };
        _head = n;
    }

    public void InsertAtEnd(Person value)
    {
        var n = new Node(value);
        if (_head is null)
        {
            _head = n;
            return;
        }

        var cur = _head;
        while (cur.Next is not null) cur = cur.Next;
        cur.Next = n;
    }

    public Node? Search(Func<Person, bool> predicate)
    {
        var cur = _head;
        while (cur is not null)
        {
            if (predicate(cur.Data)) return cur;
            cur = cur.Next;
        }
        return null;
    }

    public IEnumerable<Person> ToEnumerable()
    {
        var cur = _head;
        while (cur is not null)
        {
            yield return cur.Data;
            cur = cur.Next;
        }
    }
}
