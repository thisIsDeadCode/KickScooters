using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KickScooters
{
    public class Path
    {
        public int Oldpoint { get; set; }
        public int Newpoint { get; set; }
    }
    public class PathProvider
    {
        private List<Car> _cars;
        private int[,] _distance;
        private List<Path> _path;
        private int _amountKickScooters;
        private int _amountCarParks;
        private int _amountCars;

        public PathProvider(InputData input)
        {
            _amountKickScooters = input.AmountKickScooters;
            _amountCarParks = input.AmountCarParks;
            _amountCars = input.AmountCars;

            _distance = input.DistanceMatrix;
            _cars = new List<Car>();
            _path = new List<Path>();

            for(int i = 0; i < _amountCars; i++)
            {
                Car car = new Car()
                {
                    MaxDistances = input.MaxDistances[i],
                };
                _cars.Add(car);
            }
        }

        public void SimpleStrategy()
        {
            //var xxx = GetLoadingPoints();
            //var xxx1 = GetUnloadingPoints();
            //CustomConsole.ConsoleWrite(_amountKickScooters, _amountCarParks, _distance, _path);

            //SendCar(_cars[0], 3, Action.Get);
            //SendCar(_cars[0], 6, Action.Give);
            //var xxxx = GetLoadingPoints();
            //var xxxx1 = GetUnloadingPoints();

            //CustomConsole.ConsoleWrite(_amountKickScooters, _amountCarParks, _distance, _path);

            //SendCar(_cars[1], 1, Action.Get);
            //SendCar(_cars[1], 2, Action.Get);
            //SendCar(_cars[1], 4, Action.Give);
            //SendCar(_cars[1], 5, Action.Give);
            //var xxxxx = GetLoadingPoints();
            //var xxxx11 = GetUnloadingPoints();


            FastFullLoading(_cars[0]);
            CustomConsole.ConsoleWrite(_amountKickScooters, _amountCarParks, _distance, _path);

            Loading(_cars[1]);
            CustomConsole.ConsoleWrite(_amountKickScooters, _amountCarParks, _distance, _path);


            Unloading(_cars[0]);
            CustomConsole.ConsoleWrite(_amountKickScooters, _amountCarParks, _distance, _path);

            Unloading(_cars[1]);
            CustomConsole.ConsoleWrite(_amountKickScooters, _amountCarParks, _distance, _path);
        }

        public void MiddleStrategy()
        {
        }

        private bool Unloading(Car car)
        {
            bool hasLoad = false;
            for (int i = _amountKickScooters; i < _amountKickScooters + _amountCarParks + 1; i++)
            {
                for (int j = _amountKickScooters; j < _amountKickScooters + _amountCarParks + 1; j++)
                {
                    var count = _path.Where(x => x.Newpoint == j).Count();
                    if (_amountCarParks >= j - _amountKickScooters && car.MaxDistances >= _distance[car.CurrentPoint.I, j] && _distance[car.CurrentPoint.I, j] != 0
                        && count == 0)
                    {
                        SendCar(car, j, Action.Get);
                        hasLoad = true;
                    }
                }
            };
            return hasLoad;
        }

        private bool Loading(Car car)
        {
            bool hasLoad = false;
            for (int i = 0; i < _amountKickScooters + _amountCarParks + 1; i++)
            {
                for (int j = 1; j < _amountKickScooters + _amountCarParks + 1; j++)
                {
                    if (i < _amountKickScooters + 1 && j < _amountKickScooters + 1)
                    {
                        var count = _path.Where(x => x.Newpoint == j).Count();
                        if (_amountKickScooters >= j && car.MaxDistances >= _distance[car.CurrentPoint.I, j] && _distance[car.CurrentPoint.I, j] != 0
                            && count == 0)
                        {
                            SendCar(car, j, Action.Get);
                            hasLoad = true;
                        }
                    }
                }
            };
            return hasLoad;
        }

        private bool FastFullLoading(Car car)
        {
            bool hasLoad = false;
            for (int i = 0; i < _amountKickScooters + _amountCarParks + 1; i++)
            {
                for (int j = 1; j < _amountKickScooters + _amountCarParks + 1; j++)
                {
                    if (i < _amountKickScooters + 1 && j < _amountKickScooters + 1)
                    {
                        var count = _path.Where(x => x.Newpoint == j).Count();
                        if (_amountKickScooters == j && car.MaxDistances >= _distance[car.CurrentPoint.I, j] && _distance[car.CurrentPoint.I, j] != 0
                             && count == 0)
                        {
                            SendCar(car, j, Action.Get);
                            hasLoad = true;
                        }
                    }
                }
            };
            return hasLoad;
        }

        private List<int> GetLoadingPoints()
        {
            List<int> points = new List<int>();

            for (int i = 1; i < _amountKickScooters + 1; i++)
            {
                bool used = false;

                foreach (var p in _path)
                {
                    if(p.Newpoint == i)
                    {
                        used = true;
                    }
                }

                if (used)
                {
                    continue;
                }
                else
                {
                    points.Add(i);
                }
            }

            return points;
        }

        private List<int> GetUnloadingPoints()
        {
            List<int> points = new List<int>();

            for (int i = _amountKickScooters + 1; i < _amountKickScooters + _amountCarParks + 1; i++)
            {
                bool used = false;

                foreach (var p in _path)
                {
                    if (p.Newpoint == i)
                    {
                        used = true;
                    }
                }

                if (used)
                {
                    continue;
                }
                else
                {
                    points.Add(i);
                }
            }

            return points;
        }

        private void SendCar(Car car, int newPoint, Action action)
        {
            var curPoint = car.CurrentPoint;
            var distance = _distance[curPoint.I, newPoint];
            car.GoToNewPoint(newPoint, distance, action);
            _path.Add(new Path()
            {
                Oldpoint = curPoint.I,
                Newpoint = newPoint,
            });
        }
    }
}
