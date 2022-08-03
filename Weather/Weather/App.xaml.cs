using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Weather.Services;
using Xamarin.Essentials;

namespace Weather
{
    public partial class App : Application
    {

        public Services.ProfManager Profiles = new Services.ProfManager();
        public Services.FavouritesManager FavouritesManager = new Services.FavouritesManager();

        public App()
        {
            InitializeComponent();
            var theme = Preferences.Get("OSAppTheme", Enum.GetName(typeof(OSAppTheme), OSAppTheme.Unspecified));
            App.Current.UserAppTheme = (OSAppTheme)Enum.Parse(typeof(OSAppTheme), theme);
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
