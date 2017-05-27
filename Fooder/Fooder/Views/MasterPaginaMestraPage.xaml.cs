using System;
using System.Collections.Generic;
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
    public partial class MasterPaginaMestraPage : MasterDetailPage
    {
        MenuLateralPage menu;
        public MasterPaginaMestraPage()
        {
            menu = new MenuLateralPage();
            Master = menu;
            Detail = new NavigationPage(new DadosIniciaisPage());
        }
    }
}
