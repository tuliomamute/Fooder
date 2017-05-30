using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Fooder.Model
{

    public class ProdutosLista
    {
        [Indexed(Name = "CodigoProduto", Order = 1, Unique = true)]
        public int CodigoProduto { get; set; }

        [Indexed(Name = "CodigoProduto", Order = 2, Unique = true)]
        public int CodigoLista { get; set; }

        public int QuantidadeProduto { get; set; }
    }
}
