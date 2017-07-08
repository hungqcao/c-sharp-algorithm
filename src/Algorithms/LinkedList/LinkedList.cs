using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LinkedList
{
    class LinkedList
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
    }
}
