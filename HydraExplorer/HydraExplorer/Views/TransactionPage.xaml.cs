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
    [QueryProperty(nameof(Transaction), "Transaction")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionPage : ContentPage
    {
        public TransactionPage()
        {
            InitializeComponent();
        }

        public string Transaction{ set { LoadTransaction(value); } }

        async void LoadTransaction(string tx)
        {
            TransactionViewModel vm = this.BindingContext as TransactionViewModel;
            if (vm != null)
            {
                await vm.GetTransaction(tx);
            }
        }
    }
}