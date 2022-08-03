using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class CityObj
    {
        public string City { get; set; }
        public string Country { get; set; }

        public CityObj(string city, string country)
        {
            City = city;
            Country = country;
        }
        public override string ToString()
        {
            return $"{City}, {Country}";
        }
    }

    
}
