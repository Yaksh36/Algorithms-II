namespace BinaryTreeDataStructures
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data, Node<T> left = null, Node<T> right = null)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public Node()
        {
            
        }
    }
}