namespace DataStructure_LinkedList
{
    public interface ILinkedList<T>
    {
        int Count { get; set; }
        GenericNode<T> Head { get; set; }
        void AddFirst(GenericNode<T> node);
        GenericNode<T> AddFirst(T data);
        void AddLast(GenericNode<T> node);
        GenericNode<T> AddLast(T data);
        void AddBefore(GenericNode<T> node, GenericNode<T> newNode);
        GenericNode<T> AddBefore(GenericNode<T> node, T data);
        void AddSorted(GenericNode<T> newNode);
        GenericNode<T> AddSorted(T data);
        GenericNode<T> RemoveByValue(T data);
        GenericNode<T> RemoveByIndex(int index);
        string ToString();
    }
}
