using Common;
using Einfache_Liste;
using System;

var list = new SinglyLinkedList<Person>();

list.Insert(new Person(new DateTime(2008, 1, 23), "männlich", "Gabriel"));
list.Insert(new Person(new DateTime(2003, 1, 7), "weiblich", "Magdalena"));
list.InsertAtEnd(new Person(new DateTime(2007, 11, 16), "männlich", "Felix"));

var found = list.Search(p => p.Name == "Gabriel");
Console.WriteLine(found is null ? "Gabriel nicht gefunden" : $"Gefunden: {found.Data}");

foreach (var p in list.ToEnumerable())
    Console.WriteLine(p);
