using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LinkedList
{
    public class LinkedList
    {
        public Node reverse(Node head)
        {
            Node current = head;
            Node prev = null;
            while (current != null)
            {
                Node next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }
        public static Node mergeSortedLinkedList(Node a, Node b)
        {
            if (a == null)
            {
                return b;
            }
            if (b == null)
            {
                return a;
            }
            Node result = null;
            if (a.val <= b.val)
            {
                result = a;
                result.next = mergeSortedLinkedList(a.next, b);
            }
            else
            {
                result = b;
                result.next = mergeSortedLinkedList(a, b.next);
            }
            return result;
        }

        /// <summary>
        /// https://leetcode.com/problems/baseball-game/description/
        /// </summary>
        /// <param name="ops"></param>
        /// <returns></returns>
        public static int CalPoints(string[] ops)
        {
            var ret = 0;
            var linkedList = new LinkedList<int>();

            for (int i = 0; i < ops.Length; i++)
            {
                switch (ops[i])
                {
                    case "C":
                        var last = linkedList.Last;
                        ret -= last.Value;
                        linkedList.RemoveLast();
                        break;
                    case "D":
                        var lst = linkedList.Last.Value;
                        linkedList.AddLast(lst * 2);
                        ret += lst * 2;
                        break;
                    case "+":
                        var point = linkedList.Last.Value + linkedList.Last.Previous.Value;
                        linkedList.AddLast(point);
                        ret += point;
                        break;
                    default:
                        var cur = int.Parse(ops[i]);
                        linkedList.AddLast(cur);
                        ret += cur;
                        break;
                }
            }

            return ret;
        }
    }
}
