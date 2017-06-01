using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fooder.WebApi.Models
{
    /// <summary>
    /// Classe de Retorno
    /// </summary>
    public class ClassificacaoMercados
    {
        /// <summary>
        /// Nome do Supermercado
        /// </summary>
        public string NomeSupermercado { get; set; }
        /// <summary>
        /// Url que contém localização do mapa
        /// </summary>
        public string UrlMapa { get; set; }
        /// <summary>
        /// Soma do valor dos produtos de um supermercado
        /// </summary>
        public decimal? PrecoTotal { get; set; }
    }
}