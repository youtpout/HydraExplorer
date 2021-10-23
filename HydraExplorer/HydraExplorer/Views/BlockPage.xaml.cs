using System;
using System.Collections.Generic;
using HydraExplorer.Models;
using HydraExplorer.ViewModels;
using Xamarin.Forms;

namespace HydraExplorer.Views
{
    [QueryProperty(nameof(Block), "Block")]
    public partial class BlockPage : ContentPage
    {
        public BlockPage()
        {
            InitializeComponent();
        }

        public string Block { set { LoadBlock(value); } }

        async void LoadBlock(string block)
        {
            BlockViewModel vm = this.BindingContext as BlockViewModel;
            if (vm != null)
            {
                await vm.GetBlock(block);
            }
        }
    }
}
