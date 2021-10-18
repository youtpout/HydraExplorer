using System;
using System.Collections.Generic;
using System.Text;

namespace HydraExplorer.Models
{
    public class Block
    {
        public string hash { get; set; }
        public int height { get; set; }
        public int timestamp { get; set; }
        public int interval { get; set; }
        public int size { get; set; }
        public int transactionCount { get; set; }
        public string miner { get; set; }
        public string reward { get; set; }
    }
}
