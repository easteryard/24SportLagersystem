using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using _24SportWS;

namespace _24SportConsole
{
    class Program
    {
        static void Main(string[] args)
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
                    var response = client.GetAsync("api/customers").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        IEnumerable<Customer> customers = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                        foreach (var customer in customers)
                        {
                            Console.WriteLine(customer);
                        }
                    }

                    //var response = client.PostAsJsonAsync("api/events", new Event()).Result;
                    //var response = client.PutAsync("api/events/" + events.Id)
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
