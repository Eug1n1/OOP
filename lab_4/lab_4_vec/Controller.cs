using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
            if(harbor == null)
                throw new HarborNullException();
            
            _harbor = harbor;
        }

        public void ChangeHarbor(Harbor harbor)
        {
            if(harbor == null)
                throw new HarborNullException();
            
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
            if(index < 0 || index > _harbor.Ships.Count)
                throw new IndexOutOfRangeException();
            
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

        public void SaveToTxt(string path)
        {
            if (Path.EndsInDirectorySeparator(path))
            {
                throw new PathException();
            }
            
            using (var sw = new StreamWriter(path))
            {
                foreach (var ship in _harbor.Ships)
                {
                    var shipLine = ship.CommonInfo.Title + ";" + ship.CommonInfo.Type + ";"
                                   + ship.CommonInfo.CaptainName + ";" + ship.CommonInfo.CaptainAge + ";"
                                   + ship.CommonInfo.Displacement + ";" + ship.CommonInfo.Places;

                    sw.WriteLine(shipLine);
                }
            }
        }

        public void LoadFromTxt(string path)
        {
            if (Path.EndsInDirectorySeparator(path))
            {
                throw new PathException();
            }
            
            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    var shipLine = sr.ReadLine();

                    var info = shipLine?.Split(";");
                    CommonInfo ci = new CommonInfo();
                    ci.Title = info?[0];
                    ci.CaptainName = info?[2];
                    ci.CaptainAge = Convert.ToInt32(info?[3]);
                    ci.Displacement = Convert.ToInt32(info?[4]);
                    ci.Places = Convert.ToInt32(info?[5]);

                    var type = info?[1];

                    if (type == "Boat")
                    {
                        ci.Type = ShipType.Boat;
                    }
                    else if (type == "Corvette")
                    {
                        ci.Type = ShipType.Corvette;
                    }
                    else if (type == "Sailboat")
                    {
                        ci.Type = ShipType.Sailboat;
                    }
                    else if (type == "Steamboat")
                    {
                        ci.Type = ShipType.Steamboat;
                    }
                    else if (type == "MyOwnBoat")
                    {
                        ci.Type = ShipType.MyOwnShip;
                    }
                    else
                    {
                        throw new Exception("Unknown ship type");
                    }

                    Add(ci);
                }
            }
        }

        public void SaveToJson(string path)
        {
            if (Path.EndsInDirectorySeparator(path))
            {
                throw new PathException();
            }
            
            using (var sw = new StreamWriter(path))
            {
                foreach (var ship in _harbor.Ships)
                {
                    string shipLine = JsonConvert.SerializeObject(ship.CommonInfo);
                    sw.WriteLine(shipLine);
                }
            }
        }

        public void LoadFromJson(string path)
        {
            if (Path.EndsInDirectorySeparator(path))
            {
                throw new PathException();
            }
            
            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    var shipLine = sr.ReadLine();
                    var shipInfo = JsonConvert.DeserializeObject<CommonInfo>(shipLine!);
                    Add(shipInfo);
                }
            }
        }
    }
}