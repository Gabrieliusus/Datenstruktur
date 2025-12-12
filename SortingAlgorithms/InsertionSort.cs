using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class InsertionSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public void Sort(Node<T> head)
        {
            if (head == null || head.Next == null)
                return;

            Node<T> current = head.Next;

            while (current != null)
            {
                T value = current.Data;
                Node<T> before = current.Before;

                while (before != null && before.Data.CompareTo(value) > 0)
                {
                    before.Next.Data = before.Data;  
                    before = before.Before;
                }

                if (before == null)
                    head.Data = value;
                else
                    before.Next.Data = value;

                current = current.Next;
            }
        }
    }

}
