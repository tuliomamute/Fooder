﻿using Fooder.Model;
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
    public partial class AssociacaoProdutosListaPage : ContentPage
    {
        public AssociacaoProdutosListaPage()
        {
            InitializeComponent();
            BindingContext = new AssociacaoProdutosListaPageViewModel();
        }

        private void LstProdutosCadastrados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((AssociacaoProdutosListaPageViewModel)BindingContext).AdicionarProdutoSelecionadoTemporariamente(e.SelectedItem as ProdutoQuantidade);
        }
        public void OnItemAdded(object sender, EventArgs e)
        {

        }

    }

}
