using AppExamenObandoBryan.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExamenObandoBryan
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PageLaptop());
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
