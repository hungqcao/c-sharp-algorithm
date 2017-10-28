using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ListNode
    {
        public ListNode(int v)
        {
            this.val = v;
        }

        public ListNode next { get; set; }
        public int val { get; set; }
    }
}
