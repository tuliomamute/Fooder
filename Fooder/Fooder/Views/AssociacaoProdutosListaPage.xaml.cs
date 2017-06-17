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
    public partial class AssociacaoProdutosListaPage : ContentPage
    {
        public AssociacaoProdutosListaPage(Lista aLista)
        {
            InitializeComponent();
            BindingContext = new AssociacaoProdutosListaPageViewModel(aLista);
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((AssociacaoProdutosListaPageViewModel)BindingContext).FiltrarElementosLista(TxtSearch.Text);
        }
    }

}
