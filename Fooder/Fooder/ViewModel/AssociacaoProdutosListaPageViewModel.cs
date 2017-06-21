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
        public INavigation Navigation { get; set; }
        public ICommand RecuperarQuantidade { get; set; }
        public ICommand SalvarProdutosLista { get; set; }
        public Lista ListaSelecionada { get; set; }
        public ObservableCollection<ProdutoQuantidade> ListaProdutos { get; set; }
        public bool Carregando { get; set; }

        private ObservableCollection<ProdutoQuantidade> BackupListaProdutos { get; set; }

        public AssociacaoProdutosListaPageViewModel(Lista aLista, INavigation nav)
        {
            try
            {
                Carregando = true;

                ListaSelecionada = aLista;

                BuscaProdutos();

                SalvarProdutosLista = new Command(() => PersistirElementosBaseDadosAsync());
                Navigation = nav;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Filtra a lista de produtos, baseado no que foi escrito no campo de searchbar
        /// </summary>
        /// <param name="texto"></param>
        public void FiltrarElementosLista(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                ListaProdutos = BackupListaProdutos;
                return;
            }

            //Realiza a busca na lista de backup, para setar na lista bindada
            ListaProdutos = new ObservableCollection<ProdutoQuantidade>(BackupListaProdutos.Where(x => x.NOME.ToLower().Contains(texto.ToLower())).ToList());

        }

        /// <summary>
        /// Carrega a lista de todos os produtos (a partir da WEBAPI)
        /// </summary>
        private async void BuscaProdutos()
        {
            var serializedParent = JsonConvert.SerializeObject(await ExternalService.FooderService.RetornaProdutos());
            ListaProdutos = JsonConvert.DeserializeObject<ObservableCollection<ProdutoQuantidade>>(serializedParent);

            BackupListaProdutos = ListaProdutos;

            if (ListaProdutos.Count > 0)
            {
                RecuperarListaBancoLocal();
                Carregando = false;
            }

        }

        //Recupepera os produtos e suas quantidades do banco SQLITE
        private void RecuperarListaBancoLocal()
        {
            var retorno = App.Database.ProdutoLista_GetItemsAsync(ListaSelecionada.CodigoLista).Result;

            while (ListaProdutos == null)
                continue;

            //Preenchimento da lista de produtos para ser escrita na tela
            foreach (var item in retorno)
            {
                ListaProdutos.Where(x => x.PRODUTO_ID == item.CodigoProduto).FirstOrDefault().QuantidadeProduto = item.QuantidadeProduto;
            }
            ListaProdutos = new ObservableCollection<ProdutoQuantidade>(ListaProdutos.OrderByDescending(x => x.QuantidadeProduto).ToList());
        }

        //Salva alterações na quantidade de produtos e no nome da lista na base de dados
        private async void PersistirElementosBaseDadosAsync()
        {
            ProdutosLista prodlist = null;
            prodlist = new ProdutosLista();

            //Salvando Lista, caso tenha alterado algo
            await App.Database.Lista_SaveItemAsync(ListaSelecionada);
            
            //Percorrendo Lista de Produtos
            foreach (ProdutoQuantidade item in ListaProdutos.Where(x => !string.IsNullOrEmpty(x.QuantidadeProduto)))
            {
                prodlist.CodigoProduto = item.PRODUTO_ID;
                prodlist.CodigoLista = ListaSelecionada.CodigoLista;
                prodlist.QuantidadeProduto = item.QuantidadeProduto;

                await App.Database.ProdutoLista_SaveItemAsync(prodlist);
            }

            //Exclusão de registro no relacionamento, caso o valor seja zerado
            foreach (ProdutoQuantidade item in ListaProdutos.Where(x => string.IsNullOrEmpty(x.QuantidadeProduto)))
                App.Database.ProdutoLista_BasedOnCode(item.PRODUTO_ID, ListaSelecionada.CodigoLista);

            DisplayMessage.DisplayMessageAlert("Confirmação", "Produtos Incluidos na Lista com Sucesso!");

            //retorno para a tela de listas
            await Navigation.PopAsync();
        }
    }
}
