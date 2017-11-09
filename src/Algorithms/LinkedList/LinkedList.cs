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

        /// <summary>
        /// https://leetcode.com/problems/remove-linked-list-elements/description/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return null;

            head.next = RemoveElements(head.next, val);

            if (head.val == val) return head.next;
            else return head;
        }

        /// <summary>
        /// https://leetcode.com/problems/intersection-of-two-linked-lists/description/
        /// sol 1: calculate diff in lengths of them
        /// sol 2: switch heads
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;
            var a = headA;
            var b = headB;

            while(a != b)
            {
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;
            }

            return a;
        }

        /// <summary>
        /// https://leetcode.com/problems/add-two-numbers-ii/description/
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();

            while (l1 != null)
            {
                s1.Push(l1.val);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                s2.Push(l2.val);
                l2 = l2.next;
            }

            int sum = 0;
            ListNode head = new ListNode(0);
            while(s1.Any() || s2.Any())
            {
                if (s1.Any()) sum += s1.Pop();
                if (s2.Any()) sum += s2.Pop();

                head.val = sum / 10;
                var tmp = new ListNode(sum % 10);
                sum = sum / 10;
                tmp.next = head.next;
                head.next = tmp;
            }

            return head.val == 0 ? head.next : head;
        }
    }
}
