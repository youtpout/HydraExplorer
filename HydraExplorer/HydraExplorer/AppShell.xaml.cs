using HydraExplorer.Services;
using HydraExplorer.ViewModels;
using HydraExplorer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HydraExplorer
{
    public partial class AppShell : Shell
    {
        private string titleSelected;

        public string TitleSelected
        {
            get { return titleSelected; }
            set
            {
                titleSelected = value;
                OnPropertyChanged();
            }
        }

        public const string keyTestnet = "keyTestnet";


        private string explorerSelected;

        public string ExplorerSelected
        {
            get { return explorerSelected; }
            set
            {
                explorerSelected = value;
                OnPropertyChanged();
            }
        }


        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = this;
            Routing.RegisterRoute(nameof(BlockPage), typeof(BlockPage));
            Routing.RegisterRoute(nameof(AddressPage), typeof(AddressPage));
            Routing.RegisterRoute(nameof(TransactionPage), typeof(TransactionPage));

            var testnetSelected = Preferences.Get(keyTestnet, false);
            this.ExplorerSelected = testnetSelected ? "TestNet" : "MainNet";
            ApiService.isTestNet = testnetSelected;
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//LoginPage");
            var testnetSelected = Preferences.Get(keyTestnet, false);
            bool toggle = !testnetSelected;
            Preferences.Set(keyTestnet, toggle);
            this.ExplorerSelected = toggle ? "TestNet" : "MainNet";
            ApiService.isTestNet = toggle;
            //await Current.GoToAsync("//HomePage");
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
            TitleSelected = Current.CurrentItem.Title;
        }

    }
}
