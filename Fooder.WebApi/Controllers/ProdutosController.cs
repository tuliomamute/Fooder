﻿using Fooder.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Fooder.WebApi.Controllers
{
    /// <summary>
    /// Controle de Produtos
    /// </summary>
    public class ProdutosController : ApiController
    {
        private FooderModel db = new FooderModel();

        /// <summary>
        /// Retorno dos Produtos Cadastrados na Base de Dados
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(List<PRODUTOS>))]
        [HttpGet]
        public IHttpActionResult Get(string quantidade)
        {
            try
            {
                return Ok(RetornarProdutos());
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        private List<PRODUTOS> RetornarProdutos()
        {
            return db.PRODUTOS.OrderBy(x => x.NOME).ToList();
        }

    }
}
