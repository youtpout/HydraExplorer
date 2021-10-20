﻿using HydraExplorer.ViewModels;
using HydraExplorer.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HydraExplorer
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddressPage), typeof(AddressPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
