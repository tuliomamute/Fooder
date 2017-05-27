using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fooder.Model;
using Xamarin.Forms;
using Fooder.Interfaces.DependencyService;
using SQLite;

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
    }
}
