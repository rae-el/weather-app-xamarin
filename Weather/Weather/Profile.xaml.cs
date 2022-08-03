using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Weather.Services;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using Weather.Themes;

namespace Weather
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        ProfManager mainProfile;

        public Profile()
        {
            InitializeComponent();
            mainProfile = ((App)Application.Current).Profiles;
            UpdatePage();
        }

        public void UpdatePage()
        {
            //doing colour as a switch toggle instead of a picker now
            //ColourPicker.ItemsSource = mainProfile.GetColourArray();
            //ColourPicker.SelectedIndex = mainProfile.GetColourIndex();
            ColourSwitch.IsToggled = mainProfile.GetColourValue();
            UnitsPicker.ItemsSource = mainProfile.GetUnitArray();
            UnitsPicker.SelectedIndex = mainProfile.GetUnitIndex();
            NameEntry.Text = mainProfile.GetName();
            CityEntry.Text = mainProfile.GetCity();
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

        private async void EditProfile_Clicked(object sender, EventArgs e)
        {
            string origName = mainProfile.GetName();
            string origCity = mainProfile.GetCity();
            int origUnit = mainProfile.GetUnitIndex();
            bool origColour = mainProfile.GetColourValue();

            string tryName = NameEntry.Text;
            string tryCity = CityEntry.Text;
            int tryUnit = UnitsPicker.SelectedIndex;
            bool tryColour = ColourSwitch.IsToggled;


            string updateTextLabel = "";

            if (origName != tryName)
            {
                if (!Regex.Match(tryName, "^[A-Z][a-zA-Z]*$").Success || !mainProfile.ChangeName(tryName))
                {
                    updateTextLabel = "We couldn't update please try again";
                    UpdateLabel.Text = updateTextLabel;
                    UpdatePage();
                    return;
                }
                else
                {
                    updateTextLabel = "Success";
                    UpdateLabel.Text = updateTextLabel;
                    UpdatePage();
                }
            }

            if (origCity != tryCity)
            {
                if (!Regex.Match(tryCity, "^[A-Z][a-zA-Z]*$").Success || !await mainProfile.ChangeCity(tryCity, mainProfile.GetUnits()))
                {
                    updateTextLabel = "We couldn't update please try again";
                    UpdateLabel.Text = updateTextLabel;
                    UpdatePage();
                    return;
                }
                else
                {
                    updateTextLabel = "Success";
                    UpdateLabel.Text = updateTextLabel;
                    UpdatePage();
                }
            }

            if (origUnit != tryUnit)
            {
                mainProfile.ChangeUnits(tryUnit);
                updateTextLabel = "Success";
                UpdateLabel.Text = updateTextLabel;
                UpdatePage();
            }
            if (origColour != tryColour)
            {
                mainProfile.ChangeColour(tryColour);
                updateTextLabel = "Success";
                UpdateLabel.Text = updateTextLabel;
                UpdatePage();
            }

        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        
    }
}