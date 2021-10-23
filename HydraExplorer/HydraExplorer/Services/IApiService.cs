﻿using HydraExplorer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HydraExplorer.Services
{
    public interface IApiService
    {
        Task<Info> GetInfo();
        Task<List<Block>> GetLastBlocks(int count);
        Task<List<Transaction>> GetLastTransactions(int count);
        Task<Search> Search(string query);
        Task<Address> GetAddress(string address);
        Task<Block> GetBlock(string block);
    }
}
