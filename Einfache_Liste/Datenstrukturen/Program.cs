using System;
using Common;
using Datenstrukturen;

namespace Datenstrukturen
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Einfach verkettete Liste ===");
            var list = new SinglyLinkedList<string>();
            list.Insert("B");
            list.Insert("A");
            list.InsertAtEnd("C");
            Console.WriteLine($"Position von B: {list.PosOfElement("B")}");
            Console.WriteLine($"Position von D (nicht enthalten): {list.PosOfElement("D")}");

            Console.WriteLine("\n=== Doppelt verkettete Liste ===");
            var dlist = new DoubleLinkedList<int>();
            dlist.InsertBefore(default!, 2);
            dlist.InsertBefore(2, 1);
            dlist.InsertAfter(2, 3);

            Console.WriteLine($"Head: {dlist.Head?.Data}, Tail: {dlist.Tail?.Data}");
            Console.WriteLine($"Position von 1: {dlist.PosOfElement(1)}");
            Console.WriteLine($"Position von 3: {dlist.PosOfElement(3)}");
        }
    }
}
