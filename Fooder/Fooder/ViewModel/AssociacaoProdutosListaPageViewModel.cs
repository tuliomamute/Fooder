using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.Windows.Input;
using Xamarin.Forms;
using Fooder.Model;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Fooder.ViewModel
{
    [ImplementPropertyChanged]
    public class AssociacaoProdutosListaPageViewModel
    {
        public ICommand SalvarProdutosLista { get; set; }
        public Lista ListaSelecionada { get; set; }
        public ObservableCollection<ProdutoQuantidade> ListaProdutos { get; set; }
        public AssociacaoProdutosListaPageViewModel(Lista aLista)
        {
            try
            {
                ListaSelecionada = aLista;

                var serializedParent = JsonConvert.SerializeObject(App.Database.Produto_GetItemsAsync().Result);
                ListaProdutos = JsonConvert.DeserializeObject<ObservableCollection<ProdutoQuantidade>>(serializedParent);

                SalvarProdutosLista = new Command(() => PersistirElementosBaseDados());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void PersistirElementosBaseDados()
        {
            ProdutosLista prodlist = null;
            prodlist = new ProdutosLista();

            //Salvando Lista, caso tenha alterado algo
            App.Database.Lista_SaveItemAsync(ListaSelecionada);

            //Percorrendo Lista de Produtos
            foreach (ProdutoQuantidade item in ListaProdutos.Where(x => x.QuantidadeProduto > 0))
            {
                prodlist.CodigoProduto = item.CodigoProduto;
                prodlist.CodigoLista = ListaSelecionada.CodigoLista;
                prodlist.QuantidadeProduto = item.QuantidadeProduto;

                App.Database.ProdutoLista_SaveItemAsync(prodlist);
            }
        }
    }
}
