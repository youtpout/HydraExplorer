using HydraExplorer.Models;
using HydraExplorer.Services;
using HydraExplorer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HydraExplorer.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IApiService ApiService => DependencyService.Get<IApiService>();
        public Command LoadCommand { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public BaseViewModel()
        {
            this.ApiService.Loading += ApiService_Loading;
        }

        private void ApiService_Loading(object sender, bool e)
        {
            IsBusy = e;
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        /// <summary>
        /// Store data in smartphone Properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void PropertiesSetValue<T>(string key, T value)
        {
            if (value is string)
            {
                Application.Current.Properties[key] = value;
            }
            else
            {
                string res = Newtonsoft.Json.JsonConvert.SerializeObject(value);
                Application.Current.Properties[key] = res;
            }
        }

        /// <summary>
        /// Retrieve data from smarthphone properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T PropertiesGetValue<T>(string key) where T : new()
        {
            Application.Current.Properties.TryGetValue(key, out object val);
            string value = string.Empty;
            if (val != null)
            {
                value = val.ToString();
                if (typeof(T) == typeof(string))
                {
                    return (T)val;
                }
                else
                {
                    T res = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
                    return res;
                }
            }
            return new T();
        }

        protected async Task NavigateTo(string searchType, string value)
        {
            if (searchType == Search.typeAddress)
            {
                await Shell.Current.GoToAsync($"{nameof(AddressPage)}?Address={value}");
            }
            else if (searchType == Search.typeBlock)
            {
                await Shell.Current.GoToAsync($"{nameof(BlockPage)}?Block={value}");
            }

            await Shell.Current.DisplayAlert("Search", "Not supported for the moment", "OK");
        }


    }
}
