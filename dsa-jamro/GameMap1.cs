using System.Text;

namespace dsa_jamro
{

    internal static class GameMap1
    {
        private static readonly TerrainEnum[,] map = new TerrainEnum[10, 21];

        // returns color by TerrainEnum type.
        private static ConsoleColor GetColor(this TerrainEnum terrain)
        {
            switch(terrain)
            {
                case TerrainEnum.GRASS: return ConsoleColor.Green;
                case TerrainEnum.SAND: return ConsoleColor.Yellow;
                case TerrainEnum.WATER: return ConsoleColor.DarkBlue;
                case TerrainEnum.WALL: return ConsoleColor.Gray;
                default: return ConsoleColor.White;
            }
        }


        // returns character by TerrainType.
        private static char GetChar(this TerrainEnum terrain)
        {
            switch(terrain)
            {
                case TerrainEnum.GRASS: return '\u201c';
                case TerrainEnum.SAND: return '\u25cb';
                case TerrainEnum.WATER: return '\u2248';
                case TerrainEnum.WALL: return '\u25cf';
                default: return '*';
            }
        }


        // populates map with characters
        public static void PopulatePrintMap()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var rand = new Random();
            int terrainTypesCount = Enum.GetNames(typeof(TerrainEnum)).Length;
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for(int column = 0; column < map.GetLength(1); column++)
                {
                    int num = rand.Next(terrainTypesCount);
                    switch (num)
                    {
                        case 0:
                            map[row, column] = TerrainEnum.GRASS;
                            break;
                        case 1:
                            map[row, column] = TerrainEnum.WALL;
                            break;
                        case 2:
                            map[row, column] = TerrainEnum.WATER;
                            break;
                        case 3:
                            map[row, column] = TerrainEnum.SAND;
                            break;
                    }
                    Console.ForegroundColor = map[row, column].GetColor();
                    Console.Write(map[row, column].GetChar() + " ");
                    
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

}
