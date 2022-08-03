using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    class ProfileObj
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Units { get; set; }
        public bool Colour { get; set; }

        public ProfileObj(string name, string city, int units, bool colour)
        {
            Name = name;
            City = city;
            Units = units;
            Colour = colour;
        }
        public ProfileObj()
        {

        }
    }
    
}
