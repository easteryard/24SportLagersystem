using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using _24SportLagersystem.Model;

namespace _24SportLagersystem.Persistency
{
    class PersistencyService
    {
        public static async Task<List<Order>> LoadProductFromJsonAsync()
        {
            const string ServerUrl = "http://localhost:41731";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try// i try delen er her vi forventer der kan ske en fejl. 
                {
                    var responce = client.GetAsync("api/Orders").Result;
                    if (responce.IsSuccessStatusCode)
                    {
                        var orderdata = responce.Content.ReadAsAsync<IEnumerable<Order>>().Result;
                        return orderdata.ToList();
                    }
                    return null;
                }
                catch (Exception)// i catch er her vi fanger den opstået fejl og giver en evt fejl meddelse/gemmer fejlen i en logfil
                {

                    throw;
                }
            }
        }


        public static async void SaveOrdersAsJsonAsync(Order orders)
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
                    await client.PostAsJsonAsync("api/orders", orders);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
    }
}
