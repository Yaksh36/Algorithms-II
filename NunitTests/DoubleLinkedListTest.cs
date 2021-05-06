using AlgoDataStructures;
using NUnit.Framework;

namespace NunitTests
{
    [TestFixture]
    public class DoubleLinkedListTest
    {
        [Test]
        public void AddTest()
        {
            DoubleLinkedList<char> linkedList = new DoubleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            
            Assert.AreEqual(linkedList.Count, 2);
        }
        
        [Test]
        public void RemoveTest()
        {
            DoubleLinkedList<char> linkedList = new DoubleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            linkedList.Add('C');
            linkedList.Add('D');
            linkedList.Remove();
            
            Assert.AreEqual(linkedList.Count, 3);
        }

        [Test]
        public void GetTest()
        {
            DoubleLinkedList<char> linkedList = new DoubleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            linkedList.Add('C');
            var expected = linkedList.Get(1);
            Assert.AreEqual(expected.Data, 'B');
        }
        
        [Test]
        public void RemoveAtTest()
        {
            DoubleLinkedList<char> linkedList = new DoubleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            linkedList.Add('C');
            linkedList.Add('D');
            linkedList.RemoveAt(1);
            var expected = linkedList.Get(1);
            
            Assert.AreEqual(expected.Data, 'C');
        }
        
        [Test]
        public void InsertTest()
        {
            DoubleLinkedList<char> linkedList = new DoubleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('C');
            linkedList.Add('D');
            linkedList.Insert('B',1);
            
            Assert.AreEqual(linkedList.Get(1).Data, 'B');
        }
        
        [Test]
        public void ToStringTest()
        {
            DoubleLinkedList<char> linkedList = new DoubleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            linkedList.Add('C');
            
            Assert.AreEqual(linkedList.ToString(), "A, B, C");
        }
        
        [Test]
        public void SearchTest()
        {
            DoubleLinkedList<char> linkedList = new DoubleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            linkedList.Add('C');
            linkedList.Add('B');
            
            Assert.AreEqual(linkedList.Search('B'), 1);
        }
        [Test]
        public void RemoveLastTest()
        {
            DoubleLinkedList<char> linkedList = new DoubleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            linkedList.Add('C');
            linkedList.Add('D');
            linkedList.RemoveLast();
            var expected = linkedList.Get(2);
            
            Assert.AreEqual(expected.Data, 'C');
        }
        [Test]
        public void ClearTest()
        {
            DoubleLinkedList<char> linkedList = new DoubleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            linkedList.Add('C');
            linkedList.Add('B');
            linkedList.Clear();
            
            Assert.AreEqual(linkedList.Count, 0);
        }
        
    }
}