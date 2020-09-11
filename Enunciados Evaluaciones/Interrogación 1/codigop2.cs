using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
 static void Main(String[] args) {
   int n = Convert.ToInt32(Console.ReadLine());
   string[] scores_temp = Console.ReadLine().Split(' ');
   int[] scores = Array.ConvertAll(scores_temp, Int32.Parse);
   int m = Convert.ToInt32(Console.ReadLine());
   string[] player_temp = Console.ReadLine().Split(' ');
   int[] player = Array.ConvertAll(player_temp, Int32.Parse);

   scores = scores.Distinct().ToArray();

   foreach(var v in player) {
     int le = 0;
     int r = scores.Length - 1;
     while (le <= r) {
       int m = le + (r - le) / 2;
       if (v < scores[m]) {
         le = m + 1;
       }
       else {
         r = m - 1;
       }
     }
     Console.WriteLine(le + 1);
   }
 }
}
