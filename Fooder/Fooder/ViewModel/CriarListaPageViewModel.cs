using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using Fooder.Model;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fooder.ViewModel
{
    [ImplementPropertyChanged]
    public class CriarListaPageViewModel
    {
        public Lista ObjLista { get; set; }
        public ICommand Navigate { get; set; }
        public INavigation Navigation { get; set; }

        public CriarListaPageViewModel(INavigation nav)
        {
            Navigation = nav;
            ObjLista = new Lista();
            Navigate = new Command(() => SalvarListaBaseDados());
        }
        public CriarListaPageViewModel(INavigation nav, Lista listaobjetos)
        {

            Navigation = nav;
            ObjLista = listaobjetos;
            Navigate = new Command(() => SalvarListaBaseDados());

        }
        private async void SalvarListaBaseDados()
        {
            await App.Database.Lista_SaveItemAsync(ObjLista);
            await Navigation.PopAsync();
        }


    }
}
