using Fooder.Model;
using Fooder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fooder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesProdutosPage : ContentPage
    {
        public DetalhesProdutosPage(ClassificacaoMercados mercado)
        {
            BindingContext = new DetalhesProdutosViewModel(mercado);
            InitializeComponent();
        }
    }
}
