using System;
using System.Collections.Generic;

namespace lab_5
{
    public class Controller
    {
        private Harbor _harbor;
        private int _averageSailboatDisplacement;
        private int _averageSteamboatPlaces;

        public int AverageSailboatDisplacement => _averageSailboatDisplacement;
        public int AverageSteamboatPlaces => _averageSteamboatPlaces;
        public List<Ship> YoungCaptains => _harbor.ShipsWithYoungCaptains;

        public Harbor Harbor => _harbor;

        public Controller()
        {
            _harbor = new Harbor();
        }

        public Controller(Harbor harbor)
        {
            _harbor = harbor;
        }

        public void ChangeHarbor(Harbor harbor)
        {
            _harbor = harbor;
        }
        
        public void Add(CommonInfo commonInfo)
        {

            
            if (commonInfo.Type == ShipType.Boat)
            {
                _harbor.Ships.Add(new Boat(commonInfo));
                if (commonInfo.CaptainAge < 35)
                {
                    _harbor.ShipsWithYoungCaptains.Add(new Boat(commonInfo));
                }
            }
            else if (commonInfo.Type == ShipType.Corvette)
            {
                _harbor.Ships.Add(new Corvette(commonInfo));
                if (commonInfo.CaptainAge < 35)
                {
                    _harbor.ShipsWithYoungCaptains.Add(new Corvette(commonInfo));
                }
            }
            else if (commonInfo.Type == ShipType.Sailboat)
            {
                _harbor.Ships.Add(new Sailboat(commonInfo));
                if (commonInfo.CaptainAge < 35)
                {
                    _harbor.ShipsWithYoungCaptains.Add(new Sailboat(commonInfo));
                }
                if (_averageSailboatDisplacement != 0)
                {
                    _averageSailboatDisplacement = (_averageSailboatDisplacement + commonInfo.Displacement) / 2;
                }
                else
                {
                    _averageSailboatDisplacement = commonInfo.Displacement;
                }
                
            }
            else if (commonInfo.Type == ShipType.Steamboat)
            {
                _harbor.Ships.Add(new Steamboat(commonInfo));
                if (commonInfo.CaptainAge < 35)
                {
                    _harbor.ShipsWithYoungCaptains.Add(new Steamboat(commonInfo));
                }
                if (_averageSteamboatPlaces != 0)
                {
                    _averageSteamboatPlaces = (_averageSteamboatPlaces + commonInfo.Places) / 2;
                }
                else
                {
                    _averageSteamboatPlaces = commonInfo.Places;
                }
            }
            else if (commonInfo.Type == ShipType.MyOwnShip)
            {
                _harbor.Ships.Add(new MyOwnShip(commonInfo));
                if (commonInfo.CaptainAge < 35)
                {
                    _harbor.ShipsWithYoungCaptains.Add(new MyOwnShip(commonInfo));
                }
            }
            else
            {
                throw new Exception("type is missing");
            }
        }

        public void Add(Ship ship)
        {
            if (ship.CommonInfo.CaptainAge < 35)
            {
                _harbor.ShipsWithYoungCaptains.Add(ship);
            }
            
            _harbor.Ships.Add(ship);
            if (ship.CommonInfo.Type == ShipType.Boat)
            {
                _harbor.Ships.Add(new Boat(ship.CommonInfo));
            }
            else if (ship.CommonInfo.Type == ShipType.Corvette)
            {
                _harbor.Ships.Add(new Corvette(ship.CommonInfo));
            }
            else if (ship.CommonInfo.Type == ShipType.Sailboat)
            {
                _harbor.Ships.Add(new Sailboat(ship.CommonInfo));
                if (_averageSailboatDisplacement != 0)
                {
                    _averageSailboatDisplacement = (_averageSailboatDisplacement + ship.CommonInfo.Displacement) / 2;
                }
                else
                {
                    _averageSailboatDisplacement = ship.CommonInfo.Displacement;
                }
                
            }
            else if (ship.CommonInfo.Type == ShipType.Steamboat)
            {
                _harbor.Ships.Add(new Steamboat(ship.CommonInfo));
            }
            else if (ship.CommonInfo.Type == ShipType.MyOwnShip)
            {
                _harbor.Ships.Add(new MyOwnShip(ship.CommonInfo));
            }
            else
            {
                throw new Exception("type is missing");
            }
        }

        public void Delete(int index)
        {
            _harbor.Ships.Remove(_harbor.Ships[index]);
            _harbor.ShipsWithYoungCaptains.Clear();
            foreach (var ship in _harbor.Ships)
            {
                if (ship.CommonInfo.CaptainAge < 35)
                {
                    _harbor.ShipsWithYoungCaptains.Add(ship);
                }
            }
        }

        public void Print()
        {
            foreach (var ship in _harbor.Ships)
            {
                Console.WriteLine(ship.ToString());
            }
        }
    }
}