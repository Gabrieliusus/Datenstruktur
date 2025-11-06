namespace Common;

public class Node<T>
{
    public T Data;
    public Node<T>? Next;   // für einfach & doppelt verkettet
    public Node<T>? Prev;   // wird von DoubleLinkedList genutzt

    public Node(T data) => Data = data;
}
