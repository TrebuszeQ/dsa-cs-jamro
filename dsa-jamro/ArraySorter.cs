namespace dsa_jamro
{
    internal static class ArraySorter
    {
        // cli that collects input and does things with it, 
        // eventually calls to methods to sort and print input
        public static void Cli()
        {
            Console.Clear();
            int selection = 0;
            string[] enumArr = Enum.GetNames(typeof(SortsEnum));
            int intInput;
            do
            {
                valueInput:
                Console.WriteLine("Provide from 1 to 10 integer digits separated by comma.");
                string? input = Console.ReadLine();
                int[]? array = InputChecker(input);
                if (array == null) 
                {
                    Console.WriteLine("Wrong input.");
                    goto valueInput;
                }

                sortInput:
                Console.WriteLine("Type number of desirable sort algorithm");
                PrintEnums();
                
                input = Console.ReadLine();
                
                bool truth = int.TryParse(input, out intInput);
                if (truth) selection = intInput;

                switch(selection)
                {
                    case 1:
                        Console.WriteLine(enumArr[intInput - 1]);
                        int[] result = SelectionSort(array);
                        PrintArray(result);
                    return;
                    default:
                        Console.WriteLine("Wrong input.");
                        goto sortInput;
                }
            } while (true);
        }


        // prints strings of enumerable
        public static void PrintEnums()
        {
            int c = 1;
            string[] enumArr = Enum.GetNames(typeof(SortsEnum));
            foreach (var sorting in enumArr) 
            {
                if (enumArr.Length -1 == c) Console.WriteLine($"{c}. {sorting}.");
                else Console.WriteLine($"{c}. {sorting} sort.");
                c++;
            }
        }


        // checks if input is correct, if not returns false. 
        // if correct it initializes and/or populates InputArray
        private static int[]? InputChecker(string? input)
        {
            if(input != null || input.Length == 0)
            {
                input = input.Replace(" ", "");
                string[] arr = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                int[] resArr = new int[arr.Length];
                int c = 0;
                foreach(string indice in arr)
                {
                    if(c == 9) break;
                    int result;
                    // intInput = Convert.ToInt32(input);
                    bool truth = int.TryParse(indice, out result);
                    if(truth) resArr[c] = result;
                    else if(!truth) return null;
                    c++;
                }
                return resArr;
            }
            return null;
        }


        // performs selection sort algorithm on the InputArray
        static public int[] SelectionSort(int[] array)
        {
            int i = 0;
            int j = 0;
            for(; i < array.Length - 1; i++) 
            {
                int head = array[i];
                int temp = head;
                for (; j  < array.Length; j++)
                {
                    int indice = array[j];
                    if (indice < head) head = indice;
                }
                temp = array[i];
                array[i] = head;
                array[j] = temp;
            }
            return array;
        }


        // prints array from argument
        public static void PrintArray(int[] array)
        {
            {
                int c = 0;
                foreach(int indice in array)
                {
                    if(c != array.Length - 1) Console.Write($"{indice}  ,");
                    else Console.Write($"{indice}.");
                    c++;
                }
                Console.WriteLine();
            }
        }
    }
}