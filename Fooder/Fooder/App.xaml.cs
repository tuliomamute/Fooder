using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fooder.Views;
using Xamarin.Forms;
using Fooder.Interfaces.DependencyService;
using Fooder.Data;
using Fooder.Model;
using Xamarin.Forms.Xaml;

namespace Fooder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        static ConnectDatabase database;

        public static ConnectDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ConnectDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Fooder.db3"));
                }
                return database;
            }
        }

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
