using Fooder.UtilityClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fooder.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuLateralPage : ContentPage
    {
        public ListView ListPaginas { get { return lstPaginas; } }

        public MenuLateralPage()
        {
            InitializeComponent();

            List<MasterPageItem> masterPageItem = null;

            masterPageItem = new List<MasterPageItem>();
            masterPageItem.Add(new MasterPageItem
            {
                Titulo = "Listas Inclusas",
                Imagem = "icon.png",
                Detalhes = "Gerencie suas listas",
                TargetType = typeof(ListasCadastradasPage)
            });

            //masterPageItem.Add(new MasterPageItem
            //{
            //    Titulo = "Menor Preço",
            //    Imagem = "icon.png",
            //    Detalhes = "Encontre o Supermercado com Menor Preço",
            //    TargetType = typeof(ListasCadastradasPage)
            //});

            lstPaginas.ItemsSource = masterPageItem;
        }

    }

}
