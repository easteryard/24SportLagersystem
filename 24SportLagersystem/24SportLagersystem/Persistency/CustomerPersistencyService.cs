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
    class CustomerPersistencyService
    {

        public static async void SaveCustomersAsJsonAsync(Customer customers)
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
                    var response = client.PostAsJsonAsync("api/Customers", customers).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var returnCustomer = response.Content.ReadAsAsync<Customer>();
                        customers.CustomerId = returnCustomer.Result.CustomerId;
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();

                }
            }
        }

        public static async Task<List<Customer>> LoadCustomersFromJsonAsync()
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
                    var response = client.GetAsync("api/Customers").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var customerData = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                        return customerData.ToList();
                    }
                    return null;
                }
                catch (Exception)// i catch er her vi fanger den opstået fejl og giver en evt fejl meddelse/gemmer fejlen i en logfil
                {

                    throw;
                }
            }
        }

        public static async void EditCustomersAsJsonAsync(Customer customers)
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
                    await client.PutAsJsonAsync("api/Customers/" + customers.CustomerId, customers);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteCustomersAsAsync(Customer customers)
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
                    await client.DeleteAsync("api/Customers/" + customers.CustomerId);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
    }
}
