using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.Collections.ObjectModel;
using Fooder.Model;
using System.Windows.Input;
using Xamarin.Forms;
using Fooder.ExternalService;
using Fooder.Views;

namespace Fooder.ViewModel
{
    [ImplementPropertyChanged]
    public class ExibicaoSupermercadosClassificacaoViewModel
    {
        public ObservableCollection<ClassificacaoMercados> ListaClassificacaoSupermercados { get; set; }
        public ObservableCollection<Lista> LstMercados { get; set; }
        public ICommand BuscarElementos { get; set; }
        public ICommand RedirecionarMapa { get; private set; }
        public INavigation Navigation { get; set; }
        public Lista ListaSelecionada { get; set; }
        public bool Carregando { get; set; }
        public ExibicaoSupermercadosClassificacaoViewModel(INavigation nav)
        {
            try
            {
                Navigation = nav;
                BuscarElementos = new Command(() => BuscarClassificacao());
                RedirecionarMapa = new Command<ClassificacaoMercados>(key => TelaDetalhesProduto(key));

                LstMercados = new ObservableCollection<Lista>(App.Database.Lista_GetItemsAsync().Result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //Busca dos dados da WEBAPI retornando a classificação dos supermercados
        private async void BuscarClassificacao()
        {
            try
            {
                Carregando = true;

                ListaClassificacaoSupermercados = await FooderService.RetornaClassificacoes(await App.Database.ProdutoLista_GetItemsAsync(ListaSelecionada.CodigoLista));

                if (ListaClassificacaoSupermercados.Count > 0)
                    Carregando = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Redireciona para a tela de detalhes dos produtos
        private void TelaDetalhesProduto(ClassificacaoMercados mercados)
        {
            try
            {
                Navigation.PushAsync(new DetalhesProdutosPage(mercados));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
