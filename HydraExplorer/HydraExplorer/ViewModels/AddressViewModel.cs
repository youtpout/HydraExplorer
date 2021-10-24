using HydraExplorer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HydraExplorer.ViewModels
{
    public class AddressViewModel : BaseViewModel
    {


        private Address address;

        public Address Address
        {
            get { return address; }
            set { SetProperty(ref address, value); }
        }

        private string addressName;

        public string AddressName
        {
            get { return addressName; }
            set { SetProperty(ref addressName, value); }
        }

        private string fontFavorite;

        public string FontFavorite
        {
            get { return fontFavorite; }
            set { SetProperty(ref fontFavorite, value); }
        }

        public Command FavoriteCommand { get; set; }

        public AddressViewModel() : base()
        {
            Title = "Addresse";

            FavoriteCommand = new Command(() =>
            {
                List<Favorite> favorites = PropertiesGetValue<List<Favorite>>(Favorite.keyFavorites);
                bool contains = favorites.Exists(f => f.Value == this.AddressName);
                if (contains)
                {
                    RemoveFromFavorite();
                }
                else
                {
                    AddToFavorite();
                }
            });


            LoadCommand = new Command(() =>
            {
                List<Favorite> favorites = PropertiesGetValue<List<Favorite>>(Favorite.keyFavorites);
                bool contains = favorites.Exists(f => f.Value == this.AddressName);
                FontFavorite = contains ? "FA-Solid" : "FA-Regular";
            });
        }

        public async Task GetAddress(string adr)
        {
            this.AddressName = adr;
            this.Address = await ApiService.GetAddress(adr);
        }

        public void AddToFavorite()
        {
            List<Favorite> favorites = PropertiesGetValue<List<Favorite>>(Favorite.keyFavorites);
            favorites.Add(new Favorite()
            {
                Value = this.AddressName,
                SearchType = Search.typeAddress
            });
            PropertiesSetValue(Favorite.keyFavorites, favorites);
            FontFavorite = "FA-Solid";
        }

        public void RemoveFromFavorite()
        {
            List<Favorite> favorites = PropertiesGetValue<List<Favorite>>(Favorite.keyFavorites);
            var item = favorites.Single(f => f.Value == this.AddressName);
            favorites.Remove(item);
            PropertiesSetValue(Favorite.keyFavorites, favorites);
            FontFavorite = "FA-Regular";
        }
    }
}
