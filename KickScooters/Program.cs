using System;

namespace KickScooters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int AmountKickScooters = 3;
            const int AmountCarParks = 4;
            const int AmountCars = 2;
            InputData inputData = new InputData()
            {
                AmountKickScooters = AmountKickScooters,
                AmountCarParks = AmountCarParks,
                AmountCars = AmountCars,
                DistanceMatrix = new int[AmountKickScooters + AmountCarParks + 1, AmountKickScooters + AmountCarParks + 1] {
                    { 0, 1, 2, 4, 3, 4, 3, 1 },
                    { 1, 0, 1, 5, 2, 3, 4, 2 },
                    { 2, 1, 0, 6, 1, 2, 5, 3 },
                    { 4, 5, 6, 0, 7, 8, 1, 3 },
                    { 3, 2, 1, 7, 0, 1, 6, 4 },
                    { 4, 3, 2, 8, 1, 0, 7, 5 },
                    { 3, 4, 5, 1, 6, 7, 0, 2 },
                    { 1, 2, 3, 3, 4, 5, 2, 0 }
                },
                MaxDistances = new int[AmountCars] {5, 4}
            };

            PathProvider pathProvider = new PathProvider(inputData);
            pathProvider.SimpleStrategy();
        }
    }
}
