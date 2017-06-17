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
using Fooder.GlobalClasses;

namespace Fooder.ViewModel
{
    [ImplementPropertyChanged]
    public class AssociacaoProdutosListaPageViewModel
    {
        public ICommand RecuperarQuantidade { get; set; }
        public ICommand SalvarProdutosLista { get; set; }
        public Lista ListaSelecionada { get; set; }
        public ObservableCollection<ProdutoQuantidade> ListaProdutos { get; set; }
        public AssociacaoProdutosListaPageViewModel(Lista aLista)
        {
            try
            {
                ListaSelecionada = aLista;

                RecuperarListaBancoLocal();
                BuscaProdutos();

                SalvarProdutosLista = new Command(() => PersistirElementosBaseDadosAsync());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async void BuscaProdutos()
        {
            var serializedParent = JsonConvert.SerializeObject(await ExternalService.FooderService.RetornaProdutos());
            ListaProdutos = JsonConvert.DeserializeObject<ObservableCollection<ProdutoQuantidade>>(serializedParent);

        }

        private void RecuperarListaBancoLocal()
        {
            var retorno = App.Database.ProdutoLista_GetItemsAsync(ListaSelecionada.CodigoLista).Result;

            //Preenchimento da lista de produtos para ser escrita na tela
            foreach (var item in retorno)
                ListaProdutos.Where(x => x.PRODUTO_ID == item.CodigoProduto).FirstOrDefault().QuantidadeProduto = item.QuantidadeProduto;

        }

        private async void PersistirElementosBaseDadosAsync()
        {
            ProdutosLista prodlist = null;
            prodlist = new ProdutosLista();

            //Salvando Lista, caso tenha alterado algo
            await App.Database.Lista_SaveItemAsync(ListaSelecionada);

            //Percorrendo Lista de Produtos
            foreach (ProdutoQuantidade item in ListaProdutos.Where(x => x.QuantidadeProduto > 0))
            {
                prodlist.CodigoProduto = item.PRODUTO_ID;
                prodlist.CodigoLista = ListaSelecionada.CodigoLista;
                prodlist.QuantidadeProduto = item.QuantidadeProduto;

                await App.Database.ProdutoLista_SaveItemAsync(prodlist);
            }

            DisplayMessage.DisplayMessageAlert("Confirmação", "Produtos Incluidos na Lista com Sucesso!");
        }
    }
}
