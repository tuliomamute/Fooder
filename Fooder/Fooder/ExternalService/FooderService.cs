using Fooder.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Fooder.ExternalService
{
    public static class FooderService
    {
        /// <summary>
        /// Metodo responsável por realizar a requisição na WEBAPI para retorno das classificações dos supermercados
        /// </summary>
        /// <param name="ListaProdutos">Lista de produtos com as quantidades</param>
        /// <returns></returns>
        public static async Task<ObservableCollection<ClassificacaoMercados>> RetornaClassificacoes(List<ProdutosLista> ListaProdutos)
        {
            ObservableCollection<ClassificacaoMercados> model = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalClasses.GlobalProperties.UrlApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var stringContent = new StringContent(JsonConvert.SerializeObject(ListaProdutos), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"/api/ClassificacaoSupermercado/", stringContent);

                    if (response.IsSuccessStatusCode)
                        model = JsonConvert.DeserializeObject<ObservableCollection<ClassificacaoMercados>>(await response.Content.ReadAsStringAsync());

                    return model;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Métodos responsável por fazer a requisição na WEBAPI, para retorno dos produtos
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<Produto>> RetornaProdutos()
        {
            ObservableCollection<Produto> model = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalClasses.GlobalProperties.UrlApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync($"/api/Produtos?quantidade={"0"}");

                    if (response.IsSuccessStatusCode)
                        model = JsonConvert.DeserializeObject<ObservableCollection<Produto>>(await response.Content.ReadAsStringAsync());

                    return model;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
