﻿using System;
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

            //READ METHOD

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


        public static async void SaveEventsAsJsonAsync(Event events)
        {
            const string SERVER_URL = "http://localhost:3683";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(SERVER_URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PostAsJsonAsync("api/Events", events).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var returnEvent = response.Content.ReadAsAsync<Event>();
                        events.Id = returnEvent.Result.Id;
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
    }
}
