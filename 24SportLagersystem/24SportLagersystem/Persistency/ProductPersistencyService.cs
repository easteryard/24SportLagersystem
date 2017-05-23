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
    class ProductPersistencyService
    {
        public static async void SaveProductsAsJsonAsync(Product products)
        {
            const string SERVER_URL = "http://localhost:41731";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(SERVER_URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PostAsJsonAsync("api/Products", products).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var returnProduct = response.Content.ReadAsAsync<Product>();
                        products.ProductId = returnProduct.Result.ProductId;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

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

                // i try delen er her vi forventer der kan ske en fejl.
                try
                {
                    // Run the controller associated with Product in the webservice
                    var response = client.GetAsync("api/Products").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var productData = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                        return productData.ToList();
                    }
                    return null;
                }
                // i catch er her vi fanger den opstået fejl og giver en evt fejl meddelse/gemmer fejlen i en logfil
                catch (Exception)
                {
                    throw;
                }
            }
        }


    }
}
