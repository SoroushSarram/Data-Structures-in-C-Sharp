namespace DataStructure_LinkedList
{
    public class GenericNode<T>
    {
        private T data;
        private GenericNode<T> next;

        public GenericNode(T initialData)
        {
            data = initialData;
            next = null;
        }

        public T Data { get => data; set => data = value; }
        public GenericNode<T> Next { get => next; set => next = value; }

        public static int Compare(string left, string right)
        {
            int leftNumeric;
            int rightNumeric;
            if (int.TryParse(left, out leftNumeric) &&
                int.TryParse(right, out rightNumeric))
            {
                if (leftNumeric > rightNumeric)
                    return 1;
                else if (leftNumeric == rightNumeric)
                    return 0;
                else
                    return -1;
            }
            return string.Compare(left, right);
        }

        public static bool operator <(GenericNode<T> left, GenericNode<T> right)
        {
            return Compare(left.Data.ToString(), right.Data.ToString()) < 0;
        }

        public static bool operator >(GenericNode<T> left, GenericNode<T> right)
        {
            return Compare(left.Data.ToString(), right.Data.ToString()) > 0;
        }

        public static bool operator <=(GenericNode<T> left, GenericNode<T> right)
        {
            return Compare(left.Data.ToString(), right.Data.ToString()) < 0;
        }

        public static bool operator >=(GenericNode<T> left, GenericNode<T> right)
        {
            return Compare(left.Data.ToString(), right.Data.ToString()) > 0;
        }
    }
}
