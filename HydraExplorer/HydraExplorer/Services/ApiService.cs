using HydraExplorer.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HydraExplorer.Services
{
    public class ApiService : IApiService
    {
        HttpClient client;

        string urlApi = "https://explorer.hydrachain.org/api/";
        public ApiService()
        {
            client = new HttpClient();
        }

        public async Task<Info> GetInfo()
        {
            var url = urlApi + "info";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Info>();
            }
            else
            {
                throw new Exception("No response");
            }
        }
    }
}
