using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooder.UtilityClass
{
    /// <summary>
    /// Classe para criação dos itens de menu lateral
    /// </summary>
    public class MasterPageItem
    {
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Detalhes { get; set; }
        public Type TargetType { get; set; }
    }
}
