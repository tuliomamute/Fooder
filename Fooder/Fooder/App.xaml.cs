using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fooder.Views;
using Xamarin.Forms;
using Fooder.InternalService;

namespace Fooder
{
    public partial class App : Application
    {
        public static NavigationService NavigationService { get; }
= new NavigationService();

        public App()
        {
            InitializeComponent();

            MainPage = new MasterPaginaMestraPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
