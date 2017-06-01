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
        public IHttpActionResult Get(ProdutosLista[] ListaProdutos)
        {
            return Ok(ProcessaSupermercados(ListaProdutos));
        }

        /// <summary>
        /// Método que realiza processamento das listas.
        /// </summary>
        /// <param name="ListaProdutos"></param>
        /// <returns></returns>
        private List<ClassificacaoMercados> ProcessaSupermercados(ProdutosLista[] ListaProdutos)
        {
            List<MERCADOS> SuperMercados = db.MERCADOS.ToList();
            List<ESTOQUE> Estoque = null;
            List<DetalhesProdutos> ListaDetails = null;
            ProdutosLista itemProdutoLista = null;
            List<ClassificacaoMercados> ClassificacaoMercado = null;

            ClassificacaoMercado = new List<ClassificacaoMercados>();

            foreach (MERCADOS item in SuperMercados)
            {
                ListaDetails = new List<DetalhesProdutos>();

                //Busca os estoques de um supermercado
                Estoque = db.ESTOQUE.Where(x => x.MERCADO_ID == item.MERCADO_ID).ToList();

                //Interações nos produtos encontrados para um supermercado
                foreach (ESTOQUE itemEstoque in Estoque)
                {
                    itemProdutoLista = ListaProdutos.Where(x => x.CodigoProduto == itemEstoque.PRODUTO_ID).FirstOrDefault();

                    //Se algum produto escolhido no aplicativo estiver na lista, calcula-se o valor, caso o contrário, ele assume o valor 0.
                    //Refazer trecho, para quando não for encontrado, adicionar com valor zerado

                    //if (itemProdutoLista != null)
                    //    ListaDetails.Add(new DetalhesProdutos()
                    //    {
                    //        SomaProduto = itemProdutoLista.QuantidadeProduto * itemEstoque.PRECO,
                    //        ProdutoId = itemEstoque.PRODUTO_ID,
                    //        NomeProduto = db.PRODUTOS.Where(x => x.PRODUTO_ID == itemEstoque.PRODUTO_ID).FirstOrDefault().NOME
                    //    });
                    //else
                    //    
                    //    ListaDetails.Add(new DetalhesProdutos()
                    //    {
                    //        SomaProduto = 0,
                    //        ProdutoId = itemEstoque.PRODUTO_ID,
                    //        NomeProduto = db.PRODUTOS.Where(x => x.PRODUTO_ID == itemEstoque.PRODUTO_ID).FirstOrDefault().NOME
                    //    });
                }

                //Criação do Objeto de Supermercado
                ClassificacaoMercado.Add(new ClassificacaoMercados()
                {
                    DetalhesProdutos = ListaDetails,
                    NomeSupermercado = item.NOME,
                    UrlMapa = item.URL_MAPA,
                    PrecoTotal = ListaDetails.Sum(x => x.SomaProduto),
                    ListaCompleta = ListaDetails.Count == Estoque.Count
                });
            }

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
