using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Weather.Models;

namespace Weather.Services
{
    /// <summary>
    /// Manages api back end calls and responses.
    /// </summary>
    class WeatherAPI
    {
        //this will not change so can be stored as a const - Can also be put into the APP.XAML file.
        const string apiKey = "b625c094845a3be181d28d3e6664ea93";

        /// <summary>
        /// This function takes the city name and inserts the value into the api call. Uses an HTTP client to call the api
        /// and get the response from the server, then deserializes this from JSON into the weather object we created.
        /// </summary>
        /// <param name="city"></param>
        /// <param units="units"></param>
        /// <returns></returns>
        

        public async Task<double> GetTemp(string city, string units)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Content == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", string.Format("Response contained status code:{ 0}", response.StatusCode), "OK");
                return 0;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherObj root = JsonConvert.DeserializeObject<WeatherObj>(content);
                return root.main.temp;
            }
            return 0;
        }
        public async Task<double> GetMinTemp(string city, string units)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Content == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", string.Format("Response contained status code:{ 0}", response.StatusCode), "OK");
                return 0;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherObj root = JsonConvert.DeserializeObject<WeatherObj>(content);
                return root.main.temp_min;
            }
            return 0;
        }
        public async Task<double> GetMaxTemp(string city, string units)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Content == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", string.Format("Response contained status code:{ 0}", response.StatusCode), "OK");
                return 0;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherObj root = JsonConvert.DeserializeObject<WeatherObj>(content);
                return root.main.temp_max;
            }
            return 0;
        }
        public async Task<double> GetFeelsLike(string city, string units)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Content == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", string.Format("Response contained status code:{ 0}", response.StatusCode), "OK");
                return 0;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherObj root = JsonConvert.DeserializeObject<WeatherObj>(content);
                return root.main.feels_like;
            }
            return 0;
        }
        public async Task<string> GetCountry(string city, string units)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Content == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", string.Format("Response contained status code:{ 0}", response.StatusCode), "OK");
                return "";
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherObj root = JsonConvert.DeserializeObject<WeatherObj>(content);
                return root.sys.country;
            }
            return "";
        }

        public async Task<int> GetHumidity(string city, string units)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Content == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", string.Format("Response contained status code:{ 0}", response.StatusCode), "OK");
                return 0;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherObj root = JsonConvert.DeserializeObject<WeatherObj>(content);
                return root.main.humidity;
            }
            return 0;
        }
        public async Task<float> GetWindSpeed(string city, string units)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Content == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", string.Format("Response contained status code:{ 0}", response.StatusCode), "OK");
                return 0;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherObj root = JsonConvert.DeserializeObject<WeatherObj>(content);
                return root.wind.speed;
            }
            return 0;
        }
        public async Task<int> GetCloudiness(string city, string units)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Content == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", string.Format("Response contained status code:{ 0}", response.StatusCode), "OK");
                return 0;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherObj root = JsonConvert.DeserializeObject<WeatherObj>(content);
                return root.clouds.all;
            }
            return 0;
        }
        public async Task<int> GetSunrise(string city, string units)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Content == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", string.Format("Response contained status code:{ 0}", response.StatusCode), "OK");
                return 0;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherObj root = JsonConvert.DeserializeObject<WeatherObj>(content);
                return root.sys.sunrise;
            }
            return 0;
        }
        public async Task<int> GetSunset(string city, string units)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Content == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", string.Format("Response contained status code:{ 0}", response.StatusCode), "OK");
                return 0;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherObj root = JsonConvert.DeserializeObject<WeatherObj>(content);
                return root.sys.sunset;
            }
            return 0;
        }

        public async Task<string> GetWeatherDesc(string city, string units)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Content == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", string.Format("Response contained status code:{ 0}", response.StatusCode), "OK");
                return "";
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherObj root = JsonConvert.DeserializeObject<WeatherObj>(content);
                return root.weather[0].description;
            }
            return "";
        }

        public async Task<string> GetWeatherImageSource(string city, string units)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Content == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", string.Format("Response contained status code:{ 0}", response.StatusCode), "OK");
                return "";
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherObj root = JsonConvert.DeserializeObject<WeatherObj>(content);
                return root.weather[0].icon_url;
            }
            return "";
        }

        public async Task<string> CheckCity(string city, string units)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Content == null)
            {
                return "";
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                WeatherObj root = JsonConvert.DeserializeObject<WeatherObj>(content);
                return root.name;
            }
            return "";
        }


    }
}
