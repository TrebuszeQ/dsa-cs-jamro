using System.Runtime.InteropServices;

namespace dsa_jamro
{
    public static class Cli
    {

        // starts textual loop with menu and user input
        public static void InputLoop()
        {
            do
            {
            input:
                Console.WriteLine("Menu");
                Console.WriteLine("Type number to choose option.");
                Console.WriteLine("0. Clear terminal.");
                Console.WriteLine("1. Generate array with multiplication from 1st up to 10th number.");
                Console.WriteLine("2. Generate game map with random terrain.");
                Console.WriteLine("3. Prints daily plan of transport for whole year.");
                Console.WriteLine("4. Sorts array with selection sorting algorithm.");
                Console.WriteLine("80. Restart program.");
                Console.WriteLine("90. Exit program.");
                string? input = Console.ReadLine();
                if(input != null) input = input.Replace(" ", "");
                Console.WriteLine($"Entered {input}.");
                int? intInput;
                if (input.Length == 0)
                {
                    Console.WriteLine("Wrong input");
                    goto input;
                }
                try
                {
                    intInput = Convert.ToInt32(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong input");
                    Console.WriteLine(e.Message);
                    goto input;
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
                        ArraySorter.InputCollector();
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
                        goto input;
                }
            } while (true);
        }


        public static bool Restart()
        {
            [DllImport ("libc")]
            static extern int system (string exec);
            system("dotnet run"); 
            return true;
        }
    }
}
