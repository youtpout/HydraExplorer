using HydraExplorer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace HydraExplorer.ViewModels
{
    public class InfoViewModel : BaseViewModel
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


        public InfoViewModel()
        {
            Title = "Info";
            GetInfo();
        }

        async void GetInfo()
        {
            var result = await ApiService.GetInfo();
            Debug.WriteLine(result.height);
            this.Info = result;
        }
    }
}
