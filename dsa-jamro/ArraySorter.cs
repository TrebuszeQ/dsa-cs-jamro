namespace dsa_jamro
{
    internal class ArraySorter
    {
        // performs selection sort algorithm on the InputArray
        public static int[] SelectionSort(int[] array)
        {
            for(int i = 0; i < array.Length - 1; i++) 
            {
                int min = array[i];
                int temp;
                int pos = i;
                for (int j = i + 1; j  < array.Length; j++)
                {
                    
                    if (array[j].CompareTo(min) < 0) 
                    {
                        min = array[j];
                        pos = j;
                    }
                }
                temp = array[i];
                array[i] = min;
                array[pos] = temp;
            }
            return array;
        }

    public static T[] SelectionSortG<T> (T[] array) where T : IComparable
            {
                for(int i = 0; i < array.Length - 1; i++) 
                {
                    T min = array[i];
                    T temp;
                    int pos = i;
                    for (int j = i + 1; j  < array.Length; j++)
                    {
                        
                        if (array[j].CompareTo(min) < 0) 
                        {
                            min = array[j];
                            pos = j;
                        }
                    }
                    temp = array[i];
                    array[i] = min;
                    array[pos] = temp;
                }
                return array;
            }

        // prints array from argument
        public static void PrintArray(int[] array)
        {
            int c = 0;
            foreach(int indice in array)
            {
                if(c != array.Length - 1) Console.Write($"{indice}, ");
                else Console.Write($"{indice}.");
                c++;
            }
            Console.WriteLine();
        }
    }
}