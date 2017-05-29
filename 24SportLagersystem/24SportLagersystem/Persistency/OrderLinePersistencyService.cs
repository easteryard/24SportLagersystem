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
    class OrderLinePersistencyService
    {
        public static async void CreateOrderLineAsAsync(OrderLine orderLine)
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
                    var response = client.PostAsJsonAsync("api/OrderLines", orderLine).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var returnOrderLine = response.Content.ReadAsAsync<OrderLine>();
                        orderLine.OrderLineId = returnOrderLine.Result.OrderLineId;
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();

                }
            }
        }

        public static async Task<List<OrderLine>> LoadOrderLineFromJsonAsync()
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
                    var response = client.GetAsync("api/OrderLines").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var orderLineData = response.Content.ReadAsAsync<IEnumerable<OrderLine>>().Result;
                        return orderLineData.ToList();
                    }
                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static async void EditOrderLinesAsJsonAsync(OrderLine orderLines)
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
                    await client.PutAsJsonAsync("api/OrderLines/" + orderLines.OrderLineId, orderLines);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteOrderLinesAsAsync(OrderLine orderLines)
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
                    await client.DeleteAsync("api/OrderLines/" + orderLines.OrderLineId);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
    }
}
