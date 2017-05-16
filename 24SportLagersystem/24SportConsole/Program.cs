using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//using _24SportWS;
using _24SportConsole;

namespace _24SportConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // CREATE METHOD
            //SaveEventsAsJsonAsync(new ConsoleCustomer(0, "Karsten", 12345678, "Vejen 1, 4000", "mail@mail.dk"));

            // READ METHOD
            GetCustomerAsAsync();

            // UPDATE METHOD - virker ikke ordentlig i console
            //EditCustomerAsync(new ConsoleCustomer(1, "Knud", 4321, "Hej 123", "mail@mail.dk"));

            // DELETE METHOD - virker ikke ordentlig i console
            //DeleteCustomerAsync(2);
        }

        // CREATE METHOD
        public static async void SaveEventsAsJsonAsync(ConsoleCustomer customer)
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
                    var response = client.PostAsJsonAsync("api/Customers", customer).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var returnEvent = response.Content.ReadAsAsync<ConsoleCustomer>();
                        customer.CustomerId = returnEvent.Result.CustomerId;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                    //new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        // READ METHOD

        public static async void GetCustomerAsAsync()
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
                    var response = client.GetAsync("api/Customers").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        IEnumerable<ConsoleCustomer> customers = response.Content.ReadAsAsync<IEnumerable<ConsoleCustomer>>().Result;
                        foreach (var customer in customers)
                        {
                            Console.WriteLine(customer);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        // UPDATE METHOD
        public static async void EditCustomerAsync(ConsoleCustomer customer)
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
                    var response = client.PutAsJsonAsync("api/Customers/" + customer.CustomerId, customer).Result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        // DELETE METHOD
        public static async void DeleteCustomerAsync(int customer)
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
                    await client.DeleteAsync("api/Customers/" + customer);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
