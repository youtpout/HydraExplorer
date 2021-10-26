using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HydraExplorer.Models
{
    public class Transaction
    {
        public string id { get; set; }
        public string hash { get; set; }
        public int version { get; set; }
        public int lockTime { get; set; }
        public string blockHash { get; set; }
        public List<Input> inputs { get; set; }
        public List<Output> outputs { get; set; }
        public bool isCoinbase { get; set; }
        public bool isCoinstake { get; set; }
        public int blockHeight { get; set; }
        public int confirmations { get; set; }
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime timestamp { get; set; }
        public string inputValue { get; set; }
        public string outputValue { get; set; }
        public string refundValue { get; set; }
        public string fees { get; set; }
        public int size { get; set; }
        public int weight { get; set; }
        public List<Qrc20TokenTransfers> qrc20TokenTransfers { get; set; }

        public string cutId { get { return string.Join("", id.Take(20)) + "..."; } }

        public decimal txHydra
        {
            get
            {
                if (decimal.TryParse(outputValue, out decimal result))
                {
                    return result / 100000000;
                }
                return 0;
            }
        }

        public decimal feesHydra
        {
            get
            {
                if (decimal.TryParse(fees, out decimal result))
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

    }

    public class ScriptSig
    {
        public string type { get; set; }
        public string hex { get; set; }
        public string asm { get; set; }
    }

    public class Input
    {
        public string prevTxId { get; set; }
        public int outputIndex { get; set; }
        public string value { get; set; }
        public string address { get; set; }
        public string addressHex { get; set; }
        public ScriptSig scriptSig { get; set; }
        public long sequence { get; set; }
    }

    public class ScriptPubKey
    {
        public string type { get; set; }
        public string hex { get; set; }
        public string asm { get; set; }
    }

    public class Output
    {
        public string value { get; set; }
        public string address { get; set; }
        public ScriptPubKey scriptPubKey { get; set; }
        public string addressHex { get; set; }
        public Receipt receipt { get; set; }
    }

    public class Receipt
    {
        public string sender { get; set; }
        public int gasUsed { get; set; }
        public string contractAddress { get; set; }
        public string contractAddressHex { get; set; }
        public string excepted { get; set; }
        public string exceptedMessage { get; set; }
        public List<Log> logs { get; set; }
    }

    public class Log
    {
        public string address { get; set; }
        public string addressHex { get; set; }
        public List<string> topics { get; set; }
        public string data { get; set; }
    }

    public class Qrc20TokenTransfers
    {
        public string address { get; set; }
        public string addressHex { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int decimals { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string value { get; set; }
    }

}
