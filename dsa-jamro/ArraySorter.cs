namespace dsa_jamro
{
    internal static class ArraySorter
    {
        private static int[]? InputArray {get; set;}


        public static void Cli()
        {
            int selection = 0;
    
            do
            {
                Console.WriteLine("Choose selection methods number.");
                selection = SelectionInputCollector();
                bool truth = InputChecker(input);

            } while (true);
        }

            // collects input to determine which selection is chosen.
            private static int SelectionInputCollector()
        {
            string[] enumArr = Enum.GetNames(typeof(SortsEnum));
            int intInput;
            do
            {
                Console.WriteLine("Choose selection methods number.");
                int c = 1;
                foreach (var sorting in enumArr) 
                {
                    if (enumArr.Length -1 == c) Console.WriteLine($"{c}. {sorting}.");
                    else Console.WriteLine($"{c}. {sorting}");
                    c++;
                }
                string? input = Console.ReadLine();
                
                bool truth = int.TryParse(input, out intInput);
                if (truth && (intInput <= enumArr.Length && intInput >= 1))
                {
                    Console.WriteLine(enumArr[intInput]);
                    return intInput;
                }
                else Console.WriteLine("Wrong input.");
            } while (true);
        }


        public static void PrintEnums()
        {
            foreach (var sorting in enumArr) 
                {
                    if (enumArr.Length -1 == c) Console.WriteLine($"{c}. {sorting}.");
                    else Console.WriteLine($"{c}. {sorting}");
                    c++;
                }
        }


        // collects input of array of ints.
        private static bool ArrayInputCollector()
        {
            do
            {
                Console.WriteLine("Provide from 1 to 10 integer digits separated by comma.");
                string? input = Console.ReadLine();
                bool truth = InputChecker(input);
                if (truth) return true;
                else Console.WriteLine("Wrong input.");
            } while (true);
        }


        // checks if input is correct, if not returns false. 
        // if correct it initializes and/or populates InputArray
        private static bool InputChecker(string? input)
        {
            if(input == null || input.Length == 0) return false;
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
                else if(!truth) return false;
                c++;
            }

            InputArray = resArr;
            return true;
        }


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