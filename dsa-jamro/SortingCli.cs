namespace dsa_jamro
{
    public class SortingCli
    {
        public static void InputLoop()
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
                if(input == null || input.Length == 0) Console.WriteLine("Wrong input.");
                int[]? array = InputChecker(input);
                if (array == null) 
                {
                    Console.WriteLine("Wrong input.");
                    goto valueInput;
                }

                sortInput:
                Console.WriteLine();
                Console.WriteLine("Type number of desirable sort algorithm");
                PrintEnums();
                Console.WriteLine();
                input = Console.ReadLine();
                
                bool truth = int.TryParse(input, out intInput);
                if (truth) selection = intInput;

                switch(selection)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine(enumArr[intInput - 1] + " sorted:");
                        int[] result = ArraySorter.SelectionSort(array);
                        ArraySorter.PrintArray(result);
                    return;
                    default:
                        Console.WriteLine();
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
                if (enumArr.Length - 1 == c) Console.WriteLine($"{c}. {sorting}.");
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
    }
}