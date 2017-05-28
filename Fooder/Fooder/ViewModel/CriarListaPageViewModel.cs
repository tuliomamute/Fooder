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
        public Lista objLista { get; set; }
        public ICommand Navigate { get; set; }
        public INavigation Navigation { get; set; }
        public CriarListaPageViewModel(INavigation nav)
        {
            Navigation = nav;
            objLista = new Lista();
            Navigate = new Command(() => FindSummoner());
        }

        private async void FindSummoner()
        {
            await App.Database.SaveItemAsync(objLista);
            await Navigation.PopAsync();
        }
    }
}
