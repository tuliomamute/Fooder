using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooder.Model
{
    public class Lista
    {
        [PrimaryKey, AutoIncrement]
        public int CodigoLista { get; set; }
        public string NomeLista { get; set; }
    }
}
