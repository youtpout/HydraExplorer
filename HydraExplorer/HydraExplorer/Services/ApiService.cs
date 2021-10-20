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

        public async Task<List<Block>> GetLastBlocks(int count)
        {
            var url = urlApi + "recent-blocks?count=" + count;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<Block>>();
            }
            else
            {
                throw new Exception("No response");
            }
        }

        public async Task<List<Transaction>> GetLastTransactions(int count)
        {
            var url = urlApi + "recent-txs?count=" + count;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<Transaction>>();
            }
            else
            {
                throw new Exception("No response");
            }
        }

        public async Task<Search> Search(string query)
        {
            var url = urlApi + "search?query=" + query;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Search>();
            }
            else
            {
                throw new Exception("No response");
            }
        }

        public async Task<Address> GetAddress(string address)
        {
            var url = urlApi + "address/" + address;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Address>();
            }
            else
            {
                throw new Exception("No response");
            }
        }
    }
}
