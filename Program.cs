using System;
using System.Globalization;

namespace CSharpFundamental
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Challenge 1 */
            string text = "this is a text";
            string newText = toTitleCase(text);
            Console.WriteLine(newText); // expect to see "This Is A Text"
           
            /* Challenge 2 */
            int[,] arrayA = { { 3, 5, 4, 6 }, { 3, 7, 8, 3 } };
            int[,] arrayB = { { 5, 1 }, { 8, 4 }, { 2, 9 }, { 2, 3 } };
            int[,] result = matrixMultiply(arrayA, arrayB);
            Console.WriteLine((result));//share your findings to Slack
            Console.ReadLine();
        }

        static int[,] matrixMultiply(int[,] arrayA, int[,] arrayB)
        {
            if (arrayA.GetLength(0) != arrayB.GetLength(1))
            {
                throw new InvalidOperationException("Two arrays can't be multiplied");
            }
            int[,] result = new int[arrayA.GetLength(0), arrayB.GetLength(1)];
            for (int i = 0; i < arrayA.GetLength(0); i++)
            {
                for (int j = 0; j < arrayB.GetLength(1); j++)
                {
                    for (int k = 0; k < arrayA.GetLength(1); k++)
                    {
                        result[i, j] += arrayA[i, k] * arrayB[k, j];
                    }
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
            return result;
        }

        static string toTitleCase(string input)
        {
            string[] words = input.Split(' ');
            var wordList = new List<string>();

            /* Approach 1: 
            foreach (var word in words)
            {
                wordList.Add($"{((word[0].ToString().ToUpper() + (word.Substring(1))))}");
            }
            return string.Join(" ", wordList); */

            // Approach 2: Using ASCII value to replace the title case alphabet
            foreach (var word in words)
            {
                var convertToAscii = (System.Convert.ToInt32(word[0]) - 32);
                char character = (char)convertToAscii;
                wordList.Add($"{character.ToString() + (word.Substring(1))}");
            }
            return string.Join(" ", wordList);
        }
    }
}
