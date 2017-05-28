using Fooder.ViewModel;
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
    public partial class CriarListaPage : ContentPage
    {
        public CriarListaPage()
        {
            InitializeComponent();
            BindingContext = new CriarListaPageViewModel(Navigation);
        }
    }

}
