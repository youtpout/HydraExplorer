using HydraExplorer.Models;
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
    }
}
