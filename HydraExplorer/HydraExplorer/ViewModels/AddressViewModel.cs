using HydraExplorer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HydraExplorer.ViewModels
{
    public class AddressViewModel : BaseViewModel
    {
        public const string keyAddresses = "Addresses";

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

        public AddressViewModel()
        {
            List<string> favorites = PropertiesGetValue<List<string>>(keyAddresses);
            bool contains = favorites.Contains(AddressName);
            FontFavorite = contains ? "FA-Solid" : "FA-Regular";
            FavoriteCommand = new Command(() =>
            {
                var item = Preferences.Get(this.AddressName, false);
                if (item)
                {
                    RemoveFromFavorite();
                }
                else
                {
                    AddToFavorite();
                }
            });
        }

        public async Task GetAddress(string adr)
        {
            this.AddressName = adr;
            this.Address = await ApiService.GetAddress(adr);
        }

        public void AddToFavorite()
        {
            List<string> favorites = PropertiesGetValue<List<string>>(keyAddresses);
            favorites.Add(AddressName);
            PropertiesSetValue(keyAddresses, favorites);
            FontFavorite = "FA-Solid";
        }

        public void RemoveFromFavorite()
        {
            List<string> favorites = PropertiesGetValue<List<string>>(keyAddresses);
            favorites.Remove(AddressName);
            PropertiesSetValue(keyAddresses, favorites);
            FontFavorite = "FA-Regular";
        }
    }
}
