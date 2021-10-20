using HydraExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HydraExplorer.Views
{
    [QueryProperty(nameof(Address), "Address")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressPage : ContentPage
    {
        public AddressPage()
        {
            InitializeComponent();
        }

        public string Address { set {  LoadAddress(value); } }

        async void LoadAddress(string address)
        {
            AddressViewModel vm = this.BindingContext as AddressViewModel;
            if (vm != null)
            {
                await vm.GetAddress(address);
            }
        }
    }
}