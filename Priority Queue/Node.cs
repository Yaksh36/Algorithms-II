namespace Priority_Queue
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        
        public Node<T> Parent { get; set; }

        public Node(T data, Node<T> parent = null, Node<T> left = null, Node<T> right = null)
        {
            Data = data;
            Left = left;
            Right = right;
            Parent = parent;
        }

        public Node()
        {
            
        }
    }
}