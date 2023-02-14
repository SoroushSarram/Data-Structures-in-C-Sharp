namespace DCLinkedLists
{
    public class GenericNode<T>
    {
        //In doubly cicular linked list 
        //every node will have the value of the node
        // a pointer to its previous node 
        // a pointer to its next node
        private T data;//data
        private GenericNode<T> next;//pointer to next node
        public GenericNode<T> prev;//pointer to previous node
        public GenericNode(T initialData)
        {
            // constructor
            // when we create a node we set data and create 2 other
            // nodes for prev and next and set the reference
            data = initialData;
            next = null;
            prev = null;
        }
        //public properties with getter and setter
        public T Data { get => data; set => data = value; }
        public GenericNode<T> Next { get => next; set => next = value; }
        public GenericNode<T> Prev { get => prev; set => prev = value; }
    }
}
