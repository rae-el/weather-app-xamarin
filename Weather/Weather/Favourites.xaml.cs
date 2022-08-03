using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Weather.Services;
using Weather.Models;

namespace Weather
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favourites : ContentPage
    {
        FavouritesManager favouritesManager;

        public Favourites()
        {
            InitializeComponent();
            favouritesManager = ((App)Application.Current).FavouritesManager;
            UpdatePage();
        }
        
        private async void UpdatePage()
        {
            List<CityObj> favourites = await favouritesManager.GetFavouriteCities();

            if (favourites != null)
            {
                ClearFavesButton.IsVisible = true;
                foreach (CityObj faveCity in favourites)
                {
                    Button faveCityButton = new Button();
                    faveCityButton.Text = faveCity.ToString();
                    FavouritesStack.Children.Add(faveCityButton);
                }
            }

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

        private void ClearFavesButton_Clicked(object sender, EventArgs e)
        {
            favouritesManager.RemoveAllFavourites();
        }
    }
}