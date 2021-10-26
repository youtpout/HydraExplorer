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

        private List<BlockInfo> blocks;

        public List<BlockInfo> Blocks
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
        public Command<string> TxCommand { get; set; }
        public Command ToggleSearchCommand { get; set; }

        public HomeViewModel() : base()
        {
            Title = "Home";
            LoadCommand = new Command(async () =>
            {
                await LoadDatas();
            });
            SearchCommand = new Command<string>(async (query) =>
              {
                  try
                  {
                      var result = await ApiService.Search(query);
                      if (!string.IsNullOrEmpty(result?.type))
                      {
                          await NavigateTo(result.type, query);
                      }
                      else
                      {
                          await Shell.Current.DisplayAlert("Search", "Not found", "OK");
                      }
                  }
                  catch (Exception ex)
                  {
                      await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
                  }
              });

            AddressCommand = new Command<string>(async (query) =>
            {
                await NavigateTo(Search.typeAddress, query);
            });

            BlockCommand = new Command<int>(async (query) =>
            {
                await NavigateTo(Search.typeBlock, query.ToString());
            });

            TxCommand = new Command<string>(async (query) =>
            {
                await NavigateTo(Search.typeTransaction, query);
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
