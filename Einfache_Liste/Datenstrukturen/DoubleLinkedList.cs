using System.Collections.Generic;
using Common;

namespace Datenstrukturen;

public class DoubleLinkedList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public Node<T>? Head => _head;
    public Node<T>? Tail => _tail;
    public int Count { get; private set; }

    public void Insert(T value)
    {
        var n = new Node<T>(value);

        if (_head is null)
        {
            _head = _tail = n;
        }
        else
        {
            n.Next = _head;
            _head.Prev = n;
            _head = n;
        }

        Count++;
    }

    public void InsertAtEnd(T value)
    {
        var n = new Node<T>(value);

        if (_tail is null)
        {
            _head = _tail = n;
        }
        else
        {
            _tail.Next = n;
            n.Prev = _tail;
            _tail = n;
        }

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
            var n = new Node<T>(elementToInsert);
            _head = _tail = n;
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
                    Prev = cur,
                    Next = cur.Next
                };

                if (cur.Next is not null)
                    cur.Next.Prev = n;
                else
                    _tail = n;

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
            var n = new Node<T>(elementToInsert);
            _head = _tail = n;
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
            _head.Prev = n;
            _head = n;
            Count++;
            return;
        }

        var cur = _head.Next;
        while (cur is not null)
        {
            if (cmp.Equals(cur.Data, elementAfter))
            {
                var n = new Node<T>(elementToInsert)
                {
                    Prev = cur.Prev,
                    Next = cur
                };

                cur.Prev!.Next = n;
                cur.Prev = n;
                Count++;
                return;
            }

            cur = cur.Next;
        }
    }

    public void BubbleSort(IComparer<T>? comparer = null)
    {
        if (_head is null) return;
        comparer ??= Comparer<T>.Default;

        bool swapped;
        do
        {
            swapped = false;
            var current = _head;

            while (current?.Next is not null)
            {
                if (comparer.Compare(current.Data, current.Next.Data) > 0)
                {
                    (current.Data, current.Next.Data) = (current.Next.Data, current.Data);
                    swapped = true;
                }

                current = current.Next;
            }

        } while (swapped);
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
}
