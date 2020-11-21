using System;
using System.Collections.Generic;
using System.Globalization;

namespace lab_5
{
    public class Harbor
    {
        public List<Ship> Ships { get; set; }
        
        public List<Ship> ShipsWithYoungCaptains { get; set; }

        public Harbor()
        {
            Ships = new List<Ship>();
            ShipsWithYoungCaptains = new List<Ship>();
        }
        
    }
}