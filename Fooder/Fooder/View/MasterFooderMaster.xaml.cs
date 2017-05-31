using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fooder.View.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterFooderMaster : ContentPage
    {
        public ListView ListView => LstMenuItems;
        public MasterFooderMaster()
        {
            InitializeComponent();
            BindingContext = new MasterFooderMasterViewModel();
        }

        class MasterFooderMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterFooderMenuItem> MenuItems { get; }
            public MasterFooderMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterFooderMenuItem>(new[]
                {
                    new MasterFooderMenuItem { Id = 0, Title = "Page 1" },
                    new MasterFooderMenuItem { Id = 1, Title = "Page 2" },
                    new MasterFooderMenuItem { Id = 2, Title = "Page 3" },
                    new MasterFooderMenuItem { Id = 3, Title = "Page 4" },
                    new MasterFooderMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
