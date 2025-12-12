using Common;

namespace SortingAlgorithms
{
    public class BubbleSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        void SwapNodes(Node<T> current)
        {
            T temp = current.Data;
            current.Data = current.Next.Data;
            current.Next.Data = temp;
        }
        public void Sort(Node<T> head)
        {
            if (head == null)
                return;

            bool isSwapped;
            Node<T> last = null;

            do
            {
                isSwapped = false;
                Node<T> current = head;

                while (current.Next != last)
                {
                    if (current.Data.CompareTo(current.Next.Data) > 0)
                    {
                        SwapNodes(current);
                        isSwapped = true;
                    }
                    current = current.Next;
                }

                last = current;
            } while (isSwapped);
        }
    }
}
