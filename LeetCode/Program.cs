using System.Numerics;

namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            BigInteger deno = 1;
            BigInteger l1Number = 0;
            BigInteger l2Number = 0;
            do
            {
                if (l1 != null)
                {
                    l1Number += deno * l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    l2Number += deno * l2.val;
                    l2 = l2.next;
                }
                deno *= 10;
            } while (l1 != null || l2 != null);
            BigInteger sum = l1Number + l2Number;
            var head = new ListNode();
            if (sum == 0)
            {
                return new ListNode();
            }
            head.val = (int)(sum % 10);
            var sumLinList = head;
            sum /= 10;
            while (sum != 0)
            {
                sumLinList.next = new ListNode();
                sumLinList = sumLinList.next;
                sumLinList.val = (int)(sum % 10);
                sum /= 10;

            }
            return head;
        }
    }
}
