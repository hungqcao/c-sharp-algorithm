using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LinkedList
{
    public class LinkedList
    {
        public static ListNode reverse(ListNode head)
        {
            ListNode current = head;
            ListNode prev = null;
            while (current != null)
            {
                ListNode next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }
        public static ListNode mergeSortedLinkedList(ListNode a, ListNode b)
        {
            if (a == null)
            {
                return b;
            }
            if (b == null)
            {
                return a;
            }
            ListNode result = null;
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

        /// <summary>
        /// https://leetcode.com/problems/linked-list-cycle/description/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool HasCycle(ListNode head)
        {
            if (head == null) return false;

            var slow = head;
            var fast = head;
            while (slow != null && slow.next != null && fast != null && fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if(slow.val == fast.val)
                {
                    return true;
                }
            }

            return false;
        }

        public static ListNode DetectCycle(ListNode head)
        {
            if (head == null) return null;

            var slow = head;
            var fast = head;
            while (fast != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow.val == fast.val)
                {
                    return FindCycle(slow, head);
                }
            }

            return null;
        }

        public static ListNode FindCycle(ListNode node, ListNode head)
        {
            var tmp = node;
            
            while(tmp != head)
            {
                tmp = tmp.next;
                head = head.next;
            }

            return tmp;
        }

        /// <summary>
        /// https://leetcode.com/problems/palindrome-linked-list/description/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null) return false;

            ListNode slow = head;
            ListNode fast = head;

            while(fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            slow.next = reverse(slow.next);
            
            slow = slow.next;
            while(slow != null)
            {
                if (head.val != slow.val) return false;
                head = head.next;
                slow = slow.next;
            }

            return true;
        }
    }
}
