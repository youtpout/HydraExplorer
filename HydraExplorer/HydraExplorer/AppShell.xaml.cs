using HydraExplorer.ViewModels;
using HydraExplorer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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


        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = this;
            Routing.RegisterRoute(nameof(AddressPage), typeof(AddressPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//LoginPage");
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
            TitleSelected = Current.CurrentItem.Title;
        }

    }
}
