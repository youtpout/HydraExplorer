using HydraExplorer.Models;
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
            IsFavorite();
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
            Preferences.Set(this.AddressName, true);
            IsFavorite();
        }

        public void RemoveFromFavorite()
        {
            Preferences.Set(this.AddressName, false);
            IsFavorite();
        }

        void IsFavorite()
        {
            var item = Preferences.Get(this.AddressName, false);
            this.FontFavorite = item ? "FA-Solid" : "FA-Regular";
        }
    }
}
