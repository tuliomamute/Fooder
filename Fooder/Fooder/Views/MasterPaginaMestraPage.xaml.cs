using Fooder.UtilityClass;
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
            menu.ListPaginas.ItemSelected += OnItemSelected;
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                menu.ListPaginas.SelectedItem = null;
                IsPresented = false;
            }
        }
    }

}
