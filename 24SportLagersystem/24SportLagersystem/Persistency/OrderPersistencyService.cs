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
    class OrderPersistencyService
    {
        public static async void SaveOrdersAsJsonAsync(Order orders)
        {
            const string serverURL = "http://localhost:41731";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    // Run the Post controller associated with Order in the webservice
                    var response = client.PostAsJsonAsync("api/Orders", orders).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var returnOrder = response.Content.ReadAsAsync<Order>();
                        orders.OrderId = returnOrder.Result.OrderId;
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();

                }
            }
        }

        public static async Task<List<Order>> LoadOrderFromJsonAsync()
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
                    // Run the Get controller associated with Order in the webservice
                    var response = client.GetAsync("api/Orders").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var orderData = response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
                        return orderData.ToList();
                    }
                    return null;
                }
                catch (Exception)// i catch er her vi fanger den opstået fejl og giver en evt fejl meddelse/gemmer fejlen i en logfil
                {

                    throw;
                }
            }
        }

        public static async void EditOrdersAsJsonAsync(Order orders)
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
                    // Run the Put controller associated with Order in the webservice
                    await client.PutAsJsonAsync("api/Orders/" + orders.OrderId, orders);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteOrdersAsAsync(Order orders)
        {
            const string serverURL = "http://localhost:41731";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    // Run the Delete controller associated with Order in the webservice
                    await client.DeleteAsync("api/Orders/" + orders.OrderId);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
    }
}
