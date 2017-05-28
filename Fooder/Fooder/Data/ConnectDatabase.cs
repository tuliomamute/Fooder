using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fooder.Model;
using Xamarin.Forms;
using Fooder.Interfaces.DependencyService;
using SQLite;
using System.Collections.ObjectModel;

namespace Fooder.Data
{
    public class ConnectDatabase
    {
        readonly SQLiteAsyncConnection data;

        public ConnectDatabase(string dbPath)
        {

            try
            {
                data = new SQLiteAsyncConnection(dbPath);
                data.CreateTableAsync<Lista>().Wait();
                data.CreateTableAsync<Produto>().Wait();
                data.CreateTableAsync<ProdutosLista>().Wait();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #region Metodos Classe Lista
        public Task<List<Lista>> Lista_GetItemsAsync()
        {
            return data.Table<Lista>().ToListAsync();
        }

        public Task<int> Lista_SaveItemAsync(Lista item)
        {
            if (item.CodigoLista != 0)
                return data.UpdateAsync(item);
            else
                return data.InsertAsync(item);
        }
        #endregion

        #region Metodos Classe Produto
        public Task<List<Produto>> Produto_GetItemsAsync()
        {
            return data.Table<Produto>().ToListAsync();
        }

        public Task<int> Produto_SaveItemAsync(Produto item)
        {
            if (item.CodigoProduto != 0)
                return data.UpdateAsync(item);
            else
                return data.InsertAsync(item);
        }

        #endregion

        #region Metodos Classe ProdutoLista
        public Task<List<ProdutosLista>> ProdutoLista_GetItemsAsync()
        {
            return data.Table<ProdutosLista>().ToListAsync();
        }

        public Task<int> ProdutoLista_SaveItemAsync(ProdutosLista item)
        {
            if (item.CodigoLista != 0)
                return data.UpdateAsync(item);
            else
                return data.InsertAsync(item);
            #endregion
        }
    }
}
