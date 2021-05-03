namespace AlgoDataStructures
{
    public class SingleLinkedList<T>
    {
        public Node<T> head { get; set; }

        public int Count { get; set; }

        public void Add(T val)
        {
            
        }

        public void Insert(T val, int index)
        {
            
        }
        
        public Node<T> Get(int index)
        {

            return null;
        }

        public T Remove()
        {
            return head.Data;
        }

        public T RemoveAt(int index)
        {
           //Node<T> node = new Node<T>();
            return head.Data;
        }

        public T RemoveLast()
        {
            return head.Data;
        }

        public override string ToString()
        {
            return " ";
        }

        public void Clear()
        {
            
        }

        public int Search(T val)
        {
            return -1;
        }
    }
}