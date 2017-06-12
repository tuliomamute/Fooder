using Fooder.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooder.ViewModel
{
    public class DetalhesProdutosViewModel
    {
        public ObservableCollection<DetalhesProdutos> ProdutosEncontrados { get; set; }
        public ObservableCollection<DetalhesProdutos> ProdutosNaoEncontrados { get; set; }
        public ClassificacaoMercados mercado;
        public bool VisivelEncontrados { get; set; }
        public bool VisivelNaoEncontrados { get; set; }

        public DetalhesProdutosViewModel(ClassificacaoMercados mercados)
        {
            mercado = mercados;
            ProdutosNaoEncontrados = new ObservableCollection<DetalhesProdutos>(mercados.DetalhesProdutos.Where(x => x.SomaProduto == 0).ToList());
            ProdutosEncontrados = new ObservableCollection<DetalhesProdutos>(mercados.DetalhesProdutos.Where(x => x.SomaProduto != 0).ToList());

            VisivelEncontrados = ProdutosEncontrados.Count > 0;
            VisivelNaoEncontrados = ProdutosNaoEncontrados.Count > 0;

        }
    }
}
