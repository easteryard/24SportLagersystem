using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using _24SportLagersystem.Model;

namespace _24SportLagersystem.Persistency
{
    class PersistencyService
    {
        public static async Task<List<Product>> LoadProductFromJsonAsync()
        {
            const string ServerUrl = "http://localhost:41731";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var responce = client.GetAsync("api/Products").Result;
                    if (responce.IsSuccessStatusCode)
                    {
                        var productsdata = responce.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                        return productsdata.ToList();
                    }
                    return null;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
