using Fooder.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Fooder.WebApi.Controllers
{
    /// <summary>
    /// Controle da classificação dos produtos
    /// </summary>
    public class ClassificacaoSupermercadoController : ApiController
    {
        private FooderModel db = new FooderModel();
        /// <summary>
        /// Retorno da lista de classificação baseado no preço
        /// </summary>
        /// <param name="ListaProdutos">Lista dos Produtos</param>
        /// <returns></returns>
        [ResponseType(typeof(List<ClassificacaoMercados>))]
        [HttpPost]
        public IHttpActionResult Post(List<ProdutosLista> ListaProdutos)
        {
            try
            {
                return Ok(ProcessaSupermercados(ListaProdutos));
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Método que realiza processamento das listas.
        /// </summary>
        /// <param name="ListaProdutos"></param>
        /// <returns>Lista de Classificação dos preços do supermercados cadastrados</returns>
        private List<ClassificacaoMercados> ProcessaSupermercados(List<ProdutosLista> ListaProdutos)
        {
            List<MERCADOS> SuperMercados = db.MERCADOS.ToList();
            List<ESTOQUE> Estoque = null;
            List<DetalhesProdutos> ListaDetails = null;
            ESTOQUE itemEstoque = null;
            List<ClassificacaoMercados> ClassificacaoMercado = null;
            int QuantidadeItensEncontrados = 0;

            ClassificacaoMercado = new List<ClassificacaoMercados>();

            foreach (MERCADOS item in SuperMercados)
            {
                //Zerando Variavel de controle de quantidade de itens encontrados na base, por supermercado
                QuantidadeItensEncontrados = 0;

                ListaDetails = new List<DetalhesProdutos>();

                //Busca os estoques de um supermercado
                Estoque = db.ESTOQUE.Where(x => x.MERCADO_ID == item.MERCADO_ID).ToList();

                //Interações nos produtos da lista feita através do app

                foreach (ProdutosLista itemLista in ListaProdutos)
                {
                    itemEstoque = null;

                    itemEstoque = Estoque.Where(x => x.PRODUTO_ID == itemLista.CodigoProduto).FirstOrDefault();

                    //Se algum produto escolhido no aplicativo estiver na lista, calcula-se o valor, caso o contrário, ele assume o valor 0.
                    //Refazer trecho, para quando não for encontrado, adicionar com valor zerado

                    if (itemEstoque != null)
                    {
                        QuantidadeItensEncontrados++;
                        ListaDetails.Add(new DetalhesProdutos()
                        {
                            SomaProduto = itemLista.QuantidadeProduto * itemEstoque.PRECO,
                            ProdutoId = itemLista.CodigoProduto,
                            NomeProduto = itemEstoque.PRODUTOS.NOME
                        });
                    }
                    else
                    {
                        ListaDetails.Add(new DetalhesProdutos()
                        {
                            SomaProduto = 0,
                            ProdutoId = itemLista.CodigoProduto,
                            NomeProduto = db.PRODUTOS.Where(x => x.PRODUTO_ID == itemLista.CodigoProduto).FirstOrDefault().NOME
                        });
                    }
                }

                //Ordenação dos menores para os maiores preços
                ListaDetails = ListaDetails.OrderBy(x => x.SomaProduto).ToList();

                //Criação do Objeto de Supermercado
                ClassificacaoMercado.Add(new ClassificacaoMercados()
                {
                    DetalhesProdutos = ListaDetails,
                    NomeSupermercado = item.NOME,
                    UrlMapa = item.URL_MAPA,
                    PrecoTotal = ListaDetails.Sum(x => x.SomaProduto),
                    ListaCompleta = ListaDetails.Count == Estoque.Count,
                    QuantidadeItensEncontrados = QuantidadeItensEncontrados
                });
            }

            //Ordenação baseado se alguma lista foi encontrada completa e depois pela quantidade de itens encontrados
            ClassificacaoMercado = ClassificacaoMercado.OrderByDescending(x => x.ListaCompleta).OrderByDescending(x => x.QuantidadeItensEncontrados).ToList();

            return ClassificacaoMercado;
        }

    }
}

//[{
//	"CodigoProduto": 0,
//	"CodigoLista": 0,
//	"QuantidadeProduto": 2
//}, {
//	"CodigoProduto": 1,
//	"CodigoLista": 0,
//	"QuantidadeProduto": 3
//}, {
//	"CodigoProduto": 2,
//	"CodigoLista": 0,
//	"QuantidadeProduto": 4
//}, {
//	"CodigoProduto": 3,
//	"CodigoLista": 0,
//	"QuantidadeProduto": 5
//}
//]
