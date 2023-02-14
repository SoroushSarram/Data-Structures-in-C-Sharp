namespace DataStructure_Stack
{
    public interface IStack<T>
    {
        void Push(T item);
        T Peek();
        T Pop();
        void Clear();
        bool Contains(T item);
        int Count();
    }
}
