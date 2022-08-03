using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search : ContentPage
    {
        WeatherAPI weatherAPI;
        ProfManager mainProfile;

        public Search()
        {
            InitializeComponent();
            weatherAPI = new WeatherAPI();
            mainProfile = ((App)Application.Current).Profiles;
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

        private async void SearchCityButton_Clicked(object sender, EventArgs e)
        {
            string units = mainProfile.GetUnits();
            string searchCity = SearchEntry.Text;

            string foundCity = await weatherAPI.CheckCity(searchCity, units);

            if (foundCity != "")
            {
                FoundCityButton.Text = foundCity;
            }
        }

        public async void FoundCityButton_Clicked(object sender, EventArgs e)
        {
            string city = (sender as Button).Text;

            if (city != "")
            {
                SearchWeather searchWeather = new SearchWeather(city);
                await Navigation.PushModalAsync(searchWeather);
            }

        }

    }
}