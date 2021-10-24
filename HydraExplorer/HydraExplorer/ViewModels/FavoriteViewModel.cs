using HydraExplorer.Models;
using HydraExplorer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace HydraExplorer.ViewModels
{
    public class FavoriteViewModel : BaseViewModel
    {
        public ObservableCollection<Favorite> Favorites { get; set; }

        public Command<object> SelectCommand { get; set; }

        private Favorite selectedItem;

        public Favorite SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                SelectCommand.Execute(value);
            }
        }



        public FavoriteViewModel() : base()
        {
            Title = "Favorites";
            Favorites = new ObservableCollection<Favorite>();

            SelectCommand = new Command<object>(async (item) =>
              {
                  Favorite fav = item as Favorite;
                  if (fav != null)
                  {
                      await NavigateTo(fav.SearchType, fav.Value);
                  }
              });

            LoadCommand = new Command(() =>
           {
               List<Favorite> favorites = PropertiesGetValue<List<Favorite>>(Favorite.keyFavorites);
               Favorites.Clear();
               favorites.ForEach(f => Favorites.Add(f));
           });

        }
    }
}
