namespace Common;

public class Node<T>
{
    public T Data;
    public Node<T> Next;
    //Constructor to create a new node
    public Node(T argData) { Data = argData; }
}
