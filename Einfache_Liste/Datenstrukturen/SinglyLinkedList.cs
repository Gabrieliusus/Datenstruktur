using System;
using System.Collections.Generic;
using Common;

namespace Datenstrukturen;

public class SinglyLinkedList<T>
{
    private Node<T>? _head;

    public Node<T>? Head => _head;
    public int Count { get; private set; }

    public void Insert(T value)
    {
        var n = new Node<T>(value) { Next = _head };
        _head = n;
        Count++;
    }

    public Node<T>? GetLastNode()
    {
        var cur = _head;
        if (cur is null)
            return null;

        while (cur.Next is not null)
            cur = cur.Next;

        return cur;
    }


    public void InsertAtEnd(T value)
    {
        var n = new Node<T>(value);
        if (_head is null)
        {
            _head = n;
            Count = 1;
            return;
        }

        var cur = _head;
        while (cur.Next is not null)
            cur = cur.Next;

        cur.Next = n;
        Count++;
    }


    public Node<T>? Search(Func<T, bool> predicate)
    {
        var cur = _head;
        while (cur is not null)
        {
            if (predicate(cur.Data))
                return cur;
            cur = cur.Next;
        }
        return null;
    }

    public void InsertAfter(T elementBefore, T elementToInsert)
    {
        if (_head is null)
        {

            var n0 = new Node<T>(elementToInsert);
            _head = n0;
            Count = 1;
            return;
        }

        var cmp = EqualityComparer<T>.Default;
        var cur = _head;

        while (cur is not null)
        {
            if (cmp.Equals(cur.Data, elementBefore))
            {
                var n = new Node<T>(elementToInsert)
                {
                    Next = cur.Next
                };

                cur.Next = n;
                Count++;
                return;
            }

            cur = cur.Next;
        }
    }

    public void InsertBefore(T elementAfter, T elementToInsert)
    {
        if (_head is null)
        {
            var n0 = new Node<T>(elementToInsert);
            _head = n0;
            Count = 1;
            return;
        }

        var cmp = EqualityComparer<T>.Default;

        if (cmp.Equals(_head.Data, elementAfter))
        {
            var n = new Node<T>(elementToInsert)
            {
                Next = _head
            };
            _head = n;
            Count++;
            return;
        }

        var prev = _head;
        var cur = _head.Next;

        while (cur is not null)
        {
            if (cmp.Equals(cur.Data, elementAfter))
            {
                var n = new Node<T>(elementToInsert)
                {
                    Next = cur
                };

                prev.Next = n;
                Count++;
                return;
            }

            prev = cur;
            cur = cur.Next;
        }
    }


    public int PosOfElement(T element)
    {
        var cmp = EqualityComparer<T>.Default;
        var cur = _head;
        int i = 0;

        while (cur is not null)
        {
            if (cmp.Equals(cur.Data, element))
                return i;

            cur = cur.Next;
            i++;
        }

        return -1;
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
