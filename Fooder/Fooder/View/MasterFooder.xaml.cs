﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fooder.View.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterFooder : MasterDetailPage
    {
        MasterFooderMaster master;
        public MasterFooder()
        {
            InitializeComponent();
            master.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterFooderMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            Detail = new NavigationPage(page);
            master.ListView.SelectedItem = null;
            IsPresented = false;

        }
    }

}
