using HydraExplorer.Services;
using HydraExplorer.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

[assembly: ExportFont("FA-Brands-Regular-400.otf", Alias = "FA-Brands")]
[assembly: ExportFont("FA-Regular-400.otf", Alias = "FA-Regular")]
[assembly: ExportFont("FA-Solid-900.otf", Alias = "FA-Solid")]
namespace HydraExplorer
{
    public partial class App : Xamarin.Forms.Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ApiService>();
            MainPage = new AppShell();
            MainPage.On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Always);
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
