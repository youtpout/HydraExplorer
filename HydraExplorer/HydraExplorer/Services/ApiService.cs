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

        public event EventHandler<bool> Loading;

        public ApiService()
        {
            client = new HttpClient();
        }

        public async Task<Info> GetInfo()
        {
            return await GetCall<Info>("info");
        }

        public async Task<List<BlockInfo>> GetLastBlocks(int count)
        {
            return await GetCall<List<BlockInfo>>($"recent-blocks?count={count}");
        }

        public async Task<List<Transaction>> GetLastTransactions(int count)
        {
            return await GetCall<List<Transaction>>($"recent-txs?count={count}");
        }

        public async Task<Search> Search(string query)
        {
            return await GetCall<Search>($"search?query={query}");
        }

        public async Task<Address> GetAddress(string address)
        {
            return await GetCall<Address>($"address/{address}");
        }

        public async Task<Block> GetBlock(string block)
        {
            return await GetCall<Block>($"block/{block}");
        }

        private async Task<T> GetCall<T>(string getUrl)
        {
            this.ApiCalling();
            var url = $"{urlApi}{getUrl}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                this.ApiCalled();
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                this.ApiCalled();
                throw new Exception(response.ReasonPhrase);
            }
        }

        private void ApiCalling()
        {
            if (Loading != null) { Loading(this, true); }
        }

        private void ApiCalled()
        {
            if (Loading != null) { Loading(this, false); }
        }

        public async Task<Transaction> GetTransaction(string tx)
        {
            return await GetCall<Transaction>($"tx/{tx}");
        }
    }
}
