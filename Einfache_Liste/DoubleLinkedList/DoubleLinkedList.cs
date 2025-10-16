using System.Collections.Generic;

namespace DoubleLinkedList;

public class DoubleLinkedList<T>
{
    private DNode<T>? _head;
    private DNode<T>? _tail;

    public DNode<T>? Head => _head;
    public DNode<T>? Tail => _tail;
    public int Count { get; private set; }

    public void InsertAfter(T elementBefore, T elementToInsert)
    {
        if (_head is null) return;

        var cur = _head;
        var cmp = EqualityComparer<T>.Default;

        while (cur is not null)
        {
            if (cmp.Equals(cur.Data, elementBefore))
            {
                var newNode = new DNode<T>(elementToInsert)
                {
                    Prev = cur,
                    Next = cur.Next
                };
                if (cur.Next is not null)
                    cur.Next.Prev = newNode;
                else
                    _tail = newNode;
                cur.Next = newNode;
                Count++;
                return;
            }
            cur = cur.Next;
        }
    }


    public void InsertBefore(T elementAfter, T elementToInsert)
    {
        if (_head is null) return;
        var cmp = EqualityComparer<T>.Default;
        if (cmp.Equals(_head.Data, elementAfter))
        {
            var newNode = new DNode<T>(elementToInsert)
            {
                Next = _head,
                Prev = null
            };

            _head.Prev = newNode;
            _head = newNode;
            Count++;
            return;
        }
        var cur = _head.Next;
        while (cur is not null)
        {
            if (cmp.Equals(cur.Data, elementAfter))
            {
                var newNode = new DNode<T>(elementToInsert)
                {
                    Prev = cur.Prev,
                    Next = cur
                };

                cur.Prev!.Next = newNode;
                cur.Prev = newNode;
                Count++;
                return;
            }
            cur = cur.Next;
        }
    }


    public int PosOfElement(T element)
    {
        var cur = _head;
        int index = 0;
        var cmp = EqualityComparer<T>.Default;

        while (cur is not null)
        {
            if (cmp.Equals(cur.Data, element))
                return index;

            cur = cur.Next;
            index++;
        }

        return -1;
    }

}
