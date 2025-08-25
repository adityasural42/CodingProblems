using System.Collections.Generic;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace TestApplication
{

//    You are given a list of movie objects, where each object contains two properties:
//	•	name(string) : the name of the movie
//	•	rank(integer) : the current rank of the movie(1 = highest, N = lowest)


//Your task is to implement a function that updates the rank of a specified movie to a new rank.When this change is made, the other movies must adjust their ranks accordingly to maintain a continuous and non-conflicting ranking sequence.

//movies = [
//    {"name": "Inception", "rank": 1},
//    {"name": "The Prestige", "rank": 2},
//    { "name": "Edge of Tomorrow", "rank": 3},
//    { "name": "Interstellar", "rank": 4},
//    { "name": "The Dark Knight", "rank": 5}
//]
 
    internal class Program
    {
        static void Main(string[] args)
        {
            var movieDict = new Dictionary<int, string>
            {
                {1,"Inception"},
                 {2,"The Prestige"},
                { 3,"Edge of Tomorrow"},
                { 4,"Interstellar"},
                { 5,"The Dark Knight"}                                                                  
            };

            movieDict=UpdateRank(movieDict, 4, "Edge of Tomorrow");
            for(int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i+" -- "+movieDict[i]);
            }
            
        }
        static Dictionary<int, string> UpdateRank(Dictionary<int, string> dict,int newRank, string movieName)
        {
            if (dict[newRank] == movieName)
            {
                return dict;
            }
            var currentRank = 0;
            foreach (var item in dict) {
                if (item.Value == movieName)
                {
                    currentRank = item.Key;
                    dict.Remove(item.Key);
                    break;
                }
            }
            
            Queue<string> movieQueue = new Queue<string>();
            for(var rankHolder =1; rankHolder <= 5; rankHolder++)
            {
                //If 
                if (newRank > currentRank)
                {
                    if (dict.ContainsKey(rankHolder))
                    {
                        movieQueue.Enqueue(dict[rankHolder]);
                    }
                    if (rankHolder == newRank)
                    {
                        movieQueue.Enqueue(movieName);
                    }
                }
                else
                {
                    if (rankHolder == newRank)
                    {
                        movieQueue.Enqueue(movieName);
                    }
                    if (dict.ContainsKey(rankHolder))
                    {
                        movieQueue.Enqueue(dict[rankHolder]);
                    }
                }
            }
            var updatedDict=new Dictionary<int, string>();
            int rank = 1;
            while (movieQueue.Count > 0)
            {
                updatedDict.Add(rank, movieQueue.Dequeue());
                rank++;
            }
            return updatedDict;
        }
        public static int minimumDistances(List<int> a)
        {
            var minDist = -1;
            var aArr = a.ToArray();
            for (int i = 0; i < aArr.Count() - 1; i++)
            {
                for (int j = i + 1; j < aArr.Count(); j++)
                {
                    if (aArr[i] == aArr[j])
                    {
                        if (minDist == -1 || minDist > Math.Abs(i - j))
                        {
                            minDist = Math.Abs(i - j);
                        }
                    }
                }
            }
            return minDist;
        }
        public static List<int> permutationEquation(List<int> p)
        {
            var dict = new Dictionary<int, int>();
            var x = 1;
            foreach (var pi in p)
            {
                dict.Add(pi, x);
                x++;
            }
            var res = new List<int>();
            var pArr = p.ToArray();
            for (int i = 1; i <= p.Count(); i++)
            {
                res.Add(dict[dict[i]]);
            }
            return res;
        }
        public static long repeatedString(string s, long n)
        {
            var finalChar = n % s.Count();
            var repeats = n / s.Count();
            long asCount = 0;
            long remainas = 0;
            long i = 0;
            foreach (var a in s)
            {
                if (a == 'a')
                {
                    asCount++;
                    if (i < finalChar)
                    {
                        remainas++;
                    }
                }
                i++;
            }
            return (repeats * asCount) + remainas;
        }
        public static List<int> matchingStrings(List<string> stringList, List<string> queries)
        {
            var dict = new Dictionary<string, int>();
            var res = new List<int>();
            foreach (var s in stringList)
            {
                if (dict.ContainsKey(s))
                {
                    dict[s] += 1;
                }
                else
                {
                    dict.Add(s, 1);
                }
            }
            foreach (var q in queries)
            {
                if (dict.ContainsKey(q))
                {
                    res.Add(dict[q]);
                }
                else
                {
                    res.Add(0);
                }
            }
            return res;
        }
        public static List<int> rotateLeft(int d, List<int> arr)
        {
            var a = arr.ToArray();
            var res = new int[a.Count()];
            for (int i = 0; i < a.Count(); i++)
            {
                res[i] = a[d];
                d++;
                if (d == a.Count())
                {
                    d = 0;
                }
            }
            return res.ToList();
        }

        public static List<int> reverseArray(List<int> a)
        {
            var aArr = a.ToArray();
            var res = new int[aArr.Count()];
            for (int i = aArr.Count() - 1; i >= 0; i--)
            {
                res[res.Count() - i - 1] = aArr[i];
            }
            return res.ToList();
        }

        static int jumpingOnClouds(int[] c, int k)
        {

            var currentCloud = 0;
            var energy = 100;

            do
            {
                currentCloud += k;
                if (currentCloud > c.Count() - 1)
                {
                    currentCloud = currentCloud % c.Count();
                }
                energy--;
                if (c[currentCloud] == 1)
                {
                    energy -= 2;
                }

            } while (currentCloud != 0);
            return energy;
        }
        public static int designerPdfViewer(List<int> h, string word)
        {
            var initialChar = 'a';
            var dict = new Dictionary<char, int>();
            foreach (var hIn in h)
            {
                dict.Add(initialChar, hIn);
                initialChar++;
            }
            var max = 0;
            foreach (var c in word)
            {
                if (dict[c] > max)
                {
                    max = dict[c];
                }
            }
            return word.Count() * max;
        }
        public static int chocolateFeast(int n, int c, int m)
        {
            var wrappers = n / c;
            var totalChocolates = wrappers;
            while (wrappers >= m)
            {
                var currentChocs = wrappers / m;
                totalChocolates += currentChocs;
                wrappers -= m * currentChocs;
                wrappers += currentChocs;
            }
            return totalChocolates;
        }
        public static int jumpingOnClouds(List<int> c)
        {
            var cArr = c.ToArray();
            var jumps = 0;
            var cloudIndex = 0;
            while (cloudIndex <= cArr.Count() - 3)
            {
                if (cArr[cloudIndex + 1] != 0)
                {
                    jumps++;
                    cloudIndex += 2;
                }
                else if (cArr[cloudIndex + 2] != 0)
                {
                    jumps++;
                    cloudIndex += 1;
                }
                else
                {
                    jumps++;
                    cloudIndex += 2;
                }
            }
            if (cloudIndex == cArr.Count() - 2)
            {
                jumps++;
            }
            return jumps;
        }
        public static int viralAdvertising(int n)
        {
            var share = 5;
            var likes = 0;
            for (int i = 1; i <= n; i++)
            {
                likes += (int)Math.Floor((double)share / 2);
                share = (int)Math.Floor((double)share / 2) * 3;
            }
            return likes;
        }
        public static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
        {
            int appCount = 0, oraCount = 0;
            foreach (var app in apples)
            {
                if (app + a >= s && app + a <= t)
                {
                    appCount++;
                }
            }
            foreach (var ora in oranges)
            {
                if (ora + b >= s && ora + b <= t)
                {
                    oraCount++;
                }
            }
            Console.WriteLine(appCount);
            Console.WriteLine(oraCount);
        }
        public static int findDigits(int n)
        {
            var charArr = n.ToString().ToCharArray();
            var countOfFactors = 0;
            foreach (var c in charArr)
            {
                Console.WriteLine(c);
                var i = Convert.ToInt32(c.ToString());
                Console.WriteLine(i);
                if (i != 0 && n % i == 0)
                {
                    countOfFactors++;
                }
            }
            return countOfFactors;
        }
        public static string angryProfessor(int k, List<int> a)
        {
            a.Sort();
            var earlyArr = 0;
            var arr = a.ToArray();
            while (arr[earlyArr] <= 0)
            {
                earlyArr++;
            }
            Console.WriteLine(earlyArr);
            return earlyArr >= k ? "NO" : "YES";
        }
        public static int beautifulDays(int i, int j, int k)
        {
            var beauDays = 0;
            for (int a = i; a <= j; a++)
            {
                var strNum = a.ToString();
                var revStr = Reverse(strNum);
                var revInt = Convert.ToInt32(revStr);
                if ((Math.Abs(a - revInt)) % k == 0)
                {
                    beauDays++;
                }
            }
            return beauDays;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static int utopianTree(int n)
        {
            bool isSpring = true;
            int height = 1;
            for (int i = 0; i < n; i++)
            {
                if (isSpring)
                {
                    height *= 2;
                    isSpring = false;
                }
                else
                {
                    height += 1;
                    isSpring = true;
                }
            }
            return height;
        }
        public static int pageCount(int n, int p)
        {
            if (p == 1 || p == n)
            {
                return 0;
            }
            if (p <= n / 2)
            {
                return p % 2 == 0 ? p / 2 : (p - 1) / 2;
            }
            else
            {
                return n % 2 == 0 ? ((n - p) + 1) / 2 : (n - p) / 2;
            }
        }
        public static int sockMerchant(int n, List<int> ar)
        {
            var dict = new Dictionary<int, int>();
            var pairCount = 0;
            foreach (var a in ar)
            {
                if (dict.ContainsKey(a))
                {
                    dict[a]++;
                    if (dict[a] % 2 == 0)
                    {
                        pairCount++;
                    }
                }
                else
                {
                    dict.Add(a, 1);
                }
            }

            return pairCount;
        }
    }


    
    
}
