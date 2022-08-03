using System;
using System.Collections.Generic;
using System.Text;
using PCLStorage;
using Newtonsoft.Json;
using Weather.Models;
using System.Threading.Tasks;

namespace Weather.Services
{
    public class FavouritesManager
    {
        private const string fileName = "favourites.json";
        private const string folderName = "FaveCities";

        public async Task SaveFavourite(CityObj cityObj)
        {
            CityObj favouriteCity;
            List<CityObj> favourites = new List<CityObj>();
            string jsonFavourite;

            //access folder
            IFolder folder = FileSystem.Current.LocalStorage;
            folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            //accessing file
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            //accessing json text in file
            string exisitingFavourites = await file.ReadAllTextAsync();

            //get the exisiting favourites
            try
            {
                //there is already multiple
                //get exisiting favourites
                favourites = JsonConvert.DeserializeObject<List<CityObj>>(exisitingFavourites);
                //find this favourite
                if (!favourites.Contains(cityObj))
                {
                    //add this favourite
                    favourites.Add(cityObj);
                    jsonFavourite = JsonConvert.SerializeObject(favourites);
                    //write json text
                    await file.WriteAllTextAsync(jsonFavourite);
                }
                
            }
            catch (JsonSerializationException)
            {
                //there is only 1
                //get exisiting favourite
                favouriteCity = JsonConvert.DeserializeObject<CityObj>(exisitingFavourites);
                if (favouriteCity != cityObj)
                {
                    //add to list
                    favourites.Add(favouriteCity);
                    //add this favourite
                    favourites.Add(cityObj);
                    jsonFavourite = JsonConvert.SerializeObject(favourites);
                    //write json text
                    await file.WriteAllTextAsync(jsonFavourite);
                }
                    
            }
            catch (NullReferenceException)
            {
                //there are none
                //save this favourite
                jsonFavourite = JsonConvert.SerializeObject(cityObj);
                //write json text
                await file.WriteAllTextAsync(jsonFavourite);
            }

        }
        public async Task<List<CityObj>> GetFavouriteCities()
        {
            List<CityObj> favourites = new List<CityObj>();
            CityObj favouriteCity;

            //accessing folder
            IFolder folder = FileSystem.Current.LocalStorage;
            folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);

            //accessing file
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            //accessing json text in file
            string text = await file.ReadAllTextAsync();

            

            //accessing json text in file
            string exisitingFavourites = await file.ReadAllTextAsync();

            try
            {
                //there are already multiple
                //get exisiting favourites
                favourites = JsonConvert.DeserializeObject<List<CityObj>>(exisitingFavourites);
                //this is empty, is this a problem with my save or show?
                return favourites;
            }
            catch (JsonSerializationException)
            {
                //there is only 1
                //get exisiting favourite
                favouriteCity = JsonConvert.DeserializeObject<CityObj>(exisitingFavourites);
                //add to list
                favourites.Add(favouriteCity);
                return favourites;
            }
            catch (NullReferenceException)
            {
                //is null
                return favourites;
            }

            //getting json and convert to list
            //right now this is just returning 1 item
            //CityObj favouriteCity;
            //favouriteCity = JsonConvert.DeserializeObject<CityObj>(text);
            //favourites.Add(favouriteCity);


            //getting json and convert to list
            //favourites = JsonConvert.DeserializeObject<List<CityObj>>(text);

            /*
            if(favourites == null)
            {
                favourites.Add(new CityObj("Perth", "AU"));
                favourites.Add(new CityObj("Vancouver", "CA"));
            }*/
        }

        public async void RemoveFavourite(CityObj cityObj)
        {
            List<CityObj> favourites;
            CityObj exisitingFave;
            string jsonFavourite;

            //accessing folder
            IFolder folder = FileSystem.Current.LocalStorage;
            folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);

            //accessing file
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            //accessing json text in file
            string exisitingFavourites = await file.ReadAllTextAsync();


            try
            {
                //there are already multiple
                //get exisiting favourites
                favourites = JsonConvert.DeserializeObject<List<CityObj>>(exisitingFavourites);
                //find city in favourites
                if (favourites.Contains(cityObj))
                {
                    //remove city from favourites
                    favourites.Remove(cityObj);
                    //save new favourites
                    jsonFavourite = JsonConvert.SerializeObject(favourites);
                    //write json text
                    await file.WriteAllTextAsync(jsonFavourite);
                }
            }
            catch (JsonSerializationException)
            {
                //there is only 1
                //get exisiting favourite
                exisitingFave = JsonConvert.DeserializeObject<CityObj>(exisitingFavourites);
                if (exisitingFave == cityObj)
                {
                    jsonFavourite = null;
                    //write json text
                    await file.WriteAllTextAsync(jsonFavourite);
                }
            }

        }

        public async Task<bool> IsAFavourite(CityObj cityObj)
        {
            CityObj favouriteCity;
            List<CityObj> favourites = new List<CityObj>();

            //access folder
            IFolder folder = FileSystem.Current.LocalStorage;
            folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            //accessing file
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            //accessing json text in file
            string exisitingFavourites = await file.ReadAllTextAsync();
            //get the exisiting favourites
            try
            {
                //there is already multiple
                //get exisiting favourites
                favourites = JsonConvert.DeserializeObject<List<CityObj>>(exisitingFavourites);
                //find this favourite
                if (favourites.Contains(cityObj))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (JsonSerializationException)
            {
                //there is only 1
                //get exisiting favourite
                favouriteCity = JsonConvert.DeserializeObject<CityObj>(exisitingFavourites);
                //add to list
                if (favouriteCity == cityObj)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }

        }
        public async void RemoveAllFavourites()
        {
            //access folder
            IFolder folder = FileSystem.Current.LocalStorage;
            folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            //accessing file
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            //accessing json text in file
            string exisitingFavourites = await file.ReadAllTextAsync();
            exisitingFavourites = null;
            await file.WriteAllTextAsync(exisitingFavourites);
        }
    }
   

}
