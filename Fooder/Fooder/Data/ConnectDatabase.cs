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
            data = new SQLiteAsyncConnection(dbPath);
            data.CreateTableAsync<Lista>().Wait();
        }

        public Task<List<Lista>> GetItemsAsync()
        {
            return data.Table<Lista>().ToListAsync();
        }

        public Task<int> SaveItemAsync(Lista item)
        {
            if (item.CodigoLista != 0)
                return data.UpdateAsync(item);
            else
                return data.InsertAsync(item);
        }
    }
}
