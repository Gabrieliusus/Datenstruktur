using Common;

namespace Common
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Next;
        public Node<T> Before;
        public Node(T argData)
        {
            Data = argData;
        }
    }
}
