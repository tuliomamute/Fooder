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
    public partial class ExibicaoSupermercadosClassificacaoPage : ContentPage
    {
        public ExibicaoSupermercadosClassificacaoPage()
        {
            try
            {
                InitializeComponent();
                BindingContext = new ExibicaoSupermercadosClassificacaoViewModel(this.Navigation);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void LstClassificacaoSupermercados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ClassificacaoMercados item = e.SelectedItem as ClassificacaoMercados;

            if (item != null)
                Device.OpenUri(new Uri(item.UrlMapa));
        }
    }


}
