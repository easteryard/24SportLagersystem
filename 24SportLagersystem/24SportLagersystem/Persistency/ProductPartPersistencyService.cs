﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using _24SportLagersystem.Model;

namespace _24SportLagersystem.Persistency
{
    class ProductPartPersistencyService
    {
        public static async Task<List<ProductPart>> LoadProductFromJsonAsync()
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
                    // Run the controller associated with ProductPart in the webservice
                    var response = client.GetAsync("api/ProductParts").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var productPartData = response.Content.ReadAsAsync<IEnumerable<ProductPart>>().Result;
                        return productPartData.ToList();
                    }
                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
