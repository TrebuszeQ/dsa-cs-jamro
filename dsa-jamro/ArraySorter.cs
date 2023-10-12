namespace dsa_jamro
{
    internal static class ArraySorter
    {
        private static int[]? InputArray {get; set;}
        // static ArraySorter()
        // {
        //     InputCollector();
        // }


        public static void InputCollector()
        {
            do
            {
                Console.WriteLine("Provide from 1 to 10 integer digits separated by comma.");
                string? input = Console.ReadLine();
                bool truth = InputChecker(input);
                if (truth) break;
                else Console.WriteLine("Wrong input.");
            } while (true);            
            PrintInputArray();
        }

        
        // checks if input is correct, if not returns false. 
        // if correct it initializes InputArray
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


        // prints input array
        private static bool PrintInputArray()
        {
            if(InputArray != null)
            {
                int c = 0;
                foreach(int indice in InputArray!)
                {
                    if(c != InputArray.Length - 2) Console.Write(indice + " ,");
                    else Console.Write(indice + '.');
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