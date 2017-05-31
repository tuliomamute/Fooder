using Fooder.WebApi.Models;
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
        public IHttpActionResult Get(ProdutosLista ListaProdutos)
        {
            return null;
        }
    }
}
