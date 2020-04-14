using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetGSB.Mobile
{
    public partial class App : Application
    {
        public static INavigation GlobalNavigation { get; private set; }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();

            var rootPage = new NavigationPage(new ProjetGSB.Mobile.MainPage());

            GlobalNavigation = rootPage.Navigation;

            MainPage = rootPage;
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
