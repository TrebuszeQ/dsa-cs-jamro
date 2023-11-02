namespace dsa_jamro
{
    internal static class Sorter
    {
        private static int[]? InputArray {get; set;}


        // performs selection sort algorithm on the InputArray
        static public int[] SelectionSort()
        {
            int c = 0;
            int i = 0;
            int j = 0;
            int[] result = InputArray!;
            for(; i < result.Length; i++) 
            {
                int minValue = result[i];
                int temp = minValue;
                for (; j  < result.Length; j++)
                {
                    int indice = result[j];
                    if (minValue > indice)
                    {
                        indice = temp;
                        minValue = indice;
                    }
                }
                result[i] = minValue;
                result[j] = result[i];
            }
            return result;
        }


        // prints input array
        private static bool PrintInputArray()
        {
            if(InputArray != null)
            {
                int c = 0;
                foreach(int indice in InputArray!)
                {
                    if(c != InputArray.Length - 1) Console.Write($"{indice}  ,");
                    else Console.Write($"{indice}.");
                    c++;
                }
                Console.WriteLine();
                return true;
            }
            Console.WriteLine("Array coudln't been printed.");
            return false;
        }
    }
}