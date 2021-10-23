using HydraExplorer.Models;
using HydraExplorer.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HydraExplorer.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private Info info;

        public Info Info
        {
            get { return info; }
            set
            {
                SetProperty(ref info, value);
            }
        }

        private List<Block> blocks;

        public List<Block> Blocks
        {
            get { return blocks; }
            set { SetProperty(ref blocks, value); }
        }

        private List<Transaction> transactions;

        public List<Transaction> Transactions
        {
            get { return transactions; }
            set { SetProperty(ref transactions, value); }
        }

        private bool visibleSearch;

        public bool VisibleSearch
        {
            get { return visibleSearch; }
            set
            {
                SetProperty(ref visibleSearch, value);
            }
        }

        public Command<string> SearchCommand { get; set; }
        public Command<string> AddressCommand { get; set; }
        public Command<int> BlockCommand { get; set; }
        public Command ToggleSearchCommand { get; set; }

        public HomeViewModel()
        {
            Title = "Home";
            LoadCommand = new Command(async () =>
            {
                await LoadDatas();
            });
            SearchCommand = new Command<string>(async (query) =>
              {
                  var result = await ApiService.Search(query);
                  Debug.WriteLine(result.type);
                  if (result.type == Search.typeAddress)
                  {
                      await Shell.Current.GoToAsync($"{nameof(AddressPage)}?Address={query}");
                  }
                  else if (result.type == Search.typeBlock)
                  {
                      await Shell.Current.GoToAsync($"{nameof(BlockPage)}?Block={query}");
                  }
              });

            AddressCommand = new Command<string>(async (query) =>
            {
                await Shell.Current.GoToAsync($"{nameof(AddressPage)}?Address={query}");
            });

            BlockCommand = new Command<int>(async (query) =>
            {
                await Shell.Current.GoToAsync($"{nameof(BlockPage)}?Block={query}");
            });

            ToggleSearchCommand = new Command(() =>
              {
                  VisibleSearch = !VisibleSearch;
              });
        }

        public async Task LoadDatas()
        {
            this.Info = await ApiService.GetInfo();
            this.Blocks = await ApiService.GetLastBlocks(3);
            this.Transactions = await ApiService.GetLastTransactions(3);
        }

    }
}
