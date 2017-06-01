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

            int[] CodigoProdutos = ListaProdutos.Select(x => x.CodigoProduto).Distinct().ToArray();

            List<ESTOQUE> elementos_estoque = db.ESTOQUE.Where(x => CodigoProdutos.Contains(x.PRODUTO_ID)).ToList();
            int[] Mercados = db.ESTOQUE.Select(x => x.MERCADO_ID).Distinct().ToArray();
            List<MERCADOS> mercados_detalhes = db.MERCADOS.ToList();
            List<ClassificacaoMercados> Classificacao = new List<ClassificacaoMercados>();
            foreach (int itemMercado in Mercados)
            {
                Classificacao.Add(elementos_estoque.Where(x => x.MERCADO_ID == itemMercado)
                                   .Join(ListaProdutos, a => a.PRODUTO_ID, b => b.CodigoProduto, (a, b) => new { SomaProduto = a.PRECO * b.QuantidadeProduto, Produto = a.PRODUTO_ID, Mercado = a.MERCADO_ID })
                                   .GroupBy(a => a.Mercado)
                                   .Select(x => new { CodigoMercado = x.FirstOrDefault().Mercado, SomaProdutos = x.Sum(y => y.SomaProduto) })
                                   .Join(mercados_detalhes, a => a.CodigoMercado, b => b.MERCADO_ID, (a, b) => new ClassificacaoMercados { NomeSupermercado = b.NOME, PrecoTotal = a.SomaProdutos, UrlMapa = b.URL_MAPA }).FirstOrDefault());

            }

            return Ok(Classificacao);
        }
    }
}

//{
//	"ListaProdutos": [{
//		"CodigoProduto": 0,
//		"CodigoLista": 0,
//		"QuantidadeProduto": 0
//	}, {
//		"CodigoProduto": 1,
//		"CodigoLista": 0,
//		"QuantidadeProduto": 3
//	}]
//}