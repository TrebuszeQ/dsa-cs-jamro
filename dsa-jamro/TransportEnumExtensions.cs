using System.Globalization;

namespace dsa_jamro
{
    internal static class TransportEnumExtensions
    {
        private static TransportEnum[][] transport = new TransportEnum[12][];

        static TransportEnumExtensions() => PopulateArray();

        static char GetChar(this TransportEnum transport) 
        {
            switch(transport)
            {
                case TransportEnum.CAR:
                    return 'C';
                case TransportEnum.BUS:
                    return 'B';
                case TransportEnum.SUBWAY:
                    return 'S';
                case TransportEnum.BIKE:
                    return 'C';
                case TransportEnum.WALK:
                    return 'W';
                default:
                    throw new Exception("Unidentified transport method.");
            }
        }


        // returns color of the console depending on transport
        public static ConsoleColor GetColor(this TransportEnum transport)
        {
            switch (transport)
            {
                case TransportEnum.CAR:
                    return ConsoleColor.DarkRed;
                case TransportEnum.BUS:
                    return ConsoleColor.DarkYellow;
                case TransportEnum.SUBWAY:
                    return ConsoleColor.DarkBlue;
                case TransportEnum.BIKE:
                    return ConsoleColor.DarkGreen;
                case TransportEnum.WALK:
                    return ConsoleColor.DarkGreen;
                default:
                    throw new Exception("Unidentified transport method.");
            }
        }


        // populates array
        public static void PopulateArray()
        {
            Random rand = new Random();
            int transportTypesCount = Enum.GetNames(typeof(TransportEnum)).Length;
            for(int month = 1; month <= 12; month++)
            {
                int daysCount = DateTime.DaysInMonth(DateTime.Now.Year, month);
                transport[month - 1] = new TransportEnum[daysCount];
                for(int day = 1; day <= daysCount; day++)
                {
                    int randomType = rand.Next(transportTypesCount);
                    transport[month - 1][day - 1] = (TransportEnum)randomType;
                }
            }
        }


        // returns array with month names
        public static string[] GetMonthNames()
        {
            string[] names = new string[12];
            int year = new DateTime().Year;
            for (int i = 0; i < names.Length; i++)
            {
                DateTime date = new DateTime(year, i + 1, 1);
                string monthName = date.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
                names[i] = monthName; 
            }
            return names;
        }


        // print array
        public static void PrintArray()
        {
            string[] monthNames = GetMonthNames();
            for (int month = 0; month < monthNames.Length - 1; month++)
            {
                Console.WriteLine(monthNames[month].PadRight(6));
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Black;
                for (int day = 0; day < transport[month].Length - 1; day++)
                {
                    Console.BackgroundColor = transport[month][day].GetColor();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(transport[month][day].GetChar());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;    
                    Console.Write(" ");
                
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("");   
            }
        }
        
    }
}
