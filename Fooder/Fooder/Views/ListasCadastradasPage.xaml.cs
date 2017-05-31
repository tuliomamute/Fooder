using Fooder.Model;
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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext != null)
            {
                ((ListasCadastradasPageViewModel)BindingContext).BuscaListaDatabase();
            }
        }
        public void OnItemAdded(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CriarListaPage());
        }
        public void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new AssociacaoProdutosListaPage(e.SelectedItem as Lista));
        }

    }

}
