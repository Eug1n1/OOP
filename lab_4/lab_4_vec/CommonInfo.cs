using System;

namespace lab_5
{
    public struct CommonInfo
    {
        private string _captainName;
        private int _captainAge;
        public string Title { get; set; }

        public string CaptainName
        {
            get => _captainName;
            set
            {
                if (value == null)
                    throw new NullReferenceException();

                _captainName = value;
            }
        }

        public int CaptainAge
        {
            get => _captainAge;
            set
            {
                if (value < 18)
                {
                    throw new CaptainAgeException();
                }

                _captainAge = value;
            }
        }

        public int Displacement { get; set; }
        public int  Places { get; set; }
        public ShipType Type { get; set; }
    }
}