using System;
using System.Linq;
using Common;
using Einfache_Liste;
using NUnit.Framework;

namespace Einfache_Liste.Tests
{
    [TestFixture]
    public class SinglyLinkedListTests<T>
    {
        private static Person P(string name, string g = "männlich", int y = 2003, int m = 1, int d = 1)
            => new Person(new DateTime(y, m, d), g, name);

        [Test]
        public void Insert_AddsAtHead_InReverseOrderOfCalls()
        {
            var list = new SinglyLinkedList<Person>();
            list.Insert(P("A"));
            list.Insert(P("B"));
            list.Insert(P("C"));

            var names = list.ToEnumerable().Select(p => p.Name).ToArray();
            Assert.That(names, Is.EqualTo(new[] { "C", "B", "A" }));
        }

        [Test]
        public void InsertAtEnd_AppendsToTail_PreservesOrder()
        {
            var list = new SinglyLinkedList<Person>();
            list.InsertAtEnd(P("A"));
            list.InsertAtEnd(P("B"));
            list.InsertAtEnd(P("C"));

            var names = list.ToEnumerable().Select(p => p.Name).ToArray();
            Assert.That(names, Is.EqualTo(new[] { "A", "B", "C" }));
        }

        [Test]
        public void InsertAtEnd_OnEmptyList_CreatesHead()
        {
            var list = new SinglyLinkedList<Person>();
            list.InsertAtEnd(P("Only"));

            Assert.That(list.Head, Is.Not.Null);
            Assert.That(list.Head!.Data.Name, Is.EqualTo("Only"));
            Assert.That(list.Head.Next, Is.Null);
        }

        [Test]
        public void Search_FindsExisting_ByPredicate()
        {
            var list = new SinglyLinkedList<Person>();
            list.Insert(P("Magdalena", "weiblich"));
            list.InsertAtEnd(P("Felix"));
            list.Insert(P("Gabriel"));

            var found = list.Search(p => p.Name == "Gabriel");

            Assert.That(found, Is.Not.Null);
            Assert.That(found!.Data.Name, Is.EqualTo("Gabriel"));
        }

        [Test]
        public void Search_ReturnsNull_WhenNotFound()
        {
            var list = new SinglyLinkedList<Person>();
            list.Insert(P("Magdalena"));

            var found = list.Search(p => p.Name == "NichtDa");
            Assert.That(found, Is.Null);
        }

        [Test]
        public void ToEnumerable_EmptyList_YieldsNothing()
        {
            var list = new SinglyLinkedList<Person>();
            Assert.That(list.ToEnumerable(), Is.Empty);
        }

        [Test]
        public void Test1()
        {
            SinglyLinkedList<String> list = new();
            list.Insert("bla");
            var bla =list.GetLastNode();
            Assert.That(bla, Is.Not.Null);
        }
    }
}
