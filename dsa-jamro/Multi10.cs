using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;
using System.Diagnostics;

namespace dsa_jamro
{
    internal static class Multi10
    {
        private static int[,] MultiArray;

        static Multi10()
        {
            Console.WriteLine("Array of multiplication to 10.");
            Trace.Write("Array of multiplication to 10.");
            MultiArray = new int[10,10];
            PopulateArray();
        }

        private static void PopulateArray()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    MultiArray[i, j] = (i + 1) * (j + 1);
                }
            }
        }


        public static void PrintArray()
        {
            Console.WriteLine("Array length is: " + MultiArray.Length);
            if (MultiArray != null)
            {
                for (int i = 0; i < MultiArray.GetLength(0); i++)
                {
                    for (int j = 0; j < MultiArray.GetLength(1); j++)
                    {
                        Console.Write("{0,4}", MultiArray[i, j]);
                        Trace.Write($"{MultiArray[i, j]}");
                    }
                    Console.WriteLine();
                }
            }
            else throw new ArgumentNullException(nameof(MultiArray) + "is null.");
        }
    }
}
