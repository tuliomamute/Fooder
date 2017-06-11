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
            CriarProdutos();

            MainPage = new MasterPaginaMestraPage();
        }

        private void CriarProdutos()
        {
            if (Database.Produto_GetItemsAsync().Result.Count == 0)
            {

                Produto prod = new Produto();
                prod.NomeProduto = "Produto 1";

                Database.Produto_SaveItemAsync(prod);

                prod = new Produto();
                prod.NomeProduto = "Produto 2";

                Database.Produto_SaveItemAsync(prod);

                prod = new Produto();
                prod.NomeProduto = "Produto 3";

                Database.Produto_SaveItemAsync(prod);


                prod = new Produto();
                prod.NomeProduto = "Produto 4";

                Database.Produto_SaveItemAsync(prod);
            }
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
