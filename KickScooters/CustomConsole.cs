using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KickScooters
{
    internal class CustomConsole
    {
        public static void ConsoleWrite(int amountKickScooters, int amountCarParks, int[,] mas, List<Path> paths)
        {
            Console.Clear();
            for (int i = 0; i < amountKickScooters + amountCarParks + 1; i++)
            {
                for (int j = 0; j < amountKickScooters + amountCarParks + 1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write($"{mas[i, j]} ");
                        Console.ResetColor();
                    }
                    else if (i < amountKickScooters + 1 && j < amountKickScooters + 1)
                    {
                        var hasBeenWriten = WriteRedPoint(mas, i, j, paths);
                        if (hasBeenWriten)
                        {
                            continue;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write($"{mas[i, j]} ");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        var hasBeenWriten = WriteRedPoint(mas, i, j, paths);
                        if (hasBeenWriten)
                        {
                            continue;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write($"{mas[i, j]} ");
                            Console.ResetColor();
                        }
                    }
                }
                Console.WriteLine();
            };
        }
        private static bool WriteRedPoint(int[,] mas, int i, int j, List<Path> paths)
        {
            bool goNext = false;
            if (paths.Count() > 0)
            {
                foreach (var p in paths)
                {
                    if (p.Oldpoint == i && p.Newpoint == j)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write($"{mas[i, j]} ");
                        Console.ResetColor();
                        goNext = true;
                    }
                }
            }
            return goNext;
        }
    }
}
