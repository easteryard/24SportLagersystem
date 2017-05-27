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
    class ProductLinePersistencyService
    {
        public static async void SaveProductLinesAsAsync(ProductLine productLine)
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
                    var response = client.PostAsJsonAsync("api/ProductLines", productLine).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var returnProductLine = response.Content.ReadAsAsync<ProductLine>();
                        productLine.ProductLineId = returnProductLine.Result.ProductLineId;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static async Task<List<ProductLine>> LoadProductLinesFromJsonAsync()
        {
            const string ServerUrl = "http://localhost:41731";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //
                try
                {
                    // Run the controller associated with ProductLine in the webservice
                    var response = client.GetAsync("api/ProductLines").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var productLineData = response.Content.ReadAsAsync<IEnumerable<ProductLine>>().Result;
                        return productLineData.ToList();
                    }
                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static async void EditProductLineAsync(ProductLine productLine)
        {
            const string SERVER_URL = "http://localhost:41731";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(SERVER_URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("ApplicationData/JsonConvert"));

                try
                {
                    var response = client.PutAsJsonAsync("api/ProductLines/" + productLine.ProductLineId, productLine).Result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static async void DeleteProductLineAsync(ProductLine productLine)
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
                    await client.DeleteAsync("api/ProductLines/" + productLine.ProductLineId);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
