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

                // Run lines of code and if errors occur catch them in the catch part
                try
                {
                    // Run the Post controller associated with OrderLine in the webservice
                    var response = client.PostAsJsonAsync("api/Customers", customers).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var returnCustomer = response.Content.ReadAsAsync<Customer>();
                        customers.CustomerId = returnCustomer.Result.CustomerId;
                    }
                }
                // Catch errors occurring in the try part and give it an error message or save it in a log file
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

                // Run lines of code and if errors occur catch them in the catch part
                try
                {
                    // Run the Get controller associated with OrderLine in the webservice
                    var response = client.GetAsync("api/Customers").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var customerData = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                        return customerData.ToList();
                    }
                    return null;
                }
                // Catch errors occurring in the try part and give it an error message or save it in a log file
                catch (Exception)
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

                // Run lines of code and if errors occur catch them in the catch part
                try
                {
                    // Run the Put controller associated with OrderLine in the webservice
                    await client.PutAsJsonAsync("api/Customers/" + customers.CustomerId, customers);
                }
                // Catch errors occurring in the try part and give it an error message or save it in a log file
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
                
                // Run lines of code and if errors occur catch them in the catch part
                try
                {
                    // Run the Delete controller associated with OrderLine in the webservice
                    await client.DeleteAsync("api/Customers/" + customers.CustomerId);
                }
                // Catch errors occurring in the try part and give it an error message or save it in a log file
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
    }
}
