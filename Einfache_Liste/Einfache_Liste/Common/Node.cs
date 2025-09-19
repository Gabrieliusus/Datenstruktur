namespace Common;

public class Node
{
    public Person Data;
    public Node? Next;

    public Node(Person data)
    {
        Data = data;
        Next = null;
    }
}
