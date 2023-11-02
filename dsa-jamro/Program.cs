// See https://aka.ms/new-console-template for more information
using dsa_jamro;
using System.Runtime.InteropServices;

static void Main()
{
    
    // starts textual loop with menu and user input
    void MainLoop()
    {
        string? input;
        int intInput = 999;
        Dictionary<string, string> options = new Dictionary<string, string>
        {
            { "menu", "Menu" },
            { "todo", "Type integer number to choose option." },
            { "clear", "Clear terminal." },
            { "array", "Generate array with multiplication from 1st up to 10th number." },
            { "mutliArr", "Generate game map with random terrain." },
            { "jaggArr", "Prints daily plan of transport for whole year." },
            { "sortings", "Sorting algorithms." },
            { "exit", "Exit program." }
        };
        string[] values = options.Values.ToArray();
        do
        {
            for(int i = 0; i < values.Length; i++)
            {
                Console.WriteLine(values[i]);
            }
            Console.WriteLine();

            input = Console.ReadLine();

            if (input != null) input = input.Replace(" ", "");
            Console.WriteLine($"Entered {input}.");

            try
            {
                intInput = Convert.ToInt32(input);
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong input");
                Console.WriteLine(e.Message);
            }

            switch (intInput)
            {
                case 0:
                    Console.Clear();
                    break;
                case 1:
                    Multi10.PrintArray();
                    Console.WriteLine();
                    break;
                case 2:
                    GameMap1.PopulatePrintMap();
                    Console.WriteLine();
                    break;
                case 3:
                    TransportEnumExtensions.PrintArray();
                    Console.WriteLine();
                    break;
                case 4:
                    SortingCli();
                    Console.WriteLine();
                    break;
                case 80:
                    Restart();
                    break;
                case 90:
                    Console.WriteLine("Exiting");
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        } while (true);
    }


    bool Restart()
    {
        [DllImport("libc")]
        static extern int system(string exec);
        system("dotnet run");
        return true;
    }

    void SortingCli()
    {
        string? input;
        int intInput = 0;
        bool truth = false;
        do
        {
            Console.WriteLine("Sorting algorithms");
            Console.WriteLine("Type number to choose option.");
            Console.WriteLine("0. Go back.");
            Console.WriteLine("1. Clear terminal.");
            Console.WriteLine("2. Restart program.");
            Console.WriteLine("3. Insertion sort.");
            Console.WriteLine("4. Selection sort.");

            input = Console.ReadLine();

            if (input != null) input = input.Replace(" ", "");
            Console.WriteLine($"Entered {input}.\n");

            try
            {
                intInput = Convert.ToInt32(input);
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong input");
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            switch (intInput)
            {
                case 0:
                    Console.Clear();
                    return;
                case 1:
                    Console.Clear();
                    break;
                case 2:
                    Restart();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        } while (true);
    }

    // collects input to determine which selection is chosen.
    int SelectionArrayCollector()
    {
        string[] enumArr = Enum.GetNames(typeof(SortsEnum));
        int intInput = 0;
        do
        {
            Console.WriteLine("Choose selection methods number.");
            int c = 1;
            for (int i = 0; i < enumArr.Length; i++)
            {
                Console.WriteLine($"{c + 2}. {enumArr[i]}.");
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


    void PrintEnums(string[] enumArr, int c)
    {
        foreach (var sorting in enumArr)
        {
            if (enumArr.Length -1 == c) Console.WriteLine($"{c}. {sorting}.");
            else Console.WriteLine($"{c}. {sorting}");
            c++;
        }
    }


    // collects input of array of ints.
    bool ArrayInputCollector()
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
    bool InputChecker(string? input)
    {
        if (input == null || input.Length == 0) return false;
        input = input.Replace(" ", "");
        string[] arr = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
        int[] resArr = new int[arr.Length];
        int c = 0;
        foreach (string indice in arr)
        {
            if (c == 9) break;
            int result;
            // intInput = Convert.ToInt32(input);
            bool truth = int.TryParse(indice, out result);
            if (truth) resArr[c] = result;
            else if (!truth) return false;
            c++;
        }

        InputArray = resArr;
        return true;
    }

    MainLoop();
}
Main();
Environment.Exit(0);