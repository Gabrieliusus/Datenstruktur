namespace DoubleLinkedList;

public class DNode<T>
{
    public T Data;
    public DNode<T>? Prev;
    public DNode<T>? Next;

    public DNode(T data) => Data = data;
}
