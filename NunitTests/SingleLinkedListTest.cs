using System;
using AlgoDataStructures;
using NUnit.Framework;

namespace NunitTests
{
    [TestFixture]
    public class SingleLikedListTest
    {
        
        [Test]
        public void AddTest()
        {
            SingleLinkedList<char> linkedList = new SingleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            
            Assert.AreEqual(linkedList.Count, 2);
        }
        
        [Test]
        public void RemoveTest()
        {
            SingleLinkedList<char> linkedList = new SingleLinkedList<char>();
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
            SingleLinkedList<char> linkedList = new SingleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            linkedList.Add('C');
            var expected = linkedList.Get(1);
            Assert.AreEqual(expected.Data, 'B');
        }
        
        [Test]
        public void RemoveAtTest()
        {
            SingleLinkedList<char> linkedList = new SingleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            linkedList.Add('C');
            linkedList.Add('D');
            linkedList.RemoveAt(1);
            var expected = linkedList.Get(1);
            
            Assert.AreEqual(expected.Data, 'C');
        }
        
        [Test]
        public void RemoveLastTest()
        {
            SingleLinkedList<char> linkedList = new SingleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            linkedList.Add('C');
            linkedList.Add('D');
            linkedList.RemoveLast();
            var expected = linkedList.Get(2);
            
            Assert.AreEqual(expected.Data, 'C');
        }
        
        [Test]
        public void InsertTest()
        {
            SingleLinkedList<char> linkedList = new SingleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('C');
            linkedList.Add('D');
            linkedList.Insert('B',1);
            
            Assert.AreEqual(linkedList.Get(1).Data, 'B');
        }
        
        [Test]
        public void ToStringTest()
        {
            SingleLinkedList<char> linkedList = new SingleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            linkedList.Add('C');
            
            Assert.AreEqual(linkedList.ToString(), "A, B, C");
        }
        
        [Test]
        public void SearchTest()
        {
            SingleLinkedList<char> linkedList = new SingleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            linkedList.Add('C');
            linkedList.Add('B');
            
            Assert.AreEqual(linkedList.Search('B'), 1);
        }
        [Test]
        public void ClearTest()
        {
            SingleLinkedList<char> linkedList = new SingleLinkedList<char>();
            linkedList.Add('A');
            linkedList.Add('B');
            linkedList.Add('C');
            linkedList.Add('B');
            linkedList.Clear();
            
            Assert.AreEqual(linkedList.Count, 0);
        }

        [Test]
        public void NegativeRangeTest()
        {
            SingleLinkedList<char> linkedList = new SingleLinkedList<char>();
            linkedList.Add('A');
            Assert.Throws<IndexOutOfRangeException>(() => linkedList.Get(-1));
        }
        
        [Test]
        public void OutOfRangeTest()
        {
            SingleLinkedList<char> linkedList = new SingleLinkedList<char>();
            linkedList.Add('A');
            Assert.Throws<IndexOutOfRangeException>(() => linkedList.Get(3));
        }
        
    }
}