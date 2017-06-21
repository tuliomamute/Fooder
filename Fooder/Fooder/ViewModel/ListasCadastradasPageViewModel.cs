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
        public ICommand ExcluirLista { get; set; }

        public ListasCadastradasPageViewModel()
        {
            ExcluirLista = new Command<Lista>((lista) => ExcluirListaBaseDados(lista));
            GetRefreshedHistory = new Command(() => BuscaListaDatabase());
        }
        public async void BuscaListaDatabase()
        {
            ListaObjetos = new ObservableCollection<Lista>(await App.Database.Lista_GetItemsAsync());
        }

        //Exclusão da lista e de seus dependentes da base de dados
        private async void ExcluirListaBaseDados(Lista ListaSelecionada)
        {
            //Emissão da mensagem de confirmação
            if (await GlobalClasses.DisplayMessage.DisplayQuestionAlert("Confirmação", $"Deseja excluir a lista '{ListaSelecionada.NomeLista}' e seus produtos associados?", "Sim", "Não"))
            {
                foreach (ProdutosLista item in await App.Database.ProdutoLista_GetItemsAsync(ListaSelecionada.CodigoLista))
                {
                    await App.Database.ProdutoLista_DeleteItemsAsync(item);
                }

                await App.Database.Lista_DeleteItemAsync(ListaSelecionada);

                BuscaListaDatabase();
            }
        }

    }

}
