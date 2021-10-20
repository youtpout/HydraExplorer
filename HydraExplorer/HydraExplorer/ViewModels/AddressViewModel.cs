using HydraExplorer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HydraExplorer.ViewModels
{
    public class AddressViewModel : BaseViewModel
    {
        private Address address;

        public Address Address
        {
            get { return address; }
            set { SetProperty(ref address, value); }
        }

        private string addressName;

        public string AddressName
        {
            get { return addressName; }
            set { SetProperty(ref addressName, value); }
        }



        public AddressViewModel() { }

        public async Task GetAddress(string adr)
        {
            this.AddressName = adr;
            this.Address = await ApiService.GetAddress(adr);
        }
    }
}
