using HydraExplorer.Services;
using HydraExplorer.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HydraExplorer
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ApiService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
