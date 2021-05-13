using BinaryTreeDataStructures;
using NUnit.Framework;

namespace NunitTests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]
        public void TestAdd()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(6);
            binarySearchTree.Add(4);
            Assert.AreEqual(binarySearchTree.Count, 2);
        }

        [Test]
        public void ContainsTest()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(6);
            binarySearchTree.Add(4);
            Assert.AreEqual(binarySearchTree.Contains(6), true);
        }
        
        [Test]
        public void RemoveTest()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(6);
            binarySearchTree.Add(4);
            binarySearchTree.Remove(4);
            Assert.AreEqual(binarySearchTree.Contains(4), false);
        }
        
        [Test]
        public void ClearTest()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(6);
            binarySearchTree.Add(4);
            binarySearchTree.Clear();
            Assert.AreEqual(binarySearchTree.Count, 0);
        }

        [Test]
        public void CountTest()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(6);
            binarySearchTree.Add(4);
            binarySearchTree.Add(2);
            
            Assert.AreEqual(binarySearchTree.Count, 3);
        }
        
        
        [Test]
        public void InOrderTest()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(6);
            binarySearchTree.Add(8);
            binarySearchTree.Add(4);
            Assert.AreEqual(binarySearchTree.InOrder(), "4, 6, 8");
        }
        
        [Test]
        public void PostOrderTest()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(6);
            binarySearchTree.Add(8);
            binarySearchTree.Add(4);
            Assert.AreEqual(binarySearchTree.PostOrder(), "4, 8, 6");
        }
        
        [Test]
        public void PreOrderTest()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(6);
            binarySearchTree.Add(4);
            binarySearchTree.Add(8);
            Assert.AreEqual(binarySearchTree.PreOrder(), "6, 4, 8");
        }
        
        [Test]
        public void HeightTest()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(6);
            binarySearchTree.Add(4);
            binarySearchTree.Add(8);
            Assert.AreEqual(binarySearchTree.Height(), 2);
        }
        
        [Test]
        public void EmptyTreeHeightTest()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(6);
            Assert.AreEqual(binarySearchTree.Height(), 1);
        }
        
        [Test]
        public void ToArray()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(6);
            binarySearchTree.Add(8);
            binarySearchTree.Add(4);
            Assert.AreEqual(binarySearchTree.ToArray(), new int[]{4,6,8});
        }

        
        
    }
}