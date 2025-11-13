using NUnit.Framework;
using Datenstrukturen;

namespace DatenstrukturenTests;

[TestFixture]
public class DoubleLinkedListTests
{
    [Test]
    public void InsertAfter_InsertsCorrectly()
    {
        var list = new DoubleLinkedList<int>();
        list.InsertAfter(default!, 1);
        list.InsertAfter(1, 2);
        list.InsertAfter(2, 3);

        Assert.That(list.PosOfElement(1), Is.EqualTo(0));
        Assert.That(list.PosOfElement(2), Is.EqualTo(1));
        Assert.That(list.PosOfElement(3), Is.EqualTo(2));
    }

    [Test]
    public void InsertBefore_InsertsCorrectly()
    {
        var list = new DoubleLinkedList<string>();
        list.InsertBefore(default!, "B");
        list.InsertBefore("B", "A");
        list.InsertAfter("B", "C");

        Assert.That(list.PosOfElement("A"), Is.EqualTo(0));
        Assert.That(list.PosOfElement("B"), Is.EqualTo(1));
        Assert.That(list.PosOfElement("C"), Is.EqualTo(2));
    }

    [Test]
    public void BubbleSort_SortsIntegerListAscending()
    {
        var list = new DoubleLinkedList<int>();
        list.InsertBefore(0, 3);
        list.InsertAfter(3, 1);
        list.InsertAfter(1, 2);

        list.BubbleSort();

        var result = list.ToEnumerable().ToArray();
        Assert.That(result, Is.EqualTo(new[] { 1, 2, 3 }));
    }
}
