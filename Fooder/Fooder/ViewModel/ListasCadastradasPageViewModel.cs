using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using Fooder.Model;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Fooder.ViewModel
{
    [ImplementPropertyChanged]
    public class ListasCadastradasPageViewModel
    {
        public ObservableCollection<Lista> ListaObjetos { get; set; }
        public ICommand GetRefreshedHistory { get; set; }
        public ListasCadastradasPageViewModel()
        {
            GetRefreshedHistory = new Command(() => BuscaListaDatabase());
        }
        public async void BuscaListaDatabase()
        {
            ListaObjetos = new ObservableCollection<Lista>(await App.Database.Lista_GetItemsAsync());
        }
    }

}
