using Common;
using SortingAlgorithms;

namespace Datenstrukturen
{
    public class DoubleLinkedList<T> where T : IComparable<T>
    {
        private static Node<T> head;
        private ISortAlgorithm<T> sortAlgorithm;
        public DoubleLinkedList()
        {
            head = null;
        }
        public Node<T> InsertAfter(T elementBefore, T elementToInsert)
        {
            Node<T> newNode = new Node<T>(elementToInsert);
            if (head == null)
            {
                head = newNode;
                return newNode;
            }
            Node<T> current = head;
            while (current != null && !current.Data.Equals(elementBefore))
            {

                current = current.Next;
            }
            if (current == null)
                return null;
           
            newNode.Next = current.Next;
            newNode.Before = current;
            if (current.Next != null)
            {
                current.Next.Before = newNode;
            }
            current.Next = newNode;
            return newNode;
        }

        public Node<T> InsertBefore(T elementAfter, T elementToInsert)
        {
            Node<T> current = head;
            if (head != null && head.Data.Equals(elementAfter))
            {
                Node<T> newNode = new Node<T>(elementToInsert);
                newNode.Next = head;
                head.Before = newNode;
                head = newNode;
                return newNode;
            }
            while (current != null && !current.Data.Equals(elementAfter))
            {
                current = current.Next;
            }
            if (current == null)
            {
                return null;
            }
            Node<T> newNode2 = new Node<T>(elementToInsert);
            newNode2.Next = current;
            newNode2.Before = current.Before;
            if (current.Before != null)
            {
                current.Before.Next = newNode2;
            }
            current.Before = newNode2;
            return newNode2;
        }

        public int PosOfElement(T person)
        {
            Node<T> current = head;
            int pos = 0;
            while (current != null)
            {
                if(current.Data.Equals(person))
                {
                    return pos;
                }
                current = current.Next;
                pos++;
            }
            return -1;
        }
        public void SetSortAlgorithm(ISortAlgorithm<T> algorithm)
        {
            sortAlgorithm = algorithm;
        }
        public void Sort()
        {
            sortAlgorithm.Sort(head);
        }
    }
}
