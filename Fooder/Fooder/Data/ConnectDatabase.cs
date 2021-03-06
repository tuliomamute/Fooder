﻿using System;
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
    /// <summary>
    /// classe responsável por fazer a conexão com o SQLITE
    /// </summary>
    public class ConnectDatabase
    {
        readonly SQLiteAsyncConnection data;

        /// <summary>
        /// Criação da conexão e das tabelas
        /// </summary>
        /// <param name="dbPath"></param>
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

        public Task<int> Lista_DeleteItemAsync(Lista item)
        {
            return data.DeleteAsync(item);
        }
        #endregion

        #region Metodos Classe Produto
        public Task<List<Produto>> Produto_GetItemsAsync()
        {
            return data.Table<Produto>().ToListAsync();
        }

        public Task<int> Produto_SaveItemAsync(Produto item)
        {
            if (item.PRODUTO_ID != 0)
                return data.UpdateAsync(item);
            else
                return data.InsertAsync(item);
        }

        #endregion

        #region Metodos Classe ProdutoLista
        public Task<List<ProdutosLista>> ProdutoLista_GetItemsAsync(int CodigoLista)
        {
            List<ProdutosLista> abc = data.Table<ProdutosLista>().Where(x => x.CodigoLista == CodigoLista).ToListAsync().Result;
            return data.Table<ProdutosLista>().Where(x => x.CodigoLista == CodigoLista).ToListAsync();
        }

        public async Task<int> ProdutoLista_SaveItemAsync(ProdutosLista item)
        {
            try
            {
                if (data.Table<ProdutosLista>().Where(x => x.CodigoLista == item.CodigoLista && x.CodigoProduto == item.CodigoProduto).CountAsync().Result == 0)
                    return await data.InsertAsync(item);
                else
                    return await data.UpdateAsync(item);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<int> ProdutoLista_DeleteItemsAsync(ProdutosLista CodigoLista)
        {
            return await data.DeleteAsync(CodigoLista);
        }

        public async void ProdutoLista_BasedOnCode(int CodigoProduto, int CodigoLista)
        {
            ProdutosLista prod = data.Table<ProdutosLista>().Where(x => x.CodigoLista == CodigoLista && x.CodigoProduto == CodigoProduto).FirstOrDefaultAsync().Result;

            if (prod != null)
                await data.DeleteAsync(prod);
        }
        #endregion

    }
}
