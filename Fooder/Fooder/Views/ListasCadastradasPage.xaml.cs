using Fooder.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fooder.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListasCadastradasPage : ContentPage
    {
        public ListasCadastradasPage()
        {
            InitializeComponent();
            BindingContext = new ListasCadastradasPageViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext != null)
            {
                ((ListasCadastradasPageViewModel)BindingContext).BuscaListaDatabase();
            }
            // Reset the 'resume' id, since we just want to re-start here
            //LstListasCadastradas.ItemsSource = await App.Database.GetItemsAsync();
        }
        public void OnItemAdded(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CriarListaPage());
        }
    }

}
