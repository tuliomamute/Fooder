using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooder.Model
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
        /// <summary>
        /// Indica se todos os produtos tiveram preços encontrados
        /// </summary>
        public bool ListaCompleta { get; set; }
        /// <summary>
        /// Lista dos produtos de um mercado
        /// </summary>
        public List<DetalhesProdutos> DetalhesProdutos { get; set; }
        /// <summary>
        /// Quantidade de itens encontrados a partir da lista de produtos informados
        /// </summary>
        public int QuantidadeItensEncontrados { get; set; }
    }
    /// <summary>
    /// Detalhes dos produtos de um determinado supermercado
    /// </summary>
    public class DetalhesProdutos
    {
        /// <summary>
        /// Multiplicação da Quantidade do Produto pelo preço
        /// </summary>
        public decimal? SomaProduto { get; set; }
        /// <summary>
        /// Código do Produto
        /// </summary>
        public int ProdutoId { get; set; }
        /// <summary>
        /// Nome do Produto
        /// </summary>
        public string NomeProduto { get; set; }

    }
}
