using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooder.Model
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
    }
    public class ProdutoQuantidade : Produto
    {
        public int QuantidadeProduto { get; set; }
    }

}
