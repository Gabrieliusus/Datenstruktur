using NUnit.Framework;
using System.Linq;
using DoubleLinkedList;

namespace DoubleLinkedList.Tests
{
    [TestFixture]
    public class DoubleLinkedListExtraTests
    {
        [Test]
        public void InsertAfter_InsertsElementCorrectly()
        {
            var list = new DoubleLinkedList<string>();

            list.InsertBefore(default!, "A");
            list.InsertAfter("A", "B");
            list.InsertAfter("B", "C");

            Assert.That(list.PosOfElement("A"), Is.EqualTo(0));
            Assert.That(list.PosOfElement("B"), Is.EqualTo(1));
            Assert.That(list.PosOfElement("C"), Is.EqualTo(2));
            Assert.That(list.PosOfElement("X"), Is.EqualTo(-1));
        }


        [Test]
        public void InsertBefore_InsertsElementBeforeTargetCorrectly()
        {
            var list = new DoubleLinkedList<int>();
            list.InsertBefore(default!, 3);

            list.InsertBefore(3, 2);
            list.InsertBefore(2, 1);
            list.InsertAfter(3, 4);

            Assert.That(list.PosOfElement(1), Is.EqualTo(0));
            Assert.That(list.PosOfElement(2), Is.EqualTo(1));
            Assert.That(list.PosOfElement(3), Is.EqualTo(2));
            Assert.That(list.PosOfElement(4), Is.EqualTo(3));
        }

    }
}