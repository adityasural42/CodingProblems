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
    }


    
    
}
