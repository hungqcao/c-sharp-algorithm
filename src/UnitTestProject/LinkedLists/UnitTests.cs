using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.LinkedLists
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod_CalPoints()
        {
            Assert.AreEqual(Algorithms.LinkedList.LinkedList.CalPoints(new string[] { "5", "2", "C", "D", "+" }), 30);
            Assert.AreEqual(Algorithms.LinkedList.LinkedList.CalPoints(new string[] { "5", "-2", "4", "C", "D", "9", "+", "+" }), 27);
        }

        [TestMethod]
        public void Test_DetectCycle()
        {
            var node1 = new ListNode(-1);
            var node2 = new ListNode(-7);
            var node3 = new ListNode(7);
            var node4 = new ListNode(-4);
            var node5 = new ListNode(19);
            var node6 = new ListNode(6);
            var node7 = new ListNode(-9);
            var node8 = new ListNode(-5);
            var node9 = new ListNode(-2);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            node7.next = node8;
            node8.next = node9;
            node9.next = node8;

            var output = Algorithms.LinkedList.LinkedList.DetectCycle(node1);

            Assert.AreEqual(node3.val, output.val);
        }


        [TestMethod]
        public void Test_IsPalindrom()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node2r = new ListNode(2);
            var node1r = new ListNode(1);
            node1.next = node2;
            node2.next = node3;
            node3.next = node2r;
            node2r.next = node1r;

            var output = Algorithms.LinkedList.LinkedList.IsPalindrome(node1);

            Assert.AreEqual(true, output);

            node1 = new ListNode(1);
            node2 = new ListNode(2);
            node2r = new ListNode(2);
            node1r = new ListNode(1);
            node1.next = node2;
            node2.next = node2r;
            node2r.next = node1r;

            output = Algorithms.LinkedList.LinkedList.IsPalindrome(node1);

            Assert.AreEqual(true, output);
        }
    }
}
