using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace HydraExplorer.Models
{
    public class Block
    {
        public string hash { get; set; }
        public int height { get; set; }
        public int version { get; set; }
        public string prevHash { get; set; }
        public string merkleRoot { get; set; }
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime timestamp { get; set; }
        public string bits { get; set; }
        public int nonce { get; set; }
        public string hashStateRoot { get; set; }
        public string hashUTXORoot { get; set; }
        public string prevOutStakeHash { get; set; }
        public int prevOutStakeN { get; set; }
        public string signature { get; set; }
        public string chainwork { get; set; }
        public string flags { get; set; }
        public int interval { get; set; }
        public int size { get; set; }
        public int weight { get; set; }
        public List<string> transactions { get; set; }
        public string miner { get; set; }
        public string nextHash { get; set; }
        public double difficulty { get; set; }
        public string reward { get; set; }
        public int confirmations { get; set; }

        public decimal rewardHydra
        {
            get
            {
                if (decimal.TryParse(reward, out decimal result))
                {
                    return result / 100000000;
                }
                return 0;
            }
        }

        public string Date
        {
            get
            {
                DateTime convertedDate = DateTime.SpecifyKind(this.timestamp, DateTimeKind.Utc);
                return convertedDate.ToLocalTime().ToString("yyyy/MM/dd HH:mm:ss");
            }
        }

        public int transactionCount { get { return transactions.Count; } }
    }
}
