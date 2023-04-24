using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_trials
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Range for the integral Datatypes");
            Random_trials.DataTypes.RangeOfTypes.RangeOfType();


            Console.WriteLine("Trying the diff between int[][]  || int[,] ");
            RectangularArray();
            JaggedArray();


            Console.ReadKey();

        }

        public static void RectangularArray()
        {
            Console.WriteLine("\nTrying int[,] ");
            int[,] rectangularArray = new int[3, 2];

            Console.WriteLine(rectangularArray.ToString());

            for (int i = 0; i < rectangularArray.GetLength(0); i++)
            {
                for (int j = 0; j < rectangularArray.GetLength(1); j++)
                {
                    Console.Write("Enter [" + i + " , " + j + "] = ");
                    rectangularArray[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < rectangularArray.GetLength(0); i++)
            {
                for (int j = 0; j < rectangularArray.GetLength(1); j++)
                {
                    Console.Write(" " + rectangularArray[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void JaggedArray()
        {
            Console.WriteLine("\nTrying int[][]");
            int[][] jaggedArray = new int[3][];

            for(int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write("Enter the length of internal array " + i + " = ");
                jaggedArray[i] = new int[int.Parse(Console.ReadLine())];
            }

            Console.WriteLine(jaggedArray.ToString());

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write("Enter [" + i + "][" + j + "] = ");
                    jaggedArray[i][j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(" " + jaggedArray[i][j]);
                }
                Console.WriteLine();
            }

        }
    }
}
