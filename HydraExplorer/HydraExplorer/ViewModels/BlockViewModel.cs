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
    public class BlockViewModel : BaseViewModel
    {


        private Block block;

        public Block Block
        {
            get { return block; }
            set { SetProperty(ref block, value); }
        }

        private string blockName;

        public string BlockName
        {
            get { return blockName; }
            set { SetProperty(ref blockName, value); }
        }

        private string fontFavorite;

        public string FontFavorite
        {
            get { return fontFavorite; }
            set { SetProperty(ref fontFavorite, value); }
        }

        public Command FavoriteCommand { get; set; }
        public Command<string> AddressCommand { get; set; }
        public Command PreviousBlockCommand { get; set; }
        public Command NextBlockCommand { get; set; }

        public BlockViewModel():base()
        {
            Title = "Block";

            FavoriteCommand = new Command(() =>
            {
                List<Favorite> favorites = PropertiesGetValue<List<Favorite>>(Favorite.keyFavorites);
                bool contains = favorites.Exists(f => f.Value == this.BlockName);
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
                bool contains = favorites.Exists(f => f.Value == this.BlockName);
                FontFavorite = contains ? "FA-Solid" : "FA-Regular";
            });

            AddressCommand = new Command<string>(async (query) =>
            {
                await NavigateTo(Search.typeAddress, query);
            });

            PreviousBlockCommand = new Command(async () =>
            {
                await GetBlock((Block.height - 1).ToString());
            });

            NextBlockCommand = new Command(async () =>
            {
                await GetBlock((Block.height + 1).ToString());
            });
        }

        public async Task GetBlock(string adr)
        {
            this.BlockName = adr;
            this.Block = await ApiService.GetBlock(adr);
        }

        public void AddToFavorite()
        {
            List<Favorite> favorites = PropertiesGetValue<List<Favorite>>(Favorite.keyFavorites);
            favorites.Add(new Favorite()
            {
                Value = this.BlockName,
                SearchType = Search.typeBlock
            });
            PropertiesSetValue(Favorite.keyFavorites, favorites);
            FontFavorite = "FA-Solid";
        }

        public void RemoveFromFavorite()
        {
            List<Favorite> favorites = PropertiesGetValue<List<Favorite>>(Favorite.keyFavorites);
            var item = favorites.Single(f => f.Value == this.BlockName);
            favorites.Remove(item);
            PropertiesSetValue(Favorite.keyFavorites, favorites);
            FontFavorite = "FA-Regular";
        }
    }
}
