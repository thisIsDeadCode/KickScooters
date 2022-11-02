using System.Collections.Generic;

namespace KickScooters
{
    public class Car
    {
        public int MaxDistances { get; set; }
        /// <summary>
        ///  max 25
        /// </summary>
        public int Сapacity { get; set; } = 0;
        public Point CurrentPoint { get; set; } = new Point();
        public List<int> Path { get; set; } = new List<int>();

        public void GoToNewPoint(int newPoint, int distance, Action action)
        {
            if(action == Action.Get)
            {
                GetKickScooters(newPoint, distance);
            }
            else
            {
                GiveKickScooters(newPoint, distance);
            }
        }

        private void GetKickScooters(int newPoint, int distance)
        {
            var amount = newPoint - 1;
            MaxDistances -= distance;
            Сapacity += amount;
            AddPoint(newPoint);
        }

        private void GiveKickScooters(int newPoint, int distance)
        {
            var amount = newPoint - 1;
            MaxDistances -= distance;
            Сapacity -= amount;
            AddPoint(newPoint);
        }

        private void AddPoint(int newPoint)
        {
            CurrentPoint = new Point()
            {
                I = newPoint,
            };
            Path.Add(newPoint);
        }
    }

    public class Point
    {
        /// <summary>
        ///  Start I = 0
        /// </summary>
        public int I { get; set; } = 0;
    }
}
