using System;
using System.Linq;

public class Solution {
 public static void Main(String[] args) {
   int[] rankedScores = readArrayInput().Distinct().ToArray();
   int[] newScores = readArrayInput();

   foreach(var score in newScores) {
     int scorePosition = getIndexWithDivideAndConquer(score, rankedScores) + 1;
     Console.WriteLine(scorePosition);
   }
 }

 private static int[] readArrayInput() {
    int size = Convert.ToInt32(Console.ReadLine());
    string[] values = Console.ReadLine().Split(' ');

    return Array.ConvertAll(values, Int32.Parse);
 }

 private static int getIndexWithDivideAndConquer(int score, int[] rankedScores) {
     int scorePosition = 0;
     int indexForMaxValue = rankedScores.Length - 1;
     while (scorePosition <= indexForMaxValue) {
       int compareIndex = scorePosition + (indexForMaxValue - scorePosition) / 2;
       if (score < rankedScores[compareIndex]) {
         scorePosition = compareIndex + 1;
       } else {
         indexForMaxValue = compareIndex - 1;
       }
     }
	 return scorePosition;
 }
}
