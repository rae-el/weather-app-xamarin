using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;
using Weather.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Weather.Services
{

    public class ProfManager
    {
        private readonly int maxprofiles = 1;
        string[] units = { "metric", "imperial" };
        ProfileObj[] mainProfile;
        WeatherAPI weatherAPI;

        public ProfManager()
        {
            mainProfile = new ProfileObj[maxprofiles];
            mainProfile[0] = new ProfileObj("Rachel", "Perth", 0, false);

            weatherAPI = new WeatherAPI();
        }
        public string GetName()
        {
            return mainProfile[0].Name;
        }
        public string GetCity()
        {
            return mainProfile[0].City;
        }
        public string GetUnits()
        {
            return units[mainProfile[0].Units];
        }

        public string GetColour()
        {
            if (mainProfile[0].Colour)
            {
                return "Dark";
            }
            else
            {
                return "Light";
            }
        }

        public bool ChangeName(string name)
        {
            if (name.Length > 0 && name.Length < 20)
            {
                mainProfile[0].Name = name;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangeColour(bool colour)
        {
            mainProfile[0].Colour = colour;
            if (colour)
            {
                var theme = Preferences.Get("OSAppTheme", Enum.GetName(typeof(OSAppTheme), OSAppTheme.Dark));
                App.Current.UserAppTheme = (OSAppTheme)Enum.Parse(typeof(OSAppTheme), theme);
                return true;
            }
            else
            {
                var theme = Preferences.Get("OSAppTheme", Enum.GetName(typeof(OSAppTheme), OSAppTheme.Light));
                App.Current.UserAppTheme = (OSAppTheme)Enum.Parse(typeof(OSAppTheme), theme);
                return false;
            }
            
        }

        public async Task<bool> ChangeCity(string city, string units)
        {
            string newCity = await weatherAPI.CheckCity(city, units);
            if (newCity != "")
            {
                mainProfile[0].City = newCity;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ChangeUnits(int unit)
        {
            mainProfile[0].Units = unit;
        }
        
        public string[] GetUnitArray()
        {
            return units;
        }
        public bool GetColourValue()
        {
            return mainProfile[0].Colour;
        }
        public int GetUnitIndex()
        {
            return mainProfile[0].Units;
        }
    }
}
