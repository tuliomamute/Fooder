using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fooder.WebApi.Models
{
    /// <summary>
    /// Relacionamento entre Produto e Lista
    /// </summary>
    public class ProdutosLista
    {
        /// <summary>
        /// Código do Produto
        /// </summary>
        public int CodigoProduto { get; set; }
        /// <summary>
        /// Código da Lista
        /// </summary>
        public int CodigoLista { get; set; }
        /// <summary>
        /// Quantidade de unidades de um determinado produto
        /// </summary>
        public string QuantidadeProduto { get; set; }
    }
}