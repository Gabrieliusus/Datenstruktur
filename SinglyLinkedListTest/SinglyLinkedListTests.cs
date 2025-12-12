using Common;
using Datenstrukturen;
using System;
namespace DatenstrukturenTests
{
    [TestFixture]
    public class Tests
    {
        private SinglyLinkedList<Person> list;
        private Person p1;
        private Person p2;
        private Person p3;
        private Person p4;

        [SetUp]
        public void SetUp()
        {
            list = new SinglyLinkedList<Person>();

            p1 = new Person(new DateTime(2000, 1, 1), "weiblich", "Onur");
            p2 = new Person(new DateTime(2000, 1, 1), "weiblich", "Arslan");
            p3 = new Person(new DateTime(2000, 1, 1), "männlich", "Mehmet");
            p4 = new Person(new DateTime(2000, 1, 1), "männlich", "Gabriel");
        }

        [Test]
        public void InsertAtEnd_InsertTwoElementsInEmptyList_AddNodesCorrectly()
        {
            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);

            Assert.AreEqual(0, list.PosOfElement(p1));
            Assert.AreEqual(1, list.PosOfElement(p2));
        }

        [Test]
        public void InsertBefore_ReturnsCorrectNode()
        {
            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);
            list.InsertAtEnd(p3);

            list.InsertBefore(p2, p4);

            Assert.AreEqual(1, list.PosOfElement(p4));
        }
        [Test]
        public void InsertAfter_ReturnsCorrectNode()
        {
            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);
            list.InsertAtEnd(p3);

            list.InsertAfter(p2, p4);
            Assert.AreEqual(2, list.PosOfElement(p4));
        }

        [Test]
        public void PosOfElement_ReturnCorrectPosNumber()
        {
            list.InsertAtEnd(p1);
            list.InsertAtEnd(p2);
            list.InsertAtEnd(p3);
            list.InsertAtEnd(p4);

            int result = list.PosOfElement(p3);
            Assert.AreEqual(2, result);
        }
    }
}