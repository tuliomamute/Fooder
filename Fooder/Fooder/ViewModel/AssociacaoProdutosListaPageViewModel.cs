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
        public List<ProdutoQuantidade> produtosSelecionados { get; set; }
        public Lista ListaSelecionada { get; set; }
        public ObservableCollection<Lista> ListasGravadas { get; set; }
        public ObservableCollection<ProdutoQuantidade> ListaProdutos { get; set; }
        public AssociacaoProdutosListaPageViewModel()
        {
            try
            {
                ListasGravadas = new ObservableCollection<Lista>(App.Database.Lista_GetItemsAsync().Result);
                //ListaProdutos = new ObservableCollection<ProdutoQuantidade>(App.Database.Produto_GetItemsAsync().Result.Cast<ProdutoQuantidade>());

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

            foreach (ProdutoQuantidade item in produtosSelecionados)
            {
                prodlist.CodigoProduto = item.CodigoProduto;
                prodlist.CodigoLista = ListaSelecionada.CodigoLista;
                prodlist.QuantidadeProduto = item.QuantidadeProduto;

                App.Database.ProdutoLista_SaveItemAsync(prodlist);
            }
        }
        public void RemoverTodosProdutosSelecionados()
        {
            produtosSelecionados.Clear();
        }
        public void AdicionarProdutoSelecionadoTemporariamente(ProdutoQuantidade prod)
        {
            if (produtosSelecionados == null)
                produtosSelecionados = new List<ProdutoQuantidade>();

            produtosSelecionados.Add(prod);
        }
    }
}
