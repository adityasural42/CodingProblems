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
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
            {
                return "";
            }
            var prefix = strs[0];
            foreach (var str in strs)
            {
                while (!str.StartsWith(prefix))
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (prefix == "")
                    {
                        return "";
                    }
                }
            }
            return prefix;
            // var shortestStrLen=strs[0].Length;
            // for(int i=0;i<strs.Length;i++){
            //     if(strs[i].Length<shortestStrLen){
            //         shortestStrLen=strs[i].Length;
            //     }
            // }
            // var counter=0;
            // var preStr=new StringBuilder();
            // var prefixBroke=false;
            // while(counter<shortestStrLen){
            //     char c='\0';
            //     for(int i=0;i<strs.Length;i++){
            //         if(c=='\0'){
            //             c=strs[i][counter];
            //         }
            //         if(c!=strs[i][counter]){
            //             prefixBroke=true;
            //             break;
            //         }
            //     }
            //     if(!prefixBroke){
            //         preStr.Append(c);
            //     }else{
            //         break;
            //     }
            //     counter++;
            // }
            // return preStr.ToString();
        }
        public static int MaxContainers(int n, int w, int maxWeight)
        {
            int maxCont = maxWeight / w;
            var cargoDeck = n * n;
            return maxCont > cargoDeck ? cargoDeck : maxCont;
        }
    }
}
