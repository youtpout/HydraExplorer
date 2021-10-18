using HydraExplorer.Models;
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



        public Command LoadCommand { get; set; }


        public HomeViewModel()
        {
            Title = "Home";
            LoadCommand = new Command(async () =>
            {
                await LoadDatas();
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
