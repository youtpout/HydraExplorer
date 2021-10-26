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
    public class TransactionViewModel : BaseViewModel
    {


        private Transaction transaction;

        public Transaction Transaction
        {
            get { return transaction; }
            set { SetProperty(ref transaction, value); }
        }

        private string transactionName;

        public string TransactionName
        {
            get { return transactionName; }
            set { SetProperty(ref transactionName, value); }
        }

        private string fontFavorite;

        public string FontFavorite
        {
            get { return fontFavorite; }
            set { SetProperty(ref fontFavorite, value); }
        }

        public Command FavoriteCommand { get; set; }
        public Command<int> BlockCommand { get; set; }

        public TransactionViewModel() : base()
        {
            Title = "Transaction";

            FavoriteCommand = new Command(() =>
            {
                List<Favorite> favorites = PropertiesGetValue<List<Favorite>>(Favorite.keyFavorites);
                bool contains = favorites.Exists(f => f.Value == this.TransactionName);
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
                bool contains = favorites.Exists(f => f.Value == this.TransactionName);
                FontFavorite = contains ? "FA-Solid" : "FA-Regular";
            });

            BlockCommand = new Command<int>(async (query) =>
            {
                await NavigateTo(Search.typeBlock, query.ToString());
            });
        }

        public async Task GetTransaction(string tx)
        {
            this.TransactionName = tx;
            this.Transaction = await ApiService.GetTransaction(tx);
        }

        public void AddToFavorite()
        {
            List<Favorite> favorites = PropertiesGetValue<List<Favorite>>(Favorite.keyFavorites);
            favorites.Add(new Favorite()
            {
                Value = this.TransactionName,
                SearchType = Search.typeAddress
            });
            PropertiesSetValue(Favorite.keyFavorites, favorites);
            FontFavorite = "FA-Solid";
        }

        public void RemoveFromFavorite()
        {
            List<Favorite> favorites = PropertiesGetValue<List<Favorite>>(Favorite.keyFavorites);
            var item = favorites.Single(f => f.Value == this.TransactionName);
            favorites.Remove(item);
            PropertiesSetValue(Favorite.keyFavorites, favorites);
            FontFavorite = "FA-Regular";
        }
    }
}
