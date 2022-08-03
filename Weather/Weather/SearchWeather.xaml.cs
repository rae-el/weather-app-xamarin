using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;
using Weather.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchWeather : ContentPage
    {
        WeatherAPI weatherAPI;
        ProfManager mainProfile;
        FavouritesManager favouritesManager;


        public SearchWeather(string city)
        {
            InitializeComponent();
            weatherAPI = new WeatherAPI();
            mainProfile = ((App)Application.Current).Profiles;
            favouritesManager = ((App)Application.Current).FavouritesManager;
            string units = mainProfile.GetUnits();

            GetWeather(city, units);

        }
        private async void GetWeather(string city, string units)
        {
            string country = await weatherAPI.GetCountry(city, units);
            double temp = await weatherAPI.GetTemp(city, units);
            double feelsLike = await weatherAPI.GetFeelsLike(city, units);
            int humidity = await weatherAPI.GetHumidity(city, units);
            float windSpeed = await weatherAPI.GetWindSpeed(city, units);
            string iconUrl = await weatherAPI.GetWeatherImageSource(city, units);
            //cannot be bothered to do wind direction atm... a lot of work converting to NSEW
            //cannot be bothered to do sunrise/set atm... a lot of work converting reg time
            //int sunrise = await weatherAPI.GetSunrise(city);
            //SunriseLabel.Text = String.Format("{Common.Common.UnixTimeStampToDateTime(sunrise).ToString("HH: mm")})
            //cannot be bothered to do rain atm... per 1 or 3 hours

            CityObj thisCity = new CityObj(city, country);
            FaveCheckBox.IsChecked = await favouritesManager.IsAFavourite(thisCity);

            CityLabel.Text = city;
            CountryLabel.Text = country;
            WeatherDescLabel.Text = await weatherAPI.GetWeatherDesc(city, units);
            HumidityLabel.Text = String.Format("Humidity: {0:0} %", humidity);
            WeatherImage.Source = iconUrl;

            if (units == "imperial")
            {
                TempLabel.Text = String.Format("{0:0} °F", temp);
                FeelsLikeLabel.Text = String.Format("Feels like: {0:0} °F", feelsLike);
                WindLabel.Text = String.Format("Wind: {0:0} miles / hour", windSpeed);
            }
            else
            {
                TempLabel.Text = String.Format("{0:0} °C", temp);
                FeelsLikeLabel.Text = String.Format("Feels like: {0:0} °C", feelsLike);
                WindLabel.Text = String.Format("Wind: {0:0} metres / second", windSpeed);
            }
        }

        public async Task<CityObj> ThisCity(string city)
        {
            //just here to hold space need actual city 
            string units = mainProfile.GetUnits();
            string country = await weatherAPI.GetCountry(city, units);
            CityObj faveCity = new CityObj(city, country);
            return faveCity;
        }

        private async void HomeButton_Clicked(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            await Navigation.PushModalAsync(mainPage);
        }

        private async void SearchButton_Clicked(object sender, EventArgs e)
        {
            Search searchPage = new Search();
            await Navigation.PushModalAsync(searchPage);
        }

        private async void ProfileButton_Clicked(object sender, EventArgs e)
        {
            Profile profilePage = new Profile();
            await Navigation.PushModalAsync(profilePage);
        }

        private async void FaveButton_Clicked(object sender, EventArgs e)
        {
            Favourites favouritesPage = new Favourites();
            await Navigation.PushModalAsync(favouritesPage);
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        /*
        private async void FaveCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            //removing this as it doesnt work properly
            //just here to hold space need actual city
            //this doesnt work properly
            //how do i transfer the proper city data
            //this gets the main profile city
            string city = mainProfile.GetCity();
            string units = mainProfile.GetUnits();
            string country = await weatherAPI.GetCountry(city, units);

            CityObj thisCity = new CityObj(city, country);

            if (FaveCheckBox.IsChecked)
            {

                await favouritesManager.SaveFavourite(thisCity);
            }
            else
            {
                favouritesManager.RemoveFavourite(thisCity);
            }
        }*/
    }
}