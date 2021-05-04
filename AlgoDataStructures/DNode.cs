namespace AlgoDataStructures
{
    public class DNode<T>
    {
        public T Data { get; set; }
        public DNode<T> Next { get; set; }
        public DNode<T> Prev { get; set; }
        
        public DNode(T data, DNode<T> next = null, DNode<T> previous = null)
        {
            Data = data;
            Next = next;
            Prev = previous;
        }

        public DNode()
        {
            
        }
    }
}