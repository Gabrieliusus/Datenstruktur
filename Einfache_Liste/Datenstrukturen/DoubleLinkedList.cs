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

    // NUR: InsertAfter, InsertBefore, PosOfElement

    // Fügt NACH dem ersten Vorkommen von elementBefore ein.
    // Sonderfall: Ist die Liste leer, wird elementToInsert als erstes Element angelegt.
    public void InsertAfter(T elementBefore, T elementToInsert)
    {
        // leer -> erstes Element anlegen (damit man die Liste ohne Initialize aufbauen kann)
        if (_head is null)
        {
            var n0 = new Node<T>(elementToInsert);
            _head = _tail = n0;
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
        // nicht gefunden -> absichtlich nichts tun
    }

    // Fügt VOR dem ersten Vorkommen von elementAfter ein.
    // Sonderfall: Ist die Liste leer, wird elementToInsert als erstes Element angelegt.
    public void InsertBefore(T elementAfter, T elementToInsert)
    {
        // leer -> erstes Element anlegen
        if (_head is null)
        {
            var n0 = new Node<T>(elementToInsert);
            _head = _tail = n0;
            Count = 1;
            return;
        }

        var cmp = EqualityComparer<T>.Default;

        // vor Head einfügen
        if (cmp.Equals(_head.Data, elementAfter))
        {
            var n = new Node<T>(elementToInsert)
            {
                Next = _head,
                Prev = null
            };
            _head.Prev = n;
            _head = n;
            Count++;
            return;
        }

        // in der Mitte
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
        // nicht gefunden -> absichtlich nichts tun
    }

    // Liefert den 0-basierten Index des ersten Vorkommens oder -1, wenn nicht gefunden
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
