namespace Common;

public class Node<T>
{
    public T Data;
    public Node<T>? Next;
    public Node<T>? Prev; // für DoubleLinkedList

    public Node(T data)
    {
        Data = data;
    }

    public override string ToString() => Data?.ToString() ?? "null";
}
