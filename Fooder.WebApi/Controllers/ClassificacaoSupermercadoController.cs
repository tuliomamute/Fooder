using Fooder.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        /// <param name="ListaProdutos"></param>
        /// <returns></returns>
        public IHttpActionResult Get([FromBody]ProdutosLista[] ListaProdutos)
        {

            int[] CodigoProdutos = ListaProdutos.Select(x => x.CodigoProduto).Distinct().ToArray();

            List<ESTOQUE> elementos_estoque = db.ESTOQUE.Where(x => CodigoProdutos.Contains(x.PRODUTO_ID)).ToList();
            int[] Mercados = db.ESTOQUE.Select(x => x.MERCADO_ID).Distinct().ToArray();
            List<MERCADOS> mercados_detalhes = db.MERCADOS.ToList();

            foreach (int itemMercado in Mercados)
            {
                elementos_estoque
                    .Where(x => x.MERCADO_ID == itemMercado)
                    .Join(ListaProdutos, a => a.PRODUTO_ID, b => b.CodigoProduto, (a, b) => new { SomaProduto = a.PRECO * b.QuantidadeProduto, Produto = a.PRODUTO_ID, Mercado = a.MERCADO_ID })
                    .Sum(x => x.SomaProduto);
            }

            return null;
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