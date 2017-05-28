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

namespace Fooder.ViewModel
{
    [ImplementPropertyChanged]
    public class AssociacaoProdutosListaPageViewModel
    {
        public ICommand SalvarProdutosLista { get; set; }
        public List<Produto> produtosSelecionados { get; set; }
        public Lista ListaSelecionada { get; set; }
        public ObservableCollection<Lista> ListasGravadas { get; set; }

        public AssociacaoProdutosListaPageViewModel()
        {
            ListasGravadas = new ObservableCollection<Lista>(App.Database.Lista_GetItemsAsync().Result);
            SalvarProdutosLista = new Command(() => PersistirElementosBaseDados());
        }
        private void PersistirElementosBaseDados()
        {
            ProdutosLista prodlist = null;
            prodlist = new ProdutosLista();

            foreach (Produto item in produtosSelecionados)
            {
                prodlist.CodigoProduto = item.CodigoProduto;
                prodlist.CodigoLista = ListaSelecionada.CodigoLista;

                App.Database.ProdutoLista_SaveItemAsync(prodlist);
            }
        }
        public void RemoverTodosProdutosSelecionados()
        {
            produtosSelecionados.Clear();
        }
        public void AdicionarProdutoSelecionadoTemporariamente(Produto prod)
        {
            if (produtosSelecionados == null)
                produtosSelecionados = new List<Produto>();

            produtosSelecionados.Add(prod);
        }
    }
}
