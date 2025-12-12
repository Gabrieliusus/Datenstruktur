using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Datenstrukturen
{
    public class SinglyLinkedList<T>
    {
        private static Node<T> head;
        public Node<T> InsertAtEnd(T person)
        {
            Node<T> newNode = new Node<T>(person);
            if (head == null)
            {
                head = newNode;
                return newNode;
            }
            Node<T> last = head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            last.Next = newNode;
            return head;
        }
        public Node<T> InsertAfter(T elementBefore, T elementToInsert)
        {
            Node<T> current = head;
            if(head.Data.Equals(elementBefore))
            {
                Node<T> newNode = new Node<T>(elementToInsert);
                newNode.Next = head.Next;
                head.Next = newNode;
                return head;
            }
            while (current != null && !current.Data.Equals(elementBefore))
            {
                current = current.Next;
            }
            if (current == null)
            {
                return null;
            }
            Node<T> newNode2 = new Node<T>(elementToInsert);
            newNode2.Next = current.Next;
            current.Next = newNode2;
            return newNode2;
        }
        public Node<T> InsertBefore(T elementAfter, T elementToInsert)
        {
            Node<T> current = head;
            if (head != null && head.Data.Equals(elementAfter))
            {
                Node<T> newNode = new Node<T>(elementToInsert);
                newNode.Next = head;
                head = newNode;
                return newNode;
            }
            while (current != null && current.Next != null && !current.Next.Data.Equals(elementAfter))
            {
                current = current.Next;
            }

            if (current.Next == null)
            {
                return null;
            }
            Node<T> newNode2 = new Node<T>(elementToInsert);
            newNode2.Next = current.Next;
            current.Next = newNode2;
            return newNode2;

        }

        public int PosOfElement(T person)
        {
            Node<T> current = head;
            int pos = 0;
            while (current != null)
            {
                if (current.Data.Equals(person))
                {
                    return pos;
                }
                current = current.Next;
                pos++;
            }
            return -1; 
        }

        public void printSinglyLinkedList()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
}
